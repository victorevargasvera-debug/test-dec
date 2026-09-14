// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpIuiPage
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonLib.FindResult;
using AcpCommonLib.StatusMessage;
using AcpCommonResources;
using AcpUI.Common;
using AcpUILib;
using DevComponents.WpfDock;
using DevComponents.WpfDock.themes;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;

#nullable disable
namespace AcpUI;

public class AcpIuiPage : Page, IComponentConnector
{
  private Dictionary<string, HelpMapData> helpMap;
  private string helpMapPath = ACPBrowser.Utility.HelpRootDir + "ext\\map.xml";
  private bool dwClosing;
  private IEnumerable<StatusMessageInfo> lastOutputList;
  private IEnumerable<FieldsReportInfo> lastInvalidList;
  private IEnumerable<FieldsReportInfo> lastDNDList;
  private IEnumerable<FieldsReportInfo> lastImportExportList;
  private IEnumerable<FieldsReportInfo> lastCompareList;
  private IEnumerable<FindResultInfo> lastFindList;
  private IEnumerable<FieldsReportInfo> lastFillUpDownList;
  private PageOutputMessage msgPage;
  private PageFieldsReport fldRptPage;
  private PageReportSystemKeys sysKeyPage;
  internal System.Windows.Controls.Frame StatusBarFrame;
  internal DockSite AppDock;
  internal SplitPanel NavPanel;
  internal DockWindowGroup NavPanelGrp;
  internal AcpDockWindow NavWindowDockWnd;
  internal System.Windows.Controls.Frame FrameLeft;
  internal SplitPanel TaskPanel;
  internal DockWindowGroup TaskPanelGrp;
  internal AcpDockWindow TaskWindowDockWnd;
  internal System.Windows.Controls.Frame FrameRight;
  internal ContextHelp browser;
  internal DockSite CenterDock;
  internal SplitPanel EventPanel;
  internal DockWindowGroup EventPanelGrp;
  internal AcpDockWindow OutputDockWnd;
  internal System.Windows.Controls.Frame FrameOutput;
  internal AcpDockWindow InvalidFieldsDockWnd;
  internal System.Windows.Controls.Frame FrameInvalidFields;
  internal AcpDockWindow DnDDockWnd;
  internal System.Windows.Controls.Frame FrameDnD;
  internal AcpDockWindow ImpExpDockWnd;
  internal System.Windows.Controls.Frame FrameImpExp;
  internal AcpDockWindow ComparatorDockWnd;
  internal System.Windows.Controls.Frame FrameComparator;
  internal AcpDockWindow FillUpFillDownDockWnd;
  internal System.Windows.Controls.Frame FrameFillUpFillDown;
  internal AcpDockWindow FindResultsDockWnd;
  internal System.Windows.Controls.Frame FrameFindResults;
  internal AcpDockWindow SysKeyReportWnd;
  internal System.Windows.Controls.Frame FrameSysKeyReport;
  internal System.Windows.Controls.Frame FrameCenterTop;
  private bool _contentLoaded;

  public System.Windows.Controls.Frame GetFrameLeft => this.FrameLeft;

  public System.Windows.Controls.Frame GetFrameCenterTop => this.FrameCenterTop;

  public System.Windows.Controls.Frame GetFrameRight => this.FrameRight;

  public System.Windows.Controls.Frame GetFrameOutput => this.FrameOutput;

  public System.Windows.Controls.Frame GetFrameInvalidFields => this.FrameInvalidFields;

  public System.Windows.Controls.Frame GetFrameImpExp => this.FrameImpExp;

  public System.Windows.Controls.Frame GetFrameDnD => this.FrameDnD;

  public System.Windows.Controls.Frame GetFrameComparator => this.FrameComparator;

  public System.Windows.Controls.Frame GetFrameFindResults => this.FrameFindResults;

  public System.Windows.Controls.Frame GetStatusBar => this.StatusBarFrame;

  public void InitDockWindowState(DockWndType dwType, bool bVisible, bool bAutoRise)
  {
    DockWindow dockWindow = this.GetDockWindow(dwType);
    if (dockWindow == null)
      return;
    if (!bVisible)
    {
      dockWindow.Visibility = Visibility.Collapsed;
      if (dwType == DockWndType.Naviagtion)
        dockWindow.IsAutoHide = true;
      AcpUI.Common.Utility.DockWindowVisibilityChanged((object) dockWindow, false);
    }
    else
    {
      dockWindow.Visibility = Visibility.Visible;
      AcpUI.Common.Utility.DockWindowVisibilityChanged((object) dockWindow, true);
    }
    ((AcpDockWindow) dockWindow).IsAutoRiseEnabled = bAutoRise;
    AcpUI.Common.Utility.DockWindowAutoRiseChanged((object) dockWindow, bAutoRise);
  }

  public void GetDockWindowState(
    DockWndType dwType,
    out bool bVisibile,
    out bool bAutoRise,
    out bool bAutoHide)
  {
    bVisibile = true;
    bAutoRise = true;
    bAutoHide = true;
    DockWindow dockWindow = this.GetDockWindow(dwType);
    if (dockWindow == null)
      return;
    switch (dockWindow.Visibility)
    {
      case Visibility.Visible:
        bVisibile = true;
        break;
      case Visibility.Hidden:
      case Visibility.Collapsed:
        bVisibile = false;
        break;
    }
    bAutoRise = ((AcpDockWindow) dockWindow).IsAutoRiseEnabled;
    bAutoHide = dockWindow.IsAutoHide;
  }

  public void PopupDockWindow(DockWndType dwType)
  {
    DockWindow dockWindow = this.GetDockWindow(dwType);
    if (dockWindow.Visibility == Visibility.Visible)
    {
      dockWindow.IsAutoHide = false;
    }
    else
    {
      this.OpenDockWindow(dwType);
      dockWindow.IsAutoHide = false;
    }
  }

  public bool IsDockWindowAutoHide(DockWndType dwType) => this.GetDockWindow(dwType).IsAutoHide;

  public void SetDockWindowAutoRise(DockWndType dwType, bool IsAutoRiseOn)
  {
    DockWindow dockWindow;
    ((AcpDockWindow) (dockWindow = this.GetDockWindow(dwType))).IsAutoRiseEnabled = IsAutoRiseOn;
    int num = IsAutoRiseOn ? 1 : 0;
    AcpUI.Common.Utility.DockWindowAutoRiseChanged((object) dockWindow, num != 0);
  }

  private void StartDockWindowAnimation(DockWindow dw)
  {
    if (dw == null || dw.Image == null || !(dw.Image is Image))
      return;
    Image image = (Image) dw.Image;
    DoubleAnimation doubleAnimation = new DoubleAnimation();
    doubleAnimation.From = new double?(1.0);
    doubleAnimation.To = new double?(0.2);
    Duration duration = new Duration(TimeSpan.FromSeconds(0.3));
    doubleAnimation.Duration = duration;
    doubleAnimation.AutoReverse = true;
    RepeatBehavior repeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(5.0));
    doubleAnimation.RepeatBehavior = repeatBehavior;
    doubleAnimation.FillBehavior = FillBehavior.Stop;
    DependencyProperty opacityProperty = UIElement.OpacityProperty;
    DoubleAnimation animation = doubleAnimation;
    image.BeginAnimation(opacityProperty, (AnimationTimeline) animation, HandoffBehavior.SnapshotAndReplace);
    dw.AttentionRequired = true;
  }

  private void StopDockWindowAnimation(DockWindow dw)
  {
    if (dw == null || dw.Image == null || !(dw.Image is Image))
      return;
    Image image = (Image) dw.Image;
    if (!image.HasAnimatedProperties)
      return;
    image.BeginAnimation(UIElement.OpacityProperty, (AnimationTimeline) null);
    dw.AttentionRequired = false;
  }

  public void OpenDockWindow(DockWndType dwType)
  {
    DockWindow dockWindow = this.GetDockWindow(dwType);
    if (dockWindow == null)
      return;
    this.PopulateDockWindow(dockWindow);
    if (dockWindow.Visibility != Visibility.Visible)
      dockWindow.IsAutoHide = false;
    bool flag = false;
    if (!dockWindow.IsAutoHide)
    {
      dockWindow.Open();
      dockWindow.IsSelected = true;
      flag = true;
    }
    else if (((AcpDockWindow) dockWindow).IsAutoRiseEnabled)
    {
      ((AcpDockWindow) dockWindow).StartTimer(5000);
      dockWindow.AutoHideOpen = true;
      flag = true;
    }
    else
      this.StartDockWindowAnimation(dockWindow);
    if (!flag)
      return;
    RoutedEventArgs e = new RoutedEventArgs(DockWindow.AutoHideChangedEvent, (object) dockWindow);
    this.AutoHideChanged((object) dockWindow, e);
    AcpUI.Common.Utility.DockWindowVisibilityChanged((object) dockWindow, true);
  }

  public void CloseDockWindow(DockWndType dwType) => this.GetDockWindow(dwType)?.Close();

  public DockWindow GetDockWindow(DockWndType dwType)
  {
    DockWindow dockWindow = (DockWindow) null;
    switch (dwType)
    {
      case DockWndType.Naviagtion:
        dockWindow = (DockWindow) this.NavWindowDockWnd;
        break;
      case DockWndType.Output:
        dockWindow = (DockWindow) this.OutputDockWnd;
        break;
      case DockWndType.InvalidFields:
        dockWindow = (DockWindow) this.InvalidFieldsDockWnd;
        break;
      case DockWndType.ImpExp:
        dockWindow = (DockWindow) this.ImpExpDockWnd;
        break;
      case DockWndType.DnD:
        dockWindow = (DockWindow) this.DnDDockWnd;
        break;
      case DockWndType.FillUpFillDown:
        dockWindow = (DockWindow) this.FillUpFillDownDockWnd;
        break;
      case DockWndType.Comparator:
        dockWindow = (DockWindow) this.ComparatorDockWnd;
        break;
      case DockWndType.FindResults:
        dockWindow = (DockWindow) this.FindResultsDockWnd;
        break;
      case DockWndType.SysKeyRpt:
        dockWindow = (DockWindow) this.SysKeyReportWnd;
        break;
      case DockWndType.HelpInfo:
        dockWindow = (DockWindow) this.TaskWindowDockWnd;
        break;
    }
    return dockWindow;
  }

  private void DockWindowActivated(object sender, RoutedEventArgs e)
  {
    DockWindow originalSource = e.OriginalSource as DockWindow;
    this.PopulateDockWindow(originalSource);
    this.StopDockWindowAnimation(originalSource);
    originalSource.AttentionRequired = false;
  }

  private void DockWindowDeactivated(object sender, RoutedEventArgs e)
  {
    object originalSource = e.OriginalSource;
  }

  private void DockWindowClosing(object sender, CancelSourceRoutedEventArgs e)
  {
    object originalSource = e.OriginalSource;
    this.dwClosing = true;
  }

  private void DockWindowClosed(object sender, RoutedEventArgs e)
  {
    DockWindow originalSource = e.OriginalSource as DockWindow;
    AcpUI.Common.Utility.DockWindowVisibilityChanged((object) originalSource, false);
    this.ClearDockWindowContent(originalSource);
    this.dwClosing = false;
  }

  private void ClearDockWindowContent(DockWindow dw)
  {
    string name = dw.Name;
    if (name == null)
      return;
    switch (name.Length)
    {
      case 10:
        if (!(name == "DnDDockWnd"))
          break;
        this.FrameDnD.Content = (object) null;
        break;
      case 13:
        switch (name[0])
        {
          case 'I':
            if (!(name == "ImpExpDockWnd"))
              return;
            this.FrameImpExp.Content = (object) null;
            return;
          case 'O':
            if (!(name == "OutputDockWnd"))
              return;
            this.FrameOutput.Content = (object) null;
            return;
          default:
            return;
        }
      case 15:
        if (!(name == "SysKeyReportWnd"))
          break;
        this.FrameSysKeyReport.Content = (object) null;
        break;
      case 16 /*0x10*/:
        int num1 = name == "NavWindowDockWnd" ? 1 : 0;
        break;
      case 17:
        switch (name[0])
        {
          case 'C':
            if (!(name == "ComparatorDockWnd"))
              return;
            this.FrameComparator.Content = (object) null;
            return;
          case 'T':
            int num2 = name == "TaskWindowDockWnd" ? 1 : 0;
            return;
          default:
            return;
        }
      case 18:
        if (!(name == "FindResultsDockWnd"))
          break;
        this.FrameFindResults.Content = (object) null;
        break;
      case 20:
        if (!(name == "InvalidFieldsDockWnd"))
          break;
        this.FrameInvalidFields.Content = (object) null;
        break;
      case 21:
        if (!(name == "FillUpFillDownDockWnd"))
          break;
        this.FrameFillUpFillDown.Content = (object) null;
        break;
    }
  }

  private void AutoHideChanged(object sender, RoutedEventArgs e)
  {
    if (!(e.OriginalSource is DockWindow originalSource) || this.dwClosing)
      return;
    if (!originalSource.IsAutoHide)
    {
      DockSite dockSite = originalSource.GetDockSite();
      AutoHidePanel autoHidePanel = dockSite.GetAutoHidePanel(dockSite.GetDockFromDockWindow(originalSource));
      int num = autoHidePanel.Items.Count - 1;
      while (num > -1 && autoHidePanel.Items.Count > num)
      {
        object obj = autoHidePanel.Items[num--];
        if (obj is DockWindow)
        {
          DockWindow dockWindow = (DockWindow) obj;
          if (dockWindow.Visibility == Visibility.Visible)
            dockWindow.IsAutoHide = originalSource.IsAutoHide;
        }
      }
    }
    else
    {
      DockWindowGroup previousGroup = originalSource.PreviousGroup;
      if (previousGroup != null)
      {
        int num = previousGroup.Items.Count - 1;
        while (num > -1 && previousGroup.Items.Count > num)
        {
          object obj = previousGroup.Items[num--];
          if (obj is DockWindow)
          {
            DockWindow dockWindow = (DockWindow) obj;
            if (dockWindow.Visibility == Visibility.Visible)
              dockWindow.IsAutoHide = originalSource.IsAutoHide;
          }
        }
      }
    }
    originalSource.IsSelected = true;
  }

  private void PopulateDockWindow(DockWindow wnd)
  {
    if (wnd == null)
      return;
    string name = wnd.Name;
    switch (name)
    {
      case "OutputDockWnd":
        if (this.msgPage == null)
          this.msgPage = new PageOutputMessage();
        if (AppInfoManager.StatusMsgReport != null && AppInfoManager.StatusMsgReport.HasMsgs && this.msgPage != null)
        {
          if (!this.IsSameStatusMessageInfoList(this.lastOutputList, AppInfoManager.StatusMsgReport.Messages) || this.msgPage.DataContext == null)
          {
            this.msgPage.DataContext = (object) AppInfoManager.StatusMsgReport.Messages;
            this.lastOutputList = (IEnumerable<StatusMessageInfo>) new List<StatusMessageInfo>(AppInfoManager.StatusMsgReport.Messages);
          }
        }
        else
        {
          this.msgPage.DataContext = (object) null;
          this.lastOutputList = (IEnumerable<StatusMessageInfo>) null;
        }
        this.FrameOutput.Content = (object) this.msgPage;
        break;
      case "InvalidFieldsDockWnd":
        PageInvalidFieldsReport invalidFieldsReport;
        if (this.FrameInvalidFields.Content == null)
        {
          invalidFieldsReport = new PageInvalidFieldsReport();
          invalidFieldsReport.Title = AcpResources.Invalid_Fields;
          invalidFieldsReport.FieldsReportGVC4.Header = (object) AcpResources.Invalid_Fields_Result;
        }
        else
        {
          if (!(this.FrameInvalidFields.Content is PageInvalidFieldsReport))
            return;
          invalidFieldsReport = (PageInvalidFieldsReport) this.FrameInvalidFields.Content;
        }
        if (AppInfoManager.InvalidFieldsReport != null && AppInfoManager.InvalidFieldsReport.UiHasFields && invalidFieldsReport != null)
        {
          if (!this.IsSameFieldsReportInfoList(this.lastInvalidList, AppInfoManager.InvalidFieldsReport.UiFields) || invalidFieldsReport.DataContext == null)
          {
            invalidFieldsReport.DataContext = (object) AppInfoManager.InvalidFieldsReport.UiFields;
            this.lastInvalidList = (IEnumerable<FieldsReportInfo>) new List<FieldsReportInfo>(AppInfoManager.InvalidFieldsReport.UiFields);
          }
        }
        else
        {
          invalidFieldsReport.DataContext = (object) null;
          this.lastInvalidList = (IEnumerable<FieldsReportInfo>) null;
        }
        this.FrameInvalidFields.Content = (object) invalidFieldsReport;
        break;
      case "DnDDockWnd":
        PageFieldsReport pageFieldsReport1;
        if (this.FrameDnD.Content == null)
        {
          pageFieldsReport1 = new PageFieldsReport();
          pageFieldsReport1.Title = AcpResources.Drag_and_Drop_Report;
          pageFieldsReport1.FieldsReportGVC4.Header = (object) AcpResources.Drag_and_Drop_Result;
        }
        else
        {
          if (!(this.FrameDnD.Content is PageFieldsReport))
            return;
          pageFieldsReport1 = (PageFieldsReport) this.FrameDnD.Content;
        }
        if (AppInfoManager.DragAndDropFieldsReport != null && AppInfoManager.DragAndDropFieldsReport.HasFields && pageFieldsReport1 != null)
        {
          if (!this.IsSameFieldsReportInfoList(this.lastDNDList, AppInfoManager.DragAndDropFieldsReport.Fields) || pageFieldsReport1.DataContext == null)
          {
            pageFieldsReport1.DataContext = (object) AppInfoManager.DragAndDropFieldsReport.Fields;
            this.lastDNDList = (IEnumerable<FieldsReportInfo>) new List<FieldsReportInfo>(AppInfoManager.DragAndDropFieldsReport.Fields);
          }
        }
        else
        {
          pageFieldsReport1.DataContext = (object) null;
          this.lastDNDList = (IEnumerable<FieldsReportInfo>) null;
        }
        this.FrameDnD.Content = (object) pageFieldsReport1;
        break;
      case "ImpExpDockWnd":
        PageFieldsReport pageFieldsReport2;
        if (this.FrameImpExp.Content == null)
        {
          pageFieldsReport2 = new PageFieldsReport();
          pageFieldsReport2.Title = AcpResources.Import_Export_Report;
          pageFieldsReport2.FieldsReportGVC4.Header = (object) AcpResources.Import_Export_Result;
        }
        else
        {
          if (!(this.FrameImpExp.Content is PageFieldsReport))
            return;
          pageFieldsReport2 = (PageFieldsReport) this.FrameImpExp.Content;
        }
        if (AppInfoManager.ImportExportFieldsReport != null && AppInfoManager.ImportExportFieldsReport.HasFields && pageFieldsReport2 != null)
        {
          if (!this.IsSameFieldsReportInfoList(this.lastImportExportList, AppInfoManager.ImportExportFieldsReport.Fields) || pageFieldsReport2.DataContext == null)
          {
            pageFieldsReport2.DataContext = (object) AppInfoManager.ImportExportFieldsReport.Fields;
            this.lastImportExportList = (IEnumerable<FieldsReportInfo>) new List<FieldsReportInfo>(AppInfoManager.ImportExportFieldsReport.Fields);
          }
        }
        else
        {
          pageFieldsReport2.DataContext = (object) null;
          this.lastImportExportList = (IEnumerable<FieldsReportInfo>) null;
        }
        this.FrameImpExp.Content = (object) pageFieldsReport2;
        break;
      case "ComparatorDockWnd":
        PageFieldsReport pageFieldsReport3;
        if (this.FrameComparator.Content == null)
        {
          pageFieldsReport3 = new PageFieldsReport();
          pageFieldsReport3.Title = AcpResources.Comparator_Report;
          pageFieldsReport3.FieldsReportGVC4.Header = (object) AcpResources.Comparator_Result;
        }
        else
        {
          if (!(this.FrameComparator.Content is PageFieldsReport))
            return;
          pageFieldsReport3 = (PageFieldsReport) this.FrameComparator.Content;
        }
        if (AppInfoManager.ComparatorFieldsReport != null && AppInfoManager.ComparatorFieldsReport.HasFields && pageFieldsReport3 != null)
        {
          if (!this.IsSameFieldsReportInfoList(this.lastCompareList, AppInfoManager.ComparatorFieldsReport.Fields) || pageFieldsReport3.DataContext == null)
          {
            pageFieldsReport3.DataContext = (object) AppInfoManager.ComparatorFieldsReport.Fields;
            this.lastCompareList = (IEnumerable<FieldsReportInfo>) new List<FieldsReportInfo>(AppInfoManager.ComparatorFieldsReport.Fields);
          }
        }
        else
        {
          pageFieldsReport3.DataContext = (object) null;
          this.lastCompareList = (IEnumerable<FieldsReportInfo>) null;
        }
        this.FrameComparator.Content = (object) pageFieldsReport3;
        break;
      case "FindResultsDockWnd":
        PageFindResults pageFindResults;
        if (this.FrameFindResults.Content == null)
        {
          pageFindResults = new PageFindResults();
          pageFindResults.Title = "Find Results";
        }
        else
        {
          if (!(this.FrameFindResults.Content is PageFindResults))
            return;
          pageFindResults = (PageFindResults) this.FrameFindResults.Content;
        }
        if (AppInfoManager.FindResultReport != null && AppInfoManager.FindResultReport.HasResults && pageFindResults != null)
        {
          if (!this.IsSameFindResultInfoList(this.lastFindList, AppInfoManager.FindResultReport.Results) || pageFindResults.DataContext == null)
          {
            pageFindResults.DataContext = (object) AppInfoManager.FindResultReport.Results;
            this.lastFindList = (IEnumerable<FindResultInfo>) new List<FindResultInfo>(AppInfoManager.FindResultReport.Results);
          }
        }
        else
        {
          pageFindResults.DataContext = (object) null;
          this.lastFindList = (IEnumerable<FindResultInfo>) null;
        }
        this.FrameFindResults.Content = (object) pageFindResults;
        break;
      case "SysKeyReportWnd":
        if (this.sysKeyPage == null)
          this.sysKeyPage = new PageReportSystemKeys();
        this.FrameSysKeyReport.Navigate((object) this.sysKeyPage);
        break;
      case "FillUpFillDownDockWnd":
        if (this.fldRptPage == null)
        {
          this.fldRptPage = new PageFieldsReport();
          this.fldRptPage.Title = AcpResources.Fill_Up_Fill_Down_Report;
          this.fldRptPage.FieldsReportGVC4.Header = (object) AcpResources.Fill_Up_Fill_Down_Result;
        }
        if (AppInfoManager.FillUpFillDownFieldsReport != null && AppInfoManager.FillUpFillDownFieldsReport.HasFields && this.fldRptPage != null)
        {
          if (!this.IsSameFieldsReportInfoList(this.lastFillUpDownList, AppInfoManager.FillUpFillDownFieldsReport.Fields) || this.fldRptPage.DataContext == null)
          {
            this.fldRptPage.DataContext = (object) AppInfoManager.FillUpFillDownFieldsReport.Fields;
            this.lastFillUpDownList = (IEnumerable<FieldsReportInfo>) new List<FieldsReportInfo>(AppInfoManager.FillUpFillDownFieldsReport.Fields);
          }
        }
        else
        {
          this.fldRptPage.DataContext = (object) null;
          this.lastFillUpDownList = (IEnumerable<FieldsReportInfo>) null;
        }
        this.FrameFillUpFillDown.Content = (object) this.fldRptPage;
        break;
      default:
        int num = name == "TaskWindowDockWnd" ? 1 : 0;
        break;
    }
    try
    {
      wnd.UpdateLayout();
    }
    catch (InvalidOperationException ex)
    {
    }
  }

  public bool IsSameStatusMessageInfoList(
    IEnumerable<StatusMessageInfo> lastList,
    IEnumerable<StatusMessageInfo> UIFields)
  {
    try
    {
      if (lastList != null)
      {
        if (UIFields != null)
        {
          List<StatusMessageInfo> statusMessageInfoList1 = new List<StatusMessageInfo>(lastList);
          List<StatusMessageInfo> statusMessageInfoList2 = new List<StatusMessageInfo>(UIFields);
          bool flag = true;
          if (statusMessageInfoList1.Count == statusMessageInfoList2.Count)
          {
            foreach (StatusMessageInfo statusMessageInfo in statusMessageInfoList1)
            {
              StatusMessageInfo reportInOld = statusMessageInfo;
              if (statusMessageInfoList2.Find((Predicate<StatusMessageInfo>) (x => x.ImageLink == reportInOld.ImageLink && x.Message == reportInOld.Message && x.Type == reportInOld.Type)) == null)
              {
                flag = false;
                break;
              }
            }
          }
          else
            flag = false;
          return flag;
        }
      }
    }
    catch
    {
      return false;
    }
    return false;
  }

  public bool IsSameFindResultInfoList(
    IEnumerable<FindResultInfo> lastList,
    IEnumerable<FindResultInfo> UIFields)
  {
    try
    {
      if (lastList != null)
      {
        if (UIFields != null)
        {
          List<FindResultInfo> findResultInfoList1 = new List<FindResultInfo>(lastList);
          List<FindResultInfo> findResultInfoList2 = new List<FindResultInfo>(UIFields);
          bool resultInfoList = true;
          if (findResultInfoList1.Count == findResultInfoList2.Count)
          {
            foreach (FindResultInfo findResultInfo in findResultInfoList1)
            {
              FindResultInfo reportInOld = findResultInfo;
              if (findResultInfoList2.Find((Predicate<FindResultInfo>) (x => x.Field == reportInOld.Field && x.FieldType == reportInOld.FieldType && x.FieldValue == reportInOld.FieldValue && x.Index == reportInOld.Index && x.Name == reportInOld.Name && x.Node == reportInOld.Node && x.Path == reportInOld.Path)) == null)
              {
                resultInfoList = false;
                break;
              }
            }
          }
          else
            resultInfoList = false;
          return resultInfoList;
        }
      }
    }
    catch
    {
      return false;
    }
    return false;
  }

  public bool IsSameFieldsReportInfoList(
    IEnumerable<FieldsReportInfo> lastList,
    IEnumerable<FieldsReportInfo> UIFields)
  {
    try
    {
      if (lastList != null)
      {
        if (UIFields != null)
        {
          List<FieldsReportInfo> fieldsReportInfoList1 = new List<FieldsReportInfo>(lastList);
          List<FieldsReportInfo> fieldsReportInfoList2 = new List<FieldsReportInfo>(UIFields);
          bool flag = true;
          if (fieldsReportInfoList1.Count == fieldsReportInfoList2.Count)
          {
            foreach (FieldsReportInfo fieldsReportInfo in fieldsReportInfoList1)
            {
              FieldsReportInfo reportInOld = fieldsReportInfo;
              if (fieldsReportInfoList2.Find((Predicate<FieldsReportInfo>) (x => x.Field == reportInOld.Field && x.FieldType == reportInOld.FieldType && x.FieldValue == reportInOld.FieldValue && x.Message == reportInOld.Message && x.Name == reportInOld.Name && x.Node == reportInOld.Node && x.Path == reportInOld.Path)) == null)
              {
                flag = false;
                break;
              }
            }
          }
          else
            flag = false;
          return flag;
        }
      }
    }
    catch
    {
      return false;
    }
    return false;
  }

  public void RefreshSelectedEventWindow()
  {
    DockWindow selectedDockWindow = this.EventPanelGrp.SelectedDockWindow;
    if (selectedDockWindow == null || selectedDockWindow.IsAutoHide)
      return;
    if (selectedDockWindow.Name == "OutputDockWnd")
    {
      if (AppInfoManager.StatusMsgReport == null)
        return;
      AppInfoManager.StatusMsgReport.MessageListChanged = true;
    }
    else if (selectedDockWindow.Name == "InvalidFieldsDockWnd")
    {
      if (AppInfoManager.InvalidFieldsReport == null)
        return;
      AppInfoManager.InvalidFieldsReport.FieldsReportChanged = true;
    }
    else if (selectedDockWindow.Name == "DnDDockWnd")
    {
      if (AppInfoManager.DragAndDropFieldsReport == null)
        return;
      AppInfoManager.DragAndDropFieldsReport.FieldsReportChanged = true;
    }
    else if (selectedDockWindow.Name == "ImpExpDockWnd")
    {
      if (AppInfoManager.ImportExportFieldsReport == null)
        return;
      AppInfoManager.ImportExportFieldsReport.FieldsReportChanged = true;
    }
    else if (selectedDockWindow.Name == "ComparatorDockWnd")
    {
      if (AppInfoManager.ComparatorFieldsReport == null)
        return;
      AppInfoManager.ComparatorFieldsReport.FieldsReportChanged = true;
    }
    else if (selectedDockWindow.Name == "FindResultsDockWnd")
    {
      if (AppInfoManager.FindResultReport == null)
        return;
      AppInfoManager.FindResultReport.ResultChanged = true;
    }
    else
    {
      if (!(selectedDockWindow.Name == "FillUpFillDownDockWnd") || AppInfoManager.FillUpFillDownFieldsReport == null)
        return;
      AppInfoManager.FillUpFillDownFieldsReport.FieldsReportChanged = true;
    }
  }

  private void OnFieldReportUpdated(object sender, FieldReportUpdatedEventArgs e)
  {
    DockWndType dwType = DockWndType.UnKnown;
    switch (e.FieldReportType)
    {
      case FieldReportType.InvalidFld:
        dwType = DockWndType.InvalidFields;
        break;
      case FieldReportType.ImpExp:
        dwType = DockWndType.ImpExp;
        break;
      case FieldReportType.DnD:
        dwType = DockWndType.DnD;
        break;
      case FieldReportType.Comparator:
        dwType = DockWndType.Comparator;
        break;
      case FieldReportType.FillUpFillDown:
        dwType = DockWndType.FillUpFillDown;
        break;
    }
    if (dwType == DockWndType.UnKnown)
      return;
    this.OpenDockWindow(dwType);
  }

  private void HandleReportChanged(DockWndType dWndType, bool hasReportEntries)
  {
    DockWindow dockWindow = this.GetDockWindow(dWndType);
    if (!dockWindow.Dispatcher.CheckAccess())
      return;
    if (!dockWindow.IsAutoHide)
      this.OpenDockWindow(dWndType);
    else if (hasReportEntries || dockWindow.IsMouseWithinAutoHidePopup())
    {
      this.OpenDockWindow(dWndType);
    }
    else
    {
      this.StopDockWindowAnimation(dockWindow);
      this.lastInvalidList = (IEnumerable<FieldsReportInfo>) null;
    }
  }

  private void OnComparatorFieldReportChanged(object sender, NotifyFieldsReportChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.Comparator, AppInfoManager.ComparatorFieldsReport.HasFields);
  }

  private void OnDnDFieldReportChanged(object sender, NotifyFieldsReportChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.DnD, AppInfoManager.DragAndDropFieldsReport.HasFields);
  }

  private void OnFillUpFillDownFieldReportChanged(
    object sender,
    NotifyFieldsReportChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.FillUpFillDown, AppInfoManager.FillUpFillDownFieldsReport.HasFields);
  }

  private void OnInvalidFieldsReportChanged(object sender, NotifyFieldsReportChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.InvalidFields, AppInfoManager.InvalidFieldsReport.UiHasFields);
  }

  private void OnImportExportFieldReportChanged(object sender, NotifyFieldsReportChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.ImpExp, AppInfoManager.ImportExportFieldsReport.HasFields);
  }

  private void OnStatusMessageChanged(object sender, NotifyMsgListChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.Output, AppInfoManager.StatusMsgReport.HasMsgs);
  }

  private void OnFindResultChanged(object sender, NotifyFindResultChangedEventArgs e)
  {
    this.HandleReportChanged(DockWndType.FindResults, AppInfoManager.FindResultReport.HasResults);
  }

  private void OnRightPanePinAndDisplayFieldHelpInfo(object sender, CpgFieldNameMouseEventArgs e)
  {
    this.PopupDockWindow(DockWndType.HelpInfo);
    this.OnRightPaneDisplayFieldHelpInfo(sender, e);
  }

  private void OnRightPaneDisplayFieldHelpInfo(object sender, CpgFieldNameMouseEventArgs e)
  {
    if (!(sender is IAcpUIParentCtrlBase))
      return;
    IAcpUIParentCtrlBase uiParentCtrlBase = (IAcpUIParentCtrlBase) sender;
    if (uiParentCtrlBase == null || uiParentCtrlBase.MyBLObject == null)
      return;
    AcpFieldBase myBlObject = uiParentCtrlBase.MyBLObject;
    HelpMapData helpMapData;
    if (this.helpMap == null || !this.helpMap.TryGetValue(myBlObject.Name, out helpMapData))
      return;
    this.browser.ShowSingleFileHelp(helpMapData.Url);
  }

  public void ChangeColorScheme(eDockVisualStyle dockColor, Color customBaseColor)
  {
    this.AppDock.ChangeColorScheme(dockColor, customBaseColor);
  }

  public AcpIuiPage()
  {
    this.InitializeComponent();
    this.InvalidFieldsDockWnd.DataContext = (object) AppInfoManager.InvalidFieldsReport;
    Application.Current.Resources.MergedDictionaries.Add((ResourceDictionary) new Office2007SilverSkin());
    AcpUI.Common.Utility.FieldsReportUpdatedEvent += new FieldReportUpdatedEventHandler(this.OnFieldReportUpdated);
    StatusMessagesManager.NotifyMsgListChangedEvent += new NotifyMsgListChangedEventHandler(this.OnStatusMessageChanged);
    FindResultsManager.NotifyFindResultChangedEvent += new NotifyFindResultChangedEventHandler(this.OnFindResultChanged);
    AcpUI.Common.Utility.CpgFieldNameMouseDoubleClickEvent += new CpgFieldNameEventHandler(this.OnRightPanePinAndDisplayFieldHelpInfo);
    AcpUI.Common.Utility.CpgFieldNameMouseClickEvent += new CpgFieldNameEventHandler(this.OnRightPaneDisplayFieldHelpInfo);
    AppInfoManager.InvalidFieldsReport.NotifyFieldsReportChangedEvent += new NotifyFieldsReportChangedEventHandler(this.OnInvalidFieldsReportChanged);
    if (AppInfoManager.ImportExportFieldsReport == null)
      AppInfoManager.ImportExportFieldsReport = new FieldsReportManager();
    AppInfoManager.ImportExportFieldsReport.NotifyFieldsReportChangedEvent += new NotifyFieldsReportChangedEventHandler(this.OnImportExportFieldReportChanged);
    if (AppInfoManager.ComparatorFieldsReport == null)
      AppInfoManager.ComparatorFieldsReport = new FieldsReportManager();
    AppInfoManager.ComparatorFieldsReport.NotifyFieldsReportChangedEvent += new NotifyFieldsReportChangedEventHandler(this.OnComparatorFieldReportChanged);
    if (AppInfoManager.DragAndDropFieldsReport == null)
      AppInfoManager.DragAndDropFieldsReport = new FieldsReportManager();
    AppInfoManager.DragAndDropFieldsReport.NotifyFieldsReportChangedEvent += new NotifyFieldsReportChangedEventHandler(this.OnDnDFieldReportChanged);
    if (AppInfoManager.FillUpFillDownFieldsReport == null)
      AppInfoManager.FillUpFillDownFieldsReport = new FieldsReportManager();
    AppInfoManager.FillUpFillDownFieldsReport.NotifyFieldsReportChangedEvent += new NotifyFieldsReportChangedEventHandler(this.OnFillUpFillDownFieldReportChanged);
    this.helpMap = HelpMapProvider.ParseHelpMapFile(this.helpMapPath);
  }

  private void FrameCenterTop_Navigated(object sender, NavigationEventArgs e)
  {
    if (!AppInfoManager.ClearNavigationHistory)
      return;
    System.Windows.Controls.Frame frame = (System.Windows.Controls.Frame) sender;
    while (frame.CanGoBack)
      frame.RemoveBackEntry();
    AppInfoManager.ClearNavigationHistory = false;
  }

  private void FrameInvalidFields_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameDnD_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameFillUpFillDown_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameImpExp_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameComparator_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameFindResults_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void FrameSysKeyReport_LoadCompleted(object sender, NavigationEventArgs e)
  {
    this.RemoveReportWindowBackStack(sender as System.Windows.Controls.Frame);
  }

  private void RemoveReportWindowBackStack(System.Windows.Controls.Frame frameToClear)
  {
    if (frameToClear == null || frameToClear.BackStack == null)
      return;
    while (frameToClear.CanGoBack)
      frameToClear.RemoveBackEntry();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/app.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  internal Delegate _CreateDelegate(Type delegateType, string handler)
  {
    return Delegate.CreateDelegate(delegateType, (object) this, handler);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.StatusBarFrame = (System.Windows.Controls.Frame) target;
        break;
      case 2:
        this.AppDock = (DockSite) target;
        this.AppDock.AddHandler(DockWindow.ActivatedEvent, (Delegate) new RoutedEventHandler(this.DockWindowActivated));
        this.AppDock.AddHandler(DockWindow.DeactivatedEvent, (Delegate) new RoutedEventHandler(this.DockWindowDeactivated));
        this.AppDock.AddHandler(DockWindow.AutoHideOpenChangedEvent, (Delegate) new RoutedEventHandler(this.DockWindowActivated));
        this.AppDock.AddHandler(DockWindow.AutoHideChangedEvent, (Delegate) new RoutedEventHandler(this.AutoHideChanged));
        this.AppDock.AddHandler(DockWindow.ClosingEvent, (Delegate) new CancelSourceRoutedEventHandler(this.DockWindowClosing));
        this.AppDock.AddHandler(DockWindow.ClosedEvent, (Delegate) new RoutedEventHandler(this.DockWindowClosed));
        break;
      case 3:
        this.NavPanel = (SplitPanel) target;
        break;
      case 4:
        this.NavPanelGrp = (DockWindowGroup) target;
        break;
      case 5:
        this.NavWindowDockWnd = (AcpDockWindow) target;
        break;
      case 6:
        this.FrameLeft = (System.Windows.Controls.Frame) target;
        break;
      case 7:
        this.TaskPanel = (SplitPanel) target;
        break;
      case 8:
        this.TaskPanelGrp = (DockWindowGroup) target;
        break;
      case 9:
        this.TaskWindowDockWnd = (AcpDockWindow) target;
        break;
      case 10:
        this.FrameRight = (System.Windows.Controls.Frame) target;
        break;
      case 11:
        this.browser = (ContextHelp) target;
        break;
      case 12:
        this.CenterDock = (DockSite) target;
        this.CenterDock.AddHandler(DockWindow.ActivatedEvent, (Delegate) new RoutedEventHandler(this.DockWindowActivated));
        this.CenterDock.AddHandler(DockWindow.DeactivatedEvent, (Delegate) new RoutedEventHandler(this.DockWindowDeactivated));
        this.CenterDock.AddHandler(DockWindow.AutoHideOpenChangedEvent, (Delegate) new RoutedEventHandler(this.DockWindowActivated));
        this.CenterDock.AddHandler(DockWindow.AutoHideChangedEvent, (Delegate) new RoutedEventHandler(this.AutoHideChanged));
        this.CenterDock.AddHandler(DockWindow.ClosingEvent, (Delegate) new CancelSourceRoutedEventHandler(this.DockWindowClosing));
        this.CenterDock.AddHandler(DockWindow.ClosedEvent, (Delegate) new RoutedEventHandler(this.DockWindowClosed));
        break;
      case 13:
        this.EventPanel = (SplitPanel) target;
        break;
      case 14:
        this.EventPanelGrp = (DockWindowGroup) target;
        break;
      case 15:
        this.OutputDockWnd = (AcpDockWindow) target;
        break;
      case 16 /*0x10*/:
        this.FrameOutput = (System.Windows.Controls.Frame) target;
        break;
      case 17:
        this.InvalidFieldsDockWnd = (AcpDockWindow) target;
        break;
      case 18:
        this.FrameInvalidFields = (System.Windows.Controls.Frame) target;
        this.FrameInvalidFields.LoadCompleted += new LoadCompletedEventHandler(this.FrameInvalidFields_LoadCompleted);
        break;
      case 19:
        this.DnDDockWnd = (AcpDockWindow) target;
        break;
      case 20:
        this.FrameDnD = (System.Windows.Controls.Frame) target;
        this.FrameDnD.LoadCompleted += new LoadCompletedEventHandler(this.FrameDnD_LoadCompleted);
        break;
      case 21:
        this.ImpExpDockWnd = (AcpDockWindow) target;
        break;
      case 22:
        this.FrameImpExp = (System.Windows.Controls.Frame) target;
        this.FrameImpExp.LoadCompleted += new LoadCompletedEventHandler(this.FrameImpExp_LoadCompleted);
        break;
      case 23:
        this.ComparatorDockWnd = (AcpDockWindow) target;
        break;
      case 24:
        this.FrameComparator = (System.Windows.Controls.Frame) target;
        this.FrameComparator.LoadCompleted += new LoadCompletedEventHandler(this.FrameComparator_LoadCompleted);
        break;
      case 25:
        this.FillUpFillDownDockWnd = (AcpDockWindow) target;
        break;
      case 26:
        this.FrameFillUpFillDown = (System.Windows.Controls.Frame) target;
        this.FrameFillUpFillDown.LoadCompleted += new LoadCompletedEventHandler(this.FrameFillUpFillDown_LoadCompleted);
        break;
      case 27:
        this.FindResultsDockWnd = (AcpDockWindow) target;
        break;
      case 28:
        this.FrameFindResults = (System.Windows.Controls.Frame) target;
        this.FrameFindResults.LoadCompleted += new LoadCompletedEventHandler(this.FrameFindResults_LoadCompleted);
        break;
      case 29:
        this.SysKeyReportWnd = (AcpDockWindow) target;
        break;
      case 30:
        this.FrameSysKeyReport = (System.Windows.Controls.Frame) target;
        this.FrameSysKeyReport.LoadCompleted += new LoadCompletedEventHandler(this.FrameSysKeyReport_LoadCompleted);
        break;
      case 31 /*0x1F*/:
        this.FrameCenterTop = (System.Windows.Controls.Frame) target;
        this.FrameCenterTop.Navigated += new NavigatedEventHandler(this.FrameCenterTop_Navigated);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
