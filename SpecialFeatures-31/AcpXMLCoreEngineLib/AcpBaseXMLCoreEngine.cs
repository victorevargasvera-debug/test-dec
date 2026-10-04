// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.ACPXMLCoreEngineLib.AcpBaseXMLCoreEngine
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using Common;
using CommonResources;
using ConstraintHelper;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.AcpXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Xml;

#nullable disable
namespace SpecialFeatures.ACPXMLCoreEngineLib;

public abstract class AcpBaseXMLCoreEngine
{
  protected _XMLData XMLRptDataObj;
  protected _table rptTable;
  protected _UIFields rptFields;

  protected AcpReports acpr
  {
    get
    {
      short num1 = -14401;
      int num2 = (int) num1;
      num1 = (short) -14401;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.a;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 25418;
      int num2 = (int) num1;
      num1 = (short) 25418;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.a = value;
          break;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
  }

  protected string cul
  {
    get
    {
      short num1 = -31588;
      int num2 = (int) num1;
      num1 = (short) -31588;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.b;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 13360;
      int num2 = (int) num1;
      num1 = (short) 13360;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.b = value;
          break;
        default:
          num1 = (short) 0;
          goto case 1;
      }
    }
  }

  protected CultureInfo ci
  {
    get
    {
      short num1 = -11125;
      int num2 = (int) num1;
      num1 = (short) -11125;
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
            ;
          return this.c;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 20173;
      int num2 = (int) num1;
      num1 = (short) 20173;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          this.c = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  protected bool isRTL
  {
    get
    {
      short num1 = 11931;
      int num2 = (int) num1;
      num1 = (short) 11931;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          short num4 = 0;
          num4 = (short) 1;
          if (num4 == (short) 0)
            ;
          num4 = (short) 0;
          if (num4 == (short) 0)
            ;
          return this.d;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -211;
      int num2 = (int) num1;
      num1 = (short) -211;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.d = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  protected string indexSeparator
  {
    get
    {
      short num1 = 0;
      num1 = (short) 948;
      int num2 = (int) num1;
      num1 = (short) 948;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          return this.e;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) -2807;
      int num2 = (int) num1;
      num1 = (short) -2807;
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
          this.e = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  protected _RecSet rptRec
  {
    get
    {
      short num1 = 32492;
      int num2 = (int) num1;
      num1 = (short) 32492;
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
          return this.f;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) -20286;
      int num2 = (int) num1;
      num1 = (short) -20286;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          this.f = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  protected _Value rptValue
  {
    get
    {
      short num = 17052;
      switch ((short) 17052 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          return this.g;
        default:
          goto case 1;
      }
    }
    set
    {
      short num1 = 0;
      num1 = (short) 29677;
      int num2 = (int) num1;
      num1 = (short) 29677;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          this.g = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  public AcpBaseXMLCoreEngine()
  {
    int A_1 = 14;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.XMLRptDataObj = new _XMLData();
    this.rptTable = new _table();
    this.acpr = new AcpReports();
    this.cul = AppInfoManager.ReportsLangSelection;
    this.ci = new CultureInfo(this.cul);
    this.isRTL = this.ci.TextInfo.IsRightToLeft;
    this.indexSeparator = RptMgrErrorHandler.b("붐", A_1);
    this.rptFields = new _UIFields();
    this.rptRec = new _RecSet();
    this.rptValue = new _Value();
  }

  public abstract void BuildDataTables(ref _XMLData XMLRptDataObj);

  public void BuildXMLfile(string XMLFileName, ref int inError)
  {
    int A_1 = 8;
    int num1 = 0;
    switch (num1)
    {
      default:
        CultureInfo culture;
        _XMLData XMLRptDataObj;
        string numberA8539UiValue;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            XMLRptDataObj = new _XMLData();
            XMLRptDataObj.PageTitle = UtilityMack.ProductModelId.Substring(0, 3) + RptMgrErrorHandler.b("ꮊ", A_1) + UtilityMack.ProductModelId.Substring(3) + RptMgrErrorHandler.b("ꮊ", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
            numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            string str;
            XmlTextWriter xmlTextWriter;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("쎊뒌붎", A_1)))
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 1:
                  goto label_10;
                case 2:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("잊", A_1)))
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 18;
                case 3:
                  XMLRptDataObj.PageTitle = RptMgrErrorHandler.b("쪊\uDD8C힎놐킒杖練\uEA98\uF49A\uF19C爵햠힢삤螦", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                case 19:
                  this.BuildDataTables(ref XMLRptDataObj);
                  xmlTextWriter = (XmlTextWriter) null;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (numberA8539UiValue.Contains(RptMgrErrorHandler.b("벊첌솎", A_1)))
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  XMLRptDataObj.PageTitle = RptMgrErrorHandler.b("\uDD8A햌꾎", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  str = RptMgrErrorHandler.b("\uDD8A햌ꊎ", A_1);
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("쎊뒌벎", A_1)))
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 12:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (Product.IsVertex())
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 14:
                  if (!numberA8539UiValue.Contains(RptMgrErrorHandler.b("붊첌솎", A_1)))
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 16 /*0x10*/;
                case 15:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("쎊벌몎쒐킒펔꺖즘첚ꮜ\uDE9E\uEFA0", A_1)))
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 16 /*0x10*/:
                  XMLRptDataObj.PageTitle = str + RptMgrErrorHandler.b("\uDB8A뒌뮎ꢐ뎒", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  str = RptMgrErrorHandler.b("\uDD8A\uE88Cﶎ\uE590\uF692\uED94랖쪘\uEF9Aﲜ\uF19E얠슢\uD7A4쎦蒨", A_1);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  if (!UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 12;
                case 21:
                  XMLRptDataObj.PageTitle = RptMgrErrorHandler.b("쪊\uDD8C힎놐\uDD92ꚔꞖ릘", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  XMLRptDataObj.PageTitle = RptMgrErrorHandler.b("쪊\uDD8C힎놐ꪒꖔꞖ릘", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uD98A\uEC8C\uEB8E\uF890ﲒ쪔\uDE96ﶘ", A_1), culture);
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_10:
            num2 = (short) 0;
            try
            {
              xmlTextWriter = new XmlTextWriter(XMLFileName, (Encoding) null);
              xmlTextWriter.Formatting = Formatting.Indented;
              xmlTextWriter.Indentation = 3;
              xmlTextWriter.WriteStartDocument();
              xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쾊\uEC8Cﮎ\uF090", A_1));
              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uDB8A\uEC8C\uE88E\uF490잒ﲔ\uE396\uF598ﺚ", A_1), XMLRptDataObj.PageTitle);
              using (List<_table>.Enumerator enumerator1 = XMLRptDataObj.tables.GetEnumerator())
              {
                num2 = (short) 0;
                int num3 = (int) (IntPtr) num2;
                while (true)
                {
                  List<string>.Enumerator enumerator2;
                  _table current1;
                  List<_RecSet>.Enumerator enumerator3;
                  switch (num3)
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
                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDF8A\uEC8C\uED8E\uFD90\uF692", A_1));
                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uDF8A\uEC8C\uED8E\uFD90\uF692\uDB94\uF696\uF498ﺚ", A_1), "");
                      num2 = (short) 5;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      try
                      {
                        num2 = (short) 0;
                        int num4 = (int) (IntPtr) num2;
                        while (true)
                        {
                          string current2;
                          switch (num4)
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
                              if (current2 == null)
                              {
                                num2 = (short) 5;
                                num4 = (int) (IntPtr) num2;
                                continue;
                              }
                              xmlTextWriter.WriteElementString(RptMgrErrorHandler.b("좊\uE28C\uE38E얐朗\uE194ﮖﲘ", A_1), current2);
                              num2 = (short) 4;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            case 3:
                              goto label_94;
                            case 5:
                              xmlTextWriter.WriteElementString(RptMgrErrorHandler.b("좊\uE28C\uE38E얐朗\uE194ﮖﲘ", A_1), "");
                              num2 = (short) 2;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            case 6:
                              num2 = (short) 3;
                              num4 = (int) (IntPtr) num2;
                              continue;
                            case 7:
                              if (enumerator2.MoveNext())
                              {
                                current2 = enumerator2.Current;
                                num2 = (short) 1;
                                num4 = (int) (IntPtr) num2;
                                continue;
                              }
                              num2 = (short) 6;
                              num4 = (int) (IntPtr) num2;
                              continue;
                          }
                          num2 = (short) 7;
                          num4 = (int) (IntPtr) num2;
                        }
                      }
                      finally
                      {
                        enumerator2.Dispose();
                      }
label_94:
                      xmlTextWriter.WriteEndElement();
                      enumerator3 = current1.RecSet.GetEnumerator();
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                    case 5:
                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDF8A\uEC8C\uED8E\uFD90\uF692\uDD94\uF296\uF898ﾚ\uF89C\uED9E", A_1));
                      enumerator2 = current1.ColTitle.GetEnumerator();
                      num2 = (short) 2;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      goto label_103;
                    case 7:
                      num2 = (short) 6;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 8:
                      try
                      {
                        num2 = (short) 1;
                        int num5 = (int) (IntPtr) num2;
                        while (true)
                        {
                          _RecSet current3;
                          List<_UIFields>.Enumerator enumerator4;
                          switch (num5)
                          {
                            case 0:
                              goto label_93;
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
                            case 6:
                              num2 = (short) 13;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 4:
                            case 12:
                              enumerator4 = current3.UIFields.GetEnumerator();
                              num2 = (short) 9;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 5:
                              if (current3.RecTitle == null)
                              {
                                num2 = (short) 7;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98A\uE88C\uEC8E얐朗\uE194ﮖﲘ", A_1), current3.RecTitle);
                              num2 = (short) 6;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 7:
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98A\uE88C\uEC8E얐朗\uE194ﮖﲘ", A_1), "");
                              num2 = (short) 2;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 8:
                              if (enumerator3.MoveNext())
                              {
                                current3 = enumerator3.Current;
                                xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uD98A\uE88C\uEC8E슐\uF692\uE194", A_1));
                                num2 = (short) 5;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              num2 = (short) 11;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 9:
                              try
                              {
                                num2 = (short) 0;
                                int num6 = (int) (IntPtr) num2;
                                while (true)
                                {
                                  List<_Value>.Enumerator enumerator5;
                                  _UIFields current4;
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
                                    case 2:
                                      try
                                      {
                                        num2 = (short) 0;
                                        int num7 = (int) (IntPtr) num2;
                                        while (true)
                                        {
                                          _Value current5;
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
                                              xmlTextWriter.WriteElementString(RptMgrErrorHandler.b("\uDD8A\uEC8C\uE38E\uE490\uF692", A_1), "");
                                              num2 = (short) 4;
                                              num7 = (int) (IntPtr) num2;
                                              continue;
                                            case 2:
                                              if (current5.FieldValue == null)
                                              {
                                                num2 = (short) 1;
                                                num7 = (int) (IntPtr) num2;
                                                continue;
                                              }
                                              xmlTextWriter.WriteElementString(RptMgrErrorHandler.b("\uDD8A\uEC8C\uE38E\uE490\uF692", A_1), AcpXMLCoreEngLib.convertToArabicFormat(current5.FieldValue));
                                              num2 = (short) 6;
                                              num7 = (int) (IntPtr) num2;
                                              continue;
                                            case 3:
                                              goto label_59;
                                            case 5:
                                              if (enumerator5.MoveNext())
                                              {
                                                current5 = enumerator5.Current;
                                                num2 = (short) 2;
                                                num7 = (int) (IntPtr) num2;
                                                continue;
                                              }
                                              num2 = (short) 16018;
                                              int num8 = (int) num2;
                                              num2 = (short) 16018;
                                              int num9 = (int) num2;
                                              switch (num8 == num9 ? 1 : 0)
                                              {
                                                case 0:
                                                case 2:
                                                  break;
                                                default:
                                                  num2 = (short) 0;
                                                  if (num2 == (short) 0)
                                                    ;
                                                  num2 = (short) 7;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                              }
                                              break;
                                            case 7:
                                              num2 = (short) 3;
                                              num7 = (int) (IntPtr) num2;
                                              continue;
                                          }
                                          num2 = (short) 5;
                                          num7 = (int) (IntPtr) num2;
                                        }
                                      }
                                      finally
                                      {
                                        enumerator5.Dispose();
                                      }
label_59:
                                      xmlTextWriter.WriteEndElement();
                                      xmlTextWriter.WriteEndElement();
                                      num6 = 1;
                                      continue;
                                    case 3:
                                      if (!enumerator4.MoveNext())
                                      {
                                        num2 = (short) 4;
                                        num6 = (int) (IntPtr) num2;
                                        continue;
                                      }
                                      current4 = enumerator4.Current;
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("춊\uE48C\uEA8E\uFD90\uF792", A_1));
                                      num2 = (short) 7;
                                      num6 = (int) (IntPtr) num2;
                                      continue;
                                    case 4:
                                      num2 = (short) 6;
                                      num6 = (int) (IntPtr) num2;
                                      continue;
                                    case 5:
                                    case 8:
                                      xmlTextWriter.WriteElementString(RptMgrErrorHandler.b("얊\uEC8C\uE28E\uF490", A_1), current4.UIFieldName);
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDD8A\uEC8C\uE38E\uE490\uF692\uE694", A_1));
                                      enumerator5 = current4.values.GetEnumerator();
                                      num2 = (short) 2;
                                      num6 = (int) (IntPtr) num2;
                                      continue;
                                    case 6:
                                      goto label_44;
                                    case 7:
                                      if (current4.UIFieldDes == null)
                                      {
                                        num2 = (short) 9;
                                        num6 = (int) (IntPtr) num2;
                                        continue;
                                      }
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춊\uE48C\uEA8E\uFD90\uF792톔\uF296\uEA98", A_1), current4.UIFieldDes);
                                      num2 = (short) 5;
                                      num6 = (int) (IntPtr) num2;
                                      continue;
                                    case 9:
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춊\uE48C\uEA8E\uFD90\uF792톔\uF296\uEA98", A_1), "");
                                      num2 = (short) 8;
                                      num6 = (int) (IntPtr) num2;
                                      continue;
                                  }
                                  num2 = (short) 3;
                                  num6 = (int) (IntPtr) num2;
                                }
                              }
                              finally
                              {
                                enumerator4.Dispose();
                              }
label_44:
                              xmlTextWriter.WriteEndElement();
                              num2 = (short) 3;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 10:
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98A\uE88C\uEC8E\uDF90ﲒ", A_1), "");
                              num2 = (short) 12;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 11:
                              num2 = (short) 0;
                              num5 = (int) (IntPtr) num2;
                              continue;
                            case 13:
                              if (current3.RecNo == null)
                              {
                                num2 = (short) 10;
                                num5 = (int) (IntPtr) num2;
                                continue;
                              }
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98A\uE88C\uEC8E\uDF90ﲒ", A_1), current3.RecNo);
                              num2 = (short) 4;
                              num5 = (int) (IntPtr) num2;
                              continue;
                          }
                          num2 = (short) 8;
                          num5 = (int) (IntPtr) num2;
                        }
                      }
                      finally
                      {
                        enumerator3.Dispose();
                      }
label_93:
                      xmlTextWriter.WriteEndElement();
                      num2 = (short) 3;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 9:
                      if (enumerator1.MoveNext())
                      {
                        current1 = enumerator1.Current;
                        num2 = (short) 10;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 7;
                      num3 = (int) (IntPtr) num2;
                      continue;
                    case 10:
                      if (current1.TableTitle != null)
                      {
                        xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDF8A\uEC8C\uED8E\uFD90\uF692", A_1));
                        xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uDF8A\uEC8C\uED8E\uFD90\uF692\uDB94\uF696\uF498ﺚ", A_1), current1.TableTitle);
                        num2 = (short) 4;
                        num3 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 1;
                      num3 = (int) (IntPtr) num2;
                      continue;
                  }
                  num2 = (short) 9;
                  num3 = (int) (IntPtr) num2;
                }
              }
label_103:
              xmlTextWriter.WriteEndElement();
              return;
            }
            catch (Exception ex)
            {
              int num10 = (int) MessageBox.Show(ex.Message);
              inError = 1;
              return;
            }
            finally
            {
              int num11 = 0;
              while (true)
              {
                short num12;
                switch (num11)
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
                    goto label_111;
                  case 2:
                    xmlTextWriter.Close();
                    num12 = (short) 1;
                    num11 = (int) (IntPtr) num12;
                    continue;
                }
                if (xmlTextWriter != null)
                {
                  num12 = (short) 2;
                  num11 = (int) (IntPtr) num12;
                }
                else
                  break;
              }
label_111:;
            }
        }
    }
  }
}
