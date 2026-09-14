// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.PageReportSystemKeys
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpASKLib;
using AcpCommonLib;
using AcpCommonResources;
using AcpSecurityLib;
using AcpUtility;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI.Common;

public partial class PageReportSystemKeys : Page, IComponentConnector
{
  internal TextBlock TxtBlkCounter;
  internal ListView myListView;
  internal GridView SysKeyReport;
  internal GridViewColumn KeyIcon;
  internal GridViewColumn SysID;
  internal GridViewColumn SysKeyType;
  internal GridViewColumn SerialNum;
  internal GridViewColumn KeyAccessLevel;
  internal GridViewColumn KeyWPEnabled;
  private bool _contentLoaded;

  public PageReportSystemKeys() => this.InitializeComponent();

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    Style resource = (Style) this.TryFindResource((object) "ListViewItemStyleBase");
    if (resource == null)
      return;
    this.myListView.ItemContainerStyle = new Style(typeof (ListViewItem), resource);
  }

  private void myListView_Loaded(object sender, EventArgs e)
  {
    ((INotifyCollectionChanged) this.myListView.Items).CollectionChanged += new NotifyCollectionChangedEventHandler(this.myListView_CollectionChanged);
    this.SortListView();
    ContextMenu contextMenu = new ContextMenu();
    MenuItem newItem = new MenuItem();
    newItem.Header = (object) AcpResources.Copy_Id;
    contextMenu.Items.Add((object) newItem);
    this.myListView.ContextMenu = contextMenu;
    newItem.Click += new RoutedEventHandler(this.menuItem_Click);
    this.myListView.InputBindings.Add(new InputBinding((ICommand) ApplicationCommands.Copy, (InputGesture) new KeyGesture(Key.C, ModifierKeys.Control)));
    this.myListView.InputBindings.Add(new InputBinding((ICommand) ApplicationCommands.SelectAll, (InputGesture) new KeyGesture(Key.A, ModifierKeys.Control)));
    CommandBinding commandBinding1 = new CommandBinding((ICommand) ApplicationCommands.Copy);
    commandBinding1.Executed += new ExecutedRoutedEventHandler(this.copy_Executed);
    this.myListView.CommandBindings.Add(commandBinding1);
    CommandBinding commandBinding2 = new CommandBinding((ICommand) ApplicationCommands.SelectAll);
    commandBinding2.Executed += new ExecutedRoutedEventHandler(this.selectAllCommand_Executed);
    this.myListView.CommandBindings.Add(commandBinding2);
  }

  private void SortListView()
  {
    try
    {
      ICollectionView defaultView = CollectionViewSource.GetDefaultView((object) this.myListView.ItemsSource);
      defaultView.SortDescriptions.Clear();
      defaultView.SortDescriptions.Add(new SortDescription("SystemID", ListSortDirection.Ascending));
      defaultView.Refresh();
    }
    catch
    {
    }
  }

  private void myListView_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.Action != NotifyCollectionChangedAction.Add && e.Action != NotifyCollectionChangedAction.Remove)
      return;
    this.SortListView();
  }

  private void myListView_UnLoaded(object sender, EventArgs e)
  {
    ((INotifyCollectionChanged) this.myListView.Items).CollectionChanged -= new NotifyCollectionChangedEventHandler(this.myListView_CollectionChanged);
  }

  private void menuItem_Click(object sender, RoutedEventArgs e)
  {
    this.copy_Executed((object) null, (ExecutedRoutedEventArgs) null);
  }

  private void copy_Executed(object sender, ExecutedRoutedEventArgs e)
  {
    try
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (SystemKeyData selectedItem in (IEnumerable) this.myListView.SelectedItems)
      {
        object obj1 = new DecToHexConverter().Convert((object) selectedItem.SystemID, (Type) null, (object) null, AcpResources.Culture);
        stringBuilder.Append(obj1.ToString() + "\t");
        object obj2 = new KeySrcKeyTypeConverter().Convert(new object[2]
        {
          (object) selectedItem.Source,
          (object) selectedItem.Type
        }, (Type) null, (object) null, AcpResources.Culture);
        stringBuilder.Append(obj2.ToString() + "\t");
        stringBuilder.Append(selectedItem.iBtnSerialNum + "\t");
        object obj3 = new KeyACLTypeConverter().Convert((object) selectedItem.AccessLevelType, (Type) null, (object) null, AcpResources.Culture);
        stringBuilder.Append(obj3.ToString() + "\t");
        object obj4 = new KeyWriteProtectEnabledConverter().Convert(new object[2]
        {
          (object) selectedItem.Source,
          (object) selectedItem.WriteProtectEnabled
        }, (Type) null, (object) null, AcpResources.Culture);
        stringBuilder.Append(obj4.ToString() + "\t");
        stringBuilder.AppendLine();
      }
      Clipboard.Clear();
      Clipboard.SetText(stringBuilder.ToString());
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Info, AcpResources.Num_Recs_Copied_to_Clipboard.AcpStringFormat((object) this.myListView.SelectedItems.Count));
    }
    catch
    {
    }
  }

  private void selectAllCommand_Executed(object sender, ExecutedRoutedEventArgs e)
  {
    this.myListView.SelectAll();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/common/pagereportsystemkeys.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.TxtBlkCounter = (TextBlock) target;
        break;
      case 2:
        this.myListView = (ListView) target;
        this.myListView.Loaded += new RoutedEventHandler(this.myListView_Loaded);
        this.myListView.Unloaded += new RoutedEventHandler(this.myListView_UnLoaded);
        break;
      case 3:
        this.SysKeyReport = (GridView) target;
        break;
      case 4:
        this.KeyIcon = (GridViewColumn) target;
        break;
      case 5:
        this.SysID = (GridViewColumn) target;
        break;
      case 6:
        this.SysKeyType = (GridViewColumn) target;
        break;
      case 7:
        this.SerialNum = (GridViewColumn) target;
        break;
      case 8:
        this.KeyAccessLevel = (GridViewColumn) target;
        break;
      case 9:
        this.KeyWPEnabled = (GridViewColumn) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
