// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.AdvWindow
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class AdvWindow : Window
{
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (AdvWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(AdvWindow.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (AdvWindow), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(AdvWindow.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = AdvWindow.EffectiveStylePropertyKey.DependencyProperty;
  public static RoutedCommand CloseWindow = new RoutedCommand(nameof (CloseWindow), typeof (AdvWindow));
  public static RoutedCommand MinimizeWindow = new RoutedCommand(nameof (MinimizeWindow), typeof (AdvWindow));
  public static RoutedCommand MaximizeWindow = new RoutedCommand(nameof (MaximizeWindow), typeof (AdvWindow));
  public static RoutedCommand RestoreWindow = new RoutedCommand(nameof (RestoreWindow), typeof (AdvWindow));
  private Border _WindowBorder;
  private ResizeGrip _ResizeGrip;
  private bool _SourceInitialized;
  private bool _SizingWindow;
  private const string PartWindowBorder = "PART_WindowBorder";
  private const string PartWindowResizeGrip = "WindowResizeGrip";
  public static readonly DependencyProperty EnableSystemCaptionMenuProperty = DependencyProperty.Register(nameof (EnableSystemCaptionMenu), typeof (bool), typeof (AdvWindow), (PropertyMetadata) new UIPropertyMetadata((object) true));
  private bool m_CursorIsSet;
  private bool _UpdatingWindowStyle;
  private bool _IsFirstLoad = true;

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(AdvWindow.VisualStyleProperty);
    set => this.SetValue(AdvWindow.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((AdvWindow) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
  }

  private void OnVisualStyleChanged(eRibbonVisualStyle oldValue, eRibbonVisualStyle newValue)
  {
    if (this.IsDesignMode)
      return;
    if (newValue == eRibbonVisualStyle.Office2010Silver || newValue == eRibbonVisualStyle.Office2010Blue || newValue == eRibbonVisualStyle.Office2010Black)
      this.EffectiveStyle = eEffectiveStyle.Office2010;
    else
      this.EffectiveStyle = eEffectiveStyle.Office2007;
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  public eEffectiveStyle EffectiveStyle
  {
    get => (eEffectiveStyle) this.GetValue(AdvWindow.EffectiveStyleProperty);
    internal set => this.SetValue(AdvWindow.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is AdvWindow advWindow))
      return;
    advWindow.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
  }

  static AdvWindow()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (AdvWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (AdvWindow)));
  }

  public bool EnableSystemCaptionMenu
  {
    get => (bool) this.GetValue(AdvWindow.EnableSystemCaptionMenuProperty);
    set => this.SetValue(AdvWindow.EnableSystemCaptionMenuProperty, (object) value);
  }

  public AdvWindow() => this.WindowStyle = WindowStyle.None;

  public override void OnApplyTemplate()
  {
    this._WindowBorder = this.GetTemplateChild("PART_WindowBorder") as Border;
    this._ResizeGrip = this.GetTemplateChild("WindowResizeGrip") as ResizeGrip;
    base.OnApplyTemplate();
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    if (e.OriginalSource is FrameworkElement && (((FrameworkElement) e.OriginalSource).Name == "WindowTitleText" || ((FrameworkElement) e.OriginalSource).Name == "WindowTitle"))
    {
      if (e.ClickCount == 2)
      {
        if (this.ResizeMode != ResizeMode.NoResize)
        {
          if (this.WindowState == WindowState.Maximized)
            AdvWindow.RestoreWindow.Execute((object) null, (IInputElement) null);
          else if (this.WindowState == WindowState.Normal)
            AdvWindow.MaximizeWindow.Execute((object) null, (IInputElement) null);
        }
      }
      else
      {
        this.StartWindowDragMove();
        e.Handled = true;
      }
    }
    else if (e.OriginalSource is FrameworkElement && ((FrameworkElement) e.OriginalSource).Name == "WinIcon")
    {
      if (e.ClickCount == 2)
        AdvWindow.CloseWindow.Execute((object) null, (IInputElement) null);
      else if (this.EnableSystemCaptionMenu)
      {
        FrameworkElement originalSource = e.OriginalSource as FrameworkElement;
        this.ShowTitleContextMenu(originalSource.PointToScreen(new System.Windows.Point(0.0, originalSource.ActualHeight)));
      }
      e.Handled = true;
    }
    base.OnMouseLeftButtonDown(e);
  }

  private void StartWindowDragMove()
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Background, (Delegate) new DispatcherOperationCallback(this.DispatcherStartWindowDragMove), (object) null);
  }

  private object DispatcherStartWindowDragMove(object arg)
  {
    Window window = (Window) this;
    if (Mouse.LeftButton == MouseButtonState.Pressed)
    {
      try
      {
        window.DragMove();
      }
      catch (InvalidOperationException ex)
      {
      }
    }
    return (object) null;
  }

  protected override void OnMouseRightButtonUp(MouseButtonEventArgs e)
  {
    if (this.EnableSystemCaptionMenu && e.OriginalSource is FrameworkElement && (((FrameworkElement) e.OriginalSource).Name == "WindowTitleText" || ((FrameworkElement) e.OriginalSource).Name == "WinIcon"))
    {
      this.ShowTitleContextMenu(this.PointToScreen(e.GetPosition((IInputElement) this)));
      e.Handled = true;
    }
    base.OnMouseRightButtonUp(e);
  }

  private void ShowTitleContextMenu(System.Windows.Point screenPos)
  {
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    byte[] bytes1 = BitConverter.GetBytes((int) screenPos.X);
    byte[] bytes2 = BitConverter.GetBytes((int) screenPos.Y);
    int int32 = BitConverter.ToInt32(new byte[4]
    {
      bytes1[0],
      bytes1[1],
      bytes2[0],
      bytes2[1]
    }, 0);
    WinApi.SendMessage(handle, 274, WinApi.TrackPopupMenu(WinApi.GetSystemMenu(handle, false), 256U /*0x0100*/, (int) screenPos.X, (int) screenPos.Y, 0, handle, IntPtr.Zero), int32);
  }

  protected override void OnPreviewMouseMove(MouseEventArgs e)
  {
    if (e.LeftButton == MouseButtonState.Released && e.RightButton == MouseButtonState.Released)
    {
      WinApi.SizingCommand commandFromPoint = this.GetSizingCommandFromPoint(e.GetPosition((IInputElement) this));
      if (commandFromPoint == WinApi.SizingCommand.None)
      {
        if (this.Cursor != null && this.m_CursorIsSet)
        {
          this.Cursor = (Cursor) null;
          this.m_CursorIsSet = false;
        }
      }
      else
      {
        Cursor cursor = (Cursor) null;
        switch (commandFromPoint - 1)
        {
          case WinApi.SizingCommand.None:
          case WinApi.SizingCommand.West:
            cursor = Cursors.SizeWE;
            break;
          case WinApi.SizingCommand.East:
          case WinApi.SizingCommand.NorthEast:
            cursor = Cursors.SizeNS;
            break;
          case WinApi.SizingCommand.North:
            cursor = Cursors.SizeNWSE;
            break;
          case WinApi.SizingCommand.NorthWest:
            cursor = Cursors.SizeNESW;
            break;
          case WinApi.SizingCommand.South:
            cursor = Cursors.SizeNESW;
            break;
          case WinApi.SizingCommand.SouthWest:
            cursor = Cursors.SizeNWSE;
            break;
        }
        if (cursor != null)
        {
          this.m_CursorIsSet = true;
          this.Cursor = cursor;
          e.Handled = true;
        }
      }
    }
    if (this._SizingWindow)
      e.Handled = true;
    base.OnPreviewMouseMove(e);
  }

  protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    WinApi.SizingCommand commandFromPoint = this.GetSizingCommandFromPoint(e.GetPosition((IInputElement) this));
    if (commandFromPoint != WinApi.SizingCommand.None)
    {
      this.StartResize(commandFromPoint);
      e.Handled = true;
    }
    base.OnPreviewMouseLeftButtonDown(e);
  }

  private WinApi.SizingCommand GetSizingCommandFromPoint(System.Windows.Point p)
  {
    if (this.WindowState != WindowState.Normal || this.ResizeMode == ResizeMode.NoResize || this.ResizeMode == ResizeMode.CanMinimize)
      return WinApi.SizingCommand.None;
    Rect rect = new Rect();
    if (this._ResizeGrip != null && this._ResizeGrip.Visibility == Visibility.Visible && this.ResizeMode == ResizeMode.CanResizeWithGrip)
    {
      System.Windows.Point point = this._ResizeGrip.PointFromScreen(this.PointToScreen(p));
      rect = new Rect(this._ResizeGrip.RenderSize);
      if (rect.Contains(point))
        return this.FlowDirection == FlowDirection.RightToLeft ? WinApi.SizingCommand.SouthWest : WinApi.SizingCommand.SouthEast;
    }
    Thickness resizeBorderThickness = this.GetResizeBorderThickness();
    rect = LayoutHelpers.DeflateRect(new Rect(0.0, 0.0, this.Width, this.Height), resizeBorderThickness);
    if (rect.Contains(p))
      return WinApi.SizingCommand.None;
    CornerRadius resizeCornerRadius = this.GetResizeCornerRadius();
    if (p.Y <= resizeBorderThickness.Top && p.Y >= 0.0 && p.X <= resizeCornerRadius.TopLeft && p.X >= 0.0)
      return WinApi.SizingCommand.NorthWest;
    if (p.Y < resizeCornerRadius.TopRight && p.X >= this.Width - resizeCornerRadius.TopRight)
      return WinApi.SizingCommand.NorthEast;
    if (p.Y >= this.Height - resizeCornerRadius.BottomLeft && p.Y <= this.Height && p.X <= resizeCornerRadius.BottomLeft && p.X >= 0.0)
      return WinApi.SizingCommand.SouthWest;
    if (p.Y >= this.Height - resizeCornerRadius.BottomRight && p.Y <= this.Height && p.X >= this.Width - resizeCornerRadius.BottomRight && p.X <= this.Width)
      return WinApi.SizingCommand.SouthEast;
    if (p.Y <= resizeBorderThickness.Top && p.Y >= 0.0)
      return WinApi.SizingCommand.North;
    if (p.X <= resizeBorderThickness.Left && p.X >= 0.0)
      return WinApi.SizingCommand.West;
    if (p.X >= this.Width - resizeBorderThickness.Right && p.X <= this.Width)
      return WinApi.SizingCommand.East;
    return p.Y >= this.Height - resizeBorderThickness.Bottom && p.Y <= this.Height ? WinApi.SizingCommand.South : WinApi.SizingCommand.None;
  }

  private Thickness GetResizeBorderThickness() => new Thickness(6.0, 6.0, 6.0, 6.0);

  private CornerRadius GetResizeCornerRadius() => new CornerRadius(7.0, 7.0, 7.0, 7.0);

  private void StartResize(WinApi.SizingCommand cmd)
  {
    if (Mouse.LeftButton != MouseButtonState.Pressed)
      return;
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    WinApi.SendMessage(handle, 274, (int) (61440 /*0xF000*/ + cmd), 0);
    WinApi.SendMessage(handle, 514, 0, 0);
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.CommandBindings.Add(new CommandBinding((ICommand) AdvWindow.CloseWindow, new ExecutedRoutedEventHandler(this.ExecuteCloseWindow), new CanExecuteRoutedEventHandler(this.CanExecuteCloseWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) AdvWindow.MinimizeWindow, new ExecutedRoutedEventHandler(this.ExecuteMinimizeWindow), new CanExecuteRoutedEventHandler(this.CanExecuteMinimizeWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) AdvWindow.MaximizeWindow, new ExecutedRoutedEventHandler(this.ExecuteMaximizeWindow), new CanExecuteRoutedEventHandler(this.CanExecuteMaximizeWindow)));
    this.CommandBindings.Add(new CommandBinding((ICommand) AdvWindow.RestoreWindow, new ExecutedRoutedEventHandler(this.ExecuteRestoreWindow), new CanExecuteRoutedEventHandler(this.CanExecuteRestoreWindow)));
    base.OnInitialized(e);
  }

  private void ExecuteCloseWindow(object sender, ExecutedRoutedEventArgs e)
  {
    this.Close();
    e.Handled = true;
  }

  private void CanExecuteCloseWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = true;
  }

  private void ExecuteMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
  {
    this.WindowState = WindowState.Minimized;
    e.Handled = true;
  }

  private void CanExecuteMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.WindowState != WindowState.Minimized;
  }

  private void ExecuteMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
  {
    this.WindowState = WindowState.Maximized;
    e.Handled = true;
  }

  private void CanExecuteMaximizeWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.WindowState != WindowState.Maximized;
  }

  private void ExecuteRestoreWindow(object sender, ExecutedRoutedEventArgs e)
  {
    this.WindowState = WindowState.Normal;
    e.Handled = true;
  }

  private void CanExecuteRestoreWindow(object sender, CanExecuteRoutedEventArgs e)
  {
    e.CanExecute = this.WindowState != 0;
  }

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    this._SourceInitialized = true;
    HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).AddHook(new HwndSourceHook(this.WindowMessageHandler));
    this.UpdateWindowStyle();
  }

  private void UpdateWindowStyle()
  {
    if (!this._SourceInitialized)
      return;
    if (this.WindowStyle != WindowStyle.None)
      this.WindowStyle = WindowStyle.None;
    this._UpdatingWindowStyle = true;
    try
    {
      if (this.WindowStyle != WindowStyle.None)
        this.WindowStyle = WindowStyle.None;
      IntPtr handle = new WindowInteropHelper((Window) this).Handle;
      HwndSource.FromHwnd(handle).CompositionTarget.BackgroundColor = Colors.Black;
      int windowLong = WinApi.GetWindowLong(handle, -16);
      WinApi.SetWindowLong(handle, -16, windowLong & ~(windowLong & 262144 /*0x040000*/));
      WinApi.SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, 39);
      this.UpdateRegion(false);
    }
    finally
    {
      this._UpdatingWindowStyle = false;
    }
  }

  private void UpdateRegion(bool redraw, WindowState windowState)
  {
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    int width = (int) this.Width + 1;
    int height = (int) this.Height + 1;
    if (this.SizeToContent != SizeToContent.Manual)
    {
      if (this.SizeToContent == SizeToContent.WidthAndHeight)
      {
        height = (int) Math.Ceiling(this.ActualHeight) + 1;
        width = (int) Math.Ceiling(this.ActualWidth) + 1;
      }
      else if (this.SizeToContent == SizeToContent.Width)
        width = (int) Math.Ceiling(this.ActualWidth) + 1;
      else if (this.SizeToContent == SizeToContent.Height)
        height = (int) Math.Ceiling(this.ActualHeight) + 1;
    }
    if (handle != IntPtr.Zero && this.SizeToContent == SizeToContent.Manual)
    {
      WinApi.RECT r = new WinApi.RECT();
      WinApi.GetWindowRect(handle, ref r);
      if (this.SizeToContent != SizeToContent.Manual)
      {
        if (this.SizeToContent == SizeToContent.Width || this.SizeToContent == SizeToContent.WidthAndHeight)
          height = r.Height + 1;
        if (this.SizeToContent == SizeToContent.Height || this.SizeToContent == SizeToContent.WidthAndHeight)
          width = r.Width + 1;
        if (this.SizeToContent == SizeToContent.WidthAndHeight && this._IsFirstLoad && this.WindowStyle == WindowStyle.None)
        {
          width -= (int) SystemParameters.ResizeFrameVerticalBorderWidth * 2 - 1;
          height -= (int) SystemParameters.ResizeFrameHorizontalBorderHeight * 2 - 1;
        }
      }
      else
      {
        width = r.Width + 1;
        height = r.Height + 1;
      }
    }
    this.UpdateRegion(redraw, width, height, windowState);
  }

  private void UpdateRegion(bool redraw) => this.UpdateRegion(redraw, this.WindowState);

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    base.OnRenderSizeChanged(sizeInfo);
    if (this.SizeToContent == SizeToContent.Manual)
      return;
    this.UpdateRegion(false);
  }

  private void UpdateRegion(bool redraw, int width, int height, WindowState windowState)
  {
    if (windowState == WindowState.Minimized || this._WindowBorder == null)
      return;
    CornerRadius cornerRadius = this._WindowBorder.CornerRadius;
    if (cornerRadius.BottomLeft > 0.0)
      ++cornerRadius.BottomLeft;
    if (cornerRadius.BottomRight > 0.0)
      ++cornerRadius.BottomRight;
    if (cornerRadius.TopLeft > 0.0)
      ++cornerRadius.TopLeft;
    if (cornerRadius.TopRight > 0.0)
      ++cornerRadius.TopRight;
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    IntPtr hrgnDest = IntPtr.Zero;
    if (windowState != WindowState.Maximized)
    {
      if (cornerRadius.BottomLeft == cornerRadius.BottomRight && cornerRadius.BottomLeft == cornerRadius.TopLeft && cornerRadius.BottomLeft == cornerRadius.TopRight && cornerRadius.BottomLeft >= 1.0)
        hrgnDest = WinApi.CreateRoundRectRgn(0, 0, width, height, (int) cornerRadius.BottomLeft, (int) cornerRadius.BottomLeft);
      else if (cornerRadius.BottomLeft >= 1.0 || cornerRadius.BottomRight >= 1.0 || cornerRadius.TopLeft >= 1.0 || cornerRadius.TopRight >= 1.0)
      {
        IntPtr zero1 = IntPtr.Zero;
        IntPtr zero2 = IntPtr.Zero;
        IntPtr zero3 = IntPtr.Zero;
        IntPtr zero4 = IntPtr.Zero;
        int num1 = width - (int) Math.Max(cornerRadius.TopRight, cornerRadius.BottomRight);
        int num2 = height - (int) Math.Max(Math.Max(cornerRadius.BottomLeft, cornerRadius.BottomRight), Math.Max(cornerRadius.TopLeft, cornerRadius.TopRight));
        IntPtr num3 = (int) cornerRadius.TopLeft < 1 ? WinApi.CreateRectRgn(0, 0, num1, num2) : WinApi.CreateRoundRectRgn(0, 0, num1, num2, (int) cornerRadius.TopLeft, (int) cornerRadius.TopLeft);
        int num4 = width - (int) Math.Max(cornerRadius.TopLeft, cornerRadius.BottomLeft);
        IntPtr num5 = (int) cornerRadius.TopRight < 1 ? WinApi.CreateRectRgn(width - num4, 0, width, num2) : WinApi.CreateRoundRectRgn(width - num4, 0, width, num2, (int) cornerRadius.TopRight, (int) cornerRadius.TopRight);
        int num6 = width - (int) Math.Max(cornerRadius.TopRight, cornerRadius.BottomRight);
        int num7 = height - (int) Math.Max(cornerRadius.TopLeft, cornerRadius.TopRight);
        IntPtr num8 = (int) cornerRadius.BottomLeft < 1 ? WinApi.CreateRectRgn(0, height - num7, num6, height) : WinApi.CreateRoundRectRgn(0, height - num7, num6, height, (int) cornerRadius.BottomLeft, (int) cornerRadius.BottomLeft);
        int num9 = width - (int) Math.Max(cornerRadius.TopLeft, cornerRadius.BottomLeft);
        IntPtr num10 = (int) cornerRadius.BottomRight < 1 ? WinApi.CreateRectRgn(width - num9, height - num7, width, height) : WinApi.CreateRoundRectRgn(width - num9, height - num7, width, height, (int) cornerRadius.BottomRight, (int) cornerRadius.BottomRight);
        hrgnDest = WinApi.CreateRectRgn(0, 0, 0, 0);
        IntPtr rectRgn1 = WinApi.CreateRectRgn(0, 0, 0, 0);
        IntPtr rectRgn2 = WinApi.CreateRectRgn(0, 0, 0, 0);
        WinApi.CombineRgn(rectRgn1, num3, num5, 2);
        WinApi.CombineRgn(rectRgn2, num8, num10, 2);
        WinApi.CombineRgn(hrgnDest, rectRgn1, rectRgn2, 2);
        WinApi.DeleteObject(rectRgn1);
        WinApi.DeleteObject(rectRgn2);
        WinApi.DeleteObject(num3);
        WinApi.DeleteObject(num5);
        WinApi.DeleteObject(num8);
        WinApi.DeleteObject(num10);
      }
    }
    IntPtr hRgn = hrgnDest;
    int num = redraw ? 1 : 0;
    WinApi.SetWindowRgn(handle, hRgn, num != 0);
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
      case 5:
        num = this.WmSize(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 36:
        num = this.WmGetMinMaxInfo(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 132:
        num = this.WmNcHitTest(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 561:
        num = this.WmEnterSizeMove(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 562:
        num = this.WmExitSizeMove(hwnd, msg, wParam, lParam, ref handled);
        break;
    }
    return num;
  }

  private IntPtr WmGetMinMaxInfo(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    WinApi.MINMAXINFO structure = (WinApi.MINMAXINFO) Marshal.PtrToStructure(lParam, typeof (WinApi.MINMAXINFO));
    int flags = 2;
    IntPtr hMonitor = WinApi.MonitorFromWindow(hwnd, flags);
    if (hMonitor != IntPtr.Zero)
    {
      WinApi.MONITORINFO lpmi = new WinApi.MONITORINFO();
      WinApi.GetMonitorInfo(hMonitor, lpmi);
      WinApi.RECT rcWork = lpmi.rcWork;
      WinApi.RECT rcMonitor = lpmi.rcMonitor;
      structure.ptMaxPosition.x = Math.Abs(rcWork.Left - rcMonitor.Left);
      structure.ptMaxPosition.y = Math.Abs(rcWork.Top - rcMonitor.Top) - 3;
      structure.ptMaxSize.x = Math.Abs(rcWork.Right - rcWork.Left);
      structure.ptMaxSize.y = Math.Abs(rcWork.Bottom - rcWork.Top) + (rcMonitor.Height == rcWork.Height ? 2 : 5);
    }
    structure.ptMinTrackSize = new WinApi.POINT(this.MinWidth > 0.0 ? (int) this.MinWidth : 160 /*0xA0*/, this.MinHeight > 0.0 ? (int) this.MinHeight : 38);
    Marshal.StructureToPtr<WinApi.MINMAXINFO>(structure, lParam, true);
    handled = true;
    return IntPtr.Zero;
  }

  private IntPtr WmSizing(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
  {
    WinApi.RECT structure = (WinApi.RECT) Marshal.PtrToStructure(lParam, typeof (WinApi.RECT));
    this.UpdateRegion(true, structure.Width + 1, structure.Height + 1, this.WindowState);
    return IntPtr.Zero;
  }

  private IntPtr WmEnterSizeMove(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    this._SizingWindow = true;
    return IntPtr.Zero;
  }

  private IntPtr WmExitSizeMove(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    this._SizingWindow = false;
    this.UpdateRegion(true);
    return IntPtr.Zero;
  }

  private IntPtr WmSize(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
  {
    switch (wParam.ToInt32())
    {
      case 0:
      case 2:
        if (this._SourceInitialized && !this._UpdatingWindowStyle)
        {
          this.UpdateRegion(true, WinApi.WindowStateFromParam(wParam));
          this._IsFirstLoad = false;
          break;
        }
        break;
    }
    return IntPtr.Zero;
  }

  private IntPtr WmNcHitTest(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    int x = WinApi.LOWORD(lParam);
    int y = WinApi.HIWORD(lParam);
    if (this._ResizeGrip == null || this._ResizeGrip.Visibility != Visibility.Visible || this.ResizeMode != ResizeMode.CanResizeWithGrip || this.WindowState != WindowState.Normal || !new Rect(this._ResizeGrip.RenderSize).Contains(this._ResizeGrip.PointFromScreen(new System.Windows.Point((double) x, (double) y))))
      return IntPtr.Zero;
    handled = true;
    return new IntPtr(1);
  }
}
