// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpXMLCoreEngineLib.AcpXMLCoreEngLib
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using SpecialFeatures.AcpReportManagerLib;
using System;
using System.Text.RegularExpressions;

#nullable disable
namespace SpecialFeatures.AcpXMLCoreEngineLib;

public class AcpXMLCoreEngLib
{
  public static bool isValidArabicDateTime(string dt)
  {
    int A_1 = 6;
    int num1;
    char ch;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        ch = dt[dt.Length - 1];
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (ch != 'ص')
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_12;
            case 1:
              if (ch != 'م')
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_12;
            case 2:
              goto label_5;
            case 3:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
        }
label_5:
        num2 = (short) 26911;
        int num3 = (int) num2;
        num2 = (short) 26911;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_5;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            return false;
        }
label_12:
        dt = dt.Remove(dt.Length - 1, 1);
        string pattern = RptMgrErrorHandler.b("했\uEF8A\uF68C붎\uEC90좒뢔뢖쒘잚列\uE49E鎠\uDEA2ﺤ誦蚨\uF6AA\uF1AC쮮쪰螲좴鞶\uE5B8\uDFBA욼趾변蓼駄ꏆ니流냌\uF5CE跐럒껔\uE5D6ꓘﯚ", A_1);
        return Regex.IsMatch(dt, pattern);
    }
  }

  public static string convertToArabicFormat(string inValue)
  {
    int num1 = 1;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          if (AcpXMLCoreEngLib.isValidArabicDateTime(inValue))
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
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
          goto label_5;
        case 3:
          goto label_12;
      }
      if (string.IsNullOrEmpty(inValue))
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        num2 = (short) 31365;
        int num3 = (int) num2;
        num2 = (short) 31365;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_12;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
        }
      }
    }
label_5:
    return ReportViewer.convertToArabicDateTime(inValue);
label_12:
    return inValue;
label_13:
    return inValue;
  }
}
