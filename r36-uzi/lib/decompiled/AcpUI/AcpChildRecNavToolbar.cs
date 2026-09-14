// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpChildRecNavToolbar
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

#nullable disable
namespace AcpUI;

public class AcpChildRecNavToolbar : AcpRecNavToolbar
{
  private AcpParentRecNavToolbar parent;

  ~AcpChildRecNavToolbar() => this.Dispose(false);

  public AcpParentRecNavToolbar ParentToolbar
  {
    get => this.parent;
    internal set => this.parent = value;
  }

  public override IAcpRecordset MySecondaryRecordsetDataSource
  {
    get => base.MySecondaryRecordsetDataSource;
    set
    {
      base.MySecondaryRecordsetDataSource = value;
      this.SyncDataSources();
    }
  }

  protected override void OnLoaded(object sender, RoutedEventArgs e)
  {
    base.OnLoaded(sender, e);
    this.GrpNavigationToolBar.Visibility = Visibility.Collapsed;
    this.GrpOperationToolBar.Visibility = Visibility.Visible;
    this.GrpModeSelection.Visibility = Visibility.Visible;
  }

  protected override void OnUnloaded(object sender, RoutedEventArgs e)
  {
    base.OnUnloaded(sender, e);
    this.parent = (AcpParentRecNavToolbar) null;
  }

  protected override void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    base.OnDataContextChanged(sender, e);
  }

  protected internal override void OnUpdate(object sender, ToolbarUpdateEventArgs e)
  {
    if (sender != this.ParentToolbar || this.MyDataPresenter == null)
      return;
    if (this.MyDataPresenter.Records.Count > 0)
    {
      this.MyDataPresenter.SelectedItems.Records.Clear();
      CollectionView viewForDataSource = this.GetCollectionViewForDataSource();
      if (viewForDataSource.CurrentPosition == -1)
        viewForDataSource.MoveCurrentToFirst();
    }
    this.Update();
  }

  protected override void OnRecsetCollectionChanged(
    object sender,
    NotifyCollectionChangedEventArgs e)
  {
    base.OnRecsetCollectionChanged(sender, e);
    if (this.ParentToolbar == null)
      return;
    this.ParentToolbar.OnUpdate((object) this, new ToolbarUpdateEventArgs(UpdateToolbarEventType.RecordOperation));
  }

  protected override void OnRecordsetPropertyChanged(object sender, PropertyChangedEventArgs e)
  {
    base.OnRecordsetPropertyChanged(sender, e);
    if (!(e.PropertyName == "CanAdd") || this.ParentToolbar == null)
      return;
    this.ParentToolbar.OnUpdate((object) this, new ToolbarUpdateEventArgs(UpdateToolbarEventType.RecordOperation));
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
