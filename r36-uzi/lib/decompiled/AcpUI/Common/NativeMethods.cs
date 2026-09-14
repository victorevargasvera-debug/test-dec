// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.NativeMethods
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Runtime.InteropServices;

#nullable disable
namespace AcpUI.Common;

internal static class NativeMethods
{
  [DllImport("user32.dll")]
  [return: MarshalAs(UnmanagedType.Bool)]
  internal static extern bool GetCursorPos(ref NativeMethods.Win32Point pt);

  internal struct Win32Point
  {
    public int X;
    public int Y;
  }
}
