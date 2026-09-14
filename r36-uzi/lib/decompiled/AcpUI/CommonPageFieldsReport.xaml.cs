// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.PageFieldsReport
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using AcpCommonLib.FieldsReport;
using AcpCommonResources;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace AcpUI.Common;

public partial class PageFieldsReport : Page, IComponentConnector
{
  internal ListView myListView;
  internal GridView FieldsReportGV;
  internal GridViewColumn FieldsReportGVC1;
  internal GridViewColumn FieldsReportGVC2;
  internal GridViewColumn FieldsReportGVC3;
  internal GridViewColumn FieldsReportGVC4;
  private bool _contentLoaded;

  public PageFieldsReport() => this.InitializeComponent();

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    Style style = new Style(typeof (ListViewItem), (Style) this.TryFindResource((object) "ListViewItemStyleBase") ?? this.myListView.ItemContainerStyle);
    style.Setters.Add((SetterBase) new EventSetter(Control.MouseDoubleClickEvent, (Delegate) new MouseButtonEventHandler(this.OnDoubleClick)));
    this.myListView.ItemContainerStyle = style;
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

  private void OnDoubleClick(object sender, MouseButtonEventArgs e)
  {
    if (!(sender is ListViewItem listViewItem) || !(listViewItem.DataContext is FieldsReportInfo dataContext))
      return;
    Utility.FieldReportSelectionChanged(sender, (FieldInfo) dataContext);
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
      foreach (FieldsReportInfo selectedItem in (IEnumerable) this.myListView.SelectedItems)
      {
        stringBuilder.Append(selectedItem.Path + "\t");
        stringBuilder.Append(selectedItem.Name + "\t");
        stringBuilder.Append(selectedItem.FieldValue + "\t");
        stringBuilder.Append(selectedItem.Message + "\t");
        stringBuilder.AppendLine();
      }
      Clipboard.Clear();
      Clipboard.SetText(stringBuilder.ToString());
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
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/common/pagefieldsreport.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.myListView = (ListView) target;
        break;
      case 2:
        this.FieldsReportGV = (GridView) target;
        break;
      case 3:
        this.FieldsReportGVC1 = (GridViewColumn) target;
        break;
      case 4:
        this.FieldsReportGVC2 = (GridViewColumn) target;
        break;
      case 5:
        this.FieldsReportGVC3 = (GridViewColumn) target;
        break;
      case 6:
        this.FieldsReportGVC4 = (GridViewColumn) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
