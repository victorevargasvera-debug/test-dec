// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.HandOutXMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using CommonResources;
using ConstraintHelper;
using Motorola.MackinawCPS.CoreFeatures.Buttons;
using Motorola.MackinawCPS.CoreFeatures.SmartKeyFob;
using Motorola.MackinawCPS.CoreFeatures.Switches;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public class HandOutXMLCoreEngine : BaseHandOutXMLCoreEngine
{
  private Motorola.MackinawCPS.CoreFeatures.Switches.Switches a;
  private RotaryControlInnerRecset b;
  private RotaryControlInnerSection c;
  private MFKAssignmentControlInnerRecset d;
  private MFKAssignmentControlInnerSection e;
  private MFKAssignmentControlInnerSection f;
  private ButtonsRecset g;
  private PortableButtonInnerRecset h;
  private DataButtonInnerRecset i;
  private PortableSideUpDownArrowButtonInnerRecset j;
  private SmartKeyFobRecset k;
  private SmartKeyFobButtonTableInnerRecset l;

  public HandOutXMLCoreEngine()
  {
    this.a = FeatureManager.GetFeature(2038)[0] as Motorola.MackinawCPS.CoreFeatures.Switches.Switches;
    if (this.a != null)
    {
      this.b = ((FeatureNode) this.a)[10081].EmbeddedRecset as RotaryControlInnerRecset;
      if (this.b != null)
        this.c = ((Recordset) this.b)[0][10082] as RotaryControlInnerSection;
    }
    if (this.a != null)
      goto label_8;
label_6:
    this.g = FeatureManager.GetFeature(2042) as ButtonsRecset;
    if (this.g != null)
    {
      this.h = ((Recordset) this.g)[0][10091].EmbeddedRecset as PortableButtonInnerRecset;
      this.i = ((Recordset) this.g)[0][10089].EmbeddedRecset as DataButtonInnerRecset;
      this.j = ((Recordset) this.g)[0][10745].EmbeddedRecset as PortableSideUpDownArrowButtonInnerRecset;
    }
    this.k = FeatureManager.GetFeature(4130) as SmartKeyFobRecset;
    if (this.k == null)
      return;
    this.l = ((Recordset) this.k)[0][10747].EmbeddedRecset as SmartKeyFobButtonTableInnerRecset;
    return;
label_8:
    this.d = ((FeatureNode) this.a)[10637].EmbeddedRecset as MFKAssignmentControlInnerRecset;
    if (this.d != null)
    {
      this.e = ((Recordset) this.d)[0][10638] as MFKAssignmentControlInnerSection;
      this.f = ((Recordset) this.d)[1][10638] as MFKAssignmentControlInnerSection;
      goto label_6;
    }
    goto label_6;
  }

  private void j(ref _table A_0)
  {
    int A_1 = 17;
    short num1 = 27634;
    int num2 = (int) num1;
    num1 = (short) 27634;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (true)
          ;
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD993\uE395\uF497\uEE99\uF59B솝\uE69F힡쪣얥\uDCA7쎩쎫삭\uEFAF鈴\uDAB3\uD9B5\uDAB7", A_1), this.ci);
        this.rptRec.RecNo = this.count.ToString();
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒓秊\uEF97ﾙ\uEE9B솝\uE99F욡", A_1), this.ci), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒓秊\uEF97ﾙ\uEE9B솝\uE99F욡", A_1), this.ci), ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("쒓秊\uEF97", A_1);
        this.rptFields.UIFieldDes = "";
        this.rptRec.UIFields.Add(this.rptFields);
        this.rptFields = new _UIFields();
        string str1 = (string) ((AcpFieldX<int, string>) this.e.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Converter.Convert((object) ((AcpField<int>) this.e.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Value, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str1, str1, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("쒓\uE495\uF197\uF799ﶛ\uEC9D\uD99F\uE4A1톣좥쮧\uDEA9얫솭\uDEAF", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒓\uE495\uF197\uF799ﶛ\uEC9D\uD99Fﶡ\uE2A3펥욧즩\uD8AB잭\uDFAF\uDCB1", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        this.rptFields = new _UIFields();
        string str2 = (string) ((AcpFieldX<int, string>) this.f.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Converter.Convert((object) ((AcpField<int>) this.f.RadErgoControlSwitchsMFKFeatureAssignment_A38514).Value, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str2, str2, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("잓\uF395ﮗ\uF599\uF29B瞧솟킡\uDDA3\uE0A5\uDDA7쒩쾫\uDAAD\uD9AF\uDDB1\uDAB3", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("잓\uF395ﮗ\uF599\uF29B瞧솟킡\uDDA3殮\uEEA7\uDFA9슫춭쒯\uDBB1\uDBB3\uD8B5", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void i(ref _table A_0)
  {
    int A_1 = 0;
    short num1 = -1484;
    int num2 = (int) num1;
    num1 = (short) -1484;
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
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        _RecSet rptRec1 = this.rptRec;
        string noprintId = AppResources.NOPRINT_Id;
        int count = this.count;
        string str1 = count.ToString();
        string str2 = noprintId + str1;
        rptRec1.RecTitle = str2;
        _RecSet rptRec2 = this.rptRec;
        count = this.count;
        string str3 = count.ToString();
        rptRec2.RecNo = str3;
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("펂\uEA84\uF086\uEC88力튌욎\uF590", A_1), this.ci), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("펂\uEA84\uF086\uEC88力튌욎\uF590", A_1), this.ci), ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("펂\uEA84\uF086", A_1);
        this.rptFields.UIFieldDes = "";
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void h(ref _table A_0)
  {
    int A_1 = 19;
    short num1 = 16471;
    int num2 = (int) num1;
    num1 = (short) 16471;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        _RecSet rptRec1 = this.rptRec;
        string noprintId = AppResources.NOPRINT_Id;
        int count = this.count;
        string str1 = count.ToString();
        string str2 = noprintId + str1;
        rptRec1.RecTitle = str2;
        _RecSet rptRec2 = this.rptRec;
        count = this.count;
        string str3 = count.ToString();
        rptRec2.RecNo = str3;
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1), this.ci), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("욕\uF797\uED99鍊\uEC9Dﾟ\uF4A1쮣쪥\uDDA7잩즫", A_1), this.ci), ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("욕\uF797\uED99쪛\uF19D첟", A_1);
        this.rptFields.UIFieldDes = "";
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void g(ref _table A_0)
  {
    int A_1 = 2;
    short num1 = -3659;
    int num2 = (int) num1;
    num1 = (short) -3659;
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
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("톄\uF086\uE688풊\uDD8C\uE08E\uE290朗\uE194ﺖ\uF698\uF59A슜\uDC9E캠춢욤슦잨\uDFAA\uDFAC욮튰", A_1), this.ci);
        this.rptRec.RecNo = this.count.ToString();
        int num5 = ((AcpField<int>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).Value;
        int num6 = ((AcpField<int>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).Value;
        string str1 = (string) ((AcpFieldX<int, string>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).Converter.Convert((object) num5, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).HiddenStatic), new bool?(!((AcpFieldBase) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition1_A7734).HiddenStatic), (string) ((AcpFieldX<int, string>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition1_A9466).Converter.Convert((object) num6, (Type) null, (object) null, this.ci), str1, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("햄\uE886愈\uE28A歷\uE68Eﺐﶒ풔", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("햄\uE886愈\uE28A歷\uE68Eﺐﶒ쪔횖", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        this.rptFields = new _UIFields();
        int num7 = ((AcpField<int>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).Value;
        int num8 = ((AcpField<int>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).Value;
        string str2 = (string) ((AcpFieldX<int, string>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).Converter.Convert((object) num7, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).HiddenStatic), new bool?(!((AcpFieldBase) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition2_A7735).HiddenStatic), (string) ((AcpFieldX<int, string>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition2_A9467).Converter.Convert((object) num8, (Type) null, (object) null, this.ci), str2, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("햄\uE886愈\uE28A歷\uE68Eﺐﶒ힔", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("햄\uE886愈\uE28A歷\uE68Eﺐﶒ쪔햖", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void f(ref _table A_0)
  {
    int A_1 = 1;
    short num1 = -11610;
    int num2 = (int) num1;
    num1 = (short) -11610;
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
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        this.rptRec.RecTitle = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("킃\uEE85慎\uEF89\uE98B톍삏\uFD91\uE793ﾕ\uEC97\uF399\uF39B\uF09Dﾟ\uF6A1쮣솥쾧용즫", A_1), this.ci);
        this.rptRec.RecNo = this.count.ToString();
        int num5 = ((AcpField<int>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).Value;
        int num6 = ((AcpField<int>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).Value;
        string str1 = (string) ((AcpFieldX<int, string>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).Converter.Convert((object) num5, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).HiddenStatic), new bool?(!((AcpFieldBase) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition3_A7737).HiddenStatic), (string) ((AcpFieldX<int, string>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition3_A9468).Converter.Convert((object) num6, (Type) null, (object) null, this.ci), str1, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ햓", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ쮓힕", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        this.rptFields = new _UIFields();
        int num7 = ((AcpField<int>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).Value;
        int num8 = ((AcpField<int>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).Value;
        string str2 = (string) ((AcpFieldX<int, string>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).Converter.Convert((object) num7, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).HiddenStatic), new bool?(!((AcpFieldBase) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition4_A21530).HiddenStatic), (string) ((AcpFieldX<int, string>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition4_A21534).Converter.Convert((object) num8, (Type) null, (object) null, this.ci), str2, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ횓", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ쮓풕", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        this.rptFields = new _UIFields();
        int num9 = ((AcpField<int>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).Value;
        int num10 = ((AcpField<int>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).Value;
        string str3 = (string) ((AcpFieldX<int, string>) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).Converter.Convert((object) num9, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).HiddenStatic), new bool?(!((AcpFieldBase) this.a.ConventionalSwitches.SwitchConventionalSwitchesPosition5_A21531).HiddenStatic), (string) ((AcpFieldX<int, string>) this.a.TrunkingSwitches.SwitchTrunkingSwitchesPosition5_A21535).Converter.Convert((object) num10, (Type) null, (object) null, this.ci), str3, ref this.rptFields);
        this.rptFields.UIFieldName = RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ힓", A_1);
        this.rptFields.UIFieldDes = AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풃\uE985ﮇ\uE389\uF88B\uE78Dﾏﲑ쮓햕", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void e(ref _table A_0)
  {
    int A_1 = 17;
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) this.h).GetEnumerator();
        try
        {
          num1 = (short) 4;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            switch (num2)
            {
              case 0:
                goto label_19;
              case 1:
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                if (enumerator.MoveNext())
                {
                  IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                  this.rptRec = new _RecSet();
                  this.rptFields = new _UIFields();
                  ++this.count;
                  this.rptRec.RecTitle = AppResources.NOPRINT_Id + this.count.ToString();
                  this.rptRec.RecNo = this.count.ToString();
                  PortableButtonInnerSection buttonInnerSection = current[10092] as PortableButtonInnerSection;
                  int featureA19544Value = (current[10092] as PortableButtonInnerSection).BtnGeneralConventionalFeature_A19544Value;
                  int featureA19546Value = (current[10092] as PortableButtonInnerSection).BtnTrunkingPortableButtonFeature_A19546Value;
                  string str1 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnGeneralConventionalFeature_A19544).Converter.Convert((object) featureA19544Value, (Type) null, (object) null, this.ci);
                  string str2 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnTrunkingPortableButtonFeature_A19546).Converter.Convert((object) featureA19546Value, (Type) null, (object) null, this.ci);
                  int num3 = AcpField<int>.op_Implicit((AcpField<int>) (current[10092] as PortableButtonInnerSection).BtnTopButtonShortPressTime);
                  string str3 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnTopButtonShortPressTime).Converter.Convert((object) num3, (Type) null, (object) null, this.ci);
                  int num4 = AcpField<int>.op_Implicit((AcpField<int>) (current[10092] as PortableButtonInnerSection).BtnPortableTopButtonLongPressTime);
                  string str4 = (string) ((AcpFieldX<int, string>) (current[10092] as PortableButtonInnerSection).BtnPortableTopButtonLongPressTime).Converter.Convert((object) num4, (Type) null, (object) null, this.ci);
                  this.AddMultiValueByRTL(new bool?(!((AcpFieldBase) buttonInnerSection.BtnTrunkingPortableButtonFeature_A19546).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.BtnGeneralConventionalFeature_A19544).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.BtnTopButtonShortPressTime).HiddenStatic), new bool?(!((AcpFieldBase) buttonInnerSection.BtnPortableTopButtonLongPressTime).HiddenStatic), str2.ToString(), str1.ToString(), str3.ToString(), str4.ToString(), ref this.rptFields);
                  this.rptFields.UIFieldName = ((AcpFieldBase) ((PortableButtonInner) current).PortableButtonInnerSection.BtnPortableButtonName_A22558).UIName.ToString();
                  string uiName = ((PortableButtonInner) current).PortableButtonInnerSection.BtnPortableButtonName_A22558_UIValue.ToString();
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗캙펛캝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗캙펛캝\uE29F\uF7A1\uF0A3\uF2A5\uE7A7\uE4A9", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uF6A1\uEBA3\uF6A5\uEAA7ﾩ\uF8AB節ﾯﲱ", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uF6A1\uEBA3\uF6A5\uEAA7ﾩ\uF8AB節ﾯﲱ", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uEFA1\uEDA3\uE2A5\uECA7\uE6A9\uE9AB\uECAD\uE5AF\uE6B1\uE0B3例\uF6B7", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uEFA1\uEDA3\uE2A5\uECA7\uE6A9\uE9AB\uECAD\uE5AF\uE6B1\uE0B3例\uF6B7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uE0A1\uEBA3\uF2A5ﲧ\uE5A9\uE1AB\uECAD\uE5AF\uE6B1\uE0B3例\uF6B7", A_1), Thread.CurrentThread.CurrentCulture), AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙햛\uDA9D\uE59F\uE0A1\uEBA3\uF2A5ﲧ\uE5A9\uE1AB\uECAD\uE5AF\uE6B1\uE0B3例\uF6B7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙첛\uDB9D\uE19F\uE9A1\uE1A3\uF4A5\uEFA7\uF8A9\uE5AB\uE2ADﲯ\uF7B1\uF6B3\uE3B5\uECB7\uEEB9\uF3BB\uF0BD", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗즙첛\uDB9D\uE19F\uE9A1\uE1A3\uF4A5\uEFA7\uF8A9\uE5AB\uE2ADﲯ\uF7B1\uF6B3\uE3B5\uECB7\uEEB9\uF3BB\uF0BD", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙궛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙궛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙꺛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙꺛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙꾛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙꾛\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꢛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꢛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꦛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꦛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꪛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙ꪛ\uDC9D\uF59F\uF6A1\uF0A3\uE9A5\uE6A7", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗풙펛쪝\uE99F\uE4A1\uEDA3\uE5A5\uE9A7ﺩ\uE5AB\uE1ADﺯ\uF0B1\uE1B3\uE2B5\uECB7\uF5B9\uF2BB", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗풙펛쪝\uE99F\uE4A1\uEDA3\uE5A5\uE9A7ﺩ\uE5AB\uE1ADﺯ\uF0B1\uE1B3\uE2B5\uECB7\uF5B9\uF2BB", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD93튕잗쪙펛첝\uF49F\uE3A1\uE6A3\uEAA5\uEDA7\uE8A9嶺節\uE4AFﶱ荒", A_1), this.ci));
                  this.rptRec.UIFields.Add(this.rptFields);
                  A_0.RecSet.Add(this.rptRec);
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 1;
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
            }
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
label_19:
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
                num5 = (short) -1433;
                int num7 = (int) num5;
                num5 = (short) -1433;
                int num8 = (int) num5;
                switch (num7 == num8 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_18;
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
                    goto label_14;
                  default:
                    continue;
                }
              default:
label_14:
                if (enumerator == null)
                  goto label_20;
                break;
            }
            num5 = (short) 1;
            num6 = (int) (IntPtr) num5;
          }
label_18:
          num5 = (short) 0;
          if (num5 == (short) 0)
            ;
label_20:;
        }
    }
  }

  private void d(ref _table A_0)
  {
    int A_1 = 13;
    short num1 = -21634;
    int num2 = (int) num1;
    num1 = (short) -21634;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (false)
          ;
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        _RecSet rptRec1 = this.rptRec;
        string noprintId = AppResources.NOPRINT_Id;
        int count = this.count;
        string str1 = count.ToString();
        string str2 = noprintId + str1;
        rptRec1.RecTitle = str2;
        _RecSet rptRec2 = this.rptRec;
        count = this.count;
        string str3 = count.ToString();
        rptRec2.RecNo = str3;
        string str4 = (string) ((AcpFieldX<int, string>) this.c.SwitchGeneralRotaryControl_A8984).Converter.Convert((object) this.c.SwitchGeneralRotaryControl_A8984Value, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str4.ToString(), str4.ToString(), ref this.rptFields);
        this.rptFields.UIFieldName = ((AcpFieldBase) this.c.SwitchRotaryControlButtonName_A22903).UIName.ToString();
        this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98F횑쮓쒕힗캙\uDD9B첝烈\uE1A1\uEBA3\uE8A5ﲧ\uF8A9\uE3AB\uE2AD", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void c(ref _table A_0)
  {
    int A_1 = 10;
    short num1 = -10611;
    int num2 = (int) num1;
    num1 = (short) -10611;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.rptRec = new _RecSet();
        this.rptFields = new _UIFields();
        ++this.count;
        _RecSet rptRec1 = this.rptRec;
        string noprintId = AppResources.NOPRINT_Id;
        int count = this.count;
        string str1 = count.ToString();
        string str2 = noprintId + str1;
        rptRec1.RecTitle = str2;
        _RecSet rptRec2 = this.rptRec;
        count = this.count;
        string str3 = count.ToString();
        rptRec2.RecNo = str3;
        IAcpFeatureNode iacpFeatureNode = ((Recordset) this.i)[0];
        int featureA22610Value = (iacpFeatureNode[10090] as DataButtonInnerSection).BtnConventionalButtonDatatButtonFeature_A22610Value;
        int featureA22608Value = (iacpFeatureNode[10090] as DataButtonInnerSection).BtnTrunkingButtonDatatButtonFeature_A22608Value;
        string str4 = (string) ((AcpFieldX<int, string>) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnConventionalButtonDatatButtonFeature_A22610).Converter.Convert((object) featureA22610Value, (Type) null, (object) null, this.ci);
        this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), ((string) ((AcpFieldX<int, string>) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnTrunkingButtonDatatButtonFeature_A22608).Converter.Convert((object) featureA22608Value, (Type) null, (object) null, this.ci)).ToString(), str4.ToString(), ref this.rptFields);
        this.rptFields.UIFieldName = ((AcpFieldBase) (iacpFeatureNode[10090] as DataButtonInnerSection).BtnButtonDataButtonName_A22612).UIName.ToString();
        this.rptFields.UIFieldDes = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒌쮎캐힒풔쎖\uD898\uD99A좜쮞\uF5A0\uECA2\uEBA4\uF8A6風", A_1), this.ci);
        this.rptRec.UIFields.Add(this.rptFields);
        A_0.RecSet.Add(this.rptRec);
        break;
      default:
        goto case 1;
    }
  }

  private void b(ref _table A_0)
  {
    int A_1 = 6;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 0;
        this.rptRec = new _RecSet();
        ++this.count;
        this.rptRec.RecTitle = AcgResources.ID_SIDEARROWBUTTONS;
        this.rptRec.RecNo = this.count.ToString();
        int num2 = 0;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) this.j).GetEnumerator();
        try
        {
          num1 = (short) 6;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            string uiName;
            switch (num3)
            {
              case 0:
                if (this.rptFields.UIFieldDes == string.Empty)
                {
                  num1 = (short) 1;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 5;
              case 1:
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("삈쾊튌\uDF8E\uDE90솒요\uDE96\uDD98\uDE9A\uDF9C쪞\uF5A0", A_1), this.ci) + (++num2).ToString());
                num1 = (short) 5;
                num3 = (int) (IntPtr) num1;
                continue;
              case 3:
                num1 = (short) 7;
                num3 = (int) (IntPtr) num1;
                continue;
              case 4:
                if (enumerator.MoveNext())
                {
                  IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                  this.rptFields = new _UIFields();
                  string functionA41568UiValue = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideUpDownArrowButtonPrimaryFunction_A41568_UIValue;
                  string functionA41592UiValue = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideUpDownArrowButtonSecondaryFunction_A41592_UIValue;
                  string str1 = RptMgrErrorHandler.b("ꦈ\uF78A권", A_1);
                  string str2 = functionA41592UiValue;
                  string str3 = functionA41568UiValue + str1 + str2;
                  this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(), str3, str3, ref this.rptFields);
                  this.rptFields.UIFieldName = ((AcpFieldBase) (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideArrowButtonName_A41567).UIName.ToString();
                  uiName = (current[10746] as PortableSideUpDownArrowButtonInnerSection).BtnSideArrowButtonName_A41567_UIValue.ToString();
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("삈쾊튌\uDA8E손튒잔얖횘첚", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("삈쾊튌\uDA8E손튒잔얖횘첚", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("삈쾊튌쮎\uDE90쒒\uDB94횖쮘즚튜좞", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("삈쾊튌쮎\uDE90쒒\uDB94횖쮘즚튜좞", A_1), this.ci));
                  break;
                }
                num1 = (short) 3;
                num3 = (int) (IntPtr) num1;
                continue;
              case 5:
                this.rptRec.UIFields.Add(this.rptFields);
                num1 = (short) 2;
                num3 = (int) (IntPtr) num1;
                continue;
              case 6:
                switch (0)
                {
                  case 0:
                    goto label_10;
                  default:
                    continue;
                }
              case 7:
                num1 = (short) -32743;
                int num4 = (int) num1;
                num1 = (short) -32743;
                int num5 = (int) num1;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_17;
                }
                break;
              default:
label_10:
                num1 = (short) 4;
                num3 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 0;
            num3 = (int) (IntPtr) num1;
          }
label_17:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
        }
        finally
        {
          int num6 = 1;
          while (true)
          {
            short num7;
            switch (num6)
            {
              case 0:
                enumerator.Dispose();
                num7 = (short) 2;
                num6 = (int) (IntPtr) num7;
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
                goto label_24;
            }
            if (enumerator != null)
            {
              num7 = (short) 0;
              num6 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_24:;
        }
        A_0.RecSet.Add(this.rptRec);
        break;
    }
  }

  private void a(ref _table A_0)
  {
    int A_1 = 8;
    switch (0)
    {
      default:
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        this.rptRec = new _RecSet();
        ++this.count;
        this.rptRec.RecTitle = AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎슐\uDE92풔얖춘킚\uD89C욞\uE7A0\uECA2\uE7A4\uE5A6ﲨﾪ怜\uE0AEﾰ\uE0B2", A_1), this.ci);
        this.rptRec.RecNo = this.count.ToString();
        int num2 = 0;
        IEnumerator<FeatureNode> enumerator = ((Collection<FeatureNode>) this.l).GetEnumerator();
        try
        {
          num1 = (short) 6;
          int num3 = (int) (IntPtr) num1;
          while (true)
          {
            string uiName;
            switch (num3)
            {
              case 0:
                if (this.rptFields.UIFieldDes == string.Empty)
                {
                  num1 = (short) 1;
                  num3 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 5;
              case 1:
                this.AddUiFieldDescByCondition(ref this.rptFields, uiName, (string) null, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎힐\uDC92힔햖처쾚즜킞\uEFA0", A_1), this.ci) + (++num2).ToString());
                num1 = (short) 5;
                num3 = (int) (IntPtr) num1;
                continue;
              case 3:
                num1 = (short) 7;
                num3 = (int) (IntPtr) num1;
                continue;
              case 4:
                if (enumerator.MoveNext())
                {
                  IAcpFeatureNode current = (IAcpFeatureNode) enumerator.Current;
                  this.rptFields = new _UIFields();
                  SmartKeyFobButtonTableInnerSection tableInnerSection = current[10748] as SmartKeyFobButtonTableInnerSection;
                  string featureA41574UiValue = (current[10748] as SmartKeyFobButtonTableInnerSection).RadErgoCfgFobConventionalFeature_A41574_UIValue;
                  string featureA41575UiValue = (current[10748] as SmartKeyFobButtonTableInnerSection).RadErgoCfgFobTrunkingFeature_A41575_UIValue;
                  this.AddMultiValueByRTL(new bool?(!((FeatureNode) this.refTrunking).Parent.HiddenStatic), new bool?(!((AcpFieldBase) tableInnerSection.RadErgoCfgFobConventionalFeature_A41574).HiddenStatic), featureA41575UiValue, featureA41574UiValue, ref this.rptFields);
                  this.rptFields.UIFieldName = ((AcpFieldBase) ((SmartKeyFobButtonTableInner) current).SmartKeyFobButtonTableInnerSection.RadErgoCfgFobButtonName_A41573).UIName.ToString();
                  uiName = ((SmartKeyFobButtonTableInner) current).SmartKeyFobButtonTableInnerSection.RadErgoCfgFobButtonName_A41573_UIValue.ToString();
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("잊\uE28C\uEC8E敖첒\uE094\uE796", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("잊\uE28C\uEC8E敖첒\uE094\uE796", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("잊\uE28C\uEC8E敖첒\uF194\uF896\uEE98\uF59A", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("잊\uE28C\uEC8E敖첒\uF194\uF896\uEE98\uF59A", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖\uEC98\uEB9A", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖\uEC98\uEB9A", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖ﶘ\uF49A\uEA9C\uF19E", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖ﶘ\uF49A\uEA9C\uF19E", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖\uED98\uE99A\uE89C\uF19E쪠", A_1), Thread.CurrentThread.CurrentCulture), MTFResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDE8A\uE38C\uE38Eﺐ\uF092ﺔ좖\uED98\uE99A\uE89C\uF19E쪠", A_1), this.ci));
                  this.AddUiFieldDescByCondition(ref this.rptFields, uiName, AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐\uDF92풔얖풘", A_1), Thread.CurrentThread.CurrentCulture), AcgResources.ResourceManager.GetString(RptMgrErrorHandler.b("슊즌킎킐\uDF92풔얖풘", A_1), this.ci));
                  break;
                }
                num1 = (short) 3;
                num3 = (int) (IntPtr) num1;
                continue;
              case 5:
                this.rptRec.UIFields.Add(this.rptFields);
                num1 = (short) 2;
                num3 = (int) (IntPtr) num1;
                continue;
              case 6:
                switch (0)
                {
                  case 0:
                    goto label_10;
                  default:
                    continue;
                }
              case 7:
                num1 = (short) -23856;
                int num4 = (int) num1;
                num1 = (short) -23856;
                int num5 = (int) num1;
                switch (num4 == num5 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    goto label_17;
                }
                break;
              default:
label_10:
                num1 = (short) 4;
                num3 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 0;
            num3 = (int) (IntPtr) num1;
          }
label_17:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
        }
        finally
        {
          int num6 = 1;
          while (true)
          {
            short num7;
            switch (num6)
            {
              case 0:
                enumerator.Dispose();
                num7 = (short) 2;
                num6 = (int) (IntPtr) num7;
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
                goto label_24;
            }
            if (enumerator != null)
            {
              num7 = (short) 0;
              num6 = (int) (IntPtr) num7;
            }
            else
              break;
          }
label_24:;
        }
        A_0.RecSet.Add(this.rptRec);
        break;
    }
  }

  public override void BuildDataTables(ref _XMLData XMLRptDataObj)
  {
    int A_1 = 6;
    short num1;
    int num2;
    switch (0)
    {
      case 0:
label_3:
        this.AddGeneral(ref XMLRptDataObj);
        this.rptTable = new _table();
        this.acpr = new AcpReports();
        this.CreateTableHeader(ref this.rptTable);
        num1 = (short) 15;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          switch (num2)
          {
            case 0:
              if (!((Recordset) this.k).HiddenStatic)
              {
                num1 = (short) 22;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 1:
              num1 = (short) 12;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
            case 4:
            case 17:
              num1 = (short) 33;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              if (((Recordset) this.j).HasVisibleObjects)
              {
                num1 = (short) 35;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 25;
            case 5:
              if (this.c != null)
              {
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 2;
            case 6:
              num1 = (short) 37;
              num2 = (int) (IntPtr) num1;
              continue;
            case 7:
label_45:
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            case 8:
              if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("좈\uDB8A햌벎ꆐꎒꖔ", A_1)))
              {
                num1 = (short) 9;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 9:
              this.a(ref this.rptTable);
              num1 = (short) 28;
              num2 = (int) (IntPtr) num1;
              continue;
            case 10:
              this.g(ref this.rptTable);
              this.f(ref this.rptTable);
              num1 = (short) 20;
              num2 = (int) (IntPtr) num1;
              continue;
            case 11:
              num1 = (short) 26;
              num2 = (int) (IntPtr) num1;
              continue;
            case 12:
              if (((FeatureSection) this.c).HasVisibleObjects)
              {
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 2;
            case 13:
              this.j(ref this.rptTable);
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            case 14:
              this.d(ref this.rptTable);
              num1 = (short) 17;
              num2 = (int) (IntPtr) num1;
              continue;
            case 15:
              if (UtilityMack.IsPortable())
              {
                num1 = (short) 11;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 16 /*0x10*/:
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
            case 18:
              if (this.a != null)
              {
                num1 = (short) 19;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 20;
            case 19:
              this.h(ref this.rptTable);
              num1 = (short) 31 /*0x1F*/;
              num2 = (int) (IntPtr) num1;
              continue;
            case 20:
label_41:
              num1 = (short) 34;
              num2 = (int) (IntPtr) num1;
              continue;
            case 21:
              this.i(ref this.rptTable);
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
              continue;
            case 22:
              num1 = (short) 8;
              num2 = (int) (IntPtr) num1;
              continue;
            case 23:
              this.AddKeypadButton(ref this.rptTable);
              num1 = (short) 36;
              num2 = (int) (IntPtr) num1;
              continue;
            case 24:
              this.c(ref this.rptTable);
              num1 = (short) 0;
              num1 = (short) 23;
              num2 = (int) (IntPtr) num1;
              continue;
            case 25:
              num1 = (short) 29;
              num2 = (int) (IntPtr) num1;
              continue;
            case 26:
              if (!UtilityMack.IsWorldWidePro)
              {
                num1 = (short) 32 /*0x20*/;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 13;
              num2 = (int) (IntPtr) num1;
              continue;
            case 27:
              this.e(ref this.rptTable);
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 28:
              goto label_58;
            case 29:
              if (this.l != null)
              {
                num1 = (short) 30;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_58;
            case 30:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 31 /*0x1F*/:
              num1 = (short) -11061;
              int num3 = (int) num1;
              num1 = (short) -11061;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_45;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  if (((FeatureSection) this.a.ConventionalSwitches).HasVisibleObjects)
                  {
                    num1 = (short) 10;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_41;
              }
            case 32 /*0x20*/:
              if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("좈\uDB8A햌벎ꆐꎒꖔ", A_1)))
              {
                num1 = (short) 18;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 21;
              num2 = (int) (IntPtr) num1;
              continue;
            case 33:
              if (this.h != null)
              {
                num1 = (short) 27;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 6;
            case 34:
              if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("좈\uDB8A햌벎ꆐꎒꖔ", A_1)))
              {
                num1 = (short) 16 /*0x10*/;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 2;
            case 35:
              this.b(ref this.rptTable);
              num1 = (short) 25;
              num2 = (int) (IntPtr) num1;
              continue;
            case 36:
              if (this.j != null)
              {
                num1 = (short) 7;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 25;
            case 37:
              if (((Recordset) this.i).HasVisibleObjects)
              {
                num1 = (short) 24;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 23;
            default:
              goto label_3;
          }
        }
label_58:
        XMLRptDataObj.tables.Add(this.rptTable);
        this.AddZonesAndChannels(ref XMLRptDataObj);
        break;
    }
  }
}
