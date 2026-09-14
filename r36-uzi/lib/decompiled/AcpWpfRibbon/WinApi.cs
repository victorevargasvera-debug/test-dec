// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.WinApi
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Runtime.InteropServices;
using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class WinApi
{
  private static bool _IsWindows7;
  internal static bool KeyValidated;

  [DllImport("user32.dll")]
  public static extern bool IsZoomed(IntPtr hWnd);

  [DllImport("user32")]
  public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

  [DllImport("user32.dll")]
  public static extern int TrackPopupMenu(
    IntPtr hMenu,
    uint uFlags,
    int x,
    int y,
    int nReserved,
    IntPtr hWnd,
    IntPtr prcRect);

  [DllImport("user32.dll")]
  public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

  [DllImport("user32")]
  public static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

  [DllImport("user32.dll")]
  public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);

  [DllImport("gdi32.dll")]
  public static extern IntPtr CreateRectRgn(
    int nLeftRect,
    int nTopRect,
    int nRightRect,
    int nBottomRect);

  [DllImport("gdi32.dll")]
  public static extern int CombineRgn(
    IntPtr hrgnDest,
    IntPtr hrgnSrc1,
    IntPtr hrgnSrc2,
    int fnCombineMode);

  [DllImport("user32")]
  public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

  [DllImport("user32")]
  public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

  [DllImport("user32")]
  public static extern bool SetWindowPos(
    IntPtr hWnd,
    IntPtr hWndInsertAfter,
    int X,
    int Y,
    int cx,
    int cy,
    int uFlags);

  [DllImport("user32")]
  public static extern bool GetMonitorInfo(IntPtr hMonitor, WinApi.MONITORINFO lpmi);

  [DllImport("User32")]
  public static extern IntPtr MonitorFromWindow(IntPtr handle, int flags);

  [DllImport("dwmapi.dll")]
  public static extern int DwmDefWindowProc(
    IntPtr hwnd,
    int msg,
    IntPtr wParam,
    IntPtr lParam,
    out IntPtr plResult);

  [DllImport("user32")]
  public static extern bool GetWindowRect(IntPtr hWnd, ref WinApi.RECT r);

  [DllImport("gdi32.dll")]
  public static extern bool DeleteObject(IntPtr hObject);

  [DllImport("dwmapi.dll", PreserveSig = false)]
  private static extern bool DwmIsCompositionEnabled();

  [DllImport("dwmapi.dll")]
  private static extern int DwmExtendFrameIntoClientArea(IntPtr hWnd, ref WinApi.MARGINS pMargins);

  public static void ExtendGlass(IntPtr handle, int glassHeight)
  {
    WinApi.DwmExtendFrameIntoClientArea(handle, ref new WinApi.MARGINS()
    {
      cxLeftWidth = 0,
      cxRightWidth = 0,
      cyTopHeight = glassHeight,
      cyBottomHeight = 0
    });
  }

  public static bool IsGlassEnabled
  {
    get => Environment.OSVersion.Version.Major >= 6 && WinApi.DwmIsCompositionEnabled();
  }

  public static int LOWORD(int n) => (int) (short) (n & (int) ushort.MaxValue);

  public static int HIWORD(int n) => (int) (short) (n >> 16 /*0x10*/ & (int) ushort.MaxValue);

  public static int LOWORD(IntPtr n) => WinApi.LOWORD((int) (long) n);

  public static int HIWORD(IntPtr n) => WinApi.HIWORD((int) (long) n);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern int GetSystemMetrics(int nIndex);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern bool SystemParametersInfo(
    int nAction,
    int nParam,
    ref int value,
    int ignore);

  public static Size FrameBorderSize
  {
    get
    {
      return new Size((double) WinApi.GetSystemMetrics(32 /*0x20*/), (double) WinApi.GetSystemMetrics(33));
    }
  }

  public static int BorderMultiplierFactor
  {
    get
    {
      int multiplierFactor = 0;
      WinApi.SystemParametersInfo(5, 0, ref multiplierFactor, 0);
      return multiplierFactor;
    }
  }

  public static int CaptionHeight => WinApi.GetSystemMetrics(4);

  internal static WindowState WindowStateFromParam(IntPtr wParam)
  {
    if (wParam.ToInt32() == 2)
      return WindowState.Maximized;
    return wParam.ToInt32() == 1 ? WindowState.Minimized : WindowState.Normal;
  }

  static WinApi()
  {
    Version version = Environment.OSVersion.Version;
    WinApi._IsWindows7 = version.Major >= 6 && version.Minor >= 1 && version.Build >= 7000;
  }

  public static bool IsWindows7 => WinApi._IsWindows7;

  internal static void ValidateLicenseKey(string p)
  {
    if (p == "DAD80300DA22")
      WinApi.KeyValidated = true;
    else
      WinApi.KeyValidated = false;
  }

  public enum WindowLongValues
  {
    GWL_EXSTYLE = -20, // 0xFFFFFFEC
    GWL_STYLE = -16, // 0xFFFFFFF0
  }

  public enum WindowStyles
  {
    WS_EX_DLGMODALFRAME = 1,
    WS_THICKFRAME = 262144, // 0x00040000
  }

  [Flags]
  public enum SetWindowPosParams
  {
    SWP_FRAMECHANGED = 32, // 0x00000020
    SWP_NOSIZE = 1,
    SWP_NOMOVE = 2,
    SWP_NOZORDER = 4,
  }

  public enum WindowsMessages
  {
    WM_SIZE = 5,
    WM_GETMINMAXINFO = 36, // 0x00000024
    WM_NCCALCSIZE = 131, // 0x00000083
    WM_NCHITTEST = 132, // 0x00000084
    WM_NCLBUTTONDOWN = 161, // 0x000000A1
    WM_SYSCOMMAND = 274, // 0x00000112
    WM_SIZING = 532, // 0x00000214
    WM_ENTERSIZEMOVE = 561, // 0x00000231
    WM_EXITSIZEMOVE = 562, // 0x00000232
    WM_DWMCOMPOSITIONCHANGED = 798, // 0x0000031E
    WM_USER = 1024, // 0x00000400
    WVR_VALIDRECTS = 1024, // 0x00000400
  }

  public enum SysCommands
  {
    SC_SIZE = 61440, // 0x0000F000
    SC_MOVE = 61456, // 0x0000F010
    SC_MINIMIZE = 61472, // 0x0000F020
    SC_MAXIMIZE = 61488, // 0x0000F030
    SC_NEXTWINDOW = 61504, // 0x0000F040
    SC_PREVWINDOW = 61520, // 0x0000F050
    SC_CLOSE = 61536, // 0x0000F060
    SC_KEYMENU = 61696, // 0x0000F100
    SC_RESTORE = 61728, // 0x0000F120
  }

  public enum SizingCommand
  {
    None,
    West,
    East,
    North,
    NorthWest,
    NorthEast,
    South,
    SouthWest,
    SouthEast,
  }

  public enum WmSizeType
  {
    SIZE_RESTORED,
    SIZE_MINIMIZED,
    SIZE_MAXIMIZED,
    SIZE_MAXSHOW,
    SIZE_MAXHIDE,
  }

  public enum WindowHitTestRegions
  {
    Error = -2, // 0xFFFFFFFE
    TransparentOrCovered = -1, // 0xFFFFFFFF
    NoWhere = 0,
    ClientArea = 1,
    TitleBar = 2,
    SystemMenu = 3,
    GrowBox = 4,
    SizeBox = 4,
    Menu = 5,
    HorizontalScrollBar = 6,
    VerticalScrollBar = 7,
    MinimizeButton = 8,
    ReduceButton = 8,
    MaximizeButton = 9,
    ZoomButton = 9,
    LeftSizeableBorder = 10, // 0x0000000A
    RightSizeableBorder = 11, // 0x0000000B
    TopSizeableBorder = 12, // 0x0000000C
    TopLeftSizeableCorner = 13, // 0x0000000D
    TopRightSizeableCorner = 14, // 0x0000000E
    BottomSizeableBorder = 15, // 0x0000000F
    BottomLeftSizeableCorner = 16, // 0x00000010
    BottomRightSizeableCorner = 17, // 0x00000011
    NonSizableBorder = 18, // 0x00000012
    Object = 19, // 0x00000013
    CloseButton = 20, // 0x00000014
    HelpButton = 21, // 0x00000015
  }

  public struct MARGINS
  {
    public int cxLeftWidth;
    public int cxRightWidth;
    public int cyTopHeight;
    public int cyBottomHeight;
  }

  public struct WINDOWPOS
  {
    public IntPtr hwnd;
    public IntPtr hwndInsertAfter;
    public int x;
    public int y;
    public int cx;
    public int cy;
    public int flags;
  }

  public struct NCCALCSIZE_PARAMS
  {
    public WinApi.RECT rgrc0;
    public WinApi.RECT rgrc1;
    public WinApi.RECT rgrc2;
    public IntPtr lppos;
  }

  [Serializable]
  public struct RECT
  {
    public int Left;
    public int Top;
    public int Right;
    public int Bottom;

    public RECT(int left_, int top_, int right_, int bottom_)
    {
      this.Left = left_;
      this.Top = top_;
      this.Right = right_;
      this.Bottom = bottom_;
    }

    public RECT(Rect r)
    {
      this.Left = (int) Math.Ceiling(r.Left);
      this.Top = (int) Math.Ceiling(r.Top);
      this.Right = (int) Math.Ceiling(r.Right);
      this.Bottom = (int) Math.Ceiling(r.Bottom);
    }

    public int Height => this.Bottom - this.Top;

    public int Width => this.Right - this.Left;

    public Size Size => new Size((double) this.Width, (double) this.Height);

    public Point Location => new Point((double) this.Left, (double) this.Top);

    public Rect ToRectangle()
    {
      return new Rect((double) this.Left, (double) this.Top, (double) (this.Right - this.Left), (double) (this.Bottom - this.Top));
    }

    public static WinApi.RECT FromRectangle(Rect r)
    {
      return new WinApi.RECT((int) Math.Ceiling(r.Left), (int) Math.Ceiling(r.Top), (int) Math.Ceiling(r.Right), (int) Math.Ceiling(r.Bottom));
    }

    public override int GetHashCode()
    {
      return this.Left ^ (this.Top << 13 | this.Top >> 19) ^ (this.Width << 26 | this.Width >> 6) ^ (this.Height << 7 | this.Height >> 25);
    }

    public static implicit operator Rect(WinApi.RECT rect)
    {
      return new Rect((double) rect.Left, (double) rect.Top, (double) (rect.Right - rect.Left), (double) (rect.Bottom - rect.Top));
    }

    public static implicit operator WinApi.RECT(Rect rect)
    {
      return (WinApi.RECT) new Rect(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
    }

    public override string ToString()
    {
      return $"Left={this.Left.ToString()}, Top={this.Top.ToString()}, Right={this.Right.ToString()}, Bottom={this.Bottom.ToString()}";
    }
  }

  [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
  public class MONITORINFO
  {
    public int cbSize = Marshal.SizeOf(typeof (WinApi.MONITORINFO));
    public WinApi.RECT rcMonitor;
    public WinApi.RECT rcWork;
    public int dwFlags;
  }

  public struct POINT(int x, int y)
  {
    public int x = x;
    public int y = y;
  }

  public struct MINMAXINFO
  {
    public WinApi.POINT ptReserved;
    public WinApi.POINT ptMaxSize;
    public WinApi.POINT ptMaxPosition;
    public WinApi.POINT ptMinTrackSize;
    public WinApi.POINT ptMaxTrackSize;
  }

  public enum CombineRgnStyles
  {
    RGN_AND = 1,
    RGN_MIN = 1,
    RGN_OR = 2,
    RGN_XOR = 3,
    RGN_DIFF = 4,
    RGN_COPY = 5,
    RGN_MAX = 5,
  }

  private enum WM_SIZE
  {
    SIZE_RESTORED,
    SIZE_MINIMIZED,
    SIZE_MAXIMIZED,
    SIZE_MAXSHOW,
    SIZE_MAXHIDE,
  }
}
