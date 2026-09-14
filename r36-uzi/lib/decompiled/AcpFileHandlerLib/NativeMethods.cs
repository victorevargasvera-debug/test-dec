// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.NativeMethods
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;
using System.Runtime.InteropServices;
using System.Text;

#nullable disable
namespace AcpFileHandlerLib;

internal static class NativeMethods
{
  [DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern bool GetSaveFileName(ref OPENFILENAME lpofn);

  [DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern bool GetOpenFileName(ref OPENFILENAME lpofn);

  [DllImport("user32.dll")]
  internal static extern bool SetWindowPos(
    IntPtr hWnd,
    IntPtr hWndInsertAfter,
    int X,
    int Y,
    int cx,
    int cy,
    SetWindowPosFlags uFlags);

  [DllImport("user32.dll")]
  internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

  [DllImport("user32.dll")]
  internal static extern IntPtr GetParent(IntPtr hWnd);

  [DllImport("user32.dll")]
  internal static extern int SetParent(IntPtr hWndChild, IntPtr hWndParent);

  [DllImport("user32.dll", CharSet = CharSet.Auto)]
  public static extern int SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, StringBuilder param);

  [DllImport("Comdlg32.dll")]
  internal static extern int CommDlgExtendedError();

  [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
  internal static extern bool GetDiskFreeSpace(
    string lpRootPathName,
    out uint lpSectorsPerCluster,
    out uint lpBytesPerSector,
    out uint lpNumberOfFreeClusters,
    out uint lpTotalNumberOfClusters);
}
