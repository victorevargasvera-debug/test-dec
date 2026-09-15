// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.ReportFileItem
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using System;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

internal static class ReportFileItem
{
  public static string GetFileNameByRptType(reportType rptType)
  {
    int A_1 = 5;
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          goto label_17;
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
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      switch (rptType)
      {
        case reportType.RadioInfo:
          goto label_9;
        case reportType.HandOut:
          goto label_16;
        case reportType.HandOutO2:
          goto label_15;
        case reportType.HandOutO3:
          goto label_6;
        case reportType.HandOutO7:
          goto label_12;
        case reportType.HandOutO5:
          goto label_10;
        case reportType.HandOutO9:
          goto label_13;
        case reportType.Choices:
          goto label_17;
        case reportType.HandOutE5:
          goto label_5;
        default:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_5:
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uEBAD薯", A_1);
label_6:
    num2 = (short) 3726;
    int num3 = (int) num2;
    num2 = (short) 3726;
    int num4 = (int) num2;
    switch (num3 == num4 ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_17;
      default:
        num2 = (short) 0;
        if (num2 == (short) 0)
          ;
        return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uE1AD莯", A_1);
    }
label_9:
    return RptMgrErrorHandler.b("\uDA87\uEB89\uE88B\uE78Dﾏ\uDB91望\uF095\uF797\uDC99\uF09B\uF19D힟\uE6A1쮣얥\uDDA7잩즫삭쒯", A_1);
label_10:
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uE1AD薯", A_1);
label_12:
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uE1AD螯", A_1);
label_13:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uE1AD覯", A_1);
label_15:
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB\uE1AD芯", A_1);
label_16:
    return RptMgrErrorHandler.b("삇\uEB89\uE28B\uEA8D\uDF8F\uE791\uE093킕\uF497\uF599\uEB9B\uDA9D쾟송톣쮥춧쒩\uD8AB", A_1);
label_17:
    num2 = (short) 0;
    return string.Empty;
  }
}
