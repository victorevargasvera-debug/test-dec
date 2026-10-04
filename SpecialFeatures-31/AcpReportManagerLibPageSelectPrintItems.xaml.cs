// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.PageSelectPrintItems
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpUI.Common;
using CommonResources;
using Microsoft.Win32;
using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using SpecialFeatures.Utilites;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public partial class PageSelectPrintItems : PageFunction<string>, IComponentConnector
{
  internal Grid gReportsSelectPrintItems;
  internal Label lblAvailablePrint;
  internal Label lblSelectPrint;
  internal TreeView tvAvailable;
  internal TreeView tvSelected;
  internal Button btnAddSelectedItems;
  internal Button btnRemSelectedItems;
  internal Button btnSave;
  internal Button btnSaveAs;
  internal Button btnCancel;
  internal Button btnHelp;
  internal Image imgMotologo;
  private bool a;

  internal PageSelectPrintItems()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  private void InitializeData(object A_0, EventArgs A_1)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.a();
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (!this.IsKeyboardFocusWithin)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_15;
            case 1:
              if (this.tvSelected.Items.Count == 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              this.btnRemSelectedItems.IsEnabled = true;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              num2 = (short) 1;
              if (num2 == (short) 0)
                goto case 2;
              goto case 2;
            case 4:
label_12:
              this.btnSave.IsEnabled = false;
              this.btnSaveAs.IsEnabled = false;
              this.btnRemSelectedItems.IsEnabled = false;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              goto label_13;
            case 6:
              num2 = (short) 0;
              num2 = (short) 5286;
              int num3 = (int) num2;
              num2 = (short) 5286;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_12;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  Keyboard.Focus((IInputElement) this);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_13:
        break;
label_15:
        break;
    }
  }

  private void a()
  {
    int A_1 = 3;
    int num1 = 0;
    switch (num1)
    {
      default:
        BitmapImage bitmapImage;
        string str1;
        string str2;
        int length;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            bitmapImage = new BitmapImage();
            str1 = (string) null;
            str2 = AppDomain.CurrentDomain.BaseDirectory;
            length = str2.IndexOf(RptMgrErrorHandler.b("\uE485\uE187\uE489킋", A_1));
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  str2 = str2.Substring(0, length);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  num2 = (short) 18188;
                  int num3 = (int) num2;
                  num2 = (short) 18188;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_6;
                    default:
                      goto label_8;
                  }
                case 2:
label_6:
                  bitmapImage.BeginInit();
                  bitmapImage.UriSource = new Uri(str1);
                  bitmapImage.EndInit();
                  this.imgMotologo.Source = (ImageSource) bitmapImage;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (length > 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 4:
                  str1 = str2 + RptMgrErrorHandler.b("\uF485\uED87憎\uE38Bﲍ\uE48F\uE191좓ﾕ\uF597ﮙﮛﮝﲟ쪡솣장첧쾩\uDEAB肭絛\uE2B1\uF3B3", A_1);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (File.Exists(str1))
                  {
                    num2 = (short) 0;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_16;
                default:
                  goto label_3;
              }
            }
label_8:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            return;
label_16:
            return;
        }
    }
  }

  internal void OnSelItemsCancel(object sender, RoutedEventArgs e)
  {
    short num1 = -10826;
    int num2 = (int) num1;
    num1 = (short) -10826;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        ((Window) this.Parent).Close();
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  internal void OnSaveAs(object sender, RoutedEventArgs e)
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (0)
          {
            case 0:
              goto label_4;
            default:
              continue;
          }
        case 1:
          goto label_6;
        case 2:
          ((Window) this.Parent).Close();
          num2 = (short) 11099;
          int num3 = (int) num2;
          num2 = (short) 11099;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        default:
label_4:
          if (!this.a(PageSelectPrintItems.serializeAction.saveAs))
            goto label_10;
          break;
      }
      num2 = (short) 0;
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_6:
    return;
label_10:;
  }

  internal void OnSave(object sender, RoutedEventArgs e)
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      switch (num1)
      {
        case 0:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 1:
          goto label_6;
        case 2:
          num2 = (short) 0;
          ((Window) this.Parent).Close();
          num2 = (short) -19489;
          int num3 = (int) num2;
          num2 = (short) -19489;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          break;
        default:
label_3:
          if (!this.a(PageSelectPrintItems.serializeAction.save))
            goto label_10;
          break;
      }
      num2 = (short) 2;
      num1 = (int) (IntPtr) num2;
    }
label_6:
    return;
label_10:;
  }

  private bool a(PageSelectPrintItems.serializeAction A_0)
  {
    int A_1 = 12;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        string usrPrntTemplateDir;
        string path;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag1 = false;
            usrPrntTemplateDir = Global.usrPrntTemplateDir;
            path = "";
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              SaveFileDialog saveFileDialog;
              bool flag2;
              string str1;
              bool flag3;
              string str2;
              bool? nullable;
              bool flag4;
              switch (num1)
              {
                case 0:
                  Trace.WriteLine(string.Format(RptMgrErrorHandler.b("즎\uF890ﾒ\uF094\uD996\uF898\uF69A\uF89Cꖞ\uDAA0鎢\uD8A4", A_1), this.tvAvailable.Tag));
                  path = this.tvAvailable.Tag.ToString();
                  num2 = (short) 46;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  saveFileDialog.FileName += RptMgrErrorHandler.b("ꆎ\uE590\uE392璉", A_1);
                  path = saveFileDialog.FileName;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (Global.usrLastSavedContainer.Contains(path))
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 3:
                  if (VersionInfoHelper.IsDFlagExisted((DFlagType) 1))
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  saveFileDialog.Filter = AppResources.Motorola_template_File_Filter;
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  flag2 = false;
                  str1 = saveFileDialog.FileName.Remove(saveFileDialog.FileName.IndexOf(saveFileDialog.SafeFileName) - 1, saveFileDialog.SafeFileName.Length + 1);
                  num2 = (short) 27;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  flag3 = true;
                  num2 = (short) 0;
                  num2 = (short) 41;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  try
                  {
                    num2 = (short) 2;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num3)
                      {
                        case 0:
                          num2 = (short) 1;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          goto label_75;
                        case 2:
                          switch (0)
                          {
                            case 0:
                              goto label_39;
                            default:
                              continue;
                          }
                        case 3:
                          Directory.CreateDirectory(usrPrntTemplateDir);
                          num2 = (short) 0;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        default:
label_39:
                          if (!Directory.Exists(usrPrntTemplateDir))
                          {
                            num2 = (short) 3;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 0;
                      }
                    }
                  }
                  catch (Exception ex)
                  {
                    Console.WriteLine(RptMgrErrorHandler.b("쪎\uE390\uE192杖\uE596릘\uF89A\uEF9C爵삠힢첤즦캨讪\uD9AC쪮\uDCB0쎲閴펶킸즺\uD8BC\uDCBE뗀곂럄뻆\uE7C8", A_1) + ex.Message);
                  }
label_75:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  saveFileDialog = new SaveFileDialog();
                  saveFileDialog.Title = AppResources.Save_As;
                  saveFileDialog.InitialDirectory = usrPrntTemplateDir;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (Directory.Exists(usrPrntTemplateDir))
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_152;
                case 10:
                  if (File.Exists(this.tvAvailable.Tag.ToString()))
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  nullable = saveFileDialog.ShowDialog();
                  flag4 = true;
                  num2 = (short) 47;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  if (path.Length > 0)
                  {
                    num2 = (short) 25;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_152;
                case 12:
                  Global.usrLastSavedContainer.Add(path);
                  num2 = (short) 33;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  switch (A_0)
                  {
                    case PageSelectPrintItems.serializeAction.saveAs:
                    case PageSelectPrintItems.serializeAction.save:
                      num2 = (short) 32 /*0x20*/;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    default:
                      goto label_152;
                  }
                case 14:
                  Global.usrLastSavedContainer.Add(path);
                  num2 = (short) 30;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num2 = (short) 21802;
                  int num4 = (int) num2;
                  num2 = (short) 21802;
                  int num5 = (int) num2;
                  switch (num4 == num5 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_56;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        ;
                      if (!flag3)
                      {
                        num2 = (short) 14;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_30;
                  }
                case 16 /*0x10*/:
                  if (Global.usrLastSavedContainer.Count > 0)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 41;
                case 17:
                case 22:
                  saveFileDialog.FilterIndex = 1;
                  saveFileDialog.RestoreDirectory = true;
                  num2 = (short) 34;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  saveFileDialog.Filter = AppResources.Vertex_Standard_Template_File_Filter;
                  num2 = (short) 22;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  saveFileDialog.FileName += RptMgrErrorHandler.b("ꆎ\uE590\uE392璉", A_1);
                  path = saveFileDialog.FileName;
                  num2 = (short) 37;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 20:
                  if (nullable.GetValueOrDefault() == flag4 & nullable.HasValue)
                  {
                    num2 = (short) 42;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 21:
                  if (!path.ToLower().EndsWith(RptMgrErrorHandler.b("ꆎ\uE590\uE392璉", A_1)))
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 23:
                  if (!path.ToLower().EndsWith(RptMgrErrorHandler.b("ꆎ\uE590\uE392璉", A_1)))
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 37;
                case 24:
                  if (!flag2)
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 25:
                  flag1 = true;
                  num2 = (short) 13;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 26:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 27:
                  if (saveFileDialog.InitialDirectory != str1)
                  {
                    num2 = (short) 39;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 28:
                  goto label_83;
                case 29:
                  if (saveFileDialog.InitialDirectory != str2)
                  {
                    num2 = (short) 49;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 30:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    goto case 33;
                  goto case 33;
                case 31 /*0x1F*/:
                  flag2 = true;
                  num2 = (short) 35;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 32 /*0x20*/:
                  num2 = (short) 40;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 33:
                case 46:
label_30:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 34:
                  if (this.tvAvailable.Tag != null)
                  {
                    num2 = (short) 45;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 35:
                  num2 = (short) 24;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 36:
                  path = saveFileDialog.FileName;
                  num2 = (short) 23;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 37:
                  flag3 = false;
                  str2 = saveFileDialog.FileName.Remove(saveFileDialog.FileName.IndexOf(saveFileDialog.SafeFileName) - 1, saveFileDialog.SafeFileName.Length + 1);
                  num2 = (short) 29;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 38:
                  if (Global.usrLastSavedContainer.Count > 0)
                  {
                    num2 = (short) 48 /*0x30*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 39:
                  num2 = (short) 38;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 40:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 28;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_152;
                case 41:
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 42:
                  path = saveFileDialog.FileName;
                  num2 = (short) 21;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 43:
                  if (A_0 == PageSelectPrintItems.serializeAction.save)
                  {
                    num2 = (short) 26;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 44:
                  if (Global.usrLastSavedContainer.Contains(path))
                  {
                    num2 = (short) 31 /*0x1F*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 35;
                case 45:
                  num2 = (short) 43;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 47:
                  if (nullable.GetValueOrDefault() == flag4 & nullable.HasValue)
                  {
                    num2 = (short) 36;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 33;
                case 48 /*0x30*/:
                  num2 = (short) 44;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 49:
label_56:
                  num2 = (short) 16 /*0x10*/;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              nullable = saveFileDialog.ShowDialog();
              flag4 = true;
              num2 = (short) 20;
              num1 = (int) (IntPtr) num2;
            }
label_83:
            try
            {
              FileAttributes fileAttributes;
              switch (0)
              {
                case 0:
label_85:
                  fileAttributes = FileAttributes.ReadOnly;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  goto default;
                default:
                  BinaryFormatter binaryFormatter;
                  FileStream serializationStream;
                  ReportsSerializeItems graph;
                  IEnumerator enumerator1;
                  while (true)
                  {
                    switch (num1)
                    {
                      case 0:
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 1:
                        if (!fileAttributes.ToString().Equals(RptMgrErrorHandler.b("\uDD8E\uF490\uF292\uF194\uD896\uF798\uF79A\uE49C", A_1)))
                        {
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 6;
                      case 2:
                        if ((File.GetAttributes(path) & FileAttributes.ReadOnly) != FileAttributes.ReadOnly)
                        {
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 3;
                      case 3:
                        serializationStream = new FileStream(path, FileMode.Create);
                        binaryFormatter = new BinaryFormatter();
                        graph = new ReportsSerializeItems();
                        enumerator1 = ((IEnumerable) this.tvSelected.Items).GetEnumerator();
                        num2 = (short) 7;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 4:
                        File.SetAttributes(path, FileAttributes.Normal);
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 5:
                        File.SetAttributes(path, fileAttributes);
                        num2 = (short) 6;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 6:
                        num2 = (short) 8;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 7:
                        IDisposable disposable;
                        try
                        {
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          while (true)
                          {
                            RptTreeViewItem current1;
                            IEnumerator enumerator2;
                            switch (num1)
                            {
                              case 0:
                                num2 = (short) 2;
                                num1 = (int) (IntPtr) num2;
                                continue;
                              case 1:
                                try
                                {
                                  num2 = (short) 3;
                                  num1 = (int) (IntPtr) num2;
                                  while (true)
                                  {
                                    IEnumerator enumerator3;
                                    switch (num1)
                                    {
                                      case 0:
                                        try
                                        {
                                          num2 = (short) 6;
                                          num1 = (int) (IntPtr) num2;
                                          while (true)
                                          {
                                            RptTreeViewItem current2;
                                            switch (num1)
                                            {
                                              case 0:
                                                goto label_107;
                                              case 1:
                                                num2 = (short) 0;
                                                num1 = (int) (IntPtr) num2;
                                                continue;
                                              case 3:
                                                Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uDF8E\uF090\uE792ﶔ궖\uE298ꮚ\uE09C", A_1), (object) current2.RptPath));
                                                num2 = (short) 2;
                                                num1 = (int) (IntPtr) num2;
                                                continue;
                                              case 4:
                                                if (!graph.sField.ContainsKey(current2.RptPath))
                                                {
                                                  num2 = (short) 7;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                }
                                                goto case 3;
                                              case 5:
                                                if (enumerator3.MoveNext())
                                                {
                                                  current2 = (RptTreeViewItem) enumerator3.Current;
                                                  num2 = (short) 4;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                }
                                                num2 = (short) 1;
                                                num1 = (int) (IntPtr) num2;
                                                continue;
                                              case 6:
                                                switch (0)
                                                {
                                                  case 0:
                                                    break;
                                                  default:
                                                    continue;
                                                }
                                                break;
                                              case 7:
                                                graph.sField.Add(current2.RptPath, current1.ID);
                                                num2 = (short) 3;
                                                num1 = (int) (IntPtr) num2;
                                                continue;
                                            }
                                            num2 = (short) 5;
                                            num1 = (int) (IntPtr) num2;
                                          }
                                        }
                                        finally
                                        {
                                          short num6;
                                          switch (0)
                                          {
                                            case 0:
label_124:
                                              disposable = enumerator3 as IDisposable;
                                              num6 = (short) 1;
                                              num1 = (int) (IntPtr) num6;
                                              goto default;
                                            default:
                                              while (true)
                                              {
                                                switch (num1)
                                                {
                                                  case 0:
                                                    goto label_128;
                                                  case 1:
                                                    if (disposable != null)
                                                    {
                                                      num6 = (short) 2;
                                                      num1 = (int) (IntPtr) num6;
                                                      continue;
                                                    }
                                                    goto label_128;
                                                  case 2:
                                                    disposable.Dispose();
                                                    num6 = (short) 0;
                                                    num1 = (int) (IntPtr) num6;
                                                    continue;
                                                  default:
                                                    goto label_124;
                                                }
                                              }
label_128:;
                                          }
                                        }
                                      case 1:
                                        if (!enumerator2.MoveNext())
                                        {
                                          num2 = (short) 4;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        }
                                        enumerator3 = ((IEnumerable) ((ItemsControl) enumerator2.Current).Items).GetEnumerator();
                                        num2 = (short) 0;
                                        num1 = (int) (IntPtr) num2;
                                        continue;
                                      case 2:
                                        goto label_138;
                                      case 3:
                                        switch (0)
                                        {
                                          case 0:
                                            break;
                                          default:
                                            continue;
                                        }
                                        break;
                                      case 4:
                                        num2 = (short) 2;
                                        num1 = (int) (IntPtr) num2;
                                        continue;
                                    }
label_107:
                                    num1 = 1;
                                  }
                                }
                                finally
                                {
                                  short num7;
                                  switch (0)
                                  {
                                    case 0:
label_133:
                                      disposable = enumerator2 as IDisposable;
                                      num7 = (short) 1;
                                      num1 = (int) (IntPtr) num7;
                                      goto default;
                                    default:
                                      while (true)
                                      {
                                        switch (num1)
                                        {
                                          case 0:
                                            goto label_137;
                                          case 1:
                                            if (disposable != null)
                                            {
                                              num7 = (short) 2;
                                              num1 = (int) (IntPtr) num7;
                                              continue;
                                            }
                                            goto label_137;
                                          case 2:
                                            disposable.Dispose();
                                            num7 = (short) 0;
                                            num1 = (int) (IntPtr) num7;
                                            continue;
                                          default:
                                            goto label_133;
                                        }
                                      }
label_137:;
                                  }
                                }
                              case 2:
                                goto label_88;
                              case 3:
                                switch (0)
                                {
                                  case 0:
                                    break;
                                  default:
                                    continue;
                                }
                                break;
                              case 4:
                                if (enumerator1.MoveNext())
                                {
                                  current1 = (RptTreeViewItem) enumerator1.Current;
                                  enumerator2 = ((IEnumerable) current1.Items).GetEnumerator();
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                }
                                num2 = (short) 0;
                                num1 = (int) (IntPtr) num2;
                                continue;
                            }
label_138:
                            num2 = (short) 4;
                            num1 = (int) (IntPtr) num2;
                          }
                        }
                        finally
                        {
                          short num8;
                          switch (0)
                          {
                            case 0:
label_144:
                              disposable = enumerator1 as IDisposable;
                              num8 = (short) 0;
                              num1 = (int) (IntPtr) num8;
                              goto default;
                            default:
                              while (true)
                              {
                                switch (num1)
                                {
                                  case 0:
                                    if (disposable != null)
                                    {
                                      num8 = (short) 1;
                                      num1 = (int) (IntPtr) num8;
                                      continue;
                                    }
                                    goto label_148;
                                  case 1:
                                    disposable.Dispose();
                                    num8 = (short) 2;
                                    num1 = (int) (IntPtr) num8;
                                    continue;
                                  case 2:
                                    goto label_148;
                                  default:
                                    goto label_144;
                                }
                              }
label_148:;
                          }
                        }
label_88:
                        binaryFormatter.Serialize((Stream) serializationStream, (object) graph);
                        serializationStream.Close();
                        num1 = 1;
                        continue;
                      case 8:
                        goto label_152;
                      case 9:
                        fileAttributes = File.GetAttributes(path);
                        num2 = (short) 11;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 10:
                        if (File.Exists(path))
                        {
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 3;
                      case 11:
                        if (!fileAttributes.ToString().Equals(RptMgrErrorHandler.b("솎ﺐ\uE192\uF894\uF696\uF598", A_1)))
                        {
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        goto case 3;
                      default:
                        goto label_85;
                    }
                  }
              }
            }
            catch (Exception ex)
            {
              flag1 = false;
              int num9 = (int) MessageBox.Show(ex.Message);
            }
label_152:
            return flag1;
        }
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num = -13549;
    switch ((short) -13549 == num)
    {
      case true:
        num = (short) 1;
        if (num == (short) 0)
          ;
        num = (short) 0;
        if (num == (short) 0)
          ;
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void buttonHelp_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 9;
    try
    {
      short num1 = -27765;
      int num2 = (int) num1;
      num1 = (short) -27765;
      int num3 = (int) num1;
      switch (num2 == num3)
      {
        case true:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("꾋뺍\uA48Fꂑ\uF793ꚕꦗ겙瀞", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
    if (false)
      ;
  }

  internal void OnClickAdd(object sender, RoutedEventArgs e)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        RptTreeViewItem rptTreeViewItem1;
        RptTreeViewItem rptTreeViewItem2;
        RptTreeViewItem selectedItem;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 13870;
            int num3 = (int) num2;
            num2 = (short) 13870;
            int num4 = (int) num2;
            switch (num3 == num4 ? 1 : 0)
            {
              case 0:
              case 2:
                break;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                rptTreeViewItem1 = new RptTreeViewItem();
                rptTreeViewItem2 = new RptTreeViewItem();
                RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                RptTreeViewItem rptTreeViewItem4 = new RptTreeViewItem();
                selectedItem = (RptTreeViewItem) this.tvAvailable.SelectedItem;
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                goto label_2;
            }
            break;
          default:
            while (true)
            {
              int itemType;
              switch (num1)
              {
                case 0:
                  goto label_21;
                case 1:
                  this.SortItems(ref this.tvSelected);
                  this.btnSave.IsEnabled = true;
                  this.btnSaveAs.IsEnabled = true;
                  this.btnRemSelectedItems.IsEnabled = true;
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (selectedItem == null)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.tvAvailable.ItemContainerGenerator.IndexFromContainer((DependencyObject) selectedItem);
                  itemType = selectedItem.ItemType;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_22;
                case 5:
                  switch (itemType)
                  {
                    case 0:
                      RptTreeViewItem A_0 = selectedItem;
                      rptTreeViewItem1 = (RptTreeViewItem) null;
                      rptTreeViewItem2 = (RptTreeViewItem) null;
                      this.c(A_0);
                      this.d(A_0);
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      RptTreeViewItem parent1 = (RptTreeViewItem) selectedItem.Parent;
                      RptTreeViewItem A_1 = selectedItem;
                      this.c(parent1, A_1);
                      this.e(parent1, A_1);
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      RptTreeViewItem parent2 = (RptTreeViewItem) selectedItem.Parent;
                      RptTreeViewItem parent3 = (RptTreeViewItem) parent2.Parent;
                      RptTreeViewItem gItem = selectedItem;
                      this.RmvFromAvailableTreeItems(parent3, parent2, gItem);
                      this.AddToSelectedTreeItems(parent3, parent2, gItem);
                      num2 = (short) 1;
                      if (num2 == (short) 0)
                        ;
                      num2 = (short) 9;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    default:
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 6:
                case 7:
                case 9:
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  goto label_8;
                case 10:
                  goto label_22;
                default:
                  goto label_3;
              }
label_2:;
            }
label_21:
            return;
label_22:
            num2 = (short) 0;
            return;
        }
label_8:
        int num5 = (int) MessageBox.Show(AppResources.Invalid_Node_Type_Process_Aborted);
        break;
    }
  }

  private void d(RptTreeViewItem A_0)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        bool flag;
        switch (0)
        {
          case 0:
label_4:
            num2 = (short) 0;
            flag = false;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              IEnumerator enumerator;
              switch (num1)
              {
                case 0:
                  enumerator = ((IEnumerable) this.tvSelected.Items).GetEnumerator();
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  this.tvSelected.Items.Add((object) A_0);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  this.a(ref this.tvSelected, A_0.ID);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                case 9:
                  goto label_37;
                case 5:
                  if (flag)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_37;
                case 6:
                  if (!flag)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 7:
                  this.tvSelected.Items.Add((object) A_0);
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  try
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      RptTreeViewItem current;
                      switch (num1)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          this.tvSelected.Items.Remove((object) current);
                          flag = true;
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (current.Header.ToString() == A_0.Header.ToString())
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
                          if (enumerator.MoveNext())
                          {
                            current = (RptTreeViewItem) enumerator.Current;
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          goto label_22;
                        case 5:
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          goto label_34;
                      }
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                    }
label_22:
                    num2 = (short) -17162;
                    int num3 = (int) num2;
                    num2 = (short) -17162;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          break;
                        break;
                    }
                  }
                  finally
                  {
                    IDisposable disposable;
                    short num5;
                    switch (0)
                    {
                      case 0:
label_26:
                        disposable = enumerator as IDisposable;
                        num5 = (short) 0;
                        num1 = (int) (IntPtr) num5;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              if (disposable != null)
                              {
                                num5 = (short) 1;
                                num1 = (int) (IntPtr) num5;
                                continue;
                              }
                              goto label_30;
                            case 1:
                              disposable.Dispose();
                              num5 = (short) 2;
                              num1 = (int) (IntPtr) num5;
                              continue;
                            case 2:
                              goto label_30;
                            default:
                              goto label_26;
                          }
                        }
label_30:;
                    }
                  }
label_34:
                  num1 = 6;
                  continue;
                default:
                  goto label_4;
              }
            }
label_37:
            this.btnRemSelectedItems.IsEnabled = true;
            return;
        }
    }
  }

  private void e(RptTreeViewItem A_0, RptTreeViewItem A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator enumerator1;
              RptTreeViewItem rptTreeViewItem1;
              IDisposable disposable;
              switch (num1)
              {
                case 0:
                  try
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num1)
                      {
                        case 1:
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          goto label_6;
                        case 3:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          RptTreeViewItem current = (RptTreeViewItem) enumerator1.Current;
                          RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
                          this.d(current, rptTreeViewItem2);
                          rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                      }
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num3;
                    switch (0)
                    {
                      case 0:
label_19:
                        disposable = enumerator1 as IDisposable;
                        num3 = (short) 2;
                        num1 = (int) (IntPtr) num3;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              disposable.Dispose();
                              num3 = (short) 1;
                              num1 = (int) (IntPtr) num3;
                              continue;
                            case 1:
                              goto label_23;
                            case 2:
                              if (disposable != null)
                              {
                                num3 = (short) 0;
                                num1 = (int) (IntPtr) num3;
                                continue;
                              }
                              goto label_23;
                            default:
                              goto label_19;
                          }
                        }
label_23:;
                    }
                  }
                case 1:
                  goto label_92;
                case 2:
                  if (!flag)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 3:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  this.btnRemSelectedItems.IsEnabled = true;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                  this.d(A_0, rptTreeViewItem3);
                  this.tvSelected.Items.Add((object) rptTreeViewItem3);
                  rptTreeViewItem1 = new RptTreeViewItem();
                  this.d(A_1, rptTreeViewItem1);
                  rptTreeViewItem3.Items.Add((object) rptTreeViewItem1);
                  enumerator1 = ((IEnumerable) A_1.Items).GetEnumerator();
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  try
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    IEnumerator enumerator2;
                    RptTreeViewItem rptTreeViewItem4;
                    while (true)
                    {
                      RptTreeViewItem current1;
                      switch (num1)
                      {
                        case 0:
                          goto label_88;
                        case 1:
                          flag = true;
                          enumerator2 = ((IEnumerable) A_1.Items).GetEnumerator();
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          goto label_56;
                        case 3:
                          if (enumerator1.MoveNext())
                          {
                            current1 = (RptTreeViewItem) enumerator1.Current;
                            num2 = (short) 10;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          try
                          {
                            num2 = (short) 6;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              RptTreeViewItem current2;
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                case 4:
                                  goto label_48;
                                case 2:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = (RptTreeViewItem) enumerator2.Current;
                                    num2 = (short) 3;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 0;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (current2.Header.ToString() == A_1.Header.ToString())
                                  {
                                    num2 = (short) 5;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 5:
                                  rptTreeViewItem4 = current2;
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 6:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                              }
                              num2 = (short) 2;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num4;
                            switch (0)
                            {
                              case 0:
label_43:
                                disposable = enumerator2 as IDisposable;
                                num4 = (short) 2;
                                num1 = (int) (IntPtr) num4;
                                goto default;
                              default:
                                while (true)
                                {
                                  switch (num1)
                                  {
                                    case 0:
                                      disposable.Dispose();
                                      num4 = (short) 1;
                                      num1 = (int) (IntPtr) num4;
                                      continue;
                                    case 1:
                                      goto label_47;
                                    case 2:
                                      if (disposable != null)
                                      {
                                        num4 = (short) 0;
                                        num1 = (int) (IntPtr) num4;
                                        continue;
                                      }
                                      goto label_47;
                                    default:
                                      goto label_43;
                                  }
                                }
label_47:;
                            }
                          }
label_48:
                          num1 = 6;
                          continue;
                        case 5:
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (rptTreeViewItem4 == null)
                          {
                            num2 = (short) 9;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 1;
                        case 7:
                          rptTreeViewItem1 = new RptTreeViewItem();
                          rptTreeViewItem4 = (RptTreeViewItem) null;
                          enumerator2 = ((IEnumerable) current1.Items).GetEnumerator();
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 9:
                          this.d(A_1, rptTreeViewItem1);
                          current1.Items.Add((object) rptTreeViewItem1);
                          rptTreeViewItem4 = rptTreeViewItem1;
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (!(current1.Header.ToString() != A_0.Header.ToString()))
                          {
                            num2 = (short) 7;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                      }
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                    }
label_56:
                    try
                    {
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      while (true)
                      {
                        switch (num1)
                        {
                          case 0:
                            num2 = (short) 27127;
                            int num5 = (int) num2;
                            num2 = (short) 27127;
                            int num6 = (int) num2;
                            switch (num5 == num6 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                break;
                              default:
                                num2 = (short) 0;
                                if (num2 == (short) 0)
                                  ;
                                num2 = (short) 2;
                                num1 = (int) (IntPtr) num2;
                                continue;
                            }
                            break;
                          case 1:
                            if (enumerator2.MoveNext())
                            {
                              RptTreeViewItem current = (RptTreeViewItem) enumerator2.Current;
                              RptTreeViewItem rptTreeViewItem5 = new RptTreeViewItem();
                              this.d(current, rptTreeViewItem5);
                              rptTreeViewItem4.Items.Add((object) rptTreeViewItem5);
                              num2 = (short) 3;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            }
                            break;
                          case 2:
                            goto label_88;
                          case 4:
                            switch (0)
                            {
                              case 0:
                                goto label_60;
                              default:
                                continue;
                            }
                          default:
label_60:
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                        }
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                      }
                    }
                    finally
                    {
                      short num7;
                      switch (0)
                      {
                        case 0:
label_68:
                          disposable = enumerator2 as IDisposable;
                          num7 = (short) 2;
                          num1 = (int) (IntPtr) num7;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                disposable.Dispose();
                                num7 = (short) 1;
                                num1 = (int) (IntPtr) num7;
                                continue;
                              case 1:
                                goto label_72;
                              case 2:
                                if (disposable != null)
                                {
                                  num7 = (short) 0;
                                  num1 = (int) (IntPtr) num7;
                                  continue;
                                }
                                goto label_72;
                              default:
                                goto label_68;
                            }
                          }
label_72:;
                      }
                    }
                  }
                  finally
                  {
                    switch (0)
                    {
                      case 0:
label_77:
                        disposable = enumerator1 as IDisposable;
                        num1 = 2;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              disposable.Dispose();
                              num1 = 1;
                              continue;
                            case 1:
                              goto label_81;
                            case 2:
                              if (disposable != null)
                              {
                                num1 = 0;
                                continue;
                              }
                              goto label_81;
                            default:
                              goto label_77;
                          }
                        }
label_81:;
                    }
                  }
                case 6:
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_92;
                case 8:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_88;
                case 9:
                  if (!this.btnRemSelectedItems.IsEnabled)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_92;
                case 10:
                  enumerator1 = ((IEnumerable) this.tvSelected.Items).GetEnumerator();
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_6:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
label_88:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
            }
label_92:
            num2 = (short) 0;
            return;
        }
    }
  }

  internal void AddToSelectedTreeItems(
    RptTreeViewItem pItem,
    RptTreeViewItem cItem,
    RptTreeViewItem gItem)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator enumerator1;
              switch (num1)
              {
                case 0:
                  RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
                  this.d(pItem, rptTreeViewItem1);
                  this.tvSelected.Items.Add((object) rptTreeViewItem1);
                  RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
                  this.d(cItem, rptTreeViewItem2);
                  rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                  RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                  this.d(gItem, rptTreeViewItem3);
                  rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (!this.btnRemSelectedItems.IsEnabled)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_61;
                case 2:
                  this.btnRemSelectedItems.IsEnabled = true;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  goto label_61;
                case 4:
                  if (!flag)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 9;
                case 5:
                  IDisposable disposable;
                  try
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      RptTreeViewItem current1;
                      IEnumerator enumerator2;
                      switch (num1)
                      {
                        case 0:
                        case 2:
                          goto label_58;
                        case 1:
                          if (!flag)
                          {
                            num2 = (short) 5;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
                          if (!(current1.Header.ToString() != pItem.Header.ToString()))
                          {
                            num2 = (short) 4;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 4:
                          enumerator2 = ((IEnumerable) current1.Items).GetEnumerator();
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          RptTreeViewItem rptTreeViewItem4 = new RptTreeViewItem();
                          this.d(cItem, rptTreeViewItem4);
                          current1.Items.Add((object) rptTreeViewItem4);
                          RptTreeViewItem rptTreeViewItem5 = new RptTreeViewItem();
                          this.d(gItem, rptTreeViewItem5);
                          rptTreeViewItem4.Items.Add((object) rptTreeViewItem5);
                          flag = true;
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 8;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current1 = (RptTreeViewItem) enumerator1.Current;
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 8:
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          try
                          {
                            num2 = (short) 6;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              RptTreeViewItem current2;
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                case 4:
                                  goto label_42;
                                case 2:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = (RptTreeViewItem) enumerator2.Current;
                                    num2 = (short) 3;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 0;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (current2.Header == cItem.Header)
                                  {
                                    num2 = (short) 5;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 5:
                                  RptTreeViewItem rptTreeViewItem6 = new RptTreeViewItem();
                                  this.d(gItem, rptTreeViewItem6);
                                  current2.Items.Add((object) rptTreeViewItem6);
                                  flag = true;
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 6:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                              }
                              num2 = (short) 2;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num3;
                            switch (0)
                            {
                              case 0:
label_32:
                                disposable = enumerator2 as IDisposable;
                                num3 = (short) 2;
                                num1 = (int) (IntPtr) num3;
                                goto default;
                              default:
                                while (true)
                                {
                                  switch (num1)
                                  {
                                    case 0:
label_35:
                                      disposable.Dispose();
                                      num3 = (short) 1;
                                      num1 = (int) (IntPtr) num3;
                                      continue;
                                    case 1:
                                      num3 = (short) -18646;
                                      int num4 = (int) num3;
                                      num3 = (short) -18646;
                                      int num5 = (int) num3;
                                      switch (num4 == num5 ? 1 : 0)
                                      {
                                        case 0:
                                        case 2:
                                          goto label_35;
                                        default:
                                          goto label_37;
                                      }
                                    case 2:
                                      if (disposable != null)
                                      {
                                        num3 = (short) 0;
                                        num1 = (int) (IntPtr) num3;
                                        continue;
                                      }
                                      goto case 1;
                                    default:
                                      goto label_32;
                                  }
                                }
label_37:
                                num3 = (short) 0;
                                if (num3 == (short) 0)
                                  ;
                            }
                          }
label_42:
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num6;
                    switch (0)
                    {
                      case 0:
label_48:
                        disposable = enumerator1 as IDisposable;
                        num6 = (short) 2;
                        num1 = (int) (IntPtr) num6;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              disposable.Dispose();
                              num6 = (short) 1;
                              num1 = (int) (IntPtr) num6;
                              continue;
                            case 1:
                              goto label_52;
                            case 2:
                              if (disposable != null)
                              {
                                num6 = (short) 0;
                                num1 = (int) (IntPtr) num6;
                                continue;
                              }
                              goto label_52;
                            default:
                              goto label_48;
                          }
                        }
label_52:;
                    }
                  }
                case 6:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_61;
                case 8:
                  if (this.tvSelected.Items.Count > 0)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 9:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  enumerator1 = ((IEnumerable) this.tvSelected.Items).GetEnumerator();
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_58:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
            }
label_61:
            num2 = (short) 0;
            return;
        }
    }
  }

  private void d(RptTreeViewItem A_0, RptTreeViewItem A_1)
  {
    short num1 = 0;
    num1 = (short) 19906;
    int num2 = (int) num1;
    num1 = (short) 19906;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        A_1.RptRecordName = A_0.RptRecordName;
        A_1.Header = A_0.Header;
        A_1.ID = A_0.ID;
        A_1.ParentID = A_0.ParentID;
        A_1.ItemType = A_0.ItemType;
        A_1.RptPath = A_0.RptPath;
        break;
      default:
        goto case 1;
    }
  }

  private void c(RptTreeViewItem A_0)
  {
    short num1 = 24394;
    int num2 = (int) num1;
    num1 = (short) 24394;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_7:
        num4 = (short) 0;
        num5 = (int) (IntPtr) num4;
        break;
      case 1:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            goto label_6;
        }
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
    while (true)
    {
      switch (num5)
      {
        case 0:
          if (this.tvAvailable.Items.Count == 0)
          {
            num4 = (short) 1;
            num5 = (int) (IntPtr) num4;
            continue;
          }
          goto label_13;
        case 1:
          this.btnAddSelectedItems.IsEnabled = false;
          num4 = (short) 2;
          num5 = (int) (IntPtr) num4;
          continue;
        case 2:
          goto label_12;
        default:
          goto label_6;
      }
    }
label_13:
    return;
label_12:
    num4 = (short) 1;
    if (num4 == (short) 0)
      ;
    return;
label_6:
    this.tvAvailable.Items.Remove((object) A_0);
    goto label_7;
  }

  private void c(RptTreeViewItem A_0, RptTreeViewItem A_1)
  {
    int num1 = 9;
    while (true)
    {
      short num2;
      int num3;
      RptTreeViewItem itemAt;
      int num4;
      switch (num1)
      {
        case 0:
          if (this.btnAddSelectedItems.IsEnabled)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_39;
        case 1:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          num4 = 0;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
        case 7:
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          itemAt.Items.RemoveAt(num3);
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
        case 15:
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          if (((HeaderedItemsControl) itemAt.Items.GetItemAt(num3)).Header != A_1.Header)
          {
            ++num3;
            num2 = (short) 15;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          if (!(itemAt.Header.ToString() != A_0.Header.ToString()))
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 17;
        case 8:
          this.btnAddSelectedItems.IsEnabled = false;
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
label_1:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 10:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          if (itemAt.Items.Count == 0)
          {
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 21;
        case 12:
          num3 = 0;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          if (this.tvAvailable.Items.Count == 0)
          {
            num2 = (short) 8405;
            int num5 = (int) num2;
            num2 = (short) 8405;
            int num6 = (int) num2;
            switch (num5 == num6 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_1;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_37;
        case 14:
          if (num3 >= itemAt.Items.Count)
          {
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 16 /*0x10*/:
          this.tvAvailable.Items.RemoveAt(num4);
          num2 = (short) 21;
          num1 = (int) (IntPtr) num2;
          continue;
        case 17:
          ++num4;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 18:
          if (num4 < this.tvAvailable.Items.Count)
          {
            RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
            itemAt = (RptTreeViewItem) this.tvAvailable.Items.GetItemAt(num4);
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 19;
          num1 = (int) (IntPtr) num2;
          continue;
        case 19:
          goto label_34;
        case 20:
          goto label_35;
        case 21:
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
      }
      if (this.tvAvailable.Items.Count > 0)
      {
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
      }
      else
        goto label_6;
    }
label_34:
    return;
label_35:
    return;
label_6:
    return;
label_39:
    return;
label_37:;
  }

  internal void RmvFromAvailableTreeItems(
    RptTreeViewItem pItem,
    RptTreeViewItem cItem,
    RptTreeViewItem gItem)
  {
    switch (0)
    {
      default:
        int num1 = 5;
        short num2;
        while (true)
        {
          RptTreeViewItem itemAt1;
          int num3;
          RptTreeViewItem itemAt2;
          int num4;
          int num5;
          switch (num1)
          {
            case 0:
            case 22:
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num5 = 0;
              num2 = (short) 24;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              itemAt2.Items.RemoveAt(num5);
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (itemAt2.Header == cItem.Header)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ++num3;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 4:
              this.tvAvailable.Items.RemoveAt(num4);
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 5:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 6:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (!(itemAt1.Header.ToString() != pItem.Header.ToString()))
              {
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 28;
            case 8:
              if (num5 >= itemAt2.Items.Count)
              {
                num2 = (short) 21;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
              num2 = (short) 13;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              if (this.tvAvailable.Items.Count == 0)
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_50;
            case 10:
              this.btnAddSelectedItems.IsEnabled = false;
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if (itemAt1.Items.Count == 0)
              {
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 16 /*0x10*/;
            case 12:
              goto label_46;
            case 13:
              if (!(((HeaderedItemsControl) itemAt2.Items.GetItemAt(num5)).Header.ToString() != gItem.Header.ToString()))
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ++num5;
              num2 = (short) 29;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
            case 21:
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 15:
              if (itemAt2.Items.Count == 0)
              {
                num2 = (short) 30;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 14;
            case 16 /*0x10*/:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
            case 23:
              num2 = (short) 27;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              num4 = 0;
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              num3 = 0;
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 20:
              goto label_53;
            case 24:
              num2 = (short) 0;
              goto case 29;
            case 25:
              if (num4 >= this.tvAvailable.Items.Count)
              {
                num2 = (short) 20;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
              itemAt1 = (RptTreeViewItem) this.tvAvailable.Items.GetItemAt(num4);
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 26:
              if (this.btnAddSelectedItems.IsEnabled)
              {
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_52;
            case 27:
              if (num3 < itemAt1.Items.Count)
              {
                num2 = (short) 16979;
                int num6 = (int) num2;
                num2 = (short) 16979;
                int num7 = (int) num2;
                switch (num6 == num7 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_53;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                    itemAt2 = (RptTreeViewItem) itemAt1.Items.GetItemAt(num3);
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
            case 28:
              ++num4;
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
            case 29:
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              itemAt1.Items.RemoveAt(num3);
              num2 = (short) 14;
              num1 = (int) (IntPtr) num2;
              continue;
          }
          if (this.tvAvailable.Items.Count > 0)
          {
            num2 = (short) 18;
            num1 = (int) (IntPtr) num2;
          }
          else
            goto label_53;
        }
label_46:
        break;
label_52:
        break;
label_50:
        break;
label_53:
        num2 = (short) 1;
        if (num2 == (short) 0)
          break;
        break;
    }
  }

  internal void OnClickRmv(object sender, RoutedEventArgs e)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        RptTreeViewItem rptTreeViewItem1;
        RptTreeViewItem rptTreeViewItem2;
        RptTreeViewItem selectedItem;
        switch (0)
        {
          case 0:
label_3:
            num2 = (short) 0;
            rptTreeViewItem1 = new RptTreeViewItem();
            rptTreeViewItem2 = new RptTreeViewItem();
            RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
            RptTreeViewItem rptTreeViewItem4 = new RptTreeViewItem();
            selectedItem = (RptTreeViewItem) this.tvSelected.SelectedItem;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            int itemType;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  goto label_27;
                case 1:
                  if (selectedItem == null)
                  {
                    num2 = (short) 32764;
                    int num3 = (int) num2;
                    num2 = (short) 32764;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_16;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                  }
                  else
                  {
                    itemType = selectedItem.ItemType;
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                case 2:
                  this.btnSave.IsEnabled = false;
                  this.btnSaveAs.IsEnabled = false;
                  this.btnRemSelectedItems.IsEnabled = false;
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
label_16:
                  if (this.tvSelected.Items.Count == 0)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_19;
                case 4:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  switch (itemType)
                  {
                    case 0:
                      RptTreeViewItem A_0 = selectedItem;
                      rptTreeViewItem1 = (RptTreeViewItem) null;
                      rptTreeViewItem2 = (RptTreeViewItem) null;
                      this.a(A_0);
                      this.b(A_0);
                      num2 = (short) 13;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      RptTreeViewItem parent1 = (RptTreeViewItem) selectedItem.Parent;
                      RptTreeViewItem A_1 = selectedItem;
                      this.b(parent1, A_1);
                      this.a(parent1, A_1);
                      num2 = (short) 10;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      RptTreeViewItem parent2 = (RptTreeViewItem) selectedItem.Parent;
                      RptTreeViewItem parent3 = (RptTreeViewItem) parent2.Parent;
                      RptTreeViewItem A_2 = selectedItem;
                      this.b(parent3, parent2, A_2);
                      this.a(parent3, parent2, A_2);
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    default:
                      num2 = (short) 11;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                case 6:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 4;
                case 7:
                case 10:
                case 13:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  goto label_25;
                case 9:
                  this.SortItems(ref this.tvAvailable);
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 12:
                  goto label_24;
                default:
                  goto label_3;
              }
            }
label_27:
            return;
label_24:
            return;
label_19:
            return;
label_25:
            int num5 = (int) MessageBox.Show(AppResources.Invalid_Node_Type_Process_Aborted);
            return;
        }
    }
  }

  private void b(RptTreeViewItem A_0)
  {
    int num1 = 0;
    while (true)
    {
      short num2;
      IEnumerator enumerator;
      switch (num1)
      {
        case 0:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 1:
          if (this.tvAvailable.Items.Count > 0)
          {
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_35;
        case 2:
          goto label_31;
        case 3:
          enumerator = ((IEnumerable) this.tvAvailable.Items).GetEnumerator();
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) 1;
          if (num2 == (short) 0)
            goto case 4;
          goto case 4;
        case 6:
          num2 = (short) -13186;
          int num3 = (int) num2;
          num2 = (short) -13186;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              break;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              try
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                while (true)
                {
                  RptTreeViewItem current;
                  switch (num1)
                  {
                    case 0:
                      switch (0)
                      {
                        case 0:
                          break;
                        default:
                          continue;
                      }
                      break;
                    case 1:
                      this.tvAvailable.Items.Remove((object) current);
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                    case 6:
                      goto label_7;
                    case 3:
                      if (enumerator.MoveNext())
                      {
                        current = (RptTreeViewItem) enumerator.Current;
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                      if (current.Header.ToString() == A_0.Header.ToString())
                      {
                        num2 = (short) 1;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      break;
                    case 5:
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                  }
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                }
              }
              finally
              {
                IDisposable disposable;
                short num5;
                switch (0)
                {
                  case 0:
label_22:
                    disposable = enumerator as IDisposable;
                    num5 = (short) 0;
                    num1 = (int) (IntPtr) num5;
                    goto default;
                  default:
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          if (disposable != null)
                          {
                            num5 = (short) 1;
                            num1 = (int) (IntPtr) num5;
                            continue;
                          }
                          goto label_26;
                        case 1:
                          disposable.Dispose();
                          num5 = (short) 2;
                          num1 = (int) (IntPtr) num5;
                          continue;
                        case 2:
                          goto label_26;
                        default:
                          goto label_22;
                      }
                    }
label_26:;
                }
              }
label_7:
              this.a(ref this.tvAvailable, A_0.ID);
              num1 = 5;
              continue;
          }
          break;
        case 7:
          this.btnAddSelectedItems.IsEnabled = true;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          num2 = (short) 0;
          if (this.tvAvailable.Items.Count > 0)
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          this.tvAvailable.Items.Add((object) A_0);
          break;
      }
      num2 = (short) 4;
      num1 = (int) (IntPtr) num2;
    }
label_31:
    return;
label_35:;
  }

  private void b(RptTreeViewItem A_0, RptTreeViewItem A_1)
  {
    int num1 = 9;
    while (true)
    {
      short num2;
      int num3;
      RptTreeViewItem itemAt;
      int num4;
      switch (num1)
      {
        case 0:
          if (this.btnRemSelectedItems.IsEnabled)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_39;
        case 1:
          num2 = (short) 0;
          num4 = 0;
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
        case 7:
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
          itemAt.Items.RemoveAt(num3);
          num2 = (short) 11;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
        case 15:
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          if (((HeaderedItemsControl) itemAt.Items.GetItemAt(num3)).Header != A_1.Header)
          {
            ++num3;
            num2 = (short) 15;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          if (!(itemAt.Header.ToString() != A_0.Header.ToString()))
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 8:
          this.btnRemSelectedItems.IsEnabled = false;
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
label_1:
          switch (0)
          {
            case 0:
              goto label_3;
            default:
              continue;
          }
        case 10:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          continue;
        case 11:
          if (itemAt.Items.Count == 0)
          {
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 21;
        case 12:
          num3 = 0;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          if (this.tvSelected.Items.Count == 0)
          {
            num2 = (short) -23024;
            int num5 = (int) num2;
            num2 = (short) -23024;
            int num6 = (int) num2;
            switch (num5 == num6 ? 1 : 0)
            {
              case 0:
              case 2:
                goto label_1;
              default:
                num2 = (short) 0;
                if (num2 == (short) 0)
                  ;
                num2 = (short) 10;
                num1 = (int) (IntPtr) num2;
                continue;
            }
          }
          else
            goto label_37;
        case 14:
          if (num3 >= itemAt.Items.Count)
          {
            num2 = (short) 17;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 16 /*0x10*/:
          this.tvSelected.Items.RemoveAt(num4);
          num2 = (short) 21;
          num1 = (int) (IntPtr) num2;
          continue;
        case 17:
          num2 = (short) 1;
          if (num2 == (short) 0)
            break;
          break;
        case 18:
          if (num4 < this.tvSelected.Items.Count)
          {
            RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
            itemAt = (RptTreeViewItem) this.tvSelected.Items.GetItemAt(num4);
            num2 = (short) 6;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 19;
          num1 = (int) (IntPtr) num2;
          continue;
        case 19:
          goto label_34;
        case 20:
          goto label_35;
        case 21:
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        default:
label_3:
          if (this.tvSelected.Items.Count > 0)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_5;
      }
      ++num4;
      num2 = (short) 7;
      num1 = (int) (IntPtr) num2;
    }
label_34:
    return;
label_35:
    return;
label_5:
    return;
label_39:
    return;
label_37:;
  }

  private void b(RptTreeViewItem A_0, RptTreeViewItem A_1, RptTreeViewItem A_2)
  {
    switch (0)
    {
      default:
        int num1 = 10;
        while (true)
        {
          short num2;
          RptTreeViewItem itemAt1;
          int num3;
          RptTreeViewItem itemAt2;
          int num4;
          int num5;
          switch (num1)
          {
            case 0:
              this.btnRemSelectedItems.IsEnabled = false;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (itemAt2 == A_1)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ++num3;
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (itemAt2.Items.Count == 0)
              {
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 20;
            case 3:
              if (itemAt1.Items.Count == 0)
              {
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 23;
            case 4:
              goto label_46;
            case 5:
              num3 = 0;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
            case 9:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 7:
              if (num5 >= itemAt2.Items.Count)
              {
                num2 = (short) 20;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
              num2 = (short) 16 /*0x10*/;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
            case 15:
              num2 = (short) 26;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 11:
              num5 = 0;
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              num2 = (short) 30;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              itemAt1.Items.RemoveAt(num3);
              num2 = (short) 22;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              if (!(itemAt1.Header.ToString() != A_0.Header.ToString()))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 29;
            case 16 /*0x10*/:
              if (((HeaderedItemsControl) itemAt2.Items.GetItemAt(num5)).Header == A_2.Header)
              {
                num2 = (short) 28;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              ++num5;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 17:
            case 21:
              num2 = (short) 0;
              num2 = (short) 25;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              num4 = 0;
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              this.tvSelected.Items.RemoveAt(num4);
              num2 = (short) 23;
              num1 = (int) (IntPtr) num2;
              continue;
            case 20:
            case 22:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 23:
              num2 = (short) 27;
              num1 = (int) (IntPtr) num2;
              continue;
            case 24:
              goto label_41;
            case 25:
              if (num4 >= this.tvSelected.Items.Count)
              {
                num2 = (short) 24;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 26:
              if (num3 < itemAt1.Items.Count)
              {
                num2 = (short) -13196;
                int num6 = (int) num2;
                num2 = (short) -13196;
                int num7 = (int) num2;
                switch (num6 == num7 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    break;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
                    itemAt2 = (RptTreeViewItem) itemAt1.Items.GetItemAt(num3);
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              }
              else
              {
                num2 = (short) 29;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 27:
              if (this.tvSelected.Items.Count == 0)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_50;
            case 28:
              itemAt2.Items.RemoveAt(num5);
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 29:
              ++num4;
              num2 = (short) 21;
              num1 = (int) (IntPtr) num2;
              continue;
            case 30:
              if (this.btnRemSelectedItems.IsEnabled)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_52;
            default:
label_4:
              if (this.tvSelected.Items.Count > 0)
              {
                num2 = (short) 18;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_42;
          }
          RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
          itemAt1 = (RptTreeViewItem) this.tvSelected.Items.GetItemAt(num4);
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
        }
label_46:
        break;
label_41:
        break;
label_42:
        break;
label_52:
        break;
label_50:
        break;
    }
  }

  private void a(RptTreeViewItem A_0)
  {
    short num1 = 6042;
    int num2 = (int) num1;
    num1 = (short) 6042;
    int num3 = (int) num1;
    short num4;
    int num5;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_6:
        if (this.tvSelected.Items.Count != 0)
          return;
        num4 = (short) 1;
        num5 = (int) (IntPtr) num4;
        break;
      default:
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        switch (0)
        {
          case 0:
            goto label_5;
        }
        break;
    }
    while (true)
    {
      switch (num5)
      {
        case 0:
          goto label_8;
        case 1:
          this.btnRemSelectedItems.IsEnabled = false;
          num4 = (short) 0;
          num5 = (int) (IntPtr) num4;
          continue;
        case 2:
          goto label_6;
        default:
          goto label_5;
      }
label_4:;
    }
label_8:
    return;
label_5:
    this.tvSelected.Items.Remove((object) A_0);
    num4 = (short) 2;
    num5 = (int) (IntPtr) num4;
    goto label_4;
  }

  private void a(RptTreeViewItem A_0, RptTreeViewItem A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator enumerator1;
              RptTreeViewItem A_1_1;
              IDisposable disposable;
              switch (num1)
              {
                case 0:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_86;
                case 1:
                  if (!this.btnAddSelectedItems.IsEnabled)
                  {
                    num2 = (short) 9;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_89;
                case 2:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 0;
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_91;
                case 3:
                  enumerator1 = ((IEnumerable) this.tvAvailable.Items).GetEnumerator();
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
                  this.d(A_0, rptTreeViewItem1);
                  this.tvAvailable.Items.Add((object) rptTreeViewItem1);
                  A_1_1 = new RptTreeViewItem();
                  this.d(A_1, A_1_1);
                  rptTreeViewItem1.Items.Add((object) A_1_1);
                  enumerator1 = ((IEnumerable) A_1.Items).GetEnumerator();
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  if (!flag)
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 6:
label_9:
                  try
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              goto label_12;
                            default:
                              continue;
                          }
                        case 1:
                          goto label_6;
                        case 2:
label_14:
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          RptTreeViewItem current = (RptTreeViewItem) enumerator1.Current;
                          RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
                          this.d(current, rptTreeViewItem2);
                          A_1_1.Items.Add((object) rptTreeViewItem2);
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        default:
label_12:
                          num2 = (short) -15637;
                          int num3 = (int) num2;
                          num2 = (short) -15637;
                          int num4 = (int) num2;
                          switch (num3 == num4 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_9;
                            default:
                              num2 = (short) 0;
                              if (num2 == (short) 0)
                                goto label_14;
                              goto label_14;
                          }
                      }
                    }
                  }
                  finally
                  {
                    short num5;
                    switch (0)
                    {
                      case 0:
label_21:
                        disposable = enumerator1 as IDisposable;
                        num5 = (short) 2;
                        num1 = (int) (IntPtr) num5;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              goto label_25;
                            case 1:
                              disposable.Dispose();
                              num5 = (short) 0;
                              num1 = (int) (IntPtr) num5;
                              continue;
                            case 2:
                              if (disposable != null)
                              {
                                num5 = (short) 1;
                                num1 = (int) (IntPtr) num5;
                                continue;
                              }
                              goto label_25;
                            default:
                              goto label_21;
                          }
                        }
label_25:;
                    }
                  }
                case 7:
                  goto label_84;
                case 8:
                  try
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    IEnumerator enumerator2;
                    while (true)
                    {
                      RptTreeViewItem current;
                      switch (num1)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          this.d(A_1, A_1_1);
                          current.Items.Add((object) A_1_1);
                          flag = true;
                          enumerator2 = ((IEnumerable) A_1.Items).GetEnumerator();
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (!(current.Header.ToString() != A_0.Header.ToString()))
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
                          A_1_1 = new RptTreeViewItem();
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          goto label_86;
                        case 6:
                          if (this.a(current, ref A_1_1, A_1.Header.ToString()))
                          {
                            this.d(A_1, A_1_1);
                            enumerator2 = ((IEnumerable) A_1.Items).GetEnumerator();
                            num2 = (short) 7;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          goto label_55;
                        case 8:
                          if (enumerator1.MoveNext())
                          {
                            current = (RptTreeViewItem) enumerator1.Current;
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          goto label_33;
                      }
                      num2 = (short) 8;
                      num1 = (int) (IntPtr) num2;
                    }
label_33:
                    try
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      while (true)
                      {
                        switch (num1)
                        {
                          case 0:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 1:
                            goto label_86;
                          case 2:
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          case 3:
                            if (enumerator2.MoveNext())
                            {
                              RptTreeViewItem current = (RptTreeViewItem) enumerator2.Current;
                              RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                              this.d(current, rptTreeViewItem3);
                              A_1_1.Items.Add((object) rptTreeViewItem3);
                              num2 = (short) 4;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            }
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            continue;
                        }
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                      }
                    }
                    finally
                    {
                      short num6;
                      switch (0)
                      {
                        case 0:
label_43:
                          disposable = enumerator2 as IDisposable;
                          num6 = (short) 2;
                          num1 = (int) (IntPtr) num6;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                goto label_47;
                              case 1:
                                disposable.Dispose();
                                num6 = (short) 0;
                                num1 = (int) (IntPtr) num6;
                                continue;
                              case 2:
                                if (disposable != null)
                                {
                                  num6 = (short) 1;
                                  num1 = (int) (IntPtr) num6;
                                  continue;
                                }
                                goto label_47;
                              default:
                                goto label_43;
                            }
                          }
label_47:;
                      }
                    }
label_55:
                    try
                    {
                      num2 = (short) 0;
                      num1 = (int) (IntPtr) num2;
                      while (true)
                      {
                        switch (num1)
                        {
                          case 0:
                            switch (0)
                            {
                              case 0:
                                break;
                              default:
                                continue;
                            }
                            break;
                          case 1:
                            goto label_86;
                          case 3:
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          case 4:
                            if (!enumerator2.MoveNext())
                            {
                              num2 = (short) 3;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            }
                            RptTreeViewItem current = (RptTreeViewItem) enumerator2.Current;
                            RptTreeViewItem rptTreeViewItem4 = new RptTreeViewItem();
                            this.d(current, rptTreeViewItem4);
                            A_1_1.Items.Add((object) rptTreeViewItem4);
                            flag = true;
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            continue;
                        }
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                      }
                    }
                    finally
                    {
                      short num7;
                      switch (0)
                      {
                        case 0:
label_65:
                          disposable = enumerator2 as IDisposable;
                          num7 = (short) 2;
                          num1 = (int) (IntPtr) num7;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                goto label_69;
                              case 1:
                                disposable.Dispose();
                                num7 = (short) 0;
                                num1 = (int) (IntPtr) num7;
                                continue;
                              case 2:
                                if (disposable != null)
                                {
                                  num7 = (short) 1;
                                  num1 = (int) (IntPtr) num7;
                                  continue;
                                }
                                goto label_69;
                              default:
                                goto label_65;
                            }
                          }
label_69:;
                      }
                    }
                  }
                  finally
                  {
                    switch (0)
                    {
                      case 0:
label_73:
                        disposable = enumerator1 as IDisposable;
                        num1 = 2;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              goto label_77;
                            case 1:
                              disposable.Dispose();
                              num1 = 0;
                              continue;
                            case 2:
                              if (disposable != null)
                              {
                                num1 = 1;
                                continue;
                              }
                              goto label_77;
                            default:
                              goto label_73;
                          }
                        }
label_77:;
                    }
                  }
                case 9:
                  this.btnAddSelectedItems.IsEnabled = true;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_6:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
label_86:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
            }
label_91:
            return;
label_89:
            return;
label_84:
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            return;
        }
    }
  }

  private bool a(RptTreeViewItem A_0, ref RptTreeViewItem A_1, string A_2)
  {
    short num1 = 0;
    num1 = (short) 0;
    int num2 = (int) num1;
    switch (num2)
    {
      default:
        IEnumerator enumerator = ((IEnumerable) A_0.Items).GetEnumerator();
        bool flag;
        try
        {
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          while (true)
          {
            RptTreeViewItem current;
            switch (num2)
            {
              case 0:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 1:
                goto label_2;
              case 2:
                if (!enumerator.MoveNext())
                {
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                current = (RptTreeViewItem) enumerator.Current;
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                A_1 = current;
                flag = true;
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                goto label_13;
              case 5:
                if (current.Header.ToString() == A_2)
                {
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 6:
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
          }
label_13:
          num1 = (short) 1;
          if (num1 == (short) 0)
            goto label_24;
          goto label_24;
        }
        finally
        {
          short num3 = 7628;
          int num4 = (int) num3;
          num3 = (short) 7628;
          int num5 = (int) num3;
          IDisposable disposable;
          switch (num4 == num5 ? 1 : 0)
          {
            case 0:
            case 2:
label_20:
              if (disposable != null)
              {
                num3 = (short) 1;
                num2 = (int) (IntPtr) num3;
                break;
              }
              goto label_23;
            default:
              num3 = (short) 0;
              if (num3 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  goto label_19;
              }
              break;
          }
          while (true)
          {
            switch (num2)
            {
              case 0:
                goto label_23;
              case 1:
                disposable.Dispose();
                num3 = (short) 0;
                num2 = (int) (IntPtr) num3;
                continue;
              case 2:
                goto label_20;
              default:
                goto label_19;
            }
label_18:;
          }
label_19:
          disposable = enumerator as IDisposable;
          num3 = (short) 2;
          num2 = (int) (IntPtr) num3;
          goto label_18;
label_23:;
        }
label_2:
        return false;
label_24:
        return flag;
    }
  }

  private void a(RptTreeViewItem A_0, RptTreeViewItem A_1, RptTreeViewItem A_2)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            flag = false;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              IEnumerator enumerator1;
              switch (num1)
              {
                case 0:
                  if (!this.btnAddSelectedItems.IsEnabled)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_59;
                case 1:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 10;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 2:
                  goto label_55;
                case 3:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  IDisposable disposable;
                  try
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      RptTreeViewItem current1;
                      IEnumerator enumerator2;
                      switch (num1)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                        case 7:
                          goto label_60;
                        case 2:
                          if (!(current1.Header.ToString() != A_0.Header.ToString()))
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
label_13:
                          enumerator2 = ((IEnumerable) current1.Items).GetEnumerator();
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          num2 = (short) 7;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 4;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current1 = (RptTreeViewItem) enumerator1.Current;
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!flag)
                          {
                            num2 = (short) -29225;
                            int num3 = (int) num2;
                            num2 = (short) -29225;
                            int num4 = (int) num2;
                            switch (num3 == num4 ? 1 : 0)
                            {
                              case 0:
                              case 2:
                                goto label_13;
                              default:
                                num2 = (short) 0;
                                if (num2 == (short) 0)
                                  ;
                                num2 = (short) 8;
                                num1 = (int) (IntPtr) num2;
                                continue;
                            }
                          }
                          else
                            break;
                        case 8:
                          RptTreeViewItem rptTreeViewItem1 = new RptTreeViewItem();
                          this.d(A_1, rptTreeViewItem1);
                          current1.Items.Add((object) rptTreeViewItem1);
                          RptTreeViewItem rptTreeViewItem2 = new RptTreeViewItem();
                          this.d(A_2, rptTreeViewItem2);
                          rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                          flag = true;
                          num2 = (short) 1;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          try
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              RptTreeViewItem current2;
                              switch (num1)
                              {
                                case 0:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = (RptTreeViewItem) enumerator2.Current;
                                    num2 = (short) 6;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 2;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                  RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
                                  this.d(A_2, rptTreeViewItem3);
                                  current2.Items.Add((object) rptTreeViewItem3);
                                  flag = true;
                                  num2 = (short) 5;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 2:
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 4:
                                case 5:
                                  goto label_39;
                                case 6:
                                  if (current2.Header == A_1.Header)
                                  {
                                    num2 = (short) 1;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                              }
                              num2 = (short) 0;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            switch (0)
                            {
                              case 0:
label_31:
                                disposable = enumerator2 as IDisposable;
                                num1 = 2;
                                goto default;
                              default:
                                while (true)
                                {
                                  switch (num1)
                                  {
                                    case 0:
                                      goto label_35;
                                    case 1:
                                      disposable.Dispose();
                                      num1 = 0;
                                      continue;
                                    case 2:
                                      if (disposable != null)
                                      {
                                        num1 = 1;
                                        continue;
                                      }
                                      goto label_35;
                                    default:
                                      goto label_31;
                                  }
                                }
label_35:;
                            }
                          }
label_39:
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num5;
                    switch (0)
                    {
                      case 0:
label_47:
                        disposable = enumerator1 as IDisposable;
                        num5 = (short) 2;
                        num1 = (int) (IntPtr) num5;
                        goto default;
                      default:
                        while (true)
                        {
                          switch (num1)
                          {
                            case 0:
                              goto label_51;
                            case 1:
                              disposable.Dispose();
                              num5 = (short) 0;
                              num1 = (int) (IntPtr) num5;
                              continue;
                            case 2:
                              if (disposable != null)
                              {
                                num5 = (short) 1;
                                num1 = (int) (IntPtr) num5;
                                continue;
                              }
                              goto label_51;
                            default:
                              goto label_47;
                          }
                        }
label_51:;
                    }
                  }
                case 5:
                  num2 = (short) 0;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  this.btnAddSelectedItems.IsEnabled = true;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  RptTreeViewItem rptTreeViewItem4 = new RptTreeViewItem();
                  this.d(A_0, rptTreeViewItem4);
                  this.tvAvailable.Items.Add((object) rptTreeViewItem4);
                  RptTreeViewItem rptTreeViewItem5 = new RptTreeViewItem();
                  this.d(A_1, rptTreeViewItem5);
                  rptTreeViewItem4.Items.Add((object) rptTreeViewItem5);
                  RptTreeViewItem rptTreeViewItem6 = new RptTreeViewItem();
                  this.d(A_2, rptTreeViewItem6);
                  rptTreeViewItem5.Items.Add((object) rptTreeViewItem6);
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 8:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_63;
                case 9:
                  if (!flag)
                  {
                    num2 = (short) 7;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 5;
                case 10:
                  enumerator1 = ((IEnumerable) this.tvAvailable.Items).GetEnumerator();
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
label_60:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
            }
label_55:
            return;
label_63:
            return;
label_59:
            return;
        }
    }
  }

  internal void SortItems(ref TreeView itemsContainer)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        if (false)
          ;
        int num2 = 0;
        IEnumerator enumerator1 = ((IEnumerable) itemsContainer.Items).GetEnumerator();
        IDisposable disposable;
        try
        {
          num1 = 4;
          while (true)
          {
            short num3;
            IEnumerator enumerator2;
            RptTreeViewItem current1;
            int num4;
            switch (num1)
            {
              case 0:
                try
                {
                  num3 = (short) 4;
                  num1 = (int) (IntPtr) num3;
                  while (true)
                  {
                    IEnumerator enumerator3;
                    int num5;
                    RptTreeViewItem current2;
                    switch (num1)
                    {
                      case 1:
                        try
                        {
                          num3 = (short) 3;
                          num1 = (int) (IntPtr) num3;
                          while (true)
                          {
                            switch (num1)
                            {
                              case 1:
                                current2.Items.SortDescriptions.Add(new SortDescription(HeaderedItemsControl.HeaderProperty.ToString(), ListSortDirection.Ascending));
                                num3 = (short) 0;
                                num1 = (int) (IntPtr) num3;
                                continue;
                              case 2:
                                if (enumerator3.MoveNext())
                                {
                                  RptTreeViewItem current3 = (RptTreeViewItem) enumerator3.Current;
                                  ++num5;
                                  num3 = (short) 6;
                                  num1 = (int) (IntPtr) num3;
                                  continue;
                                }
                                num3 = (short) 5;
                                num1 = (int) (IntPtr) num3;
                                continue;
                              case 3:
label_10:
                                switch (0)
                                {
                                  case 0:
                                    break;
                                  default:
                                    continue;
                                }
                                break;
                              case 4:
                                goto label_34;
                              case 5:
                                num3 = (short) -2686;
                                int num6 = (int) num3;
                                num3 = (short) -2686;
                                int num7 = (int) num3;
                                switch (num6 == num7 ? 1 : 0)
                                {
                                  case 0:
                                  case 2:
                                    goto label_10;
                                  default:
                                    num3 = (short) 0;
                                    if (num3 == (short) 0)
                                      ;
                                    num3 = (short) 4;
                                    num1 = (int) (IntPtr) num3;
                                    continue;
                                }
                              case 6:
                                if (num5 == current2.Items.Count)
                                {
                                  num3 = (short) 1;
                                  num1 = (int) (IntPtr) num3;
                                  continue;
                                }
                                break;
                            }
                            num3 = (short) 2;
                            num1 = (int) (IntPtr) num3;
                          }
                        }
                        finally
                        {
                          switch (0)
                          {
                            case 0:
label_24:
                              disposable = enumerator3 as IDisposable;
                              num1 = 2;
                              goto default;
                            default:
                              while (true)
                              {
                                switch (num1)
                                {
                                  case 0:
                                    goto label_28;
                                  case 1:
                                    disposable.Dispose();
                                    num1 = 0;
                                    continue;
                                  case 2:
                                    if (disposable != null)
                                    {
                                      num1 = 1;
                                      continue;
                                    }
                                    goto label_28;
                                  default:
                                    goto label_24;
                                }
                              }
label_28:;
                          }
                        }
label_34:
                        ++num4;
                        num1 = 3;
                        continue;
                      case 2:
                        num3 = (short) 5;
                        num1 = (int) (IntPtr) num3;
                        continue;
                      case 3:
                        if (num4 == current1.Items.Count)
                        {
                          num3 = (short) 6;
                          num1 = (int) (IntPtr) num3;
                          continue;
                        }
                        break;
                      case 4:
                        switch (0)
                        {
                          case 0:
                            break;
                          default:
                            continue;
                        }
                        break;
                      case 5:
                        goto label_50;
                      case 6:
                        current1.Items.SortDescriptions.Add(new SortDescription(HeaderedItemsControl.HeaderProperty.ToString(), ListSortDirection.Ascending));
                        num3 = (short) 0;
                        num1 = (int) (IntPtr) num3;
                        continue;
                      case 7:
                        if (!enumerator2.MoveNext())
                        {
                          num3 = (short) 2;
                          num1 = (int) (IntPtr) num3;
                          continue;
                        }
                        current2 = (RptTreeViewItem) enumerator2.Current;
                        num5 = 0;
                        enumerator3 = ((IEnumerable) current2.Items).GetEnumerator();
                        num3 = (short) 1;
                        num1 = (int) (IntPtr) num3;
                        continue;
                    }
                    num3 = (short) 7;
                    num1 = (int) (IntPtr) num3;
                  }
                }
                finally
                {
                  short num8;
                  switch (0)
                  {
                    case 0:
label_40:
                      disposable = enumerator2 as IDisposable;
                      num8 = (short) 2;
                      num1 = (int) (IntPtr) num8;
                      goto default;
                    default:
                      while (true)
                      {
                        switch (num1)
                        {
                          case 0:
                            goto label_44;
                          case 1:
                            disposable.Dispose();
                            num8 = (short) 0;
                            num1 = (int) (IntPtr) num8;
                            continue;
                          case 2:
                            if (disposable != null)
                            {
                              num8 = (short) 1;
                              num1 = (int) (IntPtr) num8;
                              continue;
                            }
                            goto label_44;
                          default:
                            goto label_40;
                        }
                      }
label_44:;
                  }
                }
label_50:
                ++num2;
                num1 = 3;
                continue;
              case 2:
                num3 = (short) 5;
                num1 = (int) (IntPtr) num3;
                continue;
              case 3:
                if (num2 == itemsContainer.Items.Count)
                {
                  num3 = (short) 6;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                break;
              case 4:
                switch (0)
                {
                  case 0:
                    break;
                  default:
                    continue;
                }
                break;
              case 5:
                goto label_60;
              case 6:
                itemsContainer.Items.SortDescriptions.Add(new SortDescription(HeaderedItemsControl.HeaderProperty.ToString(), ListSortDirection.Ascending));
                itemsContainer.Items.Refresh();
                num3 = (short) 1;
                num1 = (int) (IntPtr) num3;
                continue;
              case 7:
                if (!enumerator1.MoveNext())
                {
                  num3 = (short) 2;
                  num1 = (int) (IntPtr) num3;
                  continue;
                }
                current1 = (RptTreeViewItem) enumerator1.Current;
                num4 = 0;
                enumerator2 = ((IEnumerable) current1.Items).GetEnumerator();
                num3 = (short) 0;
                num1 = (int) (IntPtr) num3;
                continue;
            }
            num3 = (short) 7;
            num1 = (int) (IntPtr) num3;
          }
label_60:
          break;
        }
        finally
        {
          short num9;
          switch (0)
          {
            case 0:
label_56:
              disposable = enumerator1 as IDisposable;
              num9 = (short) 2;
              num1 = (int) (IntPtr) num9;
              goto default;
            default:
              while (true)
              {
                switch (num1)
                {
                  case 0:
                    goto label_61;
                  case 1:
                    disposable.Dispose();
                    num9 = (short) 0;
                    num1 = (int) (IntPtr) num9;
                    continue;
                  case 2:
                    if (disposable != null)
                    {
                      num9 = (short) 1;
                      num1 = (int) (IntPtr) num9;
                      continue;
                    }
                    goto label_61;
                  default:
                    goto label_56;
                }
              }
label_61:;
          }
        }
    }
  }

  internal bool BuildPrintItems()
  {
    int A_1 = 18;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1;
        bool flag2;
        RptTreeViewItem rptTreeViewItem1;
        RptTreeViewItem rptTreeViewItem2;
        IEnumerator<IAcpRecordset> enumerator1;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            this.tvAvailable.Items.Clear();
            flag1 = true;
            flag2 = false;
            rptTreeViewItem1 = new RptTreeViewItem();
            rptTreeViewItem2 = new RptTreeViewItem();
            RptTreeViewItem rptTreeViewItem3 = new RptTreeViewItem();
            enumerator1 = FeatureManager.Features.GetEnumerator();
            num2 = (short) 1;
            if (num2 == (short) 0)
              ;
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  if (this.tvAvailable.Items.Count > 0)
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_200;
                case 1:
                  goto label_200;
                case 2:
                  this.SortItems(ref this.tvAvailable);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  try
                  {
                    num2 = (short) 9;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      IAcpRecordset current1;
                      Dictionary<int, string> dictionary1;
                      Dictionary<int, string> dictionary2;
                      int num4;
                      IAcpFeatureNode iacpFeatureNode;
                      IEnumerator<IAcpFeatureSection> enumerator2;
                      switch (num3)
                      {
                        case 0:
                        case 1:
                          num2 = (short) 18;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          if (rptTreeViewItem1.Items.Count <= 0)
                          {
                            num2 = (short) 4;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 3:
                          if (!current1.HiddenStatic)
                          {
                            num2 = (short) 7;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 4:
                          this.tvAvailable.Items.Remove((object) rptTreeViewItem1);
                          num2 = (short) 16 /*0x10*/;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          enumerator2 = iacpFeatureNode.FeatureSectionsCollection.GetEnumerator();
                          num2 = (short) 10;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 7:
                          rptTreeViewItem1 = new RptTreeViewItem();
                          rptTreeViewItem1.RptRecordName = current1.UIName;
                          rptTreeViewItem1.Header = (object) current1.UIName;
                          rptTreeViewItem1.ID = current1.RecsetId;
                          rptTreeViewItem1.ParentID = 0;
                          rptTreeViewItem1.ItemType = 0;
                          rptTreeViewItem1.RptPath = current1.Path(RptMgrErrorHandler.b("⺔", A_1));
                          this.tvAvailable.Items.Add((object) rptTreeViewItem1);
                          dictionary1 = new Dictionary<int, string>();
                          dictionary2 = new Dictionary<int, string>();
                          num4 = 0;
                          num2 = (short) 0;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          this.tvAvailable.Items.Remove((object) rptTreeViewItem1);
                          num2 = (short) 17;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 9:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 10:
                          try
                          {
                            num2 = (short) 10;
                            int num5 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpFeatureSection current2;
                              IEnumerator<IAcpField> enumerator3;
                              IEnumerator<IAcpFeatureSection> enumerator4;
                              switch (num5)
                              {
                                case 0:
                                  if (rptTreeViewItem1.HasItems)
                                  {
                                    num2 = (short) 16 /*0x10*/;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto default;
                                case 1:
                                  try
                                  {
                                    num2 = (short) 6;
                                    int num6 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpFeatureSection current3;
                                      switch (num6)
                                      {
                                        case 0:
                                          dictionary2.Add(current3.FeatureSectionId, current3.UIName);
                                          flag2 = false;
                                          enumerator3 = current3.FieldsCollection.GetEnumerator();
                                          num2 = (short) 4;
                                          num6 = (int) (IntPtr) num2;
                                          continue;
                                        case 1:
                                          if (!dictionary2.ContainsKey(current3.FeatureSectionId))
                                          {
                                            num2 = (short) 0;
                                            num6 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 2:
                                          if (!enumerator4.MoveNext())
                                          {
                                            num2 = (short) 3;
                                            num6 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          current3 = enumerator4.Current;
                                          num2 = (short) 1;
                                          num6 = (int) (IntPtr) num2;
                                          continue;
                                        case 3:
                                          num2 = (short) 5;
                                          num6 = (int) (IntPtr) num2;
                                          continue;
                                        case 4:
                                          try
                                          {
                                            num2 = (short) 19;
                                            int num7 = (int) (IntPtr) num2;
                                            while (true)
                                            {
                                              IAcpField current4;
                                              switch (num7)
                                              {
                                                case 0:
                                                  num2 = (short) 2;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 1:
                                                  if (rptTreeViewItem2.Items.Count > 0)
                                                  {
                                                    num2 = (short) 15;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 2:
                                                  if (!FieldFilters.FilterSpecialFieldInReport(current4))
                                                  {
                                                    num2 = (short) 13;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  goto case 11;
                                                case 3:
                                                  if (!((AcpFieldBase) current4).HiddenDynamic)
                                                  {
                                                    num2 = (short) 0;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  goto case 11;
                                                case 4:
                                                  if (!(current4.Name == RptMgrErrorHandler.b("횔ﾖ\uF898\uF59A\uF39C爵춠킢\uE4A4쒦\uDDA8슪\uDBAC쪮\uF2B0\uDBB2풴\uD9B6ힸ\uDEBA톼", A_1)))
                                                  {
                                                    num2 = (short) 14;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 5:
                                                  rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                                                  num2 = (short) 17;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 6:
                                                  num2 = (short) 8;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 7:
                                                  num2 = (short) 18;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 8:
                                                  if (!((AcpFieldBase) current4).HiddenStatic)
                                                  {
                                                    num2 = (short) 10;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  goto case 11;
                                                case 9:
                                                  if (enumerator3.MoveNext())
                                                  {
                                                    current4 = enumerator3.Current;
                                                    num2 = (short) 12;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  num2 = (short) 7;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 10:
                                                  num2 = (short) 3;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 11:
                                                  num2 = (short) 1;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 12:
                                                  if (current4 != null)
                                                  {
                                                    num2 = (short) 6;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  goto case 11;
                                                case 13:
                                                  num2 = (short) 4;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 14:
                                                  flag2 = true;
                                                  RptTreeViewItem newItem = new RptTreeViewItem();
                                                  newItem.RptRecordName = current4.UIName;
                                                  newItem.Header = (object) current4.UIName;
                                                  newItem.ParentID = rptTreeViewItem2.ID;
                                                  newItem.ItemType = 2;
                                                  newItem.RptPath = current4.Path(RptMgrErrorHandler.b("⺔", A_1));
                                                  rptTreeViewItem2.Items.Add((object) newItem);
                                                  num2 = (short) 11;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 15:
                                                  num2 = (short) 16 /*0x10*/;
                                                  num7 = (int) (IntPtr) num2;
                                                  continue;
                                                case 16 /*0x10*/:
                                                  if (!rptTreeViewItem1.Items.Contains((object) rptTreeViewItem2))
                                                  {
                                                    num2 = (short) 5;
                                                    num7 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 18:
                                                  goto label_42;
                                                case 19:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                              }
                                              num2 = (short) 9;
                                              num7 = (int) (IntPtr) num2;
                                            }
                                          }
                                          finally
                                          {
                                            int num8 = 2;
                                            while (true)
                                            {
                                              short num9;
                                              switch (num8)
                                              {
                                                case 0:
                                                  enumerator3.Dispose();
                                                  num9 = (short) 1;
                                                  num8 = (int) (IntPtr) num9;
                                                  continue;
                                                case 1:
                                                  goto label_84;
                                                case 2:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                              }
                                              if (enumerator3 != null)
                                              {
                                                num9 = (short) 0;
                                                num8 = (int) (IntPtr) num9;
                                              }
                                              else
                                                break;
                                            }
label_84:;
                                          }
                                        case 5:
                                          goto label_166;
                                        case 6:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                      }
label_42:
                                      num2 = (short) 2;
                                      num6 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    int num10 = 2;
                                    while (true)
                                    {
                                      short num11;
                                      switch (num10)
                                      {
                                        case 0:
                                          enumerator4.Dispose();
                                          num11 = (short) 1;
                                          num10 = (int) (IntPtr) num11;
                                          continue;
                                        case 1:
                                          goto label_92;
                                        case 2:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                      }
                                      if (enumerator4 != null)
                                      {
                                        num11 = (short) 0;
                                        num10 = (int) (IntPtr) num11;
                                      }
                                      else
                                        break;
                                    }
label_92:;
                                  }
                                case 2:
                                  num2 = (short) 0;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  dictionary1.Add(current2.FeatureSectionId, current2.UIName);
                                  flag2 = false;
                                  rptTreeViewItem2 = new RptTreeViewItem();
                                  rptTreeViewItem2.RptRecordName = current2.UIName;
                                  rptTreeViewItem2.Header = (object) current2.UIName;
                                  rptTreeViewItem2.ID = current2.FeatureSectionId;
                                  rptTreeViewItem2.ParentID = rptTreeViewItem1.ID;
                                  rptTreeViewItem2.ItemType = 1;
                                  rptTreeViewItem2.RptPath = current2.Path(RptMgrErrorHandler.b("⺔", A_1)).ToString();
                                  enumerator3 = current2.FieldsCollection.GetEnumerator();
                                  num2 = (short) 6;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 4:
                                  num2 = (short) 7;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 5:
                                  if (!current2.EmbeddedRecset.HiddenStatic)
                                  {
                                    num2 = (short) 14;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 6:
                                  try
                                  {
                                    num2 = (short) 26;
                                    int num12 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpField current5;
                                      IEnumerator enumerator5;
                                      switch (num12)
                                      {
                                        case 0:
                                          if (!current5.IgnoreOnPrint)
                                          {
                                            num2 = (short) 22;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 1:
                                          rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                                          num2 = (short) 23;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 2:
                                          if (rptTreeViewItem2 == null)
                                          {
                                            num2 = (short) 5;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto case 9;
                                        case 3:
                                          num2 = (short) 0;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 4:
                                        case 16 /*0x10*/:
                                          num2 = (short) 7;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 5:
                                          rptTreeViewItem2 = new RptTreeViewItem();
                                          rptTreeViewItem2.RptRecordName = current5.NewParent.UIName;
                                          rptTreeViewItem2.Header = (object) current5.NewParent.UIName;
                                          rptTreeViewItem2.ID = current5.NewParent.FeatureSectionId;
                                          rptTreeViewItem2.ParentID = rptTreeViewItem1.ID;
                                          rptTreeViewItem2.ItemType = 1;
                                          rptTreeViewItem2.RptPath = current5.NewParent.Path(RptMgrErrorHandler.b("⺔", A_1)).ToString();
                                          num2 = (short) 9;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 6:
                                          num2 = (short) 8;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 7:
                                          if (rptTreeViewItem2.Items.Count > 0)
                                          {
                                            num2 = (short) 20;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 8:
                                          if (!((AcpFieldBase) current5).HiddenDynamic)
                                          {
                                            num2 = (short) 10;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 9:
                                          flag2 = true;
                                          RptTreeViewItem newItem1 = new RptTreeViewItem();
                                          newItem1.RptRecordName = current5.NewUIName;
                                          newItem1.Header = (object) current5.NewUIName;
                                          newItem1.ParentID = rptTreeViewItem2.ID;
                                          newItem1.ItemType = 2;
                                          newItem1.RptPath = current5.Path(RptMgrErrorHandler.b("⺔", A_1));
                                          rptTreeViewItem2.Items.Add((object) newItem1);
                                          num2 = (short) 16 /*0x10*/;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 10:
                                          num2 = (short) 21;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 11:
                                          if (!rptTreeViewItem1.Items.Contains((object) rptTreeViewItem2))
                                          {
                                            num2 = (short) 1;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 12:
                                          num2 = (short) 25;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 13:
                                          try
                                          {
                                            num2 = (short) 0;
                                            num12 = (int) (IntPtr) num2;
                                            while (true)
                                            {
                                              RptTreeViewItem current6;
                                              switch (num12)
                                              {
                                                case 0:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                                case 1:
                                                  rptTreeViewItem2 = current6;
                                                  num2 = (short) 3;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                                case 2:
                                                  num2 = (short) 4;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                                case 3:
                                                case 4:
                                                  goto label_106;
                                                case 5:
                                                  if (enumerator5.MoveNext())
                                                  {
                                                    current6 = (RptTreeViewItem) enumerator5.Current;
                                                    num2 = (short) 6;
                                                    num12 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  num2 = (short) 2;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                                case 6:
                                                  if (current6.RptRecordName == current5.NewParent.UIName)
                                                  {
                                                    num2 = (short) 1;
                                                    num12 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                              }
                                              num2 = (short) 5;
                                              num12 = (int) (IntPtr) num2;
                                            }
                                          }
                                          finally
                                          {
                                            IDisposable disposable;
                                            switch (0)
                                            {
                                              case 0:
label_132:
                                                disposable = enumerator5 as IDisposable;
                                                num12 = 0;
                                                goto default;
                                              default:
                                                while (true)
                                                {
                                                  switch (num12)
                                                  {
                                                    case 0:
                                                      if (disposable != null)
                                                      {
                                                        num12 = 2;
                                                        continue;
                                                      }
                                                      goto label_136;
                                                    case 1:
                                                      goto label_136;
                                                    case 2:
                                                      disposable.Dispose();
                                                      num12 = 1;
                                                      continue;
                                                    default:
                                                      goto label_132;
                                                  }
                                                }
label_136:;
                                            }
                                          }
label_106:
                                          num2 = (short) 2;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 14:
                                          if (!enumerator3.MoveNext())
                                          {
                                            num2 = (short) 12;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          current5 = enumerator3.Current;
                                          num2 = (short) 17;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 15:
                                          if (current5.NewUIName != null)
                                          {
                                            num2 = (short) 24;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          flag2 = true;
                                          RptTreeViewItem newItem2 = new RptTreeViewItem();
                                          newItem2.RptRecordName = current5.UIName;
                                          newItem2.Header = (object) current5.UIName;
                                          newItem2.ParentID = rptTreeViewItem2.ID;
                                          newItem2.ItemType = 2;
                                          newItem2.RptPath = current5.Path(RptMgrErrorHandler.b("⺔", A_1));
                                          rptTreeViewItem2.Items.Add((object) newItem2);
                                          num2 = (short) 4;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 17:
                                          if (current5 != null)
                                          {
                                            num2 = (short) 18;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 18:
                                          num2 = (short) 19;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 19:
                                          if (!((AcpFieldBase) current5).HiddenStatic)
                                          {
                                            num2 = (short) 6;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 20:
                                          num2 = (short) 11;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 21:
                                          if (!FieldFilters.FilterSpecialFieldInReport(current5))
                                          {
                                            num2 = (short) 3;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 22:
                                          num2 = (short) 15;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 24:
                                          rptTreeViewItem2 = (RptTreeViewItem) null;
                                          enumerator5 = ((IEnumerable) rptTreeViewItem1.Items).GetEnumerator();
                                          num2 = (short) 13;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 25:
                                          goto label_32;
                                        case 26:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                      }
                                      num2 = (short) 14;
                                      num12 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    int num13 = 0;
                                    while (true)
                                    {
                                      switch (num13)
                                      {
                                        case 0:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 1:
                                          goto label_156;
                                        case 2:
                                          enumerator3.Dispose();
                                          num13 = 1;
                                          continue;
                                      }
                                      if (enumerator3 != null)
                                        num13 = 2;
                                      else
                                        break;
                                    }
label_156:;
                                  }
                                case 7:
                                  goto label_16;
                                case 8:
                                  if (!flag2)
                                  {
                                    num2 = (short) 2;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto default;
                                case 10:
                                  switch (0)
                                  {
                                    case 0:
                                      goto label_170;
                                    default:
                                      continue;
                                  }
                                case 11:
label_32:
                                  num2 = (short) 19;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 12:
                                  if (dictionary1.ContainsKey(current2.FeatureSectionId))
                                  {
                                    flag2 = true;
                                    num2 = (short) 11;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 3;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 13:
                                  num2 = (short) 5;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 14:
                                  enumerator4 = current2.EmbeddedRecset[0].FeatureSectionsCollection.GetEnumerator();
                                  num2 = (short) 1;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 15:
                                  if (current2.EmbeddedRecset.Count > 0)
                                  {
                                    num2 = (short) 13;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 16 /*0x10*/:
                                  rptTreeViewItem1.Items.Remove((object) rptTreeViewItem2);
                                  dictionary1.Remove(current2.FeatureSectionId);
                                  num2 = (short) 9;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 17:
                                  num2 = (short) 15;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 18:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = enumerator2.Current;
                                    num2 = (short) 12;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 4;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                                case 19:
                                  if (current2.HasEmbeddedRecset)
                                  {
                                    num2 = (short) 17;
                                    num5 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                default:
label_170:
                                  num2 = (short) 18;
                                  num5 = (int) (IntPtr) num2;
                                  continue;
                              }
label_166:
                              num2 = (short) 8;
                              num5 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            int num14 = 0;
                            while (true)
                            {
                              short num15;
                              switch (num14)
                              {
                                case 0:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 1:
                                  goto label_180;
                                case 2:
                                  enumerator2.Dispose();
                                  num15 = (short) 1;
                                  num14 = (int) (IntPtr) num15;
                                  continue;
                              }
                              if (enumerator2 != null)
                              {
                                num15 = (short) 2;
                                num14 = (int) (IntPtr) num15;
                              }
                              else
                                break;
                            }
label_180:;
                          }
label_16:
                          num2 = (short) 14;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          num2 = (short) 15;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          if (iacpFeatureNode != null)
                          {
                            num2 = (short) 6;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 17;
                        case 13:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 11;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          current1 = enumerator1.Current;
                          num2 = (short) 3;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          if (rptTreeViewItem1.Items.Count <= 0)
                          {
                            num2 = (short) 8;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 17;
                        case 15:
                          goto label_5;
                        case 17:
                          ++num4;
                          num2 = (short) 1;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 18:
                          if (num4 >= current1.Count)
                          {
                            num2 = (short) 5;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          iacpFeatureNode = current1[num4];
                          num2 = (short) 12;
                          num3 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 13;
                      num3 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
label_190:
                    int num16 = 0;
                    while (true)
                    {
                      switch (num16)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          goto label_196;
                        case 2:
                          enumerator1.Dispose();
                          num16 = 1;
                          continue;
                      }
                      if (enumerator1 != null)
                        num16 = 2;
                      else
                        goto label_198;
                    }
label_196:
                    switch (true ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        goto label_190;
                      default:
                        if (true)
                          break;
                        break;
                    }
label_198:;
                  }
label_5:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_200:
            num2 = (short) 0;
            return flag1;
        }
    }
  }

  private bool a(ref TreeView A_0, int A_1)
  {
    int A_1_1 = 11;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2;
        bool flag1;
        bool flag2;
        IEnumerator<IAcpRecordset> enumerator1;
        switch (0)
        {
          case 0:
label_4:
            flag1 = true;
            flag2 = false;
            enumerator1 = FeatureManager.Features.GetEnumerator();
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              switch (num1)
              {
                case 0:
                  this.SortItems(ref A_0);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (A_0.Items.Count > 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_174;
                case 2:
                  goto label_174;
                case 3:
                  try
                  {
                    num2 = (short) 6;
                    int num3 = (int) (IntPtr) num2;
                    while (true)
                    {
                      RptTreeViewItem rptTreeViewItem1;
                      IAcpRecordset current1;
                      IAcpFeatureNode iacpFeatureNode;
                      IEnumerator<IAcpFeatureSection> enumerator2;
                      switch (num3)
                      {
                        case 0:
                          this.tvAvailable.Items.Remove((object) rptTreeViewItem1);
                          num2 = (short) 9;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          try
                          {
                            num2 = (short) 11;
                            int num4 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpFeatureSection current2;
                              RptTreeViewItem rptTreeViewItem2;
                              IEnumerator<IAcpField> enumerator3;
                              IEnumerator<IAcpFeatureSection> enumerator4;
                              switch (num4)
                              {
                                case 0:
                                  if (current2.EmbeddedRecset.Count > 0)
                                  {
                                    num2 = (short) 14;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 1:
                                  if (current2.HasEmbeddedRecset)
                                  {
                                    num2 = (short) 16 /*0x10*/;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 2:
                                  if (!current2.EmbeddedRecset.HiddenStatic)
                                  {
                                    num2 = (short) 6;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 3:
                                  num2 = (short) 13;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 5:
                                  goto label_14;
                                case 6:
                                  enumerator4 = current2.EmbeddedRecset[0].FeatureSectionsCollection.GetEnumerator();
                                  num2 = (short) 7;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 7:
                                  try
                                  {
                                    num2 = (short) 3;
                                    int num5 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      switch (num5)
                                      {
                                        case 0:
                                          num2 = (short) 1;
                                          num5 = (int) (IntPtr) num2;
                                          continue;
                                        case 1:
                                          goto label_81;
                                        case 2:
                                          if (enumerator4.MoveNext())
                                          {
                                            enumerator3 = enumerator4.Current.FieldsCollection.GetEnumerator();
                                            num2 = (short) 4;
                                            num5 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 0;
                                          num5 = (int) (IntPtr) num2;
                                          continue;
                                        case 3:
                                          switch (0)
                                          {
                                            case 0:
                                              goto label_40;
                                            default:
                                              continue;
                                          }
                                        case 4:
label_42:
                                          try
                                          {
                                            num2 = (short) 7;
                                            int num6 = (int) (IntPtr) num2;
                                            while (true)
                                            {
                                              IAcpField current3;
                                              switch (num6)
                                              {
                                                case 0:
                                                  num2 = (short) 2;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                                case 1:
                                                  num2 = (short) 6;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                                case 2:
                                                  goto label_70;
                                                case 3:
                                                  if (!enumerator3.MoveNext())
                                                  {
                                                    num2 = (short) 0;
                                                    num6 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  current3 = enumerator3.Current;
                                                  num2 = (short) 10;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                                case 4:
                                                  num2 = (short) 11;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                                case 5:
                                                  flag2 = true;
                                                  RptTreeViewItem newItem = new RptTreeViewItem();
                                                  newItem.RptRecordName = current3.UIName;
                                                  newItem.Header = (object) current3.UIName;
                                                  newItem.ParentID = rptTreeViewItem2.ID;
                                                  newItem.ItemType = 2;
                                                  newItem.RptPath = current3.Path(RptMgrErrorHandler.b("㖍", A_1_1));
                                                  rptTreeViewItem2.Items.Add((object) newItem);
                                                  num2 = (short) 9;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                                case 6:
                                                  if (!((AcpFieldBase) current3).HiddenStatic)
                                                  {
                                                    num2 = (short) 4;
                                                    num6 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 7:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                                case 8:
                                                  if (!FieldFilters.FilterSpecialFieldInReport(current3))
                                                  {
                                                    num2 = (short) 5;
                                                    num6 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 10:
                                                  if (current3 != null)
                                                  {
                                                    num2 = (short) 1;
                                                    num6 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 11:
                                                  if (!((AcpFieldBase) current3).HiddenDynamic)
                                                  {
                                                    num2 = (short) 12;
                                                    num6 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 12:
                                                  num2 = (short) 8;
                                                  num6 = (int) (IntPtr) num2;
                                                  continue;
                                              }
                                              num2 = (short) 3;
                                              num6 = (int) (IntPtr) num2;
                                            }
                                          }
                                          finally
                                          {
                                            int num7 = 2;
                                            while (true)
                                            {
                                              switch (num7)
                                              {
                                                case 0:
                                                  enumerator3.Dispose();
                                                  num7 = 1;
                                                  continue;
                                                case 1:
                                                  goto label_68;
                                                case 2:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                              }
                                              if (enumerator3 != null)
                                                num7 = 0;
                                              else
                                                break;
                                            }
label_68:;
                                          }
                                        default:
label_40:
                                          num2 = (short) 5294;
                                          int num8 = (int) num2;
                                          num2 = (short) 5294;
                                          int num9 = (int) num2;
                                          switch (num8 == num9 ? 1 : 0)
                                          {
                                            case 0:
                                            case 2:
                                              goto label_42;
                                            default:
                                              num2 = (short) 0;
                                              if (num2 == (short) 0)
                                                break;
                                              break;
                                          }
                                          break;
                                      }
label_70:
                                      num2 = (short) 2;
                                      num5 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    short num10 = 2;
                                    int num11 = (int) (IntPtr) num10;
                                    while (true)
                                    {
                                      switch (num11)
                                      {
                                        case 0:
                                          enumerator4.Dispose();
                                          num10 = (short) 1;
                                          num11 = (int) (IntPtr) num10;
                                          continue;
                                        case 1:
                                          goto label_80;
                                        case 2:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                      }
                                      if (enumerator4 != null)
                                      {
                                        num10 = (short) 0;
                                        num11 = (int) (IntPtr) num10;
                                      }
                                      else
                                        break;
                                    }
label_80:;
                                  }
                                case 8:
                                  num2 = (short) 5;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 9:
                                  if (!flag2)
                                  {
                                    num2 = (short) 3;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto default;
                                case 10:
                                  if (enumerator2.MoveNext())
                                  {
                                    current2 = enumerator2.Current;
                                    Trace.WriteLine(string.Format(RptMgrErrorHandler.b("融馏ꂑ望\uF295첗\uE899鍊ﮝ\uEE9F춡삣쎥\uDBA7螩銫ﶭ햯톱躳춵袷잹", A_1_1), (object) current2.UIName));
                                    rptTreeViewItem2 = new RptTreeViewItem();
                                    rptTreeViewItem2.RptRecordName = current2.UIName;
                                    rptTreeViewItem2.Header = (object) current2.UIName;
                                    rptTreeViewItem2.ID = current2.FeatureSectionId;
                                    rptTreeViewItem2.ParentID = rptTreeViewItem1.ID;
                                    rptTreeViewItem2.ItemType = 1;
                                    rptTreeViewItem2.RptPath = current2.Path(RptMgrErrorHandler.b("㖍", A_1_1));
                                    flag2 = false;
                                    enumerator3 = current2.FieldsCollection.GetEnumerator();
                                    num2 = (short) 15;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 8;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 11:
                                  switch (0)
                                  {
                                    case 0:
                                      goto label_30;
                                    default:
                                      continue;
                                  }
                                case 12:
                                  rptTreeViewItem1.Items.Remove((object) rptTreeViewItem2);
                                  num2 = (short) 4;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 13:
                                  if (rptTreeViewItem1.HasItems)
                                  {
                                    num2 = (short) 12;
                                    num4 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto default;
                                case 14:
                                  num2 = (short) 2;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 15:
                                  try
                                  {
                                    num2 = (short) 23;
                                    int num12 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpField current4;
                                      IEnumerator enumerator5;
                                      switch (num12)
                                      {
                                        case 0:
                                          rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                                          num2 = (short) 24;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 1:
                                          if (!((AcpFieldBase) current4).HiddenDynamic)
                                          {
                                            num2 = (short) 21;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 2:
                                          if (current4.NewUIName != null)
                                          {
                                            num2 = (short) 17;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          flag2 = true;
                                          RptTreeViewItem newItem1 = new RptTreeViewItem();
                                          newItem1.RptRecordName = current4.UIName;
                                          newItem1.Header = (object) current4.UIName;
                                          newItem1.ParentID = rptTreeViewItem2.ID;
                                          newItem1.ItemType = 2;
                                          newItem1.RptPath = current4.Path(RptMgrErrorHandler.b("㖍", A_1_1));
                                          rptTreeViewItem2.Items.Add((object) newItem1);
                                          num2 = (short) 10;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 3:
                                          if (!((AcpFieldBase) current4).HiddenStatic)
                                          {
                                            num2 = (short) 8;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 4:
                                          if (!current4.IgnoreOnPrint)
                                          {
                                            num2 = (short) 14;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 5:
                                          num2 = (short) 3;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 6:
                                          if (rptTreeViewItem2 == null)
                                          {
                                            num2 = (short) 22;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto case 11;
                                        case 7:
                                          if (rptTreeViewItem2.Items.Count > 0)
                                          {
                                            num2 = (short) 16 /*0x10*/;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 8:
                                          num2 = (short) 1;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 9:
                                          num2 = (short) 4;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 10:
                                        case 15:
                                          num2 = (short) 7;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 11:
                                          flag2 = true;
                                          RptTreeViewItem newItem2 = new RptTreeViewItem();
                                          newItem2.RptRecordName = current4.NewUIName;
                                          newItem2.Header = (object) current4.NewUIName;
                                          newItem2.ParentID = rptTreeViewItem2.ID;
                                          newItem2.ItemType = 2;
                                          newItem2.RptPath = current4.Path(RptMgrErrorHandler.b("㖍", A_1_1));
                                          rptTreeViewItem2.Items.Add((object) newItem2);
                                          num2 = (short) 15;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 12:
                                          if (!rptTreeViewItem1.Items.Contains((object) rptTreeViewItem2))
                                          {
                                            num2 = (short) 0;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 13:
                                          if (!FieldFilters.FilterSpecialFieldInReport(current4))
                                          {
                                            num2 = (short) 9;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 14:
                                          num2 = (short) 2;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 16 /*0x10*/:
                                          num2 = (short) 12;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 17:
                                          rptTreeViewItem2 = (RptTreeViewItem) null;
                                          enumerator5 = ((IEnumerable) rptTreeViewItem1.Items).GetEnumerator();
                                          num2 = (short) 26;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 18:
                                          if (enumerator3.MoveNext())
                                          {
                                            current4 = enumerator3.Current;
                                            num2 = (short) 19;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 25;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 19:
                                          if (current4 != null)
                                          {
                                            num2 = (short) 5;
                                            num12 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 20:
                                          goto label_24;
                                        case 21:
                                          num2 = (short) 13;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 22:
                                          rptTreeViewItem2 = new RptTreeViewItem();
                                          rptTreeViewItem2.RptRecordName = current4.NewParent.UIName;
                                          rptTreeViewItem2.Header = (object) current4.NewParent.UIName;
                                          rptTreeViewItem2.ID = current4.NewParent.FeatureSectionId;
                                          rptTreeViewItem2.ParentID = rptTreeViewItem1.ID;
                                          rptTreeViewItem2.ItemType = 1;
                                          rptTreeViewItem2.RptPath = current4.NewParent.Path(RptMgrErrorHandler.b("㖍", A_1_1)).ToString();
                                          num2 = (short) 11;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 23:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 25:
                                          num2 = (short) 20;
                                          num12 = (int) (IntPtr) num2;
                                          continue;
                                        case 26:
                                          try
                                          {
                                            num2 = (short) 4;
                                            num12 = (int) (IntPtr) num2;
                                            while (true)
                                            {
                                              RptTreeViewItem current5;
                                              switch (num12)
                                              {
                                                case 0:
                                                  if (current5.RptRecordName == current4.NewParent.UIName)
                                                  {
                                                    num2 = (short) 2;
                                                    num12 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 1:
                                                  if (enumerator5.MoveNext())
                                                  {
                                                    current5 = (RptTreeViewItem) enumerator5.Current;
                                                    num2 = (short) 0;
                                                    num12 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  num2 = (short) 6;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                                case 2:
                                                  rptTreeViewItem2 = current5;
                                                  num2 = (short) 3;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                                case 4:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                                case 5:
                                                  goto label_140;
                                                case 6:
                                                  num2 = (short) 5;
                                                  num12 = (int) (IntPtr) num2;
                                                  continue;
                                              }
                                              num2 = (short) 1;
                                              num12 = (int) (IntPtr) num2;
                                            }
                                          }
                                          finally
                                          {
                                            IDisposable disposable;
                                            switch (0)
                                            {
                                              case 0:
label_135:
                                                disposable = enumerator5 as IDisposable;
                                                num12 = 0;
                                                goto default;
                                              default:
                                                while (true)
                                                {
                                                  switch (num12)
                                                  {
                                                    case 0:
                                                      if (disposable != null)
                                                      {
                                                        num12 = 2;
                                                        continue;
                                                      }
                                                      goto label_139;
                                                    case 1:
                                                      goto label_139;
                                                    case 2:
                                                      disposable.Dispose();
                                                      num12 = 1;
                                                      continue;
                                                    default:
                                                      goto label_135;
                                                  }
                                                }
label_139:;
                                            }
                                          }
label_140:
                                          num12 = 6;
                                          continue;
                                      }
                                      num2 = (short) 18;
                                      num12 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    short num13 = 0;
                                    int num14 = (int) (IntPtr) num13;
                                    while (true)
                                    {
                                      switch (num14)
                                      {
                                        case 0:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 1:
                                          goto label_150;
                                        case 2:
                                          enumerator3.Dispose();
                                          num13 = (short) 1;
                                          num14 = (int) (IntPtr) num13;
                                          continue;
                                      }
                                      if (enumerator3 != null)
                                      {
                                        num13 = (short) 2;
                                        num14 = (int) (IntPtr) num13;
                                      }
                                      else
                                        break;
                                    }
label_150:;
                                  }
label_24:
                                  num2 = (short) 1;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                case 16 /*0x10*/:
                                  num2 = (short) 0;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                                default:
label_30:
                                  num2 = (short) 10;
                                  num4 = (int) (IntPtr) num2;
                                  continue;
                              }
label_81:
                              num2 = (short) 9;
                              num4 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num15 = 0;
                            int num16 = (int) (IntPtr) num15;
                            while (true)
                            {
                              switch (num16)
                              {
                                case 0:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 1:
                                  goto label_159;
                                case 2:
                                  enumerator2.Dispose();
                                  num15 = (short) 1;
                                  num16 = (int) (IntPtr) num15;
                                  continue;
                              }
                              if (enumerator2 != null)
                              {
                                num15 = (short) 2;
                                num16 = (int) (IntPtr) num15;
                              }
                              else
                                break;
                            }
label_159:;
                          }
label_14:
                          num2 = (short) 5;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          goto label_5;
                        case 3:
                          if (current1.RecsetId == A_1)
                          {
                            num2 = (short) 7;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 4:
                          num2 = (short) 2;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (rptTreeViewItem1.Items.Count <= 0)
                          {
                            num2 = (short) 0;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 6:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 7:
                          rptTreeViewItem1 = new RptTreeViewItem();
                          rptTreeViewItem1.RptRecordName = current1.UIName;
                          rptTreeViewItem1.Header = (object) current1.UIName;
                          rptTreeViewItem1.ID = current1.RecsetId;
                          rptTreeViewItem1.ParentID = 0;
                          rptTreeViewItem1.ItemType = 0;
                          rptTreeViewItem1.RptPath = current1.Path(RptMgrErrorHandler.b("㖍", A_1_1));
                          iacpFeatureNode = current1[0];
                          num2 = (short) 10;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (!enumerator1.MoveNext())
                          {
                            num2 = (short) 4;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          current1 = enumerator1.Current;
                          num2 = (short) 3;
                          num3 = (int) (IntPtr) num2;
                          continue;
                        case 10:
                          if (iacpFeatureNode != null)
                          {
                            num2 = (short) 11;
                            num3 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 11:
                          A_0.Items.Add((object) rptTreeViewItem1);
                          enumerator2 = iacpFeatureNode.FeatureSectionsCollection.GetEnumerator();
                          num2 = (short) 1;
                          num3 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 8;
                      num3 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    short num17 = 0;
                    int num18 = (int) (IntPtr) num17;
                    while (true)
                    {
                      switch (num18)
                      {
                        case 0:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 1:
                          goto label_172;
                        case 2:
                          enumerator1.Dispose();
                          num17 = (short) 1;
                          num18 = (int) (IntPtr) num17;
                          continue;
                      }
                      if (enumerator1 != null)
                      {
                        num17 = (short) 2;
                        num18 = (int) (IntPtr) num17;
                      }
                      else
                        break;
                    }
label_172:;
                  }
label_5:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_4;
              }
            }
label_174:
            num2 = (short) 0;
            return flag1;
        }
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 17;
    while (this.a)
    {
      short num1 = -868;
      int num2 = (int) num1;
      num1 = (short) -868;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          continue;
        default:
          num1 = (short) 0;
          if (num1 == (short) 0)
            ;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          return;
      }
    }
    this.a = true;
    Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("뮓얕\uE897ﾙﾛ\uF79D솟캡\uE2A3쎥즧\uDEA9\uD9AB\uDCAD햯솱辳햵ힷힹ첻톽꺿\uA7C1\uAAC3닅\uE7C7ꯉ꿋뻍ꋏ럑ꓓ맕\uAAD7껙뇛뿝軟菡菣菥髧蛩藫賭\uDFEF英闳釵鷷觹駻鋽旿愁瀃瘅稇按戋稍礏昑焓笕欗㐙搛缝䴟両", A_1), UriKind.Relative));
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 0;
    short num2;
    while (true)
    {
      num2 = (short) -8731;
      int num3 = (int) num2;
      num2 = (short) -8731;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_16;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 1:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_21;
          }
          switch (connectionId)
          {
            case 1:
              goto label_12;
            case 2:
              goto label_10;
            case 3:
              goto label_16;
            case 4:
              goto label_19;
            case 5:
              goto label_22;
            case 6:
              goto label_15;
            case 7:
              goto label_23;
            case 8:
              goto label_9;
            case 9:
              goto label_13;
            case 10:
              goto label_8;
            case 11:
              goto label_18;
            case 12:
              goto label_11;
            case 13:
              goto label_17;
            case 14:
              goto label_14;
            default:
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              continue;
          }
      }
    }
label_8:
    this.btnSave = (Button) target;
    this.btnSave.Click += new RoutedEventHandler(this.OnSave);
    return;
label_9:
    this.btnAddSelectedItems = (Button) target;
    this.btnAddSelectedItems.Click += new RoutedEventHandler(this.OnClickAdd);
    return;
label_10:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.buttonHelp_Click);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_11:
    this.btnCancel = (Button) target;
    this.btnCancel.Click += new RoutedEventHandler(this.OnSelItemsCancel);
    return;
label_12:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.InitializeData);
    return;
label_13:
    this.btnRemSelectedItems = (Button) target;
    this.btnRemSelectedItems.Click += new RoutedEventHandler(this.OnClickRmv);
    return;
label_14:
    this.imgMotologo = (Image) target;
    return;
label_15:
    this.tvAvailable = (TreeView) target;
    return;
label_16:
    this.gReportsSelectPrintItems = (Grid) target;
    return;
label_17:
    this.btnHelp = (Button) target;
    this.btnHelp.Click += new RoutedEventHandler(this.buttonHelp_Click);
    return;
label_18:
    this.btnSaveAs = (Button) target;
    this.btnSaveAs.Click += new RoutedEventHandler(this.OnSaveAs);
    return;
label_19:
    this.lblAvailablePrint = (Label) target;
    return;
label_21:
    num2 = (short) 0;
    this.a = true;
    return;
label_22:
    this.lblSelectPrint = (Label) target;
    return;
label_23:
    this.tvSelected = (TreeView) target;
  }

  private enum serializeAction
  {
    saveAs,
    save,
  }
}
