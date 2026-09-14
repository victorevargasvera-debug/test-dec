// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.PageFindResults
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpCommonLib;
using AcpCommonLib.FindResult;
using AcpCommonResources;
using AcpUtility;
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

public partial class PageFindResults : Page, IComponentConnector
{
  internal TextBlock TxtBlkCounter;
  internal ListView FindResultsList;
  internal GridView FindResultsGrid;
  internal GridViewColumn Num;
  internal GridViewColumn FieldName;
  internal GridViewColumn Path;
  private bool _contentLoaded;

  public PageFindResults() => this.InitializeComponent();

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    Style style = new Style(typeof (ListViewItem), (Style) this.TryFindResource((object) "ListViewItemStyleBase") ?? this.FindResultsList.ItemContainerStyle);
    style.Setters.Add((SetterBase) new EventSetter(Control.MouseDoubleClickEvent, (Delegate) new MouseButtonEventHandler(this.OnMouseDoubleClick)));
    this.FindResultsList.ItemContainerStyle = style;
    ContextMenu contextMenu = new ContextMenu();
    MenuItem newItem = new MenuItem();
    newItem.Header = (object) AcpResources.Copy_Id;
    contextMenu.Items.Add((object) newItem);
    this.FindResultsList.ContextMenu = contextMenu;
    newItem.Click += new RoutedEventHandler(this.menuItem_Click);
    this.FindResultsList.InputBindings.Add(new InputBinding((ICommand) ApplicationCommands.Copy, (InputGesture) new KeyGesture(Key.C, ModifierKeys.Control)));
    this.FindResultsList.InputBindings.Add(new InputBinding((ICommand) ApplicationCommands.SelectAll, (InputGesture) new KeyGesture(Key.A, ModifierKeys.Control)));
    CommandBinding commandBinding1 = new CommandBinding((ICommand) ApplicationCommands.Copy);
    commandBinding1.Executed += new ExecutedRoutedEventHandler(this.copy_Executed);
    this.FindResultsList.CommandBindings.Add(commandBinding1);
    CommandBinding commandBinding2 = new CommandBinding((ICommand) ApplicationCommands.SelectAll);
    commandBinding2.Executed += new ExecutedRoutedEventHandler(this.selectAllCommand_Executed);
    this.FindResultsList.CommandBindings.Add(commandBinding2);
  }

  private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
  {
    if (!(sender is ListViewItem listViewItem) || !(listViewItem.DataContext is FieldInfo dataContext))
      return;
    FeatureNode parent1 = dataContext.Field.Parent.Parent as FeatureNode;
    Recordset parent2 = parent1.Parent as Recordset;
    if (parent2.IsEmbeddedRecset && parent2.Contains(parent1))
    {
      parent1 = parent2.ParentSection.Parent as FeatureNode;
      parent2 = parent1.Parent as Recordset;
    }
    if (parent2.Contains(parent1) || dataContext.Field.Name == "BookmarkName" || dataContext.Field.Name == "BookmarkURL")
      Utility.FieldReportSelectionChanged(sender, dataContext);
    else
      AppInfoManager.StatusMsgReport.RegisterMessage(StatusMsgType.Error, AcpResources.Field_Not_Found.AcpStringFormat((object) dataContext.Name));
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
      foreach (FindResultInfo selectedItem in (IEnumerable) this.FindResultsList.SelectedItems)
      {
        stringBuilder.Append(selectedItem.Index.ToString() + "\t");
        stringBuilder.Append(selectedItem.Name + "\t");
        stringBuilder.Append(selectedItem.Path + "\t");
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
    this.FindResultsList.SelectAll();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/common/pagefindresults.xaml", UriKind.Relative));
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
        this.FindResultsList = (ListView) target;
        break;
      case 3:
        this.FindResultsGrid = (GridView) target;
        break;
      case 4:
        this.Num = (GridViewColumn) target;
        break;
      case 5:
        this.FieldName = (GridViewColumn) target;
        break;
      case 6:
        this.Path = (GridViewColumn) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
