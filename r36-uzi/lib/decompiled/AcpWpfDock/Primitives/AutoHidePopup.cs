// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.Primitives.AutoHidePopup
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfDock.Primitives;

internal class AutoHidePopup : Canvas
{
  private DockWindow m_DockWindow;

  public AutoHidePopup()
  {
    this.ClipToBounds = true;
    this.Focusable = true;
    this.FocusVisualStyle = (Style) null;
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    if (!(bool) e.NewValue && this.DockWindow != null)
    {
      DockWindowGroup group = this.GetGroup();
      if (group != null && group.OptionsContextMenu == Keyboard.FocusedElement && Keyboard.FocusedElement is ContextMenu)
      {
        group.OptionsContextMenu.Closed += new RoutedEventHandler(this.OptionsContextMenuClosed);
        return;
      }
      if (Keyboard.FocusedElement is ContextMenu)
      {
        (Keyboard.FocusedElement as ContextMenu).Closed += new RoutedEventHandler(this.OptionsContextMenuClosed);
        return;
      }
      if (this.m_DockWindow != null && Keyboard.FocusedElement is Window)
      {
        DockSite dockSite = this.m_DockWindow.GetDockSite();
        if (dockSite != null && dockSite.AutoHidePopupOverlay && Window.GetWindow((DependencyObject) dockSite) == Keyboard.FocusedElement)
          return;
      }
      if (!LayoutHelpers.IsMouseWithin((UIElement) this))
        this.DockWindow.AutoHideOpen = false;
    }
    base.OnIsKeyboardFocusWithinChanged(e);
  }

  private void OptionsContextMenuClosed(object sender, RoutedEventArgs e)
  {
    if (sender is ContextMenu contextMenu)
      contextMenu.Closed -= new RoutedEventHandler(this.OptionsContextMenuClosed);
    if (this.IsKeyboardFocusWithin)
      return;
    this.Focus();
  }

  public DockWindow DockWindow
  {
    get => this.m_DockWindow;
    set => this.m_DockWindow = value;
  }

  internal void AutoHideCloseAnimationCompleted(object sender, EventArgs e) => this.CleanupPopup();

  internal void CleanupPopup()
  {
    if (this.Parent is AutoHideAdorner parent)
      parent.Children.Remove((UIElement) this);
    if (this.Children.Count > 0 && this.Children[0] is SplitPanel)
    {
      SplitPanel child1 = this.Children[0] as SplitPanel;
      DockWindowGroup child2 = child1.Children[0] as DockWindowGroup;
      child2.SelectedContent = (object) null;
      child2.SelectedContentHeader = (object) null;
      child2.SelectedDockWindow = (DockWindow) null;
      child1.Children.Clear();
    }
    this.Children.Clear();
  }

  private DockWindowGroup GetGroup()
  {
    return this.Children.Count > 0 && this.Children[0] is SplitPanel ? (this.Children[0] as SplitPanel).Children[0] as DockWindowGroup : (DockWindowGroup) null;
  }
}
