// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.BaseHandOutXMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using Motorola.MackinawCPS.CoreFeatures.Keypad;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class BaseHandOutXMLCoreEngine : AcpBaseXMLCoreEngine
{
  protected Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem refTrunking
  {
    get
    {
      short num1 = 12789;
      int num2 = (int) num1;
      num1 = (short) 12789;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.a;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 3993;
      int num2 = (int) num1;
      num1 = (short) 3993;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private KeypadRecset recsetKeypad
  {
    get
    {
      short num1 = 10611;
      int num2 = (int) num1;
      num1 = (short) 10611;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.b;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 27183;
      int num2 = (int) num1;
      num1 = (short) 27183;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  private KeypadButtonInnerRecset keypadButton
  {
    get
    {
      short num1 = -25559;
      int num2 = (int) num1;
      num1 = (short) -25559;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          return this.c;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = 919;
      int num2 = (int) num1;
      num1 = (short) 919;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  protected int count
  {
    get
    {
      short num1 = -9674;
      int num2 = (int) num1;
      num1 = (short) -9674;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.d;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
    set
    {
      short num1 = -2393;
      int num2 = (int) num1;
      num1 = (short) -2393;
      int num3 = (int) num1;
      short num4;
      switch (num2 == num3)
      {
        case true:
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          this.d = value;
          break;
        default:
          num4 = (short) 0;
          goto case 1;
      }
    }
  }

  public BaseHandOutXMLCoreEngine()
  {
    this.refTrunking = FeatureManager.GetFeature(2064)[0] as Motorola.MackinawCPS.CoreFeatures.TrunkingSystem.TrunkingSystem;
    this.recsetKeypad = FeatureManager.GetFeature(4109) as KeypadRecset;
    if (this.recsetKeypad != null)
      this.keypadButton = ((Recordset) this.recsetKeypad)[0][10710].EmbeddedRecset as KeypadButtonInnerRecset;
    this.count = 0;
  }

  protected void AddFieldValue(ref _UIFields rptFields, string fieldValue)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    num1 = (short) -5731;
    int num2 = (int) num1;
    num1 = (short) -5731;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        rptFields.values.Add(new _Value()
        {
          FieldValue = fieldValue
        });
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void AddUiFieldDescByCondition(
    ref _UIFields rptFields,
    string uiName,
    string conditionName,
    string descValue)
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          goto label_6;
        case 1:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            goto label_5;
          goto label_5;
        case 3:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 4:
          if (!(uiName == conditionName))
          {
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_5;
        case 5:
          num2 = (short) 17067;
          int num3 = (int) num2;
          num2 = (short) 17067;
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
              if (conditionName == null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
          }
          break;
        case 6:
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (!string.IsNullOrEmpty(rptFields.UIFieldDes))
            goto label_17;
          break;
      }
      num2 = (short) 0;
      num2 = (short) 1;
      num1 = (int) (IntPtr) num2;
      continue;
label_5:
      rptFields.UIFieldDes = descValue;
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
    }
label_6:
    return;
label_17:
    return;
label_13:;
  }

  protected virtual void AddMultiValueByRTL(
    bool? condition1,
    bool? condition2,
    string value1,
    string value2,
    ref _UIFields rptField)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    int num2;
    string fieldValue1;
    string fieldValue2;
    switch (0)
    {
      case 0:
label_3:
        fieldValue1 = value1;
        fieldValue2 = value2;
        num1 = (short) 5;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          string str1;
          string str2;
          switch (num2)
          {
            case 0:
              if (Convert.ToBoolean((object) condition2))
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 0;
              num1 = (short) -735;
              int num3 = (int) num1;
              num1 = (short) -735;
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
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 1:
              num1 = (short) 7;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              str1 = value2;
              break;
            case 3:
              if (!Convert.ToBoolean((object) condition1))
              {
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 9;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              if (condition2.HasValue)
              {
                num1 = (short) 11;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 13;
            case 5:
              if (condition1.HasValue)
              {
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 10;
            case 6:
              num1 = (short) 15;
              num2 = (int) (IntPtr) num1;
              continue;
            case 7:
              str2 = string.Empty;
              goto label_30;
            case 8:
              if (this.isRTL)
              {
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_31;
            case 9:
              str2 = value1;
              goto label_30;
            case 10:
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            case 11:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 12:
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 13:
label_15:
              num1 = (short) 8;
              num2 = (int) (IntPtr) num1;
              continue;
            case 14:
              goto label_22;
            case 15:
              str1 = string.Empty;
              break;
            default:
              goto label_3;
          }
          fieldValue2 = str1;
          num1 = (short) 13;
          num2 = (int) (IntPtr) num1;
          continue;
label_30:
          fieldValue1 = str2;
          num1 = (short) 10;
          num2 = (int) (IntPtr) num1;
        }
label_22:
        this.AddFieldValue(ref rptField, fieldValue1);
        this.AddFieldValue(ref rptField, fieldValue2);
        break;
label_31:
        this.AddFieldValue(ref rptField, fieldValue2);
        this.AddFieldValue(ref rptField, fieldValue1);
        break;
    }
  }

  protected virtual void AddMultiValueByRTL(
    bool? condition1,
    bool? condition2,
    bool? condition3,
    bool? condition4,
    string value1,
    string value2,
    string value3,
    string value4,
    ref _UIFields rptField)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        string fieldValue1;
        string fieldValue2;
        string fieldValue3;
        string fieldValue4;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            fieldValue1 = value1;
            fieldValue2 = value2;
            fieldValue3 = value3;
            fieldValue4 = value4;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string str1;
              string str2;
              string str3;
              string str4;
              switch (num1)
              {
                case 0:
                  str1 = value1;
                  goto label_40;
                case 1:
                  str2 = value4;
                  goto label_32;
                case 2:
                  if (condition1.HasValue)
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 3:
                  if (Convert.ToBoolean((object) condition4))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (this.isRTL)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_55;
                case 5:
                  str1 = string.Empty;
                  goto label_40;
                case 6:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (Convert.ToBoolean((object) condition1))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  goto label_33;
                case 9:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  str3 = string.Empty;
                  goto label_44;
                case 11:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  str3 = value2;
                  goto label_44;
                case 14:
                  str4 = value3;
                  goto label_47;
                case 15:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  if (condition2.HasValue)
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 18:
                  if (condition3.HasValue)
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 19:
                  if (condition4.HasValue)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 22;
                case 20:
                  num2 = (short) 14165;
                  int num3 = (int) num2;
                  num2 = (short) 14165;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_42;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (!Convert.ToBoolean((object) condition3))
                      {
                        num2 = (short) 21;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 14;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 21:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  str2 = string.Empty;
                  goto label_32;
                case 24:
label_42:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  str4 = string.Empty;
                  goto label_47;
                case 27:
                  num2 = (short) 0;
                  break;
                case 28:
                  if (!Convert.ToBoolean((object) condition2))
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 29:
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
label_32:
              fieldValue4 = str2;
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
label_40:
              fieldValue1 = str1;
              num2 = (short) 27;
              num1 = (int) (IntPtr) num2;
              continue;
label_44:
              fieldValue2 = str3;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
label_47:
              fieldValue3 = str4;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
            }
label_33:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            this.AddFieldValue(ref rptField, fieldValue4);
            this.AddFieldValue(ref rptField, fieldValue3);
            this.AddFieldValue(ref rptField, fieldValue1);
            this.AddFieldValue(ref rptField, fieldValue2);
            return;
label_55:
            this.AddFieldValue(ref rptField, fieldValue2);
            this.AddFieldValue(ref rptField, fieldValue1);
            this.AddFieldValue(ref rptField, fieldValue3);
            this.AddFieldValue(ref rptField, fieldValue4);
            return;
        }
    }
  }

  protected virtual void KeypadButtonSequenceRTL(
    bool? condition1,
    bool? condition2,
    string value1,
    string value2,
    ref _UIFields rptField)
  {
    short num1 = 3396;
    int num2 = (int) num1;
    num1 = (short) 3396;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.AddMultiValueByRTL(condition1, condition2, value1, value2, ref this.rptFields);
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  protected virtual void AddKeypadButton(ref _table rptTable)
  {
    int A_1 = 12;
    short num1 = 163;
    int num2 = (int) num1;
    num1 = (short) 163;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_36:
        rptTable.RecSet.Add(this.rptRec);
        num4 = (short) 5;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        switch (num4)
        {
          default:
            num4 = (short) 3;
            num5 = (int) (IntPtr) num4;
            break;
        }
        break;
    }
    IEnumerator<FeatureNode> enumerator;
    int num6;
    while (true)
    {
      num4 = (short) 0;
      switch (num5)
      {
        case 0:
          this.rptRec = new _RecSet();
          ++this.count;
          this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒎\uF490\uEA92\uE594\uF696ﶘ쒚\uDF9C\uEA9E햠힢쪤즦\uDAA8", A_1), this.ci);
          this.rptRec.RecNo = this.count.ToString();
          num6 = 0;
          enumerator = ((Collection<FeatureNode>) this.keypadButton).GetEnumerator();
          num4 = (short) 4;
          num5 = (int) (IntPtr) num4;
          continue;
        case 1:
          if (!((Recordset) this.recsetKeypad).HiddenStatic)
          {
            num4 = (short) 0;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_37;
        case 2:
          num4 = (short) 1;
          num5 = (int) (IntPtr) num4;
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
          goto label_9;
        case 5:
          goto label_35;
      }
      if (this.keypadButton != null)
      {
        num4 = (short) 2;
        num5 = (int) (IntPtr) num4;
      }
      else
        goto label_39;
    }
label_35:
    return;
label_39:
    return;
label_9:
    try
    {
      num4 = (short) 1;
      int num7 = (int) (IntPtr) num4;
      while (true)
      {
        KeypadButtonInnerSection buttonInnerSection;
        string str;
        IAcpFeatureNode current;
        string uiName;
        string index41415UiValue;
        switch (num7)
        {
          case 0:
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒\uDE94튖삘쮚\uDC9C\uDB9E\uE3A0\uF6A2\uF1A4\uF3A6\uE6A8\uE5AA", A_1), this.ci) + (++num6).ToString());
            num4 = (short) 10;
            num7 = (int) (IntPtr) num4;
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
            num4 = (short) 7;
            num7 = (int) (IntPtr) num4;
            continue;
          case 4:
            str = str + this.indexSeparator + index41415UiValue;
            num4 = (short) 9;
            num7 = (int) (IntPtr) num4;
            continue;
          case 5:
            if (this.rptFields.UIFieldDes == string.Empty)
            {
              num4 = (short) 0;
              num7 = (int) (IntPtr) num4;
              continue;
            }
            goto case 10;
          case 6:
            if (str == AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒잔튖햘\uDA9A쒜쾞\uE0A0\uF7A2\uF1A4\uE2A6ﮨ\uE5AA", A_1), this.ci))
            {
              num4 = (short) 4;
              num7 = (int) (IntPtr) num4;
              continue;
            }
            goto case 9;
          case 7:
            goto label_36;
          case 8:
            if (!enumerator.MoveNext())
            {
              num4 = (short) 2;
              num7 = (int) (IntPtr) num4;
              continue;
            }
            current = (IAcpFeatureNode) enumerator.Current;
            this.rptFields = new _UIFields();
            buttonInnerSection = current[10709] as KeypadButtonInnerSection;
            int featureA41071Value = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071Value;
            str = (string) ((AcpFieldX<int, string>) (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).Converter.Convert((object) featureA41071Value, (Type) null, (object) null, this.ci);
            index41415UiValue = (current[10709] as KeypadButtonInnerSection).RadErgCtrlKeypadGeneralKeypadButtonIndex_41415_UIValue;
            num4 = (short) 6;
            num7 = (int) (IntPtr) num4;
            continue;
          case 9:
            this.KeypadButtonSequenceRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonFeature_A41071).HiddenStatic), str, str, ref this.rptFields);
            this.rptFields.UIFieldName = ((AcpFieldBase) ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069).UIName.ToString();
            uiName = ((KeypadButtonInner) current).KeypadButtonInnerSection.RadErgCtrlKeypadGeneralKeypadButtonName_A41069_UIValue.ToString();
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒쾔튖쮘풚궜", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("욎햐첒쾔튖쮘풚궜", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삎ﾐ\uF692꒔좖킘ﾚ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("삎ﾐ\uF692꒔좖킘ﾚ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E\uE690ﲒꞔ좖킘ﾚ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E\uE690ﲒꞔ좖킘ﾚ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E戀\uE192\uF094\uF296ꪘ쒚풜ﮞ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB8E戀\uE192\uF094\uF296ꪘ쒚풜ﮞ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎ﺐ\uE692\uE794ꎖ욘튚列", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎ﺐ\uE692\uE794ꎖ욘튚列", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎\uF890\uE592\uF094ꊖ욘튚列", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("즎\uF890\uE592\uF094ꊖ욘튚列", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF890\uEB92ꎔ좖킘ﾚ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF890\uEB92ꎔ좖킘ﾚ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF490\uE592\uF094練꺘쒚풜ﮞ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uF490\uE592\uF094練꺘쒚풜ﮞ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪎\uF890\uF492ﶔ\uE396ꆘ쒚풜ﮞ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪎\uF890\uF492ﶔ\uE396ꆘ쒚풜ﮞ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솎\uF890ﶒ\uF094꺖욘튚列", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("솎\uF890ﶒ\uF094꺖욘튚列", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uE590\uF292\uE794좖킘ﾚ", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDC8E\uE590\uF292\uE794좖킘ﾚ", A_1), this.ci));
            this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Eﺐ\uE692ﮔ\uF396톘漢\uEE9C\uF79Eﺠ\uEAA2솤", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDF8Eﺐ\uE692ﮔ\uF396톘漢\uEE9C\uF79Eﺠ\uEAA2솤", A_1), this.ci));
            num4 = (short) 5;
            num7 = (int) (IntPtr) num4;
            continue;
          case 10:
            this.rptRec.UIFields.Add(this.rptFields);
            num4 = (short) 3;
            num7 = (int) (IntPtr) num4;
            continue;
        }
        num4 = (short) 8;
        num7 = (int) (IntPtr) num4;
      }
    }
    finally
    {
      short num8 = 0;
      int num9 = (int) (IntPtr) num8;
      while (true)
      {
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
            enumerator.Dispose();
            num8 = (short) 2;
            num9 = (int) (IntPtr) num8;
            continue;
          case 2:
            goto label_31;
        }
        if (enumerator != null)
        {
          num8 = (short) 1;
          num9 = (int) (IntPtr) num8;
        }
        else
          break;
      }
label_31:;
    }
label_37:;
  }

  protected virtual void CreateTableHeader(ref _table rptTable)
  {
    int A_1 = 9;
    short num1 = -23571;
    int num2 = (int) num1;
    num1 = (short) -23571;
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
        rptTable.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캋ﮍ\uE48F\uE691ﮓ\uF895\uEB97얙ﶛ\uF09D쒟ﶡ\uE7A3즥욧\uDEA9\uDEAB솭\uDCAF솱", A_1), this.ci);
        rptTable.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("얋\uE08D\uF48F\uF791\uEC93즕톗ﺙ", A_1), this.ci));
        rptTable.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("좋\uEB8D\uE38F\uF191\uE693ﾕ\uE897\uEE99\uF59B\uF19D캟ﶡ\uEDA3슥", A_1), this.ci));
        rptTable.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쾋\uE18Dﺏ\uE491\uF193\uF895\uEC97\uF399\uF39B\uF09D솟캡ﮣ\uEFA5첧", A_1), this.ci));
        rptTable.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD88Bﲍ\uE58Fﲑﾓﾕ\uF697ﶙ쎛힝\uE49F", A_1), this.ci));
        break;
      default:
        goto case 1;
    }
  }

  public override void BuildDataTables(ref _XMLData XMLRptDataObj)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    num1 = (short) 19493;
    int num2 = (int) num1;
    num1 = (short) 19493;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void AddGeneral(ref _XMLData RptXMLData)
  {
    int A_1 = 10;
    int num1;
    Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation radioInformation;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        radioInformation = FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation;
        num2 = (short) 2;
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
              this.rptValue.FieldValue = iacpField2.ToString();
              this.rptFields.values.Add(this.rptValue);
              this.rptFields.UIFieldName = iacpField2.Name;
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐\uDE92\uDA94펖\uDC98힚펜쪞\uECA0\uE1A2\uE0A4\uF5A6", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              this.rptTable.RecSet.Add(this.rptRec);
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_19;
            case 2:
              if (radioInformation != null)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 3:
              num2 = (short) 0;
              break;
            case 4:
              this.rptTable.TableTitle = RptMgrErrorHandler.b("쪌\uEA8Eﾐ\uF692\uE794\uF696\uF598펚\uF49Cﮞ얠욢쮤", A_1);
              this.rptTable.ColTitle.Add(AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐풒킔\uD996\uDC98즚\uDC9C펞", A_1), this.ci));
              this.rptRec.RecTitle = RptMgrErrorHandler.b("쾌", A_1);
              this.rptRec.RecNo = RptMgrErrorHandler.b("붌", A_1);
              iacpField1 = (IAcpField) null;
              iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralModelNumber_A8539;
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              this.rptValue.FieldValue = iacpField2.ToString();
              this.rptFields.values.Add(this.rptValue);
              this.rptFields.UIFieldName = iacpField2.Name;
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐삒킔얖킘\uDA9A톜톞\uF4A0\uEEA2\uE7A4\uE2A6ﮨ", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              this.rptTable.RecSet.Add(this.rptRec);
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              this.rptRec = new _RecSet();
              this.rptValue = new _Value();
              this.rptFields = new _UIFields();
              iacpField1 = (IAcpField) null;
              this.rptRec.RecTitle = RptMgrErrorHandler.b("캌", A_1);
              this.rptRec.RecNo = RptMgrErrorHandler.b("벌", A_1);
              iacpField2 = (IAcpField) radioInformation.General.RadInfoGeneralSerialNumber_A9122;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (iacpField2 != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 6;
            case 8:
              this.rptValue.FieldValue = iacpField2.ToString();
              this.rptFields.values.Add(this.rptValue);
              this.rptFields.UIFieldName = iacpField2.Name;
              this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐햒\uD994횖쪘펚\uDE9C킞\uE5A0\uE6A2", A_1), this.ci);
              this.rptRec.UIFields.Add(this.rptFields);
              this.rptTable.RecSet.Add(this.rptRec);
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              num2 = (short) 22475;
              int num3 = (int) num2;
              num2 = (short) 22475;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_2;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  if (iacpField2 != null)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_14;
              }
            case 10:
              if (iacpField2 != null)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 11:
label_14:
              RptXMLData.tables.Add(this.rptTable);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
          this.rptRec = new _RecSet();
          this.rptValue = new _Value();
          this.rptFields = new _UIFields();
          iacpField1 = (IAcpField) null;
          this.rptRec.RecTitle = RptMgrErrorHandler.b("즌", A_1);
          this.rptRec.RecNo = RptMgrErrorHandler.b("뾌", A_1);
          iacpField2 = (IAcpField) radioInformation.FLASHport.RadInfoFLASHportFLASHcode_A8132;
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
        }
label_19:
        break;
label_23:
        break;
    }
  }

  private void a(ref Dictionary<int, string> A_0, int A_1)
  {
    int num1;
    Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        channelAssignment = FeatureManager.GetFeature(2051)[A_1 - 1] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          int key;
          ChannelAssignmentListInner assignmentListInner;
          switch (num1)
          {
            case 0:
              A_0.Add(key, assignmentListInner.ChannelAssignmentListInnerSection.ZnChanCfgChannelsChannelName_A7659Value);
              assignmentListInner = (ChannelAssignmentListInner) null;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (key < ((FeatureSection) channelAssignment.Channels).EmbeddedRecset.Count)
              {
                assignmentListInner = (ChannelAssignmentListInner) ((FeatureSection) channelAssignment.Channels).EmbeddedRecset[key];
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              assignmentListInner = (ChannelAssignmentListInner) null;
              key = 0;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (channelAssignment != null)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_12;
            case 4:
              if (channelAssignment.Zone.ZnChanCfgZoneDynamicZoneEnable_A41257.Value)
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
            case 12:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              goto label_20;
            case 8:
              goto label_11;
            case 9:
              if (assignmentListInner != null)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 10:
              num2 = (short) -21070;
              int num3 = (int) num2;
              num2 = (short) -21070;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_2;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    break;
                  break;
              }
              break;
            case 11:
              if (((FeatureSection) channelAssignment.Channels).HasEmbeddedRecset)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_22;
            default:
              goto label_2;
          }
          ++key;
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
        }
label_20:
        break;
label_12:
        break;
label_11:
        num2 = (short) 0;
        break;
label_22:
        break;
    }
  }

  protected void AddZonesAndChannels(ref _XMLData RptXMLData)
  {
    int A_1 = 7;
    int num1 = 0;
    switch (num1)
    {
      default:
        Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            channelAssignment1 = FeatureManager.GetFeature(2051)[0] as Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment;
            num2 = (short) 18;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              List<Dictionary<int, string>> A_0_1;
              int num3;
              int index;
              string str1;
              int num4;
              int num5;
              int num6;
              int num7;
              int num8;
              int num9;
              int num10;
              int num11;
              int num12;
              string str2;
              string str3;
              int num13;
              switch (num1)
              {
                case 0:
                  A_0_1.Reverse();
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num3 = 0;
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 26:
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  str2 = string.Format(RptMgrErrorHandler.b("ꪉ\uF78B뺍\uED8F", A_1), (object) num5);
                  goto label_43;
                case 5:
                  if (num8 < num11)
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 27;
                case 6:
                  if (((FeatureNode) channelAssignment1).Parent[num7] is Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment.ZoneChannelAssignment channelAssignment2)
                  {
                    str3 = ((AcpField<string>) ((FeatureNode) channelAssignment2).KeyField).Value;
                    goto label_50;
                  }
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (num7 < ((FeatureNode) channelAssignment1).Parent.Count)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                case 16 /*0x10*/:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                case 12:
                case 13:
                  Dictionary<int, string> A_0_2 = new Dictionary<int, string>();
                  this.a(ref A_0_2, num7 + 1);
                  A_0_1.Add(A_0_2);
                  num7 = ++num8 + num9;
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  num2 = (short) -2030;
                  int num14 = (int) num2;
                  num2 = (short) -2030;
                  int num15 = (int) num2;
                  switch (num14 == num15 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_6;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      num13 = 3;
                      goto label_33;
                  }
                case 14:
                  if (this.isRTL)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 15:
                  str2 = string.Empty;
                  goto label_43;
                case 17:
                case 41:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (((FeatureNode) channelAssignment1).Parent.Count <= 3)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
label_6:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                case 34:
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  this.rptTable.ColTitle.Insert(index, str1);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  if (num5 < num12)
                  {
                    num9 = num11 * num5;
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  num10 = num11 - (((FeatureNode) channelAssignment1).Parent.Count - num9);
                  num4 = 0;
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (num5 == num6)
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 27:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  num13 = 6;
                  goto label_33;
                case 29:
                  goto label_69;
                case 30:
                  if (!this.isRTL)
                  {
                    this.rptTable.ColTitle.Add(str1);
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  if (this.isRTL)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 36;
                case 32 /*0x20*/:
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  num2 = (short) 0;
                  break;
                case 36:
                  this.rptTable.RecSet.AddRange((IEnumerable<_RecSet>) this.a(A_0_1));
                  RptXMLData.tables.Add(this.rptTable);
                  ++num5;
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  if (num4 < num10)
                  {
                    this.rptTable.ColTitle.Insert(1, string.Empty);
                    ++num4;
                    ++index;
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (num5 != num6)
                  {
                    this.rptTable.ColTitle.Insert(1, str1);
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  str3 = (string) null;
                  goto label_50;
                case 40:
                  if (num5 == num6)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 42:
                  if (num5 <= 0)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (num3 < num11 - num8)
                  {
                    A_0_1.Add(new Dictionary<int, string>()
                    {
                      {
                        0,
                        string.Empty
                      }
                    });
                    ++num3;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              A_0_1 = new List<Dictionary<int, string>>();
              num8 = 0;
              num7 = num9;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
label_33:
              num11 = num13;
              num12 = (int) Math.Ceiling((double) ((FeatureNode) channelAssignment1).Parent.Count / (double) num11);
              num6 = num12 - 1;
              num5 = 0;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
label_43:
              string str4 = str2;
              this.rptTable = new _table();
              this.rptTable.TableTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킉\uE38B\uE08D\uF58F\uE191쮓\uF795\uF697ﺙ쎛\uDD9D좟쎡쪣좥춧용\uDFAB", A_1), this.ci) + str4;
              this.rptTable.ColTitle.Add(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("즉\uE48B\uEF8Dﺏﲑ\uF193歹\uEB97얙햛瞧", A_1), this.ci));
              index = 1;
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
label_50:
              str1 = str3;
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
            }
label_69:
            return;
        }
    }
  }

  private List<_RecSet> a(List<Dictionary<int, string>> A_0)
  {
    int A_1 = 5;
    int num1 = 0;
    switch (num1)
    {
      default:
        List<_RecSet> recSetList;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            recSetList = new List<_RecSet>();
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            _UIFields rptFields;
            List<Dictionary<int, string>>.Enumerator enumerator;
            int key;
            int num3;
            int num4;
            _RecSet recSet;
            while (true)
            {
              switch (num1)
              {
                case 0:
                case 3:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  try
                  {
                    num2 = (short) 7;
                    int num5 = (int) (IntPtr) num2;
                    while (true)
                    {
                      Dictionary<int, string> current;
                      switch (num5)
                      {
                        case 2:
                          num2 = (short) -30469;
                          int num6 = (int) num2;
                          num2 = (short) -30469;
                          int num7 = (int) num2;
                          switch (num6 == num7 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_10;
                            default:
                              num2 = (short) 0;
                              if (num2 == (short) 0)
                                ;
                              num2 = (short) 3;
                              num5 = (int) (IntPtr) num2;
                              continue;
                          }
                        case 3:
                          goto label_23;
                        case 4:
                          string fieldValue;
                          current.TryGetValue(key, out fieldValue);
                          this.AddFieldValue(ref rptFields, fieldValue);
                          num2 = (short) 0;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 5:
label_10:
                          if (current.Count <= key)
                          {
                            this.AddFieldValue(ref rptFields, string.Empty);
                            num2 = (short) 1;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num5 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (enumerator.MoveNext())
                          {
                            current = enumerator.Current;
                            num2 = (short) 5;
                            num5 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 2;
                          num5 = (int) (IntPtr) num2;
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
                      num2 = (short) 6;
                      num5 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    enumerator.Dispose();
                  }
label_23:
                  rptFields.UIFieldName = RptMgrErrorHandler.b("쮇\uE289\uED8B\uE08Dﺏ\uF791\uF893\uD895聯\uF799鍊", A_1);
                  rptFields.UIFieldDes = recSet.RecNo;
                  recSet.UIFields.Add(rptFields);
                  recSetList.Add(recSet);
                  ++key;
                  num1 = 0;
                  continue;
                case 2:
                  if (key >= num3)
                  {
                    num2 = (short) 0;
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  recSet = new _RecSet();
                  rptFields = new _UIFields();
                  recSet.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욇\uE589\uE28B\uEB8D쾏\uDB91\uF093", A_1), this.ci) + num4.ToString();
                  recSet.RecNo = num4++.ToString();
                  enumerator = A_0.GetEnumerator();
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  goto label_26;
                case 5:
                  num3 = A_0.Max<Dictionary<int, string>>((Func<Dictionary<int, string>, int>) (x =>
                  {
                    short num8 = 18990;
                    int num9 = (int) num8;
                    num8 = (short) 18990;
                    int num10 = (int) num8;
                    switch (num9 == num10)
                    {
                      case true:
                        short num11 = 1;
                        if (num11 == (short) 0)
                          ;
                        num11 = (short) 0;
                        if (num11 == (short) 0)
                          ;
                        num11 = (short) 0;
                        return x.Count;
                      default:
                        goto case 1;
                    }
                  }));
                  num4 = 1;
                  key = 0;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_26:
            return recSetList;
        }
    }
  }

  private int a(
    Dictionary<int, string> A_0,
    Dictionary<int, string> A_1,
    Dictionary<int, string> A_2)
  {
    short num1 = 30709;
    int num2 = (int) num1;
    num1 = (short) 30709;
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
        return Math.Max(Math.Max(A_0.Count, A_1.Count), A_2.Count);
      default:
        goto case 1;
    }
  }
}
