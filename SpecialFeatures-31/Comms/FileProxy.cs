// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.Comms.FileProxy
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using Motorola.Common.Communication.CommonUtil;
using Motorola.Common.Communication.Pba;
using SpecialFeatures.AcpReportManagerLib;
using SSLMangrComp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;

#nullable disable
namespace SpecialFeatures.Comms;

public class FileProxy : IDeviceProxy, IDisposable
{
  private string a;
  private PbaObject b;
  private AstroDeviceInfo c;
  private bool d;

  internal FileProxy(string deviceFile, AstroDeviceInfo info)
  {
    int A_1 = 13;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    Trace.WriteLine(RptMgrErrorHandler.b("쮏풑ﶓ歹ﶗ쪙\uEE9B\uF19D\uD89F\uDBA1念ﶥ\uE1A7쒩쪫솭슯\uDFB1햳습톷햹튻\uE3BD鮿胁ꇃꇅꇇ\uA4C9釋闍雏믑룓돕裗꣙돛ꛝ駟쫡蟣鋥蟧飩엫돭", A_1));
    this.a = deviceFile;
    this.c = info;
    this.b = this.a(this.a);
    Trace.WriteLine(RptMgrErrorHandler.b("쮏풑ﶓ歹ﶗ쪙\uEE9B\uF19D\uD89F\uDBA1念ﶥ\uE1A7쒩쪫솭슯\uDFB1햳습톷햹튻\uE3BD鮿蟁\uAAC3ꋅ闇釉請\uA7CD볏럑蓓ꓕ럗ꋙꗛ\uF6DD菟雡诣铥쇧럩", A_1));
  }

  public PbaObject Read(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator)
  {
    int A_1 = 5;
    short num1 = -30969;
    int num2 = (int) num1;
    num1 = (short) -30969;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (true)
          ;
        if (false)
          ;
        Trace.WriteLine(RptMgrErrorHandler.b("펇첉\uE58B\uE28D\uF58F슑\uE693秊\uE097\uE399솛얝\uE99F첡슣즥\uDAA7잩춫\uDAAD\uD9AF\uDDB1\uDAB3\uEBB5\uE3B7\uF8B9\uD9BB\uD9BDꦿ곁駃鷅髇꿉귋\uAACD跏", A_1));
        Trace.WriteLine(RptMgrErrorHandler.b("펇첉\uE58B\uE28D\uF58F슑\uE693秊\uE097\uE399솛얝\uE99F첡슣즥\uDAA7잩춫\uDAAD\uD9AF\uDDB1\uDAB3\uEBB5\uE3B7ﾹ튻\uDABD鶿駁雃ꏅ꧇껉釋", A_1));
        return this.b;
      default:
        goto case 1;
    }
  }

  public bool Write(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    int A_1 = 9;
    short num1 = -7241;
    int num2 = (int) num1;
    num1 = (short) -7241;
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
        Trace.WriteLine(RptMgrErrorHandler.b("힋좍憐ﺑ\uF193욕\uEA97\uF599\uE49B\uE79Dﶟ說\uEDA3좥캧얩\uDEAB쎭톯욱\uDDB3\uD9B5횷\uE7B9\uE7BBﲽꖿꗁ귃\uA8C5闇釉鯋볍맏ꛑ뇓试", A_1));
        this.b = targetPba;
        int num5 = this.a(this.b, this.a) ? 1 : 0;
        Trace.WriteLine(RptMgrErrorHandler.b("힋좍憐ﺑ\uF193욕\uEA97\uF599\uE49B\uE79Dﶟ說\uEDA3좥캧얩\uDEAB쎭톯욱\uDDB3\uD9B5횷\uE7B9\uE7BB﮽꺿ꛁ駃鷅鿇룉ꗋ뫍뗏近", A_1));
        return num5 != 0;
      default:
        goto case 1;
    }
  }

  public RadioParams ReadExtendedDeviceInfo()
  {
    int A_1 = 17;
    short num1 = -25913;
    int num2 = (int) num1;
    num1 = (short) -25913;
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
        Trace.WriteLine(RptMgrErrorHandler.b("쾓킕\uF197\uF699鍊캝튟춡\uDCA3\uDFA5\uF5A7\uF1A9\uE5AB삭횯\uDDB1욳\uDBB5\uD9B7캹햻톽꺿鿁鿃蓅귇귉ꗋꃍ跏觑蛓돕맗뻙駛ꛝ铟蟡諣若跧軩꣫语蛯鯱音鏵뇷铹髻釽巿", A_1));
        Trace.WriteLine(RptMgrErrorHandler.b("쾓킕\uF197\uF699鍊캝튟춡\uDCA3\uDFA5\uF5A7\uF1A9\uE5AB삭횯\uDDB1욳\uDBB5\uD9B7캹햻톽꺿鿁鿃菅ꛇ껉釋闍苏럑뗓닕鷗ꋙ\uA8DB믝軟蛡臣若곧迩髫蟭鏯韱뷳飵黷闹ꇻ", A_1));
        return this.c.WrapperRadioParams();
      default:
        goto case 1;
    }
  }

  public PbaObject ReadBlock(
    RadioParams radioPara,
    List<IshHeader> blockList,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    int A_1 = 11;
label_1:
    switch (0)
    {
      default:
        Trace.WriteLine(RptMgrErrorHandler.b("햍횏ﮑ\uF893\uF395좗\uE899\uF39B\uE69D\uD99Fﾡﾣ\uEFA5욧첩쎫\uDCAD\uDDAF펱삳\uDFB5ힷ풹\uE1BB\uE5BD芿\uA7C1ꏃ꿅ꛇ韉韋鳍뗏돑냓铕듗뗙뿛뗝뷟", A_1));
        PbaObject pbaObject = new PbaObject();
        try
        {
          using (List<IshHeader>.Enumerator enumerator1 = blockList.GetEnumerator())
          {
            short num1 = 0;
            int num2 = (int) (IntPtr) num1;
            while (true)
            {
              List<DataPartition>.Enumerator enumerator2;
              IshHeader current1;
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
                  try
                  {
                    num1 = (short) 4;
                    int num3 = (int) (IntPtr) num1;
                    while (true)
                    {
                      DataPartition dataPartition;
                      DataPartition current2;
                      List<DataPartition>.Enumerator enumerator3;
                      bool flag;
                      List<DataBlock>.Enumerator enumerator4;
                      switch (num3)
                      {
                        case 0:
                          if (!enumerator2.MoveNext())
                          {
                            num1 = (short) 2;
                            num3 = (int) (IntPtr) num1;
                            continue;
                          }
                          current2 = enumerator2.Current;
                          num1 = (short) 12;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 1:
                          enumerator4 = current2.DataBlocks.GetEnumerator();
                          num1 = (short) 3;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 2:
                        case 8:
                          num1 = (short) 13;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 3:
                          try
                          {
                            num1 = (short) 2;
                            int num4 = (int) (IntPtr) num1;
                            while (true)
                            {
                              DataBlock current3;
                              switch (num4)
                              {
                                case 0:
                                  num1 = (short) 6;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                case 1:
                                  num1 = (short) 3;
                                  num4 = (int) (IntPtr) num1;
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
                                  if (ushort.MaxValue == ((IshHeader) ref current1).IshID)
                                  {
                                    num1 = (short) 9;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  break;
                                case 4:
                                  if (enumerator4.MoveNext())
                                  {
                                    current3 = enumerator4.Current;
                                    num1 = (short) 10;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  num1 = (short) 8;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                case 5:
                                  if (((IshHeader) ref current1).IshID == ushort.MaxValue)
                                  {
                                    num1 = (short) 7;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  goto case 8;
                                case 6:
                                  if ((int) current3.BlockID != (int) ((IshHeader) ref current1).IshID)
                                  {
                                    num1 = (short) 1;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  goto case 9;
                                case 8:
                                  num1 = (short) 11;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                case 9:
                                  DataBlock dataBlock = new DataBlock();
                                  dataBlock.BlockType = current3.BlockType;
                                  dataBlock.BlockID = current3.BlockID;
                                  dataBlock.PacketValue = new byte[current3.PacketValue.Length];
                                  Array.Copy((Array) current3.PacketValue, (Array) dataBlock.PacketValue, current3.PacketValue.Length);
                                  dataBlock.LegthInBits = current3.LegthInBits;
                                  dataBlock.Offset = current3.Offset;
                                  dataPartition.DataBlocks.Add(dataBlock);
                                  num1 = (short) 5;
                                  num4 = (int) (IntPtr) num1;
                                  continue;
                                case 10:
                                  if ((int) current3.BlockType == (int) ((IshHeader) ref current1).IshType)
                                  {
                                    num1 = (short) 0;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  break;
                                case 11:
                                  goto label_40;
                              }
                              num1 = (short) 4;
                              num4 = (int) (IntPtr) num1;
                            }
                          }
                          finally
                          {
                            enumerator4.Dispose();
                          }
label_40:
                          num1 = (short) 7;
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
                        case 5:
                          if (dataPartition == null)
                          {
                            num1 = (short) 11;
                            num3 = (int) (IntPtr) num1;
                            continue;
                          }
                          goto case 1;
                        case 6:
                          flag = true;
                          dataPartition = (DataPartition) null;
                          enumerator3 = pbaObject.CodeplugData.DataPartitions.GetEnumerator();
                          num1 = (short) 9;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 7:
                          if (flag)
                          {
                            num1 = (short) 10;
                            num3 = (int) (IntPtr) num1;
                            continue;
                          }
                          goto case 2;
                        case 9:
                          try
                          {
                            num1 = (short) 1;
                            int num5 = (int) (IntPtr) num1;
                            while (true)
                            {
                              DataPartition current4;
                              switch (num5)
                              {
                                case 0:
                                  if (enumerator3.MoveNext())
                                  {
                                    current4 = enumerator3.Current;
                                    num1 = (short) 2;
                                    num5 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  num1 = (short) 3;
                                  num5 = (int) (IntPtr) num1;
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
                                  if ((int) current4.PartitionID == (int) ((IshHeader) ref current1).PartitionNumber)
                                  {
                                    num1 = (short) 4;
                                    num5 = (int) (IntPtr) num1;
                                    continue;
                                  }
                                  break;
                                case 3:
                                case 5:
                                  num1 = (short) 6;
                                  num5 = (int) (IntPtr) num1;
                                  continue;
                                case 4:
                                  flag = false;
                                  dataPartition = current4;
                                  num1 = (short) 5;
                                  num5 = (int) (IntPtr) num1;
                                  continue;
                                case 6:
                                  goto label_21;
                              }
                              num1 = (short) 0;
                              num5 = (int) (IntPtr) num1;
                            }
                          }
                          finally
                          {
                            enumerator3.Dispose();
                          }
label_21:
                          num3 = 5;
                          continue;
                        case 10:
                          pbaObject.CodeplugData.DataPartitions.Add(dataPartition);
                          num1 = (short) 8;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 11:
                          dataPartition = new DataPartition();
                          dataPartition.PartitionID = ((IshHeader) ref current1).PartitionNumber;
                          num1 = (short) 1;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        case 12:
                          if ((int) current2.PartitionID == (int) ((IshHeader) ref current1).PartitionNumber)
                          {
                            num1 = (short) 6;
                            num3 = (int) (IntPtr) num1;
                            continue;
                          }
                          break;
                        case 13:
                          goto label_11;
                      }
                      num1 = (short) 0;
                      num3 = (int) (IntPtr) num1;
                    }
                  }
                  finally
                  {
                    enumerator2.Dispose();
                  }
                case 2:
                  if (!enumerator1.MoveNext())
                  {
                    num1 = (short) 3;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  current1 = enumerator1.Current;
                  enumerator2 = this.b.CodeplugData.DataPartitions.GetEnumerator();
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 3:
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case 4:
                  goto label_70;
              }
label_11:
              num1 = (short) 2;
              num2 = (int) (IntPtr) num1;
            }
          }
label_70:
          Trace.WriteLine(RptMgrErrorHandler.b("햍횏ﮑ\uF893\uF395좗\uE899\uF39B\uE69D\uD99Fﾡﾣ\uF5A5\uDDA7즩쾫쮭쎯솱\uE9B3\uEDB5\uEAB7\uDFB9\uDDBB\uDABD芿껁ꯃꗅꏇ韉\uF6CB\uEECD菏\uA7D1럓뗕뷗꧙꿛", A_1));
        }
        catch (Exception ex)
        {
          Trace.WriteLine(RptMgrErrorHandler.b("햍횏ﮑ\uF893\uF395좗\uE899\uF39B\uE69D\uD99Fﾡﾣ\uE3A5킧즩즫\uDEAD쒯\uDBB1\uDBB3\uD8B5\uE5B7\uE1B9\uEEBB\uDBBDꆿꛁ蛃\uAAC5\uA7C7꧉\uA7CB鏍\uEACF\uF2D1", A_1) + ex.Message);
          return (PbaObject) null;
        }
        switch (true ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          default:
            if (true)
              ;
            short num = 1;
            if (num == (short) 0)
              ;
            num = (short) 0;
            Trace.WriteLine(RptMgrErrorHandler.b("햍횏ﮑ\uF893\uF395좗\uE899\uF39B\uE69D\uD99Fﾡﾣ\uEFA5욧첩쎫\uDCAD\uDDAF펱삳\uDFB5ힷ풹\uE1BB\uE5BD薿곁ꃃ鯅鏇飉꧋꿍듏郑룓맕믗뇙臛", A_1));
            return pbaObject;
        }
    }
  }

  private PbaObject a(string A_0)
  {
    int A_1 = 10;
    short num1 = 29198;
    int num2 = (int) num1;
    num1 = (short) 29198;
    int num3 = (int) num1;
    PbaObject pbaObject1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        Trace.WriteLine(RptMgrErrorHandler.b("회즎\uF890ﾒ\uF094잖\uEB98\uF49A\uE59C\uE69Eﲠ\uF8A2\uECA4즦쾨쒪\uDFAC슮킰잲\uDCB4\uD8B6ힸ\uE6BA\uE6BC諭꿀\uA7C2飄鳆藈\uA4CA곌ꯎ韐뫒맔닖蓘", A_1));
        return pbaObject1;
      default:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        Trace.WriteLine(RptMgrErrorHandler.b("회즎\uF890ﾒ\uF094잖\uEB98\uF49A\uE59C\uE69Eﲠ\uF8A2\uECA4즦쾨쒪\uDFAC슮킰잲\uDCB4\uD8B6ힸ\uE6BA\uE6BCﶾ꓀꓂계꧆铈郊臌ꃎ냐럒鏔뻖뗘뻚胜", A_1));
        PbaObject pbaObject2 = new PbaObject();
        try
        {
          pbaObject1 = PbaObject.DeserializeFrom(A_0);
          Trace.WriteLine(RptMgrErrorHandler.b("회즎\uF890ﾒ\uF094잖\uEB98\uF49A\uE59C\uE69Eﲠ\uF8A2\uF6A4튦쪨좪좬\uDCAE슰\uEEB2\uEEB4﮶횸\uDABA\uD9BC料ꣀ꿂ꃄ髆\uF3C8\uEBCA", A_1) + A_0);
          goto case 0;
        }
        catch (Exception ex)
        {
          Trace.WriteLine(RptMgrErrorHandler.b("회즎\uF890ﾒ\uF094잖\uEB98\uF49A\uE59C\uE69Eﲠ\uF8A2\uE0A4\uDFA6쪨캪\uDDAC\uDBAE\uD8B0\uDCB2\uDBB4\uEAB6\uE2B8\uF7BA튼\uDEBEꗀ藂계ꯆ곈雊\uF7CC\uEFCE", A_1) + ex.Message);
          return (PbaObject) null;
        }
    }
  }

  private bool a(PbaObject A_0, string A_1)
  {
    int A_1_1 = 3;
    short num1 = 7413;
    int num2 = (int) num1;
    num1 = (short) 7413;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        Trace.WriteLine(RptMgrErrorHandler.b("\uDD85캇\uE389\uE08B\uEB8D삏\uE091ﮓ\uEE95\uE197잙잛힝캟쒡쮣풥얧쮩\uD8AB잭\uDFAF\uDCB1\uE9B3\uEDB5ﶷ풹\uD8BB\uE3BD鮿闁뛃꿅볇꿉請\uA7CD볏럑觓", A_1_1));
        return true;
      default:
        if (true)
          ;
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        Trace.WriteLine(RptMgrErrorHandler.b("\uDD85캇\uE389\uE08B\uEB8D삏\uE091ﮓ\uEE95\uE197잙잛힝캟쒡쮣풥얧쮩\uD8AB잭\uDFAF\uDCB1\uE9B3\uEDB5覆\uDFB9\uDBBBힽ꺿鿁鿃釅뫇ꏉ룋ꯍ雏믑룓돕藗", A_1_1));
        try
        {
          A_0.Serialize(A_1);
          Trace.WriteLine(RptMgrErrorHandler.b("\uDD85캇\uE389\uE08B\uEB8D삏\uE091ﮓ\uEE95\uE197잙잛춝햟송잣쎥\uDBA7\uD9A9\uF1AB\uF5AD\uE7AF삱\uDDB3습\uDDB7ﲹ햻튽ꖿ鿁ﻃ\uE6C5", A_1_1) + A_1);
          goto case 0;
        }
        catch (Exception ex)
        {
          Trace.WriteLine(RptMgrErrorHandler.b("\uDD85캇\uE389\uE08B\uEB8D삏\uE091ﮓ\uEE95\uE197잙잛\uDB9D\uD89F송솣횥\uDCA7쎩쎫삭\uEDAF\uE9B1\uE3B3쒵톷캹\uD9BB\uF8BDꦿ껁ꇃ鯅\uF2C7\uEAC9", A_1_1) + ex.Message);
          return false;
        }
    }
  }

  public void UpdateDevice(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1 = 32238;
    int num2 = (int) num1;
    num1 = (short) 32238;
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
        throw new NotImplementedException();
      default:
        goto case 1;
    }
  }

  public void WriteLanguagePack(
    RadioParams radioParam,
    LanguagePackData languagePackData,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1 = 0;
    num1 = (short) -31461;
    int num2 = (int) num1;
    num1 = (short) -31461;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          break;
        break;
      default:
        goto case 1;
    }
  }

  public void ValidateUpdate(RadioParams radioPara, ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1 = 0;
    num1 = (short) -26849;
    int num2 = (int) num1;
    num1 = (short) -26849;
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
        throw new NotImplementedException();
      default:
        goto case 1;
    }
  }

  ~FileProxy()
  {
    try
    {
      short num1 = -13004;
      int num2 = (int) num1;
      num1 = (short) -13004;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          if (true)
            ;
          this.a(false);
          break;
        default:
          goto case 1;
      }
    }
    finally
    {
      // ISSUE: explicit finalizer call
      base.Finalize();
    }
    short num = 0;
    num = (short) 1;
    if (num == (short) 0)
      ;
  }

  public void Dispose()
  {
    short num1 = 0;
    num1 = (short) 28261;
    int num2 = (int) num1;
    num1 = (short) 28261;
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
        this.a(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  private void a(bool A_0)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
      num2 = (short) -15670;
      int num3 = (int) num2;
      num2 = (short) -15670;
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
          switch (num1)
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
              if (A_0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 2:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              goto label_9;
            case 4:
              this.a = (string) null;
              this.c = (AstroDeviceInfo) null;
              this.b = (PbaObject) null;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (!this.d)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
      }
    }
label_9:
    num2 = (short) 0;
label_13:
    this.d = true;
  }

  public PresenceNotification RetrievePresenceInfo(PNConnectionInfo connectionConfig)
  {
    short num1 = 0;
    num1 = (short) -23737;
    int num2 = (int) num1;
    num1 = (short) -23737;
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
        throw new NotImplementedException();
      default:
        goto case 1;
    }
  }

  public bool CBIProgram(RadioParams radioPara)
  {
    short num1 = 4937;
    int num2 = (int) num1;
    num1 = (short) 4937;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public bool ForceWrite(
    RadioParams radioPara,
    PbaObject targetPba,
    ProgressChangedEventHandler prgressIndicator = null)
  {
    short num1 = 32260;
    int num2 = (int) num1;
    num1 = (short) 32260;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public bool UpdateSN(RadioParams radioPara, string serialNumber)
  {
    short num1 = 12806;
    int num2 = (int) num1;
    num1 = (short) 12806;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public bool LoadTxmCertificate(RadioParams radioParam, string path)
  {
    short num1 = 28228;
    int num2 = (int) num1;
    num1 = (short) 28228;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public string QueryTxmCertificate(RadioParams radioParam, string path)
  {
    short num1 = 9033;
    int num2 = (int) num1;
    num1 = (short) 9033;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public bool ResetPassword(byte[] passwordResetFileContent)
  {
    short num1 = -23695;
    int num2 = (int) num1;
    num1 = (short) -23695;
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
        throw new NotImplementedException();
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  public bool CurrentRadioIsConnected
  {
    get
    {
      short num1 = 1;
      if (num1 == (short) 0)
        ;
      num1 = (short) 0;
      num1 = (short) -7179;
      int num2 = (int) num1;
      num1 = (short) -7179;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          return true;
        default:
          goto case 1;
      }
    }
  }
}
