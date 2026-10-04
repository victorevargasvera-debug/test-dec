// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Clone_Configuration.Common.AstroRecSetCounts
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpBusinessLayer;
using AcpCommonLib;
using Motorola.MackinawCPS.CoreFeatures.ASTROTalkgroupList;
using Motorola.MackinawCPS.CoreFeatures.ConventionalSystem;
using Motorola.MackinawCPS.CoreFeatures.RadioProfiles;
using Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile;
using Motorola.MackinawCPS.CoreFeatures.SecureWide;
using Motorola.MackinawCPS.CoreFeatures.TrunkingPersonality;
using Motorola.MackinawCPS.CoreFeatures.TrunkingSystem;
using Motorola.MackinawCPS.CoreFeatures.ZoneChannelAssignment;
using SpecialFeatures.AcpReportManagerLib;
using SpecialFeatures.Ucl.Contact;
using SpecialFeatures.VoiceAnnouncements.List;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Xml;

#nullable disable
namespace SpecialFeatures.Clone_Configuration.Common;

public static class AstroRecSetCounts
{
  public static XmlDocument GetXmlDocument(string xmlData)
  {
    XmlDocument xmlDocument = (XmlDocument) null;
label_1:
    try
    {
      StringReader input = new StringReader(xmlData);
      try
      {
        XmlTextReader reader = new XmlTextReader((TextReader) input);
        xmlDocument = new XmlDocument();
        xmlDocument.Load((XmlReader) reader);
      }
      finally
      {
        int num1 = 2;
        while (true)
        {
          short num2;
          switch (num1)
          {
            case 0:
              input.Dispose();
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_9;
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
          if (input != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
          }
          else
            break;
        }
label_9:;
      }
      short num3 = 32143;
      int num4 = (int) num3;
      num3 = (short) 32143;
      int num5 = (int) num3;
      switch (num4 == num5 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_1;
        default:
          num3 = (short) 0;
          if (num3 == (short) 0)
            break;
          break;
      }
    }
    catch
    {
      xmlDocument = (XmlDocument) null;
    }
    if (false)
      ;
    return xmlDocument;
  }

  public static System.Collections.Generic.List<AstroRecSetCountsItem> LoadRecSetItemsFromXml(
    string xmlData)
  {
    int num1;
    System.Collections.Generic.List<AstroRecSetCountsItem> recSetCountsItemList;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        recSetCountsItemList = (System.Collections.Generic.List<AstroRecSetCountsItem>) null;
        num2 = (short) -27483;
        int num3 = (int) num2;
        num2 = (short) -27483;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          case 1:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            goto label_1;
          default:
            num2 = (short) 0;
            goto case 1;
        }
      default:
        while (true)
        {
          XmlDocument xmlDocument;
          switch (num1)
          {
            case 0:
              if (xmlDocument != null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 1:
              goto label_13;
            case 2:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              recSetCountsItemList = AstroRecSetCounts.LoadRecSetItemsFromXml(xmlDocument);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              xmlDocument = AstroRecSetCounts.GetXmlDocument(xmlData);
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              if (!string.IsNullOrEmpty(xmlData))
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            default:
              goto label_2;
          }
label_1:;
        }
label_13:
        return recSetCountsItemList;
    }
  }

  public static System.Collections.Generic.List<AstroRecSetCountsItem> LoadRecSetItemsFromXml(
    XmlDocument doc)
  {
    int A_1 = 18;
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    switch (num1)
    {
      default:
        num1 = (short) 0;
        int count = 0;
        int maxpool = 0;
        int countToMaxPool = 0;
        int instance = 0;
        System.Collections.Generic.List<AstroRecSetCountsItem> recSetCountsItemList = (System.Collections.Generic.List<AstroRecSetCountsItem>) null;
        try
        {
          num1 = (short) 3;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            IEnumerator enumerator1;
            switch (num2)
            {
              case 0:
                IDisposable disposable;
                try
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  while (true)
                  {
                    IEnumerator enumerator2;
                    string recsetName;
                    switch (num2)
                    {
                      case 0:
                        try
                        {
                          num1 = (short) 2;
                          num2 = (int) (IntPtr) num1;
                          while (true)
                          {
                            XmlAttribute attribute;
                            switch (num2)
                            {
                              case 1:
                              case 3:
                                AstroRecSetCountsItem recSetCountsItem = new AstroRecSetCountsItem(recsetName, instance, count, maxpool, countToMaxPool);
                                recSetCountsItemList.Add(recSetCountsItem);
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
                              case 4:
                                num1 = (short) 7;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              case 5:
                                if (attribute != null)
                                {
                                  num1 = (short) 8;
                                  num2 = (int) (IntPtr) num1;
                                  continue;
                                }
                                countToMaxPool = 0;
                                num1 = (short) 1;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              case 6:
                                if (enumerator2.MoveNext())
                                {
                                  num1 = (short) 9;
                                  num2 = (int) (IntPtr) num1;
                                  continue;
                                }
                                num1 = (short) 4;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              case 7:
                                goto label_12;
                              case 8:
                                countToMaxPool = int.Parse(attribute.Value, (IFormatProvider) CultureInfo.InvariantCulture);
                                num1 = (short) 3;
                                num2 = (int) (IntPtr) num1;
                                continue;
                              case 9:
                                XmlNode current = (XmlNode) enumerator2.Current;
                                attribute = current.Attributes[RptMgrErrorHandler.b("\uDC94\uF396", A_1)];
                                instance = attribute == null ? 0 : int.Parse(attribute.Value, (IFormatProvider) CultureInfo.InvariantCulture);
                                attribute = current.Attributes[RptMgrErrorHandler.b("횔\uF896\uEC98\uF59A\uE99C", A_1)];
                                count = attribute == null ? 0 : int.Parse(attribute.Value, (IFormatProvider) CultureInfo.InvariantCulture);
                                attribute = current.Attributes[RptMgrErrorHandler.b("\uD894\uF696\uE198쮚\uF29C\uF09E춠", A_1)];
                                maxpool = attribute == null ? 0 : int.Parse(attribute.Value, (IFormatProvider) CultureInfo.InvariantCulture);
                                attribute = current.Attributes[RptMgrErrorHandler.b("횔\uF896\uEC98\uF59A\uE99C爵펠\uF7A2쪤\uEAA6좨펪ﶬ삮\uDEB0\uDFB2", A_1)];
                                num1 = (short) 5;
                                num2 = (int) (IntPtr) num1;
                                continue;
                            }
                            num1 = (short) 6;
                            num2 = (int) (IntPtr) num1;
                          }
                        }
                        finally
                        {
                          short num3;
                          switch (0)
                          {
                            case 0:
label_31:
                              disposable = enumerator2 as IDisposable;
                              num3 = (short) 2;
                              num2 = (int) (IntPtr) num3;
                              goto default;
                            default:
                              while (true)
                              {
                                switch (num2)
                                {
                                  case 0:
                                    num3 = (short) 29924;
                                    int num4 = (int) num3;
                                    num3 = (short) 29924;
                                    int num5 = (int) num3;
                                    switch (num4 == num5 ? 1 : 0)
                                    {
                                      case 0:
                                      case 2:
                                        disposable.Dispose();
                                        num3 = (short) 1;
                                        num2 = (int) (IntPtr) num3;
                                        continue;
                                      default:
                                        num3 = (short) 0;
                                        if (num3 == (short) 0)
                                          goto case 0;
                                        goto case 0;
                                    }
                                  case 1:
                                    goto label_37;
                                  case 2:
                                    if (disposable != null)
                                    {
                                      num3 = (short) 0;
                                      num2 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto label_37;
                                  default:
                                    goto label_31;
                                }
                              }
label_37:;
                          }
                        }
                      case 1:
                        num1 = (short) 2;
                        num2 = (int) (IntPtr) num1;
                        continue;
                      case 2:
                        goto label_47;
                      case 3:
                        if (!enumerator1.MoveNext())
                        {
                          num1 = (short) 1;
                          num2 = (int) (IntPtr) num1;
                          continue;
                        }
                        XmlNode current1 = (XmlNode) enumerator1.Current;
                        recsetName = current1.Attributes[RptMgrErrorHandler.b("ﮔ\uF696\uF498ﺚ", A_1)].Value.Trim();
                        enumerator2 = current1.ChildNodes.GetEnumerator();
                        num1 = (short) 0;
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
label_12:
                    num2 = 3;
                  }
                }
                finally
                {
                  short num6;
                  switch (0)
                  {
                    case 0:
label_42:
                      disposable = enumerator1 as IDisposable;
                      num6 = (short) 2;
                      num2 = (int) (IntPtr) num6;
                      goto default;
                    default:
                      while (true)
                      {
                        switch (num2)
                        {
                          case 0:
                            disposable.Dispose();
                            num6 = (short) 1;
                            num2 = (int) (IntPtr) num6;
                            continue;
                          case 1:
                            goto label_46;
                          case 2:
                            if (disposable != null)
                            {
                              num6 = (short) 0;
                              num2 = (int) (IntPtr) num6;
                              continue;
                            }
                            goto label_46;
                          default:
                            goto label_42;
                        }
                      }
label_46:;
                  }
                }
              case 1:
                goto label_49;
              case 2:
                recSetCountsItemList = new System.Collections.Generic.List<AstroRecSetCountsItem>();
                enumerator1 = doc.ChildNodes[1].LastChild.ChildNodes.GetEnumerator();
                num1 = (short) 0;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                switch (0)
                {
                  case 0:
                    goto label_6;
                  default:
                    continue;
                }
              default:
label_6:
                if (doc != null)
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
            }
label_47:
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
          }
        }
        catch (Exception ex)
        {
          recSetCountsItemList.Clear();
          recSetCountsItemList = (System.Collections.Generic.List<AstroRecSetCountsItem>) null;
        }
label_49:
        return recSetCountsItemList;
    }
  }

  public static XmlDocument LoadRecSetItemsToXmlDoc(System.Collections.Generic.List<AstroRecSetCountsItem> recSetItems)
  {
    int A_1 = 11;
    switch (0)
    {
      default:
        XmlDocument xmlDoc = (XmlDocument) null;
        try
        {
          int num1 = 2;
          short num2;
          XmlElement element1;
          int index;
          XmlElement element2;
          int num3;
          System.Collections.Generic.List<AstroRecSetCountsItem>.Enumerator enumerator;
          AstroRecSetCountsItem item;
          while (true)
          {
            switch (num1)
            {
              case 0:
                if (index >= recSetItems.Count)
                {
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                item = recSetItems[index];
                element2 = xmlDoc.CreateElement(RptMgrErrorHandler.b("\uDC8D\uF58F\uF191\uE793\uF395\uEC97", A_1));
                element2.SetAttribute(RptMgrErrorHandler.b("\uE08D\uF18Fﾑ\uF193", A_1), item._recSetName.Trim());
                element1.AppendChild((XmlNode) element2);
                System.Collections.Generic.List<AstroRecSetCountsItem> all = recSetItems.FindAll((Predicate<AstroRecSetCountsItem>) (x =>
                {
                  short num4 = 1649;
                  int num5 = (int) num4;
                  num4 = (short) 1649;
                  int num6 = (int) num4;
                  switch (num5 == num6)
                  {
                    case true:
                      short num7 = 1;
                      if (num7 == (short) 0)
                        ;
                      num7 = (short) 0;
                      num7 = (short) 0;
                      if (num7 == (short) 0)
                        ;
                      return x._recSetName == item._recSetName;
                    default:
                      goto case 1;
                  }
                }));
                num3 = 0;
                enumerator = all.GetEnumerator();
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              case 1:
                xmlDoc = new XmlDocument();
                xmlDoc.AppendChild((XmlNode) xmlDoc.CreateXmlDeclaration(RptMgrErrorHandler.b("뾍뺏ꊑ", A_1), RptMgrErrorHandler.b("\uDB8D쒏풑릓꺕", A_1), (string) null));
                XmlElement element3 = xmlDoc.CreateElement(RptMgrErrorHandler.b("쾍\uE38F\uE691\uE693秊쪗ﾙﾛ\uED9D얟횡\uE7A3즥\uDDA7쒩\uD8AB\uDDAD", A_1));
                xmlDoc.AppendChild((XmlNode) element3);
                XmlElement element4 = xmlDoc.CreateElement(RptMgrErrorHandler.b("\uD88D\uF58F\uE091\uE793ﾕ\uF797\uF499", A_1));
                element4.InnerText = RptMgrErrorHandler.b("뾍", A_1);
                element3.AppendChild((XmlNode) element4);
                element1 = xmlDoc.CreateElement(RptMgrErrorHandler.b("\uDC8Dﾏ\uFD91\uE093", A_1));
                element3.AppendChild((XmlNode) element1);
                index = 0;
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                switch (0)
                {
                  case 0:
                    goto label_5;
                  default:
                    continue;
                }
              case 3:
                if (recSetItems.Count > 0)
                {
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 6;
              case 4:
                try
                {
                  num2 = (short) 6;
                  int num8 = (int) (IntPtr) num2;
                  while (true)
                  {
                    XmlElement element5;
                    AstroRecSetCountsItem current;
                    switch (num8)
                    {
                      case 0:
                        if (current._counterToMaxPool != 0)
                        {
                          num2 = (short) 10;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 3;
                      case 1:
                        goto label_8;
                      case 2:
                        num2 = (short) 12;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 3:
                        num2 = (short) 9522;
                        int num9 = (int) num2;
                        num2 = (short) 9522;
                        int num10 = (int) num2;
                        switch (num9 == num10 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            goto label_30;
                          default:
                            num2 = (short) 0;
                            if (num2 == (short) 0)
                              ;
                            element2.AppendChild((XmlNode) element5);
                            ++num3;
                            num2 = (short) 13;
                            num8 = (int) (IntPtr) num2;
                            continue;
                        }
                      case 4:
                        num2 = (short) 0;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 5:
                        if (current._count != 0)
                        {
                          num2 = (short) 7;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 2;
                      case 6:
                        switch (0)
                        {
                          case 0:
                            break;
                          default:
                            continue;
                        }
                        break;
                      case 7:
label_30:
                        element5.SetAttribute(RptMgrErrorHandler.b("춍ﾏ\uE791望\uE295", A_1), current._count.ToString((IFormatProvider) CultureInfo.InvariantCulture));
                        num2 = (short) 2;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 8:
                        element5.SetAttribute(RptMgrErrorHandler.b("쎍\uF18F\uEA91쒓秊\uF797\uF699", A_1), current._maxPool.ToString((IFormatProvider) CultureInfo.InvariantCulture));
                        num2 = (short) 4;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 9:
                        num2 = (short) 1;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 10:
                        element5.SetAttribute(RptMgrErrorHandler.b("춍ﾏ\uE791望\uE295ﶗ\uE899좛\uF19D\uED9F쎡\uDCA3\uF6A5잧얩삫", A_1), current._counterToMaxPool.ToString((IFormatProvider) CultureInfo.InvariantCulture));
                        num2 = (short) 3;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 11:
                        if (!enumerator.MoveNext())
                        {
                          num2 = (short) 9;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        }
                        current = enumerator.Current;
                        element5 = xmlDoc.CreateElement(RptMgrErrorHandler.b("삍ﾏ\uF691\uF193", A_1));
                        element5.SetAttribute(RptMgrErrorHandler.b("잍\uF48F", A_1), num3.ToString((IFormatProvider) CultureInfo.InvariantCulture));
                        num2 = (short) 5;
                        num8 = (int) (IntPtr) num2;
                        continue;
                      case 12:
                        if (current._maxPool != 0)
                        {
                          num2 = (short) 8;
                          num8 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 4;
                    }
                    num2 = (short) 11;
                    num8 = (int) (IntPtr) num2;
                  }
                }
                finally
                {
                  enumerator.Dispose();
                }
label_8:
                recSetItems.RemoveAll((Predicate<AstroRecSetCountsItem>) (x =>
                {
                  short num11 = 662;
                  int num12 = (int) num11;
                  num11 = (short) 662;
                  int num13 = (int) num11;
                  switch (num12 == num13)
                  {
                    case true:
                      short num14 = 1;
                      if (num14 == (short) 0)
                        ;
                      num14 = (short) 0;
                      num14 = (short) 0;
                      if (num14 == (short) 0)
                        ;
                      return x._recSetName == item._recSetName;
                    default:
                      goto case 1;
                  }
                }));
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              case 5:
              case 8:
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 6:
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              case 7:
                goto label_41;
              case 9:
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              default:
label_5:
                if (recSetItems != null)
                {
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 6;
            }
          }
        }
        catch (Exception ex)
        {
          xmlDoc = (XmlDocument) null;
        }
label_41:
        short num = 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        return xmlDoc;
    }
  }

  public static string PopulateAstroRecSetCounts()
  {
    int A_1 = 5;
    int num1 = 0;
    switch (num1)
    {
      default:
        string str;
        System.Collections.Generic.List<AstroRecSetCountsItem> recSetItems;
        RadioProfilesRecset feature1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            str = (string) null;
            recSetItems = new System.Collections.Generic.List<AstroRecSetCountsItem>();
            feature1 = FeatureManager.GetFeature(2077) as RadioProfilesRecset;
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator<FeatureNode> enumerator;
              int num3;
              EncryptionKeyListInnerRecset embeddedRecset1;
              TrunkingSystemRecset feature2;
              UclContactRecset feature3;
              ZoneChannelAssignmentRecset feature4;
              SecureKMFProfileRecset feature5;
              XmlDocument xmlDoc;
              VoiceAnnouncementListRecSet feature6;
              ASTROTalkgroupListRecset feature7;
              ChannelAssignmentListInnerRecset embeddedRecset2;
              TrunkingPersonalityRecset feature8;
              ConventionalSystemRecset feature9;
              switch (num1)
              {
                case 0:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("즇\uD989\uD88B\uDC8D\uDF8F욑\uF593歹\uF397ﶙ\uEE9B\uF19D햟튡\uE8A3쾥\uDBA7\uDEA9ﺫ쮭펯솱톳습", A_1), 0, ((Recordset) feature7).Count, 0, 0));
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  embeddedRecset2 = FeatureManager.GetFeature(2051)[0][10114].EmbeddedRecset as ChannelAssignmentListInnerRecset;
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  feature8 = FeatureManager.GetFeature(2072) as TrunkingPersonalityRecset;
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("쮇\uE589\uE28B\uF88D\uF58Fﲑ\uE093ﾕ\uF797\uF499ﶛ\uF29D\uF39F\uDBA1힣튥춧잩ﺫ쮭펯솱톳습", A_1), 0, ((Recordset) feature9).Count, 0, 0));
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (xmlDoc != null)
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_70;
                case 5:
                  if (feature9 != null)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 2;
                case 6:
                  feature6 = FeatureManager.GetFeature(2300) as VoiceAnnouncementListRecSet;
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  goto label_70;
                case 8:
                  embeddedRecset1 = ((Recordset) (FeatureManager.GetFeature(2021) as SecureWideRecset))[0][10040].EmbeddedRecset as EncryptionKeyListInnerRecset;
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    break;
                  break;
                case 10:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDD87\uE989\uE08B춍ﾏﲑ\uE093\uF795ﮗ\uEE99캛ﮝ쎟톡솣튥", A_1), 0, feature3.Count, 0, 0));
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (feature6 != null)
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 12:
                  try
                  {
                    num2 = (short) 3;
                    int num4 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num4)
                      {
                        case 0:
                          num2 = (short) 1;
                          num4 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          goto label_66;
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
                          if (enumerator.MoveNext())
                          {
                            SecureHardwareEncryptionKeyReferencesListInnerRecset embeddedRecset3 = ((FeatureSection) ((Motorola.MackinawCPS.CoreFeatures.SecureKMFProfile.SecureKMFProfile) enumerator.Current).SecureHardwareEncryptionKeyReferencesList).EmbeddedRecset as SecureHardwareEncryptionKeyReferencesListInnerRecset;
                            recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDB87\uEF89\uEF8Bﮍ\uE28F\uF791\uDC93\uF795\uEA97ﺙ\uEB9Bﾝ튟잡\uE1A3좥쮧\uD8A9햫\uDEAD쒯\uDBB1\uDBB3\uD8B5\uF3B7\uDFB9얻\uECBDꖿ꓁ꇃ듅귇\uA4C9꿋ꯍꏏ黑뷓ꗕ곗鏙닛냝藟郡뛣菥诧駩觫髭", A_1), num3++, ((Recordset) embeddedRecset3).Count, 0, 0));
                            num2 = (short) 2;
                            num4 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 0;
                          num4 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 4;
                      num4 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num5 = 1;
                    int num6 = (int) (IntPtr) num5;
                    while (true)
                    {
                      switch (num6)
                      {
                        case 0:
                          goto label_23;
                        case 1:
                          num5 = (short) 14075;
                          int num7 = (int) num5;
                          num5 = (short) 14075;
                          int num8 = (int) num5;
                          switch (num7 == num8 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              break;
                            default:
                              num5 = (short) 0;
                              if (num5 == (short) 0)
                                ;
                              switch (0)
                              {
                                case 0:
                                  goto label_19;
                                default:
                                  continue;
                              }
                          }
                          break;
                        case 2:
                          enumerator.Dispose();
                          break;
                        default:
label_19:
                          if (enumerator != null)
                          {
                            num5 = (short) 2;
                            num6 = (int) (IntPtr) num5;
                            continue;
                          }
                          goto label_23;
                      }
                      num5 = (short) 0;
                      num6 = (int) (IntPtr) num5;
                    }
label_23:;
                  }
                case 13:
                  xmlDoc = AstroRecSetCounts.LoadRecSetItemsToXmlDoc(recSetItems);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("쮇\uE289\uED8B\uE08Dﺏ\uF791\uF893힕\uEB97\uE999\uF59B劣캟쾡솣좥\uDCA7\uE6A9얫\uDDAD쒯ﮱ\uDAB3\uD8B5\uDDB7좹\uEEBB\uDBBDꎿ뇁ꇃ닅", A_1), 0, 0, ((Recordset) embeddedRecset2).MaxPool, ((Recordset) embeddedRecset2).CounterToMaxPool));
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  feature2 = FeatureManager.GetFeature(2064) as TrunkingSystemRecset;
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (feature1 != null)
                  {
                    num2 = (short) 0;
                    num2 = (short) 34;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 17:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDC87\uF889曆\uE08Dﮏﮑ望\uF195쮗\uE399\uEF9B\uEA9D얟쾡\uF6A3쎥쮧\uD9A9즫\uDAAD", A_1), 0, ((Recordset) feature2).Count, 0, 0));
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (feature5 != null)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_66;
                case 19:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("튇\uE589\uE28B\uEB8D펏晴\uF593\uF895\uF697ﾙ\uF09B\uDF9D펟톡춣솥욧잩즫삭쒯\uE0B1톳햵쮷\uDFB9좻", A_1), 0, ((Recordset) feature4).Count, 0, 0));
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  feature9 = FeatureManager.GetFeature(2053) as ConventionalSystemRecset;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (feature4 != null)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 15;
                case 22:
                  str = xmlDoc.InnerXml;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDE87\uE589\uE58B\uED8D\uF58F펑望\uF895\uF797\uEF99\uF29Bﶝ얟쾡솣좥\uDCA7\uE6A9얫\uDDAD쒯\uE0B1톳햵\uEBB7\uDFB9좻", A_1), 0, feature6.Count, 0, 0));
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  if (feature3 != null)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 1;
                case 25:
                  if (feature8 != null)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 6;
                case 26:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDC87\uF889曆\uE08Dﮏﮑ望\uF195좗ﾙ\uEE9B\uED9D쾟첡얣쪥솧\uDEA9햫ﲭ햯톱잳펵첷", A_1), 0, ((Recordset) feature8).Count, 0, 0));
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  num3 = 0;
                  enumerator = ((Collection<FeatureNode>) feature5).GetEnumerator();
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  if (embeddedRecset1 != null)
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 29:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("춇\uE489\uEF8Bﲍ\uE98F\uE291\uE093ﾕ\uF797\uF499힛ﮝ\uD99F\uEEA1춣향\uDCA7\uE3A9슫삭햯삱\uE6B3펵\uDBB7즹\uD9BB쪽", A_1), 0, ((Recordset) embeddedRecset1).Count, 0, 0));
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  if (feature7 != null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 31 /*0x1F*/:
                  feature5 = FeatureManager.GetFeature(2055) as SecureKMFProfileRecset;
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  if (feature2 != null)
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 33:
                  if (embeddedRecset2 != null)
                  {
                    num2 = (short) 14;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 13;
                case 34:
                  recSetItems.Add(new AstroRecSetCountsItem(RptMgrErrorHandler.b("\uDA87\uEB89\uE88B\uE78Dﾏ슑\uE693秊ﺗ\uF399\uF09Bﮝ펟\uF0A1솣얥\uDBA7쾩\uD8AB", A_1), 0, ((Recordset) feature1).Count, 0, 0));
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 35:
                  feature4 = FeatureManager.GetFeature(2051) as ZoneChannelAssignmentRecset;
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              feature7 = FeatureManager.GetFeature(2062) as ASTROTalkgroupListRecset;
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
label_66:
              feature3 = FeatureManager.GetFeature(2200) as UclContactRecset;
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
            }
label_70:
            return str;
        }
    }
  }
}
