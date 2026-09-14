// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonWindow
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonWindow : Window
{
  public static readonly DependencyProperty EnableGlassProperty;
  public static readonly DependencyProperty IsUsingGlassProperty;
  private static readonly DependencyPropertyKey IsUsingGlassPropertyKey;
  private bool m_IsGlassEnabled;
  private Ribbon m_RibbonControl;
  private bool m_SourceInitialized;
  private const string PartWindowBorder = "PART_WindowBorder";
  private const string PartWindowResizeGrip = "WindowResizeGrip";
  private WindowBorder m_Border;
  private bool m_SizingWindow;
  private ResizeGrip m_ResizeGrip;
  internal static double MaximizedGlassTopAdjustment = 3.0;
  private bool m_CursorIsSet;
  internal static bool SiziningWindowInProgress = false;
  private double _LastTopPosition;
  private bool _WasMaximized;
  private WindowState m_PreviousWindowState;
  private bool _GlassSizeAdjusted;

  static RibbonWindow()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (RibbonWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (RibbonWindow)));
    RibbonWindow.EnableGlassProperty = DependencyProperty.Register(nameof (EnableGlass), typeof (bool), typeof (RibbonWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonWindow.EnableGlassChanged)));
    RibbonWindow.IsUsingGlassPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsUsingGlass), typeof (bool), typeof (RibbonWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    RibbonWindow.IsUsingGlassProperty = RibbonWindow.IsUsingGlassPropertyKey.DependencyProperty;
  }

  public RibbonWindow() => this.m_IsGlassEnabled = this.GetGlassEnabled();

  public override void OnApplyTemplate()
  {
    this.m_Border = this.GetTemplateChild("PART_WindowBorder") as WindowBorder;
    this.m_ResizeGrip = this.GetTemplateChild("WindowResizeGrip") as ResizeGrip;
    if (this.IsGlassEnabled && this.m_RibbonControl != null && this.m_Border != null)
      this.m_Border.TransparentMargin = new Thickness(0.0, this.m_RibbonControl.GetTitleChromeHeight(), 0.0, 0.0);
    if (this.WindowState == WindowState.Maximized && this.m_PreviousWindowState != this.WindowState)
      this.HandleWindowStateChanged();
    base.OnApplyTemplate();
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
    if (this.m_SizingWindow)
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

  private WinApi.SizingCommand GetSizingCommandFromPoint(Point p)
  {
    if (this.WindowState != WindowState.Normal || this.ResizeMode == ResizeMode.NoResize)
      return WinApi.SizingCommand.None;
    Rect rect = new Rect();
    if (this.m_ResizeGrip != null && this.m_ResizeGrip.Visibility == Visibility.Visible && this.ResizeMode == ResizeMode.CanResizeWithGrip)
    {
      Point point = this.m_ResizeGrip.PointFromScreen(this.PointToScreen(p));
      rect = new Rect(this.m_ResizeGrip.RenderSize);
      if (rect.Contains(point))
        return this.FlowDirection == FlowDirection.RightToLeft ? WinApi.SizingCommand.SouthWest : WinApi.SizingCommand.SouthEast;
    }
    Thickness resizeBorderThickness = this.GetResizeBorderThickness();
    Size size = new Size(this.ActualWidth, this.ActualHeight);
    rect = LayoutHelpers.DeflateRect(new Rect(0.0, 0.0, size.Width, size.Height), resizeBorderThickness);
    if (rect.Contains(p))
      return WinApi.SizingCommand.None;
    CornerRadius resizeCornerRadius = this.GetResizeCornerRadius();
    if (p.Y <= resizeBorderThickness.Top && p.Y >= 0.0 && p.X <= resizeCornerRadius.TopLeft && p.X >= 0.0)
      return WinApi.SizingCommand.NorthWest;
    if (p.Y < resizeCornerRadius.TopRight && p.X >= size.Width - resizeCornerRadius.TopRight)
      return WinApi.SizingCommand.NorthEast;
    if (p.Y >= size.Height - resizeCornerRadius.BottomLeft && p.Y <= size.Height && p.X <= resizeCornerRadius.BottomLeft && p.X >= 0.0)
      return WinApi.SizingCommand.SouthWest;
    if (p.Y >= size.Height - resizeCornerRadius.BottomRight && p.Y <= size.Height && p.X >= size.Width - resizeCornerRadius.BottomRight && p.X <= size.Width)
      return WinApi.SizingCommand.SouthEast;
    if (p.Y <= resizeBorderThickness.Top && p.Y >= 0.0)
      return WinApi.SizingCommand.North;
    if (p.X <= resizeBorderThickness.Left && p.X >= 0.0)
      return WinApi.SizingCommand.West;
    if (p.X >= size.Width - resizeBorderThickness.Right && p.X <= size.Width)
      return WinApi.SizingCommand.East;
    return p.Y >= size.Height - resizeBorderThickness.Bottom && p.Y <= size.Height ? WinApi.SizingCommand.South : WinApi.SizingCommand.None;
  }

  private Thickness GetResizeBorderThickness() => new Thickness(5.0, 5.0, 5.0, 5.0);

  private CornerRadius GetResizeCornerRadius() => new CornerRadius(6.0, 6.0, 6.0, 6.0);

  private void StartResize(WinApi.SizingCommand cmd)
  {
    if (Mouse.LeftButton != MouseButtonState.Pressed)
      return;
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    WinApi.SendMessage(handle, 274, (int) (61440 /*0xF000*/ + cmd), 0);
    WinApi.SendMessage(handle, 514, 0, 0);
  }

  private bool SizingWindow
  {
    get => this.m_SizingWindow;
    set
    {
      this.m_SizingWindow = value;
      RibbonWindow.SiziningWindowInProgress = value;
    }
  }

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    this.m_SourceInitialized = true;
    HwndSource.FromHwnd(new WindowInteropHelper((Window) this).Handle).AddHook(new HwndSourceHook(this.WindowMessageHandler));
    this.UpdateWindowStyle();
  }

  private void UpdateWindowStyle()
  {
    if (!this.m_SourceInitialized)
      return;
    if (this.IsGlassEnabled)
    {
      this.IsUsingGlass = true;
      IntPtr handle = new WindowInteropHelper((Window) this).Handle;
      WinApi.SetWindowRgn(handle, IntPtr.Zero, false);
      int windowLong = WinApi.GetWindowLong(handle, -16);
      if ((windowLong & 262144 /*0x040000*/) == 0)
      {
        int dwNewLong = windowLong | 262144 /*0x040000*/;
        WinApi.SetWindowLong(handle, -16, dwNewLong);
        WinApi.SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, 39);
      }
      if (this.WindowStyle == WindowStyle.None)
        this.WindowStyle = WindowStyle.SingleBorderWindow;
      this.UpdateGlass();
    }
    else
    {
      if (this.WindowStyle != WindowStyle.None)
        this.WindowStyle = WindowStyle.None;
      IntPtr handle = new WindowInteropHelper((Window) this).Handle;
      HwndSource.FromHwnd(handle).CompositionTarget.BackgroundColor = Colors.Black;
      if (this.m_RibbonControl != null && this.m_RibbonControl.IsUsingGlass)
        this.m_RibbonControl.IsUsingGlass = false;
      int windowLong = WinApi.GetWindowLong(handle, -16);
      WinApi.SetWindowLong(handle, -16, windowLong & ~(windowLong & 262144 /*0x040000*/));
      WinApi.SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, 39);
      if (this.m_Border != null)
        this.m_Border.TransparentMargin = new Thickness(0.0);
      this.UpdateRegion(false);
      this.IsUsingGlass = false;
    }
  }

  private void UpdateRegion(bool redraw)
  {
    if (this.IsGlassEnabled)
      return;
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
    if (handle != IntPtr.Zero)
    {
      WinApi.RECT r = new WinApi.RECT();
      WinApi.GetWindowRect(handle, ref r);
      if (this.SizeToContent != SizeToContent.Manual)
      {
        if (this.SizeToContent == SizeToContent.Width)
          height = r.Height + 1;
        else if (this.SizeToContent == SizeToContent.Height)
          width = r.Width + 1;
      }
      else
      {
        width = r.Width + 1;
        height = r.Height + 1;
      }
    }
    this.UpdateRegion(redraw, width, height);
  }

  private void UpdateRegion(bool redraw, int width, int height)
  {
    if (this.WindowState == WindowState.Minimized)
      return;
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    IntPtr num1 = IntPtr.Zero;
    if (this.WindowState != WindowState.Maximized)
      num1 = WinApi.CreateRoundRectRgn(0, 0, width, height, 7, 7);
    IntPtr hRgn = num1;
    int num2 = redraw ? 1 : 0;
    WinApi.SetWindowRgn(handle, hRgn, num2 != 0);
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
      case 131:
        num = this.WmNcCalcSize(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 132:
        num = this.WmNcHitTest(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 161:
        num = this.WmNcLButtonDown(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 561:
        num = this.WmEnterSizeMove(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 562:
        num = this.WmExitSizeMove(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 798:
        num = this.WmDwmCompositionChanged(hwnd, msg, wParam, lParam, ref handled);
        break;
      case 1125:
        this.Top = (double) wParam.ToInt32();
        handled = true;
        break;
    }
    return num;
  }

  private IntPtr WmNcLButtonDown(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    if (wParam.ToInt32() != 3 || this.RibbonControl != null && this.RibbonControl.EffectiveStyle == eEffectiveStyle.Office2010)
      return IntPtr.Zero;
    handled = true;
    return IntPtr.Zero;
  }

  private IntPtr WmNcCalcSize(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    IntPtr num = IntPtr.Zero;
    if (this.IsGlassEnabled)
    {
      if (wParam == IntPtr.Zero)
      {
        WinApi.RECT structure = (WinApi.RECT) Marshal.PtrToStructure(lParam, typeof (WinApi.RECT));
        Marshal.StructureToPtr<WinApi.RECT>(WinApi.RECT.FromRectangle(this.GetGlassClientRectangle(hwnd, structure.ToRectangle())), lParam, false);
        num = IntPtr.Zero;
      }
      else
      {
        WinApi.NCCALCSIZE_PARAMS structure1 = (WinApi.NCCALCSIZE_PARAMS) Marshal.PtrToStructure(lParam, typeof (WinApi.NCCALCSIZE_PARAMS));
        WinApi.WINDOWPOS structure2 = (WinApi.WINDOWPOS) Marshal.PtrToStructure(structure1.lppos, typeof (WinApi.WINDOWPOS));
        WinApi.RECT rect = WinApi.RECT.FromRectangle(this.GetGlassClientRectangle(hwnd, new Rect((double) structure2.x, (double) structure2.y, (double) structure2.cx, (double) structure2.cy)));
        structure1.rgrc0 = rect;
        structure1.rgrc1 = rect;
        Marshal.StructureToPtr<WinApi.NCCALCSIZE_PARAMS>(structure1, lParam, false);
        num = new IntPtr(1024 /*0x0400*/);
      }
      handled = true;
    }
    return num;
  }

  protected virtual Rect GetGlassClientRectangle(IntPtr hwnd, Rect r)
  {
    Size frameBorderSize = WinApi.FrameBorderSize;
    int multiplierFactor = WinApi.BorderMultiplierFactor;
    int num1 = (int) frameBorderSize.Width * multiplierFactor;
    int num2 = (int) frameBorderSize.Height * multiplierFactor;
    double dpiMultiplier = this.DpiMultiplier;
    if (dpiMultiplier >= 1.5)
    {
      double num3 = 1.0 - Math.Abs(dpiMultiplier - 1.0);
      num1 = (int) (num3 * (double) num1);
      num2 = (int) (num3 * (double) num2);
    }
    r.X += (double) num1;
    r.Width = Math.Max(2.0, r.Width - (double) (num1 * 2));
    r.Height = Math.Max(2.0, r.Height - (double) num2);
    if ((this.WindowState == WindowState.Maximized || WinApi.IsZoomed(hwnd)) && this.IsGlassEnabled)
    {
      int flags = 2;
      IntPtr hMonitor = WinApi.MonitorFromWindow(hwnd, flags);
      if (hMonitor != IntPtr.Zero)
      {
        WinApi.MONITORINFO lpmi = new WinApi.MONITORINFO();
        WinApi.GetMonitorInfo(hMonitor, lpmi);
        WinApi.RECT rcWork = lpmi.rcWork;
        WinApi.RECT rcMonitor = lpmi.rcMonitor;
        if (r.Height > (double) rcWork.Height)
          r.Height = (double) Math.Max(2, rcWork.Height + num2 - 2);
      }
    }
    return r;
  }

  private IntPtr WmDwmCompositionChanged(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    this.m_IsGlassEnabled = this.GetGlassEnabled();
    this.UpdateWindowStyle();
    return IntPtr.Zero;
  }

  private IntPtr WmGetMinMaxInfo(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    if (this.IsGlassEnabled)
      return IntPtr.Zero;
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
      if (rcWork.Left > 0 && rcWork.Right - rcWork.Left > rcWork.Left)
        return IntPtr.Zero;
    }
    structure.ptMinTrackSize = new WinApi.POINT(this.MinWidth > 0.0 ? (int) this.MinWidth : 160 /*0xA0*/, this.MinHeight > 0.0 ? (int) this.MinHeight : 38);
    Marshal.StructureToPtr<WinApi.MINMAXINFO>(structure, lParam, true);
    handled = true;
    return IntPtr.Zero;
  }

  private IntPtr WmSizing(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
  {
    WinApi.RECT structure = (WinApi.RECT) Marshal.PtrToStructure(lParam, typeof (WinApi.RECT));
    this.UpdateRegion(true, structure.Width + 1, structure.Height + 1);
    return IntPtr.Zero;
  }

  private IntPtr WmEnterSizeMove(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    this.SizingWindow = true;
    return IntPtr.Zero;
  }

  private IntPtr WmExitSizeMove(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    this.SizingWindow = false;
    this.UpdateRegion(true);
    return IntPtr.Zero;
  }

  protected override void OnLocationChanged(EventArgs e)
  {
    if (this.WindowState != WindowState.Minimized && this.Top > -32000.0)
      this._LastTopPosition = this.Top + 28.0;
    base.OnLocationChanged(e);
  }

  private IntPtr WmSize(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
  {
    int int32 = wParam.ToInt32();
    if (int32 == 2 || int32 == 0)
    {
      this.UpdateRegion(true);
      switch (int32)
      {
        case 0:
          if (this._WasMaximized)
          {
            int flags = 2;
            IntPtr hMonitor = WinApi.MonitorFromWindow(hwnd, flags);
            if (hMonitor != IntPtr.Zero)
            {
              WinApi.MONITORINFO lpmi = new WinApi.MONITORINFO();
              WinApi.GetMonitorInfo(hMonitor, lpmi);
              WinApi.RECT rcWork = lpmi.rcWork;
              WinApi.RECT rcMonitor = lpmi.rcMonitor;
              if (this._LastTopPosition < (double) rcWork.Top)
                WinApi.PostMessage(hwnd, 1125, rcWork.Top, 0);
            }
          }
          this._WasMaximized = false;
          break;
        case 2:
          this._WasMaximized = true;
          break;
      }
    }
    else
    {
      switch (int32)
      {
        case 1:
          this._WasMaximized = false;
          break;
        case 2:
          this._WasMaximized = true;
          break;
      }
    }
    return IntPtr.Zero;
  }

  [DllImport("user32.dll")]
  private static extern bool MoveWindow(
    IntPtr hWnd,
    int X,
    int Y,
    int nWidth,
    int nHeight,
    bool bRepaint);

  private IntPtr WmNcHitTest(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    ref bool handled)
  {
    int x = WinApi.LOWORD(lParam);
    int y1 = WinApi.HIWORD(lParam);
    if (this.m_ResizeGrip != null && this.m_ResizeGrip.Visibility == Visibility.Visible && this.ResizeMode == ResizeMode.CanResizeWithGrip && this.WindowState == WindowState.Normal && this.ResizeMode != ResizeMode.NoResize && new Rect(this.m_ResizeGrip.RenderSize).Contains(this.m_ResizeGrip.PointFromScreen(new Point((double) x, (double) y1))))
    {
      handled = true;
      return new IntPtr(1);
    }
    Point point = this.PointFromScreen(new Point((double) x, (double) y1));
    if (new Rect(4.0, 4.0, 16.0, 16.0).Contains(point))
    {
      handled = true;
      return this.RibbonControl != null && this.RibbonControl.EffectiveStyle == eEffectiveStyle.Office2010 ? new IntPtr(3) : new IntPtr(1);
    }
    if (!this.IsGlassEnabled)
      return IntPtr.Zero;
    int y2 = (int) WinApi.FrameBorderSize.Width * WinApi.BorderMultiplierFactor;
    IntPtr plResult = IntPtr.Zero;
    WinApi.DwmDefWindowProc(hwnd, msg, wParam, lParam, out plResult);
    int int32 = plResult.ToInt32();
    if (int32 == 8 || int32 == 9 || int32 == 20 || int32 == 8 || int32 == 21)
    {
      handled = true;
      return plResult;
    }
    if (this.ResizeMode == ResizeMode.NoResize)
    {
      handled = true;
      return IntPtr.Zero;
    }
    if (new Rect(this.ActualWidth - 120.0, (double) y2, (double) (120 - y2 * 2), 43.0).Contains(point))
    {
      handled = true;
      return new IntPtr(1);
    }
    handled = false;
    return IntPtr.Zero;
  }

  private bool IsGlassEnabled => this.m_IsGlassEnabled && this.EnableGlass;

  private bool GetGlassEnabled() => WinApi.IsGlassEnabled;

  private double DpiMultiplier
  {
    get
    {
      double dpiMultiplier = 1.0;
      Point resolution = LayoutHelpers.GetResolution((Visual) this);
      if (resolution.Y != 96.0)
        dpiMultiplier += (resolution.Y - 96.0) / 96.0;
      return dpiMultiplier;
    }
  }

  protected override void OnStateChanged(EventArgs e)
  {
    base.OnStateChanged(e);
    this.HandleWindowStateChanged();
  }

  private void HandleWindowStateChanged()
  {
    if (this.IsGlassEnabled && (this.WindowState == WindowState.Maximized || this.WindowState == WindowState.Normal && this.m_PreviousWindowState == WindowState.Maximized))
    {
      if (this.m_RibbonControl != null)
      {
        if (this.WindowState == WindowState.Maximized)
        {
          if (!this._GlassSizeAdjusted)
          {
            Ribbon ribbonControl = this.m_RibbonControl;
            Thickness windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
            double left = windowBorderThickness.Left;
            windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
            double top = windowBorderThickness.Top + RibbonWindow.MaximizedGlassTopAdjustment;
            windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
            double right = windowBorderThickness.Right;
            windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
            double bottom = windowBorderThickness.Bottom;
            Thickness thickness = new Thickness(left, top, right, bottom);
            ribbonControl.WindowBorderThickness = thickness;
            this._GlassSizeAdjusted = true;
          }
        }
        else if (this._GlassSizeAdjusted)
        {
          Ribbon ribbonControl = this.m_RibbonControl;
          Thickness windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
          double left = windowBorderThickness.Left;
          windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
          double top = windowBorderThickness.Top - RibbonWindow.MaximizedGlassTopAdjustment;
          windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
          double right = windowBorderThickness.Right;
          windowBorderThickness = this.m_RibbonControl.WindowBorderThickness;
          double bottom = windowBorderThickness.Bottom;
          Thickness thickness = new Thickness(left, top, right, bottom);
          ribbonControl.WindowBorderThickness = thickness;
          this._GlassSizeAdjusted = false;
        }
      }
      this.UpdateGlass();
    }
    this.m_PreviousWindowState = this.WindowState;
  }

  internal void UpdateGlass()
  {
    if (!this.IsGlassEnabled && this.m_RibbonControl != null)
      this.m_RibbonControl.IsUsingGlass = false;
    else if (this.IsGlassEnabled && this.m_RibbonControl != null)
      this.m_RibbonControl.IsUsingGlass = true;
    if (!this.IsGlassEnabled || !this.m_SourceInitialized)
      return;
    double top = 27.0;
    int glassHeight;
    if (this.m_RibbonControl == null || !this.m_RibbonControl.HasCaption)
    {
      glassHeight = (int) WinApi.FrameBorderSize.Height * WinApi.BorderMultiplierFactor;
    }
    else
    {
      double dpiMultiplier = this.DpiMultiplier;
      top = this.m_RibbonControl.GetTitleChromeHeight() - 1.0;
      glassHeight = (int) Math.Ceiling(this.m_RibbonControl.GetTitleChromeHeight() * dpiMultiplier) - 1;
    }
    if (this.m_Border != null)
      this.m_Border.TransparentMargin = new Thickness(0.0, top, 0.0, 0.0);
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    HwndSource.FromHwnd(handle).CompositionTarget.BackgroundColor = Colors.Transparent;
    WinApi.ExtendGlass(handle, glassHeight);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Ribbon RibbonControl
  {
    get => this.m_RibbonControl;
    set
    {
      if (this.m_RibbonControl != value)
      {
        if (this.m_RibbonControl != null)
          this.m_RibbonControl.ReleaseBindings();
        this.m_RibbonControl = value;
        if (this.m_RibbonControl != null)
          this.m_RibbonControl.SetupBindings();
      }
      this.UpdateGlass();
    }
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool EnableGlass
  {
    get => (bool) this.GetValue(RibbonWindow.EnableGlassProperty);
    set => this.SetValue(RibbonWindow.EnableGlassProperty, (object) value);
  }

  private static void EnableGlassChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((RibbonWindow) d).OnEnableGlassChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  private void OnEnableGlassChanged(bool oldValue, bool newValue) => this.UpdateWindowStyle();

  private int GetSystemCaptionHeight()
  {
    return (int) WinApi.FrameBorderSize.Height * WinApi.BorderMultiplierFactor + WinApi.CaptionHeight;
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    if (this.IsGlassEnabled && Environment.Version.Major < 4 && availableSize.Height != double.PositiveInfinity)
    {
      double num1 = this.DpiMultiplier;
      if (num1 >= 1.0)
        num1 = 1.0 - Math.Abs(num1 - 1.0);
      int num2 = 0;
      if (num1 >= 1.0 && num1 < 1.3)
        num2 = 2;
      else if (num1 >= 1.0)
        num2 = 4;
      availableSize.Height += (double) this.GetSystemCaptionHeight() * num1 + (double) num2;
    }
    return base.MeasureOverride(availableSize);
  }

  protected override Size ArrangeOverride(Size arrangeBounds)
  {
    if (this.IsGlassEnabled && Environment.Version.Major < 4)
    {
      double num = this.DpiMultiplier;
      if (num >= 1.0)
        num = 1.0 - Math.Abs(num - 1.0);
      arrangeBounds.Height += Math.Ceiling((double) this.GetSystemCaptionHeight() * num);
    }
    return base.ArrangeOverride(arrangeBounds);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsUsingGlass
  {
    get => (bool) this.GetValue(RibbonWindow.IsUsingGlassProperty);
    internal set => this.SetValue(RibbonWindow.IsUsingGlassPropertyKey, (object) value);
  }
}
