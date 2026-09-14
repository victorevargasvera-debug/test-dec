// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPaneCustomizeButton
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using AcpCommonResources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class NavigationPaneCustomizeButton : Button
{
  private static readonly DependencyPropertyKey IsCustomizeMenuOpenPropertyKey;
  public static readonly DependencyProperty IsCustomizeMenuOpenProperty;

  static NavigationPaneCustomizeButton()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (NavigationPaneCustomizeButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (NavigationPaneCustomizeButton)));
    NavigationPaneCustomizeButton.IsCustomizeMenuOpenPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsCustomizeMenuOpen), typeof (bool), typeof (NavigationPaneCustomizeButton), new PropertyMetadata((object) false));
    NavigationPaneCustomizeButton.IsCustomizeMenuOpenProperty = NavigationPaneCustomizeButton.IsCustomizeMenuOpenPropertyKey.DependencyProperty;
  }

  protected override void OnPreviewMouseRightButtonUp(MouseButtonEventArgs e)
  {
    e.Handled = true;
    base.OnPreviewMouseRightButtonUp(e);
  }

  protected override void OnClick()
  {
    this.ContextMenu = this.FindResource((object) new ComponentResourceKey(typeof (NavigationPane), (object) "NavPaneCustomizeContextMenu")) as ContextMenu;
    this.SetupContextMenu();
    if (this.ContextMenu != null)
      this.ContextMenu.IsOpen = true;
    base.OnClick();
  }

  private void SetupContextMenu()
  {
    ContextMenu contextMenu = this.ContextMenu;
    if (contextMenu == null)
      return;
    NavigationPane navigationPane = this.GetNavigationPane();
    if (navigationPane == null)
      return;
    contextMenu.Closed += new RoutedEventHandler(this.CustomizeMenuClosed);
    contextMenu.Opened += new RoutedEventHandler(this.CustomizeMenuOpened);
    contextMenu.PlacementTarget = (UIElement) this;
    contextMenu.Placement = PlacementMode.Right;
    contextMenu.VerticalOffset = this.ActualHeight / 2.0;
    List<object> objectList = new List<object>();
    foreach (object obj1 in (IEnumerable) contextMenu.Items)
    {
      if (!(obj1 is MenuItem menuItem))
        objectList.Add(obj1);
      else if (menuItem.Header != null)
      {
        if ((string) menuItem.Header == NavigationPane.SystemAddRemoveMenuItem)
        {
          menuItem.Name = NavigationPane.SystemAddRemoveMenuItem;
          menuItem.Header = (object) navigationPane.SystemText.AddRemoveButtons;
          menuItem.Items.Clear();
          foreach (object obj2 in (IEnumerable) navigationPane.Items)
          {
            if (obj2 is PaneItem paneItem)
            {
              MenuItem newItem = new MenuItem();
              newItem.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "FlatMenuItem")) as Style;
              newItem.Header = CloningMachine.GetObjectCopy(paneItem.Header, false);
              newItem.Icon = CloningMachine.GetObjectCopy(paneItem.ImageSmall != null ? paneItem.ImageSmall : paneItem.Image, false);
              newItem.IsChecked = paneItem.Visibility == Visibility.Visible;
              newItem.Tag = (object) paneItem;
              newItem.Click += new RoutedEventHandler(this.ShowHidePaneItemClick);
              menuItem.Items.Add((object) newItem);
            }
          }
        }
        else if ((string) menuItem.Header == NavigationPane.SystemShowMoreButtonsMenuItem)
        {
          menuItem.Name = NavigationPane.SystemShowMoreButtonsMenuItem;
          navigationPane.SystemText.ShowMoreButtons = AcpResources.Show_More_Buttons;
          menuItem.Header = (object) navigationPane.SystemText.ShowMoreButtons;
          menuItem.Click += new RoutedEventHandler(this.ShowMoreButtonsClick);
          menuItem.IsEnabled = navigationPane.Items.Count > navigationPane.LargeItemsCount;
        }
        else if ((string) menuItem.Header == NavigationPane.SystemShowFewerButtonsMenuItem)
        {
          menuItem.Name = NavigationPane.SystemShowFewerButtonsMenuItem;
          navigationPane.SystemText.ShowFewerButtons = AcpResources.Show_Fewer_Buttons;
          menuItem.Header = (object) navigationPane.SystemText.ShowFewerButtons;
          menuItem.Click += new RoutedEventHandler(this.ShowFewerButtonsClick);
          menuItem.IsEnabled = navigationPane.LargeItemsCount > 0;
        }
        else if ((string) menuItem.Header == NavigationPane.SystemNavPaneOptionMenuItem)
        {
          menuItem.Name = NavigationPane.SystemNavPaneOptionMenuItem;
          menuItem.Header = (object) navigationPane.SystemText.NavigationPaneOptions;
          menuItem.Click += new RoutedEventHandler(this.ShowNavPaneOptions);
        }
        else if (menuItem.Tag is PaneItem)
          objectList.Add(obj1);
      }
    }
    foreach (object removeItem in objectList)
      contextMenu.Items.Remove(removeItem);
    bool flag = false;
    IEnumerator enumerator = ((IEnumerable) navigationPane.Items).GetEnumerator();
    try
    {
      while (enumerator.MoveNext() && enumerator.Current is PaneItem current)
      {
        if (LayoutInformation.GetLayoutSlot((FrameworkElement) current).X < -100.0)
        {
          MenuItem newItem1 = new MenuItem();
          newItem1.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "FlatMenuItem")) as Style;
          newItem1.Tag = (object) current;
          newItem1.Header = CloningMachine.GetObjectCopy(current.Header, false);
          newItem1.Icon = CloningMachine.GetObjectCopy(current.ImageSmall != null ? current.ImageSmall : current.Image, false);
          newItem1.IsChecked = current.IsSelected;
          newItem1.Click += new RoutedEventHandler(this.MenuItemSelectPaneClick);
          if (!flag)
          {
            Separator newItem2 = new Separator();
            newItem2.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "FlatSeparator")) as Style;
            contextMenu.Items.Add((object) newItem2);
            flag = true;
          }
          contextMenu.Items.Add((object) newItem1);
        }
      }
    }
    finally
    {
      if (enumerator is IDisposable disposable)
        disposable.Dispose();
    }
  }

  private void MenuItemSelectPaneClick(object sender, RoutedEventArgs e)
  {
    ((sender as MenuItem).Tag as PaneItem).IsSelected = true;
  }

  private void CustomizeMenuOpened(object sender, RoutedEventArgs e)
  {
    this.IsCustomizeMenuOpen = true;
  }

  private void ShowNavPaneOptions(object sender, RoutedEventArgs e)
  {
    this.GetNavigationPane().ShowOptionsDialog();
  }

  private void ShowMoreButtonsClick(object sender, RoutedEventArgs e)
  {
    ++this.GetNavigationPane().LargeItemsCount;
  }

  private void ShowFewerButtonsClick(object sender, RoutedEventArgs e)
  {
    --this.GetNavigationPane().LargeItemsCount;
  }

  private NavigationPane GetNavigationPane()
  {
    return this.Parent is NavigationPanePanel ? ((FrameworkElement) this.Parent).TemplatedParent as NavigationPane : (NavigationPane) null;
  }

  private void CustomizeMenuClosed(object sender, RoutedEventArgs e)
  {
    this.IsCustomizeMenuOpen = false;
    ContextMenu contextMenu = sender as ContextMenu;
    contextMenu.Closed -= new RoutedEventHandler(this.CustomizeMenuClosed);
    contextMenu.Opened -= new RoutedEventHandler(this.CustomizeMenuOpened);
    List<object> objectList = new List<object>();
    foreach (object obj in (IEnumerable) contextMenu.Items)
    {
      if (obj is MenuItem menuItem)
      {
        if (menuItem.Name == NavigationPane.SystemAddRemoveMenuItem)
        {
          menuItem.Header = (object) NavigationPane.SystemAddRemoveMenuItem;
          menuItem.Items.Clear();
        }
        else if (menuItem.Name == NavigationPane.SystemShowMoreButtonsMenuItem)
        {
          menuItem.Header = (object) NavigationPane.SystemShowMoreButtonsMenuItem;
          menuItem.Click -= new RoutedEventHandler(this.ShowMoreButtonsClick);
        }
        else if (menuItem.Name == NavigationPane.SystemShowFewerButtonsMenuItem)
        {
          menuItem.Header = (object) NavigationPane.SystemShowFewerButtonsMenuItem;
          menuItem.Click -= new RoutedEventHandler(this.ShowFewerButtonsClick);
        }
        else if (menuItem.Name == NavigationPane.SystemNavPaneOptionMenuItem)
        {
          menuItem.Header = (object) NavigationPane.SystemNavPaneOptionMenuItem;
          menuItem.Click -= new RoutedEventHandler(this.ShowNavPaneOptions);
        }
        else if (menuItem.Tag is PaneItem)
          objectList.Add((object) menuItem);
      }
      else if (obj is Separator)
        objectList.Add(obj);
    }
    foreach (object removeItem in objectList)
      contextMenu.Items.Remove(removeItem);
  }

  private void ShowHidePaneItemClick(object sender, RoutedEventArgs e)
  {
    MenuItem menuItem = sender as MenuItem;
    PaneItem tag = menuItem.Tag as PaneItem;
    if (menuItem.IsChecked)
      tag.Visibility = Visibility.Collapsed;
    else
      tag.Visibility = Visibility.Visible;
  }

  public bool IsCustomizeMenuOpen
  {
    get => (bool) this.GetValue(NavigationPaneCustomizeButton.IsCustomizeMenuOpenProperty);
    internal set
    {
      this.SetValue(NavigationPaneCustomizeButton.IsCustomizeMenuOpenPropertyKey, (object) value);
    }
  }
}
