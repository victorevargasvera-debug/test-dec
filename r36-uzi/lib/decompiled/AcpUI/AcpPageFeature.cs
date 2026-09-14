// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpPageFeature
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpUILib;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

#nullable disable
namespace AcpUI;

public class AcpPageFeature : Page, IAcpPageFeature
{
  private ExpanderCollection expanders = new ExpanderCollection();
  public static readonly DependencyProperty PageRecNavToolbarProperty = DependencyProperty.Register(nameof (PageRecNavToolbar), typeof (AcpRecNavToolbar), typeof (AcpPageFeature), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

  public AcpRecNavToolbar MyBaseRecNavToolbar { get; set; }

  public AcpRecNavToolbar PageRecNavToolbar
  {
    get => (AcpRecNavToolbar) this.GetValue(AcpPageFeature.PageRecNavToolbarProperty);
    set => this.SetValue(AcpPageFeature.PageRecNavToolbarProperty, (object) value);
  }

  public int PageFeatureId { get; set; }

  public ExpanderCollection Expanders => this.expanders;

  public virtual void SetDataContext() => throw new NotImplementedException();

  private void OnInitialized(object sender, EventArgs e)
  {
    if (!(bool) DesignerProperties.IsInDesignModeProperty.GetMetadata(typeof (DependencyObject)).DefaultValue)
      this.SetDataContext();
    this.Initialized -= new EventHandler(this.OnInitialized);
  }

  public virtual void OnLoaded(object sender, RoutedEventArgs e)
  {
    AppInfoManager.AppInfoHelper.PropertyChanged += new PropertyChangedEventHandler(this.OnAppInfoPropertyChanged);
    AcpDocument.PageOnLoading = true;
    this.CalculateConstraints();
    AcpDocument.PageOnLoading = false;
    FeatureNode currentNode = this.GetCurrentNode();
    if (currentNode == null)
      return;
    foreach (AcpExpander expander in (Collection<AcpExpander>) this.Expanders)
    {
      expander.IsExpanded = !AcpExpStatusManager.Contains(currentNode.NodeId, expander);
      expander.Collapsed += new RoutedEventHandler(this.exp_Collapsed);
      expander.Expanded += new RoutedEventHandler(this.exp_Expanded);
    }
  }

  protected FeatureNode GetCurrentNode()
  {
    return (FeatureNode) ((CollectionView) CollectionViewSource.GetDefaultView((object) (IAcpRecordset) this.DataContext)).CurrentItem;
  }

  private void exp_Expanded(object sender, RoutedEventArgs e)
  {
    AcpExpStatusManager.Remove(this.GetCurrentNode().NodeId, (AcpExpander) sender);
  }

  private void exp_Collapsed(object sender, RoutedEventArgs e)
  {
    AcpExpStatusManager.Add(this.GetCurrentNode().NodeId, (AcpExpander) sender);
  }

  public void OnHLinkClick(object sender)
  {
    string tag = (string) ((FrameworkContentElement) sender).Tag;
    try
    {
      AcpExpander expander = this.Expanders[tag];
      if (!expander.IsExpanded)
        expander.IsExpanded = true;
      expander.BringIntoView();
      expander.Focus();
    }
    catch (Exception ex)
    {
    }
  }

  public void HLinkClick(object sender, RoutedEventArgs e) => this.OnHLinkClick(sender);

  public void OnFieldNameDoubleClick(object sender, RoutedEventArgs e)
  {
    AcpUI.Common.Utility.GetFieldHelpText(sender);
  }

  private void OnAppInfoPropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    if (e.PropertyName == "DndOperationCompleted" || e.PropertyName == "ImportOperationCompleted")
      this.CalculateConstraints();
    if (e.PropertyName == "AppView" && this.DataContext is IAcpConstraints dataContext)
    {
      dataContext.CalculateEditability(true);
      dataContext.CalculateVisibility(true);
    }
    if (!(e.PropertyName == "AppMode"))
      return;
    this.RefreshComparatorOdp();
  }

  private void CalculateConstraints()
  {
    if (!(this.DataContext is IAcpConstraints dataContext))
      return;
    dataContext.CalculateApplicability();
    dataContext.CalculateEditability(true);
    dataContext.CalculateVisibility(true);
  }

  public void RefreshComparatorOdp()
  {
    try
    {
      if (!(this.FindResource((object) "GetComparatorParentFeature") is ObjectDataProvider resource1))
        return;
      resource1.Refresh();
      string uiName = FeatureManager.GetFeature(2028)?[0]?.UIName;
      if (uiName == null || !(this.Title == uiName) || !(this.FindResource((object) "GetURLTableFeatureCmp") is ObjectDataProvider resource2))
        return;
      resource2.Refresh();
    }
    catch (ResourceReferenceKeyNotFoundException ex)
    {
    }
  }

  public virtual void OnUnloaded(object sender, RoutedEventArgs e)
  {
    foreach (AcpExpander expander in (Collection<AcpExpander>) this.Expanders)
    {
      expander.ExpToolbar = (AcpRecNavToolbar) null;
      expander.Collapsed -= new RoutedEventHandler(this.exp_Collapsed);
      expander.Expanded -= new RoutedEventHandler(this.exp_Expanded);
    }
    this.Expanders.Clear();
    AppInfoManager.AppInfoHelper.PropertyChanged -= new PropertyChangedEventHandler(this.OnAppInfoPropertyChanged);
  }

  public AcpPageFeature()
  {
    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();
    this.Initialized += new EventHandler(this.OnInitialized);
  }

  ~AcpPageFeature()
  {
  }
}
