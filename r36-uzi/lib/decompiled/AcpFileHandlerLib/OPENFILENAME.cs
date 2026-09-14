// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.OPENFILENAME
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using System;
using System.Runtime.InteropServices;

#nullable disable
namespace AcpFileHandlerLib;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
internal struct OPENFILENAME
{
  public int lStructSize;
  public IntPtr hwndOwner;
  public IntPtr hInstance;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrFilter;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrCustomFilter;
  public int nMaxCustFilter;
  public int nFilterIndex;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrFile;
  public int nMaxFile;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrFileTitle;
  public int nMaxFileTitle;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrInitialDir;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrTitle;
  public int Flags;
  public short nFileOffset;
  public short nFileExtension;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpstrDefExt;
  public IntPtr lCustData;
  public OfnHookProc lpfnHook;
  [MarshalAs(UnmanagedType.LPTStr)]
  public string lpTemplateName;
  public int pvReserved;
  public int dwReserved;
  public int FlagsEx;
}
