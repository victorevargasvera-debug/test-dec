// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpFileDialog
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using AcpCommonResources;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Windows;
using System.Windows.Forms;

#nullable disable
namespace AcpFileHandlerLib;

public abstract class AcpFileDialog
{
  private HeaderDataControl headerDataControl;
  internal const int MaxLongPath = 32767 /*0x7FFF*/;
  internal string filter;
  internal string fileName;
  internal string defaultExt;
  internal static string initialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
  internal Screen activeScreen;
  internal AcpFileHeader localFileHeader;
  internal DialogType dlgType;

  protected AcpFileDialog()
  {
    this.filter = "All files(*.*)| *.*";
    this.fileName = string.Empty;
    this.defaultExt = string.Empty;
  }

  public string Filter
  {
    get => this.filter;
    set => this.filter = value;
  }

  public string FileName
  {
    get => this.fileName;
    set => this.fileName = value;
  }

  public string DefaultExt
  {
    get => this.defaultExt;
    set => this.defaultExt = value;
  }

  public static string InitialDirectory
  {
    get => AcpFileDialog.initialDirectory;
    set => AcpFileDialog.initialDirectory = value;
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public abstract bool? ShowDialog(AcpFileHeader fileHeader);

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public abstract bool? ShowDialogSafely(AcpFileHeader fileHeader);

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public abstract bool? ShowDialog(AcpFileHeader fileHeader, Window owner);

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public abstract bool? ShowDialogSafely(AcpFileHeader fileHeader, Window owner);

  public abstract bool? ShowDialog();

  public abstract bool? ShowDialog(Window owner);

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  protected IntPtr HookProc(IntPtr hdlg, int msg, IntPtr wParam, IntPtr lParam)
  {
    switch (msg)
    {
      case 78:
        switch (((OFNOTIFY) Marshal.PtrToStructure(lParam, typeof (OFNOTIFY))).nmhdr.Code)
        {
          case 4294966690:
            if (this.dlgType == DialogType.SaveAs)
            {
              this.localFileHeader.FileInfo = this.headerDataControl.FileInfoField;
              break;
            }
            break;
          case 4294966694:
            if (this.dlgType == DialogType.Open)
            {
              StringBuilder stringBuilder = new StringBuilder((int) short.MaxValue);
              NativeMethods.SendMessage(NativeMethods.GetParent(hdlg), 1125U, new IntPtr((int) short.MaxValue), stringBuilder);
              this.headerDataControl.OnFileChangedSafely(ref this.localFileHeader, stringBuilder.ToString());
              break;
            }
            break;
        }
        break;
      case 272:
        this.headerDataControl = new HeaderDataControl(this.dlgType);
        this.headerDataControl.ModelNumberLabel = AcpResources.Model_Number;
        this.headerDataControl.SerialNumberLabel = AcpResources.Serial_Number;
        this.headerDataControl.FlashCodeLabel = AcpResources.Flash_Code;
        this.headerDataControl.VersionNumberLabel = AcpResources.Version_Number;
        this.headerDataControl.FileInformationLabel = AcpResources.File_Information;
        Rectangle bounds = this.activeScreen.Bounds;
        RECT lpRect = new RECT();
        IntPtr parent = NativeMethods.GetParent(hdlg);
        NativeMethods.GetWindowRect(parent, ref lpRect);
        int X = (bounds.Right + bounds.Left - (lpRect.Right - lpRect.Left)) / 2;
        int Y = (bounds.Bottom + bounds.Top - (lpRect.Bottom + this.headerDataControl.Height - lpRect.Top)) / 2;
        int num1 = lpRect.Right - lpRect.Left;
        Size size = this.headerDataControl.Size;
        int width = size.Width;
        int num2;
        if (num1 < width)
        {
          size = this.headerDataControl.Size;
          num2 = size.Width;
        }
        else
          num2 = lpRect.Right - lpRect.Left;
        int cx = num2;
        int num3 = lpRect.Bottom - lpRect.Top;
        size = this.headerDataControl.Size;
        int height = size.Height;
        int cy = num3 + height + 15;
        NativeMethods.SetWindowPos(parent, IntPtr.Zero, X, Y, cx, cy, SetWindowPosFlags.SWP_NOZORDER);
        NativeMethods.SetParent(this.headerDataControl.Handle, parent);
        this.headerDataControl.Location = new Point(this.headerDataControl.Width < cx ? Math.Abs((lpRect.Right - lpRect.Left - this.headerDataControl.Width) / 2) : 0, lpRect.Bottom - lpRect.Top - 30);
        if (this.dlgType == DialogType.SaveAs)
        {
          this.headerDataControl.DisplayHeaderData(this.localFileHeader);
          break;
        }
        break;
    }
    return IntPtr.Zero;
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  protected IntPtr HookProcSafely(IntPtr hdlg, int msg, IntPtr wParam, IntPtr lParam)
  {
    switch (msg)
    {
      case 78:
        switch (((OFNOTIFY) Marshal.PtrToStructure(lParam, typeof (OFNOTIFY))).nmhdr.Code)
        {
          case 4294966690:
            if (this.dlgType == DialogType.SaveAs)
            {
              this.localFileHeader.FileInfo = this.headerDataControl.FileInfoField;
              break;
            }
            break;
          case 4294966694:
            if (this.dlgType == DialogType.Open)
            {
              StringBuilder stringBuilder = new StringBuilder((int) short.MaxValue);
              NativeMethods.SendMessage(NativeMethods.GetParent(hdlg), 1125U, new IntPtr((int) short.MaxValue), stringBuilder);
              this.headerDataControl.OnFileChangedSafely(ref this.localFileHeader, stringBuilder.ToString());
              break;
            }
            break;
        }
        break;
      case 272:
        this.headerDataControl = new HeaderDataControl(this.dlgType);
        this.headerDataControl.ModelNumberLabel = AcpResources.Model_Number;
        this.headerDataControl.SerialNumberLabel = AcpResources.Serial_Number;
        this.headerDataControl.FlashCodeLabel = AcpResources.Flash_Code;
        this.headerDataControl.VersionNumberLabel = AcpResources.Version_Number;
        this.headerDataControl.FileInformationLabel = AcpResources.File_Information;
        Rectangle bounds = this.activeScreen.Bounds;
        RECT lpRect = new RECT();
        IntPtr parent = NativeMethods.GetParent(hdlg);
        NativeMethods.GetWindowRect(parent, ref lpRect);
        int X = (bounds.Right + bounds.Left - (lpRect.Right - lpRect.Left)) / 2;
        int Y = (bounds.Bottom + bounds.Top - (lpRect.Bottom + this.headerDataControl.Height - lpRect.Top)) / 2;
        int num1 = lpRect.Right - lpRect.Left;
        Size size = this.headerDataControl.Size;
        int width = size.Width;
        int num2;
        if (num1 < width)
        {
          size = this.headerDataControl.Size;
          num2 = size.Width;
        }
        else
          num2 = lpRect.Right - lpRect.Left;
        int cx = num2;
        int num3 = lpRect.Bottom - lpRect.Top;
        size = this.headerDataControl.Size;
        int height = size.Height;
        int cy = num3 + height + 15;
        NativeMethods.SetWindowPos(parent, IntPtr.Zero, X, Y, cx, cy, SetWindowPosFlags.SWP_NOZORDER);
        NativeMethods.SetParent(this.headerDataControl.Handle, parent);
        this.headerDataControl.Location = new Point(this.headerDataControl.Width < cx ? Math.Abs((lpRect.Right - lpRect.Left - this.headerDataControl.Width) / 2) : 0, lpRect.Bottom - lpRect.Top - 30);
        if (this.dlgType == DialogType.SaveAs)
        {
          this.headerDataControl.DisplayHeaderData(this.localFileHeader);
          break;
        }
        break;
    }
    return IntPtr.Zero;
  }
}
