// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpParentRecNavToolbar
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

#nullable disable
namespace AcpUI;

public class AcpParentRecNavToolbar : AcpRecNavToolbar
{
  private AcpChildToolbarCollection children;

  public AcpParentRecNavToolbar() => this.children = new AcpChildToolbarCollection(this);

  public AcpChildToolbarCollection ChildToolbars => this.children;

  public override IAcpRecordset MySecondaryRecordsetDataSource
  {
    get => base.MySecondaryRecordsetDataSource;
    set
    {
      base.MySecondaryRecordsetDataSource = value;
      this.SyncDataSources();
      foreach (AcpRecNavToolbar childToolbar in (Collection<AcpChildRecNavToolbar>) this.ChildToolbars)
        childToolbar.SyncDataSources();
      this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.ForcedUpdate);
    }
  }

  protected override void OnLoaded(object sender, RoutedEventArgs e)
  {
    base.OnLoaded(sender, e);
    this.GrpOperationToolBar.Visibility = Visibility.Collapsed;
    this.GrpNavigationToolBar.Visibility = Visibility.Visible;
  }

  protected override void OnUnloaded(object sender, RoutedEventArgs e)
  {
    base.OnUnloaded(sender, e);
  }

  protected override void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    base.OnDataContextChanged(sender, e);
  }

  protected internal override void OnUpdate(object sender, ToolbarUpdateEventArgs e)
  {
    this.Update();
    foreach (AcpChildRecNavToolbar childToolbar in (Collection<AcpChildRecNavToolbar>) this.ChildToolbars)
    {
      if (childToolbar != sender)
        childToolbar.Update();
    }
  }

  internal override void Update(UpdateToolbarEventType eventType)
  {
    base.Update(eventType);
    if (eventType != UpdateToolbarEventType.Navigation)
      return;
    this.UpdateRecordOperationButtons();
  }

  protected override void OnRecNavBtnFirstClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnFirstClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.Navigation);
  }

  protected override void OnRecNavBtnPreviousClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnPreviousClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.Navigation);
  }

  protected override void OnRecNavBtnNextClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnNextClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.Navigation);
  }

  protected override void OnRecNavBtnLastClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnLastClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.Navigation);
  }

  protected override void OnRecNavBtnGoToClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnGoToClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.Navigation);
  }

  protected override void OnRecNavBtnAddMultipleClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnAddMultipleClick(sender, e);
    if (this.AddMultQty <= 0)
      return;
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.RecordOperation);
  }

  protected override void OnRecNavBtnDeleteClick(object sender, RoutedEventArgs e)
  {
    base.OnRecNavBtnDeleteClick(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.RecordOperation);
  }

  protected override void OnRecordAdded(object sender, NotifyCollectionChangedEventArgs e)
  {
    base.OnRecordAdded(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.RecordOperation);
  }

  protected override void OnRecordDeleted(object sender, NotifyCollectionChangedEventArgs e)
  {
    base.OnRecordDeleted(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.RecordOperation);
  }

  protected override void OnCollectionViewCurrentChanged(object sender, EventArgs e)
  {
    base.OnCollectionViewCurrentChanged(sender, e);
    this.RaiseToolbarUpdateEvent(UpdateToolbarEventType.ForcedUpdate);
  }

  private void RaiseToolbarUpdateEvent(UpdateToolbarEventType eventType)
  {
    ToolbarUpdateEventArgs e = new ToolbarUpdateEventArgs(eventType);
    foreach (AcpChildRecNavToolbar childToolbar in (Collection<AcpChildRecNavToolbar>) this.ChildToolbars)
    {
      if (childToolbar.DataContext != null)
      {
        childToolbar.OnUpdate((object) this, e);
        childToolbar.SyncDataSources();
      }
    }
  }

  protected override void Dispose(bool disposing)
  {
    try
    {
      int num = disposing ? 1 : 0;
    }
    finally
    {
      base.Dispose(disposing);
    }
  }
}
