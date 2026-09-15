// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.ReportsSerializeItems
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpUtility;
using CommonResources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Windows;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

[Serializable]
public sealed class ReportsSerializeItems : ISerializable
{
  internal Dictionary<string, int> sField = new Dictionary<string, int>();

  public ReportsSerializeItems()
  {
  }

  public void GetObjectData(SerializationInfo info, StreamingContext context)
  {
    int A_1 = 4;
    try
    {
      short num = -25864;
      switch ((short) -25864 == num)
      {
        case true:
          num = (short) 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          info.AddValue(RptMgrErrorHandler.b("힆ﮈ\uE28A\uE38Cﮎ얐\uF692\uF894\uE796\uF598漢\uE99C爵\uF7A0욢\uD7A4풦삨쒪쎬", A_1), 1);
          info.AddValue(RptMgrErrorHandler.b("햆\uEC88ﮊ\uE28Cﶎ\uE590햒\uF094\uF696\uED98\uEE9A\uEF9C爵", A_1), (object) this.sField);
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(AcpStringExtensions.AcpStringFormat(RptMgrErrorHandler.b("ﲆ릈\uF68A권ꊎ놐\uE892꒔\uEA96", A_1), new object[2]
      {
        (object) AppResources.Feature_Name_Error,
        (object) ex
      }));
    }
  }

  internal ReportsSerializeItems(SerializationInfo info, StreamingContext context)
  {
    int A_1 = 13;
    this.sField = new Dictionary<string, int>();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    if (info == null)
      throw new ArgumentNullException(RptMgrErrorHandler.b("憐ﲑ\uF293秊", A_1));
    try
    {
      Global.printTemplateVersion = (int) info.GetInt16(RptMgrErrorHandler.b("삏\uE091ﶓ\uF895\uEC97캙鍊\uF39D킟캡얣튥춧ﲩ즫\uDCAD쎯\uDBB1\uDBB3\uD8B5", A_1));
    }
    catch
    {
      Global.printTemplateVersion = 0;
    }
    try
    {
      info.GetString(RptMgrErrorHandler.b("슏\uF791\uE493秊\uEA97\uEE99\uDA9Bﮝ솟횡톣풥춧", A_1));
    }
    catch (Exception ex)
    {
      Trace.WriteLine(AcpStringExtensions.AcpStringFormat(RptMgrErrorHandler.b("횏\uF791\uF593\uE295\uED97\uE899鍊뺝\uEE9F쎡즣쎥袧\uEFA9\uDEAB\uDCAD\uDFAF삱钳鮵颷솹費쎽", A_1), new object[1]
      {
        (object) ex
      }));
    }
    try
    {
      this.sField = (Dictionary<string, int>) info.GetValue(RptMgrErrorHandler.b("슏\uF791\uE493秊\uEA97\uEE99\uDA9Bﮝ솟횡톣풥춧", A_1), typeof (Dictionary<string, int>));
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show(AcpStringExtensions.AcpStringFormat(RptMgrErrorHandler.b("\uEB8Fꊑ\uE993뚕떗몙\uE79B꾝\uDD9F", A_1), new object[2]
      {
        (object) AppResources.Feature_Name_Error,
        (object) ex
      }));
    }
  }
}
