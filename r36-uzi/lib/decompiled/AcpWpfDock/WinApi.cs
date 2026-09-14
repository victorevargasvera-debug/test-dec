// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.WinApi
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace DevComponents.WpfDock;

internal class WinApi
{
  internal const uint MF_BYCOMMAND = 0;
  internal const uint MF_GRAYED = 1;
  internal static bool KeyValidated;

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

  [DllImport("user32.dll")]
  public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

  [DllImport("user32.dll")]
  public static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

  public static int LOWORD(int n) => (int) (short) (n & (int) ushort.MaxValue);

  public static int HIWORD(int n) => (int) (short) (n >> 16 /*0x10*/ & (int) ushort.MaxValue);

  public static int LOWORD(IntPtr n) => WinApi.LOWORD((int) (long) n);

  public static int HIWORD(IntPtr n) => WinApi.HIWORD((int) (long) n);

  internal static void ValidateLicenseKey(string p)
  {
    if (p == "DAD80300DA22")
      WinApi.KeyValidated = true;
    else
      WinApi.KeyValidated = false;
  }

  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  internal static extern bool GetCursorPos(ref WinApi.Win32Point pt);

  public enum WindowLongValues
  {
    GWL_EXSTYLE = -20, // 0xFFFFFFEC
    GWL_STYLE = -16, // 0xFFFFFFF0
  }

  public enum WindowStyles
  {
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
    WM_NCMOUSEMOVE = 160, // 0x000000A0
    WM_NCLBUTTONDOWN = 161, // 0x000000A1
    WM_NCLBUTTONDBLCLK = 163, // 0x000000A3
    WM_SYSCOMMAND = 274, // 0x00000112
  }

  public enum SysCommands
  {
    SC_SIZE = 61440, // 0x0000F000
    SC_MOVE = 61458, // 0x0000F012
    SC_MINIMIZE = 61472, // 0x0000F020
    SC_MAXIMIZE = 61488, // 0x0000F030
    SC_NEXTWINDOW = 61504, // 0x0000F040
    SC_PREVWINDOW = 61520, // 0x0000F050
    SC_CLOSE = 61536, // 0x0000F060
    SC_KEYMENU = 61696, // 0x0000F100
    SC_RESTORE = 61728, // 0x0000F120
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

  internal struct Win32Point
  {
    public int X;
    public int Y;
  }
}
