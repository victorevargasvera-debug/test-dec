// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpOpenFileDialog
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using AcpCommonResources;
using AcpExceptionLib;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;

#nullable disable
namespace AcpFileHandlerLib;

public sealed class AcpOpenFileDialog : AcpFileDialog
{
  private Microsoft.Win32.OpenFileDialog openFileDialog;
  private string[] fileNames;
  private bool multiSelect;

  public AcpOpenFileDialog()
  {
    this.fileNames = new string[1]{ string.Empty };
    this.multiSelect = false;
    this.dlgType = DialogType.Open;
  }

  public string[] FileNames => this.fileNames;

  public bool MultiSelect
  {
    get => this.multiSelect;
    set => this.multiSelect = value;
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialog(AcpFileHeader fileHeader)
  {
    return this.ShowDialog(fileHeader, (Window) null);
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialogSafely(AcpFileHeader fileHeader)
  {
    return this.ShowDialogSafely(fileHeader, (Window) null);
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialog(AcpFileHeader fileHeader, Window owner)
  {
    this.localFileHeader = new AcpFileHeader();
    OPENFILENAME lpofn = new OPENFILENAME();
    lpofn.lStructSize = Marshal.SizeOf<OPENFILENAME>(lpofn);
    lpofn.lpstrFilter = this.filter.Replace('|', char.MinValue) + "\0";
    lpofn.lpstrFile = this.fileName + new string(char.MinValue, (int) short.MaxValue - this.fileName.Length);
    lpofn.nMaxFile = lpofn.lpstrFile.Length;
    string fileName = Path.GetFileName(this.fileName);
    lpofn.lpstrFileTitle = fileName + new string(char.MinValue, (int) short.MaxValue - fileName.Length);
    lpofn.nMaxFileTitle = lpofn.lpstrFileTitle.Length;
    lpofn.lpstrTitle = AcpResources.Open;
    lpofn.lpstrDefExt = this.defaultExt;
    lpofn.lpstrInitialDir = AcpFileDialog.initialDirectory;
    WindowInteropHelper windowInteropHelper = owner == null ? new WindowInteropHelper(System.Windows.Application.Current.MainWindow) : new WindowInteropHelper(owner);
    lpofn.hwndOwner = windowInteropHelper.Handle;
    this.activeScreen = Screen.FromHandle(windowInteropHelper.Handle);
    OfnFlags ofnFlags = OfnFlags.OFN_HIDEREADONLY | OfnFlags.OFN_NOCHANGEDIR | OfnFlags.OFN_ENABLEHOOK | OfnFlags.OFN_PATHMUSTEXIST | OfnFlags.OFN_FILEMUSTEXIST | OfnFlags.OFN_EXPLORER | OfnFlags.OFN_NOTESTFILECREATE | OfnFlags.OFN_ENABLESIZING;
    if (this.multiSelect)
      ofnFlags |= OfnFlags.OFN_ALLOWMULTISELECT;
    lpofn.Flags = (int) ofnFlags;
    lpofn.lpfnHook = new OfnHookProc(((AcpFileDialog) this).HookProc);
    bool flag;
    if (!NativeMethods.GetOpenFileName(ref lpofn))
    {
      int num = NativeMethods.CommDlgExtendedError();
      if (num != 0)
        throw AcpException.CreateNewException("FH_Show_Dialog_Fail", "Couldn't show file open dialog - " + num.ToString(), (AcpException.SeverityLevel) 0, (Exception) null);
      flag = false;
    }
    else
    {
      if (fileHeader != null)
      {
        fileHeader.ModelNumber = this.localFileHeader.ModelNumber;
        fileHeader.SerialNumber = this.localFileHeader.SerialNumber;
        fileHeader.FlashCode = this.localFileHeader.FlashCode;
        fileHeader.VersionNumber = this.localFileHeader.VersionNumber;
        fileHeader.FileInfo = this.localFileHeader.FileInfo;
      }
      this.fileName = lpofn.lpstrFile;
      AcpFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);
      flag = true;
    }
    return new bool?(flag);
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialogSafely(AcpFileHeader fileHeader, Window owner)
  {
    this.localFileHeader = new AcpFileHeader();
    OPENFILENAME lpofn = new OPENFILENAME();
    lpofn.lStructSize = Marshal.SizeOf<OPENFILENAME>(lpofn);
    lpofn.lpstrFilter = this.filter.Replace('|', char.MinValue) + "\0";
    lpofn.lpstrFile = this.fileName + new string(char.MinValue, (int) short.MaxValue - this.fileName.Length);
    lpofn.nMaxFile = lpofn.lpstrFile.Length;
    string fileName = Path.GetFileName(this.fileName);
    lpofn.lpstrFileTitle = fileName + new string(char.MinValue, (int) short.MaxValue - fileName.Length);
    lpofn.nMaxFileTitle = lpofn.lpstrFileTitle.Length;
    lpofn.lpstrTitle = AcpResources.Open;
    lpofn.lpstrDefExt = this.defaultExt;
    lpofn.lpstrInitialDir = AcpFileDialog.initialDirectory;
    WindowInteropHelper windowInteropHelper = owner == null ? new WindowInteropHelper(System.Windows.Application.Current.MainWindow) : new WindowInteropHelper(owner);
    lpofn.hwndOwner = windowInteropHelper.Handle;
    this.activeScreen = Screen.FromHandle(windowInteropHelper.Handle);
    OfnFlags ofnFlags = OfnFlags.OFN_HIDEREADONLY | OfnFlags.OFN_NOCHANGEDIR | OfnFlags.OFN_ENABLEHOOK | OfnFlags.OFN_PATHMUSTEXIST | OfnFlags.OFN_FILEMUSTEXIST | OfnFlags.OFN_EXPLORER | OfnFlags.OFN_NOTESTFILECREATE | OfnFlags.OFN_ENABLESIZING;
    if (this.multiSelect)
      ofnFlags |= OfnFlags.OFN_ALLOWMULTISELECT;
    lpofn.Flags = (int) ofnFlags;
    lpofn.lpfnHook = new OfnHookProc(((AcpFileDialog) this).HookProcSafely);
    bool flag;
    if (!NativeMethods.GetOpenFileName(ref lpofn))
    {
      int num = NativeMethods.CommDlgExtendedError();
      if (num != 0)
        throw AcpException.CreateNewException("FH_Show_Dialog_Fail", "Couldn't show file open dialog - " + num.ToString(), (AcpException.SeverityLevel) 0, (Exception) null);
      flag = false;
    }
    else
    {
      if (fileHeader != null)
      {
        fileHeader.ModelNumber = this.localFileHeader.ModelNumber;
        fileHeader.SerialNumber = this.localFileHeader.SerialNumber;
        fileHeader.FlashCode = this.localFileHeader.FlashCode;
        fileHeader.VersionNumber = this.localFileHeader.VersionNumber;
        fileHeader.FileInfo = this.localFileHeader.FileInfo;
      }
      this.fileName = lpofn.lpstrFile;
      AcpFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);
      flag = true;
    }
    return new bool?(flag);
  }

  public override bool? ShowDialog() => this.ShowDialog((Window) null);

  public override bool? ShowDialog(Window owner)
  {
    bool flag1 = false;
    this.openFileDialog = new Microsoft.Win32.OpenFileDialog();
    this.openFileDialog.Filter = this.filter;
    this.openFileDialog.DefaultExt = this.defaultExt;
    this.openFileDialog.FileName = this.FileName;
    this.openFileDialog.Multiselect = this.multiSelect;
    if (Directory.Exists(AcpFileDialog.initialDirectory))
      this.openFileDialog.InitialDirectory = AcpFileDialog.initialDirectory;
    else
      this.openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    this.openFileDialog.RestoreDirectory = true;
    bool? nullable = this.openFileDialog.ShowDialog(owner);
    bool flag2 = true;
    if (nullable.GetValueOrDefault() == flag2 & nullable.HasValue)
    {
      this.fileName = this.openFileDialog.FileName;
      this.fileNames = this.openFileDialog.FileNames;
      AcpFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);
      flag1 = true;
    }
    return new bool?(flag1);
  }
}
