// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.ReportViewer
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpCommonLib;
using AcpUI.Common;
using Common;
using CommonResources;
using ConstraintHelper;
using DevComponents.WpfRibbon;
using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Printing;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;
using System.Windows.Xps;
using System.Windows.Xps.Packaging;
using System.Xml;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public partial class ReportViewer : Window, IDisposable, IComponentConnector
{
  private XmlDocument a;
  private XmlNodeList b;
  private XmlNodeList c;
  private XmlNodeList d;
  private XmlNodeList e;
  private XmlNodeList f;
  private XmlNodeList g;
  private string h;
  private FileStream i;
  private XpsDocument j;
  private XpsDocumentWriter k;
  public InputDialog usrInpDia;
  private bool l;
  private string m;
  private int n;
  private reportType o;
  public static RoutedCommand CustomLastPage;
  public static RoutedCommand CustomNextPage;
  internal DocumentViewer RptViewer;
  internal Menu mnuMenu;
  internal MenuItem MenuItemFile;
  internal MenuItem MenuItemFileOpen;
  internal MenuItem MenuItemFileSave;
  internal MenuItem MenuItemFilePrint;
  internal MenuItem MenuItemFileExit;
  internal MenuItem MenuItemView;
  internal MenuItem menuViewIncreaseZoom;
  internal MenuItem menuViewDecreaseZoom;
  internal ButtonDropDown ribbonBarHelpButton;
  internal StatusBar stsbtmBar;
  private bool p;

  public ReportViewer(reportType rptType, string xmlFile, int fileCreationTime, ref bool retVal)
  {
    int A_1 = 10;
    this.l = true;
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.InitializeComponent();
    if (AppInfoManager.ReportsLangSelection == RptMgrErrorHandler.b("\uEC8Cﶎ", A_1))
      goto label_3;
label_2:
    this.h = xmlFile;
    this.m = "";
    this.n = fileCreationTime;
    this.o = rptType;
    if (this.a(rptType, fileCreationTime))
      retVal = true;
    Utility.SetDirection((FrameworkElement) this);
    return;
label_3:
    AppInfoManager.ReportsLangSelection = RptMgrErrorHandler.b("\uEC8Cﶎ벐\uD892슔", A_1);
    goto label_2;
  }

  public void UpdateStatusBar()
  {
    int A_1 = 6;
    int num1 = 0;
    switch (num1)
    {
      default:
        CultureInfo culture;
        StatusBarItem newItem1;
        TextBlock textBlock1;
        string numberA8539UiValue;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            culture = new CultureInfo(AppInfoManager.ReportsLangSelection);
            int num3 = culture.TextInfo.IsRightToLeft ? 1 : 0;
            this.stsbtmBar.Items.Clear();
            int masterPageNumber = this.RptViewer.MasterPageNumber;
            StatusBarItem newItem2 = new StatusBarItem();
            newItem2.Content = (object) new TextBlock()
            {
              Text = (AppResources.Page_Id + masterPageNumber.ToString())
            };
            newItem2.BorderBrush = (Brush) Brushes.WhiteSmoke;
            newItem2.Width = 400.0;
            this.stsbtmBar.Items.Add((object) newItem2);
            this.stsbtmBar.Items.Add((object) new Separator());
            newItem1 = new StatusBarItem();
            textBlock1 = new TextBlock();
            numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            TextBlock textBlock2;
            StatusBarItem newItem3;
            while (true)
            {
              IAcpRecordset feature;
              IAcpField iacpField;
              switch (num1)
              {
                case 0:
                  if (!numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("솈늊뺌", A_1)))
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (feature != null)
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_39;
                case 2:
                case 3:
                case 8:
                case 12:
                case 22:
                case 23:
                  newItem1.Content = (object) textBlock1;
                  newItem1.BorderBrush = (Brush) Brushes.WhiteSmoke;
                  newItem1.Width = 200.0;
                  this.stsbtmBar.Items.Add((object) newItem1);
                  this.stsbtmBar.Items.Add((object) new Separator());
                  newItem3 = new StatusBarItem();
                  textBlock2 = new TextBlock();
                  feature = FeatureManager.GetFeature(2049);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  num2 = (short) 0;
                  textBlock1.Text = RptMgrErrorHandler.b("좈\uDB8A햌꾎ꢐꎒꖔ", A_1);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("얈", A_1)))
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                case 17:
                  goto label_39;
                case 9:
                  textBlock1.Text = RptMgrErrorHandler.b("좈\uDF8A\uDE8C꾎ꎐꚒꖔꞖ\uE998", A_1);
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  textBlock1.Text = RptMgrErrorHandler.b("\uDF88\uEE8Aﾌﮎ\uF490\uEB92", A_1);
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  textBlock1.Text = RptMgrErrorHandler.b("좈\uDB8A햌꾎\uDF90ꂒꖔ", A_1);
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (!UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_31;
                case 14:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("솈늊뾌", A_1)))
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_31;
                case 15:
                  if (!numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("솈늊릌", A_1)))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  num2 = (short) -2508;
                  int num4 = (int) num2;
                  num2 = (short) -2508;
                  int num5 = (int) num2;
                  switch (num4 == num5 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      break;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      textBlock1.Text = RptMgrErrorHandler.b("좈\uDB8A햌꾎튐ﲒﮔ\uE496\uF698\uF79A\uF89C\uEB9E햠욢", A_1);
                      num2 = (short) 12;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  break;
                case 18:
                  iacpField = feature.FieldFromPath(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDB88\uEA8A\uE98C\uE68Eﺐ첒\uDC94練ﾘ\uF49A\uEF9C\uF29E삠힢첤좦잨", A_1), culture) + RptMgrErrorHandler.b("했", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("캈\uEE8A\uE38C\uEA8E\uE390\uF292璉좖킘ﾚ", A_1), culture) + RptMgrErrorHandler.b("했", A_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쒈\uE48A\uE98C\uEA8E\uFD90첒\uDB94\uE296\uF498連\uF89C\uED9E", A_1), culture), RptMgrErrorHandler.b("했", A_1));
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("솈몊뢌\uDA8E튐햒겔잖캘궚\uDC9C톞", A_1)))
                  {
                    textBlock1.Text = UtilityMack.ProductModelId.Substring(0, 3) + RptMgrErrorHandler.b("ꦈ", A_1) + UtilityMack.ProductModelId.Substring(3);
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  textBlock2.Text = iacpField.ToString();
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (iacpField != null)
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  textBlock2.Text = "";
                  break;
                default:
                  goto label_3;
              }
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
label_31:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
            }
label_39:
            newItem3.Content = (object) textBlock2;
            newItem3.BorderBrush = (Brush) Brushes.WhiteSmoke;
            newItem3.Width = 200.0;
            this.stsbtmBar.Items.Add((object) newItem3);
            this.stsbtmBar.Items.Add((object) new Separator());
            return;
        }
    }
  }

  public void Dispose()
  {
    short num1 = 5312;
    int num2 = (int) num1;
    num1 = (short) 5312;
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
        this.Dispose(true);
        GC.SuppressFinalize((object) this);
        break;
      default:
        goto case 1;
    }
  }

  protected virtual void Dispose(bool disposing)
  {
    int num1 = 3;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          this.j.Close();
          this.j = (XpsDocument) null;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 4:
label_14:
          if (this.j != null)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 2;
        case 5:
          if (this.i != null)
          {
            num2 = (short) -10737;
            int num3 = (int) num2;
            num2 = (short) -10737;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_14;
              default:
                num2 = (short) 0;
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_16;
        case 6:
          this.i.Dispose();
          this.i = (FileStream) null;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
          goto label_12;
      }
      if (disposing)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_18;
    }
label_12:
    return;
label_18:
    return;
label_16:;
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 20778;
    int num2 = (int) num1;
    num1 = (short) 20778;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void buttonHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 12;
    try
    {
      int num1;
      reportType o;
      short num2;
      switch (0)
      {
        case 0:
label_3:
          Utility.CloseHelpWindowIfOpen();
          o = this.o;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            switch (num1)
            {
              case 0:
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              case 1:
label_11:
                Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("겎\uF790ꂒ꒔꺖\uF898漢ꖜﺞ", A_1_1));
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              case 3:
              case 6:
label_15:
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              case 4:
                if (o != reportType.RadioInfo)
                {
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("겎Ꚑ\uF592꒔ꂖ겘겚ꮜ爵", A_1_1));
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              case 5:
                num2 = (short) 31924;
                int num3 = (int) num2;
                num2 = (short) 31924;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_11;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      goto label_15;
                    goto label_15;
                }
              case 7:
                if (o == reportType.Choices)
                {
                  Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("겎ꆐꞒꞔ\uF496ꦘꪚꮜ咽", A_1_1));
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              case 8:
                goto label_19;
              default:
                goto label_3;
            }
          }
      }
    }
    catch (Exception ex)
    {
    }
label_19:
    short num = 0;
    num = (short) 1;
    if (num == (short) 0)
      ;
  }

  private bool a(reportType A_0, int A_1)
  {
    int A_1_1 = 4;
    int num1;
    short num2;
    bool flag1;
    string path;
    bool flag2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 25413;
        int num3 = (int) num2;
        num2 = (short) 25413;
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
            flag1 = false;
            path = string.Empty;
            flag2 = false;
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            goto label_1;
        }
        break;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              goto label_13;
            case 1:
              goto label_23;
            case 2:
              this.j = new XpsDocument(path, FileAccess.ReadWrite);
              this.k = XpsDocument.CreateXpsDocumentWriter(this.j);
              this.k.Write(this.b(A_0).DocumentPaginator);
              this.RptViewer.Document = (IDocumentPaginatorSource) this.j.GetFixedDocumentSequence();
              this.j.Close();
              flag2 = true;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (flag1)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 4:
            case 6:
            case 9:
            case 12:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              if (!this.h())
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (!string.IsNullOrEmpty(path))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_23;
            case 8:
              goto label_7;
            case 10:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_2;
          }
label_1:;
        }
label_7:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        return flag2;
label_23:
        return flag2;
    }
label_13:
    switch (A_0)
    {
      case reportType.RadioInfo:
        flag1 = this.f();
        path = Global.flowDocPath + ReportFileItem.GetFileNameByRptType(A_0) + A_1.ToString() + RptMgrErrorHandler.b("ꦆ\uF188ﮊﺌ", A_1_1);
        num2 = (short) 6;
        num1 = (int) (IntPtr) num2;
        goto label_1;
      case reportType.HandOut:
      case reportType.HandOutO2:
      case reportType.HandOutO3:
      case reportType.HandOutO7:
      case reportType.HandOutO5:
      case reportType.HandOutO9:
      case reportType.HandOutE5:
        flag1 = this.a(A_0);
        path = Global.flowDocPath + ReportFileItem.GetFileNameByRptType(A_0) + A_1.ToString() + RptMgrErrorHandler.b("ꦆ\uF188ﮊﺌ", A_1_1);
        num2 = (short) 0;
        num2 = (short) 9;
        num1 = (int) (IntPtr) num2;
        goto label_1;
      case reportType.Choices:
        flag1 = this.g();
        path = Global.flowDocPath + RptMgrErrorHandler.b("펆ﮈ\uEE8A\uE88C\uD98E\uF890\uF692\uE294톖\uF598\uF49A\uEA9C\uDB9E캠삢키쪦첨얪\uD9AC", A_1_1) + A_1.ToString() + RptMgrErrorHandler.b("ꦆ\uF188ﮊﺌ", A_1_1);
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto label_1;
      default:
        num2 = (short) 11;
        num1 = (int) (IntPtr) num2;
        goto label_1;
    }
  }

  private static void a(string A_0, string A_1, FileSystemRights A_2, AccessControlType A_3)
  {
    short num1 = 20588;
    int num2 = (int) num1;
    num1 = (short) 20588;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        FileSecurity accessControl = File.GetAccessControl(A_0);
        accessControl.RemoveAccessRule(new FileSystemAccessRule(A_1, A_2, A_3));
        File.SetAccessControl(A_0, accessControl);
        break;
      default:
        goto case 1;
    }
  }

  private IDocumentPaginatorSource b(reportType A_0)
  {
    int A_1 = 11;
    int num1 = 4;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
        case 1:
        case 2:
        case 3:
        case 5:
        case 6:
        case 8:
        case 9:
        case 10:
        case 11:
          goto label_18;
        case 4:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 7:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      switch (A_0)
      {
        case reportType.RadioInfo:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393쒕聯ﺙ\uF59B\uF19D\uE99F첡슣즥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOut:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡誣\uDEA5즧잩삫", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOutO2:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uEBA3钥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOutO3:
          num2 = (short) -12169;
          int num3 = (int) num2;
          num2 = (short) -12169;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              continue;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uEBA3閥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case reportType.HandOutO7:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uEBA3醥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOutO5:
          num2 = (short) 0;
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uEBA3鎥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOutO9:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uEBA3龥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.Choices:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393슕\uEA97ﾙ鍊좝즟잡펣\uE2A5톧쒩춫쎭\uD9AF톱骳캵\uD9B7ힹ킻", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case reportType.HandOutE5:
          this.i = new FileStream(Global.flowDocPath + RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393\uDE95聯\uF499\uF89B톝햟횡\uE1A3鎥蚧튩춫쎭\uDCAF", A_1), FileMode.Open, FileAccess.Read);
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
      }
    }
label_18:
    FlowDocument flowDocument = XamlReader.Load((Stream) this.i) as FlowDocument;
    flowDocument.PageHeight = 900.0;
    flowDocument.ColumnWidth = 750.0;
    flowDocument.MaxPageHeight = 900.0;
    flowDocument.MaxPageWidth = 755.0;
    flowDocument.TextAlignment = TextAlignment.Left;
    return (IDocumentPaginatorSource) flowDocument;
  }

  private bool h()
  {
    short num1 = 0;
    num1 = (short) -2724;
    int num2 = (int) num1;
    num1 = (short) -2724;
    int num3 = (int) num1;
    bool flag;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        return flag;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        flag = true;
        try
        {
          this.a = new XmlDocument();
          this.a.Load(this.h);
          goto case 0;
        }
        catch (Exception ex)
        {
          int num4 = (int) MessageBox.Show(ex.Message);
          flag = false;
          goto case 0;
        }
    }
  }

  private void a(ref XmlTextWriter A_0)
  {
    int A_1 = 17;
    short num1 = 0;
    num1 = (short) -16912;
    int num2 = (int) num1;
    num1 = (short) -16912;
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
        A_0.WriteStartElement(RptMgrErrorHandler.b("삓\uF795流\uF699鍊첝쾟햡", A_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("삓\uF795流\uF699鍊\uDD9D얟캡좣", A_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("힓秊\uF497\uEF99\uF19B\uF09D\uF39F튡얣좥", A_1), RptMgrErrorHandler.b("ꖓ", A_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("쒓\uF795\uEA97ﮙﮛ\uEC9D솟튡첣", A_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("튓秊\uF697\uEE99\uDA9Bﾝ춟쮡좣\uDFA5", A_1), RptMgrErrorHandler.b("햓\uE495\uF197ﮙ\uF09B", A_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("튓秊\uF697\uEE99쾛\uF79D\uDA9F잡", A_1), RptMgrErrorHandler.b("ꖓ꒕", A_1));
        A_0.WriteString("");
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        break;
      default:
        goto case 1;
    }
  }

  public static string convertToArabicDateTime(string dt)
  {
    int A_1 = 19;
    short num1 = 2839;
    int num2 = (int) num1;
    num1 = (short) 2839;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_12:
        num4 = (short) 3;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        if (false)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        switch (num4)
        {
          default:
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            break;
        }
        break;
    }
    while (true)
    {
      char ch;
      switch (num5)
      {
        case 0:
          goto label_16;
        case 1:
          num4 = (short) 0;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          if (ch != 'م')
          {
            num4 = (short) 4;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_11;
        case 3:
          goto label_9;
        case 4:
          num4 = (short) 6;
          num5 = (int) (IntPtr) num4;
          continue;
        case 5:
          goto label_17;
        case 6:
          if (ch != 'ص')
          {
            num4 = (short) 5;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_11;
      }
      if (string.IsNullOrEmpty(dt))
      {
        num4 = (short) 0;
        num5 = (int) (IntPtr) num4;
      }
      else
      {
        ch = dt[dt.Length - 1];
        num4 = (short) 2;
        num5 = (int) (IntPtr) num4;
      }
    }
label_9:
    try
    {
      string str = dt.Substring(dt.Length - 1, 1);
      return string.Format(RptMgrErrorHandler.b("\uED95ꢗ\uE799\uE79B꾝\uDD9F芡\uDFA3钥햧誩\uD7AB鶭춯", A_1), (object) str, (object) RptMgrErrorHandler.b("颵", A_1), (object) dt.Substring(11, 8), (object) dt.Substring(0, 10));
    }
    catch (Exception ex)
    {
      return dt;
    }
label_11:
    string empty = string.Empty;
    goto label_12;
label_16:
    return dt;
label_17:
    return dt;
  }

  private bool g()
  {
    int A_1 = 2;
    short num1 = -20164;
    int num2 = (int) num1;
    num1 = (short) -20164;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_5:
        int i = 0;
        bool flag = true;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        this.b = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ춈\uEA8A歷\uEE8E", A_1));
        try
        {
          XmlTextWriter A_0;
          switch (0)
          {
            case 0:
label_8:
              A_0 = new XmlTextWriter(Global.flowDocPath + RptMgrErrorHandler.b("쎄\uEB86\uE688ﲊ\uD98Cﶎ\uF490\uF692쎔ﺖﲘ\uEC9A\uD99C\uE69E쾠슢좤캦쪨薪햬캮\uDCB0\uDFB2", A_1), Encoding.Unicode);
              A_0.WriteStartElement(RptMgrErrorHandler.b("쎄\uEB86\uE688ﲊ즌\uE08E\uF290\uE692\uF894\uF296\uF798\uEF9A", A_1));
              A_0.WriteAttributeString(RptMgrErrorHandler.b("ﶄ\uEA86\uE588\uE58Aﺌ", A_1), RptMgrErrorHandler.b("\uED84\uF386ﶈﮊ람ꂎ뺐\uE092\uF694ﾖﲘ\uF69Aﲜ\uEC9E辠캢첤쒦\uDBA8쒪\uDEAC삮ힰ잲鮴풶횸횺銼좾ꣀ귂ꏄ뿆\uE6C8流\uFDCCￎ\uE7D0ﳒ귔뛖듘럚\uF2DC꿞鏠蛢雤苦蟨\u9FEA賬鯮飰鳲鯴", A_1));
              A_0.WriteAttributeString(RptMgrErrorHandler.b("ﶄ\uEA86\uE588\uE58Aﺌ떎\uE990", A_1), RptMgrErrorHandler.b("\uED84\uF386ﶈﮊ람ꂎ뺐\uE092\uF694ﾖﲘ\uF69Aﲜ\uEC9E辠캢첤쒦\uDBA8쒪\uDEAC삮ힰ잲鮴풶횸횺銼좾ꣀ귂ꏄ뿆\uE6C8流\uFDCCￎ\uE7D0ﳒ귔뛖듘럚", A_1));
              A_0.WriteAttributeString(RptMgrErrorHandler.b("쮄\uE686\uE488\uEE8A", A_1), RptMgrErrorHandler.b("\uE384\uEB86\uED88\uE48A\uEE8C", A_1));
              A_0.WriteAttributeString(RptMgrErrorHandler.b("ﶄ\uEA86\uE588놊ﺌﾎ\uF090\uF092\uF094", A_1), RptMgrErrorHandler.b("\uF584\uF586\uEC88\uF88A\uE88Cﶎ\uE790\uF692", A_1));
              num4 = (short) 0;
              num5 = (int) (IntPtr) num4;
              goto default;
            default:
              IEnumerator enumerator;
              while (true)
              {
                switch (num5)
                {
                  case 0:
                    if (this.b.Count != 0)
                    {
                      num4 = (short) 1;
                      num5 = (int) (IntPtr) num4;
                      continue;
                    }
                    goto case 4;
                  case 1:
                    A_0.WriteStartElement(RptMgrErrorHandler.b("횄\uE286\uEA88ﾊ\uE48C\uE08Eﾐ", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("임\uF586\uEC88\uEA8A\uE68C\uDF8E\uF090\uF492\uF094햖ﲘﶚ\uF29C\uED9E쒠", A_1), RptMgrErrorHandler.b("톄\uF586ﲈ\uEE8A", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("첄\uEA86\uE888\uEC8A\uE88C", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("춄\uE286\uE088\uEC8A\uE58Cﮎ", A_1), RptMgrErrorHandler.b("낄랆", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("횄\uF386ﮈ\uEE8A歷\uEC8E戀", A_1), RptMgrErrorHandler.b("쎄\uEE86\uE588\uE78A", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ\uEF86\uEC88\uEA8A\uE98C\uEA8E\uE390붒ﾔ\uE796ﺘ", A_1));
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    this.c = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ춈\uEA8A歷\uEE8E뺐벒펔\uF296\uF898\uEF9A\uE89C\uED9E쒠", A_1));
                    enumerator = this.c.GetEnumerator();
                    num4 = (short) 2;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 2:
                    try
                    {
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      while (true)
                      {
                        switch (num5)
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
                            if (!enumerator.MoveNext())
                            {
                              num4 = (short) 2;
                              num5 = (int) (IntPtr) num4;
                              continue;
                            }
                            XmlNode current = (XmlNode) enumerator.Current;
                            A_0.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C", A_1));
                            A_0.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1), RptMgrErrorHandler.b("튄\uEF86\uE088ﾊ\uE88C", A_1));
                            A_0.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ얐ﮒﲔ\uF496\uF298\uF59A\uF89C\uEC9E튠", A_1), RptMgrErrorHandler.b("랄ꮆ뮈꞊뾌ꎎꎐ", A_1));
                            A_0.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ펐\uE192\uE094\uE496\uF198", A_1), RptMgrErrorHandler.b("Ꚅ솆쾈뮊붌벎튐꒒ꆔ", A_1));
                            A_0.WriteAttributeString(RptMgrErrorHandler.b("햄\uE686\uED88\uEF8A\uE48C\uE18E\uF690", A_1), RptMgrErrorHandler.b("낄", A_1));
                            A_0.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C\uDD8Eﺐ\uE492튔\uE596\uF698\uEE9A\uED9C", A_1));
                            this.a(ref A_0, current.Attributes[i].Value);
                            A_0.WriteEndElement();
                            A_0.WriteEndElement();
                            num4 = (short) 4;
                            num5 = (int) (IntPtr) num4;
                            continue;
                          case 2:
                            num4 = (short) 3;
                            num5 = (int) (IntPtr) num4;
                            continue;
                          case 3:
                            goto label_12;
                        }
                        num4 = (short) 1;
                        num5 = (int) (IntPtr) num4;
                      }
                    }
                    finally
                    {
                      IDisposable disposable;
                      short num6;
                      switch (0)
                      {
                        case 0:
label_23:
                          disposable = enumerator as IDisposable;
                          num6 = (short) 0;
                          num5 = (int) (IntPtr) num6;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num5)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num6 = (short) 1;
                                  num5 = (int) (IntPtr) num6;
                                  continue;
                                }
                                goto label_27;
                              case 1:
                                disposable.Dispose();
                                num6 = (short) 2;
                                num5 = (int) (IntPtr) num6;
                                continue;
                              case 2:
                                goto label_27;
                              default:
                                goto label_23;
                            }
                          }
label_27:;
                      }
                    }
label_12:
                    A_0.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("쎄\uEE86\uEE88ﺊﾌ\uEA8E", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE48C\uEC8E\uF090ﾒ풔練滛\uF39A\uF29C\uED9E", A_1), RptMgrErrorHandler.b("햄\uE686\uEE88\uEE8A쾌\uE08E\uE590\uE792杖殺", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF59Aﺜ\uF79E캠톢", A_1), RptMgrErrorHandler.b("욄\uE886\uE788ﾊ\uE88C\uE18E\uE590솒ﲔ\uF096\uF198\uEF9A", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("좄\uE686ﮈ\uEC8A\uE48C\uE18E", A_1), RptMgrErrorHandler.b("뒄ꮆ뢈꞊벌ꎎꂐ", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("임\uEB86\uE688\uE88A\uE68C\uDA8E\uD890킒杖練\uED98漢\uF49C\uF19E쒠톢", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ쾌\uE38Eﺐ\uF092ﺔ", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1), RptMgrErrorHandler.b("뒄떆", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF79A\uF49C\uF89E쾠캢삤즦\uDDA8", A_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1));
                    A_0.WriteString(ReportViewer.convertToArabicDateTime(DateTime.Now.ToString((IFormatProvider) currentUiCulture)));
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("쎄\uEE86\uEE88ﺊﾌ\uEA8E", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE48C\uEC8E\uF090ﾒ풔練滛\uF39A\uF29C\uED9E", A_1), RptMgrErrorHandler.b("햄\uE686\uEE88\uEE8A쾌\uE08E\uE590\uE792杖殺", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("좄\uE686ﮈ\uEC8A\uE48C\uE18E", A_1), RptMgrErrorHandler.b("뒄ꮆ뢈꞊벌ꎎꂐ", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("임\uEB86\uE688\uE88A\uE68C\uDA8E\uD890킒杖練\uED98漢\uF49C\uF19E쒠톢", A_1));
                    A_0.WriteStartElement(RptMgrErrorHandler.b("첄\uEA86\uE888\uEC8A\uE88C", A_1));
                    A_0.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ얆\uE688ﾊ歷\uE08Eﲐ붒\uDF94잖\uDE98", A_1));
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    A_0.WriteEndElement();
                    num4 = (short) 4;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case 3:
                    goto label_30;
                  case 4:
                    A_0.WriteEndElement();
                    A_0.Close();
                    num4 = (short) 3;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    goto label_8;
                }
              }
          }
        }
        catch (Exception ex)
        {
          int num7 = (int) MessageBox.Show(ex.Message);
          flag = false;
        }
label_30:
        return flag;
      case 1:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num5 = (int) num4;
        switch (num5)
        {
          default:
            goto label_5;
        }
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void c(ref XmlTextWriter A_0, string A_1)
  {
    int A_1_1 = 12;
    short num1 = 0;
    num1 = (short) 9988;
    int num2 = (int) num1;
    num1 = (short) 9988;
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
        Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uDC8E\uDF90\uF292\uF894\uF296ꎘ\uE09A궜\uE29E", A_1_1), (object) A_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uF090\uF192璉\uF296쮘\uF49A\uEA9C", A_1_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uF090\uF192璉\uF296\uDA98ﺚ\uF19C\uF39E", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("첎ﺐﾒ\uE094殺\uF798좚\uED9Cﺞ쾠", A_1_1), RptMgrErrorHandler.b("붎", A_1_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("\uDF8E\uF090\uE192\uF494\uF096\uEB98漢\uED9C\uF79E", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("춎ﺐ\uE192\uF194\uF296\uEB98쾚\uF59C\uF69E슠좢쮤슦\uDAA8\uD8AA", A_1_1), RptMgrErrorHandler.b("붎붐ꆒ릔ꖖ떘ꦚ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("춎ﺐ\uE192\uF194\uF296\uEB98\uD99A\uEF9C\uEA9E튠쮢", A_1_1), RptMgrErrorHandler.b("겎힐햒ꖔꞖꪘ\uD89Aꪜꮞ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("춎\uF090\uF092ﺔ\uF096\uEB98\uF49A\uE89C\uF19E얠", A_1_1), Colors.Coral.ToString());
        A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194쒖\uF098\uE19A\uF89C", A_1_1), RptMgrErrorHandler.b("뺎ꖐ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194톖\uF898\uF69A\uF49C\uF39E\uD8A0", A_1_1), RptMgrErrorHandler.b("캎\uE390朗\uF494ﮖ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194삖ﲘ\uF29A煮\uF79E햠", A_1_1), RptMgrErrorHandler.b("춎ﺐﾒ\uF194", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐ\uE192\uF094\uF096\uEB98\uF49A\uE89C\uF19E얠", A_1_1), Colors.Black.ToString());
        A_0.WriteString(RptMgrErrorHandler.b("蚎颐", A_1_1) + A_1);
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        break;
      default:
        goto case 1;
    }
  }

  private void a(ref XmlTextWriter A_0, XmlNodeList A_1)
  {
    int A_1_1 = 6;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 1;
        if (num2 == (short) 0)
          ;
        num2 = (short) 0;
        CultureInfo currentUiCulture = Thread.CurrentThread.CurrentUICulture;
        int num3 = currentUiCulture.TextInfo.IsRightToLeft ? 1 : 0;
        int num4 = 1;
        bool flag1 = true;
        bool flag2 = true;
        bool flag3 = true;
        IEnumerator enumerator = A_1.GetEnumerator();
        try
        {
          num2 = (short) 22;
          num1 = (int) (IntPtr) num2;
          while (true)
          {
            XmlNode current;
            string text1;
            string str;
            switch (num1)
            {
              case 0:
                num2 = (short) 35;
                num1 = (int) (IntPtr) num2;
                continue;
              case 1:
                num2 = (short) 32 /*0x20*/;
                num1 = (int) (IntPtr) num2;
                continue;
              case 2:
                if (current.Attributes[0].Value != AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38Cﮎ\uF090\uF092\uE194좖\uDD98漢\uE99Cﺞﺠ\uECA2\uD7A4쎦첨\uD9AA\uF2AC\uE6AE\uDFB0ힲ\uDCB4풶\uD8B8쾺튼춾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 3:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("얈\uE28A\uEA8C\uE78E\uE590풒杖ﮖﶘﺚ\uF39C\uED9E캠잢ﲤ슦얨잪슬\uD8AE", A_1_1));
                num2 = (short) 53;
                num1 = (int) (IntPtr) num2;
                continue;
              case 4:
                if (num4 % 2 != 0)
                {
                  A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("\uE588\uE28A\uEA8C\uE78E\uE590\uF492\uE794\uF696\uE098", A_1_1));
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              case 5:
              case 27:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192힔\uE596\uEC98\uE89A\uF59C", A_1_1), RptMgrErrorHandler.b("ꪈ춊쮌뾎ꆐꂒ횔ꂖ궘", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ슐朗\uEF94\uF296", A_1_1), RptMgrErrorHandler.b("뢈릊", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ힐\uF292\uF894ﺖ\uF598\uE29A", A_1_1), RptMgrErrorHandler.b("좈力\uE48C\uEE8E\uFD90", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("\uDD88\uEE8A\uF58Cﮎ킐ﾒﲔ\uF096\uF798\uF69A\uF89C\uF19E햠", A_1_1), RptMgrErrorHandler.b("\uDB88\uE28A\uEA8C\uE78E\uE590", A_1_1));
                num2 = (short) 61;
                num1 = (int) (IntPtr) num2;
                continue;
              case 6:
                if (current.Attributes[0].Value != AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD88力\uF88C\uE18E敖朗ﮔ\uF096욘좚\uF89C\uF39E쒠삢톤슦춨\uF4AA\uE0AC쪮\uDFB0욲\uEAB4ﺶ춸\uDEBA킼첾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 7:
                if (!(current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD88力\uF88C\uE18E敖朗ﮔ\uF096욘좚\uF89C\uF39E쒠삢톤슦춨\uF4AA\uE0AC쪮\uDFB0욲\uEAB4ﺶ춸\uDEBA킼첾", A_1_1), currentUiCulture)))
                {
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 38;
              case 8:
                string text2;
                try
                {
                  text2 = current.Attributes[1].Value;
                }
                catch (Exception ex)
                {
                  text2 = "";
                }
                A_0.WriteString(text2);
                str = "";
                text1 = "";
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                ++num4;
                num1 = 11;
                continue;
              case 9:
                text1 = RptMgrErrorHandler.b("ꦈ", A_1_1);
                num2 = (short) 29;
                num1 = (int) (IntPtr) num2;
                continue;
              case 10:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38C年\uF490ﶒ\uE194ﺖ\uF698\uF59Aﲜ\uF39Eﺠ\uF0A2삤쮦첨좪\uD9AC쪮햰\uECB2\uF8B4튶ힸ캺\uE2BC\uF6BE뗀ꛂ꣄듆", A_1_1), currentUiCulture))
                {
                  num2 = (short) 39;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 40;
                num1 = (int) (IntPtr) num2;
                continue;
              case 12:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("얈\uE28A\uEA8C\uE78E\uE590풒杖ﮖﶘﺚ\uF39C\uED9E캠잢ﲤ슦얨잪슬\uD8AE", A_1_1));
                num2 = (short) 63 /*0x3F*/;
                num1 = (int) (IntPtr) num2;
                continue;
              case 13:
              case 16 /*0x10*/:
              case 25:
              case 28:
              case 29:
              case 51:
              case 54:
                Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uF288뮊\uF08C", A_1_1), (object) text1));
                A_0.WriteString(text1);
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490킒\uF094ﮖ\uF598", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uD988\uEA8Aﾌ\uEE8E\uF690\uE192\uF494\uE796\uF198", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192솔ﾖ\uF098\uF89A\uF69C\uF19E쒠킢횤", A_1_1), RptMgrErrorHandler.b("뢈꞊벌ꎎꆐ뾒ꖔ", A_1_1));
                num2 = (short) 23;
                num1 = (int) (IntPtr) num2;
                continue;
              case 14:
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490솒杖\uE096", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490킒\uF094ﮖ\uF598", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uD988\uEA8Aﾌ\uEE8E\uF690\uE192\uF494\uE796\uF198", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192솔ﾖ\uF098\uF89A\uF69C\uF19E쒠킢횤", A_1_1), RptMgrErrorHandler.b("뢈꞊벌ꎎꆐ뾒ꖔ", A_1_1));
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              case 15:
                num2 = (short) 30;
                num1 = (int) (IntPtr) num2;
                continue;
              case 17:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38C年\uF490ﶒ\uE194ﺖ\uF698\uF59Aﲜ\uF39Eﺠ\uF0A2삤쮦첨좪\uD9AC쪮햰\uECB2\uF8B4튶ힸ캺\uE2BC\uF6BE뗀ꛂ꣄듆", A_1_1), currentUiCulture))
                {
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_41;
              case 18:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38Cﮎ\uF090\uF092\uE194좖\uDD98漢\uE99Cﺞﺠ\uECA2\uD7A4쎦첨\uD9AA\uF2AC\uE6AE\uDFB0ힲ\uDCB4풶\uD8B8쾺튼춾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_92;
              case 19:
                if (!current.HasChildNodes)
                {
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_92;
              case 20:
                num2 = (short) 52;
                num1 = (int) (IntPtr) num2;
                continue;
              case 21:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38Cﮎ\uF090\uF092\uE194좖\uDD98漢\uE99Cﺞﺠ\uECA2\uD7A4쎦첨\uD9AA\uF2AC\uE6AE\uDFB0ힲ\uDCB4풶\uD8B8쾺튼춾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                text1 = RptMgrErrorHandler.b("ꦈ", A_1_1);
                num2 = (short) 51;
                num1 = (int) (IntPtr) num2;
                continue;
              case 22:
                switch (0)
                {
                  case 0:
                    goto label_86;
                  default:
                    continue;
                }
              case 23:
                if (num4 % 2 != 0)
                {
                  A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("\uE588\uE28A\uEA8C\uE78E\uE590\uF492\uE794\uF696\uE098", A_1_1));
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              case 24:
              case 66:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192힔\uE596\uEC98\uE89A\uF59C", A_1_1), RptMgrErrorHandler.b("ꪈ춊쮌뾎ꆐꂒ횔ꂖ궘", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ슐朗\uEF94\uF296", A_1_1), RptMgrErrorHandler.b("뢈릊", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ힐\uF292\uF894ﺖ\uF598\uE29A", A_1_1), RptMgrErrorHandler.b("좈力\uE48C\uEE8E\uFD90", A_1_1));
                num2 = (short) 41;
                num1 = (int) (IntPtr) num2;
                continue;
              case 26:
                text1 = current.Attributes[0].Value;
                flag2 = false;
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              case 30:
                if (current.Attributes[0].Value != AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38C年\uF490ﶒ\uE194ﺖ\uF698\uF59Aﲜ\uF39Eﺠ\uE2A2펤욦삨잪첬춮\uDDB0횲\uEAB4襁\uDCB8햺좼\uE0BE裀럂ꃄ\uAAC6뫈", A_1_1), currentUiCulture))
                {
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 31 /*0x1F*/:
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490솒杖\uE096", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490킒\uF094ﮖ\uF598", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uD988\uEA8Aﾌ\uEE8E\uF690\uE192\uF494\uE796\uF198", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192솔ﾖ\uF098\uF89A\uF69C\uF19E쒠킢횤", A_1_1), RptMgrErrorHandler.b("뢈꞊벌ꎎꆐ뾒ꖔ", A_1_1));
                num2 = (short) 45;
                num1 = (int) (IntPtr) num2;
                continue;
              case 32 /*0x20*/:
                if (current.Attributes[0].Value != AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38C年\uF490ﶒ\uE194ﺖ\uF698\uF59Aﲜ\uF39Eﺠ\uF0A2삤쮦첨좪\uD9AC쪮햰\uECB2\uF8B4튶ힸ캺\uE2BC\uF6BE뗀ꛂ꣄듆", A_1_1), currentUiCulture))
                {
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 33:
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              case 34:
                goto label_107;
              case 35:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD88力\uF88C\uE18E敖朗ﮔ\uF096욘좚\uF89C\uF39E쒠삢톤슦춨\uF4AA\uE0AC쪮\uDFB0욲\uEAB4ﺶ춸\uDEBA킼첾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_44;
              case 36:
                if (enumerator.MoveNext())
                {
                  current = (XmlNode) enumerator.Current;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 65;
                num1 = (int) (IntPtr) num2;
                continue;
              case 37:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD88力\uF88C\uE18E敖朗ﮔ\uF096욘좚\uF89C\uF39E쒠삢톤슦춨\uF4AA\uE0AC쪮\uDFB0욲\uEAB4ﺶ춸\uDEBA킼첾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 47;
                num1 = (int) (IntPtr) num2;
                continue;
              case 38:
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              case 39:
                text1 = RptMgrErrorHandler.b("ꦈ", A_1_1);
                num2 = (short) 54;
                num1 = (int) (IntPtr) num2;
                continue;
              case 40:
                if (flag3)
                {
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 41:
                if (flag1)
                {
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_44;
              case 42:
                num2 = (short) 17;
                num1 = (int) (IntPtr) num2;
                continue;
              case 43:
                num2 = (short) 59;
                num1 = (int) (IntPtr) num2;
                continue;
              case 44:
              case 53:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192힔\uE596\uEC98\uE89A\uF59C", A_1_1), RptMgrErrorHandler.b("ꪈ춊쮌뾎ꆐꂒ횔ꂖ궘", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ슐朗\uEF94\uF296", A_1_1), RptMgrErrorHandler.b("뢈릊", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ힐\uF292\uF894ﺖ\uF598\uE29A", A_1_1), RptMgrErrorHandler.b("좈力\uE48C\uEE8E\uFD90", A_1_1));
                text1 = current.Attributes[0].Value;
                Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uF288뮊\uF08C", A_1_1), (object) text1));
                A_0.WriteString(text1);
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uDD88\uEA8A\uEF8C\uE38E\uF490킒\uF094ﮖ\uF598", A_1_1));
                A_0.WriteStartElement(RptMgrErrorHandler.b("\uD988\uEA8Aﾌ\uEE8E\uF690\uE192\uF494\uE796\uF198", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192솔ﾖ\uF098\uF89A\uF69C\uF19E쒠킢횤", A_1_1), RptMgrErrorHandler.b("뢈꞊벌ꎎꆐ뾒ꖔ", A_1_1));
                num2 = (short) 48 /*0x30*/;
                num1 = (int) (IntPtr) num2;
                continue;
              case 45:
                if (num4 % 2 == 0)
                {
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("\uE588\uE28A\uEA8C\uE78E\uE590\uF492\uE794\uF696\uE098", A_1_1));
                num2 = (short) 66;
                num1 = (int) (IntPtr) num2;
                continue;
              case 46:
                text1 = RptMgrErrorHandler.b("ꦈ", A_1_1);
                num2 = (short) 25;
                num1 = (int) (IntPtr) num2;
                continue;
              case 47:
                if (flag2)
                {
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto label_41;
              case 48 /*0x30*/:
                if (num4 % 2 != 0)
                {
                  A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("\uE588\uE28A\uEA8C\uE78E\uE590\uF492\uE794\uF696\uE098", A_1_1));
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 64 /*0x40*/;
                num1 = (int) (IntPtr) num2;
                continue;
              case 49:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("얈\uE28A\uEA8C\uE78E\uE590풒杖ﮖﶘﺚ\uF39C\uED9E캠잢ﲤ슦얨잪슬\uD8AE", A_1_1));
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              case 50:
                num2 = (short) 62;
                num1 = (int) (IntPtr) num2;
                continue;
              case 52:
                if (current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38Cﮎ\uF090\uF092\uE194좖\uDD98漢\uE99Cﺞﺠ\uECA2\uD7A4쎦첨\uD9AA\uF2AC\uE6AE\uDFB0ힲ\uDCB4풶\uD8B8쾺튼춾", A_1_1), currentUiCulture))
                {
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                break;
              case 55:
                text1 = current.Attributes[0].Value;
                flag1 = false;
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              case 56:
                text1 = current.Attributes[0].Value;
                flag3 = false;
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              case 58:
                num2 = (short) 18;
                num1 = (int) (IntPtr) num2;
                continue;
              case 59:
                if (!(current.Attributes[0].Value == AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("쪈\uE48A\uE38C年\uF490ﶒ\uE194ﺖ\uF698\uF59Aﲜ\uF39Eﺠ\uF0A2삤쮦첨좪\uD9AC쪮햰\uECB2\uF8B4튶ힸ캺\uE2BC\uF6BE뗀ꛂ꣄듆", A_1_1), currentUiCulture)))
                {
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 38;
              case 60:
              case 63 /*0x3F*/:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uE48Aﾌ\uEB8E\uF490\uE192힔\uE596\uEC98\uE89A\uF59C", A_1_1), RptMgrErrorHandler.b("ꪈ춊쮌뾎ꆐꂒ횔ꂖ궘", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ슐朗\uEF94\uF296", A_1_1), RptMgrErrorHandler.b("뢈릊", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쾈\uE48A\uE38Cﮎ힐\uF292\uF894ﺖ\uF598\uE29A", A_1_1), RptMgrErrorHandler.b("좈力\uE48C\uEE8E\uFD90", A_1_1));
                A_0.WriteAttributeString(RptMgrErrorHandler.b("\uDD88\uEE8A\uF58Cﮎ킐ﾒﲔ\uF096\uF798\uF69A\uF89C\uF19E햠", A_1_1), RptMgrErrorHandler.b("\uDB88\uE28A\uEA8C\uE78E\uE590", A_1_1));
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              case 61:
                string text3;
                try
                {
                  text3 = current.Attributes[1].Value;
                }
                catch (Exception ex)
                {
                  text3 = "";
                }
                A_0.WriteString(text3);
                str = "";
                text1 = "";
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                A_0.WriteEndElement();
                ++num4;
                num2 = (short) 57;
                num1 = (int) (IntPtr) num2;
                continue;
              case 62:
                if (current.Attributes[0].Value != AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("\uDD88力\uF88C\uE18E敖朗ﮔ\uF096욘\uDA9A\uEB9Cﺞ좠쾢쒤얦얨캪\uF2AC\uE2AE풰\uDDB2살\uE8B6\uF0B8쾺\uD8BC튾닀", A_1_1), currentUiCulture))
                {
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto default;
              case 64 /*0x40*/:
                A_0.WriteAttributeString(RptMgrErrorHandler.b("쮈\uEA8A\uEE8C\uE48E\uF690\uE192杖\uE296\uF798ﾚ", A_1_1), RptMgrErrorHandler.b("얈\uE28A\uEA8C\uE78E\uE590풒杖ﮖﶘﺚ\uF39C\uED9E캠잢ﲤ슦얨잪슬\uD8AE", A_1_1));
                num2 = (short) 27;
                num1 = (int) (IntPtr) num2;
                continue;
              case 65:
                num2 = (short) 34;
                num1 = (int) (IntPtr) num2;
                continue;
              default:
label_86:
                num2 = (short) 36;
                num1 = (int) (IntPtr) num2;
                continue;
            }
            num2 = (short) 21;
            num1 = (int) (IntPtr) num2;
            continue;
label_41:
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
label_44:
            num2 = (short) 37;
            num1 = (int) (IntPtr) num2;
            continue;
label_92:
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
          }
label_107:
          break;
        }
        finally
        {
          IDisposable disposable;
          short num5;
          switch (0)
          {
            case 0:
label_101:
              disposable = enumerator as IDisposable;
              num5 = (short) 2;
              num1 = (int) (IntPtr) num5;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    goto label_108;
                  case 1:
                    disposable.Dispose();
                    num5 = (short) 0;
                    num1 = (int) (IntPtr) num5;
                    continue;
                  case 2:
                    num5 = (short) -15130;
                    int num6 = (int) num5;
                    num5 = (short) -15130;
                    int num7 = (int) num5;
                    switch (num6 == num7 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_108;
                      default:
                        num5 = (short) 0;
                        if (num5 == (short) 0)
                          ;
                        if (disposable != null)
                        {
                          num5 = (short) 1;
                          num1 = (int) (IntPtr) num5;
                          continue;
                        }
                        goto label_108;
                    }
                  default:
                    goto label_101;
                }
              }
label_108:;
          }
        }
    }
  }

  private void b(ref XmlTextWriter A_0, string A_1)
  {
    int A_1_1 = 4;
    short num1 = -10089;
    int num2 = (int) num1;
    num1 = (short) -10089;
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
        Trace.WriteLine(string.Format(RptMgrErrorHandler.b("풆있\uEA8A\uE08C\uEA8Eꮐ\uE892ꖔ\uEA96", A_1_1), (object) A_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("펆\uE888\uE98A\uE18C\uEA8E쎐ﲒ\uE294", A_1_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("펆\uE888\uE98A\uE18C\uEA8E튐\uF692璉ﮖ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("쒆\uE688\uE78A\uF88C\uE28Eﾐ삒\uE594\uF696\uF798", A_1_1), RptMgrErrorHandler.b("떆", A_1_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("힆\uE888力\uEC8C\uE88E\uE390\uF292\uE594ﾖ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("얆\uE688力\uE98C\uEA8E\uE390잒ﶔﺖ滛\uF09A\uF39C爵튠킢", A_1_1), RptMgrErrorHandler.b("떆ꖈ릊ꆌ붎붐ꆒ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("얆\uE688力\uE98C\uEA8E\uE390톒\uE794\uE296\uEA98\uF39A", A_1_1), RptMgrErrorHandler.b("ꒆ쾈춊붌뾎ꊐ킒ꊔꎖ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("얆\uE888\uE88A\uE68C\uE88E\uE390ﲒ\uE094練ﶘ", A_1_1), Colors.Coral.ToString());
        A_0.WriteAttributeString(RptMgrErrorHandler.b("솆\uE688\uE58A歷\uDC8E\uF890\uE992\uF094", A_1_1), RptMgrErrorHandler.b("뚆놈", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("솆\uE688\uE58A歷즎\uF090ﺒﲔﮖ\uE098", A_1_1), RptMgrErrorHandler.b("욆ﮈ\uE28A\uEC8C\uE38E", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("솆\uE688\uE58A歷\uD88E\uF490朗\uF294ﾖ\uED98", A_1_1), RptMgrErrorHandler.b("얆\uE688\uE78A\uE98C", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("솆\uE688力\uE88C\uE88E\uE390ﲒ\uE094練ﶘ", A_1_1), Colors.Black.ToString());
        A_0.WriteString(RptMgrErrorHandler.b("躆肈", A_1_1) + A_1);
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        break;
      default:
        goto case 1;
    }
  }

  private void a(ref XmlTextWriter A_0, string A_1)
  {
    int A_1_1 = 12;
    int num1 = 0;
    switch (num1)
    {
      default:
        int i;
        string str1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            i = 0;
            this.a(ref A_0, A_1, 2);
            str1 = A_1;
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator enumerator;
            int num3;
            int num4;
            XmlNodeList xmlNodeList1;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_50;
                case 1:
                case 4:
                  xmlNodeList1 = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢", A_1_1));
                  num3 = 0;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                case 5:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  try
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      string str2;
                      XmlNode current;
                      XmlNodeList xmlNodeList2;
                      int num5;
                      switch (num1)
                      {
                        case 0:
                        case 9:
                          num2 = (short) 10;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!current.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꢎ", A_1_1)))
                          {
                            num2 = (short) 8;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          str2 = RptMgrErrorHandler.b("궎", A_1_1) + current.Attributes[0].Value + RptMgrErrorHandler.b("궎", A_1_1);
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 4:
                          this.a(ref A_0);
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (!enumerator.MoveNext())
                          {
                            num2 = (short) 15;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current = (XmlNode) enumerator.Current;
                          A_0.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uF090\uF192璉\uF296쮘\uF49A\uEA9C", A_1_1));
                          A_0.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uF090\uF192璉\uF296\uDA98ﺚ\uF19C\uF39E", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("첎ﺐﾒ\uE094殺\uF798좚\uED9Cﺞ쾠", A_1_1), RptMgrErrorHandler.b("붎", A_1_1));
                          A_0.WriteStartElement(RptMgrErrorHandler.b("\uDF8E\uF090\uE192\uF494\uF096\uEB98漢\uED9C\uF79E", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("춎ﺐ\uE192\uF194\uF296\uEB98쾚\uF59C\uF69E슠좢쮤슦\uDAA8\uD8AA", A_1_1), RptMgrErrorHandler.b("뾎붐ꎒ릔Ꞗ떘ꦚ", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("춎ﺐ\uE192\uF194\uF296\uEB98\uD99A\uEF9C\uEA9E튠쮢", A_1_1), RptMgrErrorHandler.b("겎힐햒ꖔꞖꪘ\uD89Aꪜꮞ", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194쒖\uF098\uE19A\uF89C", A_1_1), RptMgrErrorHandler.b("뺎Ꞑ", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194톖\uF898\uF69A\uF49C\uF39E\uD8A0", A_1_1), RptMgrErrorHandler.b("캎\uE390朗\uF494ﮖ", A_1_1));
                          A_0.WriteAttributeString(RptMgrErrorHandler.b("즎ﺐﶒ\uE194삖ﲘ\uF29A煮\uF79E햠", A_1_1), RptMgrErrorHandler.b("춎ﺐﾒ\uF194", A_1_1));
                          XmlTextWriter xmlTextWriter1 = A_0;
                          string localName1 = RptMgrErrorHandler.b("즎ﺐ\uE192\uF094\uF096\uEB98\uF49A\uE89C\uF19E얠", A_1_1);
                          System.Windows.Media.Color color = Colors.DarkBlue;
                          string str3 = color.ToString();
                          xmlTextWriter1.WriteAttributeString(localName1, str3);
                          XmlTextWriter xmlTextWriter2 = A_0;
                          string localName2 = RptMgrErrorHandler.b("춎\uF090\uF092ﺔ\uF096\uEB98\uF49A\uE89C\uF19E얠", A_1_1);
                          color = Colors.Coral;
                          string str4 = color.ToString();
                          xmlTextWriter2.WriteAttributeString(localName2, str4);
                          A_0.WriteString(current.Attributes[i].Value);
                          A_0.WriteEndElement();
                          A_0.WriteEndElement();
                          A_0.WriteEndElement();
                          str2 = (string) null;
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (num5 >= xmlNodeList2.Count)
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          string str5 = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢ﺤ\uE7A6\uEFA8\uF8AA좬첮얰\uDAB2\uDAB4\uD9B6蒸", A_1_1) + str2 + RptMgrErrorHandler.b("튎뺐벒킔殺ﮘ튚\uF39C\uEC9E햠슢쮤쒦첨\uF0AA\uEDAC\uEAAE\uDCB0톲ﲴﺶﶸ蚺骼", A_1_1) + num5.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔튖\uF498連캜爵슠힢첤좦잨", A_1_1)).Item(0).Attributes[0].Value.ToString();
                          string str6 = RptMgrErrorHandler.b("꾎", A_1_1);
                          num4 = num5 + 1;
                          string str7 = num4.ToString();
                          string str8 = str5 + str6 + str7;
                          this.c(ref A_0, str8.Replace(RptMgrErrorHandler.b("ꦎ\uF090\uE392杖\uE496ꊘ", A_1_1), RptMgrErrorHandler.b("ꢎ", A_1_1)));
                          this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢ﺤ\uE7A6\uEFA8\uF8AA좬첮얰\uDAB2\uDAB4\uD9B6蒸", A_1_1) + str2 + RptMgrErrorHandler.b("튎뺐벒킔殺ﮘ튚\uF39C\uEC9E햠슢쮤쒦첨\uF0AA\uEDAC\uEAAE\uDCB0톲ﲴﺶﶸ蚺骼", A_1_1) + num5.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔튖\uF498連캜爵슠힢첤좦잨蒪芬ﲮﶰ\uF5B2\uDCB4튶햸\uDFBA", A_1_1));
                          this.a(ref A_0, this.g);
                          ++num5;
                          num2 = (short) 7;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                        case 14:
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          str2 = RptMgrErrorHandler.b("ꢎ", A_1_1) + current.Attributes[0].Value + RptMgrErrorHandler.b("ꢎ", A_1_1);
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (!(current.Attributes[i + 1].Value == RptMgrErrorHandler.b("즎", A_1_1)))
                          {
                            this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢ﺤ\uE7A6\uEFA8\uF8AA좬첮얰\uDAB2\uDAB4\uD9B6蒸", A_1_1) + str2 + RptMgrErrorHandler.b("튎뺐벒솔\uDB96\uDF98\uF29A\uF89C\uF39E얠", A_1_1));
                            this.a(ref A_0, this.g);
                            xmlNodeList2 = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢ﺤ\uE7A6\uEFA8\uF8AA좬첮얰\uDAB2\uDAB4\uD9B6蒸", A_1_1) + str2 + RptMgrErrorHandler.b("튎뺐벒킔殺ﮘ튚\uF39C\uEC9E햠슢쮤쒦첨", A_1_1));
                            num5 = 0;
                            num2 = (short) 14;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 12;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          goto label_8;
                        case 12:
                          this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢ﺤ\uE7A6\uEFA8\uF8AA좬첮얰\uDAB2\uDAB4\uD9B6蒸", A_1_1) + str2 + RptMgrErrorHandler.b("튎뺐벒펔\uDB96\uDF98\uF29A\uF89C\uF39E얠", A_1_1));
                          this.a(ref A_0, this.g);
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 15:
                          num2 = (short) 11;
                          num1 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    IDisposable disposable;
                    short num6;
                    switch (0)
                    {
                      case 0:
label_34:
                        disposable = enumerator as IDisposable;
                        num6 = (short) 2;
                        num1 = (int) (IntPtr) num6;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              goto label_40;
                            case 1:
                              disposable.Dispose();
                              num6 = (short) 0;
                              num1 = (int) (IntPtr) num6;
                              continue;
                            case 2:
                              num6 = (short) -8712;
                              int num7 = (int) num6;
                              num6 = (short) -8712;
                              int num8 = (int) num6;
                              switch (num7 == num8 ? 1 : 0)
                              {
                                case 0:
                                case 2:
                                  goto label_40;
                                default:
                                  num6 = (short) 0;
                                  if (num6 == (short) 0)
                                    ;
                                  if (disposable != null)
                                  {
                                    num6 = (short) 1;
                                    num1 = (int) (IntPtr) num6;
                                    continue;
                                  }
                                  goto label_40;
                              }
                            default:
                              goto label_34;
                          }
                        }
label_40:;
                    }
                  }
label_8:
                  ++num3;
                  num1 = 5;
                  continue;
                case 6:
                  if (xmlNodeList1.Count > 1)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 7;
                case 7:
                  enumerator = this.e.GetEnumerator();
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 0;
                  ref XmlTextWriter local = ref A_0;
                  string str9 = A_1;
                  string str10 = RptMgrErrorHandler.b("꾎", A_1_1);
                  num4 = num3 + 1;
                  string str11 = num4.ToString();
                  string A_1_2 = str9 + str10 + str11;
                  this.b(ref local, A_1_2);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (!A_1.Contains(RptMgrErrorHandler.b("ꢎ", A_1_1)))
                  {
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  str1 = RptMgrErrorHandler.b("궎", A_1_1) + A_1 + RptMgrErrorHandler.b("궎", A_1_1);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (num3 >= xmlNodeList1.Count)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.e = this.a.SelectNodes(RptMgrErrorHandler.b("ꂎ뺐햒\uF094\uF696\uED98\uEE9A\uEF9C爵猪\uE3A2\uE3A4\uE9A6좨욪좬銮", A_1_1) + str1 + RptMgrErrorHandler.b("튎뺐벒\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢ﺤ\uE7A6\uE0A8\uE2AA\uE9AC銮隰", A_1_1) + num3.ToString() + RptMgrErrorHandler.b("ꢎ첐벒몔쒖ﲘ\uF89A\uE99C\uF69E캠춢", A_1_1));
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  str1 = RptMgrErrorHandler.b("ꢎ", A_1_1) + A_1 + RptMgrErrorHandler.b("ꢎ", A_1_1);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_50:
            return;
        }
    }
  }

  private void a(ref XmlTextWriter A_0, string A_1, int A_2)
  {
    int A_1_1 = 19;
    short num1 = -379;
    int num2 = (int) num1;
    num1 = (short) -379;
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
        A_0.WriteStartElement(RptMgrErrorHandler.b("슕聯\uF899\uF09Bﮝ\uF29F춡펣", A_1_1));
        A_0.WriteStartElement(RptMgrErrorHandler.b("슕聯\uF899\uF09Bﮝ\uE39F잡좣쪥", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("풕\uF797\uE899\uF89Bﮝ튟\uF6A1첣쾥쮧솩슫쮭쎯솱", A_1_1), RptMgrErrorHandler.b("ꚕ뒗ꪙ낛꺝貟邡", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("풕\uF797\uE899\uF89Bﮝ튟\uE0A1횣펥\uDBA7슩", A_1_1), RptMgrErrorHandler.b("떕\uDE97\uDC99겛꺝邟銡钣隥", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("햕\uF797\uF699\uE99B\uF39D캟\uF1A1풣장욧", A_1_1), A_2.ToString());
        A_0.WriteStartElement(RptMgrErrorHandler.b("욕聯\uE899ﶛ劣튟쎡풣캥", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("풕\uF797\uE899\uF89Bﮝ튟\uF6A1첣쾥쮧솩슫쮭쎯솱", A_1_1), RptMgrErrorHandler.b("ꚕ뒗ꪙ낛꺝貟邡", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("풕\uF797\uE899\uF89Bﮝ튟\uE0A1횣펥\uDBA7슩", A_1_1), RptMgrErrorHandler.b("떕\uDE97\uDC99겛꺝鎟\uE1A1鎣銥", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("킕\uF797\uF499\uE89B춝즟\uD8A1솣", A_1_1), RptMgrErrorHandler.b("꒕ꪗ", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("킕\uF797\uF499\uE89B\uD89D솟쾡춣쪥톧", A_1_1), RptMgrErrorHandler.b("힕\uEA97\uF399ﶛ\uF29D", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("킕\uF797\uF499\uE89B증얟쮡쎣캥\uDCA7", A_1_1), RptMgrErrorHandler.b("풕\uF797\uF699\uF89B", A_1_1));
        A_0.WriteAttributeString(RptMgrErrorHandler.b("킕\uF797\uE899鍊劣튟춡톣좥첧", A_1_1), RptMgrErrorHandler.b("튕聯\uE899\uF79B\uDC9D첟힡솣", A_1_1));
        A_0.WriteString(A_1);
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        A_0.WriteEndElement();
        break;
      default:
        goto case 1;
    }
  }

  private bool a(reportType A_0)
  {
    int A_1_1 = 3;
    int num1 = 0;
    switch (num1)
    {
      default:
        int A_1_2;
        int A_2;
        int A_3;
        bool flag;
        string A_0_1;
        string A_1_3;
        string empty;
        string numberA8539UiValue;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            A_1_2 = 200;
            A_2 = 600;
            A_3 = 350;
            flag = true;
            int num3 = new CultureInfo(AppInfoManager.ReportsLangSelection).TextInfo.IsRightToLeft ? 1 : 0;
            A_0_1 = string.Empty;
            A_1_3 = string.Empty;
            empty = string.Empty;
            numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
            num2 = (short) 160 /*0xA0*/;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string A_4_1;
              int A_5_1;
              int A_6_1;
              int A_7_1;
              string A_4_2;
              int A_5_2;
              int A_6_2;
              int A_7_2;
              switch (num1)
              {
                case 0:
                  num2 = (short) 109;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 75;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 118;
                case 2:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뮉\uD98B춍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 131;
                case 3:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ첓펕", A_1_1)))
                  {
                    num2 = (short) 253;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 78;
                case 4:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉잋쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 275;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 5:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 230;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 6:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뮉잋쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 131;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_99;
                case 7:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) -30419;
                    int num4 = (int) num2;
                    num2 = (short) -30419;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_205;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 132;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                    goto case 78;
                case 8:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ욓\uF395ﺗ\uE899鍊\uED9D좟ﶡ隣殮\uE4A7쮩캫쮭\uDCAF鲱\uDEB3욵\uDFB7", A_1_1), 300, 590, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 216;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뢉\uD98B춍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 260;
                case 10:
                  if (numberA8539UiValue.Contains(RptMgrErrorHandler.b("놅즇쒉", A_1_1)))
                  {
                    num2 = (short) 224 /*0xE0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 69;
                case 11:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 177;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 12:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ\uD893ﾕ\uEF97\uF399\uE89B\uF69D\uEC9F쎡욣쎥쒧蒩\uE6ABﺭ\uF7AF", A_1_1), 200, 650, 220);
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ\uDC93캕\uDD97", A_1_1)))
                  {
                    num2 = (short) 171;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_138;
                case 14:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("킅\uED87\uF889\uF88B\uEB8D\uE88F", A_1_1)))
                  {
                    num2 = (short) 222;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 69;
                case 15:
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                case 49:
                case 117:
                case 213:
                case 229:
                case 283:
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 17:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뮋뺍ꂏꊑ\uE393ﾕ\uEC97\uF299킛ﾝ슟잡좣袥\uE2A7睊\uEBAB", A_1_1), 300, 650, 200);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 184;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 143;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 120;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) sbyte.MaxValue;
                case 20:
                  num2 = (short) 145;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뮍ꂏꊑ\uD893ﾕ", A_1_1)))
                  {
                    num2 = (short) 267;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case 22:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uD98B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 237;
                case 23:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 67;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 24;
                case 24:
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 86;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case 26:
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇붉\uD88B즍풏ꮑ쒓솕ꦗ\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 17;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 28:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뮉\uDF8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 65;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 131;
                case 29:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("햅\uDA87튉뺋벍ꂏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 200, 650, 220);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 241;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  if (!numberA8539UiValue.Trim().ToUpper().Contains(RptMgrErrorHandler.b("톅뾇", A_1_1)))
                  {
                    this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉릋뺍ꂏꊑ쮓\uDB95ꪗ얙킛ﾝ슟잡좣쎥첧蒩\uE6ABﺭ\uF7AF", A_1_1), 200, 590, 220);
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 157;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅낇뺉\uD98B춍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 252;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 197;
                case 32 /*0x20*/:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅낇뺉\uDF8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 197;
                case 33:
                  goto label_161;
                case 34:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_138;
                case 35:
                  num2 = (short) 243;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 61;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 37:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅몇뾉풋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 239;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 38:
                  A_4_1 = RptMgrErrorHandler.b("즅붇행잋\uDE8D\uDD8Fꎑ쮓ꂕ궗ꪙ겛튝즟ﶡ\uE8A3장쪧쾩삫쮭풯鲱ﺳ\uE6B5ﾷ", A_1_1);
                  num2 = (short) 150;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  num2 = (short) 141;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 105;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 107;
                case 41:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뢉\uDD8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 176 /*0xB0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 260;
                case 42:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉릋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 146;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 54;
                case 43:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뢋뺍ꂏꊑ\uD893ﾕ", A_1_1)))
                  {
                    num2 = (short) 199;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_99;
                case 44:
                  if (UtilityMack.IsAPX2000APX4000With2Knobs)
                  {
                    num2 = (short) 57;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 118;
                case 45:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDB8B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 46:
                  num2 = (short) 42;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  if (UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 68;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_241;
                case 48 /*0x30*/:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99펛겝躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("즅몇행잋\uDE8D\uDD8Fꎑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 250, 600, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 128 /*0x80*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 272;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뺋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 43;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 265;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 53:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉릋뮍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 165;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 95;
                case 54:
                  num2 = (short) 93;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ첓펕", A_1_1)))
                  {
                    num2 = (short) 207;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 250;
                case 56:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 180;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 121;
                case 57:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뺋뺍ꂏꊑ쮓ꊕꢗꪙ겛솝銟ﶡ\uEFA3좥잧좩\uF3AB\uE2AD톯킱톳\uDAB5\uDDB7\uDEB9銻풽낿ꗁ", A_1_1), 300, 590, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 118;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 58:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDD8B쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 111;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 106;
                case 59:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ\uD893ﾕ", A_1_1)))
                  {
                    this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ\uE393ﾕ\uEC97\uF299킛ﾝ슟잡좣袥\uE2A7睊\uEBAB", A_1_1), 200, 650, 220);
                    num2 = (short) 235;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅낇뺉\uDD8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 140;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 197;
                case 61:
                  num2 = (short) 90;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 62:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uDC87\uD989뺋뮍ꂏꊑ\uE493", A_1_1)))
                    goto label_84;
                  goto label_205;
                case 63 /*0x3F*/:
                  num2 = (short) 173;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 64 /*0x40*/:
                  goto label_414;
                case 65:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 66:
                  num2 = (short) 193;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 67:
                  num2 = (short) 70;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 68:
                  num2 = (short) 269;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  num2 = (short) 225;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅벇뎉\uD88B즍풏ꮑ쒓솕ꦗ\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 188;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 24;
                case 71:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 130;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 69;
                case 72:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 284;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 50;
                case 73:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  num2 = (short) 182;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  num2 = (short) 189;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 75:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 76:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
                  num2 = (short) 271;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                  num2 = (short) 142;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 79:
                  num2 = (short) 87;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                  A_4_2 = RptMgrErrorHandler.b("쎅붇행잋\uDE8D\uDD8Fꎑ쮓ꎕ궗ꪙ겛솝\uEC9F쎡욣쎥쒧쾩좫肭絛\uE2B1\uF3B3", A_1_1);
                  num2 = (short) 122;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 81:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 192 /*0xC0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_414;
                case 82:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 148;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 15;
                case 83:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 191;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 246;
                case 84:
                  num2 = (short) 156;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                case 175:
                case 235:
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 107;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 86:
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 87:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뮉\uDD8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 101;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 131;
                case 88:
                  num2 = (short) 151;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 89:
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  if (UtilityMack.IsWorldWidePro)
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 91:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 93:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 88;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 241;
                case 94:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 92;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 95;
                case 95:
                  num2 = (short) 19;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 96 /*0x60*/:
                  num2 = (short) 100;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                  if (A_0 == reportType.HandOutO3)
                  {
                    num2 = (short) 179;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 98:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, A_4_2, A_5_2, A_6_2, A_7_2);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 99:
                case 254:
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 54;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 100:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDF8B쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 257;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 101:
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 102:
                  num2 = (short) 220;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 103:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99펛ꮝ躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  A_4_1 = RptMgrErrorHandler.b("즅붇행잋\uDE8D\uDD8Fꎑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1);
                  A_5_1 = 250;
                  A_6_1 = 600;
                  A_7_1 = 300;
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 104:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 105:
                  num2 = (short) 245;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ욓\uF395ﺗ\uE899鍊\uED9D좟ﶡ鞣殮\uE4A7쮩캫쮭\uDCAF鲱\uDEB3욵\uDFB7", A_1_1), 300, 590, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 219;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 107:
                  num2 = (short) 251;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  num2 = (short) 183;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 109:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅릇뾉잋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 110:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 111:
                  num2 = (short) 226;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 112 /*0x70*/:
                  A_4_1 = RptMgrErrorHandler.b("즅붇행잋\uDE8D\uDD8Fꎑ쮓ꂕ궗ꪙ겛솝\uEC9F쎡욣쎥쒧쾩좫肭絛\uE2B1\uF3B3", A_1_1);
                  num2 = (short) sbyte.MaxValue;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 113:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 155;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 114:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅릇뾉풋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 198;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 115:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ\uDC93", A_1_1)))
                  {
                    num2 = (short) 135;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_304;
                case 116:
                  if (UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 133;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_282;
                case 118:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 119:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉잋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 242;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 120:
                  num2 = (short) 214;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 121:
                case 161:
                case 216:
                case 219:
                case 238:
                  num2 = (short) 82;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 122:
                  num2 = (short) 256 /*0x0100*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 123:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉릋뮍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 80 /*0x50*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 122;
                case 124:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 201;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_304;
                case 125:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ첓펕잗횙ﶛﲝ얟캡솣슥蚧\uE0A9ﲫ\uE9AD", A_1_1), 200, 650, 220);
                  num2 = (short) 175;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 126:
                  if (A_0 == reportType.HandOutO2)
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 128 /*0x80*/;
                case (int) sbyte.MaxValue:
                  num2 = (short) 264;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 128 /*0x80*/:
                  num2 = (short) 234;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 129:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉펋삍햏쪑삓즕풗ﮙﺛﮝ첟잡삣袥\uE2A7睊\uEBAB", A_1_1), 300, 650, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 236;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 130:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 131:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뢋뺍ꂏꊑ\uD893ﾕ잗ꮙ늛ꮝﾟ\uEEA1얣쒥춧용즫쪭麯\uF8B1\uE4B3\uF1B5", A_1_1), 300, 590, 300);
                  num2 = (short) 117;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 132:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 133:
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 134:
                  if (A_0 == reportType.HandOutE5)
                  {
                    num2 = (short) 153;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 135:
                  goto label_190;
                case 136:
                  num2 = (short) 25;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 137:
                  num2 = (short) 262;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 138:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅몇뾉잋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 231;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 139:
                  num2 = (short) 123;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 140:
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 141:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDD8B쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 228;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 237;
                case 142:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 212;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 217;
                case 143:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뾉\uD88B즍얏ꮑ쒓솕ꂗ\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 108;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) byte.MaxValue;
                case 144 /*0x90*/:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("킅\uED87\uF889\uF88B\uEB8D\uE88F춑ꚓ즕풗ﮙﺛﮝ첟잡삣袥슧\uDAA9쮫", A_1_1), 300, 590, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3, !Product.IsVertex());
                  num2 = (short) 246;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 145:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 181;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 154;
                case 146:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 147:
                  num2 = (short) 81;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 148:
                  num2 = (short) 169;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 149:
                  num2 = (short) 62;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 150:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, A_4_1, A_5_1, A_6_1, A_7_1);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 152;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 151:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("햅\uDA87튉뺋벍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 29;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 241;
                case 152:
                  num2 = (short) 223;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 153:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99\uD99Bꮝ躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  A_4_2 = RptMgrErrorHandler.b("쎅붇행잋\uDE8D\uDD8Fꎑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1);
                  A_5_2 = 250;
                  A_6_2 = 600;
                  A_7_2 = 300;
                  num2 = (short) 247;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 154:
                  num2 = (short) 134;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 155:
                  num2 = (short) 172;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 156:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDD8B쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 233;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 157:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉릋뺍ꂏꊑ쮓\uDB95ꮗ얙킛ﾝ슟잡좣쎥첧蒩\uE6ABﺭ\uF7AF", A_1_1), 200, 590, 220);
                  num2 = (short) 254;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 158:
                  num2 = (short) 185;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 159:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDF8B쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 66;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 237;
                case 160 /*0xA0*/:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 218;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 184;
                case 162:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 248;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_282;
                case 163:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뾋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 268;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 50;
                case 164:
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 165:
                  A_4_1 = RptMgrErrorHandler.b("즅붇행잋\uDE8D\uDD8Fꎑ쮓ꎕ궗ꪙ겛솝\uEC9F쎡욣쎥쒧쾩좫肭絛\uE2B1\uF3B3", A_1_1);
                  num2 = (short) 95;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 166:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 249;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 158;
                case 167:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDB8B춍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 205;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_241;
                case 168:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뢉잋쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 260;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 169:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뢋뺍ꂏꊑ첓\uDE95", A_1_1)))
                  {
                    num2 = (short) 187;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 15;
                case 170:
                  num2 = (short) 138;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 171:
                  goto label_157;
                case 172:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉겋삍햏쪑삓", A_1_1)))
                  {
                    num2 = (short) 129;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 173:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDB8B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 237;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_282;
                case 174:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅뮇뾉\uD98B춍쒏ꮑ쒓솕ꂗ\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 0;
                    num2 = (short) 277;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 158;
                case 176 /*0xB0*/:
                  num2 = (short) 266;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 177:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 178:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 259;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 121;
                case 179:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99펛궝躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("즅뮇행쾋\uE18Dﺏ\uE691\uE693秊\uF497튙鍊ﾝ쒟\uEEA1얣쒥춧용즫쪭麯\uF8B1\uE4B3\uF1B5", A_1_1), 250, 600, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 154;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 180:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ쮓꒕잗톙\uF29B\uF19D슟ﶡ\uE8A3장쪧쾩삫肭\uDAAF슱펳", A_1_1), 300, 590, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 121;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 181:
                  num2 = (short) 97;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 182:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅낇뺉잋쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 164;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 197;
                case 183:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅벇뾉\uD88B즍얏ꮑ쒓솕ꂗ\uDB99튛", A_1_1)))
                  {
                    num2 = (short) byte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 184:
                  num2 = (short) 36;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 185:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 74;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 20;
                case 186:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 190;
                case 187:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뢋뺍ꂏꊑ첓\uDE95잗횙ﶛﲝ얟캡誣첥\uD8A7충", A_1_1), 300, 590, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 188:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("삅\uE187\uF889\uE98B쎍\uF18F\uF191ﾓꞕ잗횙ﶛﲝ얟캡솣슥蚧\uE0A9ﲫ\uE9AD", A_1_1), 200, 650, 220);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 189:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅몇뾉\uD98B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 282;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 190:
                  num2 = (short) 166;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 191:
                  num2 = (short) 281;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 192 /*0xC0*/:
                  num2 = (short) 126;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 193:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉잋쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 237;
                case 194:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅릇뾉\uD98B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 195:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 263;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 217;
                case 196:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99펛ꞝ躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("즅놇행쾋揄\uE28Fﺑ\uDC93\uF395聯ﺙ킛ﾝ슟잡좣쎥첧蒩\uE6ABﺭ\uF7AF", A_1_1), 225, 650, 250);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 147;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 197:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ쮓ꞕ뚗꾙쎛튝솟삡솣쪥춧캩芫\uE4AD\uE0AF\uF5B1", A_1_1), 300, 590, 300);
                  num2 = (short) 283;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 198:
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 199:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 200:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뮍ꂏꊑ\uD893ﾕ", A_1_1)))
                  {
                    num2 = (short) 38;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 150;
                case 201:
                  num2 = (short) 115;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 202:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 102;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_263;
                case 203:
                  num2 = (short) 210;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 204:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDB8B춍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 106;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_263;
                case 205:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑﶓ즕ꮗ얙킛ﾝ슟잡좣袥슧\uDAA9쮫", A_1_1), 300, 590, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 238;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 206:
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 207:
                  num2 = (short) 276;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 208 /*0xD0*/:
                  if (numberA8539UiValue.Contains(RptMgrErrorHandler.b("낅즇쒉", A_1_1)))
                  {
                    num2 = (short) 144 /*0x90*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 246;
                case 209:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uD98B춍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 137;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 210:
                  if (A_0 == reportType.HandOutO9)
                  {
                    num2 = (short) 196;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 147;
                case 211:
                  num2 = (short) 221;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 212:
                  num2 = (short) 195;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 214:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뮍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 112 /*0x70*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case (int) sbyte.MaxValue;
                case 215:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅낇뺉\uDB8B춍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 197;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 51;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 217:
                  num2 = (short) 124;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 218:
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 220:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_263;
                case 221:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뮍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 261;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 136;
                case 222:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 223:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 203;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 147;
                case 224 /*0xE0*/:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("킅\uED87\uF889\uF88B\uEB8D\uE88F춑ꞓ즕풗ﮙﺛﮝ첟잡삣袥슧\uDAA9쮫", A_1_1), 300, 590, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3, !Product.IsVertex());
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 225:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 149;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_84;
                case 226:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDF8B쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 232;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 106;
                case 227:
                  num2 = (short) 200;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 228:
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 230:
                  num2 = (short) 209;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 231:
                  num2 = (short) 114;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 232:
                  num2 = (short) 279;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 233:
                  num2 = (short) 270;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 234:
                  if (A_0 == reportType.HandOutO7)
                  {
                    num2 = (short) 273;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_414;
                case 236:
                  num2 = (short) 186;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 237:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑﶓ즕ꪗ얙킛ﾝ슟잡좣袥슧\uDAA9쮫", A_1_1), 300, 590, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 161;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 239:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉펋삍ꖏꊑ쮓\uD895ꮗꪙ쎛튝솟삡솣쪥춧캩芫\uE4AD\uE0AF\uF5B1", A_1_1), 300, 650, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 20;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 240 /*0xF0*/:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 206;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_241;
                case 241:
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 242:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 243:
                  if (A_0 == reportType.HandOutO5)
                  {
                    num2 = (short) 103;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 152;
                case 244:
                  num2 = (short) 168;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 245:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ", A_1_1)))
                  {
                    num2 = (short) 110;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 250;
                case 246:
                  num2 = (short) 71;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 247:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 139;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 122;
                case 248:
                  num2 = (short) 116;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 249:
                  num2 = (short) 174;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 250:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  num2 = (short) 274;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 251:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 46;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 54;
                case 252:
                  num2 = (short) 215;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 253:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ첓펕잗횙ﶛﲝ얟캡솣슥蚧삩\uDCAB즭", A_1_1), 200, 650, 220);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 78;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case (int) byte.MaxValue:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉펋삍햏쪑삓즕삗풙쎛튝솟삡솣쪥춧캩芫\uE4AD\uE0AF\uF5B1", A_1_1), 300, 650, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 190;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 256 /*0x0100*/:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 211;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 136;
                case 257:
                  num2 = (short) 119;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 258:
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 259:
                  num2 = (short) 56;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 260:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뺋뺍ꂏꊑ쮓ꞕ뚗꾙쎛튝솟삡솣쪥춧캩芫\uE4AD\uE0AF\uF5B1", A_1_1), 300, 590, 300);
                  num2 = (short) 49;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 261:
                  A_4_2 = RptMgrErrorHandler.b("쎅붇행잋\uDE8D\uDD8Fꎑ쮓ꂕ궗ꪙ겛솝\uEC9F쎡욣쎥쒧쾩좫肭絛\uE2B1\uF3B3", A_1_1);
                  num2 = (short) 136;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 262:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDD8B쪍횏ꮑ쒓솕꺗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 8;
                case 263:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ\uE393ﾕ\uEC97\uF299킛ﾝ슟잡좣袥슧\uDAA9쮫", A_1_1), 200, 650, 220);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 217;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 264:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 227;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 150;
                case 265:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뺋뺍ꂏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 300, 590, 300);
                  num2 = (short) 213;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 266:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅붇뢉\uDF8B쪍풏ꮑ쒓솕궗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 244;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 260;
                case 267:
                  A_4_2 = RptMgrErrorHandler.b("쎅붇행잋\uDE8D\uDD8Fꎑ쮓ꂕ궗ꪙ겛튝즟ﶡ\uE8A3장쪧쾩삫쮭풯鲱ﺳ\uE6B5ﾷ", A_1_1);
                  num2 = (short) 98;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 268:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뾋뺍ꂏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 240 /*0xF0*/, 590, 200);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 50;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 269:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uD98B춍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 84;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 270:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uDF8B쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 76;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 205;
                case 271:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉\uD98B춍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 258;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 106;
                case 272:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 300, 590, 300);
                  num2 = (short) 229;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 273:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99펛ꦝ躟\uDAA1얣쮥쒧", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("즅뾇행잋\uDE8D\uDD8Fꎑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 250, 600, 300);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 64 /*0x40*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 274:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ첓펕", A_1_1)))
                  {
                    num2 = (short) 125;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 275:
                  num2 = (short) 167;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 276:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("입\uD887튉몋뺍ꂏꊑ\uD893ﾕ", A_1_1)))
                  {
                    num2 = (short) 250;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 107;
                case 277:
                  A_0_1 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
                  A_1_3 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉펋삍ꞏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 300, 650, 320);
                  flag = this.a(A_0_1, A_1_3, empty, A_1_2, A_2, A_3);
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 278:
                  num2 = (short) 208 /*0xD0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 279:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("캅놇뢉잋쪍\uD88Fꮑ쒓솕꾗\uDB99튛", A_1_1)))
                  {
                    num2 = (short) 280;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 106;
                case 280:
                  num2 = (short) 204;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 281:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("킅\uED87\uF889\uF88B\uEB8D\uE88F", A_1_1)))
                  {
                    num2 = (short) 278;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 246;
                case 282:
                  num2 = (short) 194;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 284:
                  num2 = (short) 163;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 202;
              num1 = (int) (IntPtr) num2;
              continue;
label_84:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
label_99:
              this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뢋뺍ꂏꊑ쮓\uDA95聯\uF899鍊\uF29D얟욡誣\uECA5\uF8A7\uEDA9", A_1_1), 300, 590, 300);
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
label_138:
              num2 = (short) 72;
              num1 = (int) (IntPtr) num2;
              continue;
label_205:
              num2 = (short) 33;
              num1 = (int) (IntPtr) num2;
              continue;
label_241:
              num2 = (short) 178;
              num1 = (int) (IntPtr) num2;
              continue;
label_263:
              num2 = (short) 162;
              num1 = (int) (IntPtr) num2;
              continue;
label_282:
              num2 = (short) 240 /*0xF0*/;
              num1 = (int) (IntPtr) num2;
              continue;
label_304:
              num2 = (short) 34;
              num1 = (int) (IntPtr) num2;
            }
label_157:
            string A_0_2 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
            string A_1_4 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ\uDC93캕\uDD97얙킛ﾝ슟잡좣쎥첧蒩욫\uDEAD\uD7AF", A_1_1), 200, 650, 220);
            return this.a(A_0_2, A_1_4, empty, A_1_2, A_2, A_3);
label_161:
            string A_0_3 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
            string A_1_5 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉붋뺍ꂏꊑ욓\uF395ﺗ\uE899鍊\uED9D좟ﶡ鞣殮\uE4A7쮩캫쮭\uDCAF鲱\uDEB3욵\uDFB7", A_1_1), 300, 590, 320);
            return this.a(A_0_3, A_1_5, empty, A_1_2, A_2, A_3);
label_190:
            string A_0_4 = RptMgrErrorHandler.b("삅\uE487\uE589ﮋ욍\uF18Fﲑ\uF093\uD995\uED97\uEE99늛\uE69D솟쾡좣", A_1_1);
            string A_1_6 = RptMgrErrorHandler.b("풅\uE987\uEE89\uE58B\uE18D쾏\uDA91\uF593\uF895ﲗ\uF599\uE99B\uEA9D", A_1_1);
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("입\uD887튉뒋뺍ꂏꊑ\uDC93즕풗ﮙﺛﮝ첟잡삣袥슧\uDAA9쮫", A_1_1), 200, 650, 220);
            return this.a(A_0_4, A_1_6, empty, A_1_2, A_2, A_3);
label_414:
            return flag;
        }
    }
  }

  private bool a(string A_0, string A_1, string A_2, int A_3, int A_4, int A_5, bool A_6 = true)
  {
    int A_1_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        this.b = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏횑\uF593\uE295聯", A_1_1));
        int i = 0;
        int num2 = 0;
        bool flag1 = true;
        CultureInfo cultureInfo = new CultureInfo(AppInfoManager.ReportsLangSelection);
        bool isRightToLeft = cultureInfo.TextInfo.IsRightToLeft;
        try
        {
          XmlTextWriter xmlTextWriter1;
          short num3;
          switch (0)
          {
            case 0:
label_5:
              xmlTextWriter1 = new XmlTextWriter(Global.flowDocPath + A_0, Encoding.Unicode);
              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("좍ﲏ\uFD91\uE393튕\uF797蓮\uE99B\uF39D얟첡킣", A_1_1));
              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uF68Dﶏﺑ望\uE595", A_1_1), RptMgrErrorHandler.b("\uE68D\uE48F\uE691\uE493겕랗떙\uEF9Bﶝ좟잡즣장\uDBA7蒩솫잭펯삱\uDBB3억ힷ\uDCB9좻邽ꎿ귁꧃\uE9C5뿇ꏉꋋ\uA8CD꣏\uFDD1\uE6D3\uE6D5\uE8D7\uECD9\uF3DBꛝ臟迡裣짥飧飩觫鷭闯鳱胳韵賷鏹鏻都", A_1_1));
              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uF68Dﶏﺑ望\uE595ꊗ\uE299", A_1_1), RptMgrErrorHandler.b("\uE68D\uE48F\uE691\uE493겕랗떙\uEF9Bﶝ좟잡즣장\uDBA7蒩솫잭펯삱\uDBB3억ힷ\uDCB9좻邽ꎿ귁꧃\uE9C5뿇ꏉꋋ\uA8CD꣏\uFDD1\uE6D3\uE6D5\uE8D7\uECD9\uF3DBꛝ臟迡裣", A_1_1));
              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("삍\uF18Fﾑ\uF193", A_1_1), RptMgrErrorHandler.b("\uE88Dﲏ\uF691ﮓ\uF595", A_1_1));
              num3 = (short) 0;
              num1 = (int) (IntPtr) num3;
              goto default;
            default:
              while (true)
              {
                IEnumerator enumerator1;
                switch (num1)
                {
                  case 0:
                    if (this.b.Count != 0)
                    {
                      num3 = (short) 2;
                      num1 = (int) (IntPtr) num3;
                      continue;
                    }
                    break;
                  case 1:
                    goto label_668;
                  case 2:
                    enumerator1 = this.b.GetEnumerator();
                    num3 = (short) 3;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  case 3:
                    IDisposable disposable;
                    try
                    {
                      num3 = (short) 23;
                      num1 = (int) (IntPtr) num3;
                      while (true)
                      {
                        bool flag2;
                        IEnumerator enumerator2;
                        XmlNode current1;
                        IEnumerator enumerator3;
                        XmlNode xmlNode;
                        IEnumerator enumerator4;
                        switch (num1)
                        {
                          case 0:
                            num3 = (short) 21;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 1:
                          case 7:
                          case 17:
                          case 24:
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("벍ꊏ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹\uDA97\uF699ﶛﶝ쮟", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                            xmlTextWriter1.WriteString(AppResources.ResourceManager.GetString(A_1, cultureInfo) + RptMgrErrorHandler.b("꺍낏늑", A_1_1) + current1.Attributes[i].Value);
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("좍ﲏ\uFD91\uF593\uE295ﶗ\uE899", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uD98D憐\uF691\uE093ﺕ", A_1_1), A_5.ToString());
                            num3 = (short) 13;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 2:
                            if (!enumerator1.MoveNext())
                            {
                              num3 = (short) 0;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            current1 = (XmlNode) enumerator1.Current;
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDD8D\uF58F\uF191\uE093ﾕ\uF797\uF499", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uE28F\uF791\uF593ﶕ좗ﮙﮛﮝ\uE29F잡슣즥\uDAA7쾩", A_1_1), RptMgrErrorHandler.b("\uDA8D\uE28F\uE791\uF193", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("슍\uF58F\uF491\uE093", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("잍ﶏ\uF391\uF393\uF395", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍\uF58Fﮑ\uF393ﺕ\uEC97", A_1_1), RptMgrErrorHandler.b("뮍ꂏ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8D\uE48F\uE091\uF193\uE295ﮗ\uF299", A_1_1), RptMgrErrorHandler.b("좍憐ﺑ\uF893", A_1_1));
                            num3 = (short) 22;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 3:
                            try
                            {
                              num3 = (short) 5;
                              num1 = (int) (IntPtr) num3;
                              while (true)
                              {
                                string str1;
                                XmlNode current2;
                                switch (num1)
                                {
                                  case 0:
                                    if (isRightToLeft)
                                    {
                                      num3 = (short) 14;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    enumerator3 = this.e.GetEnumerator();
                                    num3 = (short) 10;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 1:
                                  case 12:
                                    this.e = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str1 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B", A_1_1));
                                    num3 = (short) 7;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 2:
                                    if (!enumerator2.MoveNext())
                                    {
                                      num3 = (short) 9;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    current2 = (XmlNode) enumerator2.Current;
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.White.ToString());
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꊑ뢓ꚕ뒗ꪙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꮗ\uD999ꮛꪝ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDE8D\uF18F\uF691\uF093ﾕ\uF697ﶙ", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B\uD99D튟춡톣횥", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꊑ뢓ꚕ뒗ꢙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("벍", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꊑ뢓ꚕ뒗ꢙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꮗ\uD999ꮛꪝ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("벍ꊏ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    str1 = (string) null;
                                    num3 = (short) 11;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 3:
                                    try
                                    {
                                      num3 = (short) 13;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        string str2;
                                        XmlNode current3;
                                        string str3;
                                        switch (num1)
                                        {
                                          case 0:
                                            if (xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str2 = RptMgrErrorHandler.b("겍", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 2;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            if (enumerator3.MoveNext())
                                            {
                                              current3 = (XmlNode) enumerator3.Current;
                                              str3 = (string) null;
                                              num3 = (short) 9;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 12;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                          case 5:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str1 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str3 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str2 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            enumerator4 = this.f.GetEnumerator();
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            str2 = RptMgrErrorHandler.b("ꦍ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 5;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            try
                                            {
                                              num3 = (short) 1;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                switch (num1)
                                                {
                                                  case 0:
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
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
                                                  case 3:
                                                    goto label_576;
                                                  case 4:
                                                    if (!enumerator4.MoveNext())
                                                    {
                                                      num3 = (short) 0;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    XmlNode current4 = (XmlNode) enumerator4.Current;
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                                                    xmlTextWriter1.WriteString(current4.InnerText);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
                                                num3 = (short) 4;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              switch (0)
                                              {
                                                case 0:
label_566:
                                                  disposable = enumerator4 as IDisposable;
                                                  num1 = 1;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        goto label_570;
                                                      case 1:
                                                        if (disposable != null)
                                                        {
                                                          num1 = 2;
                                                          continue;
                                                        }
                                                        goto label_570;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num1 = 0;
                                                        continue;
                                                      default:
                                                        goto label_566;
                                                    }
                                                  }
label_570:;
                                              }
                                            }
label_576:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                                            xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 6:
                                          case 11:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str1 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str3 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            str2 = (string) null;
                                            num3 = (short) 0;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 7:
                                            str3 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current3.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 11;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 9:
                                            if (!current3.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              num3 = (short) 7;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str3 = RptMgrErrorHandler.b("겍", A_1_1) + current3.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 10:
                                            goto label_635;
                                          case 12:
                                            num3 = (short) 10;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 13:
                                            switch (0)
                                            {
                                              case 0:
                                                break;
                                              default:
                                                continue;
                                            }
                                            break;
                                        }
                                        num3 = (short) 1;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num4;
                                      switch (0)
                                      {
                                        case 0:
label_589:
                                          disposable = enumerator3 as IDisposable;
                                          num4 = (short) 1;
                                          num1 = (int) (IntPtr) num4;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                disposable.Dispose();
                                                num4 = (short) 2;
                                                num1 = (int) (IntPtr) num4;
                                                continue;
                                              case 1:
                                                if (disposable != null)
                                                {
                                                  num4 = (short) 0;
                                                  num1 = (int) (IntPtr) num4;
                                                  continue;
                                                }
                                                goto label_593;
                                              case 2:
                                                goto label_593;
                                              default:
                                                goto label_589;
                                            }
                                          }
label_593:;
                                      }
                                    }
                                  case 4:
                                    str1 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current2.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                    num3 = (short) 12;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 5:
                                    switch (0)
                                    {
                                      case 0:
                                        goto label_550;
                                      default:
                                        continue;
                                    }
                                  case 6:
                                    goto label_14;
                                  case 7:
                                    if (this.e.Count > 0)
                                    {
                                      num3 = (short) 8;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    break;
                                  case 8:
                                    num3 = (short) 0;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 9:
                                    num3 = (short) 6;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 10:
                                    try
                                    {
                                      num3 = (short) 5;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        string str4;
                                        string str5;
                                        XmlNode current5;
                                        switch (num1)
                                        {
                                          case 0:
                                          case 8:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str1 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str4 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            str5 = (string) null;
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                          case 6:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str1 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str4 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str5 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                                            xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            enumerator4 = this.f.GetEnumerator();
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            if (current5.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str4 = RptMgrErrorHandler.b("겍", A_1_1) + current5.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 8;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 10;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            try
                                            {
                                              num3 = (short) 3;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                switch (num1)
                                                {
                                                  case 0:
                                                    if (!enumerator4.MoveNext())
                                                    {
                                                      num3 = (short) 4;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    XmlNode current6 = (XmlNode) enumerator4.Current;
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), RptMgrErrorHandler.b("쪍\uF18F\uE091ﾓ풕\uF497\uEF99鍊", A_1_1));
                                                    xmlTextWriter1.WriteString(current6.InnerText);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                    goto label_604;
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
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
                                                num3 = (short) 0;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num5;
                                              switch (0)
                                              {
                                                case 0:
label_622:
                                                  disposable = enumerator4 as IDisposable;
                                                  num5 = (short) 0;
                                                  num1 = (int) (IntPtr) num5;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num5 = (short) 1;
                                                          num1 = (int) (IntPtr) num5;
                                                          continue;
                                                        }
                                                        goto label_626;
                                                      case 1:
                                                        disposable.Dispose();
                                                        num5 = (short) 2;
                                                        num1 = (int) (IntPtr) num5;
                                                        continue;
                                                      case 2:
                                                        goto label_626;
                                                      default:
                                                        goto label_622;
                                                    }
                                                  }
label_626:;
                                              }
                                            }
label_604:
                                            xmlTextWriter1.WriteEndElement();
                                            num3 = (short) 11;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            if (!xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              num3 = (short) 12;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str5 = RptMgrErrorHandler.b("겍", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 5:
                                            switch (0)
                                            {
                                              case 0:
                                                break;
                                              default:
                                                continue;
                                            }
                                            break;
                                          case 7:
                                            goto label_635;
                                          case 9:
                                            num3 = (short) 7;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 10:
                                            str4 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current5.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 0;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 12:
                                            str5 = RptMgrErrorHandler.b("ꦍ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 13:
                                            if (enumerator3.MoveNext())
                                            {
                                              current5 = (XmlNode) enumerator3.Current;
                                              str4 = (string) null;
                                              num3 = (short) 2;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 9;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                        }
                                        num3 = (short) 13;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num6;
                                      switch (0)
                                      {
                                        case 0:
label_630:
                                          disposable = enumerator3 as IDisposable;
                                          num6 = (short) 0;
                                          num1 = (int) (IntPtr) num6;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num6 = (short) 1;
                                                  num1 = (int) (IntPtr) num6;
                                                  continue;
                                                }
                                                goto label_634;
                                              case 1:
                                                disposable.Dispose();
                                                num6 = (short) 2;
                                                num1 = (int) (IntPtr) num6;
                                                continue;
                                              case 2:
                                                goto label_634;
                                              default:
                                                goto label_630;
                                            }
                                          }
label_634:;
                                      }
                                    }
                                  case 11:
                                    if (!current2.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                    {
                                      num3 = (short) 4;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    str1 = RptMgrErrorHandler.b("겍", A_1_1) + current2.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                    num3 = (short) 1;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 14:
                                    enumerator3 = this.e.GetEnumerator();
                                    num3 = (short) 3;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  default:
label_550:
                                    num3 = (short) 2;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                }
label_635:
                                xmlTextWriter1.WriteEndElement();
                                xmlTextWriter1.WriteEndElement();
                                num1 = 13;
                              }
                            }
                            finally
                            {
                              switch (0)
                              {
                                case 0:
label_649:
                                  disposable = enumerator2 as IDisposable;
                                  num1 = 0;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num1)
                                    {
                                      case 0:
                                        if (disposable != null)
                                        {
                                          num1 = 1;
                                          continue;
                                        }
                                        goto label_653;
                                      case 1:
                                        disposable.Dispose();
                                        num1 = 2;
                                        continue;
                                      case 2:
                                        goto label_653;
                                      default:
                                        goto label_649;
                                    }
                                  }
label_653:;
                              }
                            }
label_14:
                            this.c = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱鎳", A_1_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("첍\uE58F\uE691\uE093秊\uF697\uE999쎛ﾝ캟욡ﮣ\uE5A5잧쒩\uD8AB\uDCAD\uDFAF\uDEB1잳", A_1_1), cultureInfo) + RptMgrErrorHandler.b("ꦍ춏", A_1_1));
                            enumerator2 = this.c.GetEnumerator();
                            num1 = 16 /*0x10*/;
                            continue;
                          case 4:
                            if (!isRightToLeft)
                            {
                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍ﾏ\uE091ﶓ\uEC95\uF797\uF499\uE89Bﾝ첟\uE3A1좣쾥쾧쒩솫쮭\uDEAF욱", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                              num3 = (short) 25;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 11;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 5:
                            if (A_6)
                            {
                              num3 = (short) 18;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ\uF88F\uF791\uF593\uF295ﶗ\uE899쎛\uE89D얟킡킣쎥킧蒩욫\uDEAD\uD7AF", A_1_1));
                            num3 = (short) 7;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 6:
                          case 25:
                            xmlTextWriter1.WriteString(ReportViewer.convertToArabicDateTime(DateTime.Now.ToString((IFormatProvider) cultureInfo)));
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("좍憐\uF591\uE193\uE495ﶗ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uD88D\uF58F\uE091\uE093ﾕﮗﮙ\uF09B\uDF9D캟송첣즥\uDAA7", A_1_1), RptMgrErrorHandler.b("\uDE8D\uF18F\uF591\uF193풕\uF797\uEE99\uE89B\uF19D춟", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("쎍\uF18F\uE091\uF393ﾕ\uF697", A_1_1), RptMgrErrorHandler.b("뺍", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("첍ﲏ\uFD91\uF793ﶕ춗펙\uDF9B\uF19D캟횡얣쾥욧쾩\uDEAB", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("잍ﶏ\uF391\uF393\uF395", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍\uF58Fﮑ\uF393ﺕ\uEC97", A_1_1), RptMgrErrorHandler.b("뚍", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ튏\uFD91\uE093\uE295\uF797\uF799늛풝\uF09F\uE5A1", A_1_1));
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("슍憐ﲑ\uF193풕\uEA97ﾙﶛ\uF59D", A_1_1));
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            num3 = (short) 20;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 8:
                            try
                            {
                              num3 = (short) 31 /*0x1F*/;
                              num1 = (int) (IntPtr) num3;
                              while (true)
                              {
                                string str6;
                                XmlNode current7;
                                string innerText1;
                                string innerText2;
                                string innerText3;
                                string innerText4;
                                string innerText5;
                                string innerText6;
                                string innerText7;
                                string innerText8;
                                string innerText9;
                                string innerText10;
                                string innerText11;
                                switch (num1)
                                {
                                  case 0:
                                    try
                                    {
                                      num3 = (short) 14;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        XmlNode current8;
                                        string str7;
                                        string str8;
                                        switch (num1)
                                        {
                                          case 1:
                                          case 17:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            str8 = (string) null;
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            str8 = RptMgrErrorHandler.b("ꦍ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 5;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 17;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 5:
                                          case 9:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str7 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str8 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                            enumerator4 = this.f.GetEnumerator();
                                            num3 = (short) 11;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 6:
                                            if (xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str8 = RptMgrErrorHandler.b("겍", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 9;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 7:
                                            if (enumerator3.MoveNext())
                                            {
                                              current8 = (XmlNode) enumerator3.Current;
                                              str7 = (string) null;
                                              num3 = (short) 12;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 8:
                                            goto label_221;
                                          case 10:
                                          case 13:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str7 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 15;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 11:
                                            try
                                            {
                                              num3 = (short) 1;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current9;
                                                switch (num1)
                                                {
                                                  case 0:
                                                    if (num2 % 2 != 0)
                                                    {
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                                      num3 = (short) 4;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
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
                                                    goto label_87;
                                                  case 3:
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 4:
                                                  case 5:
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                                    xmlTextWriter1.WriteString(current9.InnerText);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 8;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 6:
                                                    if (enumerator4.MoveNext())
                                                    {
                                                      current9 = (XmlNode) enumerator4.Current;
                                                      xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                      num3 = (short) 0;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 7:
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
                                                num3 = (short) 6;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num7;
                                              switch (0)
                                              {
                                                case 0:
label_79:
                                                  disposable = enumerator4 as IDisposable;
                                                  num7 = (short) 0;
                                                  num1 = (int) (IntPtr) num7;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num7 = (short) 2;
                                                          num1 = (int) (IntPtr) num7;
                                                          continue;
                                                        }
                                                        goto label_83;
                                                      case 1:
                                                        goto label_83;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num7 = (short) 1;
                                                        num1 = (int) (IntPtr) num7;
                                                        continue;
                                                      default:
                                                        goto label_79;
                                                    }
                                                  }
label_83:;
                                              }
                                            }
label_87:
                                            xmlTextWriter1.WriteEndElement();
                                            --num2;
                                            num3 = (short) 0;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 12:
                                            if (current8.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str7 = RptMgrErrorHandler.b("겍", A_1_1) + current8.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 10;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 14:
                                            switch (0)
                                            {
                                              case 0:
                                                break;
                                              default:
                                                continue;
                                            }
                                            break;
                                          case 15:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 1;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 16 /*0x10*/:
                                            str7 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current8.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 13;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                        }
                                        num3 = (short) 7;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num8;
                                      switch (0)
                                      {
                                        case 0:
label_100:
                                          disposable = enumerator3 as IDisposable;
                                          num8 = (short) 0;
                                          num1 = (int) (IntPtr) num8;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num8 = (short) 2;
                                                  num1 = (int) (IntPtr) num8;
                                                  continue;
                                                }
                                                goto label_104;
                                              case 1:
                                                goto label_104;
                                              case 2:
                                                disposable.Dispose();
                                                num8 = (short) 1;
                                                num1 = (int) (IntPtr) num8;
                                                continue;
                                              default:
                                                goto label_100;
                                            }
                                          }
label_104:;
                                      }
                                    }
                                  case 1:
                                    try
                                    {
                                      num3 = (short) 3;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            if (enumerator3.MoveNext())
                                            {
                                              XmlNode current10 = (XmlNode) enumerator3.Current;
                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꎏ", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                              xmlTextWriter1.WriteString(current10.InnerText);
                                              xmlTextWriter1.WriteEndElement();
                                              xmlTextWriter1.WriteEndElement();
                                              num3 = (short) 2;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
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
                                            goto label_217;
                                        }
                                        num3 = (short) 0;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num9;
                                      switch (0)
                                      {
                                        case 0:
label_182:
                                          disposable = enumerator3 as IDisposable;
                                          num9 = (short) 1;
                                          num1 = (int) (IntPtr) num9;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                disposable.Dispose();
                                                num9 = (short) 2;
                                                num1 = (int) (IntPtr) num9;
                                                continue;
                                              case 1:
                                                if (disposable != null)
                                                {
                                                  num9 = (short) 0;
                                                  num1 = (int) (IntPtr) num9;
                                                  continue;
                                                }
                                                goto label_186;
                                              case 2:
                                                goto label_186;
                                              default:
                                                goto label_182;
                                            }
                                          }
label_186:;
                                      }
                                    }
label_217:
                                    xmlTextWriter1.WriteEndElement();
                                    num3 = (short) 18;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 2:
                                    if (enumerator2.MoveNext())
                                    {
                                      current7 = (XmlNode) enumerator2.Current;
                                      str6 = (string) null;
                                      num3 = (short) 16 /*0x10*/;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 40;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 3:
                                  case 32 /*0x20*/:
                                    this.d = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏욑\uF593\uF495\uF497ﾙ풛ﮝ솟욡솣풥螧\uE9A9쎫슭\uE4AF\uDBB1삳\uDAB5\uDDB7", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("쎍\uF18F\uE091\uF393ﾕ\uF697", A_1_1), RptMgrErrorHandler.b("뺍", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightSlateGray.ToString());
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뾍벏ꎑ뢓ꞕ뒗ꮙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꮗ\uD999ꮛꪝ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDE8D\uF18F\uF691\uF093ﾕ\uF697ﶙ", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B\uD99D튟춡톣횥", A_1_1));
                                    num3 = (short) 22;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 4:
                                    if (!isRightToLeft)
                                    {
                                      xmlTextWriter1.WriteString(current7.Attributes[i].Value);
                                      num3 = (short) 27;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 24;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 5:
                                  case 39:
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꚏ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                    num3 = (short) 4;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 6:
                                    if (isRightToLeft)
                                    {
                                      num3 = (short) 41;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    enumerator3 = this.d.GetEnumerator();
                                    num3 = (short) 12;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 7:
                                    goto label_31;
                                  case 8:
                                  case 18:
                                    this.e = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B", A_1_1));
                                    num3 = (short) 10;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 9:
                                    try
                                    {
                                      num3 = (short) 4;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        string str9;
                                        string str10;
                                        XmlNode current11;
                                        switch (num1)
                                        {
                                          case 0:
                                          case 11:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str10 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 12;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                          case 2:
                                            str9 = (string) null;
                                            num3 = (short) 7;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            num3 = (short) 9;
                                            num1 = (int) (IntPtr) num3;
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
                                          case 10:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str6 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str10 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str9 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                            enumerator4 = this.f.GetEnumerator();
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 6:
                                            try
                                            {
                                              num3 = (short) 4;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current12;
                                                switch (num1)
                                                {
                                                  case 0:
                                                    goto label_150;
                                                  case 1:
                                                    if (num2 % 2 != 0)
                                                    {
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                                      num3 = (short) 3;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                  case 3:
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                                    xmlTextWriter1.WriteString(current12.InnerText);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 6;
                                                    num1 = (int) (IntPtr) num3;
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
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 7:
                                                    if (!enumerator4.MoveNext())
                                                    {
                                                      num3 = (short) 8;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    current12 = (XmlNode) enumerator4.Current;
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    num3 = (short) 0;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
                                                num3 = (short) 7;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num10;
                                              switch (0)
                                              {
                                                case 0:
label_133:
                                                  disposable = enumerator4 as IDisposable;
                                                  num10 = (short) 1;
                                                  num1 = (int) (IntPtr) num10;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        goto label_137;
                                                      case 1:
                                                        if (disposable != null)
                                                        {
                                                          num10 = (short) 2;
                                                          num1 = (int) (IntPtr) num10;
                                                          continue;
                                                        }
                                                        goto label_137;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num10 = (short) 0;
                                                        num1 = (int) (IntPtr) num10;
                                                        continue;
                                                      default:
                                                        goto label_133;
                                                    }
                                                  }
label_137:;
                                              }
                                            }
label_150:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꂑ뢓ꚕ뒗ꪙ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            --num2;
                                            num1 = 17;
                                            continue;
                                          case 7:
                                            if (xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str9 = RptMgrErrorHandler.b("겍", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 10;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 14;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 8:
                                            if (current11.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str10 = RptMgrErrorHandler.b("겍", A_1_1) + current11.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 0;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 9:
                                            goto label_221;
                                          case 12:
                                            if (num2 % 2 == 0)
                                            {
                                              num3 = (short) 13;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 13:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 14:
                                            str9 = RptMgrErrorHandler.b("ꦍ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 5;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 15:
                                            if (!enumerator3.MoveNext())
                                            {
                                              num3 = (short) 3;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            current11 = (XmlNode) enumerator3.Current;
                                            str10 = (string) null;
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 16 /*0x10*/:
                                            str10 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current11.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 11;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                        }
                                        num3 = (short) 15;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      switch (0)
                                      {
                                        case 0:
label_161:
                                          disposable = enumerator3 as IDisposable;
                                          num1 = 1;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                goto label_165;
                                              case 1:
                                                if (disposable != null)
                                                {
                                                  num1 = 2;
                                                  continue;
                                                }
                                                goto label_165;
                                              case 2:
                                                disposable.Dispose();
                                                num1 = 0;
                                                continue;
                                              default:
                                                goto label_161;
                                            }
                                          }
label_165:;
                                      }
                                    }
                                  case 10:
                                    if (this.e.Count > 0)
                                    {
                                      num3 = (short) 38;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto label_221;
                                  case 11:
                                    if (this.d.Count <= 4)
                                    {
                                      num3 = (short) 15;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 37;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 12:
                                    try
                                    {
                                      num3 = (short) 3;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            if (!enumerator3.MoveNext())
                                            {
                                              num3 = (short) 0;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            XmlNode current13 = (XmlNode) enumerator3.Current;
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꎏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current13.InnerText);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
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
                                            goto label_114;
                                        }
                                        num3 = (short) 2;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num11;
                                      switch (0)
                                      {
                                        case 0:
label_206:
                                          disposable = enumerator3 as IDisposable;
                                          num11 = (short) 1;
                                          num1 = (int) (IntPtr) num11;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                disposable.Dispose();
                                                num11 = (short) 2;
                                                num1 = (int) (IntPtr) num11;
                                                continue;
                                              case 1:
                                                if (disposable != null)
                                                {
                                                  num11 = (short) 0;
                                                  num1 = (int) (IntPtr) num11;
                                                  continue;
                                                }
                                                goto label_210;
                                              case 2:
                                                goto label_210;
                                              default:
                                                goto label_206;
                                            }
                                          }
label_210:;
                                      }
                                    }
label_114:
                                    xmlTextWriter1.WriteEndElement();
                                    num1 = 8;
                                    continue;
                                  case 13:
                                  case 27:
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    num3 = (short) 43;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 14:
                                  case 19:
                                    enumerator3 = this.d.GetEnumerator();
                                    num3 = (short) 1;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 15:
                                    if (this.d.Count == 4)
                                    {
                                      num3 = (short) 17;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto case 14;
                                  case 16 /*0x10*/:
                                    if (!current7.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                    {
                                      num3 = (short) 29;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    str6 = RptMgrErrorHandler.b("겍", A_1_1) + current7.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                    num3 = (short) 32 /*0x20*/;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 17:
                                    innerText8 = this.d[0].InnerText;
                                    innerText9 = this.d[1].InnerText;
                                    innerText10 = this.d[2].InnerText;
                                    innerText11 = this.d[3].InnerText;
                                    num3 = (short) 33;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 20:
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.Coral.ToString());
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꊑ뢓ꚕ뒗ꮙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꢗꪙ겛꺝", A_1_1));
                                    num3 = (short) 25;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 21:
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뾍ꂏ", A_1_1));
                                    num3 = (short) 5;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 22:
                                    if (flag2)
                                    {
                                      num3 = (short) 20;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    break;
                                  case 24:
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                                    xmlTextWriter1.WriteString(current7.Attributes[i].Value);
                                    num3 = (short) 13;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 25:
                                    if (this.d.Count >= 5)
                                    {
                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("벍ꖏ", A_1_1));
                                      num3 = (short) 39;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 21;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 26:
                                    if (this.d.Count > 0)
                                    {
                                      num3 = (short) 35;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto label_221;
                                  case 28:
                                    if (this.l)
                                    {
                                      num3 = (short) 36;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto case 14;
                                  case 29:
                                    str6 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current7.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                    num3 = (short) 3;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 30:
                                    this.d[0].InnerText = innerText9;
                                    this.d[1].InnerText = innerText10;
                                    this.d[2].InnerText = innerText11;
                                    this.d[3].InnerText = innerText8;
                                    num3 = (short) 14;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 31 /*0x1F*/:
                                    switch (0)
                                    {
                                      case 0:
                                        goto label_211;
                                      default:
                                        continue;
                                    }
                                  case 33:
                                    if (this.l)
                                    {
                                      num3 = (short) 30;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto case 14;
                                  case 34:
                                    if (!isRightToLeft)
                                    {
                                      enumerator3 = this.e.GetEnumerator();
                                      num3 = (short) 0;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 42;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 35:
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                    num3 = (short) 6;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 36:
                                    this.d[0].InnerText = innerText2;
                                    this.d[1].InnerText = innerText3;
                                    this.d[2].InnerText = innerText4;
                                    this.d[3].InnerText = innerText5;
                                    this.d[4].InnerText = innerText6;
                                    this.d[5].InnerText = innerText7;
                                    this.d[6].InnerText = innerText1;
                                    num3 = (short) 19;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 37:
                                    innerText1 = this.d[0].InnerText;
                                    innerText2 = this.d[1].InnerText;
                                    innerText3 = this.d[2].InnerText;
                                    innerText4 = this.d[3].InnerText;
                                    innerText5 = this.d[4].InnerText;
                                    innerText6 = this.d[5].InnerText;
                                    innerText7 = this.d[6].InnerText;
                                    num3 = (short) 28;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 38:
                                    num2 = this.e.Count;
                                    num3 = (short) 34;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 40:
                                    num3 = (short) 7;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 41:
                                    num3 = (short) 11;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 42:
                                    enumerator3 = this.e.GetEnumerator();
                                    num3 = (short) 9;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 43:
                                    num3 = (short) -9811;
                                    int num12 = (int) num3;
                                    num3 = (short) -9811;
                                    int num13 = (int) num3;
                                    switch (num12 == num13 ? 1 : 0)
                                    {
                                      case 0:
                                      case 2:
                                        break;
                                      default:
                                        num3 = (short) 0;
                                        if (num3 == (short) 0)
                                          break;
                                        break;
                                    }
                                    break;
                                  default:
label_211:
                                    num3 = (short) 2;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                }
                                num3 = (short) 26;
                                num1 = (int) (IntPtr) num3;
                                continue;
label_221:
                                xmlTextWriter1.WriteEndElement();
                                xmlTextWriter1.WriteEndElement();
                                flag2 = false;
                                num3 = (short) 23;
                                num1 = (int) (IntPtr) num3;
                              }
                            }
                            finally
                            {
                              switch (0)
                              {
                                case 0:
label_229:
                                  disposable = enumerator2 as IDisposable;
                                  num1 = 1;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num1)
                                    {
                                      case 0:
                                        disposable.Dispose();
                                        num1 = 2;
                                        continue;
                                      case 1:
                                        if (disposable != null)
                                        {
                                          num1 = 0;
                                          continue;
                                        }
                                        goto label_233;
                                      case 2:
                                        goto label_233;
                                      default:
                                        goto label_229;
                                    }
                                  }
label_233:;
                              }
                            }
label_31:
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("좍憐\uF591\uE193\uE495ﶗ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uD88D\uF58F\uE091\uE093ﾕﮗﮙ\uF09B\uDF9D캟송첣즥\uDAA7", A_1_1), RptMgrErrorHandler.b("\uDE8D\uF18F\uF591\uF193풕\uF797\uEE99\uE89B\uF19D춟", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍ﾏ\uE091ﶓ\uEC95\uF797\uF499\uE89Bﾝ첟\uE3A1쪣얥삧얩\uDEAB", A_1_1), RptMgrErrorHandler.b("춍ﾏﲑ\uE093\uF395\uF697\uEE99캛\uF79D잟쪡킣", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("쎍\uF18F\uE091\uF393ﾕ\uF697", A_1_1), RptMgrErrorHandler.b("뺍", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("첍ﲏ\uFD91\uF793ﶕ춗펙\uDF9B\uF19D캟횡얣쾥욧쾩\uDEAB", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093풕\uF497\uF599ﾛ\uF59D", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍\uF58Fﮑ\uF393ﺕ\uEC97", A_1_1), RptMgrErrorHandler.b("뾍ꖏ", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                            num1 = 4;
                            continue;
                          case 9:
                            num3 = (short) 10;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 10:
                            if (!A_6)
                            {
                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ\uF88F\uF791\uF593\uF295ﶗ\uE899쎛\uF89D첟쮡풣횥춧캩\uF3AB\uD8AD햯삱삳펵삷钹횻캽\uA7BF", A_1_1));
                              num3 = (short) 1;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 15;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 11:
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍ﾏ\uE091ﶓ\uEC95\uF797\uF499\uE89Bﾝ첟\uE3A1좣쾥쾧쒩솫쮭\uDEAF욱", A_1_1), RptMgrErrorHandler.b("슍\uF58F\uF491\uE093", A_1_1));
                            num3 = (short) 6;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 12:
                          case 14:
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("첍ﲏ\uFD91\uF793ﶕ춗펙\uDF9B\uF19D캟횡얣쾥욧쾩\uDEAB", A_1_1));
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("잍ﶏ\uF391\uF393\uF395", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uD88D\uF58F\uE091\uE093ﾕﮗﮙ\uF09B\uDF9D첟쮡쎣좥얧쾩슫\uDAAD", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍\uF58Fﮑ\uF393ﺕ\uEC97", A_1_1), A_4.ToString());
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uD98D憐\uF691\uE093ﺕ", A_1_1), A_3.ToString());
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ", A_1_1) + A_2);
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            xmlTextWriter1.WriteEndElement();
                            this.c = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱鎳\uF1B5\uDDB7풹\uD9BB첽ꆿ껁賃꿅곇껉꧋ꃍ\uF7CF近", A_1_1));
                            enumerator2 = this.c.GetEnumerator();
                            num3 = (short) 3;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 13:
                            if (!isRightToLeft)
                            {
                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍ﾏ\uE091ﶓ\uEC95\uF797\uF499\uE89Bﾝ첟\uE3A1좣쾥쾧쒩솫쮭\uDEAF욱", A_1_1), RptMgrErrorHandler.b("슍\uF58F\uF491\uE093", A_1_1));
                              num3 = (short) 12;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 19;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 15:
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ\uF88F\uF791\uF593\uF295ﶗ\uE899쎛\uF89D첟쮡풣횥춧캩芫쒭삯햱", A_1_1));
                            num3 = (short) 17;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 16 /*0x10*/:
                            try
                            {
                              num3 = (short) 14;
                              num1 = (int) (IntPtr) num3;
                              while (true)
                              {
                                XmlNode current14;
                                string str11;
                                string innerText12;
                                string innerText13;
                                string innerText14;
                                string innerText15;
                                switch (num1)
                                {
                                  case 0:
                                  case 27:
                                    this.d = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏욑\uF593\uF495\uF497ﾙ풛ﮝ솟욡솣풥螧\uE9A9쎫슭\uE4AF\uDBB1삳\uDAB5\uDDB7", A_1_1));
                                    num3 = (short) 11;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 1:
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                                    xmlTextWriter1.WriteString(current14.Attributes[i].Value);
                                    num3 = (short) 9;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 2:
                                    num2 = this.e.Count;
                                    enumerator3 = this.e.GetEnumerator();
                                    num3 = (short) 8;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 3:
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("벍ꖏ", A_1_1));
                                    num3 = (short) 5;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 4:
                                    enumerator3 = this.d.GetEnumerator();
                                    num3 = (short) 26;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 5:
                                  case 19:
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꚏ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                    num3 = (short) 25;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 6:
                                    innerText12 = this.d[0].InnerText;
                                    innerText13 = this.d[1].InnerText;
                                    innerText14 = this.d[2].InnerText;
                                    innerText15 = this.d[3].InnerText;
                                    num3 = (short) 28;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 7:
                                    this.d[0].InnerText = innerText15;
                                    this.d[1].InnerText = innerText14;
                                    this.d[2].InnerText = innerText13;
                                    this.d[3].InnerText = innerText12;
                                    num3 = (short) 4;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 8:
                                    try
                                    {
                                      num3 = (short) 52;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        XmlNode current15;
                                        string str12;
                                        string str13;
                                        string str14;
                                        string str15;
                                        IEnumerator enumerator5;
                                        switch (num1)
                                        {
                                          case 0:
                                          case 25:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뾍ꞏ", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i + 1].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            str14 = (string) null;
                                            num3 = (short) 22;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            if (current15.Attributes[i].Value.Contains(AppResources.NOPRINT_Id))
                                            {
                                              num3 = (short) 20;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                          case 13:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("붍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            XmlTextWriter xmlTextWriter2 = xmlTextWriter1;
                                            string localName1 = RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                            System.Windows.Media.Color darkBlue1 = Colors.DarkBlue;
                                            string str16 = darkBlue1.ToString();
                                            xmlTextWriter2.WriteAttributeString(localName1, str16);
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i + 1].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뢍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            XmlTextWriter xmlTextWriter3 = xmlTextWriter1;
                                            string localName2 = RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                            darkBlue1 = Colors.DarkBlue;
                                            string str17 = darkBlue1.ToString();
                                            xmlTextWriter3.WriteAttributeString(localName2, str17);
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            str13 = (string) null;
                                            num3 = (short) 9;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            if (num2 % 2 == 0)
                                            {
                                              num3 = (short) 49;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                            num3 = (short) 0;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 5:
                                          case 29:
                                            this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str13 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            enumerator4 = this.g.GetEnumerator();
                                            num3 = (short) 33;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 6:
                                          case 48 /*0x30*/:
                                            this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str14 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            enumerator4 = this.g.GetEnumerator();
                                            num3 = (short) 30;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 7:
                                            try
                                            {
                                              num3 = (short) 4;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                string str18;
                                                XmlNode current16;
                                                switch (num1)
                                                {
                                                  case 0:
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 1:
                                                  case 7:
                                                    this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str15 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str18 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                                    enumerator5 = this.f.GetEnumerator();
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                    str18 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current16.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 3:
                                                    try
                                                    {
                                                      num3 = (short) 1;
                                                      num1 = (int) (IntPtr) num3;
                                                      while (true)
                                                      {
                                                        switch (num1)
                                                        {
                                                          case 0:
                                                            goto label_433;
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
                                                            if (enumerator5.MoveNext())
                                                            {
                                                              XmlNode current17 = (XmlNode) enumerator5.Current;
                                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("붍", A_1_1));
                                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                              xmlTextWriter1.WriteString(current17.InnerText);
                                                              xmlTextWriter1.WriteEndElement();
                                                              xmlTextWriter1.WriteEndElement();
                                                              num3 = (short) 4;
                                                              num1 = (int) (IntPtr) num3;
                                                              continue;
                                                            }
                                                            num3 = (short) 3;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                          case 3:
                                                            num3 = (short) 0;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                        }
                                                        num3 = (short) 2;
                                                        num1 = (int) (IntPtr) num3;
                                                      }
                                                    }
                                                    finally
                                                    {
                                                      short num14;
                                                      switch (0)
                                                      {
                                                        case 0:
label_448:
                                                          disposable = enumerator5 as IDisposable;
                                                          num14 = (short) 0;
                                                          num1 = (int) (IntPtr) num14;
                                                          goto default;
                                                        default:
                                                          while (true)
                                                          {
                                                            switch (num1)
                                                            {
                                                              case 0:
                                                                if (disposable != null)
                                                                {
                                                                  num14 = (short) 2;
                                                                  num1 = (int) (IntPtr) num14;
                                                                  continue;
                                                                }
                                                                goto label_452;
                                                              case 1:
                                                                goto label_452;
                                                              case 2:
                                                                disposable.Dispose();
                                                                num14 = (short) 1;
                                                                num1 = (int) (IntPtr) num14;
                                                                continue;
                                                              default:
                                                                goto label_448;
                                                            }
                                                          }
label_452:;
                                                      }
                                                    }
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
                                                    goto label_312;
                                                  case 6:
                                                    if (enumerator4.MoveNext())
                                                    {
                                                      current16 = (XmlNode) enumerator4.Current;
                                                      xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str15 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                                      xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                                      xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                      xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                                      xmlTextWriter1.WriteEndElement();
                                                      xmlTextWriter1.WriteEndElement();
                                                      str18 = (string) null;
                                                      num3 = (short) 8;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 0;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    if (!current16.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                                    {
                                                      num3 = (short) 2;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    str18 = RptMgrErrorHandler.b("겍", A_1_1) + current16.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
label_433:
                                                num1 = 6;
                                              }
                                            }
                                            finally
                                            {
                                              short num15;
                                              switch (0)
                                              {
                                                case 0:
label_456:
                                                  disposable = enumerator4 as IDisposable;
                                                  num15 = (short) 0;
                                                  num1 = (int) (IntPtr) num15;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num15 = (short) 2;
                                                          num1 = (int) (IntPtr) num15;
                                                          continue;
                                                        }
                                                        goto label_460;
                                                      case 1:
                                                        goto label_460;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num15 = (short) 1;
                                                        num1 = (int) (IntPtr) num15;
                                                        continue;
                                                      default:
                                                        goto label_456;
                                                    }
                                                  }
label_460:;
                                              }
                                            }
label_312:
                                            xmlTextWriter1.WriteEndElement();
                                            num1 = 10;
                                            continue;
                                          case 8:
                                          case 15:
                                            this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str15 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            enumerator4 = this.g.GetEnumerator();
                                            num3 = (short) 7;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 9:
                                            if (current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              str13 = RptMgrErrorHandler.b("겍", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                              num3 = (short) 5;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 36;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 10:
label_400:
                                            --num2;
                                            num3 = (short) 26;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 11:
                                          case 44:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("붍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            XmlTextWriter xmlTextWriter4 = xmlTextWriter1;
                                            string localName3 = RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                            System.Windows.Media.Color darkBlue2 = Colors.DarkBlue;
                                            string str19 = darkBlue2.ToString();
                                            xmlTextWriter4.WriteAttributeString(localName3, str19);
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i + 1].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            XmlTextWriter xmlTextWriter5 = xmlTextWriter1;
                                            string localName4 = RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                            darkBlue2 = Colors.DarkBlue;
                                            string str20 = darkBlue2.ToString();
                                            xmlTextWriter5.WriteAttributeString(localName4, str20);
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            str15 = (string) null;
                                            num3 = (short) 42;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 12:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 44;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 14:
                                            if (!isRightToLeft)
                                            {
                                              num3 = (short) 37;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 40;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 16 /*0x10*/:
                                          case 43:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            str12 = (string) null;
                                            num3 = (short) 41;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 17:
                                          case 51:
                                            this.g = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str12 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                            enumerator4 = this.g.GetEnumerator();
                                            num3 = (short) 47;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 18:
                                            if (enumerator3.MoveNext())
                                            {
                                              current15 = (XmlNode) enumerator3.Current;
                                              num3 = (short) 14;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 50;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 19:
                                            if (current15.Attributes[i].Value.Contains(AppResources.NOPRINT_Id))
                                            {
                                              num3 = (short) 24;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 35;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 20:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 45;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 21:
                                            goto label_524;
                                          case 22:
                                            if (!current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              num3 = (short) 38;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str14 = RptMgrErrorHandler.b("겍", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 23:
                                            str12 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 17;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 24:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                            num3 = (short) 28;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 27:
                                            str15 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 28:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 11;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 12;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 30:
                                            try
                                            {
                                              num3 = (short) 11;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current18;
                                                string str21;
                                                switch (num1)
                                                {
                                                  case 1:
                                                  case 5:
                                                    str21 = (string) null;
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                    if (current18.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                                    {
                                                      str21 = RptMgrErrorHandler.b("겍", A_1_1) + current18.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                                      num3 = (short) 6;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 4;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 3:
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 4:
                                                    str21 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current18.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 6:
                                                  case 7:
                                                    this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str14 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str21 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                                    enumerator5 = this.f.GetEnumerator();
                                                    num3 = (short) 8;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    try
                                                    {
                                                      num3 = (short) 2;
                                                      num1 = (int) (IntPtr) num3;
                                                      while (true)
                                                      {
                                                        switch (num1)
                                                        {
                                                          case 0:
                                                            num3 = (short) 4;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                          case 1:
                                                            if (enumerator5.MoveNext())
                                                            {
                                                              XmlNode current19 = (XmlNode) enumerator5.Current;
                                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                              xmlTextWriter1.WriteString(current19.InnerText);
                                                              xmlTextWriter1.WriteEndElement();
                                                              xmlTextWriter1.WriteEndElement();
                                                              num3 = (short) 3;
                                                              num1 = (int) (IntPtr) num3;
                                                              continue;
                                                            }
                                                            num3 = (short) 0;
                                                            num1 = (int) (IntPtr) num3;
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
                                                            goto label_497;
                                                        }
                                                        num3 = (short) 1;
                                                        num1 = (int) (IntPtr) num3;
                                                      }
                                                    }
                                                    finally
                                                    {
                                                      short num16;
                                                      switch (0)
                                                      {
                                                        case 0:
label_484:
                                                          disposable = enumerator5 as IDisposable;
                                                          num16 = (short) 0;
                                                          num1 = (int) (IntPtr) num16;
                                                          goto default;
                                                        default:
                                                          while (true)
                                                          {
                                                            switch (num1)
                                                            {
                                                              case 0:
                                                                if (disposable != null)
                                                                {
                                                                  num16 = (short) 1;
                                                                  num1 = (int) (IntPtr) num16;
                                                                  continue;
                                                                }
                                                                goto label_488;
                                                              case 1:
                                                                disposable.Dispose();
                                                                num16 = (short) 2;
                                                                num1 = (int) (IntPtr) num16;
                                                                continue;
                                                              case 2:
                                                                goto label_488;
                                                              default:
                                                                goto label_484;
                                                            }
                                                          }
label_488:;
                                                      }
                                                    }
label_497:
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteString(current18.Attributes[0].Value);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뢍", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteString("");
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num1 = 0;
                                                    continue;
                                                  case 9:
                                                    if (num2 % 2 != 0)
                                                    {
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                                      num3 = (short) 1;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 10:
                                                    if (!enumerator4.MoveNext())
                                                    {
                                                      num3 = (short) 12;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    current18 = (XmlNode) enumerator4.Current;
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                                    num3 = (short) 9;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 11:
                                                    switch (0)
                                                    {
                                                      case 0:
                                                        break;
                                                      default:
                                                        continue;
                                                    }
                                                    break;
                                                  case 12:
                                                    num3 = (short) 13;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 13:
                                                    goto label_407;
                                                }
                                                num3 = (short) 10;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num17;
                                              switch (0)
                                              {
                                                case 0:
label_502:
                                                  disposable = enumerator4 as IDisposable;
                                                  num17 = (short) 0;
                                                  num1 = (int) (IntPtr) num17;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num17 = (short) 1;
                                                          num1 = (int) (IntPtr) num17;
                                                          continue;
                                                        }
                                                        goto label_506;
                                                      case 1:
                                                        disposable.Dispose();
                                                        num17 = (short) 2;
                                                        num1 = (int) (IntPtr) num17;
                                                        continue;
                                                      case 2:
                                                        goto label_506;
                                                      default:
                                                        goto label_502;
                                                    }
                                                  }
label_506:;
                                              }
                                            }
                                          case 31 /*0x1F*/:
                                            num3 = (short) 19;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 32 /*0x20*/:
                                            if (!current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("삍\uDF8F슑욓\uDF95횗캙", A_1_1)))
                                            {
                                              num3 = (short) 34;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            goto case 20;
                                          case 33:
                                            try
                                            {
                                              num3 = (short) 13;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current20;
                                                string str22;
                                                switch (num1)
                                                {
                                                  case 0:
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 1:
                                                    try
                                                    {
                                                      num3 = (short) 2;
                                                      num1 = (int) (IntPtr) num3;
                                                      while (true)
                                                      {
                                                        switch (num1)
                                                        {
                                                          case 1:
                                                            goto label_380;
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
                                                            if (!enumerator5.MoveNext())
                                                            {
                                                              num3 = (short) 4;
                                                              num1 = (int) (IntPtr) num3;
                                                              continue;
                                                            }
                                                            XmlNode current21 = (XmlNode) enumerator5.Current;
                                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("붍", A_1_1));
                                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                            xmlTextWriter1.WriteString(current21.InnerText);
                                                            xmlTextWriter1.WriteEndElement();
                                                            xmlTextWriter1.WriteEndElement();
                                                            num3 = (short) 0;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                          case 4:
                                                            num3 = (short) 1;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                        }
                                                        num3 = (short) 3;
                                                        num1 = (int) (IntPtr) num3;
                                                      }
                                                    }
                                                    finally
                                                    {
                                                      switch (0)
                                                      {
                                                        case 0:
label_372:
                                                          disposable = enumerator5 as IDisposable;
                                                          num1 = 1;
                                                          goto default;
                                                        default:
                                                          while (true)
                                                          {
                                                            switch (num1)
                                                            {
                                                              case 0:
                                                                goto label_376;
                                                              case 1:
                                                                if (disposable != null)
                                                                {
                                                                  num1 = 2;
                                                                  continue;
                                                                }
                                                                goto label_376;
                                                              case 2:
                                                                disposable.Dispose();
                                                                num1 = 0;
                                                                continue;
                                                              default:
                                                                goto label_372;
                                                            }
                                                          }
label_376:;
                                                      }
                                                    }
label_380:
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                  case 6:
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteString("");
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteString(current20.Attributes[0].Value);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    str22 = (string) null;
                                                    num3 = (short) 4;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 3:
                                                  case 10:
                                                    this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str13 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str22 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                                    enumerator5 = this.f.GetEnumerator();
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 4:
                                                    if (!current20.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                                    {
                                                      num3 = (short) 8;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    str22 = RptMgrErrorHandler.b("겍", A_1_1) + current20.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                                    num3 = (short) 10;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 7:
                                                    if (num2 % 2 != 0)
                                                    {
                                                      xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                                      num3 = (short) 6;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 0;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    str22 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current20.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 9:
                                                    num3 = (short) 11;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 11:
                                                    goto label_400;
                                                  case 12:
                                                    if (enumerator4.MoveNext())
                                                    {
                                                      current20 = (XmlNode) enumerator4.Current;
                                                      xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                                      num3 = (short) 7;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 9;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 13:
                                                    switch (0)
                                                    {
                                                      case 0:
                                                        break;
                                                      default:
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                num3 = (short) 12;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              switch (0)
                                              {
                                                case 0:
label_395:
                                                  disposable = enumerator4 as IDisposable;
                                                  num1 = 2;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        goto label_399;
                                                      case 1:
                                                        disposable.Dispose();
                                                        num1 = 0;
                                                        continue;
                                                      case 2:
                                                        if (disposable != null)
                                                        {
                                                          num1 = 1;
                                                          continue;
                                                        }
                                                        goto label_399;
                                                      default:
                                                        goto label_395;
                                                    }
                                                  }
label_399:;
                                              }
                                            }
                                          case 34:
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 35:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 13;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 36:
                                            str13 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 29;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 37:
                                            if (!current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("삍\uDF8F슑욓\uDF95횗캙", A_1_1)))
                                            {
                                              num3 = (short) 31 /*0x1F*/;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            goto case 24;
                                          case 38:
                                            str14 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                            num3 = (short) 48 /*0x30*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 39:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 40:
                                            num3 = (short) 32 /*0x20*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 41:
                                            if (!current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              num3 = (short) 23;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str12 = RptMgrErrorHandler.b("겍", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                            num3 = (short) 51;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 42:
                                            if (!current15.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                            {
                                              num3 = (short) 27;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str15 = RptMgrErrorHandler.b("겍", A_1_1) + current15.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                            num3 = (short) 15;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 45:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 43;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 39;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 46:
label_407:
                                            --num2;
                                            num1 = 53;
                                            continue;
                                          case 47:
                                            try
                                            {
                                              num3 = (short) 8;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current22;
                                                string str23;
                                                switch (num1)
                                                {
                                                  case 0:
                                                  case 9:
                                                    this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str12 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ잛\uDE9D\uE69F쮡솣쪥첧\uEEA9즫\uDDAD趯", A_1_1) + str23 + RptMgrErrorHandler.b("펍뾏쒑\uF593歹\uED97ﾙ\uEF9B놝\uF69F쎡좣펥춧", A_1_1));
                                                    enumerator5 = this.f.GetEnumerator();
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 1:
                                                    if (!current22.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                                    {
                                                      num3 = (short) 2;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    str23 = RptMgrErrorHandler.b("겍", A_1_1) + current22.Attributes[0].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                                    num3 = (short) 9;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                    str23 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current22.Attributes[0].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                                    num3 = (short) 0;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 4:
                                                    if (!enumerator4.MoveNext())
                                                    {
                                                      num3 = (short) 6;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    current22 = (XmlNode) enumerator4.Current;
                                                    str23 = (string) null;
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 5:
                                                    try
                                                    {
                                                      num3 = (short) 3;
                                                      num1 = (int) (IntPtr) num3;
                                                      while (true)
                                                      {
                                                        switch (num1)
                                                        {
                                                          case 0:
                                                            if (!enumerator5.MoveNext())
                                                            {
                                                              num3 = (short) 2;
                                                              num1 = (int) (IntPtr) num3;
                                                              continue;
                                                            }
                                                            XmlNode current23 = (XmlNode) enumerator5.Current;
                                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                            xmlTextWriter1.WriteString(current23.InnerText);
                                                            xmlTextWriter1.WriteEndElement();
                                                            xmlTextWriter1.WriteEndElement();
                                                            num3 = (short) 4;
                                                            num1 = (int) (IntPtr) num3;
                                                            continue;
                                                          case 1:
                                                            goto label_349;
                                                          case 2:
                                                            num3 = (short) 1;
                                                            num1 = (int) (IntPtr) num3;
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
                                                        }
                                                        num3 = (short) 0;
                                                        num1 = (int) (IntPtr) num3;
                                                      }
                                                    }
                                                    finally
                                                    {
                                                      short num18;
                                                      switch (0)
                                                      {
                                                        case 0:
label_344:
                                                          disposable = enumerator5 as IDisposable;
                                                          num18 = (short) 2;
                                                          num1 = (int) (IntPtr) num18;
                                                          goto default;
                                                        default:
                                                          while (true)
                                                          {
                                                            switch (num1)
                                                            {
                                                              case 0:
                                                                goto label_348;
                                                              case 1:
                                                                disposable.Dispose();
                                                                num18 = (short) 0;
                                                                num1 = (int) (IntPtr) num18;
                                                                continue;
                                                              case 2:
                                                                if (disposable != null)
                                                                {
                                                                  num18 = (short) 1;
                                                                  num1 = (int) (IntPtr) num18;
                                                                  continue;
                                                                }
                                                                goto label_348;
                                                              default:
                                                                goto label_344;
                                                            }
                                                          }
label_348:;
                                                      }
                                                    }
label_349:
                                                    xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B얝\uE09F\uF0A1솣얥ﲧ쎩\uD8AB슭햯辱", A_1_1) + str12 + RptMgrErrorHandler.b("펍뾏풑ﶓ\uF395\uF497ﺙ", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뢍", A_1_1));
                                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                                    xmlTextWriter1.WriteString(xmlNode.Attributes[0].Value);
                                                    xmlTextWriter1.WriteEndElement();
                                                    xmlTextWriter1.WriteEndElement();
                                                    num3 = (short) 3;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 6:
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 7:
                                                    goto label_297;
                                                  case 8:
                                                    switch (0)
                                                    {
                                                      case 0:
                                                        break;
                                                      default:
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                num3 = (short) 4;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num19;
                                              switch (0)
                                              {
                                                case 0:
label_354:
                                                  disposable = enumerator4 as IDisposable;
                                                  num19 = (short) 2;
                                                  num1 = (int) (IntPtr) num19;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        goto label_358;
                                                      case 1:
                                                        disposable.Dispose();
                                                        num19 = (short) 0;
                                                        num1 = (int) (IntPtr) num19;
                                                        continue;
                                                      case 2:
                                                        if (disposable != null)
                                                        {
                                                          num19 = (short) 1;
                                                          num1 = (int) (IntPtr) num19;
                                                          continue;
                                                        }
                                                        goto label_358;
                                                      default:
                                                        goto label_354;
                                                    }
                                                  }
label_358:;
                                              }
                                            }
label_297:
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꊏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("춍\uF58Fﲑ\uE093\uF395\uEA97", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current15.Attributes[i + 1].Value);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            num1 = 46;
                                            continue;
                                          case 49:
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.LightYellow.ToString());
                                            num3 = (short) 25;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 50:
                                            num3 = (short) 21;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 52:
                                            switch (0)
                                            {
                                              case 0:
                                                break;
                                              default:
                                                continue;
                                            }
                                            break;
                                        }
                                        num3 = (short) 18;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num20;
                                      switch (0)
                                      {
                                        case 0:
label_519:
                                          disposable = enumerator3 as IDisposable;
                                          num20 = (short) 0;
                                          num1 = (int) (IntPtr) num20;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num20 = (short) 1;
                                                  num1 = (int) (IntPtr) num20;
                                                  continue;
                                                }
                                                goto label_523;
                                              case 1:
                                                disposable.Dispose();
                                                num20 = (short) 2;
                                                num1 = (int) (IntPtr) num20;
                                                continue;
                                              case 2:
                                                goto label_523;
                                              default:
                                                goto label_519;
                                            }
                                          }
label_523:;
                                      }
                                    }
                                  case 9:
                                  case 24:
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    xmlTextWriter1.WriteEndElement();
                                    str11 = (string) null;
                                    num3 = (short) 21;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 10:
                                    if (isRightToLeft)
                                    {
                                      num3 = (short) 6;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    enumerator3 = this.d.GetEnumerator();
                                    num3 = (short) 20;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 11:
                                    if (this.d.Count > 0)
                                    {
                                      num3 = (short) 13;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    break;
                                  case 12:
                                    str11 = RptMgrErrorHandler.b("ꦍ", A_1_1) + current14.Attributes[i].Value + RptMgrErrorHandler.b("ꦍ", A_1_1);
                                    num3 = (short) 27;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 13:
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                    num3 = (short) 10;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 14:
                                    switch (0)
                                    {
                                      case 0:
                                        goto label_262;
                                      default:
                                        continue;
                                    }
                                  case 15:
                                    if (this.e.Count > 0)
                                    {
                                      num3 = (short) 2;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    break;
                                  case 16 /*0x10*/:
                                    if (isRightToLeft)
                                    {
                                      num3 = (short) 3;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뾍ꂏ", A_1_1));
                                    num3 = (short) 19;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 17:
                                    if (!enumerator2.MoveNext())
                                    {
                                      num3 = (short) 23;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    current14 = (XmlNode) enumerator2.Current;
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395", A_1_1));
                                    XmlTextWriter xmlTextWriter6 = xmlTextWriter1;
                                    string localName5 = RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                    System.Windows.Media.Color color = Colors.LightSlateGray;
                                    string str24 = color.ToString();
                                    xmlTextWriter6.WriteAttributeString(localName5, str24);
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뾍벏ꎑ뢓ꞕ뒗ꮙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꮗ\uD999ꮛꪝ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDE8D\uF18F\uF691\uF093ﾕ\uF697ﶙ", A_1_1), RptMgrErrorHandler.b("뮍", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B\uD99D튟춡톣횥", A_1_1));
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395쪗\uF599\uEB9B", A_1_1));
                                    XmlTextWriter xmlTextWriter7 = xmlTextWriter1;
                                    string localName6 = RptMgrErrorHandler.b("첍\uF18F\uF191ﾓ\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1);
                                    color = Colors.Coral;
                                    string str25 = color.ToString();
                                    xmlTextWriter7.WriteAttributeString(localName6, str25);
                                    xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97캙\uF49B\uF79D쎟즡쪣쎥\uDBA7\uD9A9", A_1_1), RptMgrErrorHandler.b("뺍벏ꊑ뢓ꚕ뒗ꮙ", A_1_1));
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍ﾏ\uE091\uF093\uF395\uEA97\uD899\uEE9B\uEB9D펟쪡", A_1_1), RptMgrErrorHandler.b("궍횏풑꒓ꚕꢗꪙ겛꺝", A_1_1));
                                    num3 = (short) 16 /*0x10*/;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 18:
                                    goto label_12;
                                  case 20:
                                    try
                                    {
                                      num3 = (short) 4;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            if (enumerator3.MoveNext())
                                            {
                                              XmlNode current24 = (XmlNode) enumerator3.Current;
                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("몍", A_1_1));
                                              xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꎏ", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                              xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                              xmlTextWriter1.WriteString(current24.InnerText);
                                              xmlTextWriter1.WriteEndElement();
                                              xmlTextWriter1.WriteEndElement();
                                              num3 = (short) 1;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            goto label_527;
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
                                        num3 = (short) 0;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num21;
                                      switch (0)
                                      {
                                        case 0:
label_253:
                                          disposable = enumerator3 as IDisposable;
                                          num21 = (short) 2;
                                          num1 = (int) (IntPtr) num21;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                disposable.Dispose();
                                                num21 = (short) 1;
                                                num1 = (int) (IntPtr) num21;
                                                continue;
                                              case 1:
                                                goto label_257;
                                              case 2:
                                                if (disposable != null)
                                                {
                                                  num21 = (short) 0;
                                                  num1 = (int) (IntPtr) num21;
                                                  continue;
                                                }
                                                goto label_257;
                                              default:
                                                goto label_253;
                                            }
                                          }
label_257:;
                                      }
                                    }
                                  case 21:
                                    if (current14.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꦍ", A_1_1)))
                                    {
                                      str11 = RptMgrErrorHandler.b("겍", A_1_1) + current14.Attributes[i].Value + RptMgrErrorHandler.b("겍", A_1_1);
                                      num3 = (short) 0;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 12;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 23:
                                    num3 = (short) 18;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 25:
                                    if (isRightToLeft)
                                    {
                                      num3 = (short) 1;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDA8D\uF58F\uEA91\uE093힕\uF497\uF399ﮛ\uF09D춟잡쪣튥", A_1_1), RptMgrErrorHandler.b("슍\uF58F\uF491\uE093", A_1_1));
                                    xmlTextWriter1.WriteString(current14.Attributes[i].Value);
                                    num3 = (short) 24;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 26:
                                    try
                                    {
                                      num3 = (short) 4;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            if (!enumerator3.MoveNext())
                                            {
                                              num3 = (short) 0;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            XmlNode current25 = (XmlNode) enumerator3.Current;
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDA8D\uF18F\uF091\uF893\uF395\uDB97ﾙ\uF09B\uF29D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("춍ﾏﺑ\uE193ﮕ\uF697즙\uEC9Bﾝ캟", A_1_1), RptMgrErrorHandler.b("뢍", A_1_1));
                                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093얕\uF197\uE099鍊", A_1_1), RptMgrErrorHandler.b("뾍ꎏ", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093솕ﶗ\uF399ﮛ\uF69D풟", A_1_1), RptMgrErrorHandler.b("첍ﾏﺑ\uF093", A_1_1));
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏ\uE091\uF193\uF195\uEA97\uF599\uE99B\uF09D쒟", A_1_1), Colors.DarkBlue.ToString());
                                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("좍ﾏﲑ\uE093킕聯\uF799\uF59B\uF29D\uD99F", A_1_1), RptMgrErrorHandler.b("쾍\uE28Fﮑ\uF593歹", A_1_1));
                                            xmlTextWriter1.WriteString(current25.InnerText);
                                            xmlTextWriter1.WriteEndElement();
                                            xmlTextWriter1.WriteEndElement();
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            goto label_527;
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
                                        num3 = (short) 1;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      switch (0)
                                      {
                                        case 0:
label_285:
                                          disposable = enumerator3 as IDisposable;
                                          num1 = 0;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num1 = 2;
                                                  continue;
                                                }
                                                goto label_289;
                                              case 1:
                                                goto label_289;
                                              case 2:
                                                disposable.Dispose();
                                                num1 = 1;
                                                continue;
                                              default:
                                                goto label_285;
                                            }
                                          }
label_289:;
                                      }
                                    }
                                  case 28:
                                    if (this.l)
                                    {
                                      num3 = (short) 7;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto case 4;
                                  default:
label_262:
                                    num3 = (short) 17;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                }
label_524:
                                xmlTextWriter1.WriteEndElement();
                                xmlTextWriter1.WriteEndElement();
                                num1 = 22;
                                continue;
label_527:
                                xmlTextWriter1.WriteEndElement();
                                this.e = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛\uDE9D\uF49F쎡욣쪥춧\uE4A9춫쎭햯辱", A_1_1) + str11 + RptMgrErrorHandler.b("펍뾏삑\uF193\uF595쮗ﾙ\uE89B", A_1_1));
                                num3 = (short) 15;
                                num1 = (int) (IntPtr) num3;
                              }
                            }
                            finally
                            {
                              short num22;
                              switch (0)
                              {
                                case 0:
label_537:
                                  disposable = enumerator2 as IDisposable;
                                  num22 = (short) 0;
                                  num1 = (int) (IntPtr) num22;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num1)
                                    {
                                      case 0:
                                        if (disposable != null)
                                        {
                                          num22 = (short) 1;
                                          num1 = (int) (IntPtr) num22;
                                          continue;
                                        }
                                        goto label_541;
                                      case 1:
                                        disposable.Dispose();
                                        num22 = (short) 2;
                                        num1 = (int) (IntPtr) num22;
                                        continue;
                                      case 2:
                                        goto label_541;
                                      default:
                                        goto label_537;
                                    }
                                  }
label_541:;
                              }
                            }
label_12:
                            xmlTextWriter1.WriteStartElement(RptMgrErrorHandler.b("\uDE8D\uF18F\uE091\uF593\uF195\uEA97ﮙ\uEC9B\uF69D", A_1_1));
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("첍\uE28F\uF791\uF593ﶕ좗ﮙﮛﮝ\uE29F잡슣즥\uDAA7쾩", A_1_1), RptMgrErrorHandler.b("\uDA8D\uE28F\uE791\uF193", A_1_1));
                            xmlTextWriter1.WriteEndElement();
                            this.c = this.a.SelectNodes(RptMgrErrorHandler.b("ꆍ뾏욑\uF593\uF495\uF497ﾙ잛ﶝ쾟첡킣장솧쒩\uDFAB蚭\uF0AF\uE6B1햳풵풷\uDFB9\uF2BB\uDFBD궿\uA7C1\uE8C3\uE1C5", A_1_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("풍ﾏﲑ\uF193\uE595잗ﮙ\uF29B瞧ﾟ\uE1A1첣장욧쒩즫슭쎯", A_1_1), cultureInfo) + RptMgrErrorHandler.b("ꦍ릏쾑", A_1_1));
                            flag2 = true;
                            enumerator2 = this.c.GetEnumerator();
                            num1 = 8;
                            continue;
                          case 18:
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("\uDD8Dﾏ\uE791\uE693\uF595ﶗ", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꆍ\uF88F\uF791\uF593\uF295ﶗ\uE899늛\uF49D킟얡", A_1_1));
                            num3 = (short) 24;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 19:
                            xmlTextWriter1.WriteAttributeString(RptMgrErrorHandler.b("욍ﾏ\uE091ﶓ\uEC95\uF797\uF499\uE89Bﾝ첟\uE3A1좣쾥쾧쒩솫쮭\uDEAF욱", A_1_1), RptMgrErrorHandler.b("\uDC8D憐\uF591ﲓ\uE295", A_1_1));
                            num3 = (short) 14;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 21:
                            goto label_666;
                          case 22:
                            if (isRightToLeft)
                            {
                              num3 = (short) 9;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 5;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 23:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                        }
                        num3 = (short) 2;
                        num1 = (int) (IntPtr) num3;
                      }
                    }
                    finally
                    {
                      switch (0)
                      {
                        case 0:
label_661:
                          disposable = enumerator1 as IDisposable;
                          num1 = 1;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                disposable.Dispose();
                                num1 = 2;
                                continue;
                              case 1:
                                if (disposable != null)
                                {
                                  num1 = 0;
                                  continue;
                                }
                                goto label_665;
                              case 2:
                                goto label_665;
                              default:
                                goto label_661;
                            }
                          }
label_665:;
                      }
                    }
                  default:
                    goto label_5;
                }
label_666:
                xmlTextWriter1.WriteEndElement();
                xmlTextWriter1.Close();
                this.l = false;
                num3 = (short) 1;
                num1 = (int) (IntPtr) num3;
              }
          }
        }
        catch (Exception ex)
        {
          int num23 = (int) MessageBox.Show(ex.Message);
          flag1 = false;
        }
label_668:
        return flag1;
    }
  }

  private bool a(string A_0, string A_1, int A_2, int A_3, int A_4, bool A_5 = true)
  {
    int A_1_1 = 2;
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        this.b = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ춈\uEA8A歷\uEE8E", A_1_1));
        int i = 0;
        int num2 = 0;
        bool flag = true;
        CultureInfo cultureInfo = new CultureInfo(AppInfoManager.ReportsLangSelection);
        bool isRightToLeft = cultureInfo.TextInfo.IsRightToLeft;
        try
        {
          XmlTextWriter xmlTextWriter;
          short num3;
          switch (0)
          {
            case 0:
label_5:
              xmlTextWriter = new XmlTextWriter(Global.flowDocPath + A_0, Encoding.Unicode);
              xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쎄\uEB86\uE688ﲊ즌\uE08E\uF290\uE692\uF894\uF296\uF798\uEF9A", A_1_1));
              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("ﶄ\uEA86\uE588\uE58Aﺌ", A_1_1), RptMgrErrorHandler.b("\uED84\uF386ﶈﮊ람ꂎ뺐\uE092\uF694ﾖﲘ\uF69Aﲜ\uEC9E辠캢첤쒦\uDBA8쒪\uDEAC삮ힰ잲鮴풶횸횺銼좾ꣀ귂ꏄ뿆\uE6C8流\uFDCCￎ\uE7D0ﳒ귔뛖듘럚\uF2DC꿞鏠蛢雤苦蟨\u9FEA賬鯮飰鳲鯴", A_1_1));
              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("ﶄ\uEA86\uE588\uE58Aﺌ떎\uE990", A_1_1), RptMgrErrorHandler.b("\uED84\uF386ﶈﮊ람ꂎ뺐\uE092\uF694ﾖﲘ\uF69Aﲜ\uEC9E辠캢첤쒦\uDBA8쒪\uDEAC삮ힰ잲鮴풶횸횺銼좾ꣀ귂ꏄ뿆\uE6C8流\uFDCCￎ\uE7D0ﳒ귔뛖듘럚", A_1_1));
              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쮄\uE686\uE488\uEE8A", A_1_1), RptMgrErrorHandler.b("\uE384\uEB86\uED88\uE48A\uEE8C", A_1_1));
              num3 = (short) 1;
              num1 = (int) (IntPtr) num3;
              goto default;
            default:
              while (true)
              {
                IEnumerator enumerator1;
                switch (num1)
                {
                  case 0:
                    enumerator1 = this.b.GetEnumerator();
                    num3 = (short) 2;
                    num1 = (int) (IntPtr) num3;
                    continue;
                  case 1:
                    if (this.b.Count != 0)
                    {
                      num3 = (short) 0;
                      num1 = (int) (IntPtr) num3;
                      continue;
                    }
                    break;
                  case 2:
                    IDisposable disposable;
                    try
                    {
                      num3 = (short) 5;
                      num1 = (int) (IntPtr) num3;
                      while (true)
                      {
                        IEnumerator enumerator2;
                        XmlNode current1;
                        switch (num1)
                        {
                          case 0:
                          case 1:
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("첄\uEA86\uE888\uEC8A\uE88C", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE48C\uEC8E\uF090ﾒ풔ﮖ\uF098ﲚ\uF39C\uF29E쒠춢톤", A_1_1), RptMgrErrorHandler.b("톄\uE886麗", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE286\uE088\uEC8A\uE58Cﮎ", A_1_1), A_3.ToString());
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("튄\uEE86\uED88ﾊ\uE58C", A_1_1), A_2.ToString());
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ", A_1_1) + A_1);
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            this.c = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490", A_1_1));
                            enumerator2 = this.c.GetEnumerator();
                            num3 = (short) 7;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 2:
                            if (!isRightToLeft)
                            {
                              xmlTextWriter.WriteString(AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힄\uE686\uED88\uE28A\uE28C킎\uD890ﶒ\uF394\uF896\uEB98\uF69Aﲜ\uEB9E좠첢쮤", A_1_1), cultureInfo) + RptMgrErrorHandler.b("ꖄꞆꦈ", A_1_1) + current1.Attributes[i].Value);
                              num3 = (short) 21;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 20;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 3:
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ\uEF86\uEC88\uEA8A\uE98C\uEA8E\uE390붒ﾔ\uE796ﺘ", A_1_1));
                            num3 = (short) 10;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 4:
                            goto label_230;
                          case 5:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 6:
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF79A\uF49C\uF89E쾠캢삤즦\uDDA8", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                            num3 = (short) 0;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 7:
                            try
                            {
                              num3 = (short) 3;
                              num1 = (int) (IntPtr) num3;
                              while (true)
                              {
                                XmlNode xmlNode;
                                string str1;
                                IEnumerator enumerator3;
                                IEnumerator enumerator4;
                                XmlNode current2;
                                string text;
                                switch (num1)
                                {
                                  case 0:
                                    str1 = RptMgrErrorHandler.b("ꊄ", A_1_1) + current2.Attributes[i].Value + RptMgrErrorHandler.b("ꊄ", A_1_1);
                                    num3 = (short) 21;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 1:
                                    try
                                    {
                                      num3 = (short) 4;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            if (!enumerator4.MoveNext())
                                            {
                                              num3 = (short) 2;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            text = ((XmlNode) enumerator4.Current).InnerText + RptMgrErrorHandler.b("ꖄꞆꦈꮊ권", A_1_1);
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            goto label_96;
                                          case 2:
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
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
                                        num3 = (short) 0;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num4;
                                      switch (0)
                                      {
                                        case 0:
label_115:
                                          disposable = enumerator4 as IDisposable;
                                          num4 = (short) 2;
                                          num1 = (int) (IntPtr) num4;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                goto label_121;
                                              case 1:
                                                num4 = (short) -5051;
                                                int num5 = (int) num4;
                                                num4 = (short) -5051;
                                                int num6 = (int) num4;
                                                switch (num5 == num6 ? 1 : 0)
                                                {
                                                  case 0:
                                                  case 2:
                                                    continue;
                                                  default:
                                                    num4 = (short) 0;
                                                    if (num4 == (short) 0)
                                                      ;
                                                    disposable.Dispose();
                                                    num4 = (short) 0;
                                                    num1 = (int) (IntPtr) num4;
                                                    continue;
                                                }
                                              case 2:
                                                if (disposable != null)
                                                {
                                                  num4 = (short) 1;
                                                  num1 = (int) (IntPtr) num4;
                                                  continue;
                                                }
                                                goto label_121;
                                              default:
                                                goto label_115;
                                            }
                                          }
label_121:;
                                      }
                                    }
label_96:
                                    num1 = 12;
                                    continue;
                                  case 2:
                                  case 7:
                                    xmlTextWriter.WriteString(text);
                                    xmlTextWriter.WriteEndElement();
                                    xmlTextWriter.WriteEndElement();
                                    xmlTextWriter.WriteEndElement();
                                    this.e = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDB88\uEE8A\uEE8C\uDC8E\uF490\uE792", A_1_1));
                                    num3 = (short) 15;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 3:
                                    switch (0)
                                    {
                                      case 0:
                                        goto label_192;
                                      default:
                                        continue;
                                    }
                                  case 4:
                                    xmlTextWriter.WriteEndElement();
                                    num3 = (short) 9;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 5:
                                    try
                                    {
                                      num3 = (short) 10;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        string str2;
                                        XmlNode current3;
                                        string str3;
                                        switch (num1)
                                        {
                                          case 0:
                                            if (enumerator4.MoveNext())
                                            {
                                              current3 = (XmlNode) enumerator4.Current;
                                              str3 = (string) null;
                                              num3 = (short) 13;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 19;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                          case 8:
                                            xmlTextWriter.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter.WriteEndElement();
                                            xmlTextWriter.WriteEndElement();
                                            ++num2;
                                            xmlTextWriter.WriteEndElement();
                                            num3 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 2:
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGoldenrodYellow.ToString());
                                            num3 = (short) 6;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 3:
                                            str3 = RptMgrErrorHandler.b("ꊄ", A_1_1) + current3.Attributes[i].Value + RptMgrErrorHandler.b("ꊄ", A_1_1);
                                            num3 = (short) 14;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            try
                                            {
                                              num3 = (short) 2;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current4;
                                                switch (num1)
                                                {
                                                  case 0:
                                                  case 3:
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 1:
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGoldenrodYellow.ToString());
                                                    num3 = (short) 0;
                                                    num1 = (int) (IntPtr) num3;
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
                                                    if (num2 % 2 != 0)
                                                    {
                                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGray.ToString());
                                                      num3 = (short) 3;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 5:
                                                  case 10:
                                                    xmlTextWriter.WriteString(current4.InnerText);
                                                    xmlTextWriter.WriteEndElement();
                                                    xmlTextWriter.WriteEndElement();
                                                    num3 = (short) 12;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 6:
                                                    goto label_178;
                                                  case 7:
                                                    if (!isRightToLeft)
                                                    {
                                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                                                      num3 = (short) 5;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 11;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    num3 = (short) 6;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 9:
                                                    if (!enumerator3.MoveNext())
                                                    {
                                                      num3 = (short) 8;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    current4 = (XmlNode) enumerator3.Current;
                                                    xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C첎\uF490ﾒ璉", A_1_1));
                                                    xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                                                    num3 = (short) 4;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 11:
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                                                    num3 = (short) 10;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                }
                                                num3 = (short) 9;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              short num7;
                                              switch (0)
                                              {
                                                case 0:
label_160:
                                                  disposable = enumerator3 as IDisposable;
                                                  num7 = (short) 0;
                                                  num1 = (int) (IntPtr) num7;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        if (disposable != null)
                                                        {
                                                          num7 = (short) 2;
                                                          num1 = (int) (IntPtr) num7;
                                                          continue;
                                                        }
                                                        goto label_164;
                                                      case 1:
                                                        goto label_164;
                                                      case 2:
                                                        disposable.Dispose();
                                                        num7 = (short) 1;
                                                        num1 = (int) (IntPtr) num7;
                                                        continue;
                                                      default:
                                                        goto label_160;
                                                    }
                                                  }
label_164:;
                                              }
                                            }
label_178:
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C첎\uF490ﾒ璉", A_1_1));
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                                            num3 = (short) 20;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 5:
                                            goto label_99;
                                          case 6:
                                          case 15:
                                            num3 = (short) 9;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 7:
                                            if (xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꊄ", A_1_1)))
                                            {
                                              str2 = RptMgrErrorHandler.b("Ꞅ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("Ꞅ", A_1_1);
                                              num3 = (short) 21;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 17;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 9:
                                            if (isRightToLeft)
                                            {
                                              num3 = (short) 11;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 10:
                                            switch (0)
                                            {
                                              case 0:
                                                break;
                                              default:
                                                continue;
                                            }
                                            break;
                                          case 11:
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 12:
                                          case 14:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDB88\uEE8A\uEE8C\uDC8E\uF490\uE792캔힖쮘ﺚﺜ쮞좠힢즤슦钨", A_1_1) + str3 + RptMgrErrorHandler.b("\uD884ꢆ쾈\uE28A\uE88C\uE38E\uF590", A_1_1));
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C\uDD8Eﺐ\uE492", A_1_1));
                                            str2 = (string) null;
                                            num3 = (short) 7;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 13:
                                            if (!current3.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꊄ", A_1_1)))
                                            {
                                              num3 = (short) 3;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            str3 = RptMgrErrorHandler.b("Ꞅ", A_1_1) + current3.Attributes[i].Value + RptMgrErrorHandler.b("Ꞅ", A_1_1);
                                            num3 = (short) 12;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 17:
                                            str2 = RptMgrErrorHandler.b("ꊄ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꊄ", A_1_1);
                                            num3 = (short) 18;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 18:
                                          case 21:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDB88\uEE8A\uEE8C\uDC8E\uF490\uE792캔힖쮘ﺚﺜ쮞좠힢즤슦钨", A_1_1) + str3 + RptMgrErrorHandler.b("\uD884ꢆ쾈\uE28A\uE88C\uE38E\uF590좒햔톖\uF098ﺚ\uF19Cﮞ\uE5A0욢횤骦", A_1_1) + str2 + RptMgrErrorHandler.b("\uD884ꢆ\uDF88\uEA8A\uE18C搜\uF490\uE092", A_1_1));
                                            enumerator3 = this.f.GetEnumerator();
                                            num3 = (short) 4;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 19:
                                            num3 = (short) 5;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 20:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 15;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 2;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                        }
                                        num3 = (short) 0;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num8;
                                      switch (0)
                                      {
                                        case 0:
label_184:
                                          disposable = enumerator4 as IDisposable;
                                          num8 = (short) 0;
                                          num1 = (int) (IntPtr) num8;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                if (disposable != null)
                                                {
                                                  num8 = (short) 2;
                                                  num1 = (int) (IntPtr) num8;
                                                  continue;
                                                }
                                                goto label_188;
                                              case 1:
                                                goto label_188;
                                              case 2:
                                                disposable.Dispose();
                                                num8 = (short) 1;
                                                num1 = (int) (IntPtr) num8;
                                                continue;
                                              default:
                                                goto label_184;
                                            }
                                          }
label_188:;
                                      }
                                    }
                                  case 6:
                                    num3 = (short) 8;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 8:
                                    if (!isRightToLeft)
                                    {
                                      enumerator4 = this.e.GetEnumerator();
                                      num3 = (short) 13;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 17;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 10:
                                    text = "";
                                    enumerator4 = this.d.GetEnumerator();
                                    num3 = (short) 1;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 11:
                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                                    num3 = (short) 2;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 12:
                                    if (!isRightToLeft)
                                    {
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                                      num3 = (short) 7;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 11;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 13:
                                    try
                                    {
                                      num3 = (short) 2;
                                      num1 = (int) (IntPtr) num3;
                                      while (true)
                                      {
                                        string str4;
                                        XmlNode current5;
                                        string str5;
                                        switch (num1)
                                        {
                                          case 0:
                                            if (num2 % 2 != 0)
                                            {
                                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGray.ToString());
                                              num3 = (short) 5;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 15;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 1:
                                            if (xmlNode.Attributes[0].Value.Contains(RptMgrErrorHandler.b("ꊄ", A_1_1)))
                                            {
                                              str4 = RptMgrErrorHandler.b("Ꞅ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("Ꞅ", A_1_1);
                                              num3 = (short) 6;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num3;
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
                                          case 10:
                                            xmlNode = this.a.SelectSingleNode(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDB88\uEE8A\uEE8C\uDC8E\uF490\uE792캔힖쮘ﺚﺜ쮞좠힢즤슦钨", A_1_1) + str5 + RptMgrErrorHandler.b("\uD884ꢆ쾈\uE28A\uE88C\uE38E\uF590", A_1_1));
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C\uDD8Eﺐ\uE492", A_1_1));
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C첎\uF490ﾒ璉", A_1_1));
                                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                                            num3 = (short) 0;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 4:
                                            if (!enumerator4.MoveNext())
                                            {
                                              num3 = (short) 11;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            current5 = (XmlNode) enumerator4.Current;
                                            str5 = (string) null;
                                            num3 = (short) 8;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 5:
                                          case 7:
                                            xmlTextWriter.WriteString(xmlNode.Attributes[0].Value);
                                            xmlTextWriter.WriteEndElement();
                                            xmlTextWriter.WriteEndElement();
                                            str4 = (string) null;
                                            num3 = (short) 1;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 6:
                                          case 17:
                                            this.f = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDB88\uEE8A\uEE8C\uDC8E\uF490\uE792캔힖쮘ﺚﺜ쮞좠힢즤슦钨", A_1_1) + str5 + RptMgrErrorHandler.b("\uD884ꢆ쾈\uE28A\uE88C\uE38E\uF590좒햔톖\uF098ﺚ\uF19Cﮞ\uE5A0욢횤骦", A_1_1) + str4 + RptMgrErrorHandler.b("\uD884ꢆ\uDF88\uEA8A\uE18C搜\uF490\uE092", A_1_1));
                                            enumerator3 = this.f.GetEnumerator();
                                            num3 = (short) 13;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 8:
                                            if (current5.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꊄ", A_1_1)))
                                            {
                                              str5 = RptMgrErrorHandler.b("Ꞅ", A_1_1) + current5.Attributes[i].Value + RptMgrErrorHandler.b("Ꞅ", A_1_1);
                                              num3 = (short) 10;
                                              num1 = (int) (IntPtr) num3;
                                              continue;
                                            }
                                            num3 = (short) 12;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 11:
                                            num3 = (short) 14;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 12:
                                            str5 = RptMgrErrorHandler.b("ꊄ", A_1_1) + current5.Attributes[i].Value + RptMgrErrorHandler.b("ꊄ", A_1_1);
                                            num3 = (short) 3;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 13:
                                            try
                                            {
                                              num3 = (short) 12;
                                              num1 = (int) (IntPtr) num3;
                                              while (true)
                                              {
                                                XmlNode current6;
                                                switch (num1)
                                                {
                                                  case 0:
                                                    if (num2 % 2 == 0)
                                                    {
                                                      num3 = (short) 9;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGray.ToString());
                                                    num3 = (short) 1;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 1:
                                                  case 5:
                                                    num3 = (short) 8;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 2:
                                                    goto label_84;
                                                  case 3:
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                                                    num3 = (short) 4;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 4:
                                                  case 7:
                                                    xmlTextWriter.WriteString(current6.InnerText);
                                                    xmlTextWriter.WriteEndElement();
                                                    xmlTextWriter.WriteEndElement();
                                                    num3 = (short) 6;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 8:
                                                    if (isRightToLeft)
                                                    {
                                                      num3 = (short) 3;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                                                    num3 = (short) 7;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 9:
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGoldenrodYellow.ToString());
                                                    num3 = (short) 5;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 10:
                                                    if (enumerator3.MoveNext())
                                                    {
                                                      current6 = (XmlNode) enumerator3.Current;
                                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C첎\uF490ﾒ璉", A_1_1));
                                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                                                      num3 = (short) 0;
                                                      num1 = (int) (IntPtr) num3;
                                                      continue;
                                                    }
                                                    num3 = (short) 11;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 11:
                                                    num3 = (short) 2;
                                                    num1 = (int) (IntPtr) num3;
                                                    continue;
                                                  case 12:
                                                    switch (0)
                                                    {
                                                      case 0:
                                                        break;
                                                      default:
                                                        continue;
                                                    }
                                                    break;
                                                }
                                                num3 = (short) 10;
                                                num1 = (int) (IntPtr) num3;
                                              }
                                            }
                                            finally
                                            {
                                              switch (0)
                                              {
                                                case 0:
label_74:
                                                  disposable = enumerator3 as IDisposable;
                                                  num1 = 2;
                                                  goto default;
                                                default:
                                                  while (true)
                                                  {
                                                    switch (num1)
                                                    {
                                                      case 0:
                                                        goto label_78;
                                                      case 1:
                                                        disposable.Dispose();
                                                        num1 = 0;
                                                        continue;
                                                      case 2:
                                                        if (disposable != null)
                                                        {
                                                          num1 = 1;
                                                          continue;
                                                        }
                                                        goto label_78;
                                                      default:
                                                        goto label_74;
                                                    }
                                                  }
label_78:;
                                              }
                                            }
label_84:
                                            ++num2;
                                            xmlTextWriter.WriteEndElement();
                                            num3 = (short) 9;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 14:
                                            goto label_99;
                                          case 15:
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.LightGoldenrodYellow.ToString());
                                            num3 = (short) 7;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                          case 16 /*0x10*/:
                                            str4 = RptMgrErrorHandler.b("ꊄ", A_1_1) + xmlNode.Attributes[0].Value + RptMgrErrorHandler.b("ꊄ", A_1_1);
                                            num3 = (short) 17;
                                            num1 = (int) (IntPtr) num3;
                                            continue;
                                        }
                                        num3 = (short) 4;
                                        num1 = (int) (IntPtr) num3;
                                      }
                                    }
                                    finally
                                    {
                                      short num9;
                                      switch (0)
                                      {
                                        case 0:
label_91:
                                          disposable = enumerator4 as IDisposable;
                                          num9 = (short) 2;
                                          num1 = (int) (IntPtr) num9;
                                          goto default;
                                        default:
                                          while (true)
                                          {
                                            switch (num1)
                                            {
                                              case 0:
                                                goto label_95;
                                              case 1:
                                                disposable.Dispose();
                                                num9 = (short) 0;
                                                num1 = (int) (IntPtr) num9;
                                                continue;
                                              case 2:
                                                if (disposable != null)
                                                {
                                                  num9 = (short) 1;
                                                  num1 = (int) (IntPtr) num9;
                                                  continue;
                                                }
                                                goto label_95;
                                              default:
                                                goto label_91;
                                            }
                                          }
label_95:;
                                      }
                                    }
                                  case 14:
                                    if (current2.Attributes[i].Value.Contains(RptMgrErrorHandler.b("ꊄ", A_1_1)))
                                    {
                                      str1 = RptMgrErrorHandler.b("Ꞅ", A_1_1) + current2.Attributes[i].Value + RptMgrErrorHandler.b("Ꞅ", A_1_1);
                                      num3 = (short) 22;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 0;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 15:
                                    if (this.e.Count > 0)
                                    {
                                      num3 = (short) 6;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    break;
                                  case 16 /*0x10*/:
                                    if (enumerator2.MoveNext())
                                    {
                                      current2 = (XmlNode) enumerator2.Current;
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE686\uEA88\uE08A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.Coral.ToString());
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ얐ﮒﲔ\uF496\uF298\uF59A\uF89C\uEC9E튠", A_1_1), RptMgrErrorHandler.b("랄ꮆ뮈꞊뾌ꎎꎐ", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ펐\uE192\uE094\uE496\uF198", A_1_1), RptMgrErrorHandler.b("Ꚅ솆쾈뮊붌벎튐꒒ꆔ", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("햄\uE686\uED88\uEF8A\uE48C\uE18E\uF690", A_1_1), RptMgrErrorHandler.b("뚄", A_1_1));
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C\uDD8Eﺐ\uE492튔\uE596\uF698\uEE9A\uED9C", A_1_1));
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C\uDD8Eﺐ\uE492", A_1_1));
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE686\uEB88\uE78A\uE88C첎\uF490ﾒ璉", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ얐ﮒﲔ\uF496\uF298\uF59A\uF89C\uEC9E튠", A_1_1), RptMgrErrorHandler.b("떄ꮆ릈꞊붌ꎎꎐ", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("욄\uE886\uE588ﺊ\uE08C\uE18E슐\uE392\uF494練", A_1_1), RptMgrErrorHandler.b("랄", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uE886ﮈ\uEF8A\uE88Cﶎ펐\uE192\uE094\uE496\uF198", A_1_1), RptMgrErrorHandler.b("Ꚅ솆쾈뮊붌뾎ꆐꎒꖔ", A_1_1));
                                      xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                                      xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDA8C\uEA8E\uF890\uF492ﶔ\uE396", A_1_1), RptMgrErrorHandler.b("임\uE886\uE588\uEF8A", A_1_1));
                                      str1 = (string) null;
                                      num3 = (short) 14;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    num3 = (short) 18;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 17:
                                    enumerator4 = this.e.GetEnumerator();
                                    num3 = (short) 5;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 18:
                                    num3 = (short) 19;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  case 19:
                                    goto label_33;
                                  case 20:
                                    if (this.d.Count > 0)
                                    {
                                      num3 = (short) 10;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    }
                                    goto case 4;
                                  case 21:
                                  case 22:
                                    this.d = this.a.SelectNodes(RptMgrErrorHandler.b("ꪄꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490좒햔쎖\uF898連\uF19C爵\uEFA0슢좤슦钨", A_1_1) + str1 + RptMgrErrorHandler.b("\uD884ꢆ\uDD88\uEA8A\uEF8C\uE38E\uF490\uDB92\uF094\uF696ﶘﺚ\uEF9C낞\uE2A0첢즤\uF3A6삨\uDFAA솬쪮", A_1_1));
                                    num3 = (short) 20;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                  default:
label_192:
                                    num3 = (short) 16 /*0x10*/;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                }
label_99:
                                xmlTextWriter.WriteEndElement();
                                num3 = (short) 4;
                                num1 = (int) (IntPtr) num3;
                              }
                            }
                            finally
                            {
                              short num10;
                              switch (0)
                              {
                                case 0:
label_203:
                                  disposable = enumerator2 as IDisposable;
                                  num10 = (short) 0;
                                  num1 = (int) (IntPtr) num10;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num1)
                                    {
                                      case 0:
                                        if (disposable != null)
                                        {
                                          num10 = (short) 2;
                                          num1 = (int) (IntPtr) num10;
                                          continue;
                                        }
                                        goto label_207;
                                      case 1:
                                        goto label_207;
                                      case 2:
                                        disposable.Dispose();
                                        num10 = (short) 1;
                                        num1 = (int) (IntPtr) num10;
                                        continue;
                                      default:
                                        goto label_203;
                                    }
                                  }
label_207:;
                              }
                            }
label_33:
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쎄\uEE86\uEE88ﺊﾌ\uEA8E", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE48C\uEC8E\uF090ﾒ풔練滛\uF39A\uF29C\uED9E", A_1_1), RptMgrErrorHandler.b("햄\uE686\uEE88\uEE8A쾌\uE08E\uE590\uE792杖殺", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF59Aﺜ\uF79E캠톢", A_1_1), RptMgrErrorHandler.b("욄\uE886\uE788ﾊ\uE88C\uE18E\uE590솒ﲔ\uF096\uF198\uEF9A", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("좄\uE686ﮈ\uEC8A\uE48C\uE18E", A_1_1), RptMgrErrorHandler.b("뒄ꮆ뢈꞊벌ꎎꂐ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("임\uEB86\uE688\uE88A\uE68C\uDA8E\uD890킒杖練\uED98漢\uF49C\uF19E쒠톢", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ쾌\uE38Eﺐ\uF092ﺔ", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("뒄떆", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C", A_1_1));
                            num1 = 9;
                            continue;
                          case 8:
                          case 15:
                            xmlTextWriter.WriteString(ReportViewer.convertToArabicDateTime(DateTime.Now.ToString((IFormatProvider) cultureInfo)));
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쎄\uEE86\uEE88ﺊﾌ\uEA8E", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE48C\uEC8E\uF090ﾒ풔練滛\uF39A\uF29C\uED9E", A_1_1), RptMgrErrorHandler.b("햄\uE686\uEE88\uEE8A쾌\uE08E\uE590\uE792杖殺", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("좄\uE686ﮈ\uEC8A\uE48C\uE18E", A_1_1), RptMgrErrorHandler.b("뒄ꮆ뢈꞊벌ꎎꂐ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("임\uEB86\uE688\uE88A\uE68C\uDA8E\uD890킒杖練\uED98漢\uF49C\uF19E쒠톢", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("첄\uEA86\uE888\uEC8A\uE88C", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ얆\uE688ﾊ歷\uE08Eﲐ붒\uDF94잖\uDE98", A_1_1));
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("즄\uEE86\uE788\uEE8A쾌ﶎ\uF490\uF292ﺔ", A_1_1));
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            num3 = (short) 14;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 9:
                            if (!isRightToLeft)
                            {
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF79A\uF49C\uF89E쾠캢삤즦\uDDA8", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                              num3 = (short) 15;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 19;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 10:
                          case 17:
                          case 18:
                          case 22:
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ\uDE8C\uE68E\uEB90\uF692", A_1_1), RptMgrErrorHandler.b("랄떆", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("욄\uE286\uE788ﾊ\uE88Cﶎ", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886ﮈ\uEE8A\uEA8Cﶎﺐ\uE692ﮔ\uF396", A_1_1), Colors.DarkBlue.ToString());
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쎄\uE886\uE788ﾊ쮌\uEE8Eﲐ朗璉\uEE96", A_1_1), RptMgrErrorHandler.b("쒄\uF586\uE088\uEA8A\uE18C춎\uFD90\uF292\uF694ﲖ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("임\uE886\uE588\uEF8A", A_1_1));
                            num3 = (short) 2;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 11:
                            num3 = (short) 26;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 12:
                            if (A_5)
                            {
                              num3 = (short) 3;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ\uEF86\uEC88\uEA8A\uE98C\uEA8E\uE390첒\uF394ﮖ\uF098\uEB9A\uED9C爵얠ﲢ펤슦\uDBA8\uDFAA좬\uD7AE龰\uD9B2어킶", A_1_1));
                            num3 = (short) 18;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 13:
                            if (!enumerator1.MoveNext())
                            {
                              num3 = (short) 29;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            current1 = (XmlNode) enumerator1.Current;
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("횄\uE286\uEA88ﾊ\uE48C\uE08Eﾐ", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("임\uF586\uEC88\uEA8A\uE68C\uDF8E\uF090\uF492\uF094햖ﲘﶚ\uF29C\uED9E쒠", A_1_1), RptMgrErrorHandler.b("톄\uF586ﲈ\uEE8A", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("첄\uEA86\uE888\uEC8A\uE88C", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE286\uE088\uEC8A\uE58Cﮎ", A_1_1), RptMgrErrorHandler.b("낄랆", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uF386ﮈ\uEE8A歷\uEC8E戀", A_1_1), RptMgrErrorHandler.b("쎄\uEE86\uE588\uE78A", A_1_1));
                            num3 = (short) 23;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 16 /*0x10*/:
                            if (isRightToLeft)
                            {
                              num3 = (short) 6;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF79A\uF49C\uF89E쾠캢삤즦\uDDA8", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                            num3 = (short) 1;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 19:
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("춄\uE886ﮈ\uE28A\uF78C\uE08Eﾐ\uE792\uF494ﮖ\uD898\uF79A\uF49C\uF89E쾠캢삤즦\uDDA8", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                            num3 = (short) 8;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 20:
                            xmlTextWriter.WriteString(current1.Attributes[i].Value + RptMgrErrorHandler.b("ꖄꞆꦈ", A_1_1) + AppResources.ResourceManager.GetString(RptMgrErrorHandler.b("힄\uE686\uED88\uE28A\uE28C킎\uD890ﶒ\uF394\uF896\uEB98\uF69Aﲜ\uEB9E좠첢쮤", A_1_1), cultureInfo));
                            num3 = (short) 24;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 21:
                          case 24:
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteEndElement();
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("햄\uE686ﮈ\uEA8A\uEA8Cﶎ\uF090\uE392ﶔ", A_1_1));
                            num3 = (short) 27;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 23:
                            if (isRightToLeft)
                            {
                              num3 = (short) 11;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 12;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 25:
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("힄\uEE86\uEE88\uE38A歷", A_1_1));
                            num3 = (short) 28;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 26:
                            if (!A_5)
                            {
                              xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ\uEF86\uEC88\uEA8A\uE98C\uEA8E\uE390첒\uE394\uF296\uEB98\uEF9A\uF89C\uE79E辠즢햤삦", A_1_1));
                              num3 = (short) 17;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            num3 = (short) 31 /*0x1F*/;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 27:
                            if (isRightToLeft)
                            {
                              num3 = (short) 25;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            }
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("톄\uE286\uF188ﾊ첌\uE38E\uF890\uF492ﮔ殺ﲘ\uF59A\uE99C", A_1_1), RptMgrErrorHandler.b("즄\uE286\uEF88ﾊ", A_1_1));
                            num3 = (short) 30;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 28:
                          case 30:
                            xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쎄\uEB86\uE688\uEA8A歷\uEA8E\uE390", A_1_1));
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("튄\uEE86\uED88ﾊ\uE58C", A_1_1), A_4.ToString());
                            num3 = (short) 16 /*0x10*/;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 29:
                            num3 = (short) 4;
                            num1 = (int) (IntPtr) num3;
                            continue;
                          case 31 /*0x1F*/:
                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("횄\uE886ﲈ力\uEE8C\uEA8E", A_1_1), Global.contentDir + RptMgrErrorHandler.b("ꪄ\uEF86\uEC88\uEA8A\uE98C\uEA8E\uE390첒\uF394ﮖ\uF098\uEB9A\uED9C爵얠趢쾤\uD7A6캨", A_1_1));
                            num3 = (short) 22;
                            num1 = (int) (IntPtr) num3;
                            continue;
                        }
                        num3 = (short) 13;
                        num1 = (int) (IntPtr) num3;
                      }
                    }
                    finally
                    {
                      short num11;
                      switch (0)
                      {
                        case 0:
label_225:
                          disposable = enumerator1 as IDisposable;
                          num11 = (short) 0;
                          num1 = (int) (IntPtr) num11;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num11 = (short) 2;
                                  num1 = (int) (IntPtr) num11;
                                  continue;
                                }
                                goto label_229;
                              case 1:
                                goto label_229;
                              case 2:
                                disposable.Dispose();
                                num11 = (short) 1;
                                num1 = (int) (IntPtr) num11;
                                continue;
                              default:
                                goto label_225;
                            }
                          }
label_229:;
                      }
                    }
                  case 3:
                    goto label_232;
                  default:
                    goto label_5;
                }
label_230:
                xmlTextWriter.WriteEndElement();
                xmlTextWriter.Close();
                num3 = (short) 3;
                num1 = (int) (IntPtr) num3;
              }
          }
        }
        catch (Exception ex)
        {
          int num12 = (int) MessageBox.Show(ex.Message);
          flag = false;
        }
label_232:
        return flag;
    }
  }

  private void a(
    ref string A_0,
    ref int A_1,
    ref int A_2,
    ref int A_3,
    string A_4,
    int A_5,
    int A_6,
    int A_7)
  {
    short num1 = -15248;
    int num2 = (int) num1;
    num1 = (short) -15248;
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
        A_0 = A_4;
        A_1 = A_5;
        A_2 = A_6;
        A_3 = A_7;
        break;
      default:
        goto case 1;
    }
  }

  private bool f()
  {
    int A_1_1 = 2;
    int num1 = 0;
    switch (num1)
    {
      default:
        int A_1_2;
        int A_2;
        int A_3;
        bool flag;
        string A_0;
        string empty;
        string numberA8539UiValue;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            A_1_2 = 200;
            A_2 = 600;
            A_3 = 300;
            flag = true;
            A_0 = RptMgrErrorHandler.b("쎄\uEB86\uE688ﲊ\uDF8C\uEE8E\uF590朗杖\uDE96\uF798ﶚ\uF29C놞\uD9A0슢좤쮦", A_1_1);
            empty = string.Empty;
            numberA8539UiValue = (FeatureManager.GetFeature(2049)[0] as Motorola.MackinawCPS.CoreFeatures.RadioInformation.RadioInformation).General.RadInfoGeneralModelNumber_A8539_UIValue;
            num2 = (short) 196;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뚆번\uDE8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 211;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 71;
                case 1:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊뢌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 275;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄늆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜꾞銠ﲢ鎤銦馨鮪莬\uE5AE\uE1B0\uF4B2", A_1_1), 250, 600, 300);
                  num2 = (short) 68;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  num2 = (short) 125;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDA8A즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 175;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 4:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 101;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_402;
                case 5:
                  num2 = (short) 131;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈삊즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 146;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 168;
                case 7:
                  num2 = (short) 85;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆번\uDF8A쪌\uDA8Eꢐ쎒슔꾖\uD898햚", A_1_1)))
                  {
                    num2 = (short) 77;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 145;
                case 9:
                case 178:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 230;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뎊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 254;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 37;
                case 12:
                  if (UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 157;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_434;
                case 13:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뾆불\uD88A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 278;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 120;
                case 14:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄떆번삊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 299;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 71;
                case 15:
                  num2 = (short) 143;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("톄\uDF86쒈뢊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 124;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 46;
                case 17:
                  num2 = (short) 277;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뎆번\uDF8A쪌\uDA8Eꢐ쎒슔꾖\uD898햚", A_1_1)))
                  {
                    num2 = (short) 145;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 297;
                case 19:
                  num2 = (short) 214;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  num2 = (short) 163;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 21:
                  num2 = (short) 115;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 22:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈풊쎌쪎즐잒쪔\uD996\uF698힚ﲜﶞ쒠쾢认\uEDA6令\uECAA", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 69;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 23:
                  num2 = (short) 158;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 24:
                  num2 = (short) 258;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 25:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈릊붌뾎ꆐ첒꒔릖겘쒚펜\uF09E\uEDA0슢잤슦얨薪\uE7ACﾮ\uF6B0", A_1_1), 260, 550, 260);
                  num2 = (short) 295;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  if (numberA8539UiValue.Contains(RptMgrErrorHandler.b("늄욆있", A_1_1)))
                  {
                    num2 = (short) 207;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 74;
                case 27:
                  num2 = (short) 287;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 28:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄펆\uDA88릊뢌뾎ꆐ\uE392", A_1_1)))
                  {
                    num2 = (short) 268;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_402;
                case 29:
                  num2 = (short) 172;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 30:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ\uF592\uE794\uF896\uF798\uEF9A뎜\uF59E토쒢", A_1_1), 300, 550, 275);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 31 /*0x1F*/:
                  num2 = (short) 109;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뚆번펊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 50;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 71;
                case 33:
                  num2 = (short) 228;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 24;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_386;
                case 35:
                  num2 = (short) 220;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 132;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_26;
                case 37:
                  num2 = (short) 190;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈몊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 151;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 182;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 39:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 104;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 284;
                case 40:
                  goto label_350;
                case 41:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뢊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 51;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 42:
                  num2 = (short) 113;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 56;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_146;
                case 44:
                  num2 = (short) 283;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 45:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 221;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 210;
                case 46:
                case 81:
                case 105:
                case 235:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 274;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  num2 = (short) 130;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 48 /*0x30*/:
                  num2 = (short) 289;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈릊붌뾎ꆐ첒ꆔꞖꦘꮚ슜궞ﺠ\uE8A2쮤좦쮨\uF4AA\uE3AC삮ﶰ튲ힴ튶햸閺ힼ쾾ꛀ", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 58;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 50:
                  num2 = (short) 152;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 51:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뢊붌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 200, 550, 200);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 52:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 170;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 58;
                case 53:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 82;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 54:
                  num2 = (short) 52;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 55:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 79;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 218;
                case 56:
                  num2 = (short) 282;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 57:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뮈\uDE8A캌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 89;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 25;
                case 58:
                  num2 = (short) 288;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 59:
                  num2 = (short) 167;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 60:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 300;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_226;
                case 61:
                  if (UtilityMack.IsAPX2000APX4000With2Knobs)
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 58;
                case 62:
                  num2 = (short) 0;
                  num2 = (short) 257;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 63 /*0x3F*/:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 285;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 151;
                case 64 /*0x40*/:
                  goto label_280;
                case 65:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDE8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 195;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case 66:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈ꮊ쎌쪎즐잒", A_1_1)))
                  {
                    num2 = (short) 22;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 69;
                case 67:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 30;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 47;
                case 68:
                case 270:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 69:
                  num2 = (short) 237;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 70:
                case 117:
                case 225:
                case 234:
                case 262:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 71:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈풊쎌몎ꆐ첒\uDB94꒖ꦘ쒚펜\uF09E\uEDA0슢잤슦얨薪\uE7ACﾮ\uF6B0", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 236;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 72:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 161;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 121;
                case 73:
                  num2 = (short) 114;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 74:
                  num2 = (short) 55;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 75:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 119;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 297;
                case 76:
                  num2 = (short) 174;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 77:
label_220:
                  num2 = (short) 18;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 78:
                  num2 = (short) 66;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 79:
                  num2 = (short) 197;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 80 /*0x50*/:
                  num2 = (short) 95;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 82:
                  num2 = (short) 67;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 83:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뺈\uDF8A쪌쮎ꢐ쎒슔Ꚗ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 292;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 284;
                case 84:
                  num2 = (short) 223;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 85:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDC8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 98;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_434;
                case 86:
                  num2 = (short) 137;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 87:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE88C\uF78E", A_1_1)))
                  {
                    num2 = (short) 86;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 177;
                case 88:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 160 /*0xA0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 70;
                case 89:
                  num2 = (short) 162;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 90:
                  num2 = (short) 199;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 91:
                  num2 = (short) 206;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 92:
                  num2 = (short) 194;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 93:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 242;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_434;
                case 94:
                  num2 = (short) 164;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 95:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈몊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 35;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_437;
                case 96 /*0x60*/:
                  num2 = (short) 142;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 97:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 217;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 57;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 98:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ朗쪔ꖖ욘햚\uF29C펞삠솢삤쮦螨솪\uDDAC좮", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 234;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 99:
                  num2 = (short) 179;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 100:
                  if (numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("즄", A_1_1)))
                  {
                    num2 = (short) 202;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_26;
                case 101:
                  num2 = (short) 28;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 102:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 155;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 54;
                case 103:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뾆불\uDA8A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 192 /*0xC0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 120;
                case 104:
                  num2 = (short) 83;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 106:
                  if (UtilityMack.IsWorldWidePro)
                  {
                    num2 = (short) 27;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 54;
                case 107:
                  num2 = (short) 290;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 108:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE88C\uF78E", A_1_1)))
                  {
                    num2 = (short) 129;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 74;
                case 109:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 265;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 110:
                case 183:
                case 281:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 31 /*0x1F*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 111:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uD88A즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 44;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 112 /*0x70*/:
                  num2 = (short) 238;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 113:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뢈\uD88A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 148;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 229;
                case 114:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뮈삊즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 250;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 115:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈릊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 116:
                  num2 = (short) 75;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 118:
                case 191:
                case 193:
                case 271:
                case 294:
                case 295:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 54;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 119:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 120:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ첒꒔릖겘쒚펜\uF09E\uEDA0슢잤슦얨薪\uE7ACﾮ\uF6B0", A_1_1), 260, 550, 260);
                  num2 = (short) 271;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 121:
                  num2 = (short) 243;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 122:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뾆불\uDE8A캌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 76;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 120;
                case 123:
                  num2 = (short) 108;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 124:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("톄\uDF86쒈릊붌뾎ꆐ붒\uDF94잖\uDE98", A_1_1), 250, 600, 300);
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 125:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈벊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 90;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case 126:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDA8A즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 84;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case (int) sbyte.MaxValue:
                  num2 = (short) 176 /*0xB0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 128 /*0x80*/:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄떆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜킞銠ﲢ鞤銦馨鮪莬\uE5AE\uE1B0\uF4B2", A_1_1), 250, 600, 300);
                  num2 = (short) 81;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 129:
                  num2 = (short) 26;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 130:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 266;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_250;
                case 131:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 21;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_437;
                case 132:
                  num2 = (short) 100;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 133:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ쮒킔", A_1_1)))
                  {
                    num2 = (short) 213;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 121;
                case 134:
                  num2 = (short) 219;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 135:
                  num2 = (short) 232;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 136:
                  num2 = (short) 201;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 137:
                  if (numberA8539UiValue.Contains(RptMgrErrorHandler.b("뎄욆있", A_1_1)))
                  {
                    num2 = (short) 252;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 177;
                case 138:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 222;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 70;
                case 139:
                  num2 = (short) 87;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 140:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쎄\uEE86ﮈ\uEE8A삌\uEE8E\uF290\uF892쪔\uD996\uF698힚ﲜﶞ쒠쾢认\uEDA6令\uECAA", A_1_1), 350, 550, 300);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 218;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 141:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊붌뾎ꆐ쮒\uDD94", A_1_1)))
                  {
                    num2 = (short) 231;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 135;
                case 142:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("톄\uDF86쒈뢊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 80 /*0x50*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 143:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 246;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 144 /*0x90*/:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈릊붌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 260, 550, 260);
                  num2 = (short) 193;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 145:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈풊쎌쪎즐잒쪔쾖힘쒚펜\uF09E\uEDA0슢잤슦얨薪\uE7ACﾮ\uF6B0", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 297;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 146:
                  num2 = (short) 216;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 147:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄늆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜꾞銠ﲢ邤銦馨鮪莬\uE5AE\uE1B0\uF4B2", A_1_1), 250, 600, 300);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 94;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 148:
                  num2 = (short) 185;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 149:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 150:
                  num2 = (short) 103;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 151:
                  num2 = (short) -20093;
                  int num3 = (int) num2;
                  num2 = (short) -20093;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_220;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 36;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 152:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄떆번펊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 71;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 153:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 208 /*0xD0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 37;
                case 154:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈풊쎌쪎즐잒쪔\uD996\uF698힚ﲜﶞ쒠쾢认춦\uD9A8첪", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 116;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 155:
                  num2 = (short) 106;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 156:
                  num2 = (short) 264;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 157:
                  num2 = (short) 65;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 158:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뢈\uDE8A캌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 99;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 229;
                case 159:
                  if (!numberA8539UiValue.Trim().ToUpper().Contains(RptMgrErrorHandler.b("튄낆", A_1_1)))
                  {
                    this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뺊붌뾎ꆐ첒\uD894ꖖ욘햚\uF29C펞삠솢삤쮦螨\uE1AAﶬ\uE8AE", A_1_1), 350, 550, 275);
                    num2 = (short) 263;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 293;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 160 /*0xA0*/:
                  num2 = (short) 138;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 161:
                  num2 = (short) 133;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 162:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뮈\uDA8A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 247;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 25;
                case 163:
                  if (UtilityMack.IsAPX1000With2Knobs)
                  {
                    num2 = (short) 203;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_78;
                case 164:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 215;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 165:
                  num2 = (short) 53;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 166:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊붌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 23;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 167:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 139;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 177;
                case 168:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ朗쪔꒖욘햚\uF29C펞삠솢삤쮦螨솪\uDDAC좮", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 262;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 169:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뮈\uD88A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 73;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 25;
                case 170:
                  num2 = (short) 61;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 171:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 123;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 74;
                case 172:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 92;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 94;
                case 173:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 174:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뾆불\uDC8A캌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 97;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 120;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 175:
                  num2 = (short) 111;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 176 /*0xB0*/:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈삊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case 177:
                  num2 = (short) 171;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 179:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뢈\uDA8A즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 229;
                case 180:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDE8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 136;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 245;
                case 181:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊뢌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 210;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 182:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("톄\uDF86쒈릊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 204;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 124;
                case 184:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊뢌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 187;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 151;
                case 185:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄늆뢈삊즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 229;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 186:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDC8A캌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 239;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_78;
                case 187:
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 188:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ\uDB92", A_1_1)))
                  {
                    num2 = (short) 40;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_250;
                case 189:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 20;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_78;
                case 190:
                  if (UtilityMack.IsMobile())
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 29;
                case 192 /*0xC0*/:
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 194:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뺊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 147;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 94;
                case 195:
                  num2 = (short) 126;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 196:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 33;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 165;
                case 197:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뎆낈\uDF8A쪌쮎ꢐ쎒슔Ꚗ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 140;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 218;
                case 198:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ\uDF92ﲔ좖힘\uF49A톜ﺞ쎠욢즤覦\uE3A8ﮪ\uEAAC", A_1_1), 300, 550, 275);
                  num2 = (short) 183;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 199:
                  if (!numberA8539UiValue.StartsWith(RptMgrErrorHandler.b("즄", A_1_1)))
                  {
                    this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄늆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜꾞銠ﲢ\uE9A4욦쮨캪솬쪮햰鶲ﾴ\uE7B6ﺸ", A_1_1), 250, 600, 300);
                    num2 = (short) 178;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 212;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 200:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDE8A캌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 149;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 201:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDA8A즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 62;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 245;
                case 202:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("욄\uE886\uE788\uF88A\uE28C\uE38E\uF490\uE792\uE194\uF296래\uF19A\uED9C\uF89E", A_1_1), 250, 600, 300);
                  num2 = (short) 105;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 203:
                  num2 = (short) 200;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 204:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 205:
                  num2 = (short) 141;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 206:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 244;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 236;
                case 207:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE88C\uF78E캐ꂒ쪔\uD996\uF698힚ﲜﶞ쒠쾢认\uEDA6令\uECAA", A_1_1), 300, 550, 275);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3, !Product.IsVertex());
                  num2 = (short) 74;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 208 /*0xD0*/:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 209:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 210:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 211:
                  num2 = (short) 279;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 212:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("욄\uE886\uE788\uF88A\uE28C\uE38E\uF490\uE792\uE194\uF296래\uF19A\uED9C\uF89E", A_1_1), 250, 600, 300);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 213:
                  num2 = (short) 226;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 214:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDC8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 245;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_226;
                case 215:
                  num2 = (short) 45;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 216:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDC8A캌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 168;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_146;
                case 217:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 260, 550, 260);
                  num2 = (short) 294;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 218:
                  num2 = (short) 153;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 219:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("톄\uDF86쒈릊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 96 /*0x60*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 220:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈릊뢌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 63 /*0x3F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 128 /*0x80*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 221:
                  num2 = (short) 181;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 222:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ첒ꞔ좖튘\uF59A\uF29Cﶞﺠ\uEDA2쪤\uEBA6좨즪좬쎮龰\uD9B2어킶", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 70;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 223:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uD88A즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) sbyte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 98;
                case 224 /*0xE0*/:
                  num2 = (short) 159;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 226:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 121;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 227:
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 228:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ쮒킔", A_1_1)))
                  {
                    num2 = (short) 296;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 165;
                case 229:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뾊붌뾎ꆐ\uDF92ﲔ좖ꢘ떚ꢜ삞\uEFA0첢\uE9A4욦쮨캪솬膮ﮰ\uE3B2\uF2B4", A_1_1), 260, 550, 260);
                  num2 = (short) 118;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 230:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 269;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 59;
                case 231:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뾊붌뾎ꆐ쮒\uDD94릖\uF398\uEB9A煮", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 135;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 232:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 248;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 17;
                case 233:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ쮒킔좖힘\uF49A톜ﺞ쎠욢즤覦\uE3A8ﮪ\uEAAC", A_1_1), 300, 550, 275);
                  num2 = (short) 281;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 236:
                  num2 = (short) 256 /*0x0100*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 237:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 156;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 116;
                case 238:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uD88A즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 173;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 168;
                case 239:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ솒\uF094\uF196\uEB98ﺚ\uEE9C\uF79Eﺠ邢瘝\uE9A6욨\uE7AA첬춮풰\uDFB2鮴\uDDB6즸\uDCBA", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 225;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 240 /*0xF0*/:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDE8A캌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 107;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 168;
                case 241:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 205;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 135;
                case 242:
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 243:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ쮒킔", A_1_1)))
                  {
                    num2 = (short) 276;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 233;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 244:
                  num2 = (short) 249;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 245:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ솒\uF094\uF196\uEB98ﺚ\uEE9C\uF79Eﺠ醢瘝\uE9A6욨\uE7AA첬춮풰\uDFB2鮴\uDDB6즸\uDCBA", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 117;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 246:
                  num2 = (short) 251;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 247:
                  num2 = (short) 169;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 248:
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 249:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄떆번\uDE8A캌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 209;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 71;
                case 250:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈릊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 144 /*0x90*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 166;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 251:
                  if (!UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뾊뢌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 134;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 252:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("펄\uE286ﮈﾊ\uE88C\uF78E캐ꆒ쪔\uD996\uF698힚ﲜﶞ쒠쾢认\uEDA6令\uECAA", A_1_1), 300, 550, 275);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3, !Product.IsVertex());
                  num2 = (short) 177;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 253:
                  num2 = (short) 240 /*0xF0*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 254:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄늆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜꾞銠ﲢ鶤銦馨鮪\uF2AC\uE3AE킰톲킴\uDBB6\uDCB8\uDFBA鎼햾뇀꓂", A_1_1), 250, 600, 300);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case (int) byte.MaxValue:
                  num2 = (short) 60;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 256 /*0x0100*/:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 259;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 31 /*0x1F*/;
                case 257:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uD88A즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 245;
                case 258:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ\uDB92추튖", A_1_1)))
                  {
                    num2 = (short) 64 /*0x40*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_386;
                case 259:
                  num2 = (short) 72;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 260:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("횄햆톈릊뾌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 298;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 10;
                case 261:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 267;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 263:
                case 273:
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 59;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 264:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈ꮊ쎌쪎즐잒떔쾖\uDC98", A_1_1)))
                  {
                    num2 = (short) 154;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 116;
                case 265:
                  num2 = (short) 260;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 266:
                  num2 = (short) 188;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 267:
                  num2 = (short) 286;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 268:
                  goto label_398;
                case 269:
                  num2 = (short) 291;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 272:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈풊쎌뢎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 91;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 274:
                  goto label_437;
                case 275:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄늆횈삊\uDD8C슎ꂐ첒ꎔꊖꦘꮚ톜\uF69E辠\uE9A2\uF5A4\uE0A6", A_1_1), 250, 600, 300);
                  num2 = (short) 270;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 276:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ\uDF92ﲔ", A_1_1)))
                  {
                    num2 = (short) 198;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈붊붌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 300, 550, 275);
                  num2 = (short) 110;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 277:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) 78;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 69;
                case 278:
                  num2 = (short) 122;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 279:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뚆번삊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 227;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 71;
                case 280:
                  num2 = (short) 186;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 282:
                  if (UtilityMack.IsAPX1000i)
                  {
                    num2 = (short) 253;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_146;
                case 283:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈삊즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 280;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 239;
                case 284:
                  num2 = (short) 102;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 285:
                  num2 = (short) 184;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 286:
                  if (numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뒆번\uDE8A캌\uDB8Eꢐ쎒슔꾖\uD898햚", A_1_1)))
                  {
                    num2 = (short) 272;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 91;
                case 287:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뾆불삊즌쮎ꢐ쎒슔ꊖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 150;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 120;
                case 288:
                  if (UtilityMack.IsPortable())
                  {
                    num2 = (short) byte.MaxValue;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_226;
                case 289:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈삊즌즎ꢐ쎒슔ꆖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 245;
                case 290:
                  if (!numberA8539UiValue.Equals(RptMgrErrorHandler.b("춄뺆뮈\uDA8A즌잎ꢐ쎒슔ꂖ\uD898햚", A_1_1)))
                  {
                    num2 = (short) 112 /*0x70*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 168;
                case 291:
                  if (UtilityMack.ProductModelId.Equals(RptMgrErrorHandler.b("쒄힆톈뺊붌뾎ꆐ", A_1_1)))
                  {
                    num2 = (short) 224 /*0xE0*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 59;
                case 292:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈벊붌뾎ꆐ붒\uDF94잖\uDE98", A_1_1), 260, 550, 260);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 284;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 293:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뺊붌뾎ꆐ첒\uD894꒖욘햚\uF29C펞삠솢삤쮦螨\uE1AAﶬ\uE8AE", A_1_1), 350, 550, 275);
                  num2 = (short) 273;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 296:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ쮒킔좖힘\uF49A톜ﺞ쎠욢즤覦쎨\uDBAA쪬", A_1_1), 300, 550, 275);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 165;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 297:
                  num2 = (short) 261;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 298:
                  this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("횄햆톈릊뾌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 250, 450, 275);
                  flag = this.a(A_0, empty, A_1_2, A_2, A_3);
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 299:
                  num2 = (short) 32 /*0x20*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 300:
                  num2 = (short) 180;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뾊붌뾎ꆐ첒\uDB94\uF896햘漢ﾜ爵춠趢\uEFA4\uF7A6\uEEA8", A_1_1), 260, 550, 260);
              num2 = (short) 191;
              num1 = (int) (IntPtr) num2;
              continue;
label_26:
              this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쪄떆횈삊\uDD8C슎ꂐ첒\uDE94잖풘ꦚ슜ꮞ钠鎢閤覦\uE3A8ﮪ\uEAAC", A_1_1), 250, 600, 300);
              num2 = (short) 235;
              num1 = (int) (IntPtr) num2;
              continue;
label_78:
              num2 = (short) 93;
              num1 = (int) (IntPtr) num2;
              continue;
label_146:
              num2 = (short) 88;
              num1 = (int) (IntPtr) num2;
              continue;
label_226:
              num2 = (short) 189;
              num1 = (int) (IntPtr) num2;
              continue;
label_250:
              num2 = (short) 34;
              num1 = (int) (IntPtr) num2;
              continue;
label_386:
              num2 = (short) 39;
              num1 = (int) (IntPtr) num2;
              continue;
label_402:
              num2 = (short) 241;
              num1 = (int) (IntPtr) num2;
              continue;
label_434:
              num2 = (short) 43;
              num1 = (int) (IntPtr) num2;
            }
label_280:
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ\uDB92추튖욘햚\uF29C펞삠솢삤쮦螨솪\uDDAC좮", A_1_1), 220, 550, 275);
            return this.a(A_0, empty, A_1_2, A_2, A_3);
label_350:
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈뎊붌뾎ꆐ\uDB92쪔\uD996\uF698힚ﲜﶞ쒠쾢认춦\uD9A8첪", A_1_1), 220, 550, 275);
            return this.a(A_0, empty, A_1_2, A_2, A_3);
label_398:
            this.a(ref empty, ref A_1_2, ref A_2, ref A_3, RptMgrErrorHandler.b("쒄힆톈몊붌뾎ꆐ솒\uF094\uF196\uEB98ﺚ\uEE9C\uF79Eﺠ邢瘝\uE9A6욨\uE7AA첬춮풰\uDFB2鮴\uDDB6즸\uDCBA", A_1_1), 260, 550, 260);
            return this.a(A_0, empty, A_1_2, A_2, A_3);
label_437:
            return flag;
        }
    }
  }

  private void OnDragUpdateStatus(object A_0, MouseEventArgs A_1)
  {
    switch (true)
    {
      case true:
        if (false)
          ;
        if (true)
          ;
        this.UpdateStatusBar();
        break;
      default:
        goto case 1;
    }
  }

  private void GoToPage(object A_0, RoutedEventArgs A_1)
  {
    short num = 19923;
    switch ((short) 19923 == num)
    {
      case true:
        num = (short) 0;
        if (num == (short) 0)
          ;
        num = (short) 1;
        if (num == (short) 0)
          ;
        this.usrInpDia = new InputDialog();
        this.usrInpDia.Show();
        this.usrInpDia.txtUserInput.Focus();
        RoutedCommand routedCommand = new RoutedCommand();
        this.usrInpDia.BtnOk.CommandBindings.Add(new CommandBinding((ICommand) routedCommand, new ExecutedRoutedEventHandler(this.ExecutedCustomCommand), new CanExecuteRoutedEventHandler(this.CanExecuteCustomCommand)));
        this.usrInpDia.BtnOk.Command = (ICommand) routedCommand;
        break;
      default:
        goto case 1;
    }
  }

  private void ExecutedCustomCommand(object A_0, ExecutedRoutedEventArgs A_1)
  {
    short num1 = 11039;
    int num2;
    switch ((short) 11039 == num1 ? 1 : 0)
    {
      case 0:
      case 2:
label_11:
        num1 = (short) 10;
        num2 = (int) (IntPtr) num1;
        break;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            goto label_5;
        }
        break;
    }
    bool flag;
    int pageNumber;
    while (true)
    {
      switch (num2)
      {
        case 0:
          if (pageNumber <= 0)
            break;
          goto label_11;
        case 1:
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          continue;
        case 2:
          num1 = (short) 8;
          num2 = (int) (IntPtr) num1;
          continue;
        case 3:
          if (pageNumber != 0)
          {
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto case 14;
        case 4:
          int num3 = (int) MessageBox.Show(AppResources.Invalid_page_number);
          this.usrInpDia.txtUserInput.Text = "";
          this.usrInpDia.txtUserInput.Focus();
          num1 = (short) 11;
          num2 = (int) (IntPtr) num1;
          continue;
        case 5:
          try
          {
            num1 = (short) 0;
            int num4 = (int) (IntPtr) num1;
            while (true)
            {
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
                  goto label_31;
                case 2:
                  int num5 = (int) MessageBox.Show(AppResources.Value_is_not_a_valid_integer);
                  this.usrInpDia.txtUserInput.Focus();
                  this.usrInpDia.txtUserInput.Text = "";
                  num1 = (short) 1;
                  num4 = (int) (IntPtr) num1;
                  continue;
                case 3:
                  goto label_32;
              }
              if (this.usrInpDia.txtUserInput.Text.Length > int.MaxValue.ToString().Length - 1)
              {
                num1 = (short) 2;
                num4 = (int) (IntPtr) num1;
              }
              else
              {
                pageNumber = int.Parse(this.usrInpDia.txtUserInput.Text);
                num1 = (short) 3;
                num4 = (int) (IntPtr) num1;
              }
            }
label_31:
            return;
          }
          catch (FormatException ex)
          {
            flag = false;
            this.usrInpDia.txtUserInput.Text = "";
            this.usrInpDia.txtUserInput.Focus();
            int num6 = (int) MessageBox.Show(AppResources.Value_is_not_a_valid_integer);
          }
label_32:
          num2 = 13;
          continue;
        case 6:
          if (this.RptViewer.PageCount >= pageNumber)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          break;
        case 7:
          if (pageNumber <= 0)
          {
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_40;
        case 8:
          if (this.RptViewer.PageCount >= pageNumber)
          {
            num1 = (short) 14;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto case 4;
        case 9:
          num1 = (short) 12;
          num2 = (int) (IntPtr) num1;
          continue;
        case 10:
          goto label_36;
        case 11:
          goto label_27;
        case 12:
          if (this.usrInpDia.click)
          {
            num1 = (short) 15;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          break;
        case 13:
          if (flag)
          {
            num1 = (short) 9;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_35;
        case 14:
          num1 = (short) 7;
          num2 = (int) (IntPtr) num1;
          continue;
        case 15:
          num1 = (short) 6;
          num2 = (int) (IntPtr) num1;
          continue;
        default:
          goto label_5;
      }
      num1 = (short) 3;
      num2 = (int) (IntPtr) num1;
      continue;
label_4:;
    }
label_27:
    return;
label_40:
    return;
label_35:
    return;
label_36:
    this.RptViewer.GoToPage(pageNumber);
    this.usrInpDia.txtUserInput.Text = "";
    this.usrInpDia.Hide();
    return;
label_5:
    flag = true;
    pageNumber = 0;
    num1 = (short) 5;
    num2 = (int) (IntPtr) num1;
    goto label_4;
  }

  private void CanExecuteCustomCommand(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 2032;
    int num2 = (int) num1;
    num1 = (short) 2032;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        A_1.CanExecute = true;
        break;
      default:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        if (!(A_1.Source is Control))
        {
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          A_1.CanExecute = false;
          break;
        }
        goto case 0;
    }
  }

  private void OnMenuItemClick(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    int num2 = (int) (IntPtr) num1;
    while (true)
    {
      switch (num2)
      {
        case 0:
          num1 = (short) 20923;
          int num3 = (int) num1;
          num1 = (short) 20923;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num1 = (short) 0;
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
          }
          break;
        case 1:
          if (A_0 == this.MenuItemFilePrint)
          {
            num1 = (short) 4;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          num1 = (short) 3;
          num2 = (int) (IntPtr) num1;
          continue;
        case 2:
          goto label_16;
        case 3:
          if (A_0 == this.MenuItemFileExit)
          {
            num1 = (short) 7;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          goto label_21;
        case 4:
          goto label_8;
        case 5:
          goto label_20;
        case 6:
          if (A_0 != this.MenuItemFileSave)
          {
            num1 = (short) 1;
            num2 = (int) (IntPtr) num1;
            continue;
          }
          num1 = (short) 5;
          num2 = (int) (IntPtr) num1;
          continue;
        case 7:
          goto label_15;
      }
      if (A_0 == this.MenuItemFileOpen)
      {
        num1 = (short) 2;
        num2 = (int) (IntPtr) num1;
      }
      else
      {
        num1 = (short) 6;
        num2 = (int) (IntPtr) num1;
      }
    }
label_8:
    this.d();
    return;
label_15:
    this.Close();
    return;
label_16:
    this.e();
    return;
label_20:
    this.a(false);
    return;
label_21:
    int num5 = (int) MessageBox.Show(AppResources.On_MenuItem_Click_Unsupported_Sender);
  }

  private void e()
  {
    int num1;
    short num2;
    string str;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 0;
        str = this.b();
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (str == null)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_15;
            case 2:
              goto label_7;
            case 3:
              if (!File.Exists(str))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              goto label_5;
            default:
              goto label_2;
          }
label_1:;
        }
label_15:
        break;
label_5:
        try
        {
          this.RptViewer.Document = new XPFContent(Global.contentDir).LoadViewableFixedContent(str);
          this.m = str;
          break;
        }
        catch (Exception ex)
        {
          int num3 = (int) MessageBox.Show(ex.Message);
          break;
        }
label_7:
        num2 = (short) 10560;
        int num4 = (int) num2;
        num2 = (short) 10560;
        int num5 = (int) num2;
        switch (num4 == num5 ? 1 : 0)
        {
          case 0:
          case 2:
            goto label_1;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            int num6 = (int) MessageBox.Show(AppResources.File_Id_not_found + str, this.GetType().Name, MessageBoxButton.OK, MessageBoxImage.Hand);
            return;
        }
    }
  }

  private void a(bool A_0)
  {
    int A_1 = 7;
    int num1;
    string path;
    switch (0)
    {
      case 0:
label_2:
        path = this.a();
        num1 = 0;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (path == null)
              {
                num1 = 1;
                continue;
              }
              num1 = 2;
              continue;
            case 1:
              goto label_47;
            case 2:
              goto label_5;
            default:
              goto label_2;
          }
        }
label_47:
        break;
label_5:
        try
        {
          int num2 = 7;
          while (true)
          {
            short num3;
            switch (num2)
            {
              case 0:
                num3 = (short) 5;
                num2 = (int) (IntPtr) num3;
                continue;
              case 1:
                if (File.Exists(path))
                {
                  num3 = (short) 14;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 10;
              case 2:
                try
                {
                  num3 = (short) 2;
                  int num4 = (int) (IntPtr) num3;
                  while (true)
                  {
                    switch (num4)
                    {
                      case 0:
                        goto label_15;
                      case 1:
                        num3 = (short) 0;
                        num4 = (int) (IntPtr) num3;
                        continue;
                      case 2:
                        num3 = (short) 18398;
                        int num5 = (int) num3;
                        num3 = (short) 18398;
                        int num6 = (int) num3;
                        switch (num5 == num6 ? 1 : 0)
                        {
                          case 0:
                          case 2:
                            break;
                          default:
                            num3 = (short) 0;
                            if (num3 == (short) 0)
                              ;
                            switch (0)
                            {
                              case 0:
                                goto label_27;
                              default:
                                continue;
                            }
                        }
                        break;
                      case 3:
                        File.Delete(path);
                        break;
                      default:
label_27:
                        if (File.Exists(path))
                        {
                          num3 = (short) 3;
                          num4 = (int) (IntPtr) num3;
                          continue;
                        }
                        goto case 1;
                    }
                    num3 = (short) 1;
                    num4 = (int) (IntPtr) num3;
                  }
                }
                catch (Exception ex)
                {
                  int num7 = (int) MessageBox.Show(AppResources.Access_denied, this.Title);
                  return;
                }
label_15:
                XpsDocument xpsDocument = new XpsDocument(path, FileAccess.ReadWrite);
                XpsDocument.CreateXpsDocumentWriter(xpsDocument).Write(this.RptViewer.Document.DocumentPaginator);
                xpsDocument.Close();
                int num8 = (int) MessageBox.Show(AppResources.Saved_successfully, this.Title);
                num3 = (short) 12;
                num2 = (int) (IntPtr) num3;
                continue;
              case 3:
                num3 = (short) 8;
                num2 = (int) (IntPtr) num3;
                continue;
              case 4:
                num3 = (short) 1;
                num2 = (int) (IntPtr) num3;
                continue;
              case 5:
                if (!path.Equals(Global.flowDocPath + RptMgrErrorHandler.b("\uDE89ﺋ\uEB8D\uF58F쒑ﶓ\uF395\uEF97\uDC99\uF09B\uF19D힟\uE6A1쮣얥\uDDA7잩즫삭쒯", A_1) + this.n.ToString() + RptMgrErrorHandler.b("ꒉ\uF48Bﺍ\uE38F", A_1)))
                {
                  num3 = (short) 4;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 9;
              case 6:
                if (path.Equals(Global.flowDocPath + RptMgrErrorHandler.b("\uD889\uED8B\uEA8D憐\uFD91\uDD93\uF895ﺗ\uF599\uDA9B\uF29D쾟햡\uE0A3즥쮧\uDFA9솫쮭\uDEAF욱", A_1) + this.n.ToString() + RptMgrErrorHandler.b("ꒉ\uF48Bﺍ\uE38F", A_1)))
                {
                  num3 = (short) 9;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                break;
              case 7:
                switch (0)
                {
                  case 0:
                    goto label_8;
                  default:
                    continue;
                }
              case 8:
                if (File.Exists(path))
                {
                  num3 = (short) 0;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 4;
              case 9:
                int num9 = (int) MessageBox.Show(AppResources.Save_File_With_Different_Name, this.Title);
                num3 = (short) 13;
                num2 = (int) (IntPtr) num3;
                continue;
              case 10:
                num3 = (short) 15;
                num2 = (int) (IntPtr) num3;
                continue;
              case 11:
                num3 = (short) 6;
                num2 = (int) (IntPtr) num3;
                continue;
              case 12:
              case 13:
                num3 = (short) 17;
                num2 = (int) (IntPtr) num3;
                continue;
              case 14:
                num3 = (short) 16 /*0x10*/;
                num2 = (int) (IntPtr) num3;
                continue;
              case 15:
                if (File.Exists(path))
                {
                  num3 = (short) 11;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                break;
              case 16 /*0x10*/:
                if (!path.Equals(Global.flowDocPath + RptMgrErrorHandler.b("슉\uED8B\uE08D\uF48F\uDD91\uE193\uE295\uDE97\uF699\uF39B\uE99D\uE49F춡잣펥얧쾩슫\uDAAD", A_1) + this.n.ToString() + RptMgrErrorHandler.b("ꒉ\uF48Bﺍ\uE38F", A_1)))
                {
                  num3 = (short) 10;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 9;
              case 17:
                goto label_44;
              default:
label_8:
                if (!this.m.Equals(path))
                {
                  num3 = (short) 3;
                  num2 = (int) (IntPtr) num3;
                  continue;
                }
                goto case 9;
            }
            num3 = (short) 1;
            if (num3 == (short) 0)
              ;
            num3 = (short) 2;
            num2 = (int) (IntPtr) num3;
          }
label_44:
          break;
        }
        catch (Exception ex)
        {
          int num10 = (int) MessageBox.Show(ex.Message);
          break;
        }
    }
  }

  private void d()
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        string path;
        switch (0)
        {
          case 0:
label_5:
            path = this.m;
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            PrintDialog printDialog;
            while (true)
            {
              num2 = (short) 13785;
              int num3 = (int) num2;
              num2 = (short) 13785;
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
                  bool? nullable;
                  bool flag;
                  switch (num1)
                  {
                    case 0:
                    case 4:
                      num2 = (short) 1;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      if (path != null)
                      {
                        printDialog = new PrintDialog();
                        printDialog.PageRangeSelection = PageRangeSelection.AllPages;
                        printDialog.UserPageRangeEnabled = true;
                        nullable = printDialog.ShowDialog();
                        flag = true;
                        num2 = (short) 7;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      path = this.m;
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 3:
                      goto label_13;
                    case 5:
                      if (this.m != "")
                      {
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      path = Global.usrReportsDirectory.ToString() + this.c();
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      goto label_19;
                    case 7:
                      if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
                      {
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_20;
                    default:
                      goto label_5;
                  }
              }
            }
label_19:
            return;
label_13:
            try
            {
              FixedDocumentSequence documentSequence = new XpsDocument(path, FileAccess.Read).GetFixedDocumentSequence();
              printDialog.PrintDocument(documentSequence.DocumentPaginator, this.j.Uri.UserInfo);
            }
            catch (Exception ex)
            {
              int num5 = (int) MessageBox.Show(ex.Message);
            }
label_20:
            return;
        }
    }
  }

  private string c()
  {
    int A_1 = 14;
    short num1 = -16748;
    int num2 = (int) num1;
    num1 = (short) -16748;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        if (false)
          ;
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        string str = this.j.Uri.AbsolutePath.ToString();
        return str.Remove(0, str.IndexOf(RptMgrErrorHandler.b("쎐\uF692\uE594\uF896\uEB98\uEF9A\uEE9C낞", A_1)) + 8);
      default:
        goto case 1;
    }
  }

  private string b()
  {
    OpenFileDialog openFileDialog = new OpenFileDialog();
    openFileDialog.Filter = AppResources.XPS_Document_files_Filter;
    openFileDialog.FilterIndex = 1;
    bool? nullable = openFileDialog.ShowDialog();
    bool flag = true;
    if (!(nullable.GetValueOrDefault() == flag & nullable.HasValue))
      goto label_2;
label_1:
    return openFileDialog.FileName;
label_2:
    short num = 16507;
    switch ((short) 16507 == num ? 1 : 0)
    {
      case 0:
      case 2:
        goto label_1;
      case 1:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        return (string) null;
      default:
        num = (short) 0;
        goto case 1;
    }
  }

  private string a()
  {
    int A_1 = 15;
    int num1;
    SaveFileDialog saveFileDialog;
    bool? nullable;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = AppResources.XPS_Document_files_Filter;
        saveFileDialog.FilterIndex = 1;
        nullable = saveFileDialog.ShowDialog();
        flag = true;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (!saveFileDialog.FileName.EndsWith(RptMgrErrorHandler.b("벑\uEC93\uE695\uEB97", A_1), true, (CultureInfo) null))
              {
                num2 = (short) 3;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_8;
            case 1:
              goto label_8;
            case 2:
              if (nullable.GetValueOrDefault() == flag & nullable.HasValue)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_13;
            case 3:
              saveFileDialog.FileName += RptMgrErrorHandler.b("벑\uEC93\uE695\uEB97", A_1);
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              num2 = (short) 0;
              num2 = (short) -12681;
              int num3 = (int) num2;
              num2 = (short) -12681;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_8;
                default:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_8:
        return saveFileDialog.FileName;
label_13:
        return (string) null;
    }
  }

  private void Window_Loaded(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -19035;
    int num2 = (int) num1;
    num1 = (short) -19035;
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
        this.Dispatcher.UnhandledException += new DispatcherUnhandledExceptionEventHandler(this.Dispatcher_UnhandledException);
        break;
      default:
        goto case 1;
    }
  }

  private void Dispatcher_UnhandledException(object A_0, DispatcherUnhandledExceptionEventArgs A_1)
  {
    int num1 = 2;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
        case 1:
          num2 = (short) 16377;
          int num3 = (int) num2;
          num2 = (short) 16377;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_7;
            default:
              goto label_9;
          }
        case 2:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 3:
label_7:
          int num5 = (int) MessageBox.Show(AppResources.System_Printing_PrintSystemException + A_1.Exception.Message);
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (A_1.Exception.GetType() == typeof (PrintSystemException))
      {
        num2 = (short) 3;
        num1 = (int) (IntPtr) num2;
      }
      else
      {
        num2 = (short) 0;
        int num6 = (int) MessageBox.Show(A_1.Exception.Message);
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
    }
label_9:
    num2 = (short) 0;
    if (num2 == (short) 0)
      ;
    A_1.Handled = true;
  }

  private void Window_Closing(object A_0, CancelEventArgs A_1)
  {
    short num1;
    int num2;
    switch (0)
    {
      case 0:
label_5:
        this.Dispatcher.UnhandledException -= new DispatcherUnhandledExceptionEventHandler(this.Dispatcher_UnhandledException);
        num1 = (short) 1;
        num2 = (int) (IntPtr) num1;
        goto default;
      default:
        while (true)
        {
          num1 = (short) -22475;
          int num3 = (int) num1;
          num1 = (short) -22475;
          int num4 = (int) num1;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
label_8:
              FileAttributes attributes = File.GetAttributes(Global.XMLFileName);
              File.SetAttributes(Global.XMLFileName, attributes & ~FileAttributes.ReadOnly);
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
              num1 = (short) 1;
              if (num1 == (short) 0)
                ;
              num1 = (short) 0;
              if (num1 == (short) 0)
                ;
              switch (num2)
              {
                case 0:
                  goto label_9;
                case 1:
                  if (File.Exists(Global.XMLFileName))
                  {
                    num1 = (short) 2;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  }
                  goto label_9;
                case 2:
                  goto label_8;
                default:
                  goto label_5;
              }
          }
        }
label_9:
        num1 = (short) 0;
        break;
    }
  }

  private void CustomLastPage_CommandBinding_Executed(object A_0, ExecutedRoutedEventArgs A_1)
  {
    short num1 = -27672;
    int num2 = (int) num1;
    num1 = (short) -27672;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        this.RptViewer.GoToPage(this.RptViewer.PageCount);
        break;
      default:
        goto case 1;
    }
  }

  private void CustomLastPage_CommandBinding_CanExecute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 26112;
    int num2 = (int) num1;
    num1 = (short) 26112;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        A_1.CanExecute = this.RptViewer.PageCount >= this.RptViewer.MasterPageNumber + this.RptViewer.MaxPagesAcross;
        break;
      default:
        goto case 1;
    }
  }

  private void CustomNextPage_CommandBinding_Executed(object A_0, ExecutedRoutedEventArgs A_1)
  {
    short num1 = -12019;
    int num2 = (int) num1;
    num1 = (short) -12019;
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
        this.RptViewer.GoToPage(this.RptViewer.MasterPageNumber + this.RptViewer.MaxPagesAcross);
        break;
      default:
        goto case 1;
    }
  }

  private void CustomNextPage_CommandBinding_CanExecute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = -1020;
    int num2 = (int) num1;
    num1 = (short) -1020;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        A_1.CanExecute = this.RptViewer.PageCount >= this.RptViewer.MasterPageNumber + this.RptViewer.MaxPagesAcross;
        break;
      default:
        goto case 1;
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 0;
    if (this.p)
      return;
    short num1 = -12183;
    int num2 = (int) num1;
    num1 = (short) -12183;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
        break;
      case 1:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        this.p = true;
        Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("겂횄\uF786\uEC88\uE88A\uE48C\uEE8E\uFD90햒\uF094\uF696\uED98\uEE9A\uEF9C爵튠颢욤좦쒨\uDBAA슬솮풰\uDDB2솴颶\uD8B8\uD8BA춼춾꓀돂\uAAC4뗆뷈ꛊ곌ꇎ냐듒냔ꗖ뗘닚뿜\uF0DE鏠蛢闤裦鯨\u9FEA鯬蛮铰蓲郴藶ퟸ菺鳼鋾洀", A_1), UriKind.Relative));
        break;
      case 2:
        break;
      default:
        num1 = (short) 0;
        goto case 1;
    }
  }

  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      num2 = (short) 29148;
      int num3 = (int) num2;
      num2 = (short) 29148;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
label_5:
          switch (connectionId)
          {
            case 1:
              goto label_11;
            case 2:
              goto label_21;
            case 3:
              goto label_9;
            case 4:
              goto label_15;
            case 5:
              goto label_22;
            case 6:
              goto label_19;
            case 7:
              goto label_23;
            case 8:
              goto label_14;
            case 9:
              goto label_8;
            case 10:
              goto label_25;
            case 11:
              goto label_12;
            case 12:
              goto label_7;
            case 13:
              goto label_24;
            case 14:
              goto label_16;
            case 15:
              goto label_10;
            case 16 /*0x10*/:
              goto label_13;
            case 17:
              goto label_17;
            default:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        default:
          num2 = (short) 0;
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              goto label_26;
            case 1:
              switch (0)
              {
                case 0:
                  goto label_5;
                default:
                  continue;
              }
            case 2:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              goto label_5;
          }
      }
    }
label_7:
    this.menuViewDecreaseZoom = (MenuItem) target;
    return;
label_8:
    this.MenuItemFileExit = (MenuItem) target;
    this.MenuItemFileExit.Click += new RoutedEventHandler(this.OnMenuItemClick);
    return;
label_9:
    this.RptViewer = (DocumentViewer) target;
    this.RptViewer.MouseMove += new MouseEventHandler(this.OnDragUpdateStatus);
    return;
label_10:
    ((MenuItem) target).Click += new RoutedEventHandler(this.GoToPage);
    return;
label_11:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.Window_Loaded);
    ((Window) target).Closing += new CancelEventHandler(this.Window_Closing);
    return;
label_12:
    this.menuViewIncreaseZoom = (MenuItem) target;
    return;
label_13:
    this.ribbonBarHelpButton = (ButtonDropDown) target;
    this.ribbonBarHelpButton.Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_14:
    this.MenuItemFilePrint = (MenuItem) target;
    this.MenuItemFilePrint.Click += new RoutedEventHandler(this.OnMenuItemClick);
    return;
label_15:
    this.mnuMenu = (Menu) target;
    return;
label_16:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.CustomLastPage_CommandBinding_Executed);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.CustomLastPage_CommandBinding_CanExecute);
    return;
label_17:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    this.stsbtmBar = (StatusBar) target;
    return;
label_19:
    this.MenuItemFileOpen = (MenuItem) target;
    this.MenuItemFileOpen.Click += new RoutedEventHandler(this.OnMenuItemClick);
    return;
label_21:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_22:
    this.MenuItemFile = (MenuItem) target;
    return;
label_23:
    this.MenuItemFileSave = (MenuItem) target;
    this.MenuItemFileSave.Click += new RoutedEventHandler(this.OnMenuItemClick);
    return;
label_24:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.CustomNextPage_CommandBinding_Executed);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.CustomNextPage_CommandBinding_CanExecute);
    return;
label_25:
    this.MenuItemView = (MenuItem) target;
    return;
label_26:
    this.p = true;
  }

  static ReportViewer()
  {
    short num1 = -30048;
    int num2 = (int) num1;
    num1 = (short) -30048;
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
        ReportViewer.CustomLastPage = new RoutedCommand();
        ReportViewer.CustomNextPage = new RoutedCommand();
        break;
      default:
        goto case 1;
    }
  }
}
