// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.FloatingWindow
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

#nullable disable
namespace DevComponents.WpfDock;

[DesignTimeVisible(false)]
public class FloatingWindow : Window
{
  private DockSite m_DockSite;
  private Point m_MouseDownPoint;
  private bool m_WindowMove;
  private bool _SourceInitialized;
  private bool _CanClose;

  static FloatingWindow()
  {
    EventManager.RegisterClassHandler(typeof (FloatingWindow), DockWindow.ActivatedEvent, (Delegate) new RoutedEventHandler(FloatingWindow.DockWindowActivated));
    EventManager.RegisterClassHandler(typeof (FloatingWindow), DockWindow.DeactivatedEvent, (Delegate) new RoutedEventHandler(FloatingWindow.DockWindowDeactivated));
  }

  public FloatingWindow()
  {
    this.WindowStyle = WindowStyle.ToolWindow;
    this.ShowInTaskbar = false;
  }

  private static void DockWindowActivated(object sender, RoutedEventArgs e)
  {
    ((FloatingWindow) sender).OnDockWindowActivated(e.OriginalSource as DockWindow);
  }

  private void OnDockWindowActivated(DockWindow dockWindow)
  {
    if (this.m_DockSite == null)
      return;
    this.m_DockSite.RaiseEvent(new RoutedEventArgs(DockWindow.ActivatedEvent, (object) dockWindow));
  }

  private static void DockWindowDeactivated(object sender, RoutedEventArgs e)
  {
    ((FloatingWindow) sender).OnDockWindowDeactivated(e.OriginalSource as DockWindow);
  }

  private void OnDockWindowDeactivated(DockWindow dockWindow)
  {
    if (this.m_DockSite == null)
      return;
    this.m_DockSite.RaiseEvent(new RoutedEventArgs(DockWindow.DeactivatedEvent, (object) dockWindow));
  }

  [Browsable(false)]
  public DockSite DockSite
  {
    get => this.m_DockSite;
    internal set => this.m_DockSite = value;
  }

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).AddHook(new HwndSourceHook(this.WindowMessageHandler));
    this._SourceInitialized = true;
    this.UpdateCanClose();
  }

  private IntPtr WindowMessageHandler(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    IntPtr num = IntPtr.Zero;
    switch (msg)
    {
      case 163:
        num = this.WmNcLButtonDblClick(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 274:
        num = this.WmSysCommand(hwnd, msg, wParam, lParam, ref handled);
        break;
    }
    return num;
  }

  private IntPtr WmSysCommand(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    if (wParam == (IntPtr) 61536)
    {
      int num = WinApi.HIWORD(lParam);
      if (this.Content is DockWindowGroup content && content.SelectedDockWindow != null)
      {
        eEventActionSource actionSource = eEventActionSource.Mouse;
        if (num == 0 || num == -1)
          actionSource = eEventActionSource.Keyboard;
        content.SelectedDockWindow.Close(actionSource);
        handled = true;
      }
    }
    else if (wParam == (IntPtr) 61458)
    {
      int num = WinApi.HIWORD(lParam);
      if (this.Content is DockWindowGroup content && content.SelectedDockWindow != null || this.Content is SplitPanel)
      {
        eEventActionSource eventActionSource = eEventActionSource.Mouse;
        if (num == 0 || num == -1)
          eventActionSource = eEventActionSource.Keyboard;
        if (eventActionSource == eEventActionSource.Mouse)
        {
          this.m_WindowMove = true;
          this.CaptureMouse();
          handled = true;
        }
      }
    }
    return IntPtr.Zero;
  }

  protected override void OnLostMouseCapture(MouseEventArgs e)
  {
    this.m_MouseDownPoint = new Point();
    this.m_WindowMove = false;
    base.OnLostMouseCapture(e);
  }

  protected override void OnPreviewMouseUp(MouseButtonEventArgs e)
  {
    if (this.m_WindowMove)
    {
      if (Mouse.Captured == this)
        this.ReleaseMouseCapture();
      else
        this.m_WindowMove = false;
    }
    base.OnPreviewMouseUp(e);
  }

  protected override void OnPreviewMouseMove(MouseEventArgs e)
  {
    if (Mouse.Captured == this && this.m_WindowMove)
    {
      if (LayoutHelpers.IsEmpty(this.m_MouseDownPoint))
      {
        this.m_MouseDownPoint = e.GetPosition((IInputElement) this);
      }
      else
      {
        Point position = e.GetPosition((IInputElement) this);
        if (Math.Abs(position.X - this.m_MouseDownPoint.X) > 0.0 || Math.Abs(position.Y - this.m_MouseDownPoint.Y) > 0.0)
        {
          this.ReleaseMouseCapture();
          DockWindowGroup dockWindowGroup = (DockWindowGroup) null;
          if (this.Content is DockWindowGroup)
            dockWindowGroup = this.Content as DockWindowGroup;
          else if (this.Content is SplitPanel)
          {
            foreach (UIElement child in (Collection<UIElement>) (this.Content as SplitPanel).Children)
            {
              if (child.Visibility == Visibility.Visible && child is DockWindowGroup)
              {
                dockWindowGroup = child as DockWindowGroup;
                break;
              }
            }
          }
          this.m_DockSite.StartDockWindowDrag(dockWindowGroup, false, eEventActionSource.Mouse);
        }
      }
    }
    base.OnPreviewMouseMove(e);
  }

  private IntPtr WmNcLButtonDblClick(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    handled = true;
    if (!this.m_DockSite.IsDockingInProgress)
      this.m_DockSite.RestoreLastDockPosition(this.Content as DockWindowGroup, true, eEventActionSource.Mouse);
    return IntPtr.Zero;
  }

  protected override void OnClosed(EventArgs e)
  {
    if (this.m_DockSite != null)
      this.m_DockSite.FloatingWindowClosed(this);
    base.OnClosed(e);
  }

  internal bool CanClose
  {
    get => this._CanClose;
    set
    {
      if (this._CanClose == value)
        return;
      this._CanClose = value;
      if (!this._SourceInitialized)
        return;
      this.UpdateCanClose();
    }
  }

  private void UpdateCanClose()
  {
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    if (handle == IntPtr.Zero)
      return;
    WinApi.EnableMenuItem(WinApi.GetSystemMenu(handle, false), 61536U, !this._CanClose ? 1U : 0U);
  }
}
