// Decompiled with JetBrains decompiler
// Type: MackinawCPS.AppTreeView
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpCommonLib;
using AcpUI;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Navigation;

#nullable disable
namespace MackinawCPS;

public class AppTreeView : AcpTreeView
{
  public override bool UpdateTreeView(int nRecsetID)
  {
    bool flag = true;
    if (nRecsetID == 2200 || nRecsetID == 2300)
      flag = false;
    return flag;
  }

  public override void LaunchPage(string pageUri)
  {
    AcpTreeViewItem selectedItem = this.SelectedItem as AcpTreeViewItem;
    if (this.CurrentRecord != null || selectedItem != null && selectedItem.NodeId != 0)
      this.SetFocusOnCurrentRecord();
    if (!string.IsNullOrEmpty(pageUri))
    {
      Uri source = new Uri(Uri.EscapeUriString(pageUri.Replace("\\", "/")), UriKind.RelativeOrAbsolute);
      System.Windows.Controls.Frame frameCenterTop = ((WindowMain) Application.Current.MainWindow).FrameCenterTop;
      if (frameCenterTop.Content != null)
      {
        if (frameCenterTop.Content is AcpPageFeature)
        {
          if (frameCenterTop.CurrentSource.OriginalString == source.OriginalString)
          {
            frameCenterTop.NavigationService.LoadCompleted += new LoadCompletedEventHandler(this.SamePageLoadCompleteHandler);
            frameCenterTop.Navigate(source);
          }
          else
          {
            frameCenterTop.ContentRendered += new EventHandler(this.LoadCompleteHandler);
            frameCenterTop.Navigate(source);
          }
        }
        else
        {
          frameCenterTop.ContentRendered += new EventHandler(this.LoadCompleteHandler);
          frameCenterTop.Navigate(source);
        }
      }
      else
      {
        frameCenterTop.ContentRendered += new EventHandler(this.LoadCompleteHandler);
        frameCenterTop.Navigate(source);
      }
    }
    else
      this.LoadCompleteHandler((object) this, (EventArgs) null);
  }

  private void SetFocusOnCurrentRecord()
  {
    IAcpFeatureNode currentRecord = this.CurrentRecord;
    if (currentRecord == null)
      return;
    int nodeId = currentRecord.Parent.SingleInstance ? 0 : currentRecord.NodeId;
    AcpTreeViewItem childTreeViewItem = this.FindChildTreeViewItem(currentRecord.Parent.RecsetId, nodeId);
    if (childTreeViewItem != null)
    {
      childTreeViewItem.BringIntoView();
      if (!childTreeViewItem.IsSelected)
        childTreeViewItem.IsSelected = true;
    }
  }

  private void SamePageLoadCompleteHandler(object sender, NavigationEventArgs e)
  {
    this.LoadCompleteHandler((object) this, (EventArgs) null);
  }

  private void LoadCompleteHandler(object sender, EventArgs e)
  {
    WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
    System.Windows.Controls.Frame frameCenterTop = mainWindow.FrameCenterTop;
    object selectedItemContent = ((PageNavPaneButtons) mainWindow.FrameLeft.Content).GetSelectedItemContent();
    if (selectedItemContent is PageTreeView)
    {
      PageTreeView pageTreeView = (PageTreeView) selectedItemContent;
      ((AcpTreeView) pageTreeView.Content).OnLoadComplete(frameCenterTop);
      pageTreeView.preSelectedItem = this.SelectedItem as AcpTreeViewItem;
      AcpPageFeature content = frameCenterTop.Content as AcpPageFeature;
      if (content.Expanders != null)
      {
        foreach (AcpExpander expander in (Collection<AcpExpander>) content.Expanders)
        {
          if (expander.IsAcpVisible)
          {
            expander.Focus();
            break;
          }
        }
      }
      this.Focus();
      if (this.sectionToLaunch != null && this.sectionToLaunch.UIName != null && content.Expanders != null)
      {
        foreach (AcpExpander expander in (Collection<AcpExpander>) content.Expanders)
        {
          if ((this.sectionToLaunch.UIName.CompareTo(expander.Header) == 0 || this.sectionToLaunch.Parent.Parent.ParentSection != null && this.sectionToLaunch.Parent.Parent.ParentSection.UIName.CompareTo(expander.Header) == 0) && expander.IsAcpVisible)
          {
            if (!expander.IsExpanded)
              expander.IsExpanded = true;
            expander.Focus();
            break;
          }
        }
      }
      this.sectionToLaunch = (IAcpFeatureSection) null;
    }
    frameCenterTop.ContentRendered -= new EventHandler(this.LoadCompleteHandler);
    frameCenterTop.NavigationService.LoadCompleted -= new LoadCompletedEventHandler(this.SamePageLoadCompleteHandler);
  }
}
