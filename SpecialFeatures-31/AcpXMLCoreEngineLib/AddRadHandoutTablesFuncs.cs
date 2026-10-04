// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.AddRadHandoutTablesFuncs
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.Buttons;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO2;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO3;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO5;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO7;
using Motorola.MackinawCPS.CoreFeatures.ControlHeadO9;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.KeypadMicAndAccessories;
using Motorola.MackinawCPS.CoreFeatures.SmartKeyFob;
using Motorola.MackinawCPS.CoreFeatures.Switches;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Threading;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public class AddRadHandoutTablesFuncs : IAddRadHandouttables
{
  private string a = RptMgrErrorHandler.b("ꚉ", 7);

  public void AddGeneral(ref _XMLData RptXMLData)
  {
    int A_1 = 8;
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
            int num3 = culture.TextInfo.IsRightToLeft ? 1 : 0;
            radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IAcpField iacpField1;
            IAcpField iacpField2;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDC90\uDC92톔튖햘햚좜튞\uE3A0\uE6A2\uF7A4", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (iacpField2 != null)
                  {
                    num2 = (short) -20137;
                    int num4 = (int) num2;
                    num2 = (short) -20137;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_18;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto case 2;
                case 2:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("좊", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("몊", A_1);
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralSerialNumber_A9122;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 4:
                  if (iacpField2 != null)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 5:
                  RptXMLData.tables.Add(table);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (radioInformation != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_23;
                case 7:
                  goto label_19;
                case 8:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐횒잔\uDE96\uD898힚펜쪞\uECA0\uE1A2\uE0A4\uF5A6", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 0;
                  table.TableTitle = RptMgrErrorHandler.b("첊\uE88C\uE18E\uF490\uE192\uF494ﮖ톘\uF29A列ﮞ쒠춢", A_1);
                  string str = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎횐횒\uDB94튖쮘\uDA9A톜", A_1), culture);
                  table.ColTitle.Add(str);
                  recSet.RecTitle = RptMgrErrorHandler.b("즊", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("뮊", A_1);
                  iacpField1 = (IAcpField) null;
                  iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralModelNumber_A8539;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  recSet = new _RecSet();
                  obj = new _Value();
                  uiFields = new _UIFields();
                  iacpField1 = (IAcpField) null;
                  recSet.RecTitle = RptMgrErrorHandler.b("쾊", A_1);
                  recSet.RecNo = RptMgrErrorHandler.b("릊", A_1);
                  iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
label_18:
                  obj.FieldValue = iacpField2.ToString();
                  uiFields.values.Add(obj);
                  uiFields.UIFieldName = iacpField2.Name;
                  uiFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎힐\uDF92풔쒖톘\uD89A튜\uDB9E\uE4A0", A_1), culture);
                  recSet.UIFields.Add(uiFields);
                  table.RecSet.Add(recSet);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_19:
            return;
label_23:
            return;
        }
    }
  }

  public void AddButtonsAndControl(ref _XMLData RptXMLData)
  {
    int A_1_1 = 19;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        RotaryControlInnerRecset controlInnerRecset1;
        RotaryControlInnerSection controlInnerSection1;
        MFKAssignmentControlInnerRecset controlInnerRecset2;
        MFKAssignmentControlInnerSection controlInnerSection2;
        MFKAssignmentControlInnerSection controlInnerSection3;
        ButtonsRecset buttonsRecset;
        PortableButtonInnerRecset buttonInnerRecset1;
        DataButtonInnerRecset buttonInnerRecset2;
        PortableSideUpDownArrowButtonInnerRecset buttonInnerRecset3;
        KeypadRecset keypadRecset;
        KeypadButtonInnerRecset buttonInnerRecset4;
        SmartKeyFobRecset smartKeyFobRecset;
        SmartKeyFobButtonTableInnerRecset tableInnerRecset;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        Motorola.MackinawCPS.CoreFeatures.Switches.Switches switches;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            controlInnerRecset1 = (RotaryControlInnerRecset) null;
            controlInnerSection1 = (RotaryControlInnerSection) null;
            controlInnerRecset2 = (MFKAssignmentControlInnerRecset) null;
            controlInnerSection2 = (MFKAssignmentControlInnerSection) null;
            controlInnerSection3 = (MFKAssignmentControlInnerSection) null;
            buttonsRecset = (ButtonsRecset) null;
            buttonInnerRecset1 = (PortableButtonInnerRecset) null;
            buttonInnerRecset2 = (DataButtonInnerRecset) null;
            buttonInnerRecset3 = (PortableSideUpDownArrowButtonInnerRecset) null;
            keypadRecset = (KeypadRecset) null;
            buttonInnerRecset4 = (KeypadButtonInnerRecset) null;
            smartKeyFobRecset = (SmartKeyFobRecset) null;
            tableInnerRecset = (SmartKeyFobButtonTableInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            switches = FeatureManager.GetFeature(2038)[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
            num2 = (short) 283;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              _RecSet recSet;
              _UIFields A_0;
              int num3;
              string str1;
              string A_1_2;
              string str2;
              string A_1_3;
              string A_1_4;
              IAcpFeatureNode iacpFeatureNode;
              string str3;
              string A_1_5;
              string A_1_6;
              string A_1_7;
              string A_1_8;
              string A_1_9;
              string A_1_10;
              string A_1_11;
              string A_1_12;
              int num4;
              IEnumerator<FeatureNode> enumerator;
              string A_1_13;
              int num5;
              int num6;
              switch (num1)
              {
                case 0:
                  num2 = (short) 0;
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 125;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 324;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 259;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  try
                  {
                    num2 = (short) 9;
                    int num7 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string A_1_14;
                      string str4;
                      IAcpFeatureNode current;
                      switch (num7)
                      {
                        case 0:
                          num2 = (short) 30;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          goto label_751;
                        case 2:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 21;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 0;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                        case 4:
                          num2 = (short) 1;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 29;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            string functionA41568UiValue = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideUpDownArrowButtonPrimaryFunction_A41568_UIValue;
                            string functionA41592UiValue = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideUpDownArrowButtonSecondaryFunction_A41592_UIValue;
                            string str5 = RptMgrErrorHandler.b("뚕\uE497몙", A_1_1);
                            string str6 = functionA41592UiValue;
                            A_1_14 = functionA41568UiValue + str5 + str6;
                            num2 = (short) 25;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          num2 = (short) 12;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 10:
                        case 17:
                        case 34:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 8;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 19;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, A_1_14);
                            num2 = (short) 35;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 23;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uD89B톝\uF79F\uECA1\uE5A3\uF4A5盛\uE5A9ﮫ", A_1_1), culture);
                          num2 = (short) 17;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (str4 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uD89B톝\uF79F\uECA1\uE5A3\uF4A5盛\uE5A9ﮫ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 13;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num5;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙첛톝\uF29F\uF1A1\uEDA3\uE2A5\uEDA7\uE8A9嶺節", A_1_1), culture) + num5.ToString();
                          num2 = (short) 34;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 2;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                        case 16 /*0x10*/:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 24;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙즛캝\uE19F\uF0A1\uF6A3\uE9A5ﾧ", A_1_1), culture);
                          num2 = (short) 10;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                        case 21:
                        case 22:
                        case 31 /*0x1F*/:
                          A_0.UIFieldName = ((AcpFieldBase) (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideArrowButtonName_A41567).UIName.ToString();
                          str4 = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideArrowButtonName_A41567_UIValue.ToString();
                          num2 = (short) 33;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 26;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 5;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                        case 29:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 31 /*0x1F*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 7;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 3;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                        case 28:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 22;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 28;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          this.a(ref A_0, A_1_14);
                          num2 = (short) 15;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          if (!(str4 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙즛캝\uE19F\uF0A1\uF6A3\uE9A5ﾧ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 14;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 18;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 11;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                      }
                      num2 = (short) 6;
                      num7 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num8 = 0;
                    while (true)
                    {
                      short num9;
                      switch (num8)
                      {
                        case 0:
label_470:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          num9 = (short) -12916;
                          int num10 = (int) num9;
                          num9 = (short) -12916;
                          int num11 = (int) num9;
                          switch (num10 == num11 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_470;
                            default:
                              num9 = (short) 0;
                              if (num9 == (short) 0)
                                ;
                              enumerator.Dispose();
                              num9 = (short) 2;
                              num8 = (int) (IntPtr) num9;
                              continue;
                          }
                        case 2:
                          goto label_477;
                      }
                      if (enumerator != null)
                      {
                        num9 = (short) 1;
                        num8 = (int) (IntPtr) num9;
                      }
                      else
                        break;
                    }
label_477:;
                  }
label_751:
                  table.RecSet.Add(recSet);
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 343;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                case 45:
                  num2 = (short) 257;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 121;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 7:
                case 110:
                case 192 /*0xC0*/:
                case 239:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣\uE5A5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣殮\uEBA7", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 236;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 143;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 318;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                case 122:
                case 302:
                case 327:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣\uE7A5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣殮\uE9A7", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num12 = ((AcpField<int>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).Value;
                  int num13 = ((AcpField<int>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).Value;
                  A_1_5 = (string) ((AcpFieldX<int, string>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).Converter.Convert((object) num12, (Type) null, (object) null, culture);
                  A_1_7 = (string) ((AcpFieldX<int, string>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).Converter.Convert((object) num13, (Type) null, (object) null, culture);
                  num2 = (short) sbyte.MaxValue;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).HiddenStatic)
                  {
                    num2 = (short) 307;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 11:
                case 266:
                  this.a(ref A_0, str3.ToString());
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                case 269:
                  num2 = (short) 328;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 192 /*0xC0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                case 34:
                  num2 = (short) 164;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num2 = (short) 208 /*0xD0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  num2 = (short) 80 /*0x50*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                case 211:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 339;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                case 61:
                case 315:
                case 335:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uED99", A_1_1);
                  A_0.UIFieldDes = "";
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (switches != null)
                  {
                    num2 = (short) 321;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 20:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).HiddenStatic)
                  {
                    num2 = (short) 313;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 373;
                case 21:
                case 117:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 240 /*0xF0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  this.a(ref A_0, A_1_12);
                  num2 = (short) 359;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  if (!((Recordset) smartKeyFobRecset).HiddenStatic)
                  {
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_833;
                case 24:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣\uE4A5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣殮\uEAA7", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uF097\uE899鍊ﮝﾟ\uF2A1쮣향솧\uDEA9얫솭\uDEAF\uEDB1\uE0B3\uD9B5\uDFB7\uDDB9킻\uDBBD", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  int num14 = ((AcpField<int>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).Value;
                  int num15 = ((AcpField<int>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).Value;
                  A_1_12 = (string) ((AcpFieldX<int, string>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).Converter.Convert((object) num14, (Type) null, (object) null, culture);
                  A_1_13 = (string) ((AcpFieldX<int, string>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).Converter.Convert((object) num15, (Type) null, (object) null, culture);
                  num2 = (short) 284;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                case 343:
                  this.a(ref A_0, str3.ToString());
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).HiddenStatic)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 27:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 256 /*0x0100*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 148;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 167;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_833;
                case 29:
                case 306:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  num2 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  num2 = (short) 262;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                case 37:
                case 188:
                case 350:
                  A_0.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnButtonDataButtonName_A22612).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uD89B\uDF9D\uF49F\uE3A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD\uEFAF莱", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 292;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                case 146:
                  num2 = (short) 149;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 36:
                  num2 = (short) 132;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  num2 = (short) 162;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 286;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 40:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 153;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 204;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                case 111:
                case 199:
                case 295:
                  num2 = (short) 218;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 295;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 55;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 87;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  if (switches != null)
                  {
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 378;
                case 47:
                  this.a(ref A_0, "");
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 285;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  num2 = (short) 361;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                case 198:
                case 213:
                  num2 = (short) 160 /*0xA0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                  num2 = (short) 278;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (isRightToLeft)
                  {
                    num2 = (short) 150;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  this.a(ref A_0, "");
                  num2 = (short) 163;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 54:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 211;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 193;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 234;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                case 177:
                case 184:
                case 381:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣\uE4A5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣殮\uEAA7", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num16 = ((AcpField<int>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).Value;
                  int num17 = ((AcpField<int>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).Value;
                  A_1_6 = (string) ((AcpFieldX<int, string>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).Converter.Convert((object) num16, (Type) null, (object) null, culture);
                  A_1_10 = (string) ((AcpFieldX<int, string>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).Converter.Convert((object) num17, (Type) null, (object) null, culture);
                  num2 = (short) 154;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 59:
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  if (controlInnerRecset2 != null)
                  {
                    num2 = (short) 181;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 378;
                case 62:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).HiddenStatic)
                  {
                    num2 = (short) 226;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 85;
                case 63 /*0x3F*/:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_9);
                    num2 = (short) 254;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 299;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 271;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                case 204:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 360;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  num2 = (short) 165;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                case 363:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 239;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 293;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 229;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  this.a(ref A_0, A_1_11);
                  num2 = (short) 375;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).HiddenStatic)
                  {
                    num2 = (short) 176 /*0xB0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 268;
                case 72:
                  num2 = (short) 288;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 349;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 230;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 235;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 75:
                  this.a(ref A_0, A_1_13);
                  num2 = (short) 327;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 76:
                  this.a(ref A_0, A_1_11);
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                case 207:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 137;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).HiddenStatic)
                  {
                    num2 = (short) 120;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 241;
                case 79:
                  num2 = (short) 171;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 223;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 106;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  num2 = (short) 312;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 82:
                case 131:
                case 330:
                case 375:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣\uE7A5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uE999\uF59B\uEA9D즟춡쪣殮\uE9A7", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num18 = ((AcpField<int>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).Value;
                  int num19 = ((AcpField<int>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).Value;
                  A_1_8 = (string) ((AcpFieldX<int, string>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).Converter.Convert((object) num18, (Type) null, (object) null, culture);
                  A_1_3 = (string) ((AcpFieldX<int, string>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).Converter.Convert((object) num19, (Type) null, (object) null, culture);
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 83:
                  this.a(ref A_0, str3.ToString());
                  num2 = (short) 316;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 84:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 72;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 82;
                case 85:
                  num2 = (short) 282;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 86:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 209;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 87:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 372;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 158;
                case 88:
                  controlInnerRecset2 = ((FeatureNode) switches)[10637].EmbeddedRecset as MFKAssignmentControlInnerRecset;
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 89:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 329;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 189;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 91:
                case 125:
                case 126:
                case 360:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uED99쪛\uF19D첟", A_1_1);
                  A_0.UIFieldDes = "";
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 366;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 334;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 238;
                case 93:
                case 156:
                  num2 = (short) 224 /*0xE0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 94:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛펝\uE19F\uF0A1\uF0A3\uEDA5\uEDA7\uF3A9\uEAAB\uE1AD\uF2AF\uF0B1\uE1B3\uE2B5\uECB7\uF5B9\uF2BB\uEDBD", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num6 = 0;
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 261;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 95:
                  if (isRightToLeft)
                  {
                    num2 = (short) 161;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 265;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                case 163:
                  num2 = (short) 231;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                  this.a(ref A_0, A_1_10);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 99:
                  if (smartKeyFobRecset != null)
                  {
                    num2 = (short) 180;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 100:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 130;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 101:
                  if (controlInnerSection1 != null)
                  {
                    num2 = (short) 123;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 50;
                case 102:
                  if (isRightToLeft)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 81;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 103:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 267;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 104:
                  this.a(ref A_0, "");
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 75;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 106:
                  this.a(ref A_0, A_1_13);
                  num2 = (short) 247;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  num2 = (short) 102;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 336;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 93;
                case 109:
                  num2 = (short) 95;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 112 /*0x70*/:
                  this.a(ref A_0, A_1_10);
                  num2 = (short) 110;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 113:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 115;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 352;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 114:
                  if (isRightToLeft)
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 365;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 115:
                  num2 = (short) 280;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 116:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (isRightToLeft)
                  {
                    num2 = (short) 142;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 344;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 118:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 119:
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 120:
                  this.a(ref A_0, A_1_8);
                  num2 = (short) 241;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 121:
                  this.a(ref A_0, A_1_7);
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 123:
                  num2 = (short) 200;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 124:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 294;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case (int) sbyte.MaxValue:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 169;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 331;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 128 /*0x80*/:
                  num2 = (short) 317;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 129:
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 130:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).HiddenStatic)
                  {
                    num2 = (short) 219;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 151;
                case 132:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 135;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 133:
                  this.a(ref A_0, A_1_10);
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 134:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 335;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 135:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 300;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 341;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 136:
                  controlInnerRecset1 = ((FeatureNode) switches)[10081].EmbeddedRecset as RotaryControlInnerRecset;
                  num2 = (short) 342;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 137:
                case 364:
                  A_0.UIFieldName = RptMgrErrorHandler.b("얕ﶗ蓮\uF39B\uF09D쒟쎡횣\uDFA5\uEEA7\uDFA9슫춭쒯\uDBB1\uDBB3\uD8B5", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕ﶗ蓮\uF39B\uF09D쒟쎡횣\uDFA5\uF7A7\uECA9\uD9AB삭펯욱\uDDB3\uD9B5횷", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 198;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 138:
                  num2 = (short) 272;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 139:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 184;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 140:
                  if (((Recordset) buttonInnerRecset3).HasVisibleObjects)
                  {
                    num2 = (short) 141;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 141:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ID_SIDEARROWBUTTONS;
                  recSet.RecNo = num3.ToString();
                  num5 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 142:
                  num2 = (short) 90;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 143:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 244;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 144 /*0x90*/:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 145:
                  num2 = (short) 101;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 147:
                  num2 = (short) 347;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 148:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 149:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).HiddenStatic)
                  {
                    num2 = (short) 139;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 150:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 151:
                  num2 = (short) 105;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 152:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 207;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 153:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 154:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 194;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 155:
                case 368:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 157:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 379;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 158:
                case 193:
                  num2 = (short) 250;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 159:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 160 /*0xA0*/:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 183;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 161:
                  num2 = (short) 275;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 162:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 249;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 164:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).HiddenStatic)
                  {
                    num2 = (short) 297;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 165:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 220;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 212;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 166:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 305;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 167:
                  num2 = (short) 173;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 168:
                case 209:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 169:
                  num2 = (short) 186;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 170:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 177;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 171:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("힕좗슙꾛꺝邟銡", A_1_1)))
                  {
                    num2 = (short) 94;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_833;
                case 172:
                  this.a(ref A_0, "");
                  num2 = (short) 363;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 173:
                  if (!UtilityMack.IsWorldWidePro)
                  {
                    num2 = (short) 174;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 308;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 174:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("힕좗슙꾛꺝邟銡", A_1_1)))
                  {
                    num2 = (short) 246;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 175:
                  num2 = (short) 279;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 176 /*0xB0*/:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 268;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 178:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uEF97\uF599쎛캝쾟톡춣튥솧얩슫\uF1AD\uF3AF\uDDB1\uDAB3햵\uDDB7풹좻첽ꦿꇁ", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  int num20 = ((AcpField<int>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).Value;
                  int num21 = ((AcpField<int>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).Value;
                  A_1_11 = (string) ((AcpFieldX<int, string>) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).Converter.Convert((object) num20, (Type) null, (object) null, culture);
                  A_1_4 = (string) ((AcpFieldX<int, string>) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).Converter.Convert((object) num21, (Type) null, (object) null, culture);
                  num2 = (short) 263;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 179:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 180:
                  tableInnerRecset = ((Recordset) smartKeyFobRecset)[0][10747].EmbeddedRecset as SmartKeyFobButtonTableInnerRecset;
                  num2 = (short) 205;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 181:
                  controlInnerSection2 = ((Recordset) controlInnerRecset2)[0][10638] as MFKAssignmentControlInnerSection;
                  controlInnerSection3 = ((Recordset) controlInnerRecset2)[1][10638] as MFKAssignmentControlInnerSection;
                  num2 = (short) 378;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 182:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD95ﶗ\uE399\uEC9Bﾝ쒟ﶡ\uE6A3펥\uDCA7\uDEA9쎫삭쎯", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset4).GetEnumerator();
                  num2 = (short) 264;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 183:
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset1).GetEnumerator();
                  num2 = (short) 253;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 185:
                case 247:
                  num2 = (short) 351;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 186:
                  if (isRightToLeft)
                  {
                    num2 = (short) 128 /*0x80*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 187:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).HiddenStatic)
                  {
                    num2 = (short) 216;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 129;
                case 189:
                case 234:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 315;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 190:
                  num2 = (short) 166;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 191:
                  this.a(ref A_0, A_1_7);
                  num2 = (short) 146;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 194:
                  num2 = (short) 310;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 195:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 190;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 196:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 345;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 197:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 215;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 200:
                  if (((FeatureSection) controlInnerSection1).HasVisibleObjects)
                  {
                    num2 = (short) 214;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 50;
                case 201:
                  smartKeyFobRecset = FeatureManager.GetFeature(4130) as SmartKeyFobRecset;
                  num2 = (short) 99;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 202:
                  if (buttonsRecset != null)
                  {
                    num2 = (short) 348;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 103;
                case 203:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 206;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 357;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 205:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풕\uED97\uEE99\uE89B\uF19D캟톡ﮣ장욧캩\uF3AB\uEDAD\uDFAF\uDCB1삳쒵ힷ횹쾻", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uF697ﺙ鍊\uE69Dﾟ\uEBA1삣", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("튕ﶗ\uE999ﾛ\uEC9D즟튡킣쾥잧쒩\uF3AB\uE7AD풯", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("햕\uF797\uF499\uEA9Bﮝ캟횡춣즥욧쮩삫\uF1AD羚횱", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uEA97\uEF99\uF29B\uF59D즟첡쎣殮\uE1A7\uEEA9", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 206:
                  num2 = (short) 371;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 208 /*0xD0*/:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 228;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 210:
                  if (isRightToLeft)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, str3.ToString());
                  num2 = (short) 369;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 212:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 214:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  int controlA8984Value = controlInnerSection1.SwitchGeneralRotaryControl_A8984Value;
                  str1 = (string) ((AcpFieldX<int, string>) controlInnerSection1.SwitchGeneralRotaryControl_A8984).Converter.Convert((object) controlA8984Value, (Type) null, (object) null, culture);
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 215:
                case 376:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 273;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 216:
                  this.a(ref A_0, A_1_8);
                  num2 = (short) 129;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 217:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 319;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 137;
                case 218:
                  if (((FeatureSection) switches.ConventionalSwitches).HasVisibleObjects)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 219:
                  this.a(ref A_0, A_1_12);
                  num2 = (short) 151;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 220:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 172;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 67;
                case 221:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 222:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 188;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 223:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 251;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 185;
                case 224 /*0xE0*/:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).HiddenStatic)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 225:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 74;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 258;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 226:
                  this.a(ref A_0, A_1_11);
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 227:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 221;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 228:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 117;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 229:
                  num2 = (short) 338;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 230:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 322;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 231:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).HiddenStatic)
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 232:
                  this.a(ref A_0, A_1_10);
                  num2 = (short) 93;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 233:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 235:
                  this.a(ref A_0, "");
                  num2 = (short) 269;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 236:
                  num2 = (short) 304;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 237:
                  if (((Recordset) buttonInnerRecset2).HasVisibleObjects)
                  {
                    num2 = (short) 367;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 292;
                case 238:
                case 339:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uED99", A_1_1);
                  A_0.UIFieldDes = "";
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num22 = ((AcpField<int>) controlInnerSection2.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Value;
                  A_1_9 = (string) ((AcpFieldX<int, string>) controlInnerSection2.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Converter.Convert((object) num22, (Type) null, (object) null, culture);
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 240 /*0xF0*/:
                case 271:
                case 273:
                case 379:
                  A_0.UIFieldName = ((AcpFieldBase) controlInnerSection1.SwitchRotaryControlButtonName_A22903).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙캛톝\uF49F\uE3A1\uF6A3ﾥ\uEBA7\uE5A9\uE2AB節\uE2AFﶱ\uF8B3", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 213;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 241:
                  num2 = (short) 291;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 242:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 107;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 243:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 155;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 244:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 240 /*0xF0*/;
                case 245:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 246:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  num2 = (short) 73;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 248:
                  this.a(ref A_0, A_1_13);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 249:
                  num2 = (short) 140;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 250:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).HiddenStatic)
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 82;
                case 251:
                  this.a(ref A_0, "");
                  num2 = (short) 185;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 252:
                  controlInnerSection1 = ((Recordset) controlInnerRecset1)[0][10082] as RotaryControlInnerSection;
                  num2 = (short) 119;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 253:
                  try
                  {
                    num2 = (short) 66;
                    int num23 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str7;
                      string str8;
                      PortableButtonInnerSection buttonInnerSection;
                      string str9;
                      string str10;
                      IAcpFeatureNode current;
                      switch (num23)
                      {
                        case 0:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE6A3\uE9A5ﲧﺩ\uE3AB\uE3AD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1_1), culture);
                          num2 = (short) 29;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 50;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 57;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!((AcpFieldBase) buttonInnerSection.BtnGeneralConventionalFeature_A19544).HiddenStatic)
                          {
                            num2 = (short) 21;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 58;
                        case 3:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 38;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 14;
                        case 4:
                          num2 = (short) 43;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (!(str10 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uF0A3\uE9A5\uF8A7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 26;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 45;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                        case 62:
                          num2 = (short) 51;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          this.a(ref A_0, "");
                          num2 = (short) 61;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 41;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙좛톝\uF09F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1_1), culture);
                          num2 = (short) 16 /*0x10*/;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE9A3\uEFA5\uECA7\uEEA9\uE0AB\uEBAD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1_1), culture);
                          num2 = (short) 24;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 55;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 40;
                        case 12:
                          num2 = (short) 2;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 11;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                        case 64 /*0x40*/:
                          num2 = (short) 52;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!(str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE6A3\uE9A5ﲧﺩ\uE3AB\uE3AD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙첛톝\uF29F\uF6A1\uE5A3\uE4A5\uE4A7\uEFA9\uEEABﮭ\uE4AF\uE6B1﮳\uF8B5", A_1_1), culture);
                            num2 = (short) 36;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                        case 24:
                        case 25:
                        case 29:
                        case 36:
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 48 /*0x30*/;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          num2 = (short) 60;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          this.a(ref A_0, str9.ToString());
                          num2 = (short) 64 /*0x40*/;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          if (isRightToLeft)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 33;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 40;
                        case 21:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 58;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          goto label_739;
                        case 23:
                          if (!((AcpFieldBase) buttonInnerSection.BtnGeneralConventionalFeature_A19544).HiddenStatic)
                          {
                            num2 = (short) 72;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 53;
                        case 26:
                          if (!(str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uE9A3\uEFA5\uECA7\uEEA9\uE0AB\uEBAD\uF2AF\uE7B1\uE0B3\uE2B5\uF7B7\uF4B9", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 15;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          num2 = (short) 46;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 59;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 8;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 41;
                        case 31 /*0x1F*/:
                          this.a(ref A_0, "");
                          num2 = (short) 6;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 3;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 18;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          this.a(ref A_0, str9.ToString());
                          num2 = (short) 69;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 71;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (IAcpFeatureNode) enumerator.Current;
                          recSet = new _RecSet();
                          A_0 = new _UIFields();
                          ++num3;
                          recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                          recSet.RecNo = num3.ToString();
                          buttonInnerSection = current[10092] as PortableButtonInnerSection;
                          int featureA19544Value = (current[10092] as PortableButtonInnerSection).BtnGeneralConventionalFeature_A19544Value;
                          int featureA19546Value = (current[10092] as PortableButtonInnerSection).BtnTrunkingPortableButtonFeature_A19546Value;
                          str7 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnGeneralConventionalFeature_A19544).Converter.Convert((object) featureA19544Value, (Type) null, (object) null, culture);
                          str8 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnTrunkingPortableButtonFeature_A19546).Converter.Convert((object) featureA19546Value, (Type) null, (object) null, culture);
                          int num24 = AcpField<int>.op_Implicit((AcpField<int>) (current[10092] as PortableButtonInnerSection).BtnTopButtonShortPressTime);
                          str9 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnTopButtonShortPressTime).Converter.Convert((object) num24, (Type) null, (object) null, culture);
                          num2 = (short) 13;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          this.a(ref A_0, str9.ToString());
                          num2 = (short) 47;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          if (str10 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙좛톝\uF09F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 9;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 5;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          this.a(ref A_0, "");
                          num2 = (short) 14;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 39:
                          if (((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 67;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 47;
                        case 40:
                        case 42:
                        case 59:
                        case 69:
                          A_0.UIFieldName = ((AcpFieldBase) ((PortableButtonInner) current).PortableButtonInnerSection.BtnPortableButtonName_A22558).UIName.ToString();
                          str10 = ((PortableButtonInner) current).PortableButtonInnerSection.BtnPortableButtonName_A22558_UIValue.ToString();
                          num2 = (short) 37;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          num2 = (short) 20;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          if (((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 39;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 62;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙쾛힝\uE49F\uE7A1\uF0A3\uE9A5\uF8A7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), culture);
                          num2 = (short) 25;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 46:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 23;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                        case 49:
                          num2 = (short) 1;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 54;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          if (!((AcpFieldBase) buttonInnerSection.BtnGeneralConventionalFeature_A19544).HiddenStatic)
                          {
                            num2 = (short) 28;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 40;
                        case 52:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 44;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 70;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 53:
                          num2 = (short) 30;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 54:
                        case 61:
                          num2 = (short) 68;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 55:
                          num2 = (short) 19;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 56:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 17;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 57:
                          if (((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 7;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 54;
                        case 58:
                          num2 = (short) 65;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 60:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic)
                          {
                            num2 = (short) 73;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 40;
                        case 63 /*0x3F*/:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 40;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 65:
                          if (!((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 56;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 17;
                        case 66:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 67:
                          this.a(ref A_0, "");
                          num2 = (short) 49;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 68:
                          if (!((AcpFieldBase) buttonInnerSection.BtnGeneralConventionalFeature_A19544).HiddenStatic)
                          {
                            num2 = (short) 63 /*0x3F*/;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 40;
                        case 70:
                          if (((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic)
                          {
                            num2 = (short) 31 /*0x1F*/;
                            num23 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 71:
                          num2 = (short) 22;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 72:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 53;
                          num23 = (int) (IntPtr) num2;
                          continue;
                        case 73:
                          this.a(ref A_0, str9.ToString());
                          num2 = (short) 42;
                          num23 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 34;
                      num23 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num25 = 0;
                    int num26 = (int) (IntPtr) num25;
                    while (true)
                    {
                      switch (num26)
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
                          goto label_613;
                        case 2:
                          enumerator.Dispose();
                          num25 = (short) 1;
                          num26 = (int) (IntPtr) num25;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num25 = (short) 2;
                        num26 = (int) (IntPtr) num25;
                      }
                      else
                        break;
                    }
label_613:;
                  }
                case 254:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 309;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 326;
                case (int) byte.MaxValue:
                  buttonInnerRecset4 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 201;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 256 /*0x0100*/:
                  this.a(ref A_0, A_1_13);
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 257:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).HiddenStatic)
                  {
                    num2 = (short) 380;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 258:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 259:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 58;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 266;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 260:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_2);
                    num2 = (short) 217;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 175;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 261:
                  try
                  {
                    num2 = (short) 11;
                    int num27 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string featureA41575UiValue;
                      string str11;
                      IAcpFeatureNode current;
                      SmartKeyFobButtonTableInnerSection tableInnerSection;
                      string featureA41574UiValue;
                      switch (num27)
                      {
                        case 0:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 28;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 21;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            tableInnerSection = current[10748] as SmartKeyFobButtonTableInnerSection;
                            featureA41574UiValue = (current[10748] as SmartKeyFobButtonTableInnerSection).RadErgoCfgFobConventionalFeature_A41574_UIValue;
                            featureA41575UiValue = (current[10748] as SmartKeyFobButtonTableInnerSection).RadErgoCfgFobTrunkingFeature_A41575_UIValue;
                            num2 = (short) 23;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 15;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 29;
                        case 3:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ킣풥\uDDA7쒩잫", A_1_1), culture);
                          num2 = (short) 14;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uDD9B튝\uE19F\uF0A1\uE9A3", A_1_1), culture);
                          num2 = (short) 30;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 7:
                        case 9:
                        case 14:
                        case 20:
                        case 25:
                        case 30:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 8;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          num2 = (short) 13;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (!(str11 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ톣횥", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 18;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 31 /*0x1F*/;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 12:
                          num2 = (short) 0;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          goto label_614;
                        case 15:
                          this.a(ref A_0, featureA41575UiValue);
                          num2 = (short) 29;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (str11 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDA95\uF797蓮\uF79B솝쒟춡펣좥", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 35;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (str11 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uDD9B튝\uE19F\uF0A1\uE9A3", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 4;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num6;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙\uDA9B톝\uE29F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1_1), culture) + num6.ToString();
                          num2 = (short) 7;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (str11 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ삣즥\uDFA7쒩", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 24;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 19;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          if (!(str11 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ킣풥\uDDA7쒩잫", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 17;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 3;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, featureA41575UiValue);
                          num2 = (short) 34;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDA95\uF797蓮\uF79B솝햟튡", A_1_1), culture);
                          num2 = (short) 5;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (isRightToLeft)
                          {
                            num2 = (short) 12;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 36;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ삣즥\uDFA7쒩", A_1_1), culture);
                          num2 = (short) 25;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          num2 = (short) 2;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (!(str11 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDA95\uF797蓮\uF79B솝햟튡", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 16 /*0x10*/;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 22;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                        case 34:
                          num2 = (short) 32 /*0x20*/;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                        case 37:
                          A_0.UIFieldName = ((AcpFieldBase) ((SmartKeyFobButtonTableInner) current).SmartKeyFobButtonTableInnerSection.RadErgoCfgFobButtonName_A41573).UIName.ToString();
                          str11 = ((SmartKeyFobButtonTableInner) current).SmartKeyFobButtonTableInnerSection.RadErgoCfgFobButtonName_A41573_UIValue.ToString();
                          num2 = (short) 27;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎕\uF697\uF699\uF39Bﶝ쮟ﶡ톣횥", A_1_1), culture);
                          num2 = (short) 20;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (!((AcpFieldBase) tableInnerSection.RadErgoCfgFobConventionalFeature_A41574).HiddenStatic)
                          {
                            num2 = (short) 38;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 29;
                        case 33:
                          this.a(ref A_0, featureA41574UiValue);
                          num2 = (short) 26;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDA95\uF797蓮\uF79B솝쒟춡펣좥", A_1_1), culture);
                          num2 = (short) 9;
                          num27 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          if (!((AcpFieldBase) tableInnerSection.RadErgoCfgFobConventionalFeature_A41574).HiddenStatic)
                          {
                            num2 = (short) 33;
                            num27 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 26;
                        case 38:
                          this.a(ref A_0, featureA41574UiValue);
                          num2 = (short) 37;
                          num27 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 1;
                      num27 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num28 = 0;
                    while (true)
                    {
                      short num29;
                      switch (num28)
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
                          goto label_686;
                        case 2:
                          enumerator.Dispose();
                          num29 = (short) 1;
                          num28 = (int) (IntPtr) num29;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num29 = (short) 2;
                        num28 = (int) (IntPtr) num29;
                      }
                      else
                        break;
                    }
label_686:;
                  }
label_614:
                  table.RecSet.Add(recSet);
                  num2 = (short) 337;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 262:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 245;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_833;
                case 263:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 84;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 276;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 264:
                  try
                  {
                    num2 = (short) 45;
                    int num30 = (int) (IntPtr) num2;
                    while (true)
                    {
                      IAcpFeatureNode current;
                      string str12;
                      string A_1_15;
                      KeypadButtonInnerSection buttonInnerSection;
                      switch (num30)
                      {
                        case 0:
                          if (isRightToLeft)
                          {
                            num2 = (short) 12;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 21;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 47;
                        case 2:
                        case 5:
                        case 9:
                        case 11:
                        case 23:
                        case 28:
                        case 30:
                        case 32 /*0x20*/:
                        case 39:
                        case 43:
                        case 49:
                        case 51:
                        case 52:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 27;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("킕\uF197\uEC99鍊ꮝﾟ\uEBA1삣", A_1_1), culture);
                          num2 = (short) 49;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          this.a(ref A_0, A_1_15);
                          num2 = (short) 18;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD895\uF197\uF499鍊ꞝﾟ\uEBA1삣", A_1_1), culture);
                          num2 = (short) 11;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("킕\uF197\uEC99鍊ꮝﾟ\uEBA1삣", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 3;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 55;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕\uEC97ﮙ\uEE9B솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 37;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 29;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("킕\uF797\uEF99\uEE9Bꪝﾟ\uEBA1삣", A_1_1), culture);
                          num2 = (short) 39;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 31 /*0x1F*/;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uEF97\uF599꺛솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 40;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 44;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                        case 36:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str12 = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 22;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection = current[10709] as KeypadButtonInnerSection;
                            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                            A_1_15 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                            num2 = (short) 0;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uEF99\uF29B瞧\uE89F쎡힣캥\uF7A7\uE3A9좫", A_1_1), culture);
                          num2 = (short) 30;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("펕\uF197ﶙ\uF49B\uEA9D颟ﶡ\uEDA3슥", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 41;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 38;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                        case 25:
                          num2 = (short) 34;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          goto label_825;
                        case 20:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uF097\uE899鍊ﮝ鎟ﶡ\uEDA3슥", A_1_1), culture);
                          num2 = (short) 2;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, A_1_15);
                          num2 = (short) 47;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          if (str12 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙욛\uDB9D\uF29F\uEDA1钣", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 42;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 33;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("킕\uF797\uEF99\uEE9Bꪝﾟ\uEBA1삣", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 7;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD995\uF697ﾙ궛솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 51;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uEF99\uF29B瞧\uE89F쎡힣캥\uF7A7\uE3A9좫", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            ++num4;
                            A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙힛\uDB9D烈\uF2A1\uE5A3\uE2A5\uEAA7ﾩ\uF8AB節ﾯﲱ", A_1_1), culture) + num4.ToString();
                            num2 = (short) 9;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 4;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 25;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          if (str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD995\uF697ﾙ궛솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 26;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 13;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          if (!((AcpFieldBase) buttonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 50;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 14;
                        case 35:
                          num2 = (short) 19;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕\uEC97ﮙ\uEE9B솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 52;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD895\uF197\uF499鍊ꞝﾟ\uEBA1삣", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 8;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uF097\uE899鍊ﮝ鎟ﶡ\uEDA3슥", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 24;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("펕\uF197ﶙ\uF49B\uEA9D颟ﶡ\uEDA3슥", A_1_1), culture);
                          num2 = (short) 5;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF95\uDC97얙욛\uDB9D\uF29F\uEDA1钣", A_1_1), culture);
                          num2 = (short) 43;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슕\uEF97\uF599꺛솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 23;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 46:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕\uF197\uE299ꪛ솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 32 /*0x20*/;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          num2 = (short) 48 /*0x30*/;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 53;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 14;
                        case 50:
                          this.a(ref A_0, A_1_15);
                          num2 = (short) 36;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 53:
                          this.a(ref A_0, A_1_15);
                          num2 = (short) 14;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 54:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕ﶗ\uEC99鍊\uF09D鞟ﶡ\uEDA3슥", A_1_1), culture);
                          num2 = (short) 28;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 55:
                          if (str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕\uF197\uE299ꪛ솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 46;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 56;
                          num30 = (int) (IntPtr) num2;
                          continue;
                        case 56:
                          if (!(str12 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얕ﶗ\uEC99鍊\uF09D鞟ﶡ\uEDA3슥", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 17;
                            num30 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 54;
                          num30 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 15;
                      num30 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num31 = 2;
                    int num32 = (int) (IntPtr) num31;
                    while (true)
                    {
                      switch (num32)
                      {
                        case 0:
                          enumerator.Dispose();
                          num31 = (short) 1;
                          num32 = (int) (IntPtr) num31;
                          continue;
                        case 1:
                          goto label_377;
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
                        num31 = (short) 0;
                        num32 = (int) (IntPtr) num31;
                      }
                      else
                        break;
                    }
label_377:;
                  }
label_825:
                  table.RecSet.Add(recSet);
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 265:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 354;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 267:
                  if (keypadRecset != null)
                  {
                    num2 = (short) byte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 201;
                case 268:
                  num2 = (short) 323;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 270:
                  if (isRightToLeft)
                  {
                    num2 = (short) 325;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 227;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 272:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 274:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 275:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 368;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 243;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 276:
                  num2 = (short) 287;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 277:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 278:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 112 /*0x70*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 279:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 152;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 280:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 187;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 281:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                    num2 = (short) 92;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 138;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 282:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 374;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 82;
                case 283:
                  if (switches != null)
                  {
                    num2 = (short) 136;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 119;
                case 284:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 242;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 314;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 285:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 286:
                  num2 = (short) 203;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 287:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 296;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 277;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 288:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 225;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 289:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 298;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 196;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 290:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 350;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 291:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 233;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 292:
                  num2 = (short) 311;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 293:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 179;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 240 /*0xF0*/;
                case 294:
                  this.a(ref A_0, "");
                  num2 = (short) 306;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 296:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).HiddenStatic)
                  {
                    num2 = (short) 76;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 49;
                case 297:
                  this.a(ref A_0, A_1_12);
                  num2 = (short) 302;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 298:
                  num2 = (short) 210;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 299:
                  num2 = (short) 332;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 300:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 53;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 97;
                case 301:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 182;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 303:
                  this.a(ref A_0, A_1_12);
                  num2 = (short) 122;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 304:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("힕좗슙꾛꺝邟銡", A_1_1)))
                  {
                    num2 = (short) 145;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 50;
                case 305:
                  this.a(ref A_0, A_1_7);
                  num2 = (short) 381;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 307:
                  this.a(ref A_0, A_1_8);
                  num2 = (short) 111;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 308:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB95\uED97\uF699\uE89B\uF79Dﾟ\uE4A1톣좥쮧\uDEA9얫솭\uDEAF\uEDB1ﾳ\uD8B5ힷ\uD8B9", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num2 = (short) 281;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 309:
                  this.a(ref A_0, A_1_9);
                  num2 = (short) 358;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 310:
                  if (isRightToLeft)
                  {
                    num2 = (short) 147;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 311:
                  if (buttonInnerRecset4 != null)
                  {
                    num2 = (short) 370;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 38;
                case 312:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).HiddenStatic)
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 359;
                case 313:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 373;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 314:
                  num2 = (short) 100;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 316:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 290;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 317:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 340;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 191;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 318:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 376;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 197;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 319:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 364;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 320:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic)
                  {
                    num2 = (short) 248;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 321:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  num2 = (short) 382;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 322:
                  num2 = (short) 270;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 323:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 98;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 324:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).HiddenStatic)
                  {
                    num2 = (short) 195;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 325:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 86;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 168;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 326:
                case 358:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욕\uEA97\uF399\uF19Bﾝ튟\uDBA1\uE2A3펥욧즩\uD8AB잭\uDFAF\uDCB1", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uEA97\uF399\uF19Bﾝ튟\uDBA1ﮣ\uE0A5\uDDA7쒩쾫\uDAAD\uD9AF\uDDB1\uDAB3", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num33 = ((AcpField<int>) controlInnerSection3.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Value;
                  A_1_2 = (string) ((AcpFieldX<int, string>) controlInnerSection3.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Converter.Convert((object) num33, (Type) null, (object) null, culture);
                  num2 = (short) 260;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 328:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).HiddenStatic)
                  {
                    num2 = (short) 353;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 82;
                case 329:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic)
                  {
                    num2 = (short) 47;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 331:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 36;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 332:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 356;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, "");
                  num2 = (short) 355;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 333:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 157;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 240 /*0xF0*/;
                case 334:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uEBA1삣", A_1_1), culture));
                  num2 = (short) 238;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 336:
                  this.a(ref A_0, "");
                  num2 = (short) 156;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 337:
                  goto label_833;
                case 338:
                  if (isRightToLeft)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 333;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 340:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic)
                  {
                    num2 = (short) 377;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 341:
                  this.a(ref A_0, A_1_7);
                  num2 = (short) 97;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 342:
                  if (controlInnerRecset1 != null)
                  {
                    num2 = (short) 252;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 119;
                case 344:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 134;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 345:
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 346:
                  num2 = (short) 114;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 347:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 124;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 133;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 348:
                  buttonInnerRecset1 = ((Recordset) buttonsRecset)[0][10091].EmbeddedRecset as PortableButtonInnerRecset;
                  buttonInnerRecset2 = ((Recordset) buttonsRecset)[0][10089].EmbeddedRecset as DataButtonInnerRecset;
                  buttonInnerRecset3 = ((Recordset) buttonsRecset)[0][10745].EmbeddedRecset as PortableSideUpDownArrowButtonInnerRecset;
                  num2 = (short) 103;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 349:
                  num2 = (short) 116;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 351:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).HiddenStatic)
                  {
                    num2 = (short) 303;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 352:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 346;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 353:
                  this.a(ref A_0, A_1_11);
                  num2 = (short) 330;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 354:
                  this.a(ref A_0, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1_1), culture));
                  num2 = (short) 126;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 355:
                case 362:
                  this.a(ref A_0, A_1_9);
                  num2 = (short) 326;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 356:
                  this.a(ref A_0, A_1_9);
                  num2 = (short) 362;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 357:
                  if (((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic)
                  {
                    num2 = (short) 108;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 232;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 359:
                  num2 = (short) 320;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 361:
                  if (!((AcpFieldBase) switches.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic)
                  {
                    num2 = (short) 274;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 82;
                case 365:
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 366:
                  if (((FeatureSection) switches.ConventionalSwitches).HasVisibleObjects)
                  {
                    num2 = (short) 178;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 367:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  iacpFeatureNode = ((Recordset) buttonInnerRecset2)[0];
                  int featureA22610Value = (iacpFeatureNode[10090] as DataButtonInnerSection).BtnConventionalButtonDatatButtonFeature_A22610Value;
                  int featureA22608Value = (iacpFeatureNode[10090] as DataButtonInnerSection).BtnTrunkingButtonDatatButtonFeature_A22608Value;
                  str3 = (string) ((AcpFieldX<int, string>) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnConventionalButtonDatatButtonFeature_A22610).Converter.Convert((object) featureA22610Value, (Type) null, (object) null, culture);
                  str2 = (string) ((AcpFieldX<int, string>) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnTrunkingButtonDatatButtonFeature_A22608).Converter.Convert((object) featureA22608Value, (Type) null, (object) null, culture);
                  num2 = (short) 289;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 369:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 222;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 370:
                  num2 = (short) 301;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 371:
                  if (!((AcpFieldBase) switches.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).HiddenStatic)
                  {
                    num2 = (short) 144 /*0x90*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 372:
                  this.a(ref A_0, "");
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 373:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 374:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 131;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 377:
                  this.a(ref A_0, "");
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 378:
                  buttonsRecset = FeatureManager.GetFeature(2042) as ButtonsRecset;
                  num2 = (short) 202;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 380:
                  this.a(ref A_0, A_1_8);
                  num2 = (short) 199;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 382:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 109;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 118;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_739:
              num2 = (short) 237;
              num1 = (int) (IntPtr) num2;
            }
label_833:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  public void AddButtonsAndControlO2(ref _XMLData RptXMLData, reportType rptType)
  {
    int A_1_1 = 8;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        O2InnerRecset o2InnerRecset;
        KMButtonInnerRecset buttonInnerRecset1;
        DataButtonInnerRecset buttonInnerRecset2;
        O2NavigationControlsTableInnerRecset tableInnerRecset;
        KeypadMicAndAccessoriesRecset accessoriesRecset;
        KeypadRecset keypadRecset;
        KeypadButtonInnerRecset buttonInnerRecset3;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        ControlHeadO2Recset feature;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            o2InnerRecset = (O2InnerRecset) null;
            buttonInnerRecset1 = (KMButtonInnerRecset) null;
            buttonInnerRecset2 = (DataButtonInnerRecset) null;
            tableInnerRecset = (O2NavigationControlsTableInnerRecset) null;
            accessoriesRecset = (KeypadMicAndAccessoriesRecset) null;
            keypadRecset = (KeypadRecset) null;
            buttonInnerRecset3 = (KeypadButtonInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            IAcpFeatureNode iacpFeatureNode1 = FeatureManager.GetFeature(4115)[0];
            IAcpFeatureNode iacpFeatureNode2 = FeatureManager.GetFeature(2128)[0];
            feature = FeatureManager.GetFeature(4115) as ControlHeadO2Recset;
            num2 = (short) 48 /*0x30*/;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              DataButtonInnerSection buttonInnerSection1;
              _UIFields A_0;
              string A_1_2;
              _RecSet recSet;
              int num3;
              O2MFKAssignmentControlInnerRecset controlInnerRecset;
              O2MFKAssignmentControlInnerSection controlInnerSection1;
              O2MFKAssignmentControlInnerSection controlInnerSection2;
              Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2 controlHeadO2;
              string str1;
              IAcpFeatureNode iacpFeatureNode3;
              string str2;
              string indexA41423UiValue;
              string indexA41424UiValue;
              IEnumerator<FeatureNode> enumerator;
              int num4;
              string A_1_3;
              string A_1_4;
              switch (num1)
              {
                case 0:
                  try
                  {
                    num2 = (short) 17;
                    int num5 = (int) (IntPtr) num2;
                    while (true)
                    {
                      O2NavigationControlsTableInnerSection tableInnerSection;
                      string str3;
                      string str4;
                      switch (num5)
                      {
                        case 0:
                          num2 = (short) 1;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          goto label_194;
                        case 2:
                        case 19:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 7;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 8:
                          A_0.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO2UpDownButton_A41278).UIName.ToString();
                          str3 = tableInnerSection.O2UpDownButtonName_A41277_UIValue.ToString();
                          num2 = (short) 13;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 0;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          tableInnerSection = ((IAcpFeatureNode) current)[10725] as O2NavigationControlsTableInnerSection;
                          int buttonA41278Value = tableInnerSection.RadErgoControlO2UpDownButton_A41278Value;
                          str4 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO2UpDownButton_A41278).Converter.Convert((object) buttonA41278Value, (Type) null, (object) null, culture);
                          num2 = (short) 5;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (isRightToLeft)
                          {
                            num2 = (short) 12;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 18;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 8;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                        case 16 /*0x10*/:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 3;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 14;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 9;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (str3 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 15;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 12:
                          num2 = (short) 10;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 20;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 11;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 16 /*0x10*/;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1_1), culture);
                          num2 = (short) 2;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 18:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 6;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 3;
                        case 20:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1_1), culture);
                          num2 = (short) 19;
                          num5 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 4;
                      num5 = (int) (IntPtr) num2;
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
                          goto label_396;
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
label_396:;
                  }
label_194:
                  table.RecSet.Add(recSet);
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (keypadRecset != null)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 2:
                  if (isRightToLeft)
                  {
                    num2 = (short) 46;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 109;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즊\uF88Cﮎ\uE590ﲒﮔ\uE496욘漢\uF39Cﮞﺠ\uE0A2쪤즦\uDDA8\uD9AA슬쎮슰", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊\uE38C\uEB8E\uF490\uEB92쪔\uDE96ﶘ", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE88Cﲎ\uF290\uE192ﲔ\uE796\uED98\uF29A\uF29C\uF19Eﺠ\uEAA2솤", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("좊\uE28C\uE18E\uE790\uF692ﮔ\uE396\uF098\uF49A\uF39Cﺞ춠ﲢ\uECA4쎦", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Aﾌ搜ﾐ\uF892ﲔ練ﺘ쒚풜\uDB9E", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  enumerator = ((Collection<FeatureNode>) o2InnerRecset).GetEnumerator();
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  o2InnerRecset = ((Recordset) feature)[0][10723].EmbeddedRecset as O2InnerRecset;
                  tableInnerRecset = ((Recordset) feature)[0][10722].EmbeddedRecset as O2NavigationControlsTableInnerRecset;
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  A_0 = new _UIFields();
                  int num7 = ((AcpField<int>) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).Value;
                  A_1_2 = (string) ((AcpFieldX<int, string>) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).Converter.Convert((object) num7, (Type) null, (object) null, culture);
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 93;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 113;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  str1 = str1 + this.a + indexA41423UiValue;
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  num2 = (short) 104;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  if (!((AcpFieldBase) controlHeadO2.O2MultiFunctionKnob.RadErgoControlO2MFKButtonPress_A42217).HiddenStatic)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 21;
                case 13:
                case 79:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_416;
                case 17:
                  buttonInnerRecset3 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 100;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 19:
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  try
                  {
                    num2 = (short) 29;
                    int num8 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str5;
                      IAcpFeatureNode current;
                      switch (num8)
                      {
                        case 0:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 24;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 13;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 25;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 10:
                        case 11:
                        case 19:
                          A_0.UIFieldName = ((O2Inner) current).O2InnerSection.CHO2EmergencyButtonName_A41270.ToString();
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDE90솒풔\uD996\uDE98\uDE9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6", A_1_1), culture);
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 27;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 17;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 4:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 21;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 18;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          this.a(ref A_0, "");
                          num2 = (short) 16 /*0x10*/;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str5.ToString());
                            num2 = (short) 3;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 23;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (IAcpFeatureNode) enumerator.Current;
                          recSet = new _RecSet();
                          A_0 = new _UIFields();
                          ++num3;
                          recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                          recSet.RecNo = num3.ToString();
                          O2InnerSection o2InnerSection = current[10716] as O2InnerSection;
                          str5 = (string) ((AcpFieldX<int, string>) o2InnerSection.CHO2EmergencyButtonFeature_A41272).Converter.Convert((object) o2InnerSection.CHO2EmergencyButtonFeature_A41272Value, (Type) null, (object) null, culture);
                          num2 = (short) 9;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 15;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 9:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 8;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 6;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 31 /*0x1F*/;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 28;
                        case 14:
                          goto label_18;
                        case 15:
                          num2 = (short) 30;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                        case 26:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 10;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 11;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 26;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          num2 = (short) 4;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 5;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 16 /*0x10*/;
                        case 22:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 19;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 14;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 22;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 25:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 32 /*0x20*/;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                        case 32 /*0x20*/:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 2;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 30:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 0;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          this.a(ref A_0, "");
                          num2 = (short) 28;
                          num8 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 7;
                      num8 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num9 = 0;
                    while (true)
                    {
                      short num10;
                      switch (num9)
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
                          goto label_247;
                        case 2:
                          enumerator.Dispose();
                          num10 = (short) 1;
                          num9 = (int) (IntPtr) num10;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num10 = (short) 2;
                        num9 = (int) (IntPtr) num10;
                      }
                      else
                        break;
                    }
label_247:;
                  }
                case 21:
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (accessoriesRecset != null)
                  {
                    num2 = (short) 83;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 23:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 103;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                case 99:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 72;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_3);
                    num2 = (short) 111;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 36;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 40;
                case 29:
                  if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐킒솔\uDE96횘햚\uDE9C킞\uEFA0\uF0A2\uEAA4\uEBA6\uE0A8\uEFAA\uECACﮮ\uF8B0ﲲ﮴", A_1_1), culture))
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 30;
                case 30:
                  num2 = (short) 80 /*0x50*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                case 44:
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                case 38:
                  A_0.UIFieldName = RptMgrErrorHandler.b("\uDB8Aﾌ\uE68Eﲐ\uF292\uE794\uEE96\uDF98\uEE9A\uF39Cﲞ햠쪢쪤즦", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8Aﾌ\uE68Eﲐ\uF292\uE794\uEE96욘\uDD9A\uE89C\uF19E슠힢첤좦잨", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num11 = ((AcpField<int>) controlInnerSection2.RadErgoControlO2MFKFeatureAssignment_A41275).Value;
                  A_1_3 = (string) ((AcpFieldX<int, string>) controlInnerSection2.RadErgoControlO2MFKFeatureAssignment_A41275).Converter.Convert((object) num11, (Type) null, (object) null, culture);
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  goto label_416;
                case 34:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 72;
                case 36:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  try
                  {
                    num2 = (short) 19;
                    int num12 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KMButtonInnerSection buttonInnerSection2;
                      string str6;
                      string str7;
                      string str8;
                      IAcpFeatureNode current;
                      switch (num12)
                      {
                        case 0:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 28;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 22;
                        case 1:
                        case 30:
                          num2 = (short) 0;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 50;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          num2 = (short) 16 /*0x10*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), culture);
                          num2 = (short) 10;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 20;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 29;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 47;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 22;
                        case 7:
                        case 8:
                          num2 = (short) 48 /*0x30*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          if (((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 17;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 1;
                        case 10:
                        case 13:
                        case 15:
                        case 26:
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 32 /*0x20*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 44;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 22;
                        case 12:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 3;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 22;
                        case 14:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 38;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 49;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          this.a(ref A_0, "");
                          num2 = (short) 30;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (isRightToLeft)
                          {
                            num2 = (short) 42;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 45;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 20:
                          if (((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 46;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 21:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            recSet = new _RecSet();
                            A_0 = new _UIFields();
                            ++num3;
                            recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                            recSet.RecNo = num3.ToString();
                            buttonInnerSection2 = current[10239] as KMButtonInnerSection;
                            int featureA19646Value = buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                            int featureA19746Value = buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                            str8 = (string) ((AcpFieldX<int, string>) buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, culture);
                            str7 = (string) ((AcpFieldX<int, string>) buttonInnerSection2.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, culture);
                            num2 = (short) 41;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 43;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                        case 25:
                        case 34:
                        case 39:
                          A_0.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                          str6 = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                          num2 = (short) 40;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 6;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 23;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (str6 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 4;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDE90Ꚓ힔슖춘쾚튜톞", A_1_1), culture);
                          num2 = (short) 26;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 25;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 8;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          goto label_340;
                        case 33:
                          if (!(str6 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 27;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 52;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1_1), culture);
                          num2 = (short) 13;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          num2 = (short) 18;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 39;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          num2 = (short) 11;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          if (!(str6 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 33;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 12;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 36;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          num2 = (short) 5;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          num2 = (short) 31 /*0x1F*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 22;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 24;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 23;
                        case 46:
                          this.a(ref A_0, "");
                          num2 = (short) 7;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 34;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 37;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 22;
                        case 49:
                          num2 = (short) 51;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 1;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 14;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 38;
                        case 52:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), culture);
                          num2 = (short) 15;
                          num12 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 21;
                      num12 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num13 = 0;
                    short num14;
                    while (true)
                    {
                      switch (num13)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              goto label_332;
                            default:
                              continue;
                          }
                        case 1:
label_336:
                          enumerator.Dispose();
                          num14 = (short) 2;
                          num13 = (int) (IntPtr) num14;
                          continue;
                        case 2:
                          goto label_337;
                        default:
label_332:
                          if (enumerator != null)
                          {
                            num14 = (short) -15694;
                            int num15 = (int) num14;
                            num14 = (short) -15694;
                            int num16 = (int) num14;
                            switch (num15 == num16 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                goto label_336;
                              default:
                                num14 = (short) 0;
                                if (num14 == (short) 0)
                                  ;
                                num14 = (short) 1;
                                num13 = (int) (IntPtr) num14;
                                continue;
                            }
                          }
                          else
                            goto label_337;
                      }
                    }
label_337:;
                  }
                case 39:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  num2 = (short) 0;
                  num2 = (short) 92;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  accessoriesRecset = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  if (controlHeadO2 != null)
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 21;
                case 43:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 46:
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                case 81:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  if (feature != null)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 49:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 32 /*0x20*/;
                case 50:
                  str2 = str2 + this.a + indexA41424UiValue;
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                case 60:
                case 101:
                case 109:
                  A_0.UIFieldName = ((AcpFieldBase) (iacpFeatureNode3[10209] as DataButtonInnerSection).RadErgoCfgKMDataButtonName_A22601).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎햐튒솔횖\uDB98캚즜쮞\uEEA0\uEDA2瘝隦", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 74;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 90;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 53:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 95;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_340;
                case 54:
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (isRightToLeft)
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  A_0 = new _UIFields();
                  int num17 = ((AcpField<int>) controlInnerSection1.RadErgoControlO2MFKFeatureAssignment_A41275).Value;
                  A_1_4 = (string) ((AcpFieldX<int, string>) controlInnerSection1.RadErgoControlO2MFKFeatureAssignment_A41275).Converter.Convert((object) num17, (Type) null, (object) null, culture);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 82;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 65;
                case 59:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_2);
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 112 /*0x70*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 110;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 85;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 64 /*0x40*/:
                  this.a(ref A_0, "");
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                case 76:
                  A_0.UIFieldName = RptMgrErrorHandler.b("\uD88A\uE88C\uEC8Eﺐﶒ\uF194\uF696\uEB98\uE29A\uDB9C\uEA9E쾠삢톤캦욨얪", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE88C\uEC8Eﺐﶒ\uF194\uF696\uEB98\uE29A슜\uD99E풠춢욤펦삨쒪쎬", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 102;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 81;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 76;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  num2 = (short) 107;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                case 84:
                  A_0.UIFieldName = RptMgrErrorHandler.b("욊쮌쒎손\uE192\uF094\uE496\uEA98\uD99A\uF89C\uF79E삠햢첤좦\uDBA8", A_1_1);
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDC90햒\uDE94잖쮘\uDE9A캜첞\uE3A0\uE6A2\uEDA4\uE6A6ﾨ\uE2AA\uE2ACﶮ", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  num2 = (short) 86;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  num2 = (short) 97;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 75:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                  if (controlHeadO2 != null)
                  {
                    num2 = (short) 87;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 80 /*0x50*/:
                  if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐킒솔\uDE96횘햚\uDE9C킞\uEFA0\uF0A2\uEAA4\uEBA6\uE0A8\uEFAA\uECACﮮ\uF8B0ﲲ﮴", A_1_1), culture))
                  {
                    num2 = (short) 50;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 25;
                case 82:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 83:
                  buttonInnerRecset1 = ((Recordset) accessoriesRecset)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
                  buttonInnerRecset2 = ((Recordset) accessoriesRecset)[0][10228].EmbeddedRecset as DataButtonInnerRecset;
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDF90튒쎔\uDE96\uDE98\uDA9A즜횞\uEEA0\uEDA2\uE6A4\uE8A6\uE7A8ﾪﾬ\uE0AEﶰ\uE0B2", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 86:
                  if (o2InnerRecset != null)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 87:
                  controlInnerRecset = ((FeatureNode) controlHeadO2)[10721].EmbeddedRecset as O2MFKAssignmentControlInnerRecset;
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 88:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 84;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 89:
                  try
                  {
                    num2 = (short) 45;
                    int num18 = (int) (IntPtr) num2;
                    while (true)
                    {
                      IAcpFeatureNode current;
                      string str9;
                      KeypadButtonInnerSection buttonInnerSection3;
                      string A_1_5;
                      string index41415UiValue;
                      switch (num18)
                      {
                        case 0:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒊\uE38C\uEA8Eꂐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 29;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE28C搜\uE390Ꞓ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 3;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A戴\uE08Eꎐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 43;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 12:
                        case 20:
                        case 26:
                        case 28:
                        case 29:
                        case 32 /*0x20*/:
                        case 33:
                        case 37:
                        case 39:
                        case 43:
                        case 44:
                        case 59:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 25;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                        case 58:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str9 = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 5;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (str9 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쮐횒잔\uD896ꦘ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 18;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 31 /*0x1F*/;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          num2 = (short) 47;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (!(str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A歷\uEE8E\uE390첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 15;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 51;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (!(str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE28C搜\uE390Ꞓ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 40;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE48C\uF78EꞐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 22;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE88C年\uF490ﶒꊔ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 39;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          num2 = (short) 53;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A\uE58Cﶎ\uF490\uF692Ꚕ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 50;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 8;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          this.a(ref A_0, A_1_5);
                          num2 = (short) 23;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8A\uE28C搜ﾐ\uF792\uDD94\uF696\uEA98\uF39A슜횞얠", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 42;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num4;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDA90횒첔잖\uD898\uDF9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6", A_1_1), culture) + num4.ToString();
                          num2 = (short) 44;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE88C年\uF490ﶒꊔ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 10;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 41;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (!(str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A戴\uE08Eꎐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 13;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쮐횒잔\uD896ꦘ", A_1_1), culture);
                          num2 = (short) 28;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          num2 = (short) 49;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, A_1_5);
                          num2 = (short) 19;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE48C\uF78EꞐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 20;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                        case 55:
                          num2 = (short) 56;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection3 = current[10709] as KeypadButtonInnerSection;
                            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                            A_1_5 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                            index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
                            num2 = (short) 54;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 11;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          num2 = (short) 57;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          A_1_5 = A_1_5 + this.a + index41415UiValue;
                          num2 = (short) 27;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒊\uE38C\uEA8Eꂐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 0;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 17;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 21;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                        case 35:
                          if (str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얊\uE48C\uE18E\uF490ꪒ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 38;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 7;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          this.a(ref A_0, A_1_5);
                          num2 = (short) 58;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얊\uE48C\uE18E\uF490ꪒ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 37;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          if (!(str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE48C年\uF490Ꚓ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 9;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 52;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (!(str9 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("캊\uE48C\uE88E戀\uE792궔좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 35;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 46;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8A\uE28C搜ﾐ\uF792\uDD94\uF696\uEA98\uF39A슜횞얠", A_1_1), culture);
                          num2 = (short) 32 /*0x20*/;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 46:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("캊\uE48C\uE88E戀\uE792궔좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 12;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 55;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 14;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          this.a(ref A_0, A_1_5);
                          num2 = (short) 4;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 36;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 4;
                        case 50:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A\uE58Cﶎ\uF490\uF692Ꚕ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 59;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A歷\uEE8E\uE390첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 33;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE48C年\uF490Ꚓ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 26;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 53:
                          goto label_415;
                        case 54:
                          if (A_1_5 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쎐횒\uD994횖삘쮚\uDC9C쮞\uF5A0\uE6A2\uF7A4\uE9A6", A_1_1), culture))
                          {
                            num2 = (short) 30;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 27;
                        case 56:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 48 /*0x30*/;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 4;
                        case 57:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 34;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num18 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 24;
                      num18 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num19 = 1;
                    while (true)
                    {
                      short num20;
                      switch (num19)
                      {
                        case 0:
                          goto label_117;
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
                          num20 = (short) 0;
                          num19 = (int) (IntPtr) num20;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num20 = (short) 2;
                        num19 = (int) (IntPtr) num20;
                      }
                      else
                        break;
                    }
label_117:;
                  }
label_415:
                  table.RecSet.Add(recSet);
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  this.a(ref A_0, "");
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 91:
                  if (controlInnerRecset != null)
                  {
                    num2 = (short) 106;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 92:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 93:
                  if (buttonInnerRecset2 != null)
                  {
                    num2 = (short) 98;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 74;
                case 94:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 95:
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset1).GetEnumerator();
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 71;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_416;
                case 98:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  iacpFeatureNode3 = ((Recordset) buttonInnerRecset2)[0];
                  buttonInnerSection1 = iacpFeatureNode3[10209] as DataButtonInnerSection;
                  int featureA22603Value = buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603Value;
                  int featureA22605Value = buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605Value;
                  str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).Converter.Convert((object) featureA22603Value, (Type) null, (object) null, culture);
                  str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).Converter.Convert((object) featureA22605Value, (Type) null, (object) null, culture);
                  indexA41423UiValue = buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423_UIValue;
                  indexA41424UiValue = buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424_UIValue;
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 100:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 101;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 102:
                case 103:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 104:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삊\uE88C\uF68E\uE190\uF292\uF194좖\uDB98\uEE9A\uE99C\uEB9E캠춢횤", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 89;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  controlInnerSection1 = ((Recordset) controlInnerRecset)[0][10726] as O2MFKAssignmentControlInnerSection;
                  controlInnerSection2 = ((Recordset) controlInnerRecset)[1][10726] as O2MFKAssignmentControlInnerSection;
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 105;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_416;
                case 108:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 110:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 75;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 111:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 69;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 66;
                case 112 /*0x70*/:
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 113:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                default:
                  goto label_3;
              }
label_18:
              recSet = new _RecSet();
              ++num3;
              recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDC90욒\uD994쎖킘\uDD9A좜톞\uE2A0\uF7A2\uECA4\uE8A6\uE7A8\uE0AA\uE3AC\uE0AE\uF3B0", A_1_1), culture);
              recSet.RecNo = num3.ToString();
              controlInnerRecset = (O2MFKAssignmentControlInnerRecset) null;
              controlInnerSection1 = (O2MFKAssignmentControlInnerSection) null;
              controlInnerSection2 = (O2MFKAssignmentControlInnerSection) null;
              controlHeadO2 = FeatureManager.GetFeature(4115)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO2.ControlHeadO2;
              num2 = (short) 42;
              num1 = (int) (IntPtr) num2;
              continue;
label_340:
              num2 = (short) 63 /*0x3F*/;
              num1 = (int) (IntPtr) num2;
            }
label_416:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  public void AddButtonsAndControlO3(ref _XMLData RptXMLData, reportType rptType)
  {
    int A_1_1 = 8;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        O3HHCHButtonInnerRecset buttonInnerRecset1;
        DataButtonInnerRecset buttonInnerRecset2;
        KeypadRecset keypadRecset;
        O3NavigationControlsTableInnerRecset tableInnerRecset;
        KeypadButtonInnerRecset buttonInnerRecset3;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        ControlHeadO3Recset feature;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            buttonInnerRecset1 = (O3HHCHButtonInnerRecset) null;
            buttonInnerRecset2 = (DataButtonInnerRecset) null;
            keypadRecset = (KeypadRecset) null;
            tableInnerRecset = (O3NavigationControlsTableInnerRecset) null;
            buttonInnerRecset3 = (KeypadButtonInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            IAcpFeatureNode iacpFeatureNode1 = FeatureManager.GetFeature(2127)[0];
            feature = FeatureManager.GetFeature(2127) as ControlHeadO3Recset;
            num2 = (short) 0;
            num2 = (short) 52;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              DataButtonInnerSection buttonInnerSection1;
              _UIFields A_0;
              string A_1_2;
              _RecSet recSet;
              IEnumerator<FeatureNode> enumerator;
              int num3;
              IAcpFeatureNode iacpFeatureNode2;
              string A_1_3;
              string indexA41419UiValue;
              string indexA41420UiValue;
              int num4;
              switch (num1)
              {
                case 0:
                  if (((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).HiddenStatic)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 2:
                  if (isRightToLeft)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  try
                  {
                    num2 = (short) 18;
                    int num5 = (int) (IntPtr) num2;
                    while (true)
                    {
                      O3NavigationControlsTableInnerSection tableInnerSection;
                      string str1;
                      string str2;
                      switch (num5)
                      {
                        case 0:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 19;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (str1 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 2;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 2:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE28C\uF88Eﾐ첒힔\uE296\uED98\uEF9A\uF29C\uF19E", A_1_1), culture);
                          num2 = (short) 12;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          goto label_181;
                        case 4:
                          if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 9;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 11:
                          A_0.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO3NaviControlName_A41374).UIName.ToString();
                          str1 = tableInnerSection.RadErgoControlO3NaviControlName_A41374_UIValue.ToString();
                          num2 = (short) 4;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          num2 = (short) 3;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                        case 12:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 16 /*0x10*/;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 14;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쒐쎒힔슖춘쾚튜톞", A_1_1), culture);
                          num2 = (short) 7;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 11;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          num2 = (short) 8;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                        case 19:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 5;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 10;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 17:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str2.ToString());
                            num2 = (short) 15;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 13;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 20:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 6;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          tableInnerSection = ((IAcpFeatureNode) current)[10733] as O3NavigationControlsTableInnerSection;
                          int featureA41375Value = tableInnerSection.RadErgoControlO3NaviControlFeature_A41375Value;
                          str2 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO3NaviControlFeature_A41375).Converter.Convert((object) featureA41375Value, (Type) null, (object) null, culture);
                          num2 = (short) 17;
                          num5 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 20;
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
                          num7 = (short) -10576;
                          int num8 = (int) num7;
                          num7 = (short) -10576;
                          int num9 = (int) num7;
                          switch (num8 == num9 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              num7 = (short) 2;
                              num6 = (int) (IntPtr) num7;
                              continue;
                            default:
                              num7 = (short) 0;
                              if (num7 == (short) 0)
                                ;
                              enumerator.Dispose();
                              goto case 0;
                          }
                        case 2:
                          goto label_48;
                      }
                      if (enumerator != null)
                      {
                        num7 = (short) 1;
                        num6 = (int) (IntPtr) num7;
                      }
                      else
                        break;
                    }
label_48:;
                  }
label_181:
                  table.RecSet.Add(recSet);
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (keypadRecset != null)
                  {
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 44;
                case 7:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).HiddenStatic)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 19;
                case 9:
                  try
                  {
                    num2 = (short) 3;
                    int num10 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str3;
                      string str4;
                      IAcpFeatureNode current;
                      O3HHCHButtonInnerSection buttonInnerSection2;
                      string str5;
                      switch (num10)
                      {
                        case 0:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1_1), culture);
                          num2 = (short) 56;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 4;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 48 /*0x30*/;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 38:
                          num2 = (short) 50;
                          num10 = (int) (IntPtr) num2;
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
                        case 4:
                          num2 = (short) 52;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 12:
                        case 25:
                        case 37:
                        case 40:
                        case 56:
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 55;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          num2 = (short) 17;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (str5 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎얐\uDC92얔\uDA96킘\uDF9A\uD99C펞\uE4A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 47;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 58;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                        case 34:
                          num2 = (short) 9;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).HiddenStatic)
                          {
                            num2 = (short) 51;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 10;
                        case 10:
                        case 14:
                        case 21:
                        case 54:
                          A_0.UIFieldName = ((AcpFieldBase) ((O3HHCHButtonInner) current).O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523).UIName.ToString();
                          str5 = ((O3HHCHButtonInner) current).O3HHCHButtonInnerSection.CntrlHeadO3HHCHButtonName_A22523_UIValue.ToString();
                          num2 = (short) 43;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          num2 = (short) 19;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 11;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 41;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), culture);
                          num2 = (short) 5;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          num2 = (short) 46;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 24;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 36;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 33;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 19:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 23;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (str5 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 29;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 31 /*0x1F*/;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          this.a(ref A_0, str3.ToString());
                          num2 = (short) 14;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).HiddenStatic)
                          {
                            num2 = (short) 30;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 27;
                        case 24:
                          this.a(ref A_0, str3.ToString());
                          num2 = (short) 8;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            recSet = new _RecSet();
                            A_0 = new _UIFields();
                            ++num3;
                            recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                            recSet.RecNo = num3.ToString();
                            buttonInnerSection2 = current[10210] as O3HHCHButtonInnerSection;
                            int featureA19650Value = buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650Value;
                            int featureA19750Value = buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750Value;
                            str4 = (string) ((AcpFieldX<int, string>) buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).Converter.Convert((object) featureA19650Value, (Type) null, (object) null, culture);
                            str3 = (string) ((AcpFieldX<int, string>) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).Converter.Convert((object) featureA19750Value, (Type) null, (object) null, culture);
                            num2 = (short) 13;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 39;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          num2 = (short) 45;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          goto label_170;
                        case 29:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖풘튚\uD99C\uDB9E\uEDA0\uE6A2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), culture);
                          num2 = (short) 12;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 27;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (!(str5 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖\uDB98풚즜쮞\uEEA0\uEEA2\uE7A4\uF2A6ﶨﾪ\uE2AC\uE1AE", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDE90ꂒ힔슖춘쾚튜톞", A_1_1), culture);
                            num2 = (short) 37;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 15;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          this.a(ref A_0, str3.ToString());
                          num2 = (short) 38;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          this.a(ref A_0, "");
                          num2 = (short) 2;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 54;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          if (((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 53;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 8;
                        case 39:
                          num2 = (short) 28;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 57;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 10;
                        case 42:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 16 /*0x10*/;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          if (!(str5 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎얐\uDC92얔얖킘\uDC9A햜쮞\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 7;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 49;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          this.a(ref A_0, str3.ToString());
                          num2 = (short) 21;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 22;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 10;
                        case 46:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 44;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 10;
                        case 47:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎얐\uDC92얔\uDA96킘\uDF9A\uD99C펞\uE4A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1_1), culture);
                          num2 = (short) 40;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3TrunkingO3HHCHButtonFeature_A19750).HiddenStatic)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 18;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎얐\uDC92얔얖킘\uDC9A햜쮞\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1_1), culture);
                          num2 = (short) 25;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).HiddenStatic)
                          {
                            num2 = (short) 35;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 10;
                        case 51:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 10;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          if (!((AcpFieldBase) buttonInnerSection2.CntrlHeadO3ConventionalO3HHCHButtonFeature_A19650).HiddenStatic)
                          {
                            num2 = (short) 42;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 16 /*0x10*/;
                        case 53:
                          this.a(ref A_0, "");
                          num2 = (short) 34;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 57:
                          num2 = (short) 1;
                          num10 = (int) (IntPtr) num2;
                          continue;
                        case 58:
                          if (!(str5 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDA92톔튖춘풚출\uDD9E\uF4A0\uF7A2\uF1A4\uE8A6\uE7A8", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 20;
                            num10 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num10 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 26;
                      num10 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num11 = 2;
                    while (true)
                    {
                      switch (num11)
                      {
                        case 0:
                          enumerator.Dispose();
                          num11 = 1;
                          continue;
                        case 1:
                          goto label_139;
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
                        num11 = 0;
                      else
                        break;
                    }
label_139:;
                  }
                case 10:
                  if (((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 43;
                case 11:
                case 59:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  goto label_311;
                case 13:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_311;
                case 14:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (isRightToLeft)
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (buttonInnerRecset2 != null)
                  {
                    num2 = (short) 55;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 26;
                case 19:
                case 27:
                case 37:
                case 58:
                  A_0.UIFieldName = ((AcpFieldBase) (iacpFeatureNode2[10212] as DataButtonInnerSection).CntrlHeadO3DataButtonName_A22591).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎햐튒솔횖\uDB98캚즜쮞\uEEA0\uEDA2瘝隦", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 61;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 65;
                case 23:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).HiddenStatic)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 19;
                case 24:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삊\uE88C\uF68E\uE190\uF292\uF194좖\uDB98\uEE9A\uE99C\uEB9E캠춢횤", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 64 /*0x40*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  if (A_1_2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐킒솔\uDE96횘햚\uDE9C킞\uEFA0\uF0A2\uEAA4\uEBA6\uE0A8\uEFAA\uECACﮮ\uF8B0ﲲ﮴", A_1_1), culture))
                  {
                    num2 = (short) 46;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 30:
                  buttonInnerRecset1 = ((Recordset) feature)[0][10235].EmbeddedRecset as O3HHCHButtonInnerRecset;
                  buttonInnerRecset2 = ((Recordset) feature)[0][10234].EmbeddedRecset as DataButtonInnerRecset;
                  tableInnerRecset = ((Recordset) feature)[0][10732].EmbeddedRecset as O3NavigationControlsTableInnerRecset;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 53;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 19;
                case 32 /*0x20*/:
                  this.a(ref A_0, "");
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  this.a(ref A_0, "");
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 38:
                  buttonInnerRecset3 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 28;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_311;
                case 40:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (A_1_3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐킒솔\uDE96횘햚\uDE9C킞\uEFA0\uF0A2\uEAA4\uEBA6\uE0A8\uEFAA\uECACﮮ\uF8B0ﲲ﮴", A_1_1), culture))
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 51;
                case 42:
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset1).GetEnumerator();
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                case 57:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즊\uF88Cﮎ\uE590ﲒﮔ\uE496욘漢\uF39Cﮞﺠ\uE0A2쪤즦\uDDA8\uD9AA슬쎮슰", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊\uE38C\uEB8E\uF490\uEB92쪔\uDE96ﶘ", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾊\uE88Cﲎ\uF290\uE192ﲔ\uE796\uED98\uF29A\uF29C\uF19Eﺠ\uEAA2솤", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("좊\uE28C\uE18E\uE790\uF692ﮔ\uE396\uF098\uF49A\uF39Cﺞ춠ﲢ\uECA4쎦", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Aﾌ搜ﾐ\uF892ﲔ練ﺘ쒚풜\uDB9E", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 50;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  A_1_2 = A_1_2 + this.a + indexA41419UiValue;
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 67;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_311;
                case 50:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (feature != null)
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 53:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 54:
                  if (((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 55:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  iacpFeatureNode2 = ((Recordset) buttonInnerRecset2)[0];
                  buttonInnerSection1 = iacpFeatureNode2[10212] as DataButtonInnerSection;
                  int num12 = ((AcpField<int>) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).Value;
                  int num13 = ((AcpField<int>) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).Value;
                  A_1_2 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).Converter.Convert((object) num12, (Type) null, (object) null, culture);
                  A_1_3 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).Converter.Convert((object) num13, (Type) null, (object) null, culture);
                  indexA41419UiValue = buttonInnerSection1.CHO3DataButtonConvIndex_A41419_UIValue;
                  indexA41420UiValue = buttonInnerSection1.CHO3DataButtonTrkIndex_A41420_UIValue;
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3ConventionalO3DatatButtonFeature_A22595).HiddenStatic)
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 34;
                case 60:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 19;
                case 61:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDF90튒쎔\uDE96\uDE98\uDA9A즜횞\uEEA0\uEDA2\uE6A4\uE8A6\uE7A8ﾪﾬ\uE0AEﶰ\uE0B2", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  A_1_3 = A_1_3 + this.a + indexA41420UiValue;
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 19;
                case 64 /*0x40*/:
                  try
                  {
                    num2 = (short) 43;
                    int num14 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str;
                      string A_1_4;
                      string index41415UiValue;
                      IAcpFeatureNode current;
                      KeypadButtonInnerSection buttonInnerSection3;
                      switch (num14)
                      {
                        case 0:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얊\uE48C\uE18E\uF490ꪒ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 6;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 34;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("캊\uE48C\uE88E戀\uE792궔좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 13;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 18;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 4:
                        case 5:
                        case 10:
                        case 19:
                        case 22:
                        case 23:
                        case 26:
                        case 33:
                        case 35:
                        case 40:
                        case 54:
                        case 57:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 46;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A歷\uEE8E\uE390첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 25;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 32 /*0x20*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          num2 = (short) 51;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE88C年\uF490ﶒꊔ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 20;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A戴\uE08Eꎐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 26;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                        case 39:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 56;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쮐횒잔\uD896ꦘ", A_1_1), culture);
                          num2 = (short) 35;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("캊\uE48C\uE88E戀\uE792궔좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 40;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          A_1_4 = A_1_4 + this.a + index41415UiValue;
                          num2 = (short) 7;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          num2 = (short) 44;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE48C\uF78EꞐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 4;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          this.a(ref A_0, A_1_4);
                          num2 = (short) 39;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          goto label_302;
                        case 20:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE88C年\uF490ﶒꊔ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 22;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE28C搜\uE390Ꞓ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 59;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 24;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE28C搜\uE390Ꞓ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 3;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A歷\uEE8E\uE390첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 23;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒊\uE38C\uEA8Eꂐ첒\uDC94\uF396", A_1_1), culture);
                          num2 = (short) 19;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒊\uE38C\uEA8Eꂐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 27;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 45;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 30;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 52;
                        case 30:
                          this.a(ref A_0, A_1_4);
                          num2 = (short) 52;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 2;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (IAcpFeatureNode) enumerator.Current;
                          A_0 = new _UIFields();
                          buttonInnerSection3 = current[10709] as KeypadButtonInnerSection;
                          int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                          A_1_4 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                          index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
                          num2 = (short) 50;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8A\uE28C搜ﾐ\uF792\uDD94\uF696\uEA98\uF39A슜횞얠", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 48 /*0x30*/;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num4;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎\uDA90횒첔잖\uD898\uDF9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6", A_1_1), culture) + num4.ToString();
                          num2 = (short) 5;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("얊\uE48C\uE18E\uF490ꪒ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 54;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A\uE58Cﶎ\uF490\uF692Ꚕ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 33;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                        case 53:
                          num2 = (short) 42;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A\uE58Cﶎ\uF490\uF692Ꚕ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 36;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 21;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 17;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 11;
                        case 42:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 47;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 11;
                        case 43:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 44:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 58;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 53;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8A戴\uE08Eꎐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 38;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          this.a(ref A_0, A_1_4);
                          num2 = (short) 11;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8A\uE28C搜ﾐ\uF792\uDD94\uF696\uEA98\uF39A슜횞얠", A_1_1), culture);
                          num2 = (short) 57;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88A\uE48C\uF78EꞐ첒\uDC94\uF396", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 16 /*0x10*/;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 8;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          if (A_1_4 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쎐횒\uD994횖삘쮚\uDC9C쮞\uF5A0\uE6A2\uF7A4\uE9A6", A_1_1), culture))
                          {
                            num2 = (short) 14;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 51:
                          if (isRightToLeft)
                          {
                            num2 = (short) 15;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 29;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          num2 = (short) 41;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 55:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE48C年\uF490Ꚓ쪔\uDE96ﶘ", A_1_1), culture);
                          num2 = (short) 10;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 56:
                          if (str == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎쮐횒잔\uD896ꦘ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 12;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 28;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 58:
                          this.a(ref A_0, A_1_4);
                          num2 = (short) 37;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 59:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("춊\uE48C年\uF490Ꚓ쪔\uDE96ﶘ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 55;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 49;
                          num14 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 31 /*0x1F*/;
                      num14 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num15 = 1;
                    while (true)
                    {
                      short num16;
                      switch (num15)
                      {
                        case 0:
                          goto label_288;
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
                          num16 = (short) 0;
                          num15 = (int) (IntPtr) num16;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num16 = (short) 2;
                        num15 = (int) (IntPtr) num16;
                      }
                      else
                        break;
                    }
label_288:;
                  }
label_302:
                  table.RecSet.Add(recSet);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  if (!((AcpFieldBase) buttonInnerSection1.CntrlHeadO3TrunkingO3DatatButtonFeature_A22597).HiddenStatic)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 54;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_170:
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
            }
label_311:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  public void AddButtonsAndControlO7(ref _XMLData RptXMLData, reportType rptType)
  {
    int A_1_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        O7InnerRecset o7InnerRecset;
        KMButtonInnerRecset buttonInnerRecset1;
        O7DataButtonInnerRecset buttonInnerRecset2;
        O7NavigationControlsTableInnerRecset tableInnerRecset;
        KeypadMicAndAccessoriesRecset accessoriesRecset;
        KeypadRecset keypadRecset;
        KeypadButtonInnerRecset buttonInnerRecset3;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        ControlHeadO7Recset feature;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            o7InnerRecset = (O7InnerRecset) null;
            buttonInnerRecset1 = (KMButtonInnerRecset) null;
            buttonInnerRecset2 = (O7DataButtonInnerRecset) null;
            tableInnerRecset = (O7NavigationControlsTableInnerRecset) null;
            accessoriesRecset = (KeypadMicAndAccessoriesRecset) null;
            keypadRecset = (KeypadRecset) null;
            buttonInnerRecset3 = (KeypadButtonInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            IAcpFeatureNode iacpFeatureNode1 = FeatureManager.GetFeature(4114)[0];
            IAcpFeatureNode iacpFeatureNode2 = FeatureManager.GetFeature(2128)[0];
            feature = FeatureManager.GetFeature(4114) as ControlHeadO7Recset;
            num2 = (short) 81;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              O7DataButtonInnerSection buttonInnerSection1;
              _UIFields A_0;
              string A_1_2;
              _RecSet recSet;
              int num3;
              O7MFKAssignmentControlInnerRecset controlInnerRecset;
              O7MFKAssignmentControlInnerSection controlInnerSection1;
              O7MFKAssignmentControlInnerSection controlInnerSection2;
              Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7 controlHeadO7;
              string A_1_3;
              IAcpFeatureNode iacpFeatureNode3;
              string A_1_4;
              string indexA41417UiValue;
              string indexA41418UiValue;
              IEnumerator<FeatureNode> enumerator;
              int num4;
              string A_1_5;
              string A_1_6;
              switch (num1)
              {
                case 0:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 76;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 1:
                  A_1_3 = A_1_3 + this.a + indexA41417UiValue;
                  num2 = (short) 84;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 91;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                case 87:
                  A_0.UIFieldName = RptMgrErrorHandler.b("삏\uE091ﶓﮕ聯\uE899\uE59B\uD89D햟첡잣튥솧얩슫", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏\uE091ﶓﮕ聯\uE899\uE59B솝\uE69F힡쪣얥\uDCA7쎩쎫삭", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  A_0 = new _UIFields();
                  int num5 = ((AcpField<int>) controlInnerSection2.RadErgoControlO7MFKFeatureAssignment_A41295).Value;
                  A_1_5 = (string) ((AcpFieldX<int, string>) controlInnerSection2.RadErgoControlO7MFKFeatureAssignment_A41295).Converter.Convert((object) num5, (Type) null, (object) null, culture);
                  num2 = (short) 98;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                case 89:
                  A_0.UIFieldName = RptMgrErrorHandler.b("쎏\uF791\uF793秊\uF697ﺙﶛ\uEC9D\uD99F\uE4A1톣좥쮧\uDEA9얫솭\uDEAF", A_1_1);
                  A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏\uF791\uF793秊\uF697ﺙﶛ\uEC9D\uD99Fﶡ\uE2A3펥욧즩\uD8AB잭\uDFAF\uDCB1", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 93;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  controlInnerSection1 = ((Recordset) controlInnerRecset)[0][10724] as O7MFKAssignmentControlInnerSection;
                  controlInnerSection2 = ((Recordset) controlInnerRecset)[1][10724] as O7MFKAssignmentControlInnerSection;
                  num2 = (short) 109;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8F\uF791\uED93\uE695聯ﺙ쎛\uDC9D햟횡킣즥욧\uD9A9", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (controlHeadO7 != null)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 10:
                case 11:
                  num2 = (short) 105;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).HiddenStatic)
                  {
                    num2 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 13:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  try
                  {
                    num2 = (short) 54;
                    int num6 = (int) (IntPtr) num2;
                    while (true)
                    {
                      IAcpFeatureNode current;
                      string str;
                      KeypadButtonInnerSection buttonInnerSection2;
                      string A_1_7;
                      string index41415UiValue;
                      switch (num6)
                      {
                        case 0:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏\uE691\uF593\uE495잗펙\uF89B", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 8;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 51;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏ﮑ\uEC93ꂕ잗펙\uF89B", A_1_1), culture);
                          num2 = (short) 6;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 26:
                          num2 = (short) 45;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (A_1_7 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쒕\uDD97횙\uDD9B잝\uF09F\uE3A1\uF0A3\uF2A5\uEDA7\uF8A9\uE2AB", A_1_1), culture))
                          {
                            num2 = (short) 58;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 21;
                        case 5:
                        case 6:
                        case 7:
                        case 10:
                        case 11:
                        case 18:
                        case 23:
                        case 29:
                        case 31 /*0x1F*/:
                        case 35:
                        case 40:
                        case 55:
                        case 59:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 3;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏\uFD91\uE193\uF895ﲗ튙ﶛ\uED9D좟ﶡ\uEDA3슥", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 24;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num4;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uDD95\uDD97쎙첛\uDF9D\uE49F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1_1), culture) + num4.ToString();
                          num2 = (short) 5;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓첕\uDD97좙펛꺝", A_1_1), culture);
                          num2 = (short) 55;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒏\uE591ﮓ꒕잗펙\uF89B", A_1_1), culture);
                          num2 = (short) 31 /*0x1F*/;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("햏ﮑ\uF393ﺕ\uEC97ꊙ쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 49;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 57;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (str == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓첕\uDD97좙펛꺝", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 9;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 46;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          this.a(ref A_0, A_1_7);
                          num2 = (short) 39;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 2;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 19;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Fﲑ\uF193ꞕ잗펙\uF89B", A_1_1), culture);
                          num2 = (short) 59;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          this.a(ref A_0, A_1_7);
                          num2 = (short) 26;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 37;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 56;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          num2 = (short) 20;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          this.a(ref A_0, A_1_7);
                          num2 = (short) 28;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삏\uFD91\uE193\uF895ﲗ튙ﶛ\uED9D좟ﶡ\uEDA3슥", A_1_1), culture);
                          num2 = (short) 35;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("횏\uFD91\uE193\uE495겗얙햛瞧", A_1_1), culture);
                          num2 = (short) 18;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏\uF791\uE293\uF395\uF697궙쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 33;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 13;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          num2 = (short) 32 /*0x20*/;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒏晴\uE693\uF395ﶗꦙ쎛힝쒟", A_1_1), culture);
                          num2 = (short) 10;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 15;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 39;
                        case 33:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏\uF791\uE293\uF395\uF697궙쎛힝쒟", A_1_1), culture);
                          num2 = (short) 29;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          goto label_416;
                        case 36:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8Fﮑ望\uF395ꆗ얙햛瞧", A_1_1), culture);
                          num2 = (short) 40;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 22;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 28;
                        case 38:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏ﮑ\uEC93ꂕ잗펙\uF89B", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 1;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 39:
                        case 50:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 14;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          num2 = (short) 34;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("횏\uFD91\uE193\uE495겗얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 44;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 25;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒏\uE591ﮓ꒕잗펙\uF89B", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 52;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          if (!(str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("횏ﮑ\uE293\uF395궗얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 38;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 53;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 48 /*0x30*/;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 39;
                        case 46:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Fﲑ\uF193ꞕ잗펙\uF89B", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 17;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 43;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection2 = current[10709] as KeypadButtonInnerSection;
                            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                            A_1_7 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                            index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
                            num2 = (short) 4;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 41;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          this.a(ref A_0, A_1_7);
                          num2 = (short) 50;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8Fﮑ望\uF395ꆗ얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 36;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎏\uE691\uF593\uE495잗펙\uF89B", A_1_1), culture);
                          num2 = (short) 11;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          if (str == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒏晴\uE693\uF395ﶗꦙ쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 30;
                            num6 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 42;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 53:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("횏ﮑ\uE293\uF395궗얙햛瞧", A_1_1), culture);
                          num2 = (short) 7;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 54:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 56:
                          num2 = (short) 16 /*0x10*/;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 57:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("햏ﮑ\uF393ﺕ\uEC97ꊙ쎛힝쒟", A_1_1), culture);
                          num2 = (short) 23;
                          num6 = (int) (IntPtr) num2;
                          continue;
                        case 58:
                          A_1_7 = A_1_7 + this.a + index41415UiValue;
                          num2 = (short) 21;
                          num6 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 47;
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
                              goto label_114;
                            default:
                              continue;
                          }
                        case 1:
                          goto label_120;
                        case 2:
                          enumerator.Dispose();
                          break;
                        default:
label_114:
                          if (enumerator != null)
                          {
                            num8 = (short) -11434;
                            int num9 = (int) num8;
                            num8 = (short) -11434;
                            int num10 = (int) num8;
                            switch (num9 == num10 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                break;
                              default:
                                num8 = (short) 0;
                                if (num8 == (short) 0)
                                  ;
                                num8 = (short) 2;
                                num7 = (int) (IntPtr) num8;
                                continue;
                            }
                          }
                          else
                            goto label_120;
                          break;
                      }
                      num8 = (short) 1;
                      num7 = (int) (IntPtr) num8;
                    }
label_120:;
                  }
label_416:
                  table.RecSet.Add(recSet);
                  num2 = (short) 111;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (isRightToLeft)
                  {
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  try
                  {
                    num2 = (short) 4;
                    int num11 = (int) (IntPtr) num2;
                    while (true)
                    {
                      O7NavigationControlsTableInnerSection tableInnerSection;
                      string str1;
                      string str2;
                      switch (num11)
                      {
                        case 0:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 12;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          tableInnerSection = ((IAcpFeatureNode) current)[10728] as O7NavigationControlsTableInnerSection;
                          int buttonA41293Value = tableInnerSection.RadErgoControlO7UpDownButton_A41293Value;
                          str2 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO7UpDownButton_A41293).Converter.Convert((object) buttonA41293Value, (Type) null, (object) null, culture);
                          num2 = (short) 13;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                        case 5:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 15;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 20;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 8;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕좗\uD899즛쪝\uF49F\uEDA1\uEAA3", A_1_1), culture);
                          num2 = (short) 5;
                          num11 = (int) (IntPtr) num2;
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
                        case 6:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 11;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 9;
                        case 7:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풏\uFD91\uE393\uF895잗\uD899\uE99B\uEA9D풟춡쪣", A_1_1), culture);
                          num2 = (short) 1;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                        case 14:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 9;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                        case 10:
                          A_0.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO7UpDownButton_A41293).UIName.ToString();
                          str1 = tableInnerSection.O7UpDownButtonName_A41292_UIValue.ToString();
                          num2 = (short) 18;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 10;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 19;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (isRightToLeft)
                          {
                            num2 = (short) 17;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 6;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (str1 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풏\uFD91\uE393\uF895잗\uD899\uE99B\uEA9D풟춡쪣", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 7;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 1;
                        case 17:
                          num2 = (short) 2;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쎕좗\uD899즛쪝\uF49F\uEDA1\uEAA3", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 3;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          goto label_198;
                        case 20:
                          this.a(ref A_0, str2.ToString());
                          num2 = (short) 14;
                          num11 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 0;
                      num11 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num12 = 2;
                    int num13 = (int) (IntPtr) num12;
                    while (true)
                    {
                      switch (num13)
                      {
                        case 0:
                          goto label_397;
                        case 1:
                          enumerator.Dispose();
                          num12 = (short) 0;
                          num13 = (int) (IntPtr) num12;
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
                        num12 = (short) 1;
                        num13 = (int) (IntPtr) num12;
                      }
                      else
                        break;
                    }
label_397:;
                  }
label_198:
                  table.RecSet.Add(recSet);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                case 35:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 87;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (!isRightToLeft)
                  {
                    num2 = (short) 65;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_2);
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 67;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 28:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 106;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 90;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_417;
                case 31 /*0x1F*/:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 32 /*0x20*/:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (A_1_4 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓힕\uDB97캙햛톝\uEE9F\uE1A1\uEBA3\uE8A5ﮧ\uE5A9\uE0AB\uE7AD\uF4AF\uF3B1\uE0B3ﾵ\uF7B7\uF4B9", A_1_1), culture))
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 24;
                case 37:
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 97;
                case 39:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 73;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  A_1_4 = A_1_4 + this.a + indexA41418UiValue;
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  controlInnerRecset = ((FeatureNode) controlHeadO7)[10718].EmbeddedRecset as O7MFKAssignmentControlInnerRecset;
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  num2 = (short) 96 /*0x60*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 44;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 78;
                case 44:
                  this.a(ref A_0, "");
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                case 91:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 100;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  if (!((AcpFieldBase) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).HiddenStatic)
                  {
                    num2 = (short) 72;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 56;
                case 47:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_417;
                case 48 /*0x30*/:
                  if (A_1_3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓힕\uDB97캙햛톝\uEE9F\uE1A1\uEBA3\uE8A5ﮧ\uE5A9\uE0AB\uE7AD\uF4AF\uF3B1\uE0B3ﾵ\uF7B7\uF4B9", A_1_1), culture))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 84;
                case 49:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uD895\uD997척햛\uD99D\uE19F\uF6A1\uEDA3\uE9A5\uE6A7\uE9A9\uE3AB\uE0AD\uE4AF\uE0B1﮳蝹\uEBB7", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  if (buttonInnerRecset2 != null)
                  {
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 113;
                case 51:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 52:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("튏\uE791\uE093\uE295\uF797\uF499\uEF9B솝솟첡삣殮\uEBA7얩슫\uDAAD슯\uDDB1\uD8B3억", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98Fﲑ\uF093\uF395\uE097얙햛瞧", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풏\uF791\uE793\uF595\uEA97\uF399\uEC9B\uEA9D즟춡쪣殮\uE1A7캩", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("펏\uFD91望\uE095ﶗ\uF499\uE89B\uF79D쾟첡얣쪥\uF7A7\uE3A9좫", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒏\uE091\uE193\uF895\uF397\uF399\uF29B劣ﾟ\uEBA1\uE0A3", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 101;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 86;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 54:
                  enumerator = ((Collection<FeatureNode>) o7InnerRecset).GetEnumerator();
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (controlHeadO7 != null)
                  {
                    num2 = (short) 41;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 109;
                case 56:
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                case 79:
                case 106:
                case 107:
                  A_0.UIFieldName = ((AcpFieldBase) (iacpFeatureNode3[10713] as O7DataButtonInnerSection).RadErgCtrlHeadO7DataButtonName_A41296).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓튕\uD997캙\uDD9B\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7\uF5A9鶫", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  try
                  {
                    num2 = (short) 25;
                    int num14 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str;
                      IAcpFeatureNode current;
                      switch (num14)
                      {
                        case 0:
                          goto label_18;
                        case 1:
                          num2 = (short) 11;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 19:
                        case 28:
                        case 29:
                          A_0.UIFieldName = ((O7Inner) current).O7InnerSection.CHO7EmergencyButtonName_A41289Value.ToString();
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uD995쪗\uDB99튛\uD99D\uE59F\uE0A1\uF1A3\uF2A5ﲧ\uE5A9\uE2AB", A_1_1), culture);
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 12;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          this.a(ref A_0, "");
                          num2 = (short) 24;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 28;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 7:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 29;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          this.a(ref A_0, "");
                          num2 = (short) 5;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 6;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 9:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 4;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 10:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 8;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 31 /*0x1F*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 18;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 30;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 15;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 19;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 32 /*0x20*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                        case 24:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 2;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str.ToString());
                            num2 = (short) 9;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 3;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 16 /*0x10*/;
                        case 20:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 26;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 21:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 23;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (IAcpFeatureNode) enumerator.Current;
                          recSet = new _RecSet();
                          A_0 = new _UIFields();
                          ++num3;
                          recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                          recSet.RecNo = num3.ToString();
                          O7InnerSection o7InnerSection = current[10715] as O7InnerSection;
                          str = (string) ((AcpFieldX<int, string>) o7InnerSection.CHO7EmergencyButtonFeature_A41291).Converter.Convert((object) o7InnerSection.CHO7EmergencyButtonFeature_A41291Value, (Type) null, (object) null, culture);
                          num2 = (short) 22;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 20;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 0;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 26:
                          num2 = (short) 13;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          num2 = (short) 17;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 16 /*0x10*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          this.a(ref A_0, str.ToString());
                          num2 = (short) 7;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 14;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                      }
                      num2 = (short) 21;
                      num14 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num15 = 0;
                    while (true)
                    {
                      short num16;
                      switch (num15)
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
                          goto label_251;
                        case 2:
                          enumerator.Dispose();
                          num16 = (short) 1;
                          num15 = (int) (IntPtr) num16;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num16 = (short) 2;
                        num15 = (int) (IntPtr) num16;
                      }
                      else
                        break;
                    }
label_251:;
                  }
                case 59:
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset1).GetEnumerator();
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  if (keypadRecset != null)
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 52;
                case 61:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 51;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  this.a(ref A_0, A_1_2);
                  num2 = (short) 97;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 70;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  buttonInnerRecset3 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  if (controlInnerRecset != null)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 109;
                case 67:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).HiddenStatic)
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 77;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  A_0 = new _UIFields();
                  int num17 = ((AcpField<int>) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).Value;
                  A_1_2 = (string) ((AcpFieldX<int, string>) controlHeadO7.O7MultiFunctionKnob.RadErgoControlO7MFKButtonPress_A42218).Converter.Convert((object) num17, (Type) null, (object) null, culture);
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 0;
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 75:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).HiddenStatic)
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 73;
                case 76:
                  this.a(ref A_0, "");
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                case 108:
                  num2 = (short) 103;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  if (feature != null)
                  {
                    num2 = (short) 95;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 83;
                case 82:
                  try
                  {
                    num2 = (short) 29;
                    int num18 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KMButtonInnerSection buttonInnerSection3;
                      string str3;
                      string str4;
                      string str5;
                      IAcpFeatureNode current;
                      switch (num18)
                      {
                        case 0:
                          num2 = (short) 26;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          this.a(ref A_0, "");
                          num2 = (short) 13;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 22;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 11;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 1;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 13;
                        case 6:
                        case 8:
                        case 9:
                        case 20:
                          A_0.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                          str3 = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                          num2 = (short) 37;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 44;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 10:
                          if (!(str3 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B펝\uE99F\uE6A1\uE0A3\uEAA5\uEDA7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 25;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 34;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                        case 48 /*0x30*/:
                          num2 = (short) 28;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 7;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                        case 30:
                          num2 = (short) 32 /*0x20*/;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 33;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 49;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 36;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 16 /*0x10*/:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 20;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 12;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 9;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 30;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 2;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 18;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 23:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 17;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 12;
                        case 24:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B쪝\uEF9F\uF2A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1_1), culture);
                          num2 = (short) 40;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          if (str3 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B\uDC9D\uEF9F\uF6A1\uF0A3\uE9A5\uE5A7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 43;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uD995궗\uD899즛쪝\uF49F\uEDA1\uEAA3", A_1_1), culture);
                          num2 = (short) 46;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          goto label_342;
                        case 27:
                          if (((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 5;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 19;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 35;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 29:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 31 /*0x1F*/:
                          this.a(ref A_0, "");
                          num2 = (short) 48 /*0x30*/;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 16 /*0x10*/;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 6;
                        case 33:
                          num2 = (short) 23;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B펝\uE99F\uE6A1\uE0A3\uEAA5\uEDA7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), culture);
                          num2 = (short) 51;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 8;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          num2 = (short) 14;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          if (!(str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B쪝\uEF9F\uF2A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 10;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 24;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                        case 40:
                        case 46:
                        case 51:
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 3;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 39:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            recSet = new _RecSet();
                            A_0 = new _UIFields();
                            ++num3;
                            recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                            recSet.RecNo = num3.ToString();
                            buttonInnerSection3 = current[10239] as KMButtonInnerSection;
                            int featureA19646Value = buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                            int featureA19746Value = buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                            str5 = (string) ((AcpFieldX<int, string>) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, culture);
                            str4 = (string) ((AcpFieldX<int, string>) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, culture);
                            num2 = (short) 41;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 15;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 42;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          num2 = (short) 52;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓얕톗\uDE99\uD99B\uDC9D\uEF9F\uF6A1\uF0A3\uE9A5\uE5A7\uE8A9嶺節\uE4AFﶱ荒", A_1_1), culture);
                          num2 = (short) 38;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 6;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          num2 = (short) 27;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 21;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 49:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 4;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 50;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          if (((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 31 /*0x1F*/;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 11;
                        case 52:
                          if (isRightToLeft)
                          {
                            num2 = (short) 45;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 47;
                          num18 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 39;
                      num18 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num19 = 1;
                    while (true)
                    {
                      short num20;
                      switch (num19)
                      {
                        case 0:
                          goto label_339;
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
                          num20 = (short) 0;
                          num19 = (int) (IntPtr) num20;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num20 = (short) 2;
                        num19 = (int) (IntPtr) num20;
                      }
                      else
                        break;
                    }
label_339:;
                  }
                case 83:
                  accessoriesRecset = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
                  num2 = (short) 112 /*0x70*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 84:
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    this.a(ref A_0, "");
                    num2 = (short) 110;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 86:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 107;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 88:
                  if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                  {
                    num2 = (short) 80 /*0x50*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 90:
                case 110:
                  this.a(ref A_0, A_1_5);
                  num2 = (short) 89;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                  if (isRightToLeft)
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0, A_1_6);
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 93:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_342;
                case 94:
                  this.a(ref A_0, A_1_3);
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 95:
                  o7InnerRecset = ((Recordset) feature)[0][10719].EmbeddedRecset as O7InnerRecset;
                  tableInnerRecset = ((Recordset) feature)[0][10727].EmbeddedRecset as O7NavigationControlsTableInnerRecset;
                  buttonInnerRecset2 = ((Recordset) feature)[0][10717].EmbeddedRecset as O7DataButtonInnerRecset;
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  if (o7InnerRecset != null)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 97:
                case 100:
                  A_0.UIFieldName = RptMgrErrorHandler.b("\uDD8F풑\uDF93욕\uEA97ﾙ\uEF9B\uED9D\uE29F잡첣장\uDEA7쎩쎫\uDCAD", A_1_1);
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uDB95\uDE97톙첛첝\uE59F\uF1A1\uF7A3\uE4A5\uEDA7\uE2A9\uEDAB\uF8AD羚ﶱ\uE6B3", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                  if (!isRightToLeft)
                  {
                    this.a(ref A_0, A_1_5);
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 99:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  iacpFeatureNode3 = ((Recordset) buttonInnerRecset2)[0];
                  buttonInnerSection1 = iacpFeatureNode3[10713] as O7DataButtonInnerSection;
                  int num21 = ((AcpField<int>) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).Value;
                  int num22 = ((AcpField<int>) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).Value;
                  A_1_3 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).Converter.Convert((object) num21, (Type) null, (object) null, culture);
                  A_1_4 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgCtrlHeadO7DataButtonTrkFeature_A41297).Converter.Convert((object) num22, (Type) null, (object) null, culture);
                  indexA41417UiValue = buttonInnerSection1.CHO7DataButtonConvIndex_A41417_UIValue;
                  indexA41418UiValue = buttonInnerSection1.CHO7DataButtonTrkIndex_A41418_UIValue;
                  num2 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 101:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_417;
                case 102:
                  buttonInnerRecset1 = ((Recordset) accessoriesRecset)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 103:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).HiddenStatic)
                  {
                    num2 = (short) 94;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 104:
                  this.a(ref A_0, A_1_4);
                  num2 = (short) 79;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO7DataButtonCnvFeature_A41299).HiddenStatic)
                  {
                    num2 = (short) 28;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 57;
                case 109:
                  A_0 = new _UIFields();
                  int num23 = ((AcpField<int>) controlInnerSection1.RadErgoControlO7MFKFeatureAssignment_A41295).Value;
                  A_1_6 = (string) ((AcpFieldX<int, string>) controlInnerSection1.RadErgoControlO7MFKFeatureAssignment_A41295).Converter.Convert((object) num23, (Type) null, (object) null, culture);
                  num2 = (short) 92;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 111:
                  goto label_417;
                case 112 /*0x70*/:
                  if (accessoriesRecset != null)
                  {
                    num2 = (short) 102;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 113:
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_18:
              recSet = new _RecSet();
              ++num3;
              recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓\uDB95춗횙좛힝\uE69F\uF7A1\uEAA3\uE5A5ﲧ\uE3A9\uE3AB\uE0ADﮯﲱ﮳\uF4B5", A_1_1), culture);
              recSet.RecNo = num3.ToString();
              controlInnerRecset = (O7MFKAssignmentControlInnerRecset) null;
              controlInnerSection1 = (O7MFKAssignmentControlInnerSection) null;
              controlInnerSection2 = (O7MFKAssignmentControlInnerSection) null;
              controlHeadO7 = FeatureManager.GetFeature(4114)[0] as Motorola.MackinawCPS.CoreFeatures.ControlHeadO7.ControlHeadO7;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
label_342:
              num2 = (short) 74;
              num1 = (int) (IntPtr) num2;
            }
label_417:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  public void AddButtonsAndControlO5(ref _XMLData RptXMLData, reportType rptType)
  {
    int A_1_1 = 12;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        O5InnerRecset o5InnerRecset;
        KMButtonInnerRecset buttonInnerRecset1;
        DataButtonInnerRecset buttonInnerRecset2;
        O5NavigationControlsTableInnerRecset tableInnerRecset;
        KeypadMicAndAccessoriesRecset accessoriesRecset;
        KeypadRecset keypadRecset;
        KeypadButtonInnerRecset buttonInnerRecset3;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        ControlHeadO5Recset feature;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            o5InnerRecset = (O5InnerRecset) null;
            buttonInnerRecset1 = (KMButtonInnerRecset) null;
            buttonInnerRecset2 = (DataButtonInnerRecset) null;
            tableInnerRecset = (O5NavigationControlsTableInnerRecset) null;
            accessoriesRecset = (KeypadMicAndAccessoriesRecset) null;
            keypadRecset = (KeypadRecset) null;
            buttonInnerRecset3 = (KeypadButtonInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            IAcpFeatureNode iacpFeatureNode1 = FeatureManager.GetFeature(2130)[0];
            IAcpFeatureNode iacpFeatureNode2 = FeatureManager.GetFeature(2128)[0];
            feature = FeatureManager.GetFeature(2130) as ControlHeadO5Recset;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              DataButtonInnerSection buttonInnerSection1;
              _UIFields A_0;
              string str1;
              IEnumerator<FeatureNode> enumerator;
              IAcpFeatureNode iacpFeatureNode3;
              _RecSet recSet;
              string str2;
              string indexA41424UiValue;
              int num3;
              string indexA41423UiValue;
              int num4;
              switch (num1)
              {
                case 0:
                  enumerator = ((Collection<FeatureNode>) o5InnerRecset).GetEnumerator();
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (feature != null)
                  {
                    num2 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 11;
                case 3:
                  if (isRightToLeft)
                  {
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒풔풖춘튚튜톞\uE2A0\uECA2\uEBA4\uF4A6\uE6A8\uE7AA\uE4AC\uEBAE\uF0B0\uE7B2ﲴ\uF8B6\uF7B8", A_1_1), culture))
                  {
                    num2 = (short) 72;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 63 /*0x3F*/;
                case 5:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 6:
                case 36:
                case 39:
                case 58:
                  A_0.UIFieldName = ((AcpFieldBase) (iacpFeatureNode3[10209] as DataButtonInnerSection).RadErgoCfgKMDataButtonName_A22601).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒톔횖춘\uDA9A\uDF9C쪞\uF5A0\uF7A2\uEAA4\uE9A6\uF6A8骪", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
label_96:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (buttonInnerRecset2 != null)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 10:
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset1).GetEnumerator();
                  num2 = (short) 64 /*0x40*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
label_221:
                  accessoriesRecset = FeatureManager.GetFeature(2128) as KeypadMicAndAccessoriesRecset;
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("춎\uE490\uE792\uE194\uF896\uF798\uE89A슜ﺞ쾠잢瘝\uE4A6욨얪\uD9AC\uDDAE\uDEB0\uDFB2운", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎ﾐ\uF792\uF094\uEF96욘튚列", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쮎\uF490\uE092\uF694\uE596\uF098\uEB9A\uE99C\uF69E캠춢瘝\uEEA6춨", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첎ﺐﶒ\uE394\uF296\uF798\uEF9A\uF49C\uF09E쾠슢즤\uF8A6\uE0A8쾪", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E\uE390\uE692ﮔﲖ\uF098\uF59A煮삞\uE8A0\uE7A2", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 45;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_363;
                case 18:
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (o5InnerRecset != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 20:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 34;
                case 21:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 44;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 23:
                  buttonInnerRecset1 = ((Recordset) accessoriesRecset)[0][10231].EmbeddedRecset as KMButtonInnerRecset;
                  buttonInnerRecset2 = ((Recordset) accessoriesRecset)[0][10228].EmbeddedRecset as DataButtonInnerRecset;
                  num2 = (short) 0;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                case 71:
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDB94횖쾘튚\uDA9C\uDE9E\uF5A0\uEAA2\uEAA4\uE9A6\uEAA8\uE4AA\uE3ACﮮ\uE3B0ﲲ領\uE4B6", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  iacpFeatureNode3 = ((Recordset) buttonInnerRecset2)[0];
                  buttonInnerSection1 = iacpFeatureNode3[10209] as DataButtonInnerSection;
                  int featureA22603Value = buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603Value;
                  int featureA22605Value = buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605Value;
                  str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).Converter.Convert((object) featureA22603Value, (Type) null, (object) null, culture);
                  str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).Converter.Convert((object) featureA22605Value, (Type) null, (object) null, culture);
                  indexA41423UiValue = buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonIndex_A41423_UIValue;
                  indexA41424UiValue = buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonIndex_A41424_UIValue;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  try
                  {
                    num2 = (short) 36;
                    int num5 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str3;
                      string A_1_2;
                      KeypadButtonInnerSection buttonInnerSection2;
                      IAcpFeatureNode current;
                      string index41415UiValue;
                      switch (num5)
                      {
                        case 0:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒쾔튖쮘풚궜", A_1_1), culture);
                          num2 = (short) 14;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 33;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 4:
                        case 6:
                        case 10:
                        case 14:
                        case 25:
                        case 29:
                        case 30:
                        case 31 /*0x1F*/:
                        case 42:
                        case 46:
                        case 54:
                        case 58:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 44;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Eﺐ\uE692ﮔ\uF396톘漢\uEE9C\uF79Eﺠ\uEAA2솤", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 24;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          ++num4;
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDE94튖삘쮚\uDC9C\uDB9E\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1_1), culture) + num4.ToString();
                          num2 = (short) 6;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 56;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          A_1_2 = A_1_2 + this.a + index41415UiValue;
                          num2 = (short) 34;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 53;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 20;
                        case 9:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪎\uF890\uF492ﶔ\uE396ꆘ쒚풜ﮞ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 32 /*0x20*/;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          if (str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎ﺐ\uE692\uE794ꎖ욘튚列", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 28;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 37;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E戀\uE192\uF094\uF296ꪘ쒚풜ﮞ", A_1_1), culture);
                          num2 = (short) 10;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF490\uE592\uF094練꺘쒚풜ﮞ", A_1_1), culture);
                          num2 = (short) 42;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 5;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 18;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          if (str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삎ﾐ\uF692꒔좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 55;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솎\uF890ﶒ\uF094꺖욘튚列", A_1_1), culture);
                          num2 = (short) 4;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                        case 56:
                          num2 = (short) 8;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uE590\uF292\uE794좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 46;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                        case 33:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str3 = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 47;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uE590\uF292\uE794좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 3;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 19;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection2 = current[10709] as KeypadButtonInnerSection;
                            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                            A_1_2 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                            index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
                            num2 = (short) 50;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 23;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 39;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Eﺐ\uE692ﮔ\uF396톘漢\uEE9C\uF79Eﺠ\uEAA2솤", A_1_1), culture);
                          num2 = (short) 2;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 1;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 20;
                        case 27:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪎\uF890\uF492ﶔ\uE396ꆘ쒚풜ﮞ", A_1_1), culture);
                          num2 = (short) 58;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎ﺐ\uE692\uE794ꎖ욘튚列", A_1_1), culture);
                          num2 = (short) 31 /*0x1F*/;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솎\uF890ﶒ\uF094꺖욘튚列", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 21;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 17;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          num2 = (short) 48 /*0x30*/;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 35:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E\uE690ﲒꞔ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 57;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 45;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 37:
                          if (str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎\uF890\uE592\uF094ꊖ욘튚列", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 43;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 59;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF890\uEB92ꎔ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 25;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 39:
                          goto label_357;
                        case 40:
                          if (str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF490\uE592\uF094練꺘쒚풜ﮞ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 13;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          num2 = (short) 15;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎\uF890\uE592\uF094ꊖ욘튚列", A_1_1), culture);
                          num2 = (short) 54;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E\uE690ﲒꞔ좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 30;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (!(str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒쾔튖쮘풚궜", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 16 /*0x10*/;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 48 /*0x30*/:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 52;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 41;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 51;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          if (A_1_2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒잔튖햘\uDA9A쒜쾞\uE0A0\uF7A2\uF1A4\uE2A6ﮨ\uE5AA", A_1_1), culture))
                          {
                            num2 = (short) 7;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 34;
                        case 51:
                          num2 = (short) 26;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 49;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 51;
                        case 53:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 20;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 55:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삎ﾐ\uF692꒔좖킘ﾚ", A_1_1), culture);
                          num2 = (short) 29;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 57:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E戀\uE192\uF094\uF296ꪘ쒚풜ﮞ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 11;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 59:
                          if (!(str3 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF890\uEB92ꎔ좖킘ﾚ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 40;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 38;
                          num5 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 22;
                      num5 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num6 = 2;
                    while (true)
                    {
                      short num7;
                      switch (num6)
                      {
                        case 0:
                          enumerator.Dispose();
                          num7 = (short) 1;
                          num6 = (int) (IntPtr) num7;
                          continue;
                        case 1:
                          goto label_324;
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
                        num6 = (int) (IntPtr) num7;
                      }
                      else
                        break;
                    }
label_324:;
                  }
label_357:
                  table.RecSet.Add(recSet);
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  goto label_363;
                case 30:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  o5InnerRecset = ((Recordset) feature)[0][10227].EmbeddedRecset as O5InnerRecset;
                  tableInnerRecset = ((Recordset) feature)[0][10735].EmbeddedRecset as O5NavigationControlsTableInnerRecset;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 33:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 34:
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  this.a(ref A_0, "");
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 41:
                  try
                  {
                    num2 = (short) 16 /*0x10*/;
                    int num8 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str4;
                      IAcpFeatureNode current;
                      switch (num8)
                      {
                        case 0:
                          if (isRightToLeft)
                          {
                            num2 = (short) 7;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 28;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 32 /*0x20*/;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 4:
                        case 10:
                        case 20:
                          A_0.UIFieldName = ((AcpFieldBase) ((O5Inner) current).O5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonName_A22520).UIName.ToString();
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDA94얖\uD898햚\uDA9C\uDA9E\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1_1), culture);
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 22;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          goto label_27;
                        case 5:
                          num2 = (short) 3;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 18;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 21;
                        case 7:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 1;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 17;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str4.ToString());
                            num2 = (short) 9;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 19;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 11;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 11:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 10;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 8;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 2;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          this.a(ref A_0, "");
                          num2 = (short) 30;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          num2 = (short) 0;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 17:
                          if (((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 14;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 30;
                        case 18:
                          this.a(ref A_0, "");
                          num2 = (short) 21;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          num2 = (short) 26;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                        case 31 /*0x1F*/:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 4;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 15;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 24:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 13;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 25:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 31 /*0x1F*/;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 25;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 23;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 24;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            recSet = new _RecSet();
                            A_0 = new _UIFields();
                            ++num3;
                            recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                            recSet.RecNo = num3.ToString();
                            O5InnerSection o5InnerSection = current[10211] as O5InnerSection;
                            str4 = (string) ((AcpFieldX<int, string>) o5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754).Converter.Convert((object) o5InnerSection.CntrlHeadO5SignalIndependentO5M5MXChiefCHButtonButtonFeature_A19754Value, (Type) null, (object) null, culture);
                            num2 = (short) 27;
                            num8 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 5;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                        case 32 /*0x20*/:
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 20;
                          num8 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 29;
                      num8 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num9 = 0;
                    int num10 = (int) (IntPtr) num9;
                    while (true)
                    {
                      switch (num10)
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
                          num9 = (short) 2;
                          num10 = (int) (IntPtr) num9;
                          continue;
                        case 2:
                          goto label_82;
                      }
                      if (enumerator != null)
                      {
                        num9 = (short) 1;
                        num10 = (int) (IntPtr) num9;
                      }
                      else
                        break;
                    }
label_82:;
                  }
                case 42:
                  if (accessoriesRecset != null)
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 43:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 44:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  if (keypadRecset != null)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 66;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 13;
                case 47:
                case 62:
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  str2 = str2 + this.a + indexA41424UiValue;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  if (((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 53;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 25;
                case 51:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 53:
                  this.a(ref A_0, "");
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 54:
                  if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒풔풖춘튚튜톞\uE2A0\uECA2\uEBA4\uF4A6\uE6A8\uE7AA\uE4AC\uEBAE\uF0B0\uE7B2ﲴ\uF8B6\uF7B8", A_1_1), culture))
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 55:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 51;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_363;
                case 56:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 67;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 59:
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  try
                  {
                    num2 = (short) 19;
                    int num11 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str5;
                      O5NavigationControlsTableInnerSection tableInnerSection;
                      string str6;
                      switch (num11)
                      {
                        case 0:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str5.ToString());
                            num2 = (short) 12;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 14;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (!(str6 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒삔잖\uDB98캚즜쮞\uEEA0\uEDA2", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 7;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          num2 = (short) 5;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (enumerator.MoveNext())
                          {
                            FeatureNode current = enumerator.Current;
                            A_0 = new _UIFields();
                            tableInnerSection = ((IAcpFeatureNode) current)[10736] as O5NavigationControlsTableInnerSection;
                            int featureA41379Value = tableInnerSection.RadErgoControlO5NaviControlFeature_A41379Value;
                            str5 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO5NaviControlFeature_A41379).Converter.Convert((object) featureA41379Value, (Type) null, (object) null, culture);
                            num2 = (short) 0;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쮎ﺐ\uE492ﮔ좖\uDB98\uEE9A\uE99C\uEB9E캠춢", A_1_1), culture);
                          num2 = (short) 18;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          goto label_219;
                        case 6:
                        case 9:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 16 /*0x10*/;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (str6 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쮎ﺐ\uE492ﮔ좖\uDB98\uEE9A\uE99C\uEB9E캠춢", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 4;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 8;
                        case 8:
                        case 18:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 13;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 9;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                        case 16 /*0x10*/:
                          A_0.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO5NaviControlName_A41378).UIName.ToString();
                          str6 = tableInnerSection.RadErgoControlO5NaviControlName_A41378_UIValue.ToString();
                          num2 = (short) 1;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 17;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 11;
                        case 14:
                          num2 = (short) 15;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 10;
                            num11 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 6;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          this.a(ref A_0, str5.ToString());
                          num2 = (short) 11;
                          num11 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 20:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒삔잖\uDB98캚즜쮞\uEEA0\uEDA2", A_1_1), culture);
                          num2 = (short) 8;
                          num11 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 3;
                      num11 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num12 = 0;
                    int num13 = (int) (IntPtr) num12;
                    while (true)
                    {
                      switch (num13)
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
                          num12 = (short) 2;
                          num13 = (int) (IntPtr) num12;
                          continue;
                        case 2:
                          goto label_217;
                      }
                      if (enumerator != null)
                      {
                        num12 = (short) 1;
                        num13 = (int) (IntPtr) num12;
                      }
                      else
                        break;
                    }
label_217:;
                  }
label_219:
                  table.RecSet.Add(recSet);
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMTrunkingKMDatatButtonFeature_A22605).HiddenStatic)
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  num2 = (short) 54;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  try
                  {
                    num2 = (short) 34;
                    int num14 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KMButtonInnerSection buttonInnerSection3;
                      string str7;
                      IAcpFeatureNode current;
                      string str8;
                      string str9;
                      switch (num14)
                      {
                        case 0:
                        case 25:
                        case 28:
                        case 30:
                          recSet.UIFields.Add(A_0);
                          table.RecSet.Add(recSet);
                          num2 = (short) 8;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 48 /*0x30*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 11;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 3:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 37;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            recSet = new _RecSet();
                            A_0 = new _UIFields();
                            ++num3;
                            recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                            recSet.RecNo = num3.ToString();
                            buttonInnerSection3 = current[10239] as KMButtonInnerSection;
                            int featureA19646Value = buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646Value;
                            int featureA19746Value = buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746Value;
                            str7 = (string) ((AcpFieldX<int, string>) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).Converter.Convert((object) featureA19646Value, (Type) null, (object) null, culture);
                            str8 = (string) ((AcpFieldX<int, string>) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).Converter.Convert((object) featureA19746Value, (Type) null, (object) null, culture);
                            num2 = (short) 17;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 23;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 10:
                        case 22:
                        case 51:
                          A_0.UIFieldName = ((AcpFieldBase) ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561).UIName.ToString();
                          str9 = ((KMButtonInner) current).KMButtonInnerSection.RadErgoCfgKMButtonName_A22561_UIValue.ToString();
                          num2 = (short) 46;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A즜킞\uF1A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1_1), culture);
                          num2 = (short) 25;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (isRightToLeft)
                          {
                            num2 = (short) 19;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 44;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          if (str9 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A\uDF9C킞\uF5A0\uF7A2\uEAA4\uEAA6\uEBA8ﺪ怜ﮮﺰﶲ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 24;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDA94ꊖ\uDB98캚즜쮞\uEEA0\uEDA2", A_1_1), culture);
                          num2 = (short) 0;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 5;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 7;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 10;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 42;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (isRightToLeft)
                          {
                            num2 = (short) 43;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 26;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A킜횞\uE5A0\uE7A2\uE9A4\uE2A6\uEBA8ﺪ怜ﮮﺰﶲ", A_1_1), culture);
                          num2 = (short) 28;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 29;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          this.a(ref A_0, "");
                          num2 = (short) 21;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 38;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 47;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 33;
                        case 21:
                        case 39:
                          num2 = (short) 41;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          num2 = (short) 27;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A\uDF9C킞\uF5A0\uF7A2\uEAA4\uEAA6\uEBA8ﺪ怜ﮮﺰﶲ", A_1_1), culture);
                          num2 = (short) 30;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 1;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 48 /*0x30*/;
                        case 27:
                          goto label_83;
                        case 29:
                          num2 = (short) 15;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 3;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          this.a(ref A_0, "");
                          num2 = (short) 33;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                        case 37:
                          num2 = (short) 49;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 35:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 12;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 36:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 13;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 38:
                          this.a(ref A_0, str8.ToString());
                          num2 = (short) 39;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 51;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 50;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 42:
                          num2 = (short) 36;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          num2 = (short) 31 /*0x1F*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          num2 = (short) 52;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!(str9 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A킜횞\uE5A0\uE7A2\uE9A4\uE2A6\uEBA8ﺪ怜ﮮﺰﶲ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 9;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 46:
                          if (str9 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒요\uDE96\uDD98\uDE9A즜킞\uF1A0\uE1A2\uF0A4\uF3A6ﶨ\uE4AA\uE3AC", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 6;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 45;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMTrunkingKMButtonFeature_A19746).HiddenStatic)
                          {
                            num2 = (short) 18;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 21;
                        case 48 /*0x30*/:
                          num2 = (short) 2;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 40;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 50:
                          this.a(ref A_0, str7.ToString());
                          num2 = (short) 22;
                          num14 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          if (!((AcpFieldBase) buttonInnerSection3.RadErgoCfgKMConventionalKMButtonFeature_A19646).HiddenDynamic)
                          {
                            num2 = (short) 14;
                            num14 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 42;
                      }
                      num2 = (short) 4;
                      num14 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num15 = 1;
                    while (true)
                    {
                      short num16;
                      switch (num15)
                      {
                        case 0:
                          goto label_178;
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
                          num16 = (short) 0;
                          num15 = (int) (IntPtr) num16;
                          continue;
                      }
                      if (enumerator != null)
                      {
                        num16 = (short) 2;
                        num15 = (int) (IntPtr) num16;
                      }
                      else
                        break;
                    }
label_178:;
                  }
                case 65:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_363;
                case 66:
                  buttonInnerRecset3 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_83;
                case 69:
                  num2 = (short) -28564;
                  int num17 = (int) num2;
                  num2 = (short) -28564;
                  int num18 = (int) num2;
                  switch (num17 == num18 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_221;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (!((AcpFieldBase) buttonInnerSection1.RadErgoCfgKMConventionalKMDatatButtonFeature_A22603).HiddenStatic)
                      {
                        num2 = (short) 1;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_96;
                  }
                case 70:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒎\uF490\uEA92\uE594\uF696ﶘ쒚\uDF9C\uEA9E햠힢쪤즦\uDAA8", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  str1 = str1 + this.a + indexA41423UiValue;
                  num2 = (short) 63 /*0x3F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_27:
              num2 = (short) 68;
              num1 = (int) (IntPtr) num2;
              continue;
label_83:
              num2 = (short) 32 /*0x20*/;
              num1 = (int) (IntPtr) num2;
            }
label_363:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  public void AddButtonsAndControlO9(ref _XMLData RptXMLData, reportType rptType)
  {
    int A_1_1 = 15;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        ControlHeadO9Recset feature;
        ResponseSelectorListInnerRecset selectorListInnerRecset;
        DirectionalButtonsListInnerRecset buttonsListInnerRecset1;
        O9InnerRecset o9InnerRecset;
        O9DataButtonInnerRecset buttonInnerRecset1;
        O9NavigationControlsTableInnerRecset tableInnerRecset;
        BottomFunctionProgrammableButtonInnerRecset buttonInnerRecset2;
        PASirenButtonsListInnerRecset buttonsListInnerRecset2;
        Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem trunkingSystem;
        KeypadRecset keypadRecset;
        KeypadButtonInnerRecset buttonInnerRecset3;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            AcpReports acpReports = new AcpReports();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            IAcpFeatureNode iacpFeatureNode = FeatureManager.GetFeature(4003)[0];
            feature = FeatureManager.GetFeature(4003) as ControlHeadO9Recset;
            selectorListInnerRecset = (ResponseSelectorListInnerRecset) null;
            buttonsListInnerRecset1 = (DirectionalButtonsListInnerRecset) null;
            o9InnerRecset = (O9InnerRecset) null;
            buttonInnerRecset1 = (O9DataButtonInnerRecset) null;
            tableInnerRecset = (O9NavigationControlsTableInnerRecset) null;
            buttonInnerRecset2 = (BottomFunctionProgrammableButtonInnerRecset) null;
            buttonsListInnerRecset2 = (PASirenButtonsListInnerRecset) null;
            trunkingSystem = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
            keypadRecset = (KeypadRecset) null;
            buttonInnerRecset3 = (KeypadButtonInnerRecset) null;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 43;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              _UIFields A_0;
              string str1;
              string str2;
              _RecSet recSet;
              O9DataButtonInnerSection buttonInnerSection1;
              int num3;
              int num4;
              IEnumerator<FeatureNode> enumerator;
              string indexA41414UiValue;
              string indexA41416UiValue;
              switch (num1)
              {
                case 0:
                  if (keypadRecset != null)
                  {
                    num2 = (short) 41;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 1:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("삑\uF193\uE595\uE897\uF599\uF29B\uED9D얟ﶡ\uF7A3쎥쒧쾩쾫\uDAAD\uDFAF삱", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) selectorListInnerRecset).GetEnumerator();
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  this.a(ref A_0, str1.ToString());
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                case 7:
                case 24:
                case 42:
                case 51:
                case 53:
                case 57:
                case 71:
                  A_0.UIFieldName = ((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonName_A36523).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uDC97\uDB99좛\uDF9D\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9\uF3AB龭", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 56;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_363;
                case 8:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_461;
                case 9:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킑\uE193\uE295\uEC97\uF599\uF29B\uED9Dﾟ쎡쪣슥\uF7A7\uE9A9쎫삭쒯삱\uDBB3\uDAB5쮷", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91望\uF295ﶗ\uE299쎛힝쒟", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횑\uF193\uE595ﮗ\uE899\uF59B\uEE9D풟쮡쮣좥\uF7A7\uE3A9좫", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("톑ﮓ\uF895\uEE97ﾙ\uF29B\uEA9D즟춡쪣장쒧\uF5A9\uE5AB쪭", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욑\uE693\uE395\uF697\uF199\uF59B\uF09D잟ﶡ\uEDA3\uE2A5", A_1_1), culture));
                  recSet = (_RecSet) null;
                  A_0 = (_UIFields) null;
                  num3 = 0;
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (isRightToLeft)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  this.a(ref A_0, "");
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 15:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
                  {
                    num2 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_461;
                case 16 /*0x10*/:
                  if (buttonInnerRecset2 != null)
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 73;
                case 17:
                  goto label_464;
                case 18:
                  this.a(ref A_0, str1.ToString());
                  this.a(ref A_0, "");
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (!((Recordset) keypadRecset).HiddenStatic)
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 20:
                  this.a(ref A_0, str1.ToString());
                  this.a(ref A_0, "");
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  buttonInnerSection1 = ((Recordset) buttonInnerRecset1)[0][10608] as O9DataButtonInnerSection;
                  int featureA36528Value = buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528Value;
                  int featureA36526Value = buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526Value;
                  str1 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).Converter.Convert((object) featureA36528Value, (Type) null, (object) null, culture);
                  str2 = (string) ((AcpFieldX<int, string>) buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).Converter.Convert((object) featureA36526Value, (Type) null, (object) null, culture);
                  indexA41414UiValue = buttonInnerSection1.CHO9DataButtonConvIndex_A41414_UIValue;
                  indexA41416UiValue = buttonInnerSection1.CHO9DataButtonTrkIndex_A41416_UIValue;
                  num2 = (short) 48 /*0x30*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  if (buttonsListInnerRecset1 != null)
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 27;
                case 25:
                  this.a(ref A_0, "");
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 81;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 27:
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  try
                  {
                    num2 = (short) 4;
                    int num5 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str3;
                      string str4;
                      PASirenButtonsListInnerSection listInnerSection;
                      switch (num5)
                      {
                        case 0:
                          if (str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uE3A1\uEDA3\uF4A5\uE0A7\uE5A9ﺫ\uE0AD", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 5;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 25;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91궓즕쮗\uF399\uEE9Bﮝ캟ﶡ\uF4A3\uE7A5", A_1_1), culture);
                          num2 = (short) 8;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 8:
                        case 11:
                        case 20:
                        case 23:
                        case 24:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 16 /*0x10*/;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          this.a(ref A_0, "");
                          this.a(ref A_0, str4.ToString());
                          num2 = (short) 19;
                          num5 = (int) (IntPtr) num2;
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
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uE3A1\uEDA3\uF4A5\uE0A7\uE5A9ﺫ\uE0AD", A_1_1), culture);
                          num2 = (short) 24;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          this.a(ref A_0, str4.ToString());
                          this.a(ref A_0, "");
                          num2 = (short) 27;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (str3 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91궓즕쮗\uF399\uEE9Bﮝ캟ﶡ\uECA3쾥쒧얩", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 17;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 21;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          num2 = (short) 18;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9Fﮡ\uE1A3\uEAA5\uF8A7", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 13;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 7;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uEFA1\uE5A3\uE8A5ﶧ\uEBA9\uE0AB", A_1_1), culture);
                          num2 = (short) 11;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9Fﮡ\uE1A3\uEAA5\uF8A7", A_1_1), culture);
                          num2 = (short) 2;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 30;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 26;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (!(str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uF5A1\uE5A3\uEFA5\uE4A7", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 10;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 22;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91궓즕쮗\uF399\uEE9Bﮝ캟ﶡ\uECA3쾥쒧얩", A_1_1), culture);
                          num2 = (short) 23;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          goto label_362;
                        case 19:
                        case 27:
                          A_0.UIFieldName = ((AcpFieldBase) listInnerSection.CHO9PASirenButtonsName_A41537).UIName;
                          str3 = listInnerSection.CHO9PASirenButtonsName_A41537_UIValue.ToString();
                          num2 = (short) 0;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          if (str3 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91궓즕쮗\uF399\uEE9Bﮝ캟ﶡ\uF4A3\uE7A5", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 1;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 2;
                        case 22:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uF5A1\uE5A3\uEFA5\uE4A7", A_1_1), culture);
                          num2 = (short) 20;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          if (!(str3 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쮗펙캛\uDB9D\uEE9F\uEFA1\uE5A3\uE8A5ﶧ\uEBA9\uE0AB", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 15;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (!((AcpFieldBase) listInnerSection.CHO9PASirenButtonsFeature_A41540).HiddenStatic)
                          {
                            num2 = (short) 3;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                        case 28:
                          if (!((AcpFieldBase) listInnerSection.CHO9PASirenButtonsFeature_A41540).HiddenStatic)
                          {
                            num2 = (short) 6;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 19;
                        case 29:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 9;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          listInnerSection = ((IAcpFeatureNode) current)[10744] as PASirenButtonsListInnerSection;
                          int featureA41540Value = listInnerSection.CHO9PASirenButtonsFeature_A41540Value;
                          str4 = (string) ((AcpFieldX<int, string>) listInnerSection.CHO9PASirenButtonsFeature_A41540).Converter.Convert((object) featureA41540Value, (Type) null, (object) null, culture);
                          num2 = (short) 14;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          num2 = (short) 28;
                          num5 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 29;
                      num5 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num6 = 1;
                    while (true)
                    {
                      switch (num6)
                      {
                        case 0:
                          goto label_454;
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
                          num6 = 0;
                          continue;
                      }
                      if (enumerator != null)
                        num6 = 2;
                      else
                        break;
                    }
label_454:;
                  }
label_362:
                  table.RecSet.Add(recSet);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킑ﮓ\uE295\uEC97\uF599\uF19B솝\uE29F힡킣튥잧쒩\uDFAB", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset2).GetEnumerator();
                  num2 = (short) 64 /*0x40*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD991\uF193\uEF95\uE897ﮙ\uF89B솝\uE29F힡킣튥잧쒩\uDFAB", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  num4 = 0;
                  enumerator = ((Collection<FeatureNode>) buttonInnerRecset3).GetEnumerator();
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  try
                  {
                    num2 = (short) 6;
                    int num7 = (int) (IntPtr) num2;
                    while (true)
                    {
                      KeypadButtonInnerSection buttonInnerSection2;
                      IAcpFeatureNode current;
                      string A_1_2;
                      string index41415UiValue;
                      string str5;
                      switch (num7)
                      {
                        case 0:
                          A_1_2 = A_1_2 + this.a + index41415UiValue;
                          num2 = (short) 21;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          num2 = (short) 13;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("풑ﶓ\uE095ﶗ꾙쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 45;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 36;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 5:
                        case 7:
                        case 8:
                        case 11:
                        case 19:
                        case 20:
                        case 23:
                        case 29:
                        case 31 /*0x1F*/:
                        case 35:
                        case 39:
                        case 46:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 12;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 52;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 24;
                        case 6:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 9:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑ﶓ\uEE95꺗얙햛瞧", A_1_1), culture);
                          num2 = (short) 39;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("힑ﶓ\uF195\uF097\uEE99꒛솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 15;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 49;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          goto label_15;
                        case 14:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("풑ﮓ\uE395\uEA97꺙쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 2;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 18;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("힑ﶓ\uF195\uF097\uEE99꒛솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 7;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑\uF193\uE095ﶗ\uF499ꮛ솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 3;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 4;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 42;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("풑ﮓ\uE395\uEA97꺙쎛힝쒟", A_1_1), culture);
                          num2 = (short) 11;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          num2 = (short) 17;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          if (str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욑ﲓ\uE495ﶗﾙ꾛솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 26;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 14;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                        case 48 /*0x30*/:
                          A_0.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
                          str5 = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
                          num2 = (short) 38;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ﮓ\uE395\uF697ﺙ풛ﾝ펟쪡ﮣ\uEFA5첧", A_1_1), culture);
                          num2 = (short) 35;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욑ﲓ\uE495ﶗﾙ꾛솝\uE99F욡", A_1_1), culture);
                          num2 = (short) 29;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91望\uF395ꦗ얙햛瞧", A_1_1), culture);
                          num2 = (short) 20;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          if (!((AcpFieldBase) buttonInnerSection2.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 24;
                        case 30:
                          if (str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑\uE093\uF795\uEA97얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 37;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 50;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 24;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD91望\uF395ꦗ얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 34;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욑\uE393秊ꪗ얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 22;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 51;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑ﶓ\uEE95꺗얙햛瞧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 43;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑\uE093\uF795\uEA97얙햛瞧", A_1_1), culture);
                          num2 = (short) 31 /*0x1F*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          if (str5 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕슗\uDF99캛톝邟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 40;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 33;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕슗\uDF99캛톝邟", A_1_1), culture);
                          num2 = (short) 19;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          if (A_1_2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쪗\uDF99킛\uDF9D烈\uF2A1\uE5A3\uF2A5ﲧ\uEFA9ﺫ\uE0AD", A_1_1), culture))
                          {
                            num2 = (short) 0;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 21;
                        case 42:
                          this.a(ref A_0, "");
                          num2 = (short) 28;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솑\uF193\uE095ﶗ\uF499ꮛ솝\uE99F욡", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 10;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 16 /*0x10*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 44:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC91ﶓ\uF895ﶗꎙ쎛힝쒟", A_1_1), culture);
                          num2 = (short) 8;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("풑ﶓ\uE095ﶗ꾙쎛힝쒟", A_1_1), culture);
                          num2 = (short) 5;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 47:
                          if (enumerator.MoveNext())
                          {
                            current = (IAcpFeatureNode) enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection2 = current[10709] as KeypadButtonInnerSection;
                            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
                            A_1_2 = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, culture);
                            index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
                            num2 = (short) 41;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 49:
                          if (str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC91ﶓ\uF895ﶗꎙ쎛힝쒟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 44;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 30;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 50:
                          if (!(str5 == MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ﮓ\uE395\uF697ﺙ풛ﾝ펟쪡ﮣ\uEFA5첧", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            ++num4;
                            A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕펗\uDF99얛캝\uE19F\uE6A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1_1), culture) + num4.ToString();
                            num2 = (short) 23;
                            num7 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 25;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 51:
                          A_0.UIFieldDes = MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("욑\uE393秊ꪗ얙햛瞧", A_1_1), culture);
                          num2 = (short) 46;
                          num7 = (int) (IntPtr) num2;
                          continue;
                        case 52:
                          this.a(ref A_0, A_1_2);
                          num2 = (short) 48 /*0x30*/;
                          num7 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 47;
                      num7 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num8 = 0;
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
                          num8 = 2;
                          continue;
                        case 2:
                          goto label_105;
                      }
                      if (enumerator != null)
                        num8 = 1;
                      else
                        break;
                    }
label_105:;
                  }
label_15:
                  table.RecSet.Add(recSet);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 33:
                  if (o9InnerRecset != null)
                  {
                    num2 = (short) 44;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 60;
                case 34:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횑ﶓ\uE495ﶗ蓮\uE89B\uF79D쾟첡얣쪥\uF7A7\uE8A9\uD9AB\uDAAD쒯\uDDB1\uDAB3억", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) buttonsListInnerRecset1).GetEnumerator();
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  if (tableInnerRecset != null)
                  {
                    num2 = (short) 46;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 61;
                case 36:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 37:
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  try
                  {
                    num2 = (short) 17;
                    int num9 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string indexA36601UiValue;
                      string str6;
                      string str7;
                      DirectionalButtonsListInnerSection listInnerSection;
                      string str8;
                      switch (num9)
                      {
                        case 0:
                          indexA36601UiValue = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), culture);
                          num2 = (short) 3;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                        case 5:
                        case 10:
                        case 13:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 2;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          num2 = (short) 12;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (indexA36601UiValue == str8)
                          {
                            num2 = (short) 0;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 3;
                        case 6:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕첗햙첛\uDD9D\uE59F\uECA1\uF0A3\uE3A5盛", A_1_1), culture);
                          num2 = (short) 1;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                        case 18:
                        case 22:
                        case 28:
                          A_0.UIFieldName = ((AcpFieldBase) listInnerSection.RadErgCtrlHeadO9DirLightBarName_A36558).UIName.ToString();
                          str7 = listInnerSection.RadErgCtrlHeadO9DirLightBarName_A36558_UIValue.ToString();
                          num2 = (short) 19;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          num2 = (short) 23;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          num2 = (short) 16 /*0x10*/;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          this.a(ref A_0, indexA36601UiValue.ToString());
                          this.a(ref A_0, str6.ToString());
                          num2 = (short) 18;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 14;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 8;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 15:
                          goto label_9;
                        case 16 /*0x10*/:
                          if (!isRightToLeft)
                          {
                            this.a(ref A_0, str6.ToString());
                            this.a(ref A_0, indexA36601UiValue.ToString());
                            num2 = (short) 28;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 11;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 19:
                          if (!(str7 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕첗햙첛\uDD9D\uE59F\uECA1\uF0A3\uE3A5盛", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 26;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쪗펙\uDB9B횝\uF49F", A_1_1), culture);
                          num2 = (short) 10;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, str6.ToString());
                          this.a(ref A_0, indexA36601UiValue.ToString());
                          num2 = (short) 22;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 21;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, indexA36601UiValue.ToString());
                          this.a(ref A_0, str6.ToString());
                          num2 = (short) 7;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 25;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          listInnerSection = ((IAcpFeatureNode) current)[10610] as DirectionalButtonsListInnerSection;
                          int featureA36597Value = listInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597Value;
                          int indexA36601Value = listInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601Value;
                          str6 = (string) ((AcpFieldX<int, string>) listInnerSection.RadErgCtrlHeadO9DirLightBarFeature_A36597).Converter.Convert((object) featureA36597Value, (Type) null, (object) null, culture);
                          indexA36601UiValue = listInnerSection.RadErgCtrlHeadO9DirLightBarIndex_A36601_UIValue;
                          str8 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), Thread.CurrentThread.CurrentCulture);
                          str8 = RptMgrErrorHandler.b("꺑", A_1_1) + str8 + RptMgrErrorHandler.b("겑", A_1_1);
                          num2 = (short) 4;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          num2 = (short) 15;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          if (str7 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕풗\uDF99\uDA9B쪝", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 29;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 27;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (!(str7 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕쪗펙\uDB9B횝\uF49F", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uDC97펙캛\uDB9D\uE39F\uF6A1\uEDA3\uE9A5\uE6A7\uEBA9\uE0AB\uECAD\uE5AF\uE6B1\uE0B3例\uF6B7\uE9B9", A_1_1), culture);
                            num2 = (short) 13;
                            num9 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num9 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕풗\uDF99\uDA9B쪝", A_1_1), culture);
                          num2 = (short) 5;
                          num9 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 24;
                      num9 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num10 = 1;
                    while (true)
                    {
                      short num11;
                      switch (num10)
                      {
                        case 0:
                          enumerator.Dispose();
                          num11 = (short) 2;
                          num10 = (int) (IntPtr) num11;
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
                          goto label_265;
                      }
                      if (enumerator != null)
                      {
                        num11 = (short) 0;
                        num10 = (int) (IntPtr) num11;
                      }
                      else
                        break;
                    }
label_265:;
                  }
label_9:
                  table.RecSet.Add(recSet);
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  str1 = str1 + this.a + indexA41414UiValue;
                  num2 = (short) 84;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕좗\uDB99쾛힝\uF29F\uE7A1\uEAA3\uE4A5ﶧﺩ\uF8AB\uE1ADﺯ\uE1B1", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) buttonsListInnerRecset2).GetEnumerator();
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                  buttonInnerRecset3 = ((Recordset) keypadRecset)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (feature != null)
                  {
                    num2 = (short) 82;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 45;
                case 44:
                  recSet = new _RecSet();
                  A_0 = new _UIFields();
                  ++num3;
                  recSet.RecTitle = AppResources.NOPRINT_Id + num3.ToString();
                  recSet.RecNo = num3.ToString();
                  O9InnerSection o9InnerSection = ((Recordset) o9InnerRecset)[0][10627] as O9InnerSection;
                  int featureA36682Value = o9InnerSection.CHO9EmergencyButtonFeature_A36682Value;
                  string str9 = (string) ((AcpFieldX<int, string>) o9InnerSection.CHO9EmergencyButtonFeature_A36682).Converter.Convert((object) featureA36682Value, (Type) null, (object) null, culture);
                  this.a(ref A_0, str9.ToString());
                  this.a(ref A_0, str9.ToString());
                  A_0.UIFieldName = ((AcpFieldBase) o9InnerSection.CHO9EmergencyButtonName_A36680).UIName.ToString();
                  A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕힗좙\uDD9B킝\uE79F\uE7A1\uE6A3\uF3A5ﲧﺩ\uE3AB\uE0AD", A_1_1), culture);
                  recSet.UIFields.Add(A_0);
                  table.RecSet.Add(recSet);
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  keypadRecset = FeatureManager.GetFeature(4109) as KeypadRecset;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  recSet = new _RecSet();
                  ++num3;
                  recSet.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕횗\uDB99쪛힝\uE79F\uE3A1\uF0A3\uEFA5\uE7A7\uE4A9\uEFAB\uE1ADﺯ\uE6B1\uE6B3例\uF4B7\uE9B9", A_1_1), culture);
                  recSet.RecNo = num3.ToString();
                  enumerator = ((Collection<FeatureNode>) tableInnerRecset).GetEnumerator();
                  num2 = (short) 68;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  if (str1 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uD997\uD999좛힝\uEF9F\uECA1\uE7A3\uE9A5\uE6A7囹\uE3AB\uE2AD羚\uF6B1\uF5B3\uE2B5\uF1B7\uF5B9\uF2BB", A_1_1), culture))
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 84;
                case 49:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
                  {
                    num2 = (short) 85;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_363;
                case 50:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 52:
                  if (buttonsListInnerRecset2 != null)
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_464;
                case 54:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  this.a(ref A_0, str1.ToString());
                  this.a(ref A_0, str2.ToString());
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 56:
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  if (buttonInnerRecset3 != null)
                  {
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 59:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  num2 = (short) 0;
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_464;
                case 63 /*0x3F*/:
                  this.a(ref A_0, str2.ToString());
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  try
                  {
                    num2 = (short) 25;
                    int num12 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str10;
                      BottomFunctionProgrammableButtonInnerSection buttonInnerSection3;
                      string str11;
                      string str12;
                      string A_1_3;
                      string str13;
                      string A_1_4;
                      switch (num12)
                      {
                        case 0:
                        case 5:
                        case 6:
                        case 30:
                        case 31 /*0x1F*/:
                        case 35:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 16 /*0x10*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          goto label_121;
                        case 2:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꂓ즕톗ﺙ", A_1_1), culture);
                          num2 = (short) 6;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          if (str10 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕좗ꮙ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 8;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (!(str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꂓ즕톗ﺙ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 20;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          if (buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_Applicable)
                          {
                            num2 = (short) 28;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 36;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕좗ꮙ", A_1_1), culture);
                          num2 = (short) 0;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          num2 = (short) 1;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                        case 18:
                        case 29:
                          this.a(ref A_0, str11.ToString());
                          num2 = (short) 26;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                        case 21:
                        case 26:
                        case 36:
                          A_0.UIFieldName = ((AcpFieldBase) buttonInnerSection3.CHO9BottomFunctionButtonName_A36657).UIName.ToString();
                          str10 = buttonInnerSection3.CHO9BottomFunctionButtonName_A36657_UIValue.ToString();
                          num2 = (short) 3;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (!(str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꚓ즕톗ﺙ", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 14;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 34;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꆓ즕톗ﺙ", A_1_1), culture);
                          num2 = (short) 30;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꞓ즕톗ﺙ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 32 /*0x20*/;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          A_1_3 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), culture);
                          this.a(ref A_0, A_1_3);
                          num2 = (short) 29;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (A_1_3 == str12)
                          {
                            num2 = (short) 15;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString());
                          num2 = (short) 18;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          A_1_4 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), culture);
                          this.a(ref A_0, A_1_4);
                          num2 = (short) 21;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (str10 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꆓ즕톗ﺙ", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 13;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킑ﮓ\uE295\uEC97\uF599\uF19B솝\uE29F힡킣튥잧쒩\uF3AB\uE7AD\uF4AF", A_1_1), culture);
                          num2 = (short) 35;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 22:
                          this.a(ref A_0, str11.ToString());
                          num2 = (short) 7;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (!isRightToLeft)
                          {
                            num2 = (short) 22;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 37;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                          if (enumerator.MoveNext())
                          {
                            FeatureNode current = enumerator.Current;
                            A_0 = new _UIFields();
                            buttonInnerSection3 = ((IAcpFeatureNode) current)[10619] as BottomFunctionProgrammableButtonInnerSection;
                            int featureA36664Value = buttonInnerSection3.CHO9BottomFunctionButtonFeature_A36664Value;
                            str11 = (string) ((AcpFieldX<int, string>) buttonInnerSection3.CHO9BottomFunctionButtonFeature_A36664).Converter.Convert((object) featureA36664Value, (Type) null, (object) null, culture);
                            num2 = (short) 23;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 27:
                          if (A_1_4 == str13)
                          {
                            num2 = (short) 19;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString());
                          num2 = (short) 11;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          str13 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), Thread.CurrentThread.CurrentCulture);
                          str13 = RptMgrErrorHandler.b("꺑", A_1_1) + str13 + RptMgrErrorHandler.b("겑", A_1_1);
                          A_1_4 = buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString();
                          num2 = (short) 27;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꞓ즕톗ﺙ", A_1_1), culture);
                          num2 = (short) 5;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          str12 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), Thread.CurrentThread.CurrentCulture);
                          str12 = RptMgrErrorHandler.b("꺑", A_1_1) + str12 + RptMgrErrorHandler.b("겑", A_1_1);
                          A_1_3 = buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_UIValue.ToString();
                          num2 = (short) 17;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("슑ꚓ즕톗ﺙ", A_1_1), culture);
                          num2 = (short) 31 /*0x1F*/;
                          num12 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          if (!buttonInnerSection3.CHO9BottomFunctionButtonIndex_A36665_Applicable)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 10;
                            num12 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 33;
                          num12 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 24;
                      num12 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num13 = 2;
                    int num14 = (int) (IntPtr) num13;
                    while (true)
                    {
                      switch (num14)
                      {
                        case 0:
                          enumerator.Dispose();
                          num13 = (short) 1;
                          num14 = (int) (IntPtr) num13;
                          continue;
                        case 1:
                          goto label_179;
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
                        num13 = (short) 0;
                        num14 = (int) (IntPtr) num13;
                      }
                      else
                        break;
                    }
label_179:;
                  }
label_121:
                  table.RecSet.Add(recSet);
                  num2 = (short) 73;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  if (buttonInnerRecset1 != null)
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 66:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 32 /*0x20*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 72;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  if (str2 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕\uD997\uD999좛힝\uEF9F\uECA1\uE7A3\uE9A5\uE6A7囹\uE3AB\uE2AD羚\uF6B1\uF5B3\uE2B5\uF1B7\uF5B9\uF2BB", A_1_1), culture))
                  {
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 80 /*0x50*/;
                case 68:
                  try
                  {
                    num2 = (short) 13;
                    int num15 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str14;
                      O9NavigationControlsTableInnerSection tableInnerSection;
                      string str15;
                      switch (num15)
                      {
                        case 0:
                          goto label_209;
                        case 1:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗쪙\uDE9B쮝\uF49F\uF6A1\uEBA3\uE8A5", A_1_1), culture);
                          num2 = (short) 5;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          this.a(ref A_0, str14.ToString());
                          num2 = (short) 17;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          this.a(ref A_0, str14.ToString());
                          num2 = (short) 8;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횑ﮓ\uE195\uF697얙\uDE9B\uEB9D풟횡쮣좥", A_1_1), culture);
                          num2 = (short) 16 /*0x10*/;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                        case 16 /*0x10*/:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 12;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 18;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          FeatureNode current = enumerator.Current;
                          A_0 = new _UIFields();
                          tableInnerSection = ((IAcpFeatureNode) current)[10734] as O9NavigationControlsTableInnerSection;
                          int featureA41371Value = tableInnerSection.RadErgoControlO9NaviControlFeature_A41371Value;
                          str14 = (string) ((AcpFieldX<int, string>) tableInnerSection.RadErgoControlO9NaviControlFeature_A41371).Converter.Convert((object) featureA41371Value, (Type) null, (object) null, culture);
                          num2 = (short) 15;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                        case 8:
                          A_0.UIFieldName = ((AcpFieldBase) tableInnerSection.RadErgoControlO9NaviControlName_A41370).UIName.ToString();
                          str15 = tableInnerSection.RadErgoControlO9NaviControlName_A41370_UIValue.ToString();
                          num2 = (short) 19;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          num2 = (short) 20;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 3;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 11:
                          if (str15 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("횑ﮓ\uE195\uF697얙\uDE9B\uEB9D풟횡쮣좥", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 4;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 13:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 14:
                        case 17:
                          this.a(ref A_0, str14.ToString());
                          num2 = (short) 7;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (isRightToLeft)
                          {
                            num2 = (short) 9;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, str14.ToString());
                          num2 = (short) 10;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          num2 = (short) 0;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          if (str15 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗쪙\uDE9B쮝\uF49F\uF6A1\uEBA3\uE8A5", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 1;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 11;
                          num15 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          if (!((FeatureNode) trunkingSystem).Parent.HiddenStatic)
                          {
                            num2 = (short) 2;
                            num15 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 14;
                          num15 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 6;
                      num15 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num16 = 2;
                    while (true)
                    {
                      short num17;
                      switch (num16)
                      {
                        case 0:
                          enumerator.Dispose();
                          num17 = (short) 1;
                          num16 = (int) (IntPtr) num17;
                          continue;
                        case 1:
                          goto label_401;
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
                        num17 = (short) 0;
                        num16 = (int) (IntPtr) num17;
                      }
                      else
                        break;
                    }
label_401:;
                  }
label_209:
                  table.RecSet.Add(recSet);
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  if (selectorListInnerRecset != null)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 22;
                case 70:
                  str2 = str2 + this.a + indexA41416UiValue;
                  num2 = (short) 80 /*0x50*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  num2 = (short) 77;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 75:
                  try
                  {
                    num2 = (short) 7;
                    int num18 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string indexA36685UiValue;
                      string str16;
                      string str17;
                      ResponseSelectorListInnerSection listInnerSection;
                      string str18;
                      switch (num18)
                      {
                        case 0:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D醟", A_1_1), culture);
                          num2 = (short) 12;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          if (isRightToLeft)
                          {
                            num2 = (short) 39;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 20;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 3:
                          this.a(ref A_0, str17.ToString());
                          num2 = (short) 17;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          this.a(ref A_0, indexA36685UiValue.ToString());
                          num2 = (short) 9;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          num2 = (short) 45;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (indexA36685UiValue == str18)
                          {
                            num2 = (short) 27;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 5;
                        case 7:
                          switch (0)
                          {
                            case 0:
                              goto label_322;
                            default:
                              continue;
                          }
                        case 8:
                          if (enumerator.MoveNext())
                          {
                            FeatureNode current = enumerator.Current;
                            A_0 = new _UIFields();
                            listInnerSection = ((IAcpFeatureNode) current)[10625] as ResponseSelectorListInnerSection;
                            int actionA36684Value = listInnerSection.CHO9PursuitKnobAction_A36684Value;
                            int indexA36685Value = listInnerSection.CHO9PursuitKnobIndex_A36685Value;
                            str17 = (string) ((AcpFieldX<int, string>) listInnerSection.CHO9PursuitKnobAction_A36684).Converter.Convert((object) actionA36684Value, (Type) null, (object) null, culture);
                            indexA36685UiValue = listInnerSection.CHO9PursuitKnobIndex_A36685_UIValue;
                            str18 = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), Thread.CurrentThread.CurrentCulture);
                            str18 = RptMgrErrorHandler.b("꺑", A_1_1) + str18 + RptMgrErrorHandler.b("겑", A_1_1);
                            num2 = (short) 6;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 26;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                        case 11:
                        case 17:
                        case 22:
                        case 29:
                        case 46:
                          A_0.UIFieldName = ((AcpFieldBase) listInnerSection.CHO9PursuitKnobMode_A36683).UIName.ToString();
                          str16 = listInnerSection.CHO9PursuitKnobMode_A36683_UIValue.ToString();
                          num2 = (short) 23;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (str16 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D銟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 42;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 36;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                        case 16 /*0x10*/:
                        case 25:
                        case 30:
                        case 44:
                          recSet.UIFields.Add(A_0);
                          num2 = (short) 13;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D邟", A_1_1), culture);
                          num2 = (short) 25;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 15:
                          if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 19;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 9;
                        case 18:
                          goto label_11;
                        case 19:
                          num2 = (short) 1;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 20:
                          this.a(ref A_0, str17.ToString());
                          num2 = (short) 40;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          this.a(ref A_0, indexA36685UiValue.ToString());
                          num2 = (short) 29;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          if (!(str16 == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D邟", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            num2 = (short) 38;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 14;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 24:
                        case 34:
                          this.a(ref A_0, str17.ToString());
                          num2 = (short) 11;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          num2 = (short) 18;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          indexA36685UiValue = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕춗풙\uDD9B춝\uF39F\uEBA1\uE3A3\uE8A5\uEDA7\uEEA9", A_1_1), culture);
                          break;
                        case 28:
                          num2 = (short) 33;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          num2 = (short) 43;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          if (listInnerSection.CHO9PursuitKnobIndex_A36685_Applicable)
                          {
                            num2 = (short) 4;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 22;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 33:
                          if (isRightToLeft)
                          {
                            num2 = (short) -32087;
                            int num19 = (int) num2;
                            num2 = (short) -32087;
                            int num20 = (int) num2;
                            switch (num19 == num20 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                break;
                              default:
                                num2 = (short) 0;
                                if (num2 == (short) 0)
                                  ;
                                num2 = (short) 31 /*0x1F*/;
                                num18 = (int) (IntPtr) num2;
                                continue;
                            }
                          }
                          else
                          {
                            this.a(ref A_0, str17.ToString());
                            num2 = (short) 32 /*0x20*/;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 35:
                          this.a(ref A_0, indexA36685UiValue.ToString());
                          num2 = (short) 2;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          if (!(str16 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D鎟", A_1_1), Thread.CurrentThread.CurrentCulture)))
                          {
                            A_0.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D", A_1_1), culture);
                            num2 = (short) 16 /*0x10*/;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 41;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 37:
                          this.a(ref A_0, indexA36685UiValue.ToString());
                          num2 = (short) 34;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 38:
                          if (str16 == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D醟", A_1_1), Thread.CurrentThread.CurrentCulture))
                          {
                            num2 = (short) 0;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 39:
                          if (!listInnerSection.CHO9PursuitKnobIndex_A36685_Applicable)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 24;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 37;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 40:
                          if (listInnerSection.CHO9PursuitKnobIndex_A36685_Applicable)
                          {
                            num2 = (short) 21;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.a(ref A_0, "");
                          num2 = (short) 46;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 41:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D鎟", A_1_1), culture);
                          num2 = (short) 44;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 42:
                          A_0.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB91킓즕햗햙\uD89B\uDB9D銟", A_1_1), culture);
                          num2 = (short) 30;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 43:
                          if (!listInnerSection.CHO9PursuitKnobIndex_A36685_Applicable)
                          {
                            this.a(ref A_0, "");
                            num2 = (short) 3;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 35;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        case 45:
                          if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                          {
                            num2 = (short) 28;
                            num18 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 15;
                          num18 = (int) (IntPtr) num2;
                          continue;
                        default:
label_322:
                          num2 = (short) 8;
                          num18 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 5;
                      num18 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    int num21 = 2;
                    while (true)
                    {
                      short num22;
                      switch (num21)
                      {
                        case 0:
                          enumerator.Dispose();
                          num22 = (short) 1;
                          num21 = (int) (IntPtr) num22;
                          continue;
                        case 1:
                          goto label_345;
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
                        num22 = (short) 0;
                        num21 = (int) (IntPtr) num22;
                      }
                      else
                        break;
                    }
label_345:;
                  }
label_11:
                  table.RecSet.Add(recSet);
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 76:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 77:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 83;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonTrkFeature_A36526).HiddenStatic)
                  {
                    num2 = (short) 55;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_349;
                case 79:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 82:
                  selectorListInnerRecset = ((Recordset) feature)[0][10624].EmbeddedRecset as ResponseSelectorListInnerRecset;
                  buttonsListInnerRecset1 = ((Recordset) feature)[0][10609].EmbeddedRecset as DirectionalButtonsListInnerRecset;
                  o9InnerRecset = ((Recordset) feature)[0][10626].EmbeddedRecset as O9InnerRecset;
                  buttonInnerRecset1 = ((Recordset) feature)[0][10611].EmbeddedRecset as O9DataButtonInnerRecset;
                  tableInnerRecset = ((Recordset) feature)[0][10731].EmbeddedRecset as O9NavigationControlsTableInnerRecset;
                  buttonInnerRecset2 = ((Recordset) feature)[0][10618].EmbeddedRecset as BottomFunctionProgrammableButtonInnerRecset;
                  buttonsListInnerRecset2 = ((Recordset) feature)[0][10743].EmbeddedRecset as PASirenButtonsListInnerRecset;
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 83:
                  if (!((AcpFieldBase) buttonInnerSection1.RadErgCtrlHeadO9DataButtonCnvFeature_A36528).HiddenStatic)
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_349;
                case 84:
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  this.a(ref A_0, str2.ToString());
                  this.a(ref A_0, str1.ToString());
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 76;
              num1 = (int) (IntPtr) num2;
              continue;
label_349:
              num2 = (short) 74;
              num1 = (int) (IntPtr) num2;
              continue;
label_363:
              num2 = (short) 36;
              num1 = (int) (IntPtr) num2;
              continue;
label_461:
              num2 = (short) 50;
              num1 = (int) (IntPtr) num2;
            }
label_464:
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  private void a(ref _UIFields A_0, string A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 18824;
    int num2 = (int) num1;
    num1 = (short) 18824;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        A_0.values.Add(new _Value() { FieldValue = A_1 });
        break;
      default:
        goto case 1;
    }
  }

  public void AddZonesAndChannels(ref _XMLData RptXMLData)
  {
    int A_1_1 = 10;
    int num1 = 0;
    switch (num1)
    {
      default:
        _table table;
        CultureInfo culture;
        bool isRightToLeft;
        Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            table = new _table();
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            isRightToLeft = culture.TextInfo.IsRightToLeft;
            channelAssignment = FeatureManager.GetFeature(2051)[0] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
            num2 = (short) 355;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            Dictionary<int, string> A_0_1;
            int key1;
            Dictionary<int, string> A_0_2;
            int key2;
            string A_1_2;
            _UIFields A_0_3;
            Dictionary<int, string> A_0_4;
            int key3;
            int num3;
            Dictionary<int, string> A_0_5;
            int key4;
            _RecSet recSet1;
            _UIFields A_0_6;
            Dictionary<int, string> A_0_7;
            Dictionary<int, string> A_0_8;
            int num4;
            int num5;
            string A_1_3;
            Dictionary<int, string> A_0_9;
            _RecSet recSet2;
            _UIFields A_0_10;
            int num6;
            int key5;
            _UIFields A_0_11;
            Dictionary<int, string> A_0_12;
            int key6;
            Dictionary<int, string> A_0_13;
            int key7;
            Dictionary<int, string> A_0_14;
            Dictionary<int, string> A_0_15;
            Dictionary<int, string> A_0_16;
            _UIFields A_0_17;
            _RecSet recSet3;
            Dictionary<int, string> A_0_18;
            _RecSet recSet4;
            _UIFields A_0_19;
            Dictionary<int, string> A_0_20;
            Dictionary<int, string> A_0_21;
            Dictionary<int, string> A_0_22;
            Dictionary<int, string> A_0_23;
            Dictionary<int, string> A_0_24;
            int num7;
            int num8;
            string A_1_4;
            Dictionary<int, string> A_0_25;
            string A_1_5;
            Dictionary<int, string> A_0_26;
            Dictionary<int, string> A_0_27;
            Dictionary<int, string> A_0_28;
            Dictionary<int, string> A_0_29;
            Dictionary<int, string> A_0_30;
            Dictionary<int, string> A_0_31;
            Dictionary<int, string> A_0_32;
            Dictionary<int, string> A_0_33;
            Dictionary<int, string> A_0_34;
            Dictionary<int, string> A_0_35;
            int num9;
            Dictionary<int, string> A_0_36;
            int key8;
            int num10;
            string A_1_6;
            string A_1_7;
            _UIFields A_0_37;
            _RecSet recSet5;
            int num11;
            Dictionary<int, string> A_0_38;
            Dictionary<int, string> A_0_39;
            Dictionary<int, string> A_0_40;
            _RecSet recSet6;
            int num12;
            int num13;
            Dictionary<int, string> A_0_41;
            int num14;
            Dictionary<int, string> A_0_42;
            Dictionary<int, string> A_0_43;
            string A_1_8;
            string A_1_9;
            _UIFields A_0_44;
            int num15;
            _RecSet recSet7;
            _RecSet recSet8;
            int num16;
            int num17;
            int num18;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  A_0_1.TryGetValue(key1, out A_1_3);
                  this.a(ref A_0_6, A_1_3);
                  num2 = (short) 174;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                case 338:
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 169:
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 219;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                case 198:
                  num2 = (short) 64 /*0x40*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  A_0_9.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 234;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                case 75:
                  num2 = (short) 296;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                case 43:
                case 94:
                case 229:
                case 301:
                case 353:
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                case 303:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (A_0_41.Count > key8)
                  {
                    num2 = (short) 55;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_11, "");
                  num2 = (short) 175;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (((FeatureNode) channelAssignment).Parent.Count < 6)
                  {
                    num2 = (short) 334;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 115;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  A_0_36.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 233;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  if (((FeatureNode) channelAssignment).Parent.Count < 6)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                case 317:
                  A_0_44.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_44.UIFieldDes = recSet8.RecNo;
                  recSet8.UIFields.Add(A_0_44);
                  table.RecSet.Add(recSet8);
                  ++key6;
                  num2 = (short) 350;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                case 56:
                  num2 = (short) 107;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  if (((FeatureNode) channelAssignment).Parent.Count != 5)
                  {
                    num2 = (short) 299;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 131;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (A_0_40.Count > key5)
                  {
                    num2 = (short) 248;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_10, "");
                  num2 = (short) 321;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  recSet4 = new _RecSet();
                  A_0_19 = new _UIFields();
                  num7 = this.a(A_0_20, A_0_21, A_0_22, A_0_23, A_0_13, A_0_24);
                  num8 = 1;
                  A_1_4 = (string) null;
                  key7 = 0;
                  num2 = (short) 273;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                case 45:
                  num2 = (short) 228;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  num2 = (short) 165;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                case 258:
                  num2 = (short) 123;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (A_0_2.Count <= 0)
                  {
                    num2 = (short) 313;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 86;
                case 22:
                  goto label_241;
                case 23:
                  if (A_0_4.Count > key5)
                  {
                    num2 = (short) 302;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_10, "");
                  num2 = (short) 209;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  if (A_0_32.Count <= 0)
                  {
                    num2 = (short) 224 /*0xE0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 25:
                  A_0_29.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                case 163:
                  num2 = (short) 126;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  num2 = (short) 359;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                case 235:
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  if (A_0_28.Count <= key2)
                  {
                    this.a(ref A_0_3, "");
                    num2 = (short) 266;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 95;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  if (A_0_29.Count > key4)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_17, "");
                  num2 = (short) 275;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                case 168:
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                case 174:
                  num2 = (short) 323;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  goto label_372;
                case 34:
                  recSet7 = new _RecSet();
                  A_0_37 = new _UIFields();
                  num3 = this.a(A_0_33, A_0_34, A_0_18);
                  num17 = 1;
                  A_1_7 = (string) null;
                  key3 = 0;
                  num2 = (short) 100;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  if (A_0_12.Count <= 0)
                  {
                    num2 = (short) 65;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 46;
                case 36:
                  A_0_30.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  num2 = (short) 236;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                case 70:
                case 129:
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  num2 = (short) 314;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  if (key6 >= num16)
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet8 = new _RecSet();
                  A_0_44 = new _UIFields();
                  recSet8.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num18.ToString();
                  recSet8.RecNo = num18++.ToString();
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 41:
                case 136:
                  num2 = (short) 141;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  if (A_0_42.Count <= 0)
                  {
                    num2 = (short) 87;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 46;
                case 44:
                  if (A_0_18.Count > key3)
                  {
                    num2 = (short) 93;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_37, "");
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 46:
                  recSet8 = new _RecSet();
                  A_0_44 = new _UIFields();
                  num16 = this.a(A_0_12, A_0_42, A_0_43);
                  num18 = 1;
                  A_1_9 = (string) null;
                  key6 = 0;
                  num2 = (short) 221;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  num2 = (short) 232;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  A_0_32.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 98;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  num2 = (short) 288;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                case 347:
                  num2 = (short) 240 /*0xF0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                case 81:
                case 148:
                case 226:
                case 242:
                case 308:
                  num2 = (short) 138;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (A_0_43.Count > key6)
                  {
                    num2 = (short) 189;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_44, "");
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (A_0_36.Count <= key4)
                  {
                    this.a(ref A_0_17, "");
                    num2 = (short) 114;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 54:
                  if (((FeatureNode) channelAssignment).Parent.Count == 3)
                  {
                    num2 = (short) 202;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 309;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  A_0_41.TryGetValue(key8, out A_1_8);
                  this.a(ref A_0_11, A_1_8);
                  num2 = (short) 222;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                case 119:
                  num2 = (short) 196;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                case 333:
                  A_0_19.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_19.UIFieldDes = recSet4.RecNo;
                  recSet4.UIFields.Add(A_0_19);
                  table.RecSet.Add(recSet4);
                  ++key7;
                  num2 = (short) 132;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 59:
                  A_0_21.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 119;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                case 85:
                case 164:
                case 181:
                case 231:
                case (int) byte.MaxValue:
                  num2 = (short) 305;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 61:
                  if (A_0_1.Count <= 0)
                  {
                    num2 = (short) -17436;
                    int num19 = (int) num2;
                    num2 = (short) -17436;
                    int num20 = (int) num2;
                    switch (num19 == num20 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_358;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 47;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto case 103;
                case 62:
                  if (key5 < num15)
                  {
                    recSet2 = new _RecSet();
                    A_0_10 = new _UIFields();
                    recSet2.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num6.ToString();
                    recSet2.RecNo = num6++.ToString();
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 160 /*0xA0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 292;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 301;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  if (A_0_5.Count > key4)
                  {
                    num2 = (short) 133;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_17, "");
                  num2 = (short) 347;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 65:
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  if (A_0_14.Count > key5)
                  {
                    num2 = (short) 101;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_10, "");
                  num2 = (short) 286;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                case 177:
                  A_0_37.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_37.UIFieldDes = recSet7.RecNo;
                  recSet7.UIFields.Add(A_0_37);
                  table.RecSet.Add(recSet7);
                  ++key3;
                  num2 = (short) 329;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  num2 = (short) 204;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  num2 = (short) 0;
                  this.a(ref A_0_20, (short) 1);
                  this.a(ref A_0_21, (short) 2);
                  num2 = (short) 181;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  if (A_0_2.Count > key2)
                  {
                    num2 = (short) 270;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_3, "");
                  num2 = (short) 279;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  num2 = (short) 178;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 73:
                  this.a(ref A_0_38, (short) 1);
                  this.a(ref A_0_41, (short) 2);
                  num2 = (short) 218;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  this.a(ref A_0_4, (short) 1);
                  this.a(ref A_0_14, (short) 2);
                  this.a(ref A_0_15, (short) 3);
                  this.a(ref A_0_16, (short) 4);
                  this.a(ref A_0_25, (short) 5);
                  this.a(ref A_0_40, (short) 6);
                  num2 = (short) 220;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 76:
                  if (((FeatureNode) channelAssignment).Parent.Count != 4)
                  {
                    num2 = (short) 54;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 102;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                  this.a(ref A_0_20, (short) 1);
                  this.a(ref A_0_21, (short) 2);
                  this.a(ref A_0_22, (short) 3);
                  num2 = (short) byte.MaxValue;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                case 279:
                  num2 = (short) 295;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 79:
                  this.a(ref A_0_27, (short) 2);
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 81;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                case 266:
                  A_0_3.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_3.UIFieldDes = recSet6.RecNo;
                  recSet6.UIFields.Add(A_0_3);
                  table.RecSet.Add(recSet6);
                  ++key2;
                  num2 = (short) 199;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 82:
                  this.a(ref A_0_20, (short) 1);
                  this.a(ref A_0_21, (short) 2);
                  this.a(ref A_0_22, (short) 3);
                  this.a(ref A_0_23, (short) 4);
                  this.a(ref A_0_13, (short) 5);
                  this.a(ref A_0_24, (short) 6);
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 83:
                case 199:
                  num2 = (short) 342;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 84:
                  num2 = (short) 140;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 86:
                  recSet6 = new _RecSet();
                  A_0_3 = new _UIFields();
                  num12 = this.a(A_0_28, A_0_27, A_0_9, A_0_26, A_0_2, A_0_39);
                  num13 = 1;
                  A_1_2 = (string) null;
                  key2 = 0;
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 87:
                  num2 = (short) 251;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 88:
                  A_0_13.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 356;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 89:
                  A_0_7.TryGetValue(key1, out A_1_3);
                  this.a(ref A_0_6, A_1_3);
                  num2 = (short) 216;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  recSet2 = new _RecSet();
                  A_0_10 = new _UIFields();
                  num15 = this.a(A_0_4, A_0_14, A_0_15, A_0_16, A_0_25, A_0_40);
                  num6 = 1;
                  A_1_5 = (string) null;
                  key5 = 0;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 91:
                case 275:
                  num2 = (short) 283;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                case 321:
                  A_0_10.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_10.UIFieldDes = recSet2.RecNo;
                  recSet2.UIFields.Add(A_0_10);
                  table.RecSet.Add(recSet2);
                  ++key5;
                  num2 = (short) 169;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 93:
                  A_0_18.TryGetValue(key3, out A_1_7);
                  this.a(ref A_0_37, A_1_7);
                  num2 = (short) 177;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 95:
                  A_0_28.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 80 /*0x50*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  if (key3 >= num3)
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet7 = new _RecSet();
                  A_0_37 = new _UIFields();
                  recSet7.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num17.ToString();
                  recSet7.RecNo = num17++.ToString();
                  num2 = (short) 143;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                case 155:
                case 220:
                case 237:
                case 265:
                case 291:
                  num2 = (short) 306;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                case 130:
                  A_0_17.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_17.UIFieldDes = recSet3.RecNo;
                  recSet3.UIFields.Add(A_0_17);
                  table.RecSet.Add(recSet3);
                  ++key4;
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 99:
                  num2 = (short) 109;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 100:
                case 329:
                  num2 = (short) 96 /*0x60*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 101:
                  A_0_14.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 110;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 102:
                  this.a(ref A_0_4, (short) 1);
                  this.a(ref A_0_14, (short) 2);
                  this.a(ref A_0_15, (short) 3);
                  this.a(ref A_0_16, (short) 4);
                  num2 = (short) 237;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 103:
                  recSet1 = new _RecSet();
                  A_0_6 = new _UIFields();
                  num4 = this.a(A_0_7, A_0_1, A_0_8);
                  num5 = 1;
                  A_1_3 = (string) null;
                  key1 = 0;
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 104:
                  this.a(ref A_0_43, (short) 3);
                  this.a(ref A_0_42, (short) 2);
                  this.a(ref A_0_12, (short) 1);
                  num2 = (short) 129;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  if (((FeatureNode) channelAssignment).Parent.Count == 3)
                  {
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 125;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  this.a(ref A_0_4, (short) 1);
                  this.a(ref A_0_14, (short) 2);
                  this.a(ref A_0_15, (short) 3);
                  this.a(ref A_0_16, (short) 4);
                  this.a(ref A_0_25, (short) 5);
                  num2 = (short) 291;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  if (A_0_34.Count > key3)
                  {
                    num2 = (short) 344;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_37, "");
                  num2 = (short) 192 /*0xC0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  if (A_0_12.Count > key6)
                  {
                    num2 = (short) 246;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_44, "");
                  num2 = (short) 317;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 109:
                  if (A_0_18.Count > 0)
                  {
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_55;
                case 110:
                case 286:
                  num2 = (short) 311;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 111:
                  num2 = (short) 112 /*0x70*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 112 /*0x70*/:
                  if (A_0_30.Count <= 0)
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 113:
                  if (A_0_7.Count <= 0)
                  {
                    num2 = (short) 304;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 103;
                case 114:
                case 233:
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 115:
                  this.a(ref A_0_36, (short) 6);
                  this.a(ref A_0_29, (short) 5);
                  this.a(ref A_0_30, (short) 4);
                  this.a(ref A_0_31, (short) 3);
                  this.a(ref A_0_5, (short) 2);
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 229;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 116:
                  if (A_0_5.Count <= 0)
                  {
                    num2 = (short) 128 /*0x80*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 117:
                  if (((FeatureNode) channelAssignment).Parent.Count >= 6)
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 215;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 118:
                  A_0_38.TryGetValue(key8, out A_1_8);
                  this.a(ref A_0_11, A_1_8);
                  num2 = (short) 303;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 120:
                  if (A_0_33.Count <= 0)
                  {
                    num2 = (short) 348;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 34;
                case 121:
                case 244:
                  A_0_11.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_11.UIFieldDes = recSet5.RecNo;
                  recSet5.UIFields.Add(A_0_11);
                  table.RecSet.Add(recSet5);
                  ++key8;
                  num2 = (short) 208 /*0xD0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 122:
                  if (A_0_38.Count <= key8)
                  {
                    this.a(ref A_0_11, "");
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 118;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 123:
                  if (A_0_16.Count > key5)
                  {
                    num2 = (short) 149;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_10, "");
                  num2 = (short) 264;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 124:
                case 172:
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 125:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 69;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_20, (short) 1);
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 126:
                  if (key1 >= num4)
                  {
                    num2 = (short) 271;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet1 = new _RecSet();
                  A_0_6 = new _UIFields();
                  recSet1.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num5.ToString();
                  recSet1.RecNo = num5++.ToString();
                  num2 = (short) 324;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case (int) sbyte.MaxValue:
                case 216:
                  A_0_6.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_6.UIFieldDes = recSet1.RecNo;
                  recSet1.UIFields.Add(A_0_6);
                  table.RecSet.Add(recSet1);
                  ++key1;
                  num2 = (short) 163;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 128 /*0x80*/:
                  num2 = (short) 200;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 131:
                  this.a(ref A_0_20, (short) 1);
                  this.a(ref A_0_21, (short) 2);
                  this.a(ref A_0_22, (short) 3);
                  this.a(ref A_0_23, (short) 4);
                  this.a(ref A_0_13, (short) 5);
                  num2 = (short) 164;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 132:
                case 273:
                  num2 = (short) 225;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 133:
                  A_0_5.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 134:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_38, (short) 1);
                  num2 = (short) 207;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 135:
                  if (A_0_20.Count <= key7)
                  {
                    this.a(ref A_0_19, "");
                    num2 = (short) 195;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 357;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 137:
                  if (key8 >= num10)
                  {
                    num2 = (short) 339;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet5 = new _RecSet();
                  A_0_11 = new _UIFields();
                  recSet5.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num11.ToString();
                  recSet5.RecNo = num11++.ToString();
                  num2 = (short) 122;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 138:
                  if (A_0_28.Count <= 0)
                  {
                    num2 = (short) 206;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 86;
                case 139:
                case 356:
                  num2 = (short) 249;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 140:
                  if (!isRightToLeft)
                  {
                    table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꆔ좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꂔ좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꎔ좖킘\uDF9A", A_1_1), culture));
                    A_0_4 = new Dictionary<int, string>();
                    A_0_14 = new Dictionary<int, string>();
                    A_0_15 = new Dictionary<int, string>();
                    A_0_16 = new Dictionary<int, string>();
                    A_0_25 = new Dictionary<int, string>();
                    A_0_40 = new Dictionary<int, string>();
                    num2 = (short) 326;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 259;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 141:
                  if (key4 >= num9)
                  {
                    num2 = (short) 297;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet3 = new _RecSet();
                  A_0_17 = new _UIFields();
                  recSet3.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num14.ToString();
                  recSet3.RecNo = num14++.ToString();
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 142:
                  A_0_23.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 269;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 143:
                  if (A_0_33.Count <= key3)
                  {
                    this.a(ref A_0_37, "");
                    num2 = (short) 56;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 203;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 144 /*0x90*/:
                  if (A_0_35.Count <= key8)
                  {
                    this.a(ref A_0_11, "");
                    num2 = (short) 121;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 256 /*0x0100*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 145:
                case 179:
                case 267:
                  num2 = (short) 120;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 146:
                  this.a(ref A_0_8, (short) 3);
                  this.a(ref A_0_1, (short) 2);
                  this.a(ref A_0_7, (short) 1);
                  num2 = (short) 346;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 147:
                case 307:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 360;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 149:
                  A_0_16.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 280;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 150:
                case 209:
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 151:
                  goto label_242;
                case 152:
                  A_0_24.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 153:
                  if (A_0_9.Count > key2)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_3, "");
                  num2 = (short) 245;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 154:
                  recSet3 = new _RecSet();
                  A_0_17 = new _UIFields();
                  num9 = this.a(A_0_32, A_0_5, A_0_31, A_0_30, A_0_29, A_0_36);
                  num14 = 1;
                  A_1_6 = (string) null;
                  key4 = 0;
                  num2 = (short) 136;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 156:
                  if (A_0_36.Count > 0)
                  {
                    num2 = (short) 154;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_492;
                case 157:
                  A_0_15.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 158:
                  if (A_0_31.Count <= key4)
                  {
                    this.a(ref A_0_17, "");
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 354;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 159:
                  goto label_499;
                case 160 /*0xA0*/:
                  goto label_382;
                case 161:
                case 195:
                  num2 = (short) 260;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 162:
                  this.a(ref A_0_30, (short) 4);
                  this.a(ref A_0_31, (short) 3);
                  this.a(ref A_0_5, (short) 2);
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 165:
                  if (A_0_22.Count <= 0)
                  {
                    num2 = (short) 185;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 166:
                  if (A_0_39.Count > 0)
                  {
                    num2 = (short) 86;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_468;
                case 167:
                  A_0_27.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 168;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 170:
                  this.a(ref A_0_39, (short) 6);
                  this.a(ref A_0_2, (short) 5);
                  this.a(ref A_0_26, (short) 4);
                  this.a(ref A_0_9, (short) 3);
                  this.a(ref A_0_27, (short) 2);
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 308;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 171:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  A_0_38 = new Dictionary<int, string>();
                  A_0_41 = new Dictionary<int, string>();
                  A_0_35 = new Dictionary<int, string>();
                  num2 = (short) 327;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 173:
                  if (A_0_25.Count > key5)
                  {
                    num2 = (short) 253;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_10, "");
                  num2 = (short) 190;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 175:
                case 222:
                  num2 = (short) 144 /*0x90*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 176 /*0xB0*/:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 241;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꎔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꂔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꆔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  A_0_28 = new Dictionary<int, string>();
                  A_0_27 = new Dictionary<int, string>();
                  A_0_9 = new Dictionary<int, string>();
                  A_0_26 = new Dictionary<int, string>();
                  A_0_2 = new Dictionary<int, string>();
                  A_0_39 = new Dictionary<int, string>();
                  num2 = (short) 117;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 178:
                  if (Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 176 /*0xB0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 84;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 180:
                  A_0_8.TryGetValue(key1, out A_1_3);
                  this.a(ref A_0_6, A_1_3);
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 182:
                  A_0_42.TryGetValue(key6, out A_1_9);
                  this.a(ref A_0_44, A_1_9);
                  num2 = (short) 124;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 183:
                  if (A_0_26.Count <= 0)
                  {
                    num2 = (short) 193;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 86;
                case 184:
                  if (((FeatureNode) channelAssignment).Parent.Count == 3)
                  {
                    num2 = (short) 239;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 318;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 185:
                  num2 = (short) 197;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 186:
                  if (A_0_14.Count <= 0)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 90;
                case 187:
                  this.a(ref A_0_26, (short) 4);
                  this.a(ref A_0_9, (short) 3);
                  this.a(ref A_0_27, (short) 2);
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 188:
                  num2 = (short) 186;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 189:
                  A_0_43.TryGetValue(key6, out A_1_9);
                  this.a(ref A_0_44, A_1_9);
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 190:
                case 325:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 191:
                  if (A_0_34.Count <= 0)
                  {
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 34;
                case 192 /*0xC0*/:
                case 211:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 193:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 194:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 230;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_33, (short) 1);
                  num2 = (short) 267;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 196:
                  if (A_0_22.Count > key7)
                  {
                    num2 = (short) 214;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_19, "");
                  num2 = (short) 147;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 197:
                  if (A_0_23.Count <= 0)
                  {
                    num2 = (short) 332;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 200:
                  if (A_0_31.Count <= 0)
                  {
                    num2 = (short) 111;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 201:
                  if (((FeatureNode) channelAssignment).Parent.Count != 2)
                  {
                    this.a(ref A_0_12, (short) 1);
                    num2 = (short) 70;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 287;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 202:
                  this.a(ref A_0_4, (short) 1);
                  this.a(ref A_0_14, (short) 2);
                  this.a(ref A_0_15, (short) 3);
                  num2 = (short) 265;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 203:
                  A_0_33.TryGetValue(key3, out A_1_7);
                  this.a(ref A_0_37, A_1_7);
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 204:
                  if (A_0_21.Count <= 0)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 205:
                  this.a(ref A_0_2, (short) 5);
                  this.a(ref A_0_26, (short) 4);
                  this.a(ref A_0_9, (short) 3);
                  this.a(ref A_0_27, (short) 2);
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 148;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 206:
                  num2 = (short) 316;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 207:
                case 218:
                case 227:
                  num2 = (short) 254;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 208 /*0xD0*/:
                case 358:
                  num2 = (short) 137;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 210:
                  num2 = (short) 257;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 212:
                  if (A_0_35.Count > 0)
                  {
                    num2 = (short) 300;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_311;
                case 213:
                  this.a(ref A_0_33, (short) 1);
                  this.a(ref A_0_34, (short) 2);
                  this.a(ref A_0_18, (short) 3);
                  num2 = (short) 145;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 214:
                  A_0_22.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 307;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 215:
                  if (((FeatureNode) channelAssignment).Parent.Count == 5)
                  {
                    num2 = (short) 205;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 281;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 217:
                  this.a(ref A_0_4, (short) 1);
                  this.a(ref A_0_14, (short) 2);
                  num2 = (short) 97;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 219:
                  if (A_0_15.Count <= 0)
                  {
                    num2 = (short) 276;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 90;
                case 221:
                case 350:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 223:
                  if (((FeatureNode) channelAssignment).Parent.Count == 4)
                  {
                    num2 = (short) 162;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 238;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 224 /*0xE0*/:
                  num2 = (short) 116;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 225:
                  if (key7 >= num7)
                  {
                    num2 = (short) 151;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet4 = new _RecSet();
                  A_0_19 = new _UIFields();
                  recSet4.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num8.ToString();
                  recSet4.RecNo = num8++.ToString();
                  num2 = (short) 135;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 228:
                  if (A_0_1.Count > key1)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_6, "");
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 230:
                  this.a(ref A_0_33, (short) 1);
                  this.a(ref A_0_34, (short) 2);
                  num2 = (short) 179;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 232:
                  if (A_0_8.Count > 0)
                  {
                    num2 = (short) 103;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_192;
                case 234:
                case 245:
                  num2 = (short) 285;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 236:
                  if (A_0_9.Count <= 0)
                  {
                    num2 = (short) 340;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 86;
                case 238:
                  if (((FeatureNode) channelAssignment).Parent.Count != 3)
                  {
                    num2 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 336;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 239:
                  this.a(ref A_0_9, (short) 3);
                  this.a(ref A_0_27, (short) 2);
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 242;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 240 /*0xF0*/:
                  if (A_0_32.Count > key4)
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_17, "");
                  num2 = (short) 130;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 241:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꆔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꂔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꎔ좖킘\uDF9A", A_1_1), culture));
                  A_0_20 = new Dictionary<int, string>();
                  A_0_21 = new Dictionary<int, string>();
                  A_0_22 = new Dictionary<int, string>();
                  A_0_23 = new Dictionary<int, string>();
                  A_0_13 = new Dictionary<int, string>();
                  A_0_24 = new Dictionary<int, string>();
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 243:
                case 268:
                case 346:
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 246:
                  A_0_12.TryGetValue(key6, out A_1_9);
                  this.a(ref A_0_44, A_1_9);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 247:
                  if (((FeatureNode) channelAssignment).Parent.Count >= 3)
                  {
                    num2 = (short) 213;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 194;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 248:
                  A_0_40.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 92;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 249:
                  if (A_0_24.Count <= key7)
                  {
                    this.a(ref A_0_19, "");
                    num2 = (short) 333;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 152;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 250:
                  if (A_0_13.Count <= 0)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 251:
                  if (A_0_43.Count > 0)
                  {
                    num2 = (short) 46;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  _RecSet recSet9 = new _RecSet();
                  _UIFields A_0_45 = new _UIFields();
                  int num21 = 0;
                  recSet9.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num21.ToString();
                  _RecSet recSet10 = recSet9;
                  int num22 = num21;
                  int num23 = num22 + 1;
                  string str1 = num22.ToString();
                  recSet10.RecNo = str1;
                  this.a(ref A_0_45, "");
                  this.a(ref A_0_45, "");
                  this.a(ref A_0_45, "");
                  A_0_45.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
                  A_0_45.UIFieldDes = recSet9.RecNo;
                  recSet9.UIFields.Add(A_0_45);
                  table.RecSet.Add(recSet9);
                  RptXMLData.tables.Add(table);
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 252:
                  num2 = (short) 156;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 253:
                  A_0_25.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 325;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 254:
                  if (A_0_38.Count <= 0)
                  {
                    num2 = (short) 352;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 300;
                case 256 /*0x0100*/:
                  A_0_35.TryGetValue(key8, out A_1_8);
                  this.a(ref A_0_11, A_1_8);
                  num2 = (short) 244;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 257:
                  if (((FeatureNode) channelAssignment).Parent.Count != 5)
                  {
                    num2 = (short) 337;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 72;
                case 259:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꎔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꂔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꆔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  A_0_32 = new Dictionary<int, string>();
                  A_0_5 = new Dictionary<int, string>();
                  A_0_31 = new Dictionary<int, string>();
                  A_0_30 = new Dictionary<int, string>();
                  A_0_29 = new Dictionary<int, string>();
                  A_0_36 = new Dictionary<int, string>();
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 260:
                  if (A_0_21.Count > key7)
                  {
                    num2 = (short) 59;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_19, "");
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 261:
                  num2 = (short) 277;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 262:
label_358:
                  if (A_0_39.Count <= key2)
                  {
                    this.a(ref A_0_3, "");
                    num2 = (short) 235;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 293;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 263:
                  this.a(ref A_0_38, (short) 1);
                  this.a(ref A_0_41, (short) 2);
                  this.a(ref A_0_35, (short) 3);
                  num2 = (short) 227;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 264:
                case 280:
                  num2 = (short) 173;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 269:
                case 274:
                  num2 = (short) 328;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 270:
                  A_0_2.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 271:
                  goto label_411;
                case 272:
                  if (A_0_41.Count <= 0)
                  {
                    num2 = (short) 319;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 300;
                case 276:
                  num2 = (short) 351;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 277:
                  if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 312;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 278:
                  if (A_0_25.Count <= 0)
                  {
                    num2 = (short) 320;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 90;
                case 281:
                  if (((FeatureNode) channelAssignment).Parent.Count != 4)
                  {
                    num2 = (short) 184;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 187;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 282:
                  if (((FeatureNode) channelAssignment).Parent.Count == 4)
                  {
                    num2 = (short) 72;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 310;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 283:
                  if (A_0_30.Count <= key4)
                  {
                    this.a(ref A_0_17, "");
                    num2 = (short) 338;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 284:
                  this.a(ref A_0_1, (short) 2);
                  this.a(ref A_0_7, (short) 1);
                  num2 = (short) 268;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 285:
                  if (A_0_27.Count > key2)
                  {
                    num2 = (short) 167;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_3, "");
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 287:
                  this.a(ref A_0_42, (short) 2);
                  this.a(ref A_0_12, (short) 1);
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 288:
                  if (A_0_29.Count <= 0)
                  {
                    num2 = (short) 252;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 289:
                  if (A_0_40.Count > 0)
                  {
                    num2 = (short) 90;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_280;
                case 290:
                  if (((FeatureNode) channelAssignment).Parent.Count < 3)
                  {
                    num2 = (short) 341;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 146;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 292:
                  this.a(ref A_0_5, (short) 2);
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 353;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 293:
                  A_0_39.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 294:
                  goto label_157;
                case 295:
                  if (A_0_26.Count <= key2)
                  {
                    this.a(ref A_0_3, "");
                    num2 = (short) 349;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 315;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 296:
                  if (A_0_42.Count > key6)
                  {
                    num2 = (short) 182;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_44, "");
                  num2 = (short) 172;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 297:
                  goto label_89;
                case 298:
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  A_0_7 = new Dictionary<int, string>();
                  A_0_1 = new Dictionary<int, string>();
                  A_0_8 = new Dictionary<int, string>();
                  num2 = (short) 290;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 299:
                  if (((FeatureNode) channelAssignment).Parent.Count != 4)
                  {
                    num2 = (short) 105;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 330;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 300:
                  recSet5 = new _RecSet();
                  A_0_11 = new _UIFields();
                  num10 = this.a(A_0_38, A_0_41, A_0_35);
                  num11 = 1;
                  A_1_8 = (string) null;
                  key8 = 0;
                  num2 = (short) 358;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 302:
                  A_0_4.TryGetValue(key5, out A_1_5);
                  this.a(ref A_0_10, A_1_5);
                  num2 = (short) 150;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 304:
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 305:
                  if (A_0_20.Count <= 0)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 306:
                  if (A_0_4.Count <= 0)
                  {
                    num2 = (short) 188;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 90;
                case 309:
                  if (((FeatureNode) channelAssignment).Parent.Count != 2)
                  {
                    this.a(ref A_0_4, (short) 1);
                    num2 = (short) 155;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 217;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 310:
                  if (((FeatureNode) channelAssignment).Parent.Count <= 3)
                  {
                    num2 = (short) 261;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_501;
                case 311:
                  if (A_0_15.Count <= key5)
                  {
                    this.a(ref A_0_10, "");
                    num2 = (short) 258;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 157;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 312:
                  if (!isRightToLeft)
                  {
                    num2 = (short) 171;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                  table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                  A_0_12 = new Dictionary<int, string>();
                  A_0_42 = new Dictionary<int, string>();
                  A_0_43 = new Dictionary<int, string>();
                  num2 = (short) 345;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 313:
                  num2 = (short) 166;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 314:
                  if (!isRightToLeft)
                  {
                    table.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692\uE694좖\uF898\uF59A列삞\uE2A0쮢쒤즦잨캪솬\uDCAE", A_1_1), culture);
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598\uE89A슜횞얠", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692꒔좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692ꞔ좖킘\uDF9A", A_1_1), culture));
                    table.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힌\uE08Eﾐ\uF692Ꚕ좖킘\uDF9A", A_1_1), culture));
                    A_0_33 = new Dictionary<int, string>();
                    A_0_34 = new Dictionary<int, string>();
                    A_0_18 = new Dictionary<int, string>();
                    num2 = (short) 247;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 298;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 315:
                  A_0_26.TryGetValue(key2, out A_1_2);
                  this.a(ref A_0_3, A_1_2);
                  num2 = (short) 335;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 316:
                  if (A_0_27.Count <= 0)
                  {
                    num2 = (short) 37;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 86;
                case 318:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_28, (short) 1);
                  num2 = (short) 226;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 319:
                  num2 = (short) 212;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 320:
                  num2 = (short) 289;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 322:
                  this.a(ref A_0_29, (short) 5);
                  this.a(ref A_0_30, (short) 4);
                  this.a(ref A_0_31, (short) 3);
                  this.a(ref A_0_5, (short) 2);
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 323:
                  if (A_0_7.Count > key1)
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_6, "");
                  num2 = (short) sbyte.MaxValue;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 324:
                  if (A_0_8.Count > key1)
                  {
                    num2 = (short) 180;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_6, "");
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 326:
                  if (((FeatureNode) channelAssignment).Parent.Count < 6)
                  {
                    num2 = (short) 331;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 74;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 327:
                  if (((FeatureNode) channelAssignment).Parent.Count < 3)
                  {
                    num2 = (short) 134;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 263;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 328:
                  if (A_0_13.Count > key7)
                  {
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_19, "");
                  num2 = (short) 139;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 330:
                  this.a(ref A_0_20, (short) 1);
                  this.a(ref A_0_21, (short) 2);
                  this.a(ref A_0_22, (short) 3);
                  this.a(ref A_0_23, (short) 4);
                  num2 = (short) 231;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 331:
                  if (((FeatureNode) channelAssignment).Parent.Count == 5)
                  {
                    num2 = (short) 106;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 76;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 332:
                  num2 = (short) 250;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 334:
                  if (((FeatureNode) channelAssignment).Parent.Count != 5)
                  {
                    num2 = (short) 223;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 322;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 335:
                case 349:
                  num2 = (short) 153;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 336:
                  this.a(ref A_0_31, (short) 3);
                  this.a(ref A_0_5, (short) 2);
                  this.a(ref A_0_32, (short) 1);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 337:
                  num2 = (short) 282;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 339:
                  goto label_18;
                case 340:
                  num2 = (short) 183;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 341:
                  if (((FeatureNode) channelAssignment).Parent.Count == 2)
                  {
                    num2 = (short) 284;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref A_0_7, (short) 1);
                  num2 = (short) 243;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 342:
                  if (key2 < num12)
                  {
                    recSet6 = new _RecSet();
                    A_0_3 = new _UIFields();
                    recSet6.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num13.ToString();
                    recSet6.RecNo = num13++.ToString();
                    num2 = (short) 262;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 294;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 343:
                  num2 = (short) 278;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 344:
                  A_0_34.TryGetValue(key3, out A_1_7);
                  this.a(ref A_0_37, A_1_7);
                  num2 = (short) 211;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 345:
                  if (((FeatureNode) channelAssignment).Parent.Count >= 3)
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 201;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 348:
                  num2 = (short) 191;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 351:
                  if (A_0_16.Count <= 0)
                  {
                    num2 = (short) 343;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 90;
                case 352:
                  num2 = (short) 272;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 354:
                  A_0_31.TryGetValue(key4, out A_1_6);
                  this.a(ref A_0_17, A_1_6);
                  num2 = (short) 198;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 355:
                  if (((FeatureNode) channelAssignment).Parent.Count < 6)
                  {
                    num2 = (short) 210;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 72;
                case 357:
                  A_0_20.TryGetValue(key7, out A_1_4);
                  this.a(ref A_0_19, A_1_4);
                  num2 = (short) 161;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 359:
                  if (A_0_24.Count > 0)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_371;
                case 360:
                  if (A_0_23.Count <= key7)
                  {
                    this.a(ref A_0_19, "");
                    num2 = (short) 274;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 142;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_499:
            return;
label_18:
            RptXMLData.tables.Add(table);
            return;
label_55:
            _RecSet recSet11 = new _RecSet();
            _UIFields A_0_46 = new _UIFields();
            int num24 = 0;
            recSet11.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num24.ToString();
            _RecSet recSet12 = recSet11;
            int num25 = num24;
            int num26 = num25 + 1;
            string str2 = num25.ToString();
            recSet12.RecNo = str2;
            this.a(ref A_0_46, "");
            this.a(ref A_0_46, "");
            this.a(ref A_0_46, "");
            A_0_46.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_46.UIFieldDes = recSet11.RecNo;
            recSet11.UIFields.Add(A_0_46);
            table.RecSet.Add(recSet11);
            RptXMLData.tables.Add(table);
            return;
label_89:
            RptXMLData.tables.Add(table);
            return;
label_157:
            RptXMLData.tables.Add(table);
            return;
label_192:
            _RecSet recSet13 = new _RecSet();
            _UIFields A_0_47 = new _UIFields();
            int num27 = 0;
            recSet13.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num27.ToString();
            _RecSet recSet14 = recSet13;
            int num28 = num27;
            int num29 = num28 + 1;
            string str3 = num28.ToString();
            recSet14.RecNo = str3;
            this.a(ref A_0_47, "");
            this.a(ref A_0_47, "");
            this.a(ref A_0_47, "");
            A_0_47.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_47.UIFieldDes = recSet13.RecNo;
            recSet13.UIFields.Add(A_0_47);
            table.RecSet.Add(recSet13);
            RptXMLData.tables.Add(table);
            return;
label_241:
            RptXMLData.tables.Add(table);
            return;
label_242:
            RptXMLData.tables.Add(table);
            return;
label_280:
            _RecSet recSet15 = new _RecSet();
            _UIFields A_0_48 = new _UIFields();
            int num30 = 0;
            recSet15.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num30.ToString();
            _RecSet recSet16 = recSet15;
            int num31 = num30;
            int num32 = num31 + 1;
            string str4 = num31.ToString();
            recSet16.RecNo = str4;
            this.a(ref A_0_48, "");
            this.a(ref A_0_48, "");
            this.a(ref A_0_48, "");
            this.a(ref A_0_48, "");
            this.a(ref A_0_48, "");
            this.a(ref A_0_48, "");
            A_0_48.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_48.UIFieldDes = recSet15.RecNo;
            recSet15.UIFields.Add(A_0_48);
            table.RecSet.Add(recSet15);
            RptXMLData.tables.Add(table);
            return;
label_311:
            _RecSet recSet17 = new _RecSet();
            _UIFields A_0_49 = new _UIFields();
            int num33 = 0;
            recSet17.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num33.ToString();
            _RecSet recSet18 = recSet17;
            int num34 = num33;
            int num35 = num34 + 1;
            string str5 = num34.ToString();
            recSet18.RecNo = str5;
            this.a(ref A_0_49, "");
            this.a(ref A_0_49, "");
            this.a(ref A_0_49, "");
            A_0_49.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_49.UIFieldDes = recSet17.RecNo;
            recSet17.UIFields.Add(A_0_49);
            table.RecSet.Add(recSet17);
            RptXMLData.tables.Add(table);
            return;
label_371:
            _RecSet recSet19 = new _RecSet();
            _UIFields A_0_50 = new _UIFields();
            int num36 = 0;
            recSet19.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num36.ToString();
            _RecSet recSet20 = recSet19;
            int num37 = num36;
            int num38 = num37 + 1;
            string str6 = num37.ToString();
            recSet20.RecNo = str6;
            this.a(ref A_0_50, "");
            this.a(ref A_0_50, "");
            this.a(ref A_0_50, "");
            this.a(ref A_0_50, "");
            this.a(ref A_0_50, "");
            this.a(ref A_0_50, "");
            A_0_50.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_50.UIFieldDes = recSet19.RecNo;
            recSet19.UIFields.Add(A_0_50);
            table.RecSet.Add(recSet19);
            RptXMLData.tables.Add(table);
            return;
label_372:
            RptXMLData.tables.Add(table);
            return;
label_382:
            RptXMLData.tables.Add(table);
            return;
label_411:
            RptXMLData.tables.Add(table);
            return;
label_501:
            return;
label_468:
            _RecSet recSet21 = new _RecSet();
            _UIFields A_0_51 = new _UIFields();
            int num39 = 0;
            recSet21.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num39.ToString();
            _RecSet recSet22 = recSet21;
            int num40 = num39;
            int num41 = num40 + 1;
            string str7 = num40.ToString();
            recSet22.RecNo = str7;
            this.a(ref A_0_51, "");
            this.a(ref A_0_51, "");
            this.a(ref A_0_51, "");
            this.a(ref A_0_51, "");
            this.a(ref A_0_51, "");
            this.a(ref A_0_51, "");
            A_0_51.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_51.UIFieldDes = recSet21.RecNo;
            recSet21.UIFields.Add(A_0_51);
            table.RecSet.Add(recSet21);
            RptXMLData.tables.Add(table);
            return;
label_492:
            _RecSet recSet23 = new _RecSet();
            _UIFields A_0_52 = new _UIFields();
            int num42 = 0;
            recSet23.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쎌\uE08Eﾐ\uF692쪔\uDE96ﶘ", A_1_1), culture) + num42.ToString();
            _RecSet recSet24 = recSet23;
            int num43 = num42;
            int num44 = num43 + 1;
            string str8 = num43.ToString();
            recSet24.RecNo = str8;
            this.a(ref A_0_52, "");
            this.a(ref A_0_52, "");
            this.a(ref A_0_52, "");
            this.a(ref A_0_52, "");
            this.a(ref A_0_52, "");
            this.a(ref A_0_52, "");
            A_0_52.UIFieldName = RptMgrErrorHandler.b("캌\uE78E\uF090ﶒﮔ\uF296\uF598햚ﲜ\uF29E쒠", A_1_1);
            A_0_52.UIFieldDes = recSet23.RecNo;
            recSet23.UIFields.Add(A_0_52);
            table.RecSet.Add(recSet23);
            RptXMLData.tables.Add(table);
            return;
        }
    }
  }

  private void a(ref Dictionary<int, string> A_0, short A_1)
  {
    int num1;
    Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        channelAssignment = FeatureManager.GetFeature(2051)[(int) A_1 - 1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        int key;
        ChannelAssignmentListInner assignmentListInner;
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (key < ((FeatureSection) channelAssignment.Channels).EmbeddedRecset.Count)
              {
                assignmentListInner = (ChannelAssignmentListInner) ((FeatureSection) channelAssignment.Channels).EmbeddedRecset[key];
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              ++key;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (assignmentListInner != null)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 1;
            case 3:
            case 10:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              goto label_14;
            case 5:
              if (channelAssignment != null)
              {
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 6:
              if (channelAssignment.Zone.ZnChanCfgZoneDynamicZoneEnable_A41257.Value)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              assignmentListInner = (ChannelAssignmentListInner) null;
              key = 0;
              num2 = (short) -1997;
              int num3 = (int) num2;
              num2 = (short) -1997;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                  goto label_24;
                case 2:
                  goto label_20;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 8:
              if (((FeatureSection) channelAssignment.Channels).HasEmbeddedRecset)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_18;
            case 9:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              goto label_28;
            case 12:
              A_0.Add(key, assignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelName_A7659Value);
              assignmentListInner = (ChannelAssignmentListInner) null;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_28:
        break;
label_10:
        break;
label_14:
        num2 = (short) 0;
        break;
label_24:
        break;
label_20:
        break;
label_18:
        break;
    }
  }

  private int a(
    Dictionary<int, string> A_0,
    Dictionary<int, string> A_1,
    Dictionary<int, string> A_2)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -16431;
    int num2 = (int) num1;
    num1 = (short) -16431;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        return Math.Max(Math.Max(A_0.Count, A_1.Count), A_2.Count);
      default:
        goto case 1;
    }
  }

  private int a(
    Dictionary<int, string> A_0,
    Dictionary<int, string> A_1,
    Dictionary<int, string> A_2,
    Dictionary<int, string> A_3,
    Dictionary<int, string> A_4,
    Dictionary<int, string> A_5)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) -5050;
    int num2 = (int) num1;
    num1 = (short) -5050;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        return Math.Max(Math.Max(Math.Max(Math.Max(Math.Max(A_0.Count, A_1.Count), A_2.Count), A_3.Count), A_4.Count), A_5.Count);
      default:
        goto case 1;
    }
  }
}
