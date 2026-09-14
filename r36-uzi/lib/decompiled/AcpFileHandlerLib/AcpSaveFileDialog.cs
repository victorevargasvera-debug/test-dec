// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.AcpSaveFileDialog
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

public sealed class AcpSaveFileDialog : AcpFileDialog
{
  private Microsoft.Win32.SaveFileDialog saveFileDialog;

  public AcpSaveFileDialog() => this.dlgType = DialogType.SaveAs;

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialog(AcpFileHeader fileHeader)
  {
    return this.ShowDialog(fileHeader, (Window) null);
  }

  [SecurityPermission(SecurityAction.LinkDemand, UnmanagedCode = true)]
  public override bool? ShowDialog(AcpFileHeader fileHeader, Window owner)
  {
    if (fileHeader != null)
      this.localFileHeader = fileHeader;
    else
      this.localFileHeader = new AcpFileHeader();
    OPENFILENAME lpofn = new OPENFILENAME();
    lpofn.lStructSize = Marshal.SizeOf<OPENFILENAME>(lpofn);
    lpofn.lpstrFilter = this.filter.Replace('|', char.MinValue) + "\0";
    lpofn.lpstrFile = this.fileName + new string(char.MinValue, (int) short.MaxValue - this.fileName.Length);
    lpofn.nMaxFile = lpofn.lpstrFile.Length;
    string fileName = Path.GetFileName(this.fileName);
    lpofn.lpstrFileTitle = fileName + new string(char.MinValue, (int) short.MaxValue - fileName.Length);
    lpofn.nMaxFileTitle = lpofn.lpstrFileTitle.Length;
    lpofn.lpstrTitle = AcpResources.Save_As;
    lpofn.lpstrDefExt = this.defaultExt;
    lpofn.lpstrInitialDir = AcpFileDialog.initialDirectory;
    WindowInteropHelper windowInteropHelper = owner == null ? new WindowInteropHelper(System.Windows.Application.Current.MainWindow) : new WindowInteropHelper(owner);
    lpofn.hwndOwner = windowInteropHelper.Handle;
    this.activeScreen = Screen.FromHandle(windowInteropHelper.Handle);
    lpofn.Flags = 8980526;
    lpofn.lpfnHook = new OfnHookProc(((AcpFileDialog) this).HookProc);
    bool flag;
    if (!NativeMethods.GetSaveFileName(ref lpofn))
    {
      int num = NativeMethods.CommDlgExtendedError();
      if (num != 0)
        throw AcpException.CreateNewException("FH_Show_Dialog_Fail", "Couldn't show file save dialog - " + num.ToString(), (AcpException.SeverityLevel) 0, (Exception) null);
      flag = false;
    }
    else
    {
      string[] strArray = this.filter.Split('|');
      string FileExtension = Path.GetExtension(lpofn.lpstrFile);
      string extensionToBeAdded1 = this.GetExtensionToBeAdded(strArray.GetValue(lpofn.nFilterIndex * 2 - 1).ToString(), FileExtension);
      if (!lpofn.lpstrFile.EndsWith(extensionToBeAdded1) && !(extensionToBeAdded1 == ".*"))
      {
        // ISSUE: explicit reference operation
        ^ref lpofn.lpstrFile += extensionToBeAdded1;
      }
      else if (extensionToBeAdded1 == ".*")
      {
        for (int index = 1; index < strArray.Length; index += 2)
        {
          string extensionToBeAdded2 = this.GetExtensionToBeAdded(strArray.GetValue(index).ToString(), FileExtension);
          if (!lpofn.lpstrFile.EndsWith(extensionToBeAdded2))
          {
            if (FileExtension == string.Empty || index == strArray.Length - 1)
            {
              // ISSUE: explicit reference operation
              ^ref lpofn.lpstrFile += this.GetExtensionToBeAdded(strArray.GetValue(1).ToString(), string.Empty);
              break;
            }
          }
          else
            break;
        }
      }
      this.fileName = lpofn.lpstrFile;
      AcpFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);
      flag = true;
    }
    return new bool?(flag);
  }

  private string GetExtensionToBeAdded(string SelectedEtn, string FileExtension)
  {
    SelectedEtn = SelectedEtn.Trim().Substring(1);
    if (FileExtension == SelectedEtn || !SelectedEtn.Contains(";"))
      return SelectedEtn;
    SelectedEtn = SelectedEtn.Replace("*", "");
    string[] strArray = SelectedEtn.Split(';');
    for (int index = 0; index < strArray.Length; ++index)
    {
      SelectedEtn = strArray.GetValue(index).ToString().Trim();
      if (FileExtension == SelectedEtn)
        return SelectedEtn;
      if (FileExtension == string.Empty || index == strArray.Length - 1)
        return strArray.GetValue(0).ToString().Trim();
    }
    return string.Empty;
  }

  public override bool? ShowDialog() => this.ShowDialog((Window) null);

  public override bool? ShowDialog(Window owner)
  {
    bool flag1 = false;
    this.saveFileDialog = new Microsoft.Win32.SaveFileDialog();
    this.saveFileDialog.Filter = this.filter;
    this.saveFileDialog.DefaultExt = this.defaultExt;
    this.saveFileDialog.FileName = this.FileName;
    this.saveFileDialog.RestoreDirectory = true;
    if (Directory.Exists(AcpFileDialog.initialDirectory))
      this.saveFileDialog.InitialDirectory = AcpFileDialog.initialDirectory;
    else
      this.saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
    bool? nullable = this.saveFileDialog.ShowDialog(owner);
    bool flag2 = true;
    if (nullable.GetValueOrDefault() == flag2 & nullable.HasValue)
    {
      this.fileName = this.saveFileDialog.FileName;
      AcpFileDialog.InitialDirectory = Path.GetDirectoryName(this.fileName);
      flag1 = true;
    }
    return new bool?(flag1);
  }

  public override bool? ShowDialogSafely(AcpFileHeader fileHeader)
  {
    throw new NotImplementedException();
  }

  public override bool? ShowDialogSafely(AcpFileHeader fileHeader, Window owner)
  {
    throw new NotImplementedException();
  }
}
