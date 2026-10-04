// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.AcpReportManagerLib.PageCustomPrintSelection
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpBusinessLayer;
using AcpCommonLib;
using AcpUI;
using AcpUI.Common;
using CommonResources;
using Motorola.Common.Communication.CommonUtil;
using Motorola.CommonCPS.Server.EntityModel;
using Motorola.MackinawCPS.CoreFeatures.RadioProfiles;
using SpecialFeatures.AcpXMLCoreEngineLib;
using SpecialFeatures.Utilites;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Xml;

#nullable disable
namespace SpecialFeatures.AcpReportManagerLib;

public partial class PageCustomPrintSelection : PageFunction<string>, IComponentConnector
{
  private ArrayList a = new ArrayList();
  private Window b;
  internal Grid gReportsChoices;
  internal System.Windows.Controls.ListView lstUIValue;
  internal System.Windows.Controls.Button btnPrtHelp;
  internal System.Windows.Controls.Button btnPrtPreview;
  internal System.Windows.Controls.Button btnPrtSelectAll;
  internal System.Windows.Controls.Button btnPrtUnSelectAll;
  internal System.Windows.Controls.Button btnPrtCreateTpl;
  internal System.Windows.Controls.Button btnPrtEditTpl;
  internal System.Windows.Controls.Button btnPrtDelTpl;
  internal System.Windows.Controls.Button btnCancel;
  internal Image imgMotologo;
  internal System.Windows.Controls.Label lblSelectionTitle;
  internal System.Windows.Controls.RadioButton radBtnFeatures;
  internal System.Windows.Controls.RadioButton radBtnTemplates;
  private bool c;

  internal PageCustomPrintSelection()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  public override void OnApplyTemplate()
  {
    int A_1 = 17;
    int num1;
    Style resource;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        base.OnApplyTemplate();
        resource = (Style) this.TryFindResource((object) RptMgrErrorHandler.b("\uD893ﾕ\uEB97\uEE99쪛\uF79D얟햡\uEDA3튥춧잩\uEFAB솭\uDEAF욱톳\uD8B5첷\uE9B9좻잽겿\uA7C1", A_1));
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_3:
              if (resource != null)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              goto label_8;
            case 2:
              num2 = (short) 10164;
              int num3 = (int) num2;
              num2 = (short) 10164;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  this.lstUIValue.ItemContainerStyle = new Style(typeof (System.Windows.Controls.ListViewItem), resource);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_8:
        break;
label_10:
        break;
    }
  }

  public void InitializeData(object sender, EventArgs e)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        num2 = (short) 1;
        if (num2 == (short) 0)
          ;
        this.a();
        this.btnPrtUnSelectAll.IsEnabled = false;
        this.radBtnFeatures.IsChecked = new bool?(true);
        this.a.Clear();
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_4:
              if (!this.IsKeyboardFocusWithin)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              goto label_8;
            case 2:
              num2 = (short) 16996;
              int num3 = (int) num2;
              num2 = (short) 16996;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_4;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  Keyboard.Focus((IInputElement) this);
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_8:
        break;
label_10:
        break;
    }
  }

  private void a()
  {
    int A_1 = 12;
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
            length = str2.IndexOf(RptMgrErrorHandler.b("\uED8E\uF890ﶒ즔", A_1));
            break;
          default:
            while (true)
            {
              switch (num1)
              {
                case 0:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (length > 0)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 2:
                  bitmapImage.BeginInit();
                  bitmapImage.UriSource = new Uri(str1);
                  bitmapImage.EndInit();
                  this.imgMotologo.Source = (ImageSource) bitmapImage;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 3:
                  if (File.Exists(str1))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_21;
                case 4:
                  goto label_19;
                case 5:
                  num2 = (short) 0;
                  str2 = str2.Substring(0, length);
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  str1 = str2 + RptMgrErrorHandler.b("ﶎ\uF490\uE392杖\uE596\uED98\uE89A솜\uF69E철슢스슦\uF5A8쎪좬캮햰횲잴\uE8B6쾸\uDEBA쾼쮾꓀믂\uEBC4跆駈賊", A_1);
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  num2 = (short) -13837;
                  int num3 = (int) num2;
                  num2 = (short) -13837;
                  int num4 = (int) num2;
                  switch (num3 == num4 ? 1 : 0)
                  {
                    case 0:
                    case 2:
                      goto label_4;
                    default:
                      num2 = (short) 0;
                      if (num2 == (short) 0)
                        break;
                      break;
                  }
                  break;
                case 8:
                  if (VersionInfoHelper.IsDFlagExisted((DFlagType) 1))
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  str1 = str2 + RptMgrErrorHandler.b("ﶎ\uF490\uE392杖\uE596\uED98\uE89A솜\uF69E철슢스슦\uF5A8쎪좬캮햰횲잴馶\uF3B8\uEBBA謁", A_1);
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    goto case 0;
                  goto case 0;
                default:
                  goto label_3;
              }
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
label_2:;
            }
label_19:
            return;
label_21:
            return;
        }
label_4:
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  internal void OnPrtSelectAll(object sender, RoutedEventArgs e)
  {
    short num1 = 0;
    num1 = (short) 18621;
    int num2 = (int) num1;
    num1 = (short) 18621;
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
        this.lstUIValue.UnselectAll();
        this.lstUIValue.SelectionMode = System.Windows.Controls.SelectionMode.Multiple;
        this.lstUIValue.SelectAll();
        this.btnPrtSelectAll.IsEnabled = true;
        this.btnPrtPreview.IsEnabled = true;
        this.lstUIValue.Focus();
        break;
      default:
        goto case 1;
    }
  }

  internal void OnPrtUnSelectAll(object sender, RoutedEventArgs e)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          num2 = (short) -25538;
          int num3 = (int) num2;
          num2 = (short) -25538;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_8;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              this.lstUIValue.SelectionMode = System.Windows.Controls.SelectionMode.Multiple;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        case 1:
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
        case 2:
          if (this.lstUIValue.SelectedItems.Count == 0)
          {
            num2 = (short) 4;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
        case 3:
label_8:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 0;
          this.btnPrtPreview.IsEnabled = false;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          goto label_13;
        default:
label_4:
          if (this.lstUIValue.SelectedItems.Count == this.lstUIValue.Items.Count)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 3;
      }
    }
label_13:
    this.lstUIValue.UnselectAll();
  }

  internal void OnPrtSelCancel(object sender, RoutedEventArgs e)
  {
    short num1 = 0;
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 30699;
    int num2 = (int) num1;
    num1 = (short) 30699;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        ((Window) this.Parent).Close();
        break;
      default:
        goto case 1;
    }
  }

  internal void OnPrtPreview(object sender, RoutedEventArgs e)
  {
    int A_1 = 8;
    int num1;
    bool? isChecked;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        isChecked = this.radBtnTemplates.IsChecked;
        flag = true;
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              if (this.lstUIValue.SelectedItems.Count > 0)
              {
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_20;
            case 2:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (!this.BuildTemplateFileXMLData(this.lstUIValue.SelectedItem.ToString()))
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 4:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) -26760;
                int num3 = (int) num2;
                num2 = (short) -26760;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                    goto label_29;
                  case 2:
                    goto label_24;
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
              {
                Trace.WriteLine(string.Format(RptMgrErrorHandler.b("좊\uE28C搜ﾐ\uE792꾔랖\uE298ꮚ\uE09C", A_1), (object) this.lstUIValue.SelectedItems.Count));
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              }
            case 5:
              goto label_8;
            case 6:
              goto label_28;
            case 7:
              if (!this.BuildFeatureXMLData())
              {
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 8:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              if (this.lstUIValue.SelectedItems.Count > 0)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 10:
              if (this.lstUIValue.SelectedItems.Count > 0)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 11:
              this.BuildPrintChoicesReport();
              num2 = (short) 0;
              num2 = (short) 12;
              num1 = (int) (IntPtr) num2;
              continue;
            case 12:
              goto label_16;
            default:
              goto label_2;
          }
          num2 = (short) 1;
          num1 = (int) (IntPtr) num2;
        }
label_8:
        break;
label_28:
        break;
label_16:
        break;
label_29:
        break;
label_24:
        break;
label_20:
        break;
    }
  }

  private void OnTemplateSelected(object A_0, RoutedEventArgs A_1)
  {
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.a.Clear();
        this.a.AddRange((ICollection) this.lstUIValue.SelectedItems);
        this.lstUIValue.Items.Clear();
        string A_1_1 = "";
        this.a(PageCustomPrintSelection.fileAction.display, ref A_1_1);
        this.lstUIValue.SelectionMode = System.Windows.Controls.SelectionMode.Single;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_3:
              if (this.lstUIValue.Items.Count == 0)
              {
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_9;
            case 1:
              goto label_9;
            case 2:
              num2 = (short) -22995;
              int num3 = (int) num2;
              num2 = (short) -22995;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_3;
                default:
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  this.btnPrtEditTpl.IsEnabled = false;
                  this.btnPrtDelTpl.IsEnabled = false;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            default:
              goto label_2;
          }
        }
label_9:
        this.btnPrtSelectAll.IsEnabled = false;
        this.btnPrtUnSelectAll.IsEnabled = false;
        this.btnPrtPreview.IsEnabled = false;
        this.btnPrtCreateTpl.IsEnabled = true;
        break;
    }
  }

  private void OnFeatureSelected(object A_0, RoutedEventArgs A_1)
  {
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 0;
        switch (0)
        {
          case 0:
label_3:
            this.lstUIValue.Items.Clear();
            this.BuildCustomPrintSelection();
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            IEnumerator enumerator1;
            System.Windows.Controls.ListViewItem listViewItem;
            while (true)
            {
              switch (num1)
              {
                case 0:
                  this.btnPrtSelectAll.IsEnabled = true;
                  this.btnPrtUnSelectAll.IsEnabled = true;
                  this.btnPrtCreateTpl.IsEnabled = false;
                  this.btnPrtEditTpl.IsEnabled = false;
                  this.btnPrtDelTpl.IsEnabled = false;
                  this.btnPrtPreview.IsEnabled = false;
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                  if (this.a.Count > 0)
                  {
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_48;
                case 2:
                  if (this.lstUIValue.Items.Count > 0)
                  {
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 3;
                case 3:
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  goto label_6;
                case 5:
                  listViewItem = (System.Windows.Controls.ListViewItem) null;
                  enumerator1 = this.a.GetEnumerator();
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
            }
label_6:
            IDisposable disposable;
            try
            {
              num2 = (short) 1;
              num1 = (int) (IntPtr) num2;
              while (true)
              {
                IEnumerator enumerator2;
                System.Windows.Controls.ListViewItem current;
                switch (num1)
                {
                  case 0:
                    if (!enumerator1.MoveNext())
                    {
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    current = (System.Windows.Controls.ListViewItem) enumerator1.Current;
                    enumerator2 = ((IEnumerable) this.lstUIValue.Items).GetEnumerator();
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 1:
                    switch (0)
                    {
                      case 0:
                        break;
                      default:
                        continue;
                    }
                    break;
                  case 2:
                    try
                    {
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      while (true)
                      {
                        switch (num1)
                        {
                          case 0:
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          case 1:
                            goto label_9;
                          case 2:
                            if (!enumerator2.MoveNext())
                            {
                              num2 = (short) 0;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            }
                            listViewItem = (System.Windows.Controls.ListViewItem) enumerator2.Current;
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
                            if (current.Content.Equals(listViewItem.Content))
                            {
                              num2 = (short) 6;
                              num1 = (int) (IntPtr) num2;
                              continue;
                            }
                            break;
                          case 6:
                            ((ListBoxItem) this.lstUIValue.Items[this.lstUIValue.Items.IndexOf((object) listViewItem)]).IsSelected = true;
                            num2 = (short) 5;
                            num1 = (int) (IntPtr) num2;
                            continue;
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
label_27:
                          disposable = enumerator2 as IDisposable;
                          num3 = (short) 0;
                          num1 = (int) (IntPtr) num3;
                          goto default;
                        default:
                          while (true)
                          {
                            switch (num1)
                            {
                              case 0:
                                if (disposable != null)
                                {
                                  num3 = (short) 1;
                                  num1 = (int) (IntPtr) num3;
                                  continue;
                                }
                                goto label_31;
                              case 1:
                                disposable.Dispose();
                                num3 = (short) 2;
                                num1 = (int) (IntPtr) num3;
                                continue;
                              case 2:
                                goto label_31;
                              default:
                                goto label_27;
                            }
                          }
label_31:;
                      }
                    }
                  case 3:
                    num2 = (short) 8376;
                    int num4 = (int) num2;
                    num2 = (short) 8376;
                    int num5 = (int) num2;
                    switch (num4 == num5 ? 1 : 0)
                    {
                      case 0:
                      case 2:
                        break;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                        continue;
                    }
                    break;
                  case 4:
                    goto label_43;
                }
label_9:
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
              }
label_43:
              return;
            }
            finally
            {
              short num6;
              switch (0)
              {
                case 0:
label_36:
                  disposable = enumerator1 as IDisposable;
                  num6 = (short) 0;
                  num1 = (int) (IntPtr) num6;
                  goto default;
                default:
                  while (true)
                  {
                    switch (num1)
                    {
                      case 0:
                        if (disposable != null)
                        {
                          num6 = (short) 1;
                          num1 = (int) (IntPtr) num6;
                          continue;
                        }
                        goto label_40;
                      case 1:
                        disposable.Dispose();
                        num6 = (short) 2;
                        num1 = (int) (IntPtr) num6;
                        continue;
                      case 2:
                        goto label_40;
                      default:
                        goto label_36;
                    }
                  }
label_40:;
              }
            }
label_48:
            return;
        }
    }
  }

  private bool a(PageCustomPrintSelection.fileAction A_0, ref string A_1)
  {
    int A_1_1 = 6;
    short num1 = 29135;
    int num2 = (int) num1;
    num1 = (short) 29135;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_4:
        bool flag = false;
        string usrPrntTemplateDir = Global.usrPrntTemplateDir;
        try
        {
          num4 = (short) 28;
          int num5 = (int) (IntPtr) num4;
          int index1;
          string[] files;
          string[] strArray;
          int index2;
          int index3;
          string str1;
          int num6;
          string insertItem;
          while (true)
          {
            switch (num5)
            {
              case 0:
              case 10:
                num4 = (short) 7;
                num5 = (int) (IntPtr) num4;
                continue;
              case 1:
              case 8:
                num4 = (short) 15;
                num5 = (int) (IntPtr) num4;
                continue;
              case 2:
                flag = true;
                num4 = (short) 33;
                num5 = (int) (IntPtr) num4;
                continue;
              case 3:
              case 26:
                num4 = (short) 34;
                num5 = (int) (IntPtr) num4;
                continue;
              case 4:
                if (files.Length != 0)
                {
                  num4 = (short) 32 /*0x20*/;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 11;
              case 5:
                if (index1 < Global.usrLastSavedContainer.Count)
                {
                  num4 = (short) 36;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 25;
              case 6:
                flag = true;
                num4 = (short) 22;
                num5 = (int) (IntPtr) num4;
                continue;
              case 7:
                if (index2 >= strArray.Length)
                {
                  num4 = (short) 11;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                this.lstUIValue.Items.Add((object) strArray[index2].Remove(0, usrPrntTemplateDir.Length + 1));
                str1 = "";
                ++index2;
                num4 = (short) 10;
                num5 = (int) (IntPtr) num4;
                continue;
              case 9:
                if (index1 >= Global.usrLastSavedContainer.Count)
                {
                  A_1 = usrPrntTemplateDir + RptMgrErrorHandler.b("했", A_1_1) + A_1;
                  num4 = (short) 18;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 21;
                num5 = (int) (IntPtr) num4;
                continue;
              case 11:
                num4 = (short) 27;
                num5 = (int) (IntPtr) num4;
                continue;
              case 12:
                flag = false;
                num4 = (short) 29;
                num5 = (int) (IntPtr) num4;
                continue;
              case 13:
                if (!File.Exists(A_1.ToString()))
                {
                  int num7 = (int) System.Windows.MessageBox.Show(AppResources.File_not_found + A_1.ToString());
                  num4 = (short) 5;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 2;
                num5 = (int) (IntPtr) num4;
                continue;
              case 14:
              case 17:
                num4 = (short) 13;
                num5 = (int) (IntPtr) num4;
                continue;
              case 15:
                if (this.lstUIValue.Items.Contains((object) insertItem))
                {
                  ++num6;
                  insertItem = str1 + RptMgrErrorHandler.b("ꦈ킊", A_1_1) + num6.ToString() + RptMgrErrorHandler.b("품", A_1_1);
                  num4 = (short) 1;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 23;
                num5 = (int) (IntPtr) num4;
                continue;
              case 16 /*0x10*/:
                try
                {
                  switch (0)
                  {
                    case 0:
label_20:
                      File.Delete(A_1);
                      num4 = (short) 0;
                      num5 = (int) (IntPtr) num4;
                      goto default;
                    default:
                      while (true)
                      {
                        switch (num5)
                        {
                          case 0:
                            if (index1 < Global.usrLastSavedContainer.Count)
                            {
                              num4 = (short) 2;
                              num5 = (int) (IntPtr) num4;
                              continue;
                            }
                            goto case 1;
                          case 1:
                            flag = true;
                            num4 = (short) 3;
                            num5 = (int) (IntPtr) num4;
                            continue;
                          case 2:
                            Global.usrLastSavedContainer.Remove(A_1);
                            num4 = (short) 1;
                            num5 = (int) (IntPtr) num4;
                            continue;
                          case 3:
                            goto label_65;
                          default:
                            goto label_20;
                        }
                      }
                  }
                }
                catch (Exception ex)
                {
                  int num8 = (int) System.Windows.MessageBox.Show(ex.Message);
                  flag = false;
                  goto case 22;
                }
              case 18:
              case 24:
                num4 = (short) 16 /*0x10*/;
                num5 = (int) (IntPtr) num4;
                continue;
              case 19:
                index3 = 0;
                num4 = (short) 3;
                num5 = (int) (IntPtr) num4;
                continue;
              case 20:
                switch (A_0)
                {
                  case PageCustomPrintSelection.fileAction.display:
                    files = Directory.GetFiles(usrPrntTemplateDir, RptMgrErrorHandler.b("ꎈꖊ歷ﾎ\uFD90", A_1_1));
                    str1 = "";
                    this.lstUIValue.Items.Clear();
                    num4 = (short) 4;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case PageCustomPrintSelection.fileAction.edit:
                    Trace.WriteLine(RptMgrErrorHandler.b("첈\uEF8A\uE48Cﮎ", A_1_1));
                    index1 = this.lstUIValue.Items.IndexOf((object) A_1);
                    num4 = (short) 30;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  case PageCustomPrintSelection.fileAction.del:
                    index1 = this.lstUIValue.Items.IndexOf((object) A_1);
                    num4 = (short) 9;
                    num5 = (int) (IntPtr) num4;
                    continue;
                  default:
                    num4 = (short) 35;
                    num5 = (int) (IntPtr) num4;
                    continue;
                }
              case 21:
                int index4 = Global.usrLastSavedContainer.Count - index1 - 1;
                A_1 = Global.usrLastSavedContainer[index4];
                num4 = (short) 24;
                num5 = (int) (IntPtr) num4;
                continue;
              case 22:
              case 29:
              case 33:
              case 38:
label_65:
                num4 = (short) 37;
                num5 = (int) (IntPtr) num4;
                continue;
              case 23:
                this.lstUIValue.Items.Insert(0, (object) insertItem);
                str1 = "";
                ++index3;
                num4 = (short) 26;
                num5 = (int) (IntPtr) num4;
                continue;
              case 25:
                this.lstUIValue.Items.Remove(this.lstUIValue.Items[index1]);
                flag = false;
                num4 = (short) 38;
                num5 = (int) (IntPtr) num4;
                continue;
              case 27:
                if (Global.usrLastSavedContainer.Count > 0)
                {
                  num4 = (short) 19;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 6;
              case 28:
                switch (0)
                {
                  case 0:
                    goto label_8;
                  default:
                    continue;
                }
              case 30:
                if (index1 >= Global.usrLastSavedContainer.Count)
                {
                  A_1 = usrPrntTemplateDir + RptMgrErrorHandler.b("했", A_1_1) + A_1;
                  num4 = (short) 14;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                num4 = (short) 39;
                num5 = (int) (IntPtr) num4;
                continue;
              case 31 /*0x1F*/:
                num4 = (short) 20;
                num5 = (int) (IntPtr) num4;
                continue;
              case 32 /*0x20*/:
                strArray = files;
                index2 = 0;
                num4 = (short) 0;
                num5 = (int) (IntPtr) num4;
                continue;
              case 34:
                if (index3 >= Global.usrLastSavedContainer.Count)
                {
                  num4 = (short) 6;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                string str2 = Global.usrLastSavedContainer[index3];
                str1 = str2.Remove(0, str2.LastIndexOf(RptMgrErrorHandler.b("했", A_1_1)) + 1);
                num6 = 0;
                insertItem = str1;
                num4 = (short) 8;
                num5 = (int) (IntPtr) num4;
                continue;
              case 35:
                num4 = (short) 12;
                num5 = (int) (IntPtr) num4;
                continue;
              case 36:
                Global.usrLastSavedContainer.Remove(A_1);
                num4 = (short) 25;
                num5 = (int) (IntPtr) num4;
                continue;
              case 37:
                goto label_67;
              case 39:
                int index5 = Global.usrLastSavedContainer.Count - index1 - 1;
                A_1 = Global.usrLastSavedContainer[index5];
                num4 = (short) 17;
                num5 = (int) (IntPtr) num4;
                continue;
              default:
label_8:
                if (Directory.Exists(usrPrntTemplateDir))
                {
                  num4 = (short) 31 /*0x1F*/;
                  num5 = (int) (IntPtr) num4;
                  continue;
                }
                goto case 22;
            }
          }
        }
        catch (Exception ex)
        {
          flag = false;
          int num9 = (int) System.Windows.MessageBox.Show(ex.Message);
        }
label_67:
        return flag;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        switch (num4)
        {
          default:
            goto label_4;
        }
    }
  }

  private void OnSelectExistingTemplateFile(object A_0, RoutedEventArgs A_1)
  {
    int num1;
    bool? isChecked;
    bool flag;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        isChecked = this.radBtnTemplates.IsChecked;
        flag = true;
        num2 = (short) 2;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
label_21:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              this.btnPrtDelTpl.IsEnabled = true;
              this.btnPrtEditTpl.IsEnabled = true;
              this.btnPrtPreview.IsEnabled = true;
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              this.btnPrtPreview.IsEnabled = false;
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (isChecked.GetValueOrDefault() == flag & isChecked.HasValue)
              {
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              this.lstUIValue.SelectionMode = System.Windows.Controls.SelectionMode.Multiple;
              this.btnPrtPreview.IsEnabled = true;
              this.btnPrtSelectAll.IsEnabled = true;
              this.btnPrtDelTpl.IsEnabled = false;
              this.btnPrtEditTpl.IsEnabled = false;
              this.btnPrtCreateTpl.IsEnabled = false;
              num2 = (short) 8;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              goto label_17;
            case 4:
              num2 = (short) 24641;
              int num3 = (int) num2;
              num2 = (short) 24641;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  goto label_21;
                default:
                  num2 = (short) 0;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    break;
                  break;
              }
              break;
            case 5:
              this.lstUIValue.SelectionMode = System.Windows.Controls.SelectionMode.Single;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              goto label_5;
            case 7:
              num2 = (short) 9;
              num1 = (int) (IntPtr) num2;
              continue;
            case 8:
              if (this.lstUIValue.SelectedItems.Count == 0)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_22;
            case 9:
              if (this.lstUIValue.SelectedItems.Count != this.lstUIValue.Items.Count)
              {
                num2 = (short) 5;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 10:
              if (this.lstUIValue.SelectedItems.Count >= 1)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_5;
            default:
              goto label_2;
          }
          this.btnPrtCreateTpl.IsEnabled = true;
          num2 = (short) 10;
          num1 = (int) (IntPtr) num2;
        }
label_17:
        break;
label_5:
        this.btnPrtSelectAll.IsEnabled = false;
        this.btnPrtUnSelectAll.IsEnabled = false;
        break;
label_22:
        break;
    }
  }

  private void OnCreateTemplate(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 31823;
    int num2 = (int) num1;
    num1 = (short) 31823;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3)
    {
      case true:
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        PageSelectPrintItems selectPrintItems = new PageSelectPrintItems();
        selectPrintItems.BuildPrintItems();
        AcpUIDialogWindow<string> acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) selectPrintItems, (string) null);
        ((FrameworkElement) acpUiDialogWindow).Width = 645.0;
        ((FrameworkElement) acpUiDialogWindow).Height = 480.0;
        ((Window) acpUiDialogWindow).ResizeMode = ResizeMode.NoResize;
        ((Window) acpUiDialogWindow).WindowStartupLocation = WindowStartupLocation.Manual;
        ((Window) acpUiDialogWindow).Top = ((double) SystemInformation.MaxWindowTrackSize.Height - ((FrameworkElement) acpUiDialogWindow).Height) / 2.0;
        ((Window) acpUiDialogWindow).Left = ((double) SystemInformation.MaxWindowTrackSize.Width - ((FrameworkElement) acpUiDialogWindow).Width) / 2.0;
        ((FrameworkElement) acpUiDialogWindow).MaxHeight = ((FrameworkElement) acpUiDialogWindow).Height;
        ((FrameworkElement) acpUiDialogWindow).MaxWidth = ((FrameworkElement) acpUiDialogWindow).Width;
        ((Window) acpUiDialogWindow).Show();
        ((UIElement) acpUiDialogWindow).Focus();
        ((Window) acpUiDialogWindow).Hide();
        ((Window) acpUiDialogWindow).ShowDialog();
        this.lblSelectionTitle.Content = (object) AppResources.Features_Id_Template;
        this.lstUIValue.Items.Clear();
        string A_1_1 = "";
        this.radBtnTemplates.IsChecked = new bool?(true);
        this.radBtnFeatures.IsChecked = new bool?(false);
        this.btnPrtDelTpl.IsEnabled = false;
        this.btnPrtEditTpl.IsEnabled = false;
        this.btnPrtPreview.IsEnabled = false;
        this.a(PageCustomPrintSelection.fileAction.display, ref A_1_1);
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  private void OnEditTemplate(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 16 /*0x10*/;
    switch (0)
    {
      default:
        short num1 = 1;
        int num2 = (int) (IntPtr) num1;
        string A_1_2;
        IAcpField iacpField;
        while (true)
        {
          switch (num2)
          {
            case 0:
              if (File.Exists(A_1_2))
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_172;
            case 1:
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 2:
              goto label_168;
            case 3:
              iacpField = (IAcpField) null;
              A_1_2 = this.lstUIValue.SelectedItem.ToString();
              num1 = (short) 5;
              num2 = (int) (IntPtr) num1;
              continue;
            case 4:
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 5:
              if (this.a(PageCustomPrintSelection.fileAction.edit, ref A_1_2))
              {
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_172;
          }
          if (this.lstUIValue.SelectedItems.Count > 0)
          {
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
          else
            goto label_172;
        }
label_168:
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        try
        {
          ReportsSerializeItems reportsSerializeItems1;
          PageSelectPrintItems selectPrintItems;
          int num3;
          string str1;
          string str2;
          string str3;
          string str4;
          RptTreeViewItem rptTreeViewItem1;
          RptTreeViewItem rptTreeViewItem2;
          RptTreeViewItem rptTreeViewItem3;
          Dictionary<string, int>.KeyCollection.Enumerator enumerator1;
          switch (0)
          {
            case 0:
label_8:
              FileStream fileStream = new FileStream(A_1_2, FileMode.Open);
              BinaryFormatter binaryFormatter = new BinaryFormatter();
              ReportsSerializeItems reportsSerializeItems2 = new ReportsSerializeItems();
              FileStream serializationStream = fileStream;
              reportsSerializeItems1 = (ReportsSerializeItems) binaryFormatter.Deserialize((Stream) serializationStream);
              fileStream.Close();
              selectPrintItems = new PageSelectPrintItems();
              selectPrintItems.tvSelected.Items.Clear();
              selectPrintItems.BuildPrintItems();
              num3 = 0;
              str1 = "";
              str2 = "";
              str3 = "";
              str4 = "";
              rptTreeViewItem1 = new RptTreeViewItem();
              rptTreeViewItem2 = new RptTreeViewItem();
              rptTreeViewItem3 = new RptTreeViewItem();
              enumerator1 = reportsSerializeItems1.sField.Keys.GetEnumerator();
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              goto default;
            default:
              AcpUIDialogWindow<string> acpUiDialogWindow;
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    goto label_172;
                  case 1:
                    ((Window) acpUiDialogWindow).Show();
                    ((UIElement) acpUiDialogWindow).Focus();
                    ((Window) acpUiDialogWindow).Hide();
                    ((Window) acpUiDialogWindow).ShowDialog();
                    this.lblSelectionTitle.Content = (object) AppResources.Features_Id_Template;
                    this.lstUIValue.Items.Clear();
                    A_1_2 = "";
                    this.radBtnTemplates.IsChecked = new bool?(true);
                    this.radBtnFeatures.IsChecked = new bool?(false);
                    this.btnPrtDelTpl.IsEnabled = false;
                    this.btnPrtEditTpl.IsEnabled = false;
                    this.btnPrtPreview.IsEnabled = false;
                    this.a(PageCustomPrintSelection.fileAction.display, ref A_1_2);
                    num1 = (short) 0;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 2:
                    if (selectPrintItems.tvSelected.Items.Count > 0)
                    {
                      num1 = (short) 7;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 6;
                  case 3:
                    try
                    {
                      num1 = (short) 48 /*0x30*/;
                      int num4 = (int) (IntPtr) num1;
                      while (true)
                      {
                        string current;
                        IAcpRecordset feature;
                        IAcpFeatureSection iacpFeatureSection1;
                        IAcpRecordset parentRecset;
                        IAcpFeatureSection iacpFeatureSection2;
                        IAcpFeatureNode iacpFeatureNode;
                        bool flag1;
                        IEnumerator enumerator2;
                        IDisposable disposable;
                        bool flag2;
                        IAcpFeatureSection iacpFeatureSection3;
                        switch (num4)
                        {
                          case 0:
                          case 4:
                          case 15:
                          case 16 /*0x10*/:
                          case 18:
                          case 20:
                          case 27:
                          case 35:
                          case 70:
                          case 76:
                            selectPrintItems.RmvFromAvailableTreeItems(rptTreeViewItem1, rptTreeViewItem2, rptTreeViewItem3);
                            num1 = (short) 13;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 1:
                            goto label_159;
                          case 2:
                            num1 = (short) 66;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 3:
                            if (feature != null)
                            {
                              num1 = (short) 8;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto default;
                          case 5:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 0;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 6:
                            num1 = (short) 1;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 7:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 77;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 8:
                            num1 = (short) 33;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 9:
                            iacpField = feature.FieldFromFavoritePath(current, RptMgrErrorHandler.b("쾒", A_1_1));
                            num1 = (short) 17;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 10:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 14;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 11:
                            iacpFeatureSection2 = parentRecset.ParentSection;
                            iacpFeatureNode = iacpFeatureSection2.Parent;
                            num1 = (short) 2;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 12:
                            if (str1 != parentRecset.RecordsetName)
                            {
                              num1 = (short) 45;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 32 /*0x20*/;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 14:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 4;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 17:
                          case 47:
                            num1 = (short) 50;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 19:
                            if (str4 != iacpFeatureNode.UIName)
                            {
                              num1 = (short) 69;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 51;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 21:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 38;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 22:
                            if (enumerator1.MoveNext())
                            {
                              current = enumerator1.Current;
                              reportsSerializeItems1.sField.TryGetValue(current, out num3);
                              Trace.WriteLine(string.Format(RptMgrErrorHandler.b("햒ﲔ\uF296\uF598ﾚ출ﺞ햠쮢龤\uDCA6馨횪膬辮\uF7B0횲풴쎶첸즺\uD8BC\uF6BEꗀ蓼뻄\uF6C6듈", A_1_1), (object) current, (object) num3));
                              feature = FeatureManager.GetFeature(num3);
                              num1 = (short) 3;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 6;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 23:
                            str2 = "";
                            str3 = "";
                            rptTreeViewItem1 = new RptTreeViewItem();
                            rptTreeViewItem1.Header = (object) parentRecset.UIName;
                            rptTreeViewItem1.RptRecordName = parentRecset.RecordsetName;
                            rptTreeViewItem1.ID = num3;
                            rptTreeViewItem1.ItemType = 0;
                            selectPrintItems.tvSelected.Items.Add((object) rptTreeViewItem1);
                            str1 = parentRecset.RecordsetName;
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection1.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection1.UIName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str2 = iacpFeatureSection1.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 21;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 24:
                            if (!flag1)
                            {
                              num1 = (short) 23;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 64 /*0x40*/;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 25:
                            if (str3 != iacpFeatureSection2.UIName)
                            {
                              num1 = (short) 58;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto label_133;
                          case 26:
                          case 71:
                            rptTreeViewItem1.ID = num3;
                            rptTreeViewItem1.ItemType = 0;
                            selectPrintItems.tvSelected.Items.Add((object) rptTreeViewItem1);
                            str4 = iacpFeatureNode.UIName;
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection2.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection2.FeatureSectionName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str3 = iacpFeatureSection2.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 82;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 28:
                            iacpFeatureSection3 = iacpField.Parent;
                            break;
                          case 29:
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection1.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection1.UIName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str2 = iacpFeatureSection1.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 54;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 30:
                            iacpField = feature.FieldFromFavoritePath(current, RptMgrErrorHandler.b("⢒", A_1_1));
                            num1 = (short) 47;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 31 /*0x1F*/:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 20;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 32 /*0x20*/:
                            if (str2 != iacpFeatureSection1.UIName)
                            {
                              num1 = (short) 29;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 10;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 33:
                            if (Global.printTemplateVersion == 0)
                            {
                              num1 = (short) 9;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 68;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 34:
                            rptTreeViewItem1.Header = (object) iacpFeatureNode.Parent.UIName;
                            rptTreeViewItem1.RptRecordName = iacpFeatureNode.Parent.RecordsetName;
                            num1 = (short) 71;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 36:
                            try
                            {
                              num1 = (short) 6;
                              num4 = (int) (IntPtr) num1;
                              while (true)
                              {
                                switch (num4)
                                {
                                  case 0:
                                    flag1 = true;
                                    num1 = (short) 3;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  case 1:
                                    goto label_62;
                                  case 2:
                                    if (!enumerator2.MoveNext())
                                    {
                                      num1 = (short) 4;
                                      num4 = (int) (IntPtr) num1;
                                      continue;
                                    }
                                    num1 = (short) 5;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  case 3:
                                  case 4:
                                    num1 = (short) 1;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  case 5:
                                    if (((RptTreeViewItem) enumerator2.Current).RptRecordName.Equals(parentRecset.RecordsetName))
                                    {
                                      num1 = (short) 0;
                                      num4 = (int) (IntPtr) num1;
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
                                }
                                num1 = (short) 2;
                                num4 = (int) (IntPtr) num1;
                              }
                            }
                            finally
                            {
                              short num5;
                              switch (0)
                              {
                                case 0:
label_57:
                                  disposable = enumerator2 as IDisposable;
                                  num5 = (short) 2;
                                  num4 = (int) (IntPtr) num5;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num4)
                                    {
                                      case 0:
                                        goto label_61;
                                      case 1:
                                        disposable.Dispose();
                                        num5 = (short) 0;
                                        num4 = (int) (IntPtr) num5;
                                        continue;
                                      case 2:
                                        if (disposable != null)
                                        {
                                          num5 = (short) 1;
                                          num4 = (int) (IntPtr) num5;
                                          continue;
                                        }
                                        goto label_61;
                                      default:
                                        goto label_57;
                                    }
                                  }
label_61:;
                              }
                            }
label_62:
                            num1 = (short) 24;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 37:
                            num1 = (short) 25;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 38:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 70;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 39:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 16 /*0x10*/;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 40:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 74;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 41:
                            if (flag2)
                            {
                              num1 = (short) 37;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto label_133;
                          case 42:
                            str2 = "";
                            str3 = "";
                            rptTreeViewItem1 = new RptTreeViewItem();
                            num1 = (short) 59;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 43:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 18;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 44:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 35;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 45:
                            flag1 = false;
                            enumerator2 = ((IEnumerable) selectPrintItems.tvSelected.Items).GetEnumerator();
                            num1 = (short) 36;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 46:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 5;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 48 /*0x30*/:
                            switch (0)
                            {
                              case 0:
                                goto label_150;
                              default:
                                continue;
                            }
                          case 49:
                            if (!flag2)
                            {
                              num1 = (short) 42;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 41;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 50:
                            if (iacpField != null)
                            {
                              num1 = (short) 56;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 67;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 51:
                            if (str3 != iacpFeatureSection2.UIName)
                            {
                              num1 = (short) 55;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 46;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 52:
                            num1 = (short) 60;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 53:
                            try
                            {
                              num1 = (short) 6;
                              num4 = (int) (IntPtr) num1;
                              while (true)
                              {
                                switch (num4)
                                {
                                  case 0:
                                    if (enumerator2.MoveNext())
                                    {
                                      num1 = (short) 4;
                                      num4 = (int) (IntPtr) num1;
                                      continue;
                                    }
                                    num1 = (short) 3;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  case 1:
                                    goto label_104;
                                  case 2:
                                  case 3:
                                    num1 = (short) 1;
                                    num4 = (int) (IntPtr) num1;
                                    continue;
                                  case 4:
                                    if (((RptTreeViewItem) enumerator2.Current).RptRecordName.Equals(iacpFeatureNode.FeatureName))
                                    {
                                      num1 = (short) 5;
                                      num4 = (int) (IntPtr) num1;
                                      continue;
                                    }
                                    break;
                                  case 5:
                                    flag2 = true;
                                    num1 = (short) 2;
                                    num4 = (int) (IntPtr) num1;
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
                                num1 = (short) 0;
                                num4 = (int) (IntPtr) num1;
                                continue;
label_95:;
                              }
label_104:
                              num1 = (short) -17776;
                              int num6 = (int) num1;
                              num1 = (short) -17776;
                              int num7 = (int) num1;
                              switch (num6 == num7 ? 1 : 0)
                              {
                                case 0:
                                case 2:
                                  goto label_95;
                                default:
                                  num1 = (short) 0;
                                  if (num1 == (short) 0)
                                    break;
                                  break;
                              }
                            }
                            finally
                            {
                              short num8;
                              switch (0)
                              {
                                case 0:
label_108:
                                  disposable = enumerator2 as IDisposable;
                                  num8 = (short) 1;
                                  num4 = (int) (IntPtr) num8;
                                  goto default;
                                default:
                                  while (true)
                                  {
                                    switch (num4)
                                    {
                                      case 0:
                                        goto label_112;
                                      case 1:
                                        if (disposable != null)
                                        {
                                          num8 = (short) 2;
                                          num4 = (int) (IntPtr) num8;
                                          continue;
                                        }
                                        goto label_112;
                                      case 2:
                                        disposable.Dispose();
                                        num8 = (short) 0;
                                        num4 = (int) (IntPtr) num8;
                                        continue;
                                      default:
                                        goto label_108;
                                    }
                                  }
label_112:;
                              }
                            }
                            num4 = 49;
                            continue;
                          case 54:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 39;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 55:
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection2.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection2.FeatureSectionName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str3 = iacpFeatureSection2.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 61;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 56:
                            num1 = (short) 62;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 57:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 31 /*0x1F*/;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 58:
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection2.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection2.FeatureSectionName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str3 = iacpFeatureSection2.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 57;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 59:
                            if (iacpFeatureNode.Parent.RecordsetName.Equals(AppResources.Unified_Call_List))
                            {
                              num1 = (short) 34;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            rptTreeViewItem1.Header = (object) iacpFeatureNode.UIName;
                            rptTreeViewItem1.RptRecordName = iacpFeatureNode.FeatureName;
                            num1 = (short) 26;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 60:
                            iacpFeatureSection3 = iacpField.NewParent;
                            break;
                          case 61:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 43;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 62:
                            if (iacpField.NewParent != null)
                            {
                              num1 = (short) 52;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 28;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 63 /*0x3F*/:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 76;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 64 /*0x40*/:
                            if (flag1)
                            {
                              num1 = (short) 80 /*0x50*/;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto label_77;
                          case 65:
                            num1 = (short) 12;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 66:
                            if (!parentRecset.IsEmbeddedRecset)
                            {
                              num1 = (short) 65;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            num1 = (short) 19;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 67:
                            if (System.Windows.MessageBox.Show(AppResources.Template_Not_Supported, AppResources.Cannot_Edit_Template_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                            {
                              num1 = (short) 81;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto default;
                          case 68:
                            if (Global.printTemplateVersion == 1)
                            {
                              num1 = (short) 30;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto case 17;
                          case 69:
                            flag2 = false;
                            enumerator2 = ((IEnumerable) selectPrintItems.tvSelected.Items).GetEnumerator();
                            num1 = (short) 53;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 72:
                            goto label_172;
                          case 73:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 63 /*0x3F*/;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 74:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 15;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 75:
                            if (str2 != iacpFeatureSection1.UIName)
                            {
                              num1 = (short) 79;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto label_77;
                          case 77:
                            rptTreeViewItem3.RptRecordName = iacpField.NewUIName != null ? iacpField.NewUIName : iacpField.UIName;
                            rptTreeViewItem3.ID = num3;
                            rptTreeViewItem3.ItemType = 2;
                            rptTreeViewItem3.RptPath = iacpField.Path(RptMgrErrorHandler.b("⢒", A_1_1));
                            rptTreeViewItem2.Items.Add((object) rptTreeViewItem3);
                            num1 = (short) 27;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 78:
                            if (parentRecset.IsEmbeddedRecset)
                            {
                              num1 = (short) 11;
                              num4 = (int) (IntPtr) num1;
                              continue;
                            }
                            goto case 2;
                          case 79:
                            rptTreeViewItem2 = new RptTreeViewItem();
                            rptTreeViewItem2.Header = (object) iacpFeatureSection1.UIName;
                            rptTreeViewItem2.RptRecordName = iacpFeatureSection1.UIName;
                            rptTreeViewItem2.ID = num3;
                            rptTreeViewItem2.ItemType = 1;
                            rptTreeViewItem1.Items.Add((object) rptTreeViewItem2);
                            str2 = iacpFeatureSection1.UIName;
                            rptTreeViewItem3 = new RptTreeViewItem();
                            num1 = (short) 73;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 80 /*0x50*/:
                            num1 = (short) 75;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 81:
                            num1 = (short) 72;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          case 82:
                            rptTreeViewItem3.Header = iacpField.NewUIName != null ? (object) iacpField.NewUIName : (object) iacpField.UIName;
                            num1 = (short) 44;
                            num4 = (int) (IntPtr) num1;
                            continue;
                          default:
label_150:
                            num1 = (short) 22;
                            num4 = (int) (IntPtr) num1;
                            continue;
                        }
                        iacpFeatureSection1 = iacpFeatureSection3;
                        IAcpFeatureNode parent = iacpFeatureSection1.Parent;
                        parentRecset = iacpFeatureSection1.ParentRecset;
                        iacpFeatureSection2 = (IAcpFeatureSection) null;
                        iacpFeatureNode = (IAcpFeatureNode) null;
                        num1 = (short) 78;
                        num4 = (int) (IntPtr) num1;
                        continue;
label_77:
                        rptTreeViewItem3 = new RptTreeViewItem();
                        num1 = (short) 7;
                        num4 = (int) (IntPtr) num1;
                        continue;
label_133:
                        rptTreeViewItem3 = new RptTreeViewItem();
                        num1 = (short) 40;
                        num4 = (int) (IntPtr) num1;
                      }
                    }
                    finally
                    {
                      enumerator1.Dispose();
                    }
label_159:
                    num2 = 2;
                    continue;
                  case 4:
                    if (this.b != null)
                    {
                      num1 = (short) 5;
                      num2 = (int) (IntPtr) num1;
                      continue;
                    }
                    goto case 1;
                  case 5:
                    ((Window) acpUiDialogWindow).Owner = this.b;
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 6:
                    selectPrintItems.tvAvailable.Tag = (object) A_1_2;
                    acpUiDialogWindow = new AcpUIDialogWindow<string>((PageFunction<string>) selectPrintItems, (string) null);
                    ((FrameworkElement) acpUiDialogWindow).Width = 645.0;
                    ((FrameworkElement) acpUiDialogWindow).Height = 480.0;
                    ((Window) acpUiDialogWindow).ResizeMode = ResizeMode.NoResize;
                    ((Window) acpUiDialogWindow).WindowStartupLocation = WindowStartupLocation.Manual;
                    ((Window) acpUiDialogWindow).Top = ((double) SystemInformation.MaxWindowTrackSize.Height - ((FrameworkElement) acpUiDialogWindow).Height) / 2.0;
                    ((Window) acpUiDialogWindow).Left = ((double) SystemInformation.MaxWindowTrackSize.Width - ((FrameworkElement) acpUiDialogWindow).Width) / 2.0;
                    ((FrameworkElement) acpUiDialogWindow).MaxHeight = ((FrameworkElement) acpUiDialogWindow).Height;
                    ((FrameworkElement) acpUiDialogWindow).MaxWidth = ((FrameworkElement) acpUiDialogWindow).Width;
                    num1 = (short) 4;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  case 7:
                    selectPrintItems.SortItems(ref selectPrintItems.tvSelected);
                    num1 = (short) 6;
                    num2 = (int) (IntPtr) num1;
                    continue;
                  default:
                    goto label_8;
                }
              }
          }
        }
        catch (Exception ex)
        {
          int num9 = (int) System.Windows.MessageBox.Show(ex.Message);
        }
label_172:
        num1 = (short) 0;
        break;
    }
  }

  private void OnDelTemplate(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 7;
    int num1 = 1;
    short num2;
    while (true)
    {
      string A_1_2;
      switch (num1)
      {
        case 0:
          Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uEC89\uE58B\uE28D\uF58F\uDC91\uF593ﮕﶗ몙\uE79B꺝\uDD9F", A_1_1), this.lstUIValue.SelectedItem));
          A_1_2 = this.lstUIValue.SelectedItem.ToString();
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 1:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
        case 2:
          num2 = (short) -1260;
          int num3 = (int) num2;
          num2 = (short) -1260;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              if (this.lstUIValue.SelectedItems.Count != 0)
                goto label_16;
              goto case 0;
          }
        case 3:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          this.lstUIValue.Items.Remove(this.lstUIValue.SelectedItem);
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          goto label_5;
        case 5:
          num2 = (short) 8;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          if (this.a(PageCustomPrintSelection.fileAction.del, ref A_1_2))
          {
            num2 = (short) 3;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto case 7;
        case 7:
          num2 = (short) 2;
          num1 = (int) (IntPtr) num2;
          continue;
        case 8:
          if (System.Windows.MessageBox.Show(AppResources.Are_You_Sure_Remove_Selected_Template_From_List, AppResources.Confirm_Deleting, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
          {
            num2 = (short) 0;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
      if (this.lstUIValue.SelectedItems.Count > 0)
      {
        num2 = (short) 5;
        num1 = (int) (IntPtr) num2;
      }
      else
        break;
    }
    return;
label_5:
    this.btnPrtDelTpl.IsEnabled = false;
    this.btnPrtEditTpl.IsEnabled = false;
    this.btnPrtPreview.IsEnabled = false;
    return;
label_11:
    num2 = (short) 0;
    return;
label_16:;
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = -27250;
    int num2 = (int) num1;
    num1 = (short) -27250;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void OnHelp(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 6;
    try
    {
      switch (true)
      {
        case true:
          short num = 1;
          if (num == (short) 0)
            ;
          num = (short) 0;
          if (num == (short) 0)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("ꪈ뮊릌붎\uF290ꎒ꒔ꆖﾘ", A_1_1));
          break;
        default:
          goto case 1;
      }
    }
    catch (Exception ex)
    {
    }
  }

  internal bool BuildCustomPrintSelection()
  {
    switch (0)
    {
      default:
        short num1 = 0;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        bool flag = true;
        this.lstUIValue.Items.Clear();
        IEnumerator<IAcpRecordset> enumerator = FeatureManager.Features.GetEnumerator();
        try
        {
          num1 = (short) 0;
          int num2 = (int) (IntPtr) num1;
          while (true)
          {
            IAcpRecordset current;
            System.Windows.Controls.ListViewItem newItem;
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
                newItem.Content = (object) current.UIName;
                this.lstUIValue.Items.Add((object) newItem);
                num1 = (short) 3;
                num2 = (int) (IntPtr) num1;
                continue;
              case 2:
                if (enumerator.MoveNext())
                {
                  current = enumerator.Current;
                  newItem = new System.Windows.Controls.ListViewItem();
                  num1 = (short) 6;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                goto label_24;
              case 5:
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              case 6:
                if (!current.HiddenStatic)
                {
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
            }
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num3 = -19025;
          int num4 = (int) num3;
          num3 = (short) -19025;
          int num5 = (int) num3;
          int num6;
          switch (num4 == num5 ? 1 : 0)
          {
            case 0:
            case 2:
label_22:
              num3 = (short) 0;
              num6 = (int) (IntPtr) num3;
              break;
            default:
              num3 = (short) 0;
              if (num3 == (short) 0)
                ;
              num3 = (short) 2;
              num6 = (int) (IntPtr) num3;
              break;
          }
          while (true)
          {
            switch (num6)
            {
              case 0:
                goto label_23;
              case 1:
                goto label_21;
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
            if (enumerator != null)
            {
              num3 = (short) 1;
              num6 = (int) (IntPtr) num3;
            }
            else
              goto label_23;
          }
label_21:
          enumerator.Dispose();
          goto label_22;
label_23:;
        }
label_24:
        this.lstUIValue.Items.SortDescriptions.Add(new SortDescription(ContentControl.ContentProperty.ToString(), ListSortDirection.Ascending));
        return flag;
    }
  }

  private bool a(IAcpFeatureNode A_0, IAcpFeatureSection A_1)
  {
    switch (0)
    {
      default:
        bool flag = false;
        IEnumerator<IAcpFeatureSection> enumerator1 = A_0.FeatureSectionsCollection.GetEnumerator();
        short num1;
        try
        {
          int num2 = 0;
          while (true)
          {
            IEnumerator<IAcpField> enumerator2;
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
              case 5:
                goto label_61;
              case 2:
                try
                {
                  num1 = (short) 8;
                  int num3 = (int) (IntPtr) num1;
                  while (true)
                  {
                    IAcpField current;
                    switch (num3)
                    {
                      case 0:
                        if (current.NewParent != current.Parent)
                        {
                          num1 = (short) 1;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 1:
                        num1 = (short) 15;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 2:
                        num1 = (short) 6;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 3:
                        num1 = (short) 9;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 4:
                        if (!((AcpFieldBase) current).HiddenStatic)
                        {
                          num1 = (short) 17;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 5:
                        if (current.NewParent != null)
                        {
                          num1 = (short) 3;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 6:
                      case 16 /*0x10*/:
                        goto label_46;
                      case 7:
                        if (((AcpFieldBase) current).Visible)
                        {
                          num1 = (short) 10;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
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
                        if (current.NewParent == A_1)
                        {
                          num1 = (short) 11;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 10:
                        flag = true;
                        num1 = (short) 16 /*0x10*/;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 11:
                        num1 = (short) 0;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 12:
                        if (!((AcpFieldBase) current).HiddenDynamic)
                        {
                          num1 = (short) 14;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 13:
                        num1 = (short) 4;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 14:
                        num1 = (short) 7;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 15:
                        if (current != null)
                        {
                          num1 = (short) 13;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        break;
                      case 17:
                        num1 = (short) 12;
                        num3 = (int) (IntPtr) num1;
                        continue;
                      case 18:
                        if (!enumerator2.MoveNext())
                        {
                          num1 = (short) 2;
                          num3 = (int) (IntPtr) num1;
                          continue;
                        }
                        current = enumerator2.Current;
                        num1 = (short) 5;
                        num3 = (int) (IntPtr) num1;
                        continue;
                    }
                    num1 = (short) 18;
                    num3 = (int) (IntPtr) num1;
                  }
                }
                finally
                {
                  int num4 = 2;
                  while (true)
                  {
                    switch (num4)
                    {
                      case 0:
                        goto label_40;
                      case 1:
                        enumerator2.Dispose();
                        num4 = 0;
                        continue;
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
                    if (enumerator2 != null)
                      num4 = 1;
                    else
                      break;
                  }
label_40:;
                }
label_46:
                num1 = (short) 6;
                num2 = (int) (IntPtr) num1;
                continue;
              case 3:
                num1 = (short) 1;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                num1 = (short) 5;
                num2 = (int) (IntPtr) num1;
                continue;
              case 6:
                if (flag)
                {
                  num1 = (short) 3;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                break;
              case 7:
                if (!enumerator1.MoveNext())
                {
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                enumerator2 = enumerator1.Current.FieldsCollection.GetEnumerator();
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 7;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          short num5 = -10513;
          int num6;
          switch ((short) -10513 == num5 ? 1 : 0)
          {
            case 0:
            case 2:
label_58:
              num5 = (short) 0;
              num6 = (int) (IntPtr) num5;
              break;
            default:
              num5 = (short) 0;
              if (num5 == (short) 0)
                ;
              num5 = (short) 2;
              num6 = (int) (IntPtr) num5;
              break;
          }
          while (true)
          {
            switch (num6)
            {
              case 0:
                goto label_59;
              case 1:
                goto label_57;
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
            if (enumerator1 != null)
            {
              num5 = (short) 1;
              num6 = (int) (IntPtr) num5;
            }
            else
              goto label_60;
          }
label_57:
          enumerator1.Dispose();
          goto label_58;
label_59:
          num5 = (short) 1;
          if (num5 == (short) 0)
            ;
label_60:;
        }
label_61:
        num1 = (short) 0;
        return flag;
    }
  }

  private bool a(IAcpFeatureSection A_0)
  {
    bool flag = false;
    IEnumerator<IAcpField> enumerator = A_0.FieldsCollection.GetEnumerator();
    short num1;
    try
    {
      int num2 = 11;
      while (true)
      {
        IAcpField current;
        switch (num2)
        {
          case 0:
            num1 = (short) 16 /*0x10*/;
            num2 = (int) (IntPtr) num1;
            continue;
          case 1:
            num1 = (short) 8;
            num2 = (int) (IntPtr) num1;
            continue;
          case 2:
          case 19:
            goto label_44;
          case 3:
            num1 = (short) 10;
            num2 = (int) (IntPtr) num1;
            continue;
          case 4:
            num1 = (short) 5;
            num2 = (int) (IntPtr) num1;
            continue;
          case 5:
            if (current != null)
            {
              num1 = (short) 3;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
          case 6:
            if (flag)
            {
              num1 = (short) 14;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            break;
          case 7:
            if (current.NewParent != null)
            {
              num1 = (short) 15;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 4;
          case 8:
            if (current.NewParent == current.Parent)
            {
              num1 = (short) 4;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
          case 9:
            num1 = (short) 6;
            num2 = (int) (IntPtr) num1;
            continue;
          case 10:
            if (!((AcpFieldBase) current).HiddenStatic)
            {
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
          case 11:
            switch (0)
            {
              case 0:
                break;
              default:
                continue;
            }
            break;
          case 12:
            num1 = (short) 20;
            num2 = (int) (IntPtr) num1;
            continue;
          case 13:
            flag = true;
            num1 = (short) 9;
            num2 = (int) (IntPtr) num1;
            continue;
          case 14:
            num1 = (short) 2;
            num2 = (int) (IntPtr) num1;
            continue;
          case 15:
            num1 = (short) 21;
            num2 = (int) (IntPtr) num1;
            continue;
          case 16 /*0x10*/:
            if (!((AcpFieldBase) current).HiddenDynamic)
            {
              num1 = (short) 12;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
          case 17:
            if (!enumerator.MoveNext())
            {
              num1 = (short) 18;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            current = enumerator.Current;
            num1 = (short) 7;
            num2 = (int) (IntPtr) num1;
            continue;
          case 18:
            num1 = (short) 19;
            num2 = (int) (IntPtr) num1;
            continue;
          case 20:
            if (((AcpFieldBase) current).Visible)
            {
              num1 = (short) 13;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
          case 21:
            if (current.NewParent != null)
            {
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            }
            goto case 9;
        }
        num1 = (short) 17;
        num2 = (int) (IntPtr) num1;
      }
    }
    finally
    {
      short num3 = 14583;
      int num4;
      switch ((short) 14583 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
label_42:
          num3 = (short) 0;
          num4 = (int) (IntPtr) num3;
          break;
        default:
          num3 = (short) 0;
          if (num3 == (short) 0)
            ;
          num3 = (short) 2;
          num4 = (int) (IntPtr) num3;
          break;
      }
      while (true)
      {
        switch (num4)
        {
          case 0:
            goto label_43;
          case 1:
            goto label_41;
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
        if (enumerator != null)
        {
          num3 = (short) 1;
          num4 = (int) (IntPtr) num3;
        }
        else
          goto label_43;
      }
label_41:
      enumerator.Dispose();
      goto label_42;
label_43:;
    }
label_44:
    num1 = (short) 1;
    if (num1 == (short) 0)
      ;
    num1 = (short) 0;
    return flag;
  }

  internal bool BuildFeatureXMLData()
  {
    int A_1 = 12;
    int num1 = 0;
    switch (num1)
    {
      default:
        bool flag1 = true;
        bool flag2;
        try
        {
          XmlTextWriter xmlTextWriter = new XmlTextWriter(Global.XMLFileName, (Encoding) null);
          xmlTextWriter.Formatting = Formatting.Indented;
          xmlTextWriter.Indentation = 3;
          xmlTextWriter.WriteStartDocument();
          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쮎\uF090\uE792\uF494", A_1));
          IEnumerator enumerator1 = this.lstUIValue.SelectedItems.GetEnumerator();
          try
          {
            num1 = 13;
            while (true)
            {
              short num2;
              IAcpRecordset feature;
              int num3;
              IAcpFeatureNode A_0;
              IEnumerator<IAcpFeatureSection> enumerator2;
              System.Windows.Controls.ListViewItem current1;
              int num4;
              bool flag3;
              IEnumerator<IAcpRecordset> enumerator3;
              switch (num1)
              {
                case 0:
                  if (!flag3)
                  {
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  feature = FeatureManager.GetFeature(num4);
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 1:
                case 14:
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if (feature != null)
                  {
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 3:
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 4:
                  try
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      int num5;
                      IAcpFeatureSection current2;
                      bool flag4;
                      bool flag5;
                      bool flag6;
                      int num6;
                      IEnumerator<IAcpFeatureSection> enumerator4;
                      IEnumerator<IAcpField> enumerator5;
                      bool flag7;
                      switch (num1)
                      {
                        case 0:
                          goto label_42;
                        case 1:
                          try
                          {
                            num2 = (short) 12;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpField current3;
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                  goto label_326;
                                case 2:
                                  flag4 = true;
                                  num2 = (short) 11;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (enumerator5.MoveNext())
                                  {
                                    current3 = enumerator5.Current;
                                    num2 = (short) 10;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 9;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 4:
                                  if (((AcpFieldBase) current3).Visible)
                                  {
                                    num2 = (short) 2;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 5:
                                  if (!((AcpFieldBase) current3).HiddenDynamic)
                                  {
                                    num2 = (short) 0;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 6:
                                  num2 = (short) 8;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 7:
                                  num2 = (short) 5;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 8:
                                  if (!((AcpFieldBase) current3).HiddenStatic)
                                  {
                                    num2 = (short) 7;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 9:
                                case 11:
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 10:
                                  if (current3 != null)
                                  {
                                    num2 = (short) 6;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 12:
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
                            num1 = 0;
                            while (true)
                            {
                              short num7;
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
                                  enumerator5.Dispose();
                                  num7 = (short) 2;
                                  num1 = (int) (IntPtr) num7;
                                  continue;
                                case 2:
                                  goto label_196;
                              }
                              if (enumerator5 != null)
                              {
                                num7 = (short) 1;
                                num1 = (int) (IntPtr) num7;
                              }
                              else
                                break;
                            }
label_196:;
                          }
                        case 2:
                          switch (0)
                          {
                            case 0:
                              goto label_197;
                            default:
                              continue;
                          }
                        case 3:
                        case 24:
                          num2 = (short) 17;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                        case 12:
                          num2 = (short) 27;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!(current2.GetType() == typeof (AlertTones)))
                          {
                            num2 = (short) 26;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto default;
                        case 7:
                          num2 = (short) 37;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 8:
                          if (current2.HasVisibleObjects)
                          {
                            num2 = (short) 5;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 33;
                        case 9:
                          if (current2.HasEmbeddedRecset)
                          {
                            num2 = (short) 13;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 10:
                          Trace.WriteLine(string.Format(RptMgrErrorHandler.b("쪎ﲐ\uF192\uF094\uF396ﶘﺚ列톞삠캢삤鶦튨鮪킬", A_1), (object) current2.EmbeddedRecset.UIName));
                          enumerator5 = current2.FieldsCollection.GetEnumerator();
                          num2 = (short) 30;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 11:
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          num2 = (short) 36;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192요\uDE96\uF798\uE89A", A_1), current2.HasEmbeddedRecset ? RptMgrErrorHandler.b("\uDB8E", A_1) : RptMgrErrorHandler.b("즎", A_1));
                          num2 = (short) 18;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 15:
label_316:
                          xmlTextWriter.WriteEndElement();
                          num2 = (short) 22;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          enumerator5 = current2.FieldsCollection.GetEnumerator();
                          num2 = (short) 25;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 17:
                          if (flag6)
                          {
                            num2 = (short) 32 /*0x20*/;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 15;
                        case 18:
                          if (!(flag5 | flag6))
                          {
                            enumerator4 = A_0.FeatureSectionsCollection.GetEnumerator();
                            num2 = (short) 19;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 10;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 19:
                          try
                          {
                            num2 = (short) 2;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpFeatureSection current4;
                              switch (num1)
                              {
                                case 0:
                                  try
                                  {
                                    num2 = (short) 7;
                                    num1 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpField current5;
                                      IEnumerator<AcpBusinessLayer.ListItem> enumerator6;
                                      switch (num1)
                                      {
                                        case 0:
                                          num2 = (short) 18;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 1:
                                          string str = "".PadLeft(current5.ToString().Length, '*');
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), str);
                                          num2 = (short) 37;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 2:
                                          if (current5.NewParent != current2)
                                          {
                                            num2 = (short) 24;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto case 27;
                                        case 3:
                                          num2 = (short) 17;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 4:
                                          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uDD90햒ﲔ\uF296\uF598ﾚ", A_1));
                                          num2 = (short) 31 /*0x1F*/;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 5:
                                        case 20:
                                          num2 = (short) 10;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 6:
                                          num2 = (short) 11;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 7:
                                          switch (0)
                                          {
                                            case 0:
                                              goto label_128;
                                            default:
                                              continue;
                                          }
                                        case 8:
                                          if (current4 == current2)
                                          {
                                            num2 = (short) 27;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 10:
                                          if (current5 is AcpListField)
                                          {
                                            num2 = (short) 41;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 11:
                                          if (!((AcpFieldBase) current5).HiddenDynamic)
                                          {
                                            num2 = (short) 34;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 12:
                                          if (current5 != null)
                                          {
                                            num2 = (short) 30;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 13:
                                          goto label_152;
                                        case 14:
                                          if (((AcpFieldBase) current5).Visible)
                                          {
                                            num2 = (short) 3;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 15:
                                          try
                                          {
                                            num2 = (short) 10;
                                            num1 = (int) (IntPtr) num2;
                                            while (true)
                                            {
                                              AcpBusinessLayer.ListItem current6;
                                              switch (num1)
                                              {
                                                case 0:
                                                case 5:
                                                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), current6.ItemName.ToString().Trim());
                                                  xmlTextWriter.WriteEndElement();
                                                  num2 = (short) 7;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 1:
                                                  goto label_77;
                                                case 2:
                                                  num2 = (short) 1;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 3:
                                                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current5.NewUIName);
                                                  num2 = (short) 5;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 4:
                                                  if (string.IsNullOrEmpty(current5.NewUIName))
                                                  {
                                                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current5.UIName);
                                                    num2 = (short) 0;
                                                    num1 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  num2 = (short) 3;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 6:
                                                  if (current6.ItemVisibility)
                                                  {
                                                    num2 = (short) 9;
                                                    num1 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  break;
                                                case 8:
                                                  if (enumerator6.MoveNext())
                                                  {
                                                    current6 = enumerator6.Current;
                                                    num2 = (short) 6;
                                                    num1 = (int) (IntPtr) num2;
                                                    continue;
                                                  }
                                                  num2 = (short) 2;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 9:
                                                  xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uDD90햒ﲔ\uF296\uF598ﾚ", A_1));
                                                  num2 = (short) 4;
                                                  num1 = (int) (IntPtr) num2;
                                                  continue;
                                                case 10:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                              }
                                              num2 = (short) 8;
                                              num1 = (int) (IntPtr) num2;
                                            }
                                          }
                                          finally
                                          {
                                            num1 = 2;
                                            while (true)
                                            {
                                              short num8;
                                              switch (num1)
                                              {
                                                case 0:
                                                  enumerator6.Dispose();
                                                  num8 = (short) 1;
                                                  num1 = (int) (IntPtr) num8;
                                                  continue;
                                                case 1:
                                                  goto label_113;
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
                                              if (enumerator6 != null)
                                              {
                                                num8 = (short) 0;
                                                num1 = (int) (IntPtr) num8;
                                              }
                                              else
                                                break;
                                            }
label_113:;
                                          }
                                        case 16 /*0x10*/:
                                          num2 = (short) 28;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 17:
                                          if (!FieldFilters.FilterSpecialFieldInReport(current5))
                                          {
                                            num2 = (short) 23;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 18:
                                          if (current5.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C\uDC9E캠춢펤슦잨\uDFAA쒬삮\uDFB0튲\uD9B4\uF6B6쾸\uDABA풼펾ꃀꇂ꧄ꋆ蓈껊ꏌ뫎飐\uA7D2냔뫖\uAAD8蓚鳜\uEDDE폠헢폤퇦", A_1))
                                          {
                                            num2 = (short) 42;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 19:
                                          if (((AcpListField) current5).SerializeItems)
                                          {
                                            num2 = (short) 0;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 21:
                                          if (!current5.IsMasked)
                                          {
                                            num2 = (short) 26;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 1;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 22:
                                          num2 = (short) 13;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 23:
                                          num2 = (short) 29;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 24:
                                          num2 = (short) 9;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 25:
                                          num2 = (short) 2;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 26:
                                          if (current5.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C\uDC9E캠춢펤슦잨\uDFAA쒬삮\uDFB0튲\uD9B4\uF6B6쾸\uDABA풼펾ꃀꇂ꧄ꋆ蓈껊ꏌ뫎飐\uA7D2냔뫖\uAAD8蓚鳜\uEDDE폠헢폤퇦", A_1))
                                          {
                                            num2 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto case 37;
                                        case 27:
                                          num2 = (short) 12;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 28:
                                          if (current5.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C쮞펠횢쮤첦삨얪쪬\uEEAE잰튲\uDCB4\uDBB6\uD8B8\uD9BA톼\uDABE賀ꛂꯄ닆胈뿊\uA8CCꋎꋐ賒铔\uE5D6\uEBD8\uEDDA\uEBDC\uE8DE", A_1))
                                          {
                                            num2 = (short) 33;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto case 37;
                                        case 29:
                                          if (!current5.IgnoreOnPrint)
                                          {
                                            num2 = (short) 4;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 30:
                                          num2 = (short) 43;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 31 /*0x1F*/:
                                          if (!string.IsNullOrEmpty(current5.NewUIName))
                                          {
                                            num2 = (short) 38;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current5.UIName);
                                          num2 = (short) 5;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 32 /*0x20*/:
                                          if (current5.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C쮞펠횢쮤첦삨얪쪬\uEEAE잰튲\uDCB4\uDBB6\uD8B8\uD9BA톼\uDABE賀ꛂꯄ닆胈뿊\uA8CCꋎꋐ賒铔\uE5D6\uEBD8\uEDDA\uEBDC\uE8DE", A_1))
                                          {
                                            num2 = (short) 40;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 33:
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), AcpXMLCoreEngLib.convertToArabicFormat(current5.ToString()));
                                          num2 = (short) 39;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 34:
                                          num2 = (short) 14;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 36:
                                          if (enumerator5.MoveNext())
                                          {
                                            current5 = enumerator5.Current;
                                            num2 = (short) 44;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 22;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 37:
                                        case 39:
label_77:
                                          xmlTextWriter.WriteEndElement();
                                          num2 = (short) 35;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 38:
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current5.NewUIName);
                                          num2 = (short) 20;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 40:
                                          enumerator6 = ((AcpListField) current5).Items.GetEnumerator();
                                          num2 = (short) 15;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 41:
                                          num2 = (short) 19;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 42:
                                          num2 = (short) 32 /*0x20*/;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 43:
                                          if (!((AcpFieldBase) current5).HiddenStatic)
                                          {
                                            num2 = (short) 6;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          goto default;
                                        case 44:
                                          if (current5.NewParent == null)
                                          {
                                            num2 = (short) 8;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 25;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        default:
label_128:
                                          num2 = (short) 36;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                      }
                                      num2 = (short) 21;
                                      num1 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    short num9 = 2;
                                    num1 = (int) (IntPtr) num9;
                                    while (true)
                                    {
                                      switch (num1)
                                      {
                                        case 0:
                                          enumerator5.Dispose();
                                          num9 = (short) 1;
                                          num1 = (int) (IntPtr) num9;
                                          continue;
                                        case 1:
                                          goto label_151;
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
                                      if (enumerator5 != null)
                                      {
                                        num9 = (short) 0;
                                        num1 = (int) (IntPtr) num9;
                                      }
                                      else
                                        break;
                                    }
label_151:;
                                  }
                                case 1:
                                  goto label_316;
                                case 2:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 3:
                                  if (enumerator4.MoveNext())
                                  {
                                    current4 = enumerator4.Current;
                                    enumerator5 = current4.FieldsCollection.GetEnumerator();
                                    num2 = (short) 0;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 4:
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                              }
label_152:
                              num2 = (short) 3;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num10 = 2;
                            num1 = (int) (IntPtr) num10;
                            while (true)
                            {
                              switch (num1)
                              {
                                case 0:
                                  enumerator4.Dispose();
                                  num10 = (short) 1;
                                  num1 = (int) (IntPtr) num10;
                                  continue;
                                case 1:
                                  goto label_162;
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
                                num1 = (int) (IntPtr) num10;
                              }
                              else
                                break;
                            }
label_162:;
                          }
                        case 20:
                          num2 = (short) 15;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 21:
                          if (num5 >= current2.EmbeddedRecset.Count)
                          {
                            num2 = (short) 20;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쪎ﲐ\uF192\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢", A_1));
                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192\uDC94\uDE96\uDD98", A_1), num5.ToString());
                          IAcpFeatureNode iacpFeatureNode = current2.EmbeddedRecset[num5];
                          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("쪎ﲐ\uF192요\uF296滛\uEF9A\uF49C\uF09E쾠", A_1));
                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192펔쒖ﲘ\uF89A\uE99C\uF69E캠춢", A_1), iacpFeatureNode.UIName);
                          enumerator4 = iacpFeatureNode.FeatureSectionsCollection.GetEnumerator();
                          num2 = (short) 35;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 23:
                          flag4 = false;
                          num2 = (short) 7;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 25:
                          try
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpField current7;
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 9;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 2:
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
                                  if (!((AcpFieldBase) current7).HiddenStatic)
                                  {
                                    num2 = (short) 0;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 4:
                                  if (((AcpFieldBase) current7).Visible)
                                  {
                                    num2 = (short) 11;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 5:
                                  if (current7 != null)
                                  {
                                    num2 = (short) 12;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 6:
                                  goto label_231;
                                case 7:
                                case 10:
                                  num2 = (short) 6;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 8:
                                  if (!enumerator5.MoveNext())
                                  {
                                    num2 = (short) 10;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  current7 = enumerator5.Current;
                                  num2 = (short) 5;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 9:
                                  if (!((AcpFieldBase) current7).HiddenDynamic)
                                  {
                                    num2 = (short) 2;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 11:
                                  flag5 = true;
                                  num2 = (short) 7;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 12:
                                  num2 = (short) 3;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                              }
                              num2 = (short) 8;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            num1 = 0;
                            while (true)
                            {
                              short num11;
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
                                  enumerator5.Dispose();
                                  num11 = (short) 2;
                                  num1 = (int) (IntPtr) num11;
                                  continue;
                                case 2:
                                  goto label_230;
                              }
                              if (enumerator5 != null)
                              {
                                num11 = (short) 1;
                                num1 = (int) (IntPtr) num11;
                              }
                              else
                                break;
                            }
label_230:;
                          }
label_231:
                          num6 = 0;
                          num2 = (short) 4;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 26:
                          flag4 = false;
                          flag5 = false;
                          flag6 = false;
                          num2 = (short) 8;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 27:
                          if (num6 >= current2.EmbeddedRecset.Count)
                          {
                            num2 = (short) 38;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          enumerator4 = current2.EmbeddedRecset[num6].FeatureSectionsCollection.GetEnumerator();
                          num2 = (short) 28;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 28:
                          try
                          {
                            num2 = (short) 4;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpFeatureSection current8;
                              switch (num1)
                              {
                                case 0:
                                  goto label_52;
                                case 1:
                                  try
                                  {
                                    num2 = (short) 10;
                                    num1 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpField current9;
                                      switch (num1)
                                      {
                                        case 0:
                                          if (((AcpFieldBase) current9).Visible)
                                          {
                                            num2 = (short) 6;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 1:
                                          if (!((AcpFieldBase) current9).HiddenDynamic)
                                          {
                                            num2 = (short) 4;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 2:
                                          num2 = (short) 1;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 3:
                                          num2 = (short) 5;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 4:
                                          num2 = (short) 0;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 5:
                                          if (!((AcpFieldBase) current9).HiddenStatic)
                                          {
                                            num2 = (short) 2;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 6:
                                          flag6 = true;
                                          num2 = (short) 12;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 7:
                                          goto label_301;
                                        case 8:
                                          if (current9 != null)
                                          {
                                            num2 = (short) 3;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 9:
                                        case 12:
                                          num2 = (short) 7;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 10:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 11:
                                          if (enumerator5.MoveNext())
                                          {
                                            current9 = enumerator5.Current;
                                            num2 = (short) 8;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 9;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                      }
                                      num2 = (short) 11;
                                      num1 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    num1 = 2;
                                    while (true)
                                    {
                                      switch (num1)
                                      {
                                        case 0:
                                          enumerator5.Dispose();
                                          num1 = 1;
                                          continue;
                                        case 1:
                                          goto label_299;
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
                                      if (enumerator5 != null)
                                        num1 = 0;
                                      else
                                        break;
                                    }
label_299:;
                                  }
                                case 2:
                                  if (enumerator4.MoveNext())
                                  {
                                    current8 = enumerator4.Current;
                                    num2 = (short) 6;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  num2 = (short) 3;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 3:
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
                                case 5:
                                  enumerator5 = current8.FieldsCollection.GetEnumerator();
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 6:
                                  if (!flag6)
                                  {
                                    num2 = (short) 5;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  goto case 3;
                              }
label_301:
                              num2 = (short) 2;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num12 = 1;
                            num1 = (int) (IntPtr) num12;
                            while (true)
                            {
                              switch (num1)
                              {
                                case 0:
                                  goto label_311;
                                case 1:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 2:
                                  enumerator4.Dispose();
                                  num12 = (short) 0;
                                  num1 = (int) (IntPtr) num12;
                                  continue;
                              }
                              if (enumerator4 != null)
                              {
                                num12 = (short) 2;
                                num1 = (int) (IntPtr) num12;
                              }
                              else
                                break;
                            }
label_311:;
                          }
label_52:
                          ++num6;
                          num2 = (short) 12;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 29:
                          if (!enumerator2.MoveNext())
                          {
                            num2 = (short) 11;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current2 = enumerator2.Current;
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 30:
                          try
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              IAcpField current10;
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 8;
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
                                  if (!FieldFilters.FilterSpecialFieldInReport(current10))
                                  {
                                    num2 = (short) 9;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 5:
                                  if (!((AcpFieldBase) current10).HiddenStatic)
                                  {
                                    num2 = (short) 13;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 6:
                                  if (((AcpFieldBase) current10).Visible)
                                  {
                                    num2 = (short) 2;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 7:
                                  if (current10 != null)
                                  {
                                    num2 = (short) 14;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 8:
                                  goto label_168;
                                case 9:
                                  xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uDD90햒ﲔ\uF296\uF598ﾚ", A_1));
                                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current10.UIName);
                                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), AcpXMLCoreEngLib.convertToArabicFormat(current10.ToString()));
                                  xmlTextWriter.WriteEndElement();
                                  num2 = (short) 1;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 10:
                                  if (!((AcpFieldBase) current10).HiddenDynamic)
                                  {
                                    num2 = (short) 12;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  break;
                                case 11:
                                  if (!enumerator5.MoveNext())
                                  {
                                    num2 = (short) 0;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  current10 = enumerator5.Current;
                                  num2 = (short) 7;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 12:
                                  num2 = (short) 6;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 13:
                                  num2 = (short) 10;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 14:
                                  num2 = (short) 5;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                              }
                              num2 = (short) 11;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            num1 = 2;
                            while (true)
                            {
                              switch (num1)
                              {
                                case 0:
                                  enumerator5.Dispose();
                                  num1 = 1;
                                  continue;
                                case 1:
                                  goto label_265;
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
                              if (enumerator5 != null)
                                num1 = 0;
                              else
                                break;
                            }
label_265:;
                          }
label_168:
                          num5 = 0;
                          num2 = (short) 24;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 31 /*0x1F*/:
                          Trace.WriteLine(string.Format(RptMgrErrorHandler.b("ﲎ\uF490\uF092\uE194ﺖ\uF698\uF59A펜ﺞ철욢龤\uDCA6馨횪", A_1), (object) current2.UIName));
                          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDC8E\uF490\uF092\uE194ﺖ\uF698\uF59A", A_1));
                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("즎슐\uF692\uF694\uE396\uF098\uF49A\uF39C", A_1), current2.UIName);
                          num2 = (short) 14;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 32 /*0x20*/:
                          num2 = (short) 21;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 33:
label_326:
                          flag7 = this.a(A_0, current2);
                          num2 = (short) 34;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 34:
                          if (!this.a(current2))
                          {
                            num2 = (short) 23;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 7;
                        case 35:
                          try
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            while (true)
                            {
                              switch (num1)
                              {
                                case 0:
                                  num2 = (short) 2;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 1:
                                  if (!enumerator4.MoveNext())
                                  {
                                    num2 = (short) 0;
                                    num1 = (int) (IntPtr) num2;
                                    continue;
                                  }
                                  IAcpFeatureSection current11 = enumerator4.Current;
                                  Trace.WriteLine(string.Format(RptMgrErrorHandler.b("쪎ﲐ\uF192\uF794\uF296ﶘﺚ列\uEC9E쒠삢톤캦욨얪\uE3AC캮\uDCB0횲辴첶覸욺", A_1), (object) current11.UIName));
                                  enumerator5 = current11.FieldsCollection.GetEnumerator();
                                  num2 = (short) 4;
                                  num1 = (int) (IntPtr) num2;
                                  continue;
                                case 2:
                                  goto label_315;
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
                                  try
                                  {
                                    num2 = (short) 17;
                                    num1 = (int) (IntPtr) num2;
                                    while (true)
                                    {
                                      IAcpField current12;
                                      switch (num1)
                                      {
                                        case 0:
                                          if (((AcpFieldBase) current12).Visible)
                                          {
                                            num2 = (short) 5;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 1:
                                          num2 = (short) 11;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 2:
                                          if (!FieldFilters.FilterSpecialFieldInReport(current12))
                                          {
                                            num2 = (short) 14;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 3:
                                          if (!((AcpFieldBase) current12).HiddenStatic)
                                          {
                                            num2 = (short) 1;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 4:
                                          if (current12 != null)
                                          {
                                            num2 = (short) 13;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 5:
                                          num2 = (short) 2;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 6:
                                          string str = "".PadLeft(current12.ToString().Length, '*');
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), str);
                                          num2 = (short) 12;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 7:
                                          num2 = (short) 0;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 8:
                                          goto label_371;
                                        case 9:
                                          if (!enumerator5.MoveNext())
                                          {
                                            num2 = (short) 10;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          current12 = enumerator5.Current;
                                          num2 = (short) 4;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 10:
                                          num2 = (short) 8;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 11:
                                          if (!((AcpFieldBase) current12).HiddenDynamic)
                                          {
                                            num2 = (short) 7;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          break;
                                        case 12:
                                        case 16 /*0x10*/:
                                          xmlTextWriter.WriteEndElement();
                                          num2 = (short) 15;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 13:
                                          num2 = (short) 3;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 14:
                                          xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("\uDC8E\uDD90햒ﲔ\uF296\uF598ﾚ", A_1));
                                          xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1), current12.UIName);
                                          num2 = (short) 18;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                        case 17:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 18:
                                          if (!current12.IsMasked)
                                          {
                                            xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1), AcpXMLCoreEngLib.convertToArabicFormat(current12.ToString()));
                                            num2 = (short) 16 /*0x10*/;
                                            num1 = (int) (IntPtr) num2;
                                            continue;
                                          }
                                          num2 = (short) 6;
                                          num1 = (int) (IntPtr) num2;
                                          continue;
                                      }
                                      num2 = (short) 9;
                                      num1 = (int) (IntPtr) num2;
                                    }
                                  }
                                  finally
                                  {
                                    num1 = 1;
                                    while (true)
                                    {
                                      switch (num1)
                                      {
                                        case 0:
                                          goto label_370;
                                        case 1:
                                          switch (0)
                                          {
                                            case 0:
                                              break;
                                            default:
                                              continue;
                                          }
                                          break;
                                        case 2:
                                          enumerator5.Dispose();
                                          num1 = 0;
                                          continue;
                                      }
                                      if (enumerator5 != null)
                                        num1 = 2;
                                      else
                                        break;
                                    }
label_370:;
                                  }
                              }
label_371:
                              num2 = (short) 1;
                              num1 = (int) (IntPtr) num2;
                            }
                          }
                          finally
                          {
                            short num13 = 1;
                            num1 = (int) (IntPtr) num13;
                            while (true)
                            {
                              switch (num1)
                              {
                                case 0:
                                  goto label_382;
                                case 1:
                                  switch (0)
                                  {
                                    case 0:
                                      break;
                                    default:
                                      continue;
                                  }
                                  break;
                                case 2:
                                  enumerator4.Dispose();
                                  num13 = (short) 0;
                                  num1 = (int) (IntPtr) num13;
                                  continue;
                              }
                              if (enumerator4 != null)
                              {
                                num13 = (short) 2;
                                num1 = (int) (IntPtr) num13;
                              }
                              else
                                break;
                            }
label_382:;
                          }
label_315:
                          xmlTextWriter.WriteEndElement();
                          xmlTextWriter.WriteEndElement();
                          ++num5;
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 36:
                          if (!current2.EmbeddedRecset.HiddenStatic)
                          {
                            num2 = (short) 16 /*0x10*/;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          break;
                        case 37:
                          if (flag4 | flag5 | flag6 | flag7)
                          {
                            num2 = (short) 31 /*0x1F*/;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto default;
                        case 38:
                          num2 = (short) 33;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        default:
label_197:
                          num2 = (short) 29;
                          num1 = (int) (IntPtr) num2;
                          continue;
                      }
                      enumerator5 = current2.FieldsCollection.GetEnumerator();
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    num1 = 1;
                    while (true)
                    {
                      short num14;
                      switch (num1)
                      {
                        case 0:
                          goto label_392;
                        case 1:
                          switch (0)
                          {
                            case 0:
                              break;
                            default:
                              continue;
                          }
                          break;
                        case 2:
label_389:
                          enumerator2.Dispose();
                          num14 = (short) 3355;
                          int num15 = (int) num14;
                          num14 = (short) 3355;
                          int num16 = (int) num14;
                          switch (num15 == num16 ? 1 : 0)
                          {
                            case 0:
                            case 2:
                              goto label_389;
                            default:
                              num14 = (short) 0;
                              if (num14 == (short) 0)
                                ;
                              num14 = (short) 0;
                              num1 = (int) (IntPtr) num14;
                              continue;
                          }
                      }
                      if (enumerator2 != null)
                      {
                        num14 = (short) 2;
                        num1 = (int) (IntPtr) num14;
                      }
                      else
                        break;
                    }
label_392:;
                  }
label_42:
                  xmlTextWriter.WriteEndElement();
                  ++num3;
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 5:
                  xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uF490\uF292\uE194\uE296\uEB98ﺚ", A_1));
                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("즎\uDF90\uF292\uF894\uF296", A_1), feature.UIName);
                  xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("첎ﺐ\uE692ﮔ\uE396", A_1), feature.Count.ToString());
                  num3 = 0;
                  num2 = (short) 1;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 6:
                  flag1 = false;
                  flag2 = flag1;
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 7:
                  goto label_404;
                case 8:
                  goto label_402;
                case 9:
                  xmlTextWriter.WriteEndElement();
                  num2 = (short) 12;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 10:
                  if (num3 < feature.Count)
                  {
                    A_0 = feature[num3];
                    Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uE68Eﾐ\uF792\uF094\uEF96ꎘ\uE09A궜\uE29E", A_1), (object) num3.ToString()));
                    xmlTextWriter.WriteStartElement(RptMgrErrorHandler.b("욎ﾐ\uE092\uE194\uF696\uF798\uF89A\uF89C", A_1));
                    xmlTextWriter.WriteAttributeString(RptMgrErrorHandler.b("욎\uD890힒", A_1), num3.ToString());
                    enumerator2 = A_0.FeatureSectionsCollection.GetEnumerator();
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  num2 = (short) 9;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 11:
                  try
                  {
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    while (true)
                    {
                      IAcpRecordset current13;
                      switch (num1)
                      {
                        case 0:
                        case 1:
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                          goto label_18;
                        case 3:
                          if (current13.UIName == current1.Content.ToString())
                          {
                            num2 = (short) 5;
                            num1 = (int) (IntPtr) num2;
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
                          Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uDD8E\uF490\uF092杖\uE596ﶘ햚ﲜ\uF29E쒠馢\uDEA4鞦풨", A_1), (object) current13.UIName));
                          flag3 = true;
                          num4 = current13.RecsetId;
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (!enumerator3.MoveNext())
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          current13 = enumerator3.Current;
                          num2 = (short) 3;
                          num1 = (int) (IntPtr) num2;
                          continue;
                      }
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                    }
                  }
                  finally
                  {
                    num1 = 2;
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          goto label_38;
                        case 1:
                          enumerator3.Dispose();
                          num1 = 0;
                          continue;
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
                        num1 = 1;
                      else
                        break;
                    }
label_38:;
                  }
label_18:
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  switch (0)
                  {
                    case 0:
                      break;
                    default:
                      continue;
                  }
                  break;
                case 15:
                  if (!enumerator1.MoveNext())
                  {
                    num2 = (short) 3;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  current1 = (System.Windows.Controls.ListViewItem) enumerator1.Current;
                  Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uE18E\uF090ﺒ\uF094궖릘\uE09A궜\uE29E", A_1), current1.Content));
                  num4 = 0;
                  flag3 = false;
                  enumerator3 = FeatureManager.Features.GetEnumerator();
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
              num2 = (short) 15;
              num1 = (int) (IntPtr) num2;
            }
          }
          finally
          {
            IDisposable disposable;
            short num17;
            switch (0)
            {
              case 0:
label_397:
                disposable = enumerator1 as IDisposable;
                num17 = (short) 1;
                num1 = (int) (IntPtr) num17;
                goto default;
              default:
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      goto label_401;
                    case 1:
                      if (disposable != null)
                      {
                        num17 = (short) 2;
                        num1 = (int) (IntPtr) num17;
                        continue;
                      }
                      goto label_401;
                    case 2:
                      disposable.Dispose();
                      num17 = (short) 0;
                      num1 = (int) (IntPtr) num17;
                      continue;
                    default:
                      goto label_397;
                  }
                }
label_401:;
            }
          }
label_402:
          xmlTextWriter.WriteEndElement();
          xmlTextWriter.Close();
        }
        catch (Exception ex)
        {
          int num18 = (int) System.Windows.MessageBox.Show(ex.Message);
          flag1 = false;
        }
        if (false)
          ;
        return flag1;
label_404:
        return flag2;
    }
  }

  public Window ParenWnd
  {
    set
    {
      short num1 = 0;
      num1 = (short) 1732;
      int num2 = (int) num1;
      num1 = (short) 1732;
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
          this.b = value;
          break;
        default:
          goto case 1;
      }
    }
  }

  internal bool BuildTemplateFileXMLData(string fileName)
  {
    int A_1_1 = 7;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 0;
        bool flag1;
        switch (0)
        {
          case 0:
label_4:
            num2 = (short) 12672;
            int num3 = (int) num2;
            num2 = (short) 12672;
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
                flag1 = true;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                goto label_2;
            }
            break;
          default:
            while (true)
            {
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              switch (num1)
              {
                case 0:
                  if (this.a(PageCustomPrintSelection.fileAction.edit, ref fileName))
                  {
                    num2 = (short) 2;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_9;
                case 1:
                  goto label_60;
                case 2:
                  goto label_11;
                default:
                  goto label_4;
              }
label_2:;
            }
label_9:
            flag1 = false;
            break;
label_11:
            bool flag2;
            try
            {
              ReportsSerializeItems reportsSerializeItems1;
              int num5;
              switch (0)
              {
                case 0:
label_13:
                  FileStream fileStream = new FileStream(fileName.ToString(), FileMode.Open, FileAccess.Read);
                  BinaryFormatter binaryFormatter = new BinaryFormatter();
                  ReportsSerializeItems reportsSerializeItems2 = new ReportsSerializeItems();
                  FileStream serializationStream = fileStream;
                  reportsSerializeItems1 = (ReportsSerializeItems) binaryFormatter.Deserialize((Stream) serializationStream);
                  fileStream.Close();
                  num5 = 0;
                  num2 = (short) 0;
                  num1 = (int) (IntPtr) num2;
                  goto default;
                default:
                  while (true)
                  {
                    List<int> intList;
                    IAcpField iacpField;
                    Dictionary<string, int>.KeyCollection.Enumerator enumerator1;
                    List<int> lstSectionItemsId;
                    List<string> lstFieldName;
                    switch (num1)
                    {
                      case 0:
                        if (reportsSerializeItems1.sField.Count > 0)
                        {
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        }
                        break;
                      case 1:
                        goto label_60;
                      case 2:
                        intList = new List<int>();
                        lstSectionItemsId = new List<int>();
                        lstFieldName = new List<string>();
                        iacpField = (IAcpField) null;
                        enumerator1 = reportsSerializeItems1.sField.Keys.GetEnumerator();
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 3:
                        try
                        {
                          num2 = (short) 7;
                          int num6 = (int) (IntPtr) num2;
                          while (true)
                          {
                            IAcpFeatureSection parent1;
                            string current;
                            IAcpRecordset feature;
                            switch (num6)
                            {
                              case 0:
                                if (!lstSectionItemsId.Contains(parent1.FeatureSectionId))
                                {
                                  num2 = (short) 25;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                goto case 8;
                              case 1:
                                if (System.Windows.MessageBox.Show(AppResources.Template_Not_Supported, AppResources.Print_Preview, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                                {
                                  num2 = (short) 16 /*0x10*/;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                break;
                              case 2:
                                num2 = (short) 10;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 3:
                                iacpField = feature.FieldFromFavoritePath(current, RptMgrErrorHandler.b("횉", A_1_1));
                                num2 = (short) 23;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 4:
                                if (!enumerator1.MoveNext())
                                {
                                  num2 = (short) 9;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                current = enumerator1.Current;
                                reportsSerializeItems1.sField.TryGetValue(current, out num5);
                                feature = FeatureManager.GetFeature(num5);
                                num2 = (short) 12;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 5:
                                parent1 = iacpField.Parent;
                                IAcpFeatureNode parent2 = parent1.Parent;
                                IAcpRecordset parentRecset = parent1.ParentRecset;
                                num2 = (short) 21;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 6:
                                goto label_57;
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
                                num2 = (short) 22;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 9:
                                num2 = (short) 6;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 10:
                                if (Global.printTemplateVersion != 0)
                                {
                                  num2 = (short) 18;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                num2 = (short) 3;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 11:
                              case 23:
                                num2 = (short) 13;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 12:
                                if (feature != null)
                                {
                                  num2 = (short) 2;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                break;
                              case 13:
                                if (iacpField != null)
                                {
                                  num2 = (short) 5;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                num2 = (short) 1;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 14:
                                num2 = (short) 0;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 15:
                                intList.Add(num5);
                                num2 = (short) 14;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 16 /*0x10*/:
                                flag1 = false;
                                flag2 = flag1;
                                num2 = (short) 20;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 17:
                                lstFieldName.Add(iacpField.Name);
                                num2 = (short) 24;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 18:
                                if (Global.printTemplateVersion == 1)
                                {
                                  num2 = (short) 19;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                goto case 11;
                              case 19:
                                iacpField = feature.FieldFromFavoritePath(current, RptMgrErrorHandler.b("ㆉ", A_1_1));
                                num2 = (short) 11;
                                num6 = (int) (IntPtr) num2;
                                continue;
                              case 20:
                                goto label_61;
                              case 21:
                                if (!intList.Contains(num5))
                                {
                                  num2 = (short) 15;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                goto case 14;
                              case 22:
                                if (!lstFieldName.Contains(iacpField.Name))
                                {
                                  num2 = (short) 17;
                                  num6 = (int) (IntPtr) num2;
                                  continue;
                                }
                                break;
                              case 25:
                                lstSectionItemsId.Add(parent1.FeatureSectionId);
                                num2 = (short) 8;
                                num6 = (int) (IntPtr) num2;
                                continue;
                            }
                            num2 = (short) 4;
                            num6 = (int) (IntPtr) num2;
                          }
                        }
                        finally
                        {
                          enumerator1.Dispose();
                        }
label_57:
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      case 4:
                        try
                        {
                          XmlTextWriter tWriter = new XmlTextWriter(Global.XMLFileName, (Encoding) null);
                          tWriter.Formatting = Formatting.Indented;
                          tWriter.Indentation = 3;
                          tWriter.WriteStartDocument();
                          tWriter.WriteStartElement(RptMgrErrorHandler.b("캉\uED8B揄\uF18F", A_1_1));
                          intList.ForEach((Action<int>) (featureID =>
                          {
                            int A_1_2 = 12;
                            int num7 = 0;
                            switch (num7)
                            {
                              default:
                                IAcpRecordset feature;
                                short num8;
                                switch (0)
                                {
                                  case 0:
label_3:
                                    feature = FeatureManager.GetFeature(featureID);
                                    num8 = (short) 4;
                                    num7 = (int) (IntPtr) num8;
                                    goto default;
                                  default:
                                    int num9;
                                    IAcpFeatureNode A_0;
                                    IEnumerator<IAcpFeatureSection> enumerator2;
                                    while (true)
                                    {
                                      switch (num7)
                                      {
                                        case 0:
                                          goto label_412;
                                        case 1:
                                        case 2:
                                          num8 = (short) 0;
                                          num8 = (short) 3;
                                          num7 = (int) (IntPtr) num8;
                                          continue;
                                        case 3:
                                          if (num9 < feature.Count)
                                          {
                                            A_0 = feature[num9];
                                            Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uE68Eﾐ\uF792\uF094\uEF96ꎘ\uE09A궜\uE29E", A_1_2), (object) num9.ToString()));
                                            tWriter.WriteStartElement(RptMgrErrorHandler.b("욎ﾐ\uE092\uE194\uF696\uF798\uF89A\uF89C", A_1_2));
                                            tWriter.WriteAttributeString(RptMgrErrorHandler.b("욎\uD890힒", A_1_2), num9.ToString());
                                            enumerator2 = A_0.FeatureSectionsCollection.GetEnumerator();
                                            num8 = (short) 5;
                                            num7 = (int) (IntPtr) num8;
                                            continue;
                                          }
                                          num8 = (short) 7;
                                          num7 = (int) (IntPtr) num8;
                                          continue;
                                        case 4:
                                          num8 = (short) 1;
                                          if (num8 == (short) 0)
                                            ;
                                          if (feature != null)
                                          {
                                            num8 = (short) 6;
                                            num7 = (int) (IntPtr) num8;
                                            continue;
                                          }
                                          goto label_414;
                                        case 5:
                                          try
                                          {
                                            num8 = (short) 12;
                                            int num10 = (int) (IntPtr) num8;
                                            while (true)
                                            {
                                              IAcpFeatureSection current1;
                                              IEnumerator<IAcpField> enumerator3;
                                              int num11;
                                              bool flag3;
                                              bool flag4;
                                              int num12;
                                              bool flag5;
                                              IEnumerator<IAcpFeatureSection> enumerator4;
                                              bool flag6;
                                              bool flag7;
                                              int num13;
                                              switch (num10)
                                              {
                                                case 0:
                                                  num8 = (short) 19;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 1:
                                                  if (!enumerator2.MoveNext())
                                                  {
                                                    num8 = (short) 0;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  current1 = enumerator2.Current;
                                                  flag7 = false;
                                                  num8 = (short) 9;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 2:
                                                  num8 = (short) 21;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 3:
                                                  enumerator3 = current1.FieldsCollection.GetEnumerator();
                                                  num8 = (short) 31 /*0x1F*/;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 4:
                                                  num8 = (short) 27;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 5:
                                                  if (!current1.HasVisibleObjects)
                                                  {
                                                    num8 = (short) 44;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  num8 = (short) 2;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 6:
                                                  if (current1.EmbeddedRecset.Count > 0)
                                                  {
                                                    num8 = (short) 29;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto label_397;
                                                case 7:
                                                case 17:
                                                  num8 = (short) 30;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 8:
                                                  num8 = (short) 6;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 9:
                                                  if (current1.HasEmbeddedRecset)
                                                  {
                                                    num8 = (short) 8;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto label_397;
                                                case 10:
                                                case 14:
                                                  num8 = (short) 39;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 11:
                                                  if (!(flag5 | flag6))
                                                  {
                                                    enumerator4 = A_0.FeatureSectionsCollection.GetEnumerator();
                                                    num8 = (short) 37;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  num8 = (short) 36;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 12:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      goto label_59;
                                                    default:
                                                      continue;
                                                  }
                                                case 13:
                                                  num8 = (short) 38;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 15:
                                                  try
                                                  {
                                                    num8 = (short) 2;
                                                    int num14 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpField current2;
                                                      switch (num14)
                                                      {
                                                        case 0:
                                                          if (!((AcpFieldBase) current2).HiddenDynamic)
                                                          {
                                                            num8 = (short) 10;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 1:
                                                          num8 = (short) 3;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 2:
                                                          switch (0)
                                                          {
                                                            case 0:
                                                              break;
                                                            default:
                                                              continue;
                                                          }
                                                          break;
                                                        case 3:
                                                        case 12:
                                                          goto label_55;
                                                        case 4:
                                                          if (current2 != null)
                                                          {
                                                            num8 = (short) 11;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 5:
                                                          flag3 = true;
                                                          num8 = (short) 12;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 6:
                                                          if (!((AcpFieldBase) current2).HiddenStatic)
                                                          {
                                                            num8 = (short) 14;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 7:
                                                          num8 = (short) 13;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 8:
                                                          if (enumerator3.MoveNext())
                                                          {
                                                            current2 = enumerator3.Current;
                                                            num8 = (short) 4;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          num8 = (short) 1;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 9:
                                                          if (((AcpFieldBase) current2).Visible)
                                                          {
                                                            num8 = (short) 7;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 10:
                                                          num8 = (short) 9;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 11:
                                                          num8 = (short) 6;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 13:
                                                          if (lstFieldName.Contains(current2.Name))
                                                          {
                                                            num8 = (short) 5;
                                                            num14 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 14:
                                                          num8 = (short) 0;
                                                          num14 = (int) (IntPtr) num8;
                                                          continue;
                                                      }
                                                      num8 = (short) 8;
                                                      num14 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num15 = 2;
                                                    while (true)
                                                    {
                                                      short num16;
                                                      switch (num15)
                                                      {
                                                        case 0:
                                                          enumerator3.Dispose();
                                                          num16 = (short) 1;
                                                          num15 = (int) (IntPtr) num16;
                                                          continue;
                                                        case 1:
                                                          goto label_145;
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
                                                        num16 = (short) 0;
                                                        num15 = (int) (IntPtr) num16;
                                                      }
                                                      else
                                                        break;
                                                    }
label_145:;
                                                  }
                                                case 16 /*0x10*/:
                                                  num8 = (short) 40;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 18:
                                                  num8 = (short) 34;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 19:
                                                  goto label_7;
                                                case 20:
                                                  if (current1.HasEmbeddedRecset)
                                                  {
                                                    num8 = (short) 4;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  break;
                                                case 21:
                                                  num13 = lstSectionItemsId.Contains(current1.FeatureSectionId) ? 1 : 0;
                                                  goto label_389;
                                                case 22:
                                                  if (!this.a(current1))
                                                  {
                                                    num8 = (short) 26;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto case 18;
                                                case 23:
                                                  if (num11 >= current1.EmbeddedRecset.Count)
                                                  {
                                                    num8 = (short) 16 /*0x10*/;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  tWriter.WriteStartElement(RptMgrErrorHandler.b("쪎ﲐ\uF192\uDC94練\uEA98\uEF9Aﲜ\uF19E슠욢", A_1_2));
                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192\uDC94\uDE96\uDD98", A_1_2), num11.ToString());
                                                  IAcpFeatureNode iacpFeatureNode = current1.EmbeddedRecset[num11];
                                                  tWriter.WriteStartElement(RptMgrErrorHandler.b("쪎ﲐ\uF192요\uF296滛\uEF9A\uF49C\uF09E쾠", A_1_2));
                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192펔쒖ﲘ\uF89A\uE99C\uF69E캠춢", A_1_2), iacpFeatureNode.UIName);
                                                  enumerator4 = iacpFeatureNode.FeatureSectionsCollection.GetEnumerator();
                                                  num8 = (short) 43;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 25:
                                                  try
                                                  {
                                                    num8 = (short) 0;
                                                    int num17 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpFeatureSection current3;
                                                      switch (num17)
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
                                                          num8 = (short) 7;
                                                          num17 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 2:
                                                        case 7:
                                                          goto label_62;
                                                        case 3:
                                                          if (enumerator4.MoveNext())
                                                          {
                                                            current3 = enumerator4.Current;
                                                            num8 = (short) 6;
                                                            num17 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          num8 = (short) 4;
                                                          num17 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 4:
                                                          num8 = (short) 2;
                                                          num17 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 5:
                                                          try
                                                          {
                                                            num8 = (short) 14;
                                                            int num18 = (int) (IntPtr) num8;
                                                            while (true)
                                                            {
                                                              IAcpField current4;
                                                              switch (num18)
                                                              {
                                                                case 0:
                                                                case 2:
                                                                  goto label_286;
                                                                case 1:
                                                                  num8 = (short) 13;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 3:
                                                                  if (!((AcpFieldBase) current4).HiddenStatic)
                                                                  {
                                                                    num8 = (short) 1;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 4:
                                                                  if (((AcpFieldBase) current4).Visible)
                                                                  {
                                                                    num8 = (short) 5;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 5:
                                                                  num8 = (short) 11;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 6:
                                                                  num8 = (short) 2;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 7:
                                                                  num8 = (short) 4;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 8:
                                                                  num8 = (short) 3;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 9:
                                                                  flag6 = true;
                                                                  num8 = (short) 0;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 10:
                                                                  if (!enumerator3.MoveNext())
                                                                  {
                                                                    num8 = (short) 6;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  current4 = enumerator3.Current;
                                                                  num8 = (short) 12;
                                                                  num18 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 11:
                                                                  if (lstFieldName.Contains(current4.Name))
                                                                  {
                                                                    num8 = (short) 9;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 12:
                                                                  if (current4 != null)
                                                                  {
                                                                    num8 = (short) 8;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 13:
                                                                  if (!((AcpFieldBase) current4).HiddenDynamic)
                                                                  {
                                                                    num8 = (short) 7;
                                                                    num18 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 14:
                                                                  switch (0)
                                                                  {
                                                                    case 0:
                                                                      break;
                                                                    default:
                                                                      continue;
                                                                  }
                                                                  break;
                                                              }
                                                              num8 = (short) 10;
                                                              num18 = (int) (IntPtr) num8;
                                                            }
                                                          }
                                                          finally
                                                          {
                                                            int num19 = 2;
                                                            while (true)
                                                            {
                                                              short num20;
                                                              switch (num19)
                                                              {
                                                                case 0:
                                                                  goto label_318;
                                                                case 1:
                                                                  enumerator3.Dispose();
                                                                  num20 = (short) 0;
                                                                  num19 = (int) (IntPtr) num20;
                                                                  continue;
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
                                                                num20 = (short) 1;
                                                                num19 = (int) (IntPtr) num20;
                                                              }
                                                              else
                                                                break;
                                                            }
label_318:;
                                                          }
                                                        case 6:
                                                          if (flag6)
                                                          {
                                                            num8 = (short) 1;
                                                            num17 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          enumerator3 = current3.FieldsCollection.GetEnumerator();
                                                          num8 = (short) 5;
                                                          num17 = (int) (IntPtr) num8;
                                                          continue;
                                                      }
label_286:
                                                      num8 = (short) 3;
                                                      num17 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num21 = 2;
                                                    while (true)
                                                    {
                                                      switch (num21)
                                                      {
                                                        case 0:
                                                          goto label_328;
                                                        case 1:
                                                          enumerator4.Dispose();
                                                          num21 = 0;
                                                          continue;
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
                                                        num21 = 1;
                                                      else
                                                        break;
                                                    }
label_328:;
                                                  }
label_62:
                                                  ++num12;
                                                  num8 = (short) 10;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 26:
                                                  flag3 = false;
                                                  num8 = (short) 18;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 27:
                                                  if (!current1.EmbeddedRecset.HiddenStatic)
                                                  {
                                                    num8 = (short) 3;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  break;
                                                case 28:
                                                  try
                                                  {
                                                    num8 = (short) 0;
                                                    int num22 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpFeatureSection current5;
                                                      switch (num22)
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
                                                        case 6:
                                                          goto label_397;
                                                        case 2:
                                                          num8 = (short) 6;
                                                          num22 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 3:
label_152:
                                                          flag7 = true;
                                                          num8 = (short) 8074;
                                                          int num23 = (int) num8;
                                                          num8 = (short) 8074;
                                                          int num24 = (int) num8;
                                                          switch (num23 == num24 ? 1 : 0)
                                                          {
                                                            case 0:
                                                            case 2:
                                                              goto label_152;
                                                            default:
                                                              num8 = (short) 0;
                                                              if (num8 == (short) 0)
                                                                ;
                                                              num8 = (short) 1;
                                                              num22 = (int) (IntPtr) num8;
                                                              continue;
                                                          }
                                                        case 4:
                                                          if (lstSectionItemsId.Contains(current5.FeatureSectionId))
                                                          {
                                                            num8 = (short) 3;
                                                            num22 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 5:
                                                          if (enumerator4.MoveNext())
                                                          {
                                                            current5 = enumerator4.Current;
                                                            num8 = (short) 8;
                                                            num22 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          num8 = (short) 2;
                                                          num22 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 7:
                                                          num8 = (short) 4;
                                                          num22 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 8:
                                                          if (current5.HasVisibleObjects)
                                                          {
                                                            num8 = (short) 7;
                                                            num22 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                      }
                                                      num8 = (short) 5;
                                                      num22 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num25 = 1;
                                                    while (true)
                                                    {
                                                      short num26;
                                                      switch (num25)
                                                      {
                                                        case 0:
                                                          goto label_168;
                                                        case 1:
                                                          switch (0)
                                                          {
                                                            case 0:
                                                              break;
                                                            default:
                                                              continue;
                                                          }
                                                          break;
                                                        case 2:
                                                          enumerator4.Dispose();
                                                          num26 = (short) 0;
                                                          num25 = (int) (IntPtr) num26;
                                                          continue;
                                                      }
                                                      if (enumerator4 != null)
                                                      {
                                                        num26 = (short) 2;
                                                        num25 = (int) (IntPtr) num26;
                                                      }
                                                      else
                                                        break;
                                                    }
label_168:;
                                                  }
                                                case 29:
                                                  num8 = (short) 33;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 30:
                                                  if (flag6)
                                                  {
                                                    num8 = (short) 41;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto case 40;
                                                case 31 /*0x1F*/:
                                                  try
                                                  {
                                                    num8 = (short) 2;
                                                    int num27 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpField current6;
                                                      switch (num27)
                                                      {
                                                        case 0:
                                                          if (lstFieldName.Contains(current6.Name))
                                                          {
                                                            num8 = (short) 10;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 1:
                                                          num8 = (short) 9;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 2:
                                                          switch (0)
                                                          {
                                                            case 0:
                                                              break;
                                                            default:
                                                              continue;
                                                          }
                                                          break;
                                                        case 3:
                                                        case 6:
                                                          goto label_169;
                                                        case 4:
                                                          if (!((AcpFieldBase) current6).HiddenDynamic)
                                                          {
                                                            num8 = (short) 11;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 5:
                                                          num8 = (short) 0;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 7:
                                                          num8 = (short) 4;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 8:
                                                          if (current6 != null)
                                                          {
                                                            num8 = (short) 1;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 9:
                                                          if (!((AcpFieldBase) current6).HiddenStatic)
                                                          {
                                                            num8 = (short) 7;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 10:
                                                          flag5 = true;
                                                          num8 = (short) 6;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 11:
                                                          num8 = (short) 13;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 12:
                                                          num8 = (short) 3;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 13:
                                                          if (((AcpFieldBase) current6).Visible)
                                                          {
                                                            num8 = (short) 5;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 14:
                                                          if (!enumerator3.MoveNext())
                                                          {
                                                            num8 = (short) 12;
                                                            num27 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          current6 = enumerator3.Current;
                                                          num8 = (short) 8;
                                                          num27 = (int) (IntPtr) num8;
                                                          continue;
                                                      }
                                                      num8 = (short) 14;
                                                      num27 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num28 = 2;
                                                    while (true)
                                                    {
                                                      short num29;
                                                      switch (num28)
                                                      {
                                                        case 0:
                                                          enumerator3.Dispose();
                                                          num29 = (short) 1;
                                                          num28 = (int) (IntPtr) num29;
                                                          continue;
                                                        case 1:
                                                          goto label_96;
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
                                                        num29 = (short) 0;
                                                        num28 = (int) (IntPtr) num29;
                                                      }
                                                      else
                                                        break;
                                                    }
label_96:;
                                                  }
label_169:
                                                  num12 = 0;
                                                  num8 = (short) 14;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 32 /*0x20*/:
                                                  enumerator4 = current1.EmbeddedRecset[0].FeatureSectionsCollection.GetEnumerator();
                                                  num8 = (short) 28;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 33:
                                                  if (!current1.EmbeddedRecset.HiddenStatic)
                                                  {
                                                    num8 = (short) 32 /*0x20*/;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto label_397;
                                                case 34:
                                                  if (flag3 | flag5 | flag6 | flag4)
                                                  {
                                                    num8 = (short) 45;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  goto default;
                                                case 35:
                                                  num8 = (short) 20;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 36:
                                                  Trace.WriteLine(string.Format(RptMgrErrorHandler.b("쪎ﲐ\uF192\uF094\uF396ﶘﺚ列톞삠캢삤鶦튨鮪킬", A_1_2), (object) current1.EmbeddedRecset.UIName));
                                                  enumerator3 = current1.FieldsCollection.GetEnumerator();
                                                  num8 = (short) 42;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 37:
                                                  try
                                                  {
                                                    num8 = (short) 3;
                                                    int num30 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpFeatureSection current7;
                                                      switch (num30)
                                                      {
                                                        case 0:
                                                          goto label_58;
                                                        case 1:
                                                          num8 = (short) 0;
                                                          num30 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 2:
                                                          try
                                                          {
                                                            num8 = (short) 17;
                                                            int num31 = (int) (IntPtr) num8;
                                                            while (true)
                                                            {
                                                              IAcpField current8;
                                                              IEnumerator<AcpBusinessLayer.ListItem> enumerator5;
                                                              switch (num31)
                                                              {
                                                                case 0:
                                                                  num8 = (short) 27;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 1:
                                                                  if (!((AcpFieldBase) current8).HiddenStatic)
                                                                  {
                                                                    num8 = (short) 0;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 2:
                                                                  if (current8 is AcpListField)
                                                                  {
                                                                    num8 = (short) 24;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 4:
                                                                  num8 = (short) 37;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 5:
                                                                  try
                                                                  {
                                                                    num8 = (short) 0;
                                                                    int num32 = (int) (IntPtr) num8;
                                                                    while (true)
                                                                    {
                                                                      AcpBusinessLayer.ListItem current9;
                                                                      switch (num32)
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
                                                                          if (!enumerator5.MoveNext())
                                                                          {
                                                                            num8 = (short) 3;
                                                                            num32 = (int) (IntPtr) num8;
                                                                            continue;
                                                                          }
                                                                          current9 = enumerator5.Current;
                                                                          num8 = (short) 7;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                        case 3:
                                                                          num8 = (short) 6;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                        case 4:
                                                                        case 8:
                                                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), current9.ItemName.ToString());
                                                                          tWriter.WriteEndElement();
                                                                          num8 = (short) 2;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                        case 5:
                                                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current8.NewUIName);
                                                                          num8 = (short) 8;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                        case 6:
                                                                          goto label_249;
                                                                        case 7:
                                                                          if (current9.ItemVisibility)
                                                                          {
                                                                            num8 = (short) 10;
                                                                            num32 = (int) (IntPtr) num8;
                                                                            continue;
                                                                          }
                                                                          break;
                                                                        case 9:
                                                                          if (!string.IsNullOrEmpty(current8.NewUIName))
                                                                          {
                                                                            num8 = (short) 5;
                                                                            num32 = (int) (IntPtr) num8;
                                                                            continue;
                                                                          }
                                                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current8.UIName);
                                                                          num8 = (short) 4;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                        case 10:
                                                                          tWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uDD90햒ﲔ\uF296\uF598ﾚ", A_1_2));
                                                                          num8 = (short) 9;
                                                                          num32 = (int) (IntPtr) num8;
                                                                          continue;
                                                                      }
                                                                      num8 = (short) 1;
                                                                      num32 = (int) (IntPtr) num8;
                                                                    }
                                                                  }
                                                                  finally
                                                                  {
                                                                    short num33 = 1;
                                                                    int num34 = (int) (IntPtr) num33;
                                                                    while (true)
                                                                    {
                                                                      switch (num34)
                                                                      {
                                                                        case 0:
                                                                          goto label_241;
                                                                        case 1:
                                                                          switch (0)
                                                                          {
                                                                            case 0:
                                                                              break;
                                                                            default:
                                                                              continue;
                                                                          }
                                                                          break;
                                                                        case 2:
                                                                          enumerator5.Dispose();
                                                                          num33 = (short) 0;
                                                                          num34 = (int) (IntPtr) num33;
                                                                          continue;
                                                                      }
                                                                      if (enumerator5 != null)
                                                                      {
                                                                        num33 = (short) 2;
                                                                        num34 = (int) (IntPtr) num33;
                                                                      }
                                                                      else
                                                                        break;
                                                                    }
label_241:;
                                                                  }
                                                                case 6:
                                                                  num8 = (short) 40;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 7:
                                                                  enumerator5 = ((AcpListField) current8).Items.GetEnumerator();
                                                                  num8 = (short) 5;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 8:
                                                                  num8 = (short) 21;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 9:
                                                                  if (!enumerator3.MoveNext())
                                                                  {
                                                                    num8 = (short) 6;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  current8 = enumerator3.Current;
                                                                  num8 = (short) 23;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 10:
                                                                case 26:
label_249:
                                                                  tWriter.WriteEndElement();
                                                                  num8 = (short) 3;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 11:
                                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), AcpXMLCoreEngLib.convertToArabicFormat(current8.ToString()));
                                                                  num8 = (short) 26;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 12:
                                                                  num8 = (short) 13;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 13:
                                                                  if (current8.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C쮞펠횢쮤첦삨얪쪬\uEEAE잰튲\uDCB4\uDBB6\uD8B8\uD9BA톼\uDABE賀ꛂꯄ닆胈뿊\uA8CCꋎꋐ賒铔\uE5D6\uEBD8\uEDDA\uEBDC\uE8DE", A_1_2))
                                                                  {
                                                                    num8 = (short) 7;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 14:
                                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current8.NewUIName);
                                                                  num8 = (short) 19;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 15:
                                                                  num8 = (short) 34;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 16 /*0x10*/:
                                                                  num8 = (short) 28;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 17:
                                                                  switch (0)
                                                                  {
                                                                    case 0:
                                                                      goto label_189;
                                                                    default:
                                                                      continue;
                                                                  }
                                                                case 18:
                                                                  if (current8.NewParent != current1)
                                                                  {
                                                                    num8 = (short) 4;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto case 15;
                                                                case 19:
                                                                case 25:
                                                                  num8 = (short) 2;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 20:
                                                                  if (lstFieldName.Contains(current8.Name))
                                                                  {
                                                                    num8 = (short) 30;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 21:
                                                                  if (((AcpFieldBase) current8).Visible)
                                                                  {
                                                                    num8 = (short) 32 /*0x20*/;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 22:
                                                                  if (((AcpListField) current8).SerializeItems)
                                                                  {
                                                                    num8 = (short) 16 /*0x10*/;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 23:
                                                                  if (current8.NewParent == null)
                                                                  {
                                                                    num8 = (short) 43;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  num8 = (short) 42;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 24:
                                                                  num8 = (short) 22;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 27:
                                                                  if (!((AcpFieldBase) current8).HiddenDynamic)
                                                                  {
                                                                    num8 = (short) 8;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 28:
                                                                  if (current8.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C\uDC9E캠춢펤슦잨\uDFAA쒬삮\uDFB0튲\uD9B4\uF6B6쾸\uDABA풼펾ꃀꇂ꧄ꋆ蓈껊ꏌ뫎飐\uA7D2냔뫖\uAAD8蓚鳜\uEDDE폠헢폤퇦", A_1_2))
                                                                  {
                                                                    num8 = (short) 12;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 29:
                                                                  if (!current8.IsMasked)
                                                                  {
                                                                    num8 = (short) 36;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  num8 = (short) 38;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 30:
                                                                  num8 = (short) 31 /*0x1F*/;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 31 /*0x1F*/:
                                                                  if (!FieldFilters.FilterSpecialFieldInReport(current8))
                                                                  {
                                                                    num8 = (short) 33;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 32 /*0x20*/:
                                                                  num8 = (short) 20;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 33:
                                                                  tWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uDD90햒ﲔ\uF296\uF598ﾚ", A_1_2));
                                                                  num8 = (short) 35;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 34:
                                                                  if (current8 != null)
                                                                  {
                                                                    num8 = (short) 44;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 35:
                                                                  if (string.IsNullOrEmpty(current8.NewUIName))
                                                                  {
                                                                    tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current8.UIName);
                                                                    num8 = (short) 25;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  num8 = (short) 14;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 36:
                                                                  if (current8.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C\uDC9E캠춢펤슦잨\uDFAA쒬삮\uDFB0튲\uD9B4\uF6B6쾸\uDABA풼펾ꃀꇂ꧄ꋆ蓈껊ꏌ뫎飐\uA7D2냔뫖\uAAD8蓚鳜\uEDDE폠헢폤퇦", A_1_2))
                                                                  {
                                                                    num8 = (short) 41;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto case 10;
                                                                case 38:
                                                                  string str = "".PadLeft(current8.ToString().Length, '*');
                                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), str);
                                                                  num8 = (short) 10;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 39:
                                                                  if (current8.Name != RptMgrErrorHandler.b("쮎\uF890\uE092\uE594\uDA96ﲘ\uF59A\uE89C쮞펠횢쮤첦삨얪쪬\uEEAE잰튲\uDCB4\uDBB6\uD8B8\uD9BA톼\uDABE賀ꛂꯄ닆胈뿊\uA8CCꋎꋐ賒铔\uE5D6\uEBD8\uEDDA\uEBDC\uE8DE", A_1_2))
                                                                  {
                                                                    num8 = (short) 11;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto case 10;
                                                                case 40:
                                                                  goto label_269;
                                                                case 41:
                                                                  num8 = (short) 39;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 42:
                                                                  num8 = (short) 18;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 43:
                                                                  if (current7 == current1)
                                                                  {
                                                                    num8 = (short) 15;
                                                                    num31 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  goto default;
                                                                case 44:
                                                                  num8 = (short) 1;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                                default:
label_189:
                                                                  num8 = (short) 9;
                                                                  num31 = (int) (IntPtr) num8;
                                                                  continue;
                                                              }
                                                              num8 = (short) 29;
                                                              num31 = (int) (IntPtr) num8;
                                                            }
                                                          }
                                                          finally
                                                          {
                                                            int num35 = 1;
                                                            while (true)
                                                            {
                                                              short num36;
                                                              switch (num35)
                                                              {
                                                                case 0:
                                                                  goto label_267;
                                                                case 1:
                                                                  switch (0)
                                                                  {
                                                                    case 0:
                                                                      break;
                                                                    default:
                                                                      continue;
                                                                  }
                                                                  break;
                                                                case 2:
                                                                  enumerator3.Dispose();
                                                                  num36 = (short) 0;
                                                                  num35 = (int) (IntPtr) num36;
                                                                  continue;
                                                              }
                                                              if (enumerator3 != null)
                                                              {
                                                                num36 = (short) 2;
                                                                num35 = (int) (IntPtr) num36;
                                                              }
                                                              else
                                                                break;
                                                            }
label_267:;
                                                          }
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
                                                          if (enumerator4.MoveNext())
                                                          {
                                                            current7 = enumerator4.Current;
                                                            enumerator3 = current7.FieldsCollection.GetEnumerator();
                                                            num8 = (short) 2;
                                                            num30 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          num8 = (short) 1;
                                                          num30 = (int) (IntPtr) num8;
                                                          continue;
                                                      }
label_269:
                                                      num8 = (short) 4;
                                                      num30 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num37 = 1;
                                                    while (true)
                                                    {
                                                      short num38;
                                                      switch (num37)
                                                      {
                                                        case 0:
                                                          goto label_279;
                                                        case 1:
                                                          switch (0)
                                                          {
                                                            case 0:
                                                              break;
                                                            default:
                                                              continue;
                                                          }
                                                          break;
                                                        case 2:
                                                          enumerator4.Dispose();
                                                          num38 = (short) 0;
                                                          num37 = (int) (IntPtr) num38;
                                                          continue;
                                                      }
                                                      if (enumerator4 != null)
                                                      {
                                                        num38 = (short) 2;
                                                        num37 = (int) (IntPtr) num38;
                                                      }
                                                      else
                                                        break;
                                                    }
label_279:;
                                                  }
                                                case 38:
label_55:
                                                  flag4 = this.a(A_0, current1);
                                                  num8 = (short) 22;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 39:
                                                  if (num12 >= current1.EmbeddedRecset.Count)
                                                  {
                                                    num8 = (short) 13;
                                                    num10 = (int) (IntPtr) num8;
                                                    continue;
                                                  }
                                                  enumerator4 = current1.EmbeddedRecset[num12].FeatureSectionsCollection.GetEnumerator();
                                                  num8 = (short) 25;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 40:
label_58:
                                                  tWriter.WriteEndElement();
                                                  num8 = (short) 24;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 41:
                                                  num8 = (short) 23;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 42:
                                                  try
                                                  {
                                                    num8 = (short) 3;
                                                    int num39 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      IAcpField current10;
                                                      switch (num39)
                                                      {
                                                        case 0:
                                                          if (!((AcpFieldBase) current10).HiddenDynamic)
                                                          {
                                                            num8 = (short) 1;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 1:
                                                          num8 = (short) 14;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 2:
                                                          if (!((AcpFieldBase) current10).HiddenStatic)
                                                          {
                                                            num8 = (short) 7;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
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
                                                          num8 = (short) 16 /*0x10*/;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 5:
                                                          num8 = (short) 2;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 6:
                                                          goto label_53;
                                                        case 7:
                                                          num8 = (short) 0;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 8:
                                                          if (!FieldFilters.FilterSpecialFieldInReport(current10))
                                                          {
                                                            num8 = (short) 9;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 9:
                                                          tWriter.WriteStartElement(RptMgrErrorHandler.b("\uDB8E\uDD90햒ﲔ\uF296\uF598ﾚ", A_1_2));
                                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current10.UIName);
                                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), AcpXMLCoreEngLib.convertToArabicFormat(current10.ToString()));
                                                          tWriter.WriteEndElement();
                                                          num8 = (short) 15;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 10:
                                                          if (current10 != null)
                                                          {
                                                            num8 = (short) 5;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 11:
                                                          num8 = (short) 8;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 12:
                                                          if (!enumerator3.MoveNext())
                                                          {
                                                            num8 = (short) 13;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          current10 = enumerator3.Current;
                                                          num8 = (short) 10;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 13:
                                                          num8 = (short) 6;
                                                          num39 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 14:
                                                          if (((AcpFieldBase) current10).Visible)
                                                          {
                                                            num8 = (short) 4;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                        case 16 /*0x10*/:
                                                          if (lstFieldName.Contains(current10.Name))
                                                          {
                                                            num8 = (short) 11;
                                                            num39 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          break;
                                                      }
                                                      num8 = (short) 12;
                                                      num39 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    short num40 = 2;
                                                    int num41 = (int) (IntPtr) num40;
                                                    while (true)
                                                    {
                                                      switch (num41)
                                                      {
                                                        case 0:
                                                          enumerator3.Dispose();
                                                          num40 = (short) 1;
                                                          num41 = (int) (IntPtr) num40;
                                                          continue;
                                                        case 1:
                                                          goto label_52;
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
                                                        num40 = (short) 0;
                                                        num41 = (int) (IntPtr) num40;
                                                      }
                                                      else
                                                        break;
                                                    }
label_52:;
                                                  }
label_53:
                                                  num11 = 0;
                                                  num8 = (short) 7;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 43:
                                                  try
                                                  {
                                                    num8 = (short) 4;
                                                    int num42 = (int) (IntPtr) num8;
                                                    while (true)
                                                    {
                                                      switch (num42)
                                                      {
                                                        case 0:
                                                          if (enumerator4.MoveNext())
                                                          {
                                                            IAcpFeatureSection current11 = enumerator4.Current;
                                                            Trace.WriteLine(string.Format(RptMgrErrorHandler.b("쪎ﲐ\uF192\uF794\uF296ﶘﺚ列\uEC9E쒠삢톤캦욨얪\uE3AC캮\uDCB0횲辴첶覸욺", A_1_2), (object) current11.UIName));
                                                            enumerator3 = current11.FieldsCollection.GetEnumerator();
                                                            num8 = (short) 2;
                                                            num42 = (int) (IntPtr) num8;
                                                            continue;
                                                          }
                                                          num8 = (short) 3;
                                                          num42 = (int) (IntPtr) num8;
                                                          continue;
                                                        case 1:
                                                          goto label_388;
                                                        case 2:
                                                          try
                                                          {
                                                            num8 = (short) 20;
                                                            int num43 = (int) (IntPtr) num8;
                                                            while (true)
                                                            {
                                                              IAcpField current12;
                                                              switch (num43)
                                                              {
                                                                case 1:
                                                                  string str = "".PadLeft(current12.ToString().Length, '*');
                                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), str);
                                                                  num8 = (short) 12;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 2:
                                                                  if (!((AcpFieldBase) current12).HiddenDynamic)
                                                                  {
                                                                    num8 = (short) 17;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 3:
                                                                  num8 = (short) 2;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 4:
                                                                  goto label_336;
                                                                case 5:
                                                                  num8 = (short) 4;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 6:
                                                                  if (lstFieldName.Contains(current12.Name))
                                                                  {
                                                                    num8 = (short) 13;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 7:
                                                                  tWriter.WriteStartElement(RptMgrErrorHandler.b("\uDC8E\uDD90햒ﲔ\uF296\uF598ﾚ", A_1_2));
                                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("솎\uF090ﺒ\uF094", A_1_2), current12.UIName);
                                                                  num8 = (short) 19;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 8:
                                                                  if (((AcpFieldBase) current12).Visible)
                                                                  {
                                                                    num8 = (short) 16 /*0x10*/;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 9:
                                                                case 12:
                                                                  tWriter.WriteEndElement();
                                                                  num8 = (short) 0;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 10:
                                                                  if (enumerator3.MoveNext())
                                                                  {
                                                                    current12 = enumerator3.Current;
                                                                    num8 = (short) 15;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  num8 = (short) 5;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 11:
                                                                  if (!((AcpFieldBase) current12).HiddenStatic)
                                                                  {
                                                                    num8 = (short) 3;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 13:
                                                                  num8 = (short) 14;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 14:
                                                                  if (!FieldFilters.FilterSpecialFieldInReport(current12))
                                                                  {
                                                                    num8 = (short) 7;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 15:
                                                                  if (current12 != null)
                                                                  {
                                                                    num8 = (short) 18;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  break;
                                                                case 16 /*0x10*/:
                                                                  num8 = (short) 6;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 17:
                                                                  num8 = (short) 8;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 18:
                                                                  num8 = (short) 11;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 19:
                                                                  if (!current12.IsMasked)
                                                                  {
                                                                    tWriter.WriteAttributeString(RptMgrErrorHandler.b("\uD98E\uF090ﾒ\uE094\uF296", A_1_2), AcpXMLCoreEngLib.convertToArabicFormat(current12.ToString()));
                                                                    num8 = (short) 9;
                                                                    num43 = (int) (IntPtr) num8;
                                                                    continue;
                                                                  }
                                                                  num8 = (short) 1;
                                                                  num43 = (int) (IntPtr) num8;
                                                                  continue;
                                                                case 20:
                                                                  switch (0)
                                                                  {
                                                                    case 0:
                                                                      break;
                                                                    default:
                                                                      continue;
                                                                  }
                                                                  break;
                                                              }
                                                              num8 = (short) 10;
                                                              num43 = (int) (IntPtr) num8;
                                                            }
                                                          }
                                                          finally
                                                          {
                                                            int num44 = 1;
                                                            while (true)
                                                            {
                                                              short num45;
                                                              switch (num44)
                                                              {
                                                                case 0:
                                                                  enumerator3.Dispose();
                                                                  num45 = (short) 2;
                                                                  num44 = (int) (IntPtr) num45;
                                                                  continue;
                                                                case 1:
                                                                  switch (0)
                                                                  {
                                                                    case 0:
                                                                      break;
                                                                    default:
                                                                      continue;
                                                                  }
                                                                  break;
                                                                case 2:
                                                                  goto label_376;
                                                              }
                                                              if (enumerator3 != null)
                                                              {
                                                                num45 = (short) 0;
                                                                num44 = (int) (IntPtr) num45;
                                                              }
                                                              else
                                                                break;
                                                            }
label_376:;
                                                          }
                                                        case 3:
                                                          num8 = (short) 1;
                                                          num42 = (int) (IntPtr) num8;
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
label_336:
                                                      num8 = (short) 0;
                                                      num42 = (int) (IntPtr) num8;
                                                    }
                                                  }
                                                  finally
                                                  {
                                                    int num46 = 1;
                                                    while (true)
                                                    {
                                                      switch (num46)
                                                      {
                                                        case 0:
                                                          enumerator4.Dispose();
                                                          num46 = 2;
                                                          continue;
                                                        case 1:
                                                          switch (0)
                                                          {
                                                            case 0:
                                                              break;
                                                            default:
                                                              continue;
                                                          }
                                                          break;
                                                        case 2:
                                                          goto label_384;
                                                      }
                                                      if (enumerator4 != null)
                                                        num46 = 0;
                                                      else
                                                        break;
                                                    }
label_384:;
                                                  }
label_388:
                                                  tWriter.WriteEndElement();
                                                  tWriter.WriteEndElement();
                                                  ++num11;
                                                  num8 = (short) 17;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 44:
                                                  num13 = 0;
                                                  goto label_389;
                                                case 45:
                                                  Trace.WriteLine(string.Format(RptMgrErrorHandler.b("ﲎ\uF490\uF092\uE194ﺖ\uF698\uF59A펜ﺞ철욢龤\uDCA6馨횪", A_1_2), (object) current1.UIName));
                                                  tWriter.WriteStartElement(RptMgrErrorHandler.b("\uDC8E\uF490\uF092\uE194ﺖ\uF698\uF59A", A_1_2));
                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("즎슐\uF692\uF694\uE396\uF098\uF49A\uF39C", A_1_2), current1.UIName);
                                                  num8 = (short) 46;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                case 46:
                                                  tWriter.WriteAttributeString(RptMgrErrorHandler.b("쪎ﲐ\uF192요\uDE96\uF798\uE89A", A_1_2), current1.HasEmbeddedRecset ? RptMgrErrorHandler.b("\uDB8E", A_1_2) : RptMgrErrorHandler.b("즎", A_1_2));
                                                  num8 = (short) 11;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                                default:
label_59:
                                                  num8 = (short) 1;
                                                  num10 = (int) (IntPtr) num8;
                                                  continue;
                                              }
                                              enumerator3 = current1.FieldsCollection.GetEnumerator();
                                              num8 = (short) 15;
                                              num10 = (int) (IntPtr) num8;
                                              continue;
label_389:
                                              int num47 = flag7 ? 1 : 0;
                                              if ((num13 | num47) != 0)
                                              {
                                                num8 = (short) 35;
                                                num10 = (int) (IntPtr) num8;
                                                continue;
                                              }
                                              goto label_55;
label_397:
                                              flag3 = false;
                                              flag5 = false;
                                              flag6 = false;
                                              num8 = (short) 5;
                                              num10 = (int) (IntPtr) num8;
                                            }
                                          }
                                          finally
                                          {
                                            int num48 = 1;
                                            while (true)
                                            {
                                              short num49;
                                              switch (num48)
                                              {
                                                case 0:
                                                  enumerator2.Dispose();
                                                  num49 = (short) 2;
                                                  num48 = (int) (IntPtr) num49;
                                                  continue;
                                                case 1:
                                                  switch (0)
                                                  {
                                                    case 0:
                                                      break;
                                                    default:
                                                      continue;
                                                  }
                                                  break;
                                                case 2:
                                                  goto label_415;
                                              }
                                              if (enumerator2 != null)
                                              {
                                                num49 = (short) 0;
                                                num48 = (int) (IntPtr) num49;
                                              }
                                              else
                                                break;
                                            }
label_415:;
                                          }
label_7:
                                          tWriter.WriteEndElement();
                                          ++num9;
                                          num8 = (short) 1;
                                          num7 = (int) (IntPtr) num8;
                                          continue;
                                        case 6:
                                          tWriter.WriteStartElement(RptMgrErrorHandler.b("즎\uF490\uF292\uE194\uE296\uEB98ﺚ", A_1_2));
                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("즎\uDF90\uF292\uF894\uF296", A_1_2), feature.UIName);
                                          tWriter.WriteAttributeString(RptMgrErrorHandler.b("첎ﺐ\uE692ﮔ\uE396", A_1_2), feature.Count.ToString());
                                          num9 = 0;
                                          num8 = (short) 2;
                                          num7 = (int) (IntPtr) num8;
                                          continue;
                                        case 7:
                                          tWriter.WriteEndElement();
                                          num8 = (short) 0;
                                          num7 = (int) (IntPtr) num8;
                                          continue;
                                        default:
                                          goto label_3;
                                      }
                                    }
label_412:
                                    return;
label_414:
                                    return;
                                }
                            }
                          }));
                          tWriter.WriteEndElement();
                          tWriter.Close();
                          break;
                        }
                        catch (Exception ex)
                        {
                          int num50 = (int) System.Windows.MessageBox.Show(ex.Message);
                          flag1 = false;
                          break;
                        }
                      default:
                        goto label_13;
                    }
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                  }
              }
            }
            catch (Exception ex)
            {
              int num51 = (int) System.Windows.MessageBox.Show(ex.Message);
              flag1 = false;
              goto label_60;
            }
label_61:
            return flag2;
label_60:
            return flag1;
        }
        num2 = (short) 1;
        num1 = (int) (IntPtr) num2;
        goto label_2;
    }
  }

  internal void BuildPrintChoicesReport()
  {
    int A_1 = 18;
    int num1 = 0;
    switch (num1)
    {
      default:
        short num2 = 11683;
        switch ((short) 11683 == num2 ? 1 : 0)
        {
          case 0:
          case 2:
label_43:
            num2 = (short) 7;
            num1 = (int) (IntPtr) num2;
            break;
          default:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
        bool retVal;
        int fileCreationTime;
        Random random;
        int num3;
        ReportViewer reportViewer;
        while (true)
        {
          switch (num1)
          {
            case 0:
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              goto label_14;
            case 2:
            case 4:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 3:
              if (!File.Exists(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1)))
                break;
              goto label_43;
            case 5:
              num2 = (short) 0;
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              if (num3 >= 100)
              {
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              fileCreationTime += random.Next(12345);
              ++num3;
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 6:
              if (retVal)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_44;
            case 7:
              try
              {
                File.Delete(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1));
                break;
              }
              catch (Exception ex)
              {
                Trace.WriteLine(string.Format(RptMgrErrorHandler.b("\uEE94Ꞗ\uE498", A_1), (object) ex.Message));
                break;
              }
            default:
              goto label_5;
          }
          reportViewer = new ReportViewer(reportType.Choices, Global.XMLFileName, fileCreationTime, ref retVal);
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
label_4:;
        }
label_44:
        break;
label_14:
        try
        {
          switch (0)
          {
            case 0:
label_16:
              reportViewer.RptViewer.Focus();
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              goto default;
            default:
              while (true)
              {
                FileAttributes attributes1;
                switch (num1)
                {
                  case 0:
                    if (File.Exists(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1)))
                    {
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 1:
                    reportViewer.Owner = this.b;
                    num2 = (short) 6;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 2:
                    FileAttributes attributes2 = File.GetAttributes(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1));
                    File.SetAttributes(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1), attributes2 & ~FileAttributes.ReadOnly);
                    attributes1 = File.GetAttributes(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1));
                    num2 = (short) 5;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 3:
                    if (File.Exists(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1)))
                    {
                      num2 = (short) 10;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 8;
                  case 4:
                    num2 = (short) 0;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 5:
                    if (attributes1.ToString().Equals(RptMgrErrorHandler.b("\uDB94\uF896\uEB98\uF69Aﲜ\uF39E", A_1)))
                    {
                      num2 = (short) 9;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    break;
                  case 6:
                    reportViewer.ShowDialog();
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 7:
                    reportViewer.usrInpDia.Close();
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 8:
                    num2 = (short) 11;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 9:
                    try
                    {
                      File.Delete(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1));
                      break;
                    }
                    catch (Exception ex)
                    {
                      Console.WriteLine(RptMgrErrorHandler.b("킔\uE596\uEB98\uF49A\uEF9C뾞얠욢즤슦\uDDA8슪쎬좮", A_1) + Global.usrTempDirPath + RptMgrErrorHandler.b("솔\uE596ﲘﺚ쮜\uF69E쒠풢\uE3A4쮦욨\uDCAA\uE9AC삮튰욲\uD8B4튶ힸ쾺", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1) + ex.ToString());
                      return;
                    }
                  case 10:
                    File.SetAttributes(Global.usrTempDirPath + RptMgrErrorHandler.b("즔쎖\uEB98ﺚ\uF89C즞좠욢튤\uE1A6얨쒪\uDAAC\uEBAE\uDEB0킲살\uDAB6\uDCB8햺즼", A_1) + fileCreationTime.ToString() + RptMgrErrorHandler.b("뮔\uEF96\uE998\uE89A", A_1), FileAttributes.ReadOnly);
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  case 11:
                    if (this.b != null)
                    {
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 6;
                  case 12:
                    if (reportViewer.usrInpDia != null)
                    {
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    }
                    goto case 4;
                  case 13:
                    goto label_33;
                  default:
                    goto label_16;
                }
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
              }
label_33:
              return;
          }
        }
        catch (Exception ex)
        {
          Console.WriteLine(RptMgrErrorHandler.b("킔\uE596\uEB98\uF49A\uEF9C뾞얠욢즤슦\uDDA8슪쎬좮醰", A_1) + Global.XMLFileName + RptMgrErrorHandler.b("떔", A_1) + ex.ToString());
          break;
        }
label_5:
        retVal = false;
        fileCreationTime = 0;
        random = new Random();
        num3 = 0;
        num2 = (short) 4;
        num1 = (int) (IntPtr) num2;
        goto label_4;
    }
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 16 /*0x10*/;
    if (this.c)
    {
label_2:
      short num1 = -3101;
      int num2 = (int) num1;
      num1 = (short) -3101;
      int num3 = (int) num1;
      switch (num2 == num3 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_2;
        default:
          num1 = (short) 0;
          num1 = (short) 1;
          if (num1 == (short) 0)
            ;
          num1 = (short) 0;
          if (num1 == (short) 0)
            break;
          break;
      }
    }
    else
    {
      this.c = true;
      System.Windows.Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("벒요\uE796ﲘ\uF89A\uF49Cﺞ춠\uE5A2삤욦\uDDA8\uDEAA\uDFAC쪮슰袲횴\uD8B6풸쮺튼톾꓀귂뇄\uE8C6\uA8C8\uA8CA뷌뷎듐ꏒ뫔ꗖ귘뛚볜뇞胠蓢胤闦藨苪迬샮臰鋲鋴鋶髸軺軼课渀渂甄甆怈攊礌簎琐缒瀔琖洘爚爜焞༠嬢䐤䨦䔨", A_1), UriKind.Relative));
    }
  }

  [DebuggerNonUserCode]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    int num1 = 1;
    short num2;
    while (true)
    {
      num2 = (short) -2157;
      int num3 = (int) num2;
      num2 = (short) -2157;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
        case 2:
          goto label_24;
        default:
          num2 = (short) 0;
          if (num2 == (short) 0)
            ;
          switch (num1)
          {
            case 0:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 1:
              num2 = (short) 1;
              if (num2 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 2:
              goto label_25;
          }
          switch (connectionId)
          {
            case 1:
              goto label_12;
            case 2:
              goto label_21;
            case 3:
              goto label_10;
            case 4:
              goto label_16;
            case 5:
              goto label_19;
            case 6:
              goto label_22;
            case 7:
              goto label_15;
            case 8:
              goto label_23;
            case 9:
              goto label_9;
            case 10:
              goto label_24;
            case 11:
              goto label_8;
            case 12:
              goto label_13;
            case 13:
              goto label_17;
            case 14:
              goto label_11;
            case 15:
              goto label_14;
            case 16 /*0x10*/:
              goto label_18;
            default:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
              continue;
          }
      }
    }
label_8:
    this.btnPrtDelTpl = (System.Windows.Controls.Button) target;
    this.btnPrtDelTpl.Click += new RoutedEventHandler(this.OnDelTemplate);
    return;
label_9:
    this.btnPrtCreateTpl = (System.Windows.Controls.Button) target;
    this.btnPrtCreateTpl.Click += new RoutedEventHandler(this.OnCreateTemplate);
    return;
label_10:
    this.gReportsChoices = (Grid) target;
    return;
label_11:
    this.lblSelectionTitle = (System.Windows.Controls.Label) target;
    return;
label_12:
    ((FrameworkElement) target).Loaded += new RoutedEventHandler(this.InitializeData);
    return;
label_13:
    this.btnCancel = (System.Windows.Controls.Button) target;
    this.btnCancel.Click += new RoutedEventHandler(this.OnPrtSelCancel);
    return;
label_14:
    this.radBtnFeatures = (System.Windows.Controls.RadioButton) target;
    this.radBtnFeatures.Checked += new RoutedEventHandler(this.OnFeatureSelected);
    return;
label_15:
    this.btnPrtSelectAll = (System.Windows.Controls.Button) target;
    this.btnPrtSelectAll.Click += new RoutedEventHandler(this.OnPrtSelectAll);
    return;
label_16:
    num2 = (short) 0;
    this.lstUIValue = (System.Windows.Controls.ListView) target;
    this.lstUIValue.SelectionChanged += new SelectionChangedEventHandler(this.OnSelectExistingTemplateFile);
    return;
label_17:
    this.imgMotologo = (Image) target;
    return;
label_18:
    this.radBtnTemplates = (System.Windows.Controls.RadioButton) target;
    this.radBtnTemplates.Checked += new RoutedEventHandler(this.OnTemplateSelected);
    return;
label_19:
    this.btnPrtHelp = (System.Windows.Controls.Button) target;
    this.btnPrtHelp.Click += new RoutedEventHandler(this.OnHelp);
    return;
label_21:
    ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.OnHelp);
    ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
    return;
label_22:
    this.btnPrtPreview = (System.Windows.Controls.Button) target;
    this.btnPrtPreview.Click += new RoutedEventHandler(this.OnPrtPreview);
    return;
label_23:
    this.btnPrtUnSelectAll = (System.Windows.Controls.Button) target;
    this.btnPrtUnSelectAll.Click += new RoutedEventHandler(this.OnPrtUnSelectAll);
    return;
label_24:
    this.btnPrtEditTpl = (System.Windows.Controls.Button) target;
    this.btnPrtEditTpl.Click += new RoutedEventHandler(this.OnEditTemplate);
    return;
label_25:
    this.c = true;
  }

  private enum fileAction
  {
    display,
    edit,
    del,
  }

  public enum ItemType
  {
    Parent,
    Child,
    GrandChild,
  }
}
