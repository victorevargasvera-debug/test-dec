// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.AcpReportMgrLib
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using AcpCommonLib;
using AcpUI;
using CommonResources;
using ConstraintHelper;
using SpecialFeatures.ACPXMLCoreEngineLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Navigation;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public class AcpReportMgrLib
{
  private RptMgrErrorHandler a = new RptMgrErrorHandler();
  private Window b;

  public static void CleanReportsTempFiles()
  {
    int A_1 = 4;
    short num1 = -18354;
    int num2 = (int) num1;
    num1 = (short) -18354;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        AcpReportMgrLib.a(RptMgrErrorHandler.b("햆\uEC88ﮊ\uE28Cﶎ\uE590\uE092즔\uE396ﲘ\uF69A\uED9C", A_1), RptMgrErrorHandler.b("궆ꞈꆊ", A_1));
        AcpReportMgrLib.a(RptMgrErrorHandler.b("햆\uEC88ﮊ\uE28Cﶎ\uE590\uE092즔\uF396\uF898\uEF9Aﲜ", A_1), RptMgrErrorHandler.b("궆ꞈ\uF38A\uE08C\uE38E", A_1));
        break;
      default:
        goto case 1;
    }
  }

  private void a(reportType A_0, string A_1, int A_2, ref bool A_3)
  {
    int A_1_1 = 0;
    int num1 = 16 /*0x10*/;
    short num2;
    ReportViewer reportViewer;
    FileAttributes attributes1;
    while (true)
    {
      switch (num1)
      {
        case 0:
          reportViewer.Owner = this.b;
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          File.Delete(A_1);
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          reportViewer.usrInpDia.Close();
          num2 = (short) 12;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          if (this.b != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 9;
        case 5:
          File.SetAttributes(A_1, FileAttributes.ReadOnly);
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          if (A_3)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
        case 7:
label_8:
          reportViewer.Show();
          reportViewer.Focus();
          reportViewer.Hide();
          reportViewer.ShowDialog();
          num2 = (short) 0;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (File.Exists(A_1))
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 18;
        case 9:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 10:
          if (reportViewer.usrInpDia != null)
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 12;
        case 11:
          num2 = (short) -6015;
          int num3 = (int) num2;
          num2 = (short) -6015;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_8;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              reportViewer = new ReportViewer(A_0, Global.XMLFileName, A_2, ref A_3);
              reportViewer.RptViewer.Focus();
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 12:
          num2 = (short) 15;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          goto label_10;
        case 14:
          FileAttributes attributes2 = File.GetAttributes(A_1);
          File.SetAttributes(A_1, attributes2 & ~FileAttributes.ReadOnly);
          attributes1 = File.GetAttributes(A_1);
          num2 = (short) 17;
          num1 = (int) (IntPtr) num2;
          continue;
        case 15:
          if (File.Exists(A_1))
          {
            num2 = (short) 14;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_34;
        case 16 /*0x10*/:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 17:
          if (attributes1.ToString().Equals(RptMgrErrorHandler.b("춂\uEA84\uF586\uE488\uEA8A\uE18C", A_1_1)))
          {
            num2 = (short) 13;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_28;
        case 18:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (File.Exists(A_1))
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 11;
      }
    }
label_34:
    return;
label_10:
    try
    {
      File.Delete(A_1);
      return;
    }
    catch (Exception ex)
    {
      Console.WriteLine(RptMgrErrorHandler.b("욂\uF784\uF586\uE688力권\uEB8E\uF490ﾒ\uF094\uE396\uF098\uF59A煮", A_1_1) + A_1 + ex.ToString());
      return;
    }
label_28:;
  }

  public void GenerateReport(reportType rptType)
  {
    int A_1_1 = 9;
    switch (0)
    {
      default:
        short num1 = 8;
        int num2 = (int) (IntPtr) num1;
        int A_2;
        string A_1_2;
        bool A_3;
        while (true)
        {
          AcpBaseXMLCoreEngine baseXmlCoreEngine;
          int inError;
          AcpUIDialogWindow<string> acpUiDialogWindow1;
          Random random;
          int num3;
          switch (num2)
          {
            case 0:
              goto label_28;
            case 1:
              if (num3 < 100)
              {
                A_2 += random.Next(12345);
                ++num3;
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) 15;
              num2 = (int) (IntPtr) num1;
              continue;
            case 2:
              goto label_18;
            case 3:
            case 5:
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              if (this.b != null)
              {
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 7;
            case 6:
              goto label_26;
            case 7:
              ((Window) acpUiDialogWindow1).Show();
              ((UIElement) acpUiDialogWindow1).Focus();
              ((Window) acpUiDialogWindow1).Hide();
              ((Window) acpUiDialogWindow1).ShowDialog();
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 8:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 9:
              try
              {
                Global.systemTempPath = Path.GetTempPath();
              }
              catch (Exception ex)
              {
                Console.WriteLine(RptMgrErrorHandler.b("\uDF8B\uF78D\uE38F\uE691\uF193ﮕ뢗캙\uD99B펝\uF09F芡삣쾥\uDAA7쾩쾫\uDAAD\uDFAF삱춳隵쾷\uDBB9쾻麽꺿귁냃\uE6C5껇ꗉ맋ꃍ듏ﳑ\uF4D3\uF6D5裗뛙맛뿝鏟蟡쓣菥蛧駩駫鳭闯틱뇳飵軷鏹軻釽滿漁愃栅簇欉怋⸍昏猑易缕礗砙瀛笝\u001F瘡愣欥砧\u0A29䤫嘭夯䄱䀳", A_1_1) + ex.Message);
                return;
              }
              num1 = (short) 10;
              num2 = (int) (IntPtr) num1;
              continue;
            case 10:
              if ((inError = this.SetGlobalDirectoryAndCheckReportFiles(rptType)) > 0)
              {
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              A_2 = 0;
              random = new Random();
              num3 = 0;
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
            case 11:
              switch (rptType)
              {
                case reportType.RadioInfo:
                case reportType.HandOut:
                case reportType.HandOutO2:
                case reportType.HandOutO3:
                case reportType.HandOutO7:
                case reportType.HandOutO5:
                case reportType.HandOutO9:
                case reportType.HandOutE5:
                  baseXmlCoreEngine.BuildXMLfile(Global.XMLFileName, ref inError);
                  num1 = (short) 16 /*0x10*/;
                  num2 = (int) (IntPtr) num1;
                  continue;
                case reportType.Choices:
                  PageCustomPrintSelection customPrintSelection = new PageCustomPrintSelection();
                  customPrintSelection.btnPrtCreateTpl.IsEnabled = false;
                  customPrintSelection.btnPrtDelTpl.IsEnabled = false;
                  customPrintSelection.btnPrtEditTpl.IsEnabled = false;
                  customPrintSelection.btnPrtPreview.IsEnabled = false;
                  customPrintSelection.BuildCustomPrintSelection();
                  acpUiDialogWindow1 = new AcpUIDialogWindow<string>((PageFunction<string>) customPrintSelection, (string) null);
                  customPrintSelection.ParenWnd = (Window) acpUiDialogWindow1;
                  ((FrameworkElement) acpUiDialogWindow1).Width = 500.0;
                  ((FrameworkElement) acpUiDialogWindow1).Height = 400.0;
                  ((Window) acpUiDialogWindow1).ResizeMode = ResizeMode.NoResize;
                  ((Window) acpUiDialogWindow1).WindowStartupLocation = WindowStartupLocation.Manual;
                  AcpUIDialogWindow<string> acpUiDialogWindow2 = acpUiDialogWindow1;
                  System.Drawing.Size maxWindowTrackSize = SystemInformation.MaxWindowTrackSize;
                  double num4 = ((double) maxWindowTrackSize.Height - ((FrameworkElement) acpUiDialogWindow1).Height) / 2.0;
                  ((Window) acpUiDialogWindow2).Top = num4;
                  AcpUIDialogWindow<string> acpUiDialogWindow3 = acpUiDialogWindow1;
                  maxWindowTrackSize = SystemInformation.MaxWindowTrackSize;
                  double num5 = ((double) maxWindowTrackSize.Width - ((FrameworkElement) acpUiDialogWindow1).Width) / 2.0;
                  ((Window) acpUiDialogWindow3).Left = num5;
                  ((FrameworkElement) acpUiDialogWindow1).MaxHeight = ((FrameworkElement) acpUiDialogWindow1).Height;
                  ((FrameworkElement) acpUiDialogWindow1).MaxWidth = ((FrameworkElement) acpUiDialogWindow1).Width;
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                default:
                  num1 = (short) 13;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 12:
              goto label_36;
            case 13:
              goto label_37;
            case 14:
              num1 = (short) -24396;
              int num6 = (int) num1;
              num1 = (short) -24396;
              int num7 = (int) num1;
              switch (num6 == num7 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_37;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  ((Window) acpUiDialogWindow1).Owner = this.b;
                  num1 = (short) 7;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
            case 15:
              string fileNameByRptType = ReportFileItem.GetFileNameByRptType(rptType);
              A_1_2 = Path.Combine(Global.usrTempDirPath, fileNameByRptType + A_2.ToString() + RptMgrErrorHandler.b("ꊋ\uF68D\uE08F\uE191", A_1_1));
              baseXmlCoreEngine = new XMLCoreEngineFactory().MakeXMLCoreObj(rptType);
              num1 = (short) 11;
              num2 = (int) (IntPtr) num1;
              continue;
            case 16 /*0x10*/:
              if (inError > 0)
              {
                num1 = (short) 0;
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_24;
          }
          if (!Enum.IsDefined(typeof (reportType), (object) rptType))
          {
            num1 = (short) 0;
            num2 = (int) (IntPtr) num1;
          }
          else
          {
            A_3 = false;
            num1 = (short) 9;
            num2 = (int) (IntPtr) num1;
          }
        }
label_26:
        break;
label_36:
        break;
label_18:
        int num8 = (int) this.a.DisplayError(4U, AppResources.Incomplete_Operation, (string) null);
        break;
label_24:
        this.a(rptType, A_1_2, A_2, ref A_3);
        break;
label_28:
        throw new ArgumentException(AppResources.Invalid_Report_Type);
label_37:
        num1 = (short) 1;
        if (num1 == (short) 0)
          break;
        break;
    }
  }

  public Window ParentWnd
  {
    set
    {
      short num1 = 15950;
      int num2 = (int) num1;
      num1 = (short) 15950;
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
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal int SetGlobalDirectoryAndCheckReportFiles(reportType rptType)
  {
    int A_1 = 10;
    int num1 = 0;
    switch (num1)
    {
      default:
        string numberA8539UiValue;
        int num2;
        List<string> stringList1;
        List<string> stringList2;
        bool flag;
        string path1;
        short num3;
        switch (0)
        {
          case 0:
label_3:
            numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
            num2 = 0;
            stringList1 = new List<string>()
            {
              RptMgrErrorHandler.b("첌\uDF8E즐ꂒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꖒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꖒꖔꞖꦘ힚\uF49C", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꚒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꖒꖔꞖꦘ쎚\uD89C", A_1),
              RptMgrErrorHandler.b("\uDE8C\uDD8E즐ꆒꞔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐꒒ꖔꞖꦘ쎚\uD89C", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐꒒ꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꞒꖔꞖꦘ쎚햜", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꮒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꮒꖔꞖꦘ쎚\uD89C", A_1),
              RptMgrErrorHandler.b("\uDB8C\uEA8E\uE390\uE792\uF094\uEF96", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꮒꖔꞖꦘ펚얜\uDA9E", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꮒꖔꞖꦘ펚", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꊒꖔꞖꦘ\uF29A", A_1),
              RptMgrErrorHandler.b("첌\uDB8E슐ꆒꂔꞖꦘ\uEB9A", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94튖솘쾚", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94튖솘쾚붜잞\uEFA0", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94ꂖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94ꊖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94꒖ꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐뎒\uDB94튖솘쾚붜잞\uE4A0", A_1)
            };
            stringList2 = new List<string>()
            {
              RptMgrErrorHandler.b("첌\uDF8E즐ꮒꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐꒒ꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꖒꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꖒꂔꞖꦘ힚\uF49C", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꚒꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꆒꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("\uD98C힎\uDC90ꆒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("\uD98C힎\uDC90ꂒꖔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꞒꂔꞖꦘ", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꞒꂔꞖꦘ힚\uF49C", A_1),
              RptMgrErrorHandler.b("첌\uDF8E즐ꊒꂔꞖꦘ", A_1)
            };
            flag = false;
            path1 = string.Empty;
            num3 = (short) 10;
            num1 = (int) (IntPtr) num3;
            goto default;
          default:
            while (true)
            {
              int length1;
              string path2;
              int length2;
              string str;
              switch (num1)
              {
                case 0:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num3 = (short) 18;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 13;
                case 1:
                  if (length2 > 0)
                  {
                    num3 = (short) 26;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 13;
                case 2:
                  num3 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 3:
                  if (!path2.Equals(RptMgrErrorHandler.b("첌\uDF8E즐꒒ꂔꞖꦘ", A_1)))
                  {
                    num3 = (short) 29;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 35;
                case 4:
                  flag = true;
                  num3 = (short) 8;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 5:
                  num3 = (short) 38;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 6:
                  path1 = Path.Combine(path1, RptMgrErrorHandler.b("캌\uE08Eﾐ\uE092杖ﮖﲘ\uEF9A\uE99C爵", A_1));
                  num3 = (short) 25;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 7:
                  if (!flag)
                  {
                    num3 = (short) 17;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 15;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 8:
                  if (UtilityMack.IsPortable())
                  {
                    num3 = (short) 12;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  num3 = (short) 5;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 9:
                  path2 = stringList2.Find((Predicate<string>) (Result =>
                  {
                    short num4 = 0;
                    num4 = (short) -19622;
                    int num5 = (int) num4;
                    num4 = (short) -19622;
                    int num6 = (int) num4;
                    switch (num5 == num6)
                    {
                      case true:
                        num4 = (short) 1;
                        if (num4 == (short) 0)
                          ;
                        num4 = (short) 0;
                        if (num4 == (short) 0)
                          ;
                        return UtilityMack.ProductModelId.Equals(Result);
                      default:
                        goto case 1;
                    }
                  }));
                  num3 = (short) 27;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 10:
                  if (!UtilityMack.IsPortable())
                  {
                    num3 = (short) 28;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 30;
                case 11:
                  num3 = (short) 0;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 12:
                  str = RptMgrErrorHandler.b("ﶌ\uE08E\uE390\uE792\uF494\uF596\uF598ﺚ", A_1);
                  break;
                case 13:
                case 21:
                  Global.XMLFileName = Global.usrReportsDirectory + RptMgrErrorHandler.b("\uE98C\uEE8E\uE590\uF292즔", A_1) + rptType.ToString() + Path.GetRandomFileName() + RptMgrErrorHandler.b("ꎌ\uF78Eﲐﾒ", A_1);
                  Global.usrDesRptPath = Global.usrReportsDirectory + RptMgrErrorHandler.b("\uDF8C\uEA8E\uE190ﲒ\uE794\uE396얘", A_1);
                  Global.tempPath = Global.workingDirectory + RptMgrErrorHandler.b("ﾌ\uEA8E\uE190ﲒ\uE794\uE396\uEA98잚\uE99C爵철펢捻", A_1);
                  Global.contentDir = Global.workingDirectory + RptMgrErrorHandler.b("\uDF8C\uEA8E\uE190ﲒ\uE794\uE396\uEA98잚\uF49C\uF29E삠쒢삤ﮦ", A_1);
                  Global.flowDocPath = Global.usrReportsDirectory + RptMgrErrorHandler.b("歷\uEA8Eﲐ\uE392즔", A_1);
                  Global.usrDataDirPath = Global.usrReportsDirectory + RptMgrErrorHandler.b("\uE98C\uEE8E\uE590\uF292즔", A_1);
                  Global.usrTempDirPath = Global.usrReportsDirectory + RptMgrErrorHandler.b("歷\uEA8Eﲐ\uE392", A_1);
                  Global.usrPrntTemplateDir = Global.usrReportsDirectory + RptMgrErrorHandler.b("\uDD8Cﶎ\uF890ﶒ\uE194쎖ﲘ\uF69A\uED9C\uF39E삠힢삤", A_1);
                  Global.usrLastSavedContainer = new List<string>();
                  num3 = (short) 36;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 14:
                  if (!string.IsNullOrEmpty(path2))
                  {
                    num3 = (short) 4;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 25;
                case 15:
                  Global.usrReportsDirectory = Global.systemTempPath + RptMgrErrorHandler.b("\uDF8C\uEA8E\uE190ﲒ\uE794\uE396\uEA98잚", A_1);
                  Global.workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
                  length2 = Global.workingDirectory.IndexOf(RptMgrErrorHandler.b("\uEF8C\uE68Eﾐ쾒", A_1));
                  num3 = (short) 1;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 16 /*0x10*/:
                  if (!UtilityMack.IsAPX2000APX4000With2Knobs)
                  {
                    num3 = (short) 11;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_42;
                case 17:
                  if (UtilityMack.IsPortable())
                  {
                    num3 = (short) 22;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 13;
                case 18:
                  num3 = (short) 0;
                  goto label_42;
                case 19:
                  if (string.IsNullOrEmpty(path2))
                  {
                    num3 = (short) 37;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 27;
                case 20:
                  Global.workingDirectory = Global.workingDirectory.Substring(0, length1);
                  num3 = (short) 13;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 22:
                  num3 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 23:
                  path2 = stringList1.Find((Predicate<string>) (Result =>
                  {
                    short num7 = 0;
                    num7 = (short) -16896;
                    int num8 = (int) num7;
                    num7 = (short) -16896;
                    int num9 = (int) num7;
                    switch (num8 == num9)
                    {
                      case true:
                        num7 = (short) 1;
                        if (num7 == (short) 0)
                          ;
                        num7 = (short) 0;
                        if (num7 == (short) 0)
                          ;
                        return UtilityMack.ProductModelId.Equals(Result);
                      default:
                        goto case 1;
                    }
                  }));
                  num3 = (short) 19;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 24:
                  if (length1 > 0)
                  {
                    num3 = (short) 20;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 13;
                case 25:
                case 34:
                  num3 = (short) 7;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 26:
                  Global.workingDirectory = Global.workingDirectory.Substring(0, length2);
                  num3 = (short) 21;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 27:
                  num3 = (short) 14;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 28:
                  num3 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 29:
                  num3 = (short) 33;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 30:
                  num3 = (short) 23;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 31 /*0x1F*/:
                  if (UtilityMack.IsMobile())
                  {
                    num3 = (short) 30;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto case 25;
                case 32 /*0x20*/:
                  if (!UtilityMack.IsWorldWidePro)
                  {
                    num3 = (short) 2;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_42;
                case 33:
                  if (path2.Equals(RptMgrErrorHandler.b("첌\uDF8E즐ꞒꂔꞖꦘ", A_1)))
                  {
                    num3 = (short) 35;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_87;
                case 35:
                  num3 = (short) 39;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 36:
                  goto label_48;
                case 37:
                  num3 = (short) 9;
                  num1 = (int) (IntPtr) num3;
                  continue;
                case 38:
                  str = RptMgrErrorHandler.b("\uE08C\uE08E\uF390朗璉\uF296", A_1);
                  break;
                case 39:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("소", A_1)))
                  {
                    num3 = (short) 6;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  }
                  goto label_87;
                default:
                  goto label_3;
              }
              path1 = str;
              num3 = (short) 1;
              if (num3 == (short) 0)
                ;
              num3 = (short) 3;
              num1 = (int) (IntPtr) num3;
              continue;
label_42:
              Global.usrReportsDirectory = Global.systemTempPath + RptMgrErrorHandler.b("\uDF8C\uEA8E\uE190ﲒ\uE794\uE396\uEA98잚", A_1);
              Global.workingDirectory = AppDomain.CurrentDomain.BaseDirectory;
              length1 = Global.workingDirectory.IndexOf(RptMgrErrorHandler.b("\uEF8C\uE68Eﾐ쾒", A_1));
              num3 = (short) 24;
              num1 = (int) (IntPtr) num3;
              continue;
label_87:
              path1 = Path.Combine(path1, path2);
              num3 = (short) 34;
              num1 = (int) (IntPtr) num3;
            }
label_48:
            try
            {
              num3 = (short) 10;
              int num10 = (int) (IntPtr) num3;
              while (true)
              {
                switch (num10)
                {
                  case 0:
                    num3 = (short) 2;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 1:
                    Directory.CreateDirectory(Global.usrTempDirPath);
                    num3 = (short) 3;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 2:
                    if (!Directory.Exists(Global.usrPrntTemplateDir))
                    {
                      num3 = (short) 12;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto case 4;
                  case 3:
                    num3 = (short) 8;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 4:
                    num3 = (short) 17;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 5:
                    Directory.CreateDirectory(Global.usrDesRptPath);
                    num3 = (short) 0;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 6:
                    num3 = (short) 14;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 7:
                    if (!Directory.Exists(Global.usrDesRptPath))
                    {
                      num3 = (short) 5;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto case 0;
                  case 8:
                    if (!Directory.Exists(Global.usrDataDirPath))
                    {
                      num3 = (short) 16 /*0x10*/;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto case 15;
                  case 9:
                    Directory.CreateDirectory(Global.flowDocPath);
                    num3 = (short) 6;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 10:
                    switch (0)
                    {
                      case 0:
                        goto label_51;
                      default:
                        continue;
                    }
                  case 11:
                    num3 = (short) 1617;
                    int num11 = (int) num3;
                    num3 = (short) 1617;
                    int num12 = (int) num3;
                    switch (num11 == num12 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_51;
                      default:
                        num3 = (short) 0;
                        if (num3 == (short) 0)
                          break;
                        break;
                    }
                    break;
                  case 12:
                    Directory.CreateDirectory(Global.usrPrntTemplateDir);
                    num3 = (short) 4;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 13:
                    Directory.CreateDirectory(Global.usrReportsDirectory);
                    num3 = (short) 11;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 14:
                    if (!Directory.Exists(Global.usrReportsDirectory))
                    {
                      num3 = (short) 13;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    break;
                  case 15:
                    num3 = (short) 7;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 16 /*0x10*/:
                    Directory.CreateDirectory(Global.usrDataDirPath);
                    num3 = (short) 15;
                    num10 = (int) (IntPtr) num3;
                    continue;
                  case 17:
                    goto label_92;
                  case 18:
                    if (!Directory.Exists(Global.usrTempDirPath))
                    {
                      num3 = (short) 1;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto case 3;
                  default:
label_51:
                    if (!Directory.Exists(Global.flowDocPath))
                    {
                      num3 = (short) 9;
                      num10 = (int) (IntPtr) num3;
                      continue;
                    }
                    goto case 6;
                }
                num3 = (short) 18;
                num10 = (int) (IntPtr) num3;
              }
            }
            catch (Exception ex)
            {
              Console.WriteLine(RptMgrErrorHandler.b("좌ﶎ\uE390ﲒ\uE794랖滛\uE99A\uF89Cﺞ햠쪢쮤삦覨쾪쒬\uDDAE풰킲솴\uD8B6쮸슺鎼", A_1) + ex.Message);
            }
label_92:
            return num2;
        }
    }
  }

  private static void a(string A_0, string A_1)
  {
    int A_1_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        string path1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            path1 = Global.systemTempPath + A_0;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            string path2;
            string[] files;
            string[] strArray;
            int index;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (Directory.Exists(path1))
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_22;
                case 1:
                case 5:
                  num2 = (short) 0;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (index >= strArray.Length)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  path2 = strArray[index];
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (files.Length != 0)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_20;
                case 4:
                  files = Directory.GetFiles(path1, A_1);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  try
                  {
                    File.Delete(path2);
                  }
                  catch (Exception ex)
                  {
                    Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uF58Dꂏ\uEF91", A_1_1), (object) ex.Message));
                  }
                  ++index;
                  num1 = 5;
                  continue;
                case 7:
                  num2 = (short) 18627;
                  int num3 = (int) num2;
                  num2 = (short) 18627;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_3;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      strArray = files;
                      index = 0;
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 8:
                  goto label_18;
                default:
                  goto label_3;
              }
            }
label_18:
            return;
label_22:
            return;
label_20:
            return;
        }
    }
  }
}
