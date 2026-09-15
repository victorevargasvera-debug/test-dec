// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.RptMgrErrorHandler
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using CommonResources;
using System;
using System.Windows;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public class RptMgrErrorHandler
{
  internal MessageBoxResult DisplayError(uint errorCode, string text, string caption)
  {
    int A_1 = 0;
    int num1 = 3;
    short num2;
    string messageBoxText;
    while (true)
    {
      num2 = (short) 17584;
      int num3 = (int) num2;
      num2 = (short) 17584;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_5:
          switch (errorCode)
          {
            case 1:
              messageBoxText = text + RptMgrErrorHandler.b("ꎂ", A_1) + AppResources.Template_File_Does_Not_Exist + RptMgrErrorHandler.b("ꎂ", A_1) + caption;
              num2 = (short) 0;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              messageBoxText = text + RptMgrErrorHandler.b("ꎂ", A_1) + AppResources.File_Corrupted + RptMgrErrorHandler.b("ꎂ", A_1) + caption;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              messageBoxText = text + RptMgrErrorHandler.b("ꎂ", A_1) + AppResources.No_Codeplug_Data + RptMgrErrorHandler.b("ꎂ", A_1) + caption;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              goto label_12;
            case 1:
            case 2:
            case 4:
              goto label_13;
            case 3:
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
            case 5:
              messageBoxText = text + RptMgrErrorHandler.b("ꎂ", A_1) + AppResources.Unkown_Error + RptMgrErrorHandler.b("ꎂ", A_1) + caption;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_5;
          }
      }
    }
label_12:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
label_13:
    return MessageBox.Show(messageBoxText);
  }

  internal static string b(string A_0, int A_1)
  {
    char[] charArray = A_0.ToCharArray();
    int num1 = (int) (1616820461 + A_1 + new IntPtr(76) + new IntPtr(19) + new IntPtr(4) + new IntPtr(50));
    int num2 = 0;
    if (num2 < 1)
      goto label_2;
label_1:
    int index1 = num2;
    char[] chArray = charArray;
    int index2 = index1;
    int num3 = (int) (short) charArray[index1];
    int num4 = num3 & (int) byte.MaxValue;
    int num5 = num1;
    int num6 = num5 + 1;
    byte num7 = (byte) (num4 ^ num5);
    int num8 = num3 >> 8;
    int num9 = num6;
    num1 = num9 + 1;
    int num10 = (int) (byte) (num8 ^ num9);
    int num11 = (int) (ushort) ((uint) num7 << 8 | (uint) (byte) num10);
    chArray[index2] = (char) num11;
    ++num2;
label_2:
    if (num2 >= charArray.Length)
      return string.Intern(new string(charArray));
    goto label_1;
  }

  public enum ErrorCode : uint
  {
    FileDoesNotExist = 1,
    FileCorrupted = 2,
    emptyRptDataObject = 3,
    genericError = 4,
  }
}
