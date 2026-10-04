// Decompiled with JetBrains decompiler
// Type: SpecialFeatures.POP25BatchProgrammer.POP25BatchProgrammerRadioList
// Assembly: SpecialFeatures, Version=31.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 0788BEFE-02F3-4A8C-9224-C9BE48728FCE
// Assembly location: D:\SOFTWARE\RADIOS\APX\DEPOT\serie r31\SpecialFeatures.dll

using ACPBrowser;
using AcpCommonLib;
using AcpUI.Common;
using CommonResources;
using SpecialFeatures.AcpReportManagerLib;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml.Serialization;

#nullable disable
namespace SpecialFeatures.POP25BatchProgrammer;

public partial class POP25BatchProgrammerRadioList : 
  Window,
  INotifyPropertyChanged,
  IComponentConnector
{
  private string a;
  private SpecialFeaturesSettings b;
  private XmlSerializer c;
  private POP25BatchProgrammerRadioList.RadioList d;
  private bool e;
  private bool f;
  internal POP25BatchProgrammerRadioList This;
  internal System.Windows.Controls.Label lbSchedulerList;
  internal System.Windows.Controls.TextBox txtboxRadioListFilePath;
  internal System.Windows.Controls.Button btnRadioListFilePathBrowse;
  internal System.Windows.Controls.Label lbRadioList;
  internal System.Windows.Controls.Label label1;
  internal System.Windows.Controls.DataGrid dgRadioList;
  internal System.Windows.Controls.Button btnDelete;
  internal System.Windows.Controls.Button btnDeleteAll;
  internal System.Windows.Controls.Button btnSave;
  internal System.Windows.Controls.Button btnSaveAs;
  internal System.Windows.Controls.Button btnDone;
  internal System.Windows.Controls.Button btnCancel;
  internal System.Windows.Controls.Button btnHelp;
  private bool h;

  public ObservableCollection<POP25BatchProgrammerRadioList.RadioInfo> DataSource
  {
    get
    {
      short num = -7663;
      switch ((short) -7663 == num)
      {
        case true:
          num = (short) 0;
          if (num == (short) 0)
            ;
          num = (short) 1;
          if (num == (short) 0)
            ;
          return (ObservableCollection<POP25BatchProgrammerRadioList.RadioInfo>) this.d;
        default:
          goto case 1;
      }
    }
  }

  public POP25BatchProgrammerRadioList()
  {
    int A_1 = 8;
    this.a = "";
    // ISSUE: object of a compiler-generated type is created
    this.b = new SpecialFeaturesSettings();
    this.c = new XmlSerializer(typeof (POP25BatchProgrammerRadioList.RadioList));
    this.d = new POP25BatchProgrammerRadioList.RadioList();
    // ISSUE: explicit constructor call
    base.\u002Ector();
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.txtboxRadioListFilePath.Text = this.a();
    this.a(this.a);
    this.DataContext = (object) this;
    this.DataSource.CollectionChanged += new NotifyCollectionChangedEventHandler(this.DataSource_CollectionChanged);
    if (!Thread.CurrentThread.CurrentCulture.Name.ToLower().StartsWith(RptMgrErrorHandler.b("\uEA8Aﾌ", A_1)))
      return;
    this.txtboxRadioListFilePath.FlowDirection = System.Windows.FlowDirection.LeftToRight;
    this.txtboxRadioListFilePath.TextAlignment = TextAlignment.Right;
  }

  private void btnDone_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 21259;
    int num2 = (int) num1;
    num1 = (short) 21259;
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
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private void F1HelpCommandCanExcute(object A_0, CanExecuteRoutedEventArgs A_1)
  {
    short num1 = 0;
    num1 = (short) 23039;
    int num2 = (int) num1;
    num1 = (short) 23039;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        num1 = (short) 0;
        if (num1 == (short) 0)
          ;
        num1 = (short) 1;
        if (num1 == (short) 0)
          ;
        A_1.CanExecute = true;
        break;
      default:
        goto case 1;
    }
  }

  private void btnRadioListHelp_click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 11;
    try
    {
      switch (true)
      {
        case true:
          if (true)
            ;
          Utility.CloseHelpWindowIfOpen();
          Utility.DisplayCPSHelpDITA(RptMgrErrorHandler.b("궍ꎏꖑ\uF793\uF595ﺗ蓮ꮛꢝ", A_1_1));
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

  private void btndelete_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 3;
    switch (0)
    {
      default:
        short num1 = 3;
        int num2 = (int) (IntPtr) num1;
        IEnumerator enumerator;
        while (true)
        {
          int index;
          ArrayList arrayList;
          POP25BatchProgrammerRadioList.RadioInfo radioInfo;
          switch (num2)
          {
            case 0:
              ++index;
              num1 = (short) 9;
              num2 = (int) (IntPtr) num1;
              continue;
            case 1:
              if (index >= this.dgRadioList.SelectedItems.Count)
              {
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              num1 = (short) -9935;
              int num3 = (int) num1;
              num1 = (short) -9935;
              int num4 = (int) num1;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                case 2:
                  break;
                default:
                  num1 = (short) 0;
                  if (num1 == (short) 0)
                    ;
                  radioInfo = new POP25BatchProgrammerRadioList.RadioInfo();
                  num1 = (short) 4;
                  num2 = (int) (IntPtr) num1;
                  continue;
              }
              break;
            case 2:
              enumerator = arrayList.GetEnumerator();
              num1 = (short) 6;
              num2 = (int) (IntPtr) num1;
              continue;
            case 3:
              switch (0)
              {
                case 0:
                  goto label_4;
                default:
                  continue;
              }
            case 4:
              if (this.dgRadioList.SelectedItems[index].GetType() == radioInfo.GetType())
              {
                num1 = (short) 12;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto case 0;
            case 5:
              num1 = (short) 13;
              num2 = (int) (IntPtr) num1;
              continue;
            case 6:
              goto label_6;
            case 7:
              goto label_42;
            case 8:
              num1 = (short) 1;
              if (num1 == (short) 0)
                goto case 9;
              goto case 9;
            case 9:
              num1 = (short) 1;
              num2 = (int) (IntPtr) num1;
              continue;
            case 10:
              if (System.Windows.MessageBox.Show(AppResources.Are_You_Sure_Remove_Selected_Radio_From_List, AppResources.Confirm_Deleting, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
              {
                num1 = (short) 11;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_41;
            case 11:
              arrayList = new ArrayList();
              index = 0;
              num1 = (short) 8;
              num2 = (int) (IntPtr) num1;
              continue;
            case 12:
              arrayList.Add(this.dgRadioList.SelectedItems[index]);
              num1 = (short) 0;
              num2 = (int) (IntPtr) num1;
              continue;
            case 13:
              if (this.dgRadioList.SelectedIndex != this.dgRadioList.Items.Count - 1)
              {
                num1 = (short) 14;
                num2 = (int) (IntPtr) num1;
                continue;
              }
              goto label_30;
            case 14:
              num1 = (short) 10;
              num2 = (int) (IntPtr) num1;
              continue;
            default:
label_4:
              if (this.dgRadioList.SelectedItems.Count <= 0)
                goto label_30;
              break;
          }
          num1 = (short) 5;
          num2 = (int) (IntPtr) num1;
          continue;
label_30:
          int num5 = (int) System.Windows.MessageBox.Show(AppResources.Please_Select_A_Radio_To_Deleted + RptMgrErrorHandler.b("ꚅ", A_1_1));
          num1 = (short) 7;
          num2 = (int) (IntPtr) num1;
        }
label_6:
        try
        {
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          while (true)
          {
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
              case 2:
                goto label_42;
              case 3:
                if (enumerator.MoveNext())
                {
                  this.DataSource.Remove((POP25BatchProgrammerRadioList.RadioInfo) enumerator.Current);
                  num1 = (short) 1;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                num1 = (short) 4;
                num2 = (int) (IntPtr) num1;
                continue;
              case 4:
                num1 = (short) 2;
                num2 = (int) (IntPtr) num1;
                continue;
            }
            num1 = (short) 3;
            num2 = (int) (IntPtr) num1;
          }
        }
        finally
        {
          IDisposable disposable;
          short num6;
          switch (0)
          {
            case 0:
label_16:
              disposable = enumerator as IDisposable;
              num6 = (short) 0;
              num2 = (int) (IntPtr) num6;
              goto default;
            default:
              while (true)
              {
                switch (num2)
                {
                  case 0:
                    if (disposable != null)
                    {
                      num6 = (short) 1;
                      num2 = (int) (IntPtr) num6;
                      continue;
                    }
                    goto label_20;
                  case 1:
                    disposable.Dispose();
                    num6 = (short) 2;
                    num2 = (int) (IntPtr) num6;
                    continue;
                  case 2:
                    goto label_20;
                  default:
                    goto label_16;
                }
              }
label_20:;
          }
        }
label_41:
        break;
label_42:
        break;
    }
  }

  private void btnDeleteAll_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = 25806;
    int num2 = (int) num1;
    num1 = (short) 25806;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
        num4 = (short) 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        this.DataSource.Clear();
        break;
      default:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (System.Windows.MessageBox.Show(AppResources.Are_You_Sure_Remove_All_Radios_From_List, AppResources.Confirm_Deleting, MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
          break;
        goto case 0;
    }
  }

  private void btnSave_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 9;
    int num1;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        this.a = this.txtboxRadioListFilePath.Text;
        num2 = (short) 9;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (File.Exists(this.a))
              {
                num2 = (short) 15;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 1:
              num2 = (short) 0;
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              if (File.Exists(this.a))
              {
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_49;
            case 3:
              if (!string.IsNullOrEmpty(this.a))
              {
                num2 = (short) 18;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_65;
            case 4:
              goto label_58;
            case 5:
              if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Readonly, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 6:
              if ((File.GetAttributes(this.a) & FileAttributes.Hidden) == FileAttributes.Hidden)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              break;
            case 7:
              if ((File.GetAttributes(this.a) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
              {
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_49;
            case 8:
              num2 = (short) 7;
              num1 = (int) (IntPtr) num2;
              continue;
            case 9:
              if (this.a == AppResources.Please_Select_Radio_List_Location)
              {
                num2 = (short) 19;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              num2 = (short) 3;
              num1 = (int) (IntPtr) num2;
              continue;
            case 10:
            case 17:
label_48:
              this.b.OTAP_BATCH_RADIO_LIST_LOCATION = this.txtboxRadioListFilePath.Text;
              this.b.Save();
              this.e = false;
              num2 = (short) 4;
              num1 = (int) (IntPtr) num2;
              continue;
            case 11:
              if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Hidden, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
              {
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto case 10;
            case 12:
              AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Is_Read_Only);
              num2 = (short) 17;
              num1 = (int) (IntPtr) num2;
              continue;
            case 13:
              num2 = (short) 5;
              num1 = (int) (IntPtr) num2;
              continue;
            case 14:
              try
              {
                num2 = (short) 7629;
                int num3 = (int) num2;
                num2 = (short) 7629;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
label_36:
                    if (System.Windows.MessageBox.Show(AppResources.Fix_Delete_The_Invalid_Entries_Before_Saving_The_File, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    {
                      num2 = (short) 15;
                      num1 = (int) (IntPtr) num2;
                      break;
                    }
                    goto label_41;
                  default:
                    num2 = (short) 1;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    switch (0)
                    {
                      case 0:
                        goto label_17;
                    }
                    break;
                }
                int index;
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      num2 = (short) 9;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                    case 8:
                      num2 = (short) 4;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      goto label_62;
                    case 3:
                      TextWriter textWriter = (TextWriter) new StreamWriter(this.a);
                      this.c.Serialize(textWriter, (object) this.d);
                      textWriter.Close();
                      num2 = (short) 7;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                      if (index >= this.d.Count)
                      {
                        num2 = (short) 17;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 5:
                      this.f = true;
                      num2 = (short) 14;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      if (this.d[index].Radio_ID_Valid)
                      {
                        num2 = (short) 12;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 5;
                    case 7:
                      goto label_41;
                    case 9:
                      if (!this.a.EndsWith(RptMgrErrorHandler.b("ꊋ\uF68Dﶏﺑ", A_1_1)))
                      {
                        num2 = (short) 11;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto case 3;
                    case 10:
                      goto label_36;
                    case 11:
                      this.a += RptMgrErrorHandler.b("ꊋ\uF68Dﶏﺑ", A_1_1);
                      num2 = (short) 3;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 12:
                      num2 = (short) 18;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 13:
                      if (!this.f)
                      {
                        num2 = (short) 0;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 10;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 14:
                    case 17:
                      num2 = (short) 13;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 15:
                      num2 = (short) 2;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 16 /*0x10*/:
                      goto label_48;
                    case 18:
                      if (!this.d[index].Radio_IP_Valid)
                      {
                        num2 = (short) 5;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      this.f = false;
                      ++index;
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    default:
                      goto label_17;
                  }
label_16:;
                }
label_62:
                return;
label_17:
                index = 0;
                num2 = (short) 8;
                num1 = (int) (IntPtr) num2;
                goto label_16;
label_41:
                this.txtboxRadioListFilePath.Text = this.a;
                num2 = (short) 16 /*0x10*/;
                num1 = (int) (IntPtr) num2;
                goto label_16;
              }
              catch (Exception ex)
              {
                if (System.Windows.MessageBox.Show(ex.Message, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                  AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Without_Excalmatory + RptMgrErrorHandler.b("겋", A_1_1) + this.a);
                  goto case 10;
                }
                goto case 10;
              }
            case 15:
              num2 = (short) 6;
              num1 = (int) (IntPtr) num2;
              continue;
            case 16 /*0x10*/:
              AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_saving_Radio_List_File_Is_Hidden);
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
            case 18:
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 19:
              goto label_63;
            default:
              goto label_2;
          }
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
label_49:
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
        }
label_58:
        break;
label_65:
        break;
label_63:
        this.btnSaveAs_Click(A_0, A_1);
        break;
    }
  }

  private void btnSaveAs_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 13;
    int num1 = 0;
    switch (num1)
    {
      default:
        SaveFileDialog saveFileDialog;
        short num2;
        switch (0)
        {
          case 0:
label_3:
            saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = this.a;
            saveFileDialog.Filter = AppResources.Radio_List_Without_Mark_Filter;
            num2 = (short) 9;
            num1 = (int) (IntPtr) num2;
            goto default;
          default:
            while (true)
            {
              string fileName;
              switch (num1)
              {
                case 0:
                  if (File.Exists(fileName))
                  {
                    num2 = (short) 15;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 1:
                  num2 = (short) 11;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 2:
                  if ((File.GetAttributes(fileName) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                  {
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_19;
                case 3:
                  if (File.Exists(fileName))
                  {
                    num2 = (short) 18;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_19;
                case 4:
                  goto label_63;
                case 5:
                  if (!string.IsNullOrEmpty(fileName))
                  {
                    num2 = (short) 12;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_63;
                case 6:
                  if ((File.GetAttributes(fileName) & FileAttributes.Hidden) == FileAttributes.Hidden)
                  {
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  break;
                case 7:
                  if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Readonly, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                  {
                    num2 = (short) 13;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 8:
                  num2 = (short) 7;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 9:
                  if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                  {
                    num2 = (short) 19;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto label_63;
                case 10:
                  try
                  {
                    num2 = (short) -17661;
                    int num3 = (int) num2;
                    num2 = (short) -17661;
                    int num4 = (int) num2;
                    switch (num3 == num4 ? 1 : 0)
                    {
                      case 0:
                      case 2:
label_48:
                        if (!this.a.EndsWith(RptMgrErrorHandler.b("뺏\uEA91煉歹", A_1_1)))
                        {
                          num2 = (short) 15;
                          num1 = (int) (IntPtr) num2;
                          break;
                        }
                        goto label_36;
                      default:
                        num2 = (short) 0;
                        if (num2 == (short) 0)
                          ;
                        switch (0)
                        {
                          case 0:
                            goto label_29;
                        }
                        break;
                    }
                    int index;
                    while (true)
                    {
                      switch (num1)
                      {
                        case 0:
                          if (index >= this.d.Count)
                          {
                            num2 = (short) 3;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 6;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 1:
                          this.f = true;
                          num2 = (short) 18;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 2:
                        case 8:
                          num2 = (short) 0;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 3:
                        case 18:
                          num2 = (short) 17;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 4:
                          this.txtboxRadioListFilePath.Text = this.a;
                          num2 = (short) 16 /*0x10*/;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 5:
                          if (!this.d[index].Radio_IP_Valid)
                          {
                            num2 = (short) 1;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          this.f = false;
                          ++index;
                          num2 = (short) 2;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 6:
                          if (this.d[index].Radio_ID_Valid)
                          {
                            num2 = (short) 12;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 1;
                        case 7:
                          goto label_63;
                        case 9:
                          if (System.Windows.MessageBox.Show(AppResources.Fix_Delete_The_Invalid_Entries_Before_Saving_The_File, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                          {
                            num2 = (short) 11;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          goto case 4;
                        case 10:
                          goto label_48;
                        case 11:
                          num2 = (short) 7;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 12:
                          num2 = (short) 5;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 13:
                          num2 = (short) 10;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 14:
                          goto label_36;
                        case 15:
                          this.a += RptMgrErrorHandler.b("뺏\uEA91煉歹", A_1_1);
                          num2 = (short) 14;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        case 16 /*0x10*/:
                          goto label_18;
                        case 17:
                          if (!this.f)
                          {
                            num2 = (short) 13;
                            num1 = (int) (IntPtr) num2;
                            continue;
                          }
                          num2 = (short) 9;
                          num1 = (int) (IntPtr) num2;
                          continue;
                        default:
                          goto label_29;
                      }
label_28:;
                    }
label_29:
                    index = 0;
                    num2 = (short) 8;
                    num1 = (int) (IntPtr) num2;
                    goto label_28;
label_36:
                    TextWriter textWriter = (TextWriter) new StreamWriter(this.a);
                    this.c.Serialize(textWriter, (object) this.d);
                    textWriter.Close();
                    num2 = (short) 4;
                    num1 = (int) (IntPtr) num2;
                    goto label_28;
                  }
                  catch (Exception ex)
                  {
                    if (System.Windows.MessageBox.Show(ex.Message, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                    {
                      AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Without_Excalmatory + RptMgrErrorHandler.b("낏", A_1_1) + fileName);
                      goto case 14;
                    }
                    goto case 14;
                  }
                case 11:
                  if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Hidden, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                  {
                    num2 = (short) 16 /*0x10*/;
                    num1 = (int) (IntPtr) num2;
                    continue;
                  }
                  goto case 14;
                case 12:
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 13:
                  AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Is_Read_Only);
                  num2 = (short) 17;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 14:
                case 17:
label_18:
                  this.b.OTAP_BATCH_RADIO_LIST_LOCATION = this.txtboxRadioListFilePath.Text;
                  this.b.Save();
                  this.e = false;
                  num2 = (short) 4;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 15:
                  num2 = (short) 6;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 16 /*0x10*/:
                  AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_saving_Radio_List_File_Is_Hidden);
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 18:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                case 19:
                  this.a = saveFileDialog.FileName;
                  fileName = saveFileDialog.FileName;
                  num2 = (short) 5;
                  num1 = (int) (IntPtr) num2;
                  continue;
                default:
                  goto label_3;
              }
              num2 = (short) 10;
              num1 = (int) (IntPtr) num2;
              continue;
label_19:
              num2 = (short) 0;
              num1 = (int) (IntPtr) num2;
            }
label_63:
            num2 = (short) 0;
            return;
        }
    }
  }

  private void btnCancel_Click(object A_0, RoutedEventArgs A_1)
  {
    short num1 = -14383;
    int num2 = (int) num1;
    num1 = (short) -14383;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.Close();
        break;
      default:
        goto case 1;
    }
  }

  private string a()
  {
    int A_1 = 3;
    int num1 = 5;
    short num2;
    while (true)
    {
      switch (num1)
      {
        case 0:
          if (!File.Exists(this.a))
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_13;
        case 1:
          this.a = this.b.OTAP_BATCH_RADIO_LIST_LOCATION;
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          this.a = AppResources.Please_Select_Radio_List_Location;
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 3:
        case 4:
          goto label_13;
        case 5:
          switch (0)
          {
            case 0:
              break;
            default:
              continue;
          }
          break;
      }
      while (File.Exists(this.b.OTAP_BATCH_RADIO_LIST_LOCATION))
      {
        num2 = (short) -1379;
        int num3 = (int) num2;
        num2 = (short) -1379;
        int num4 = (int) num2;
        switch (num3 == num4 ? 1 : 0)
        {
          case 0:
          case 2:
            continue;
          case 1:
            num2 = (short) 0;
            if (num2 == (short) 0)
              ;
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            goto label_2;
          default:
            num2 = (short) 0;
            goto case 1;
        }
      }
      this.a = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), RptMgrErrorHandler.b("쮅\uE787ﺉ\uE38Bﲍﾏﺑ\uF593쪕\uD997\uEA99\uE49B\uD89D솟쾡춣쪥톧\uE9A9ﲫﶭ\uECAF\uF1B1\uDBB3\uDBB5햷햹튻\uE2BD芿ꏁ냃ꗅꃇ雉黋꿍듏믑믓觕铗동꿛ꫝ컟髡解諥", A_1));
      num2 = (short) 0;
      num1 = (int) (IntPtr) num2;
      continue;
label_2:;
    }
label_13:
    num2 = (short) 1;
    if (num2 == (short) 0)
      ;
    return this.a;
  }

  private void btnRadioListFilePathBrowse_Click(object A_0, RoutedEventArgs A_1)
  {
    int A_1_1 = 3;
    int num1;
    OpenFileDialog openFileDialog;
    short num2;
    switch (0)
    {
      case 0:
label_2:
        openFileDialog = new OpenFileDialog();
        openFileDialog.InitialDirectory = this.a;
        openFileDialog.DefaultExt = RptMgrErrorHandler.b("ﺅ\uE587\uE689", A_1_1);
        openFileDialog.Filter = AppResources.XML_Document_Filter;
        num2 = (short) 0;
        num1 = (int) (IntPtr) num2;
        goto default;
      default:
        while (true)
        {
          switch (num1)
          {
            case 0:
              if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
              {
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              }
              goto label_10;
            case 1:
              num2 = (short) -528;
              int num3 = (int) num2;
              num2 = (short) -528;
              int num4 = (int) num2;
              switch (num3 == num4 ? 1 : 0)
              {
                case 0:
                  goto label_5;
                case 2:
                  goto label_12;
                default:
                  num2 = (short) 1;
                  if (num2 == (short) 0)
                    ;
                  num2 = (short) 0;
                  if (num2 == (short) 0)
                    ;
                  this.txtboxRadioListFilePath.Text = openFileDialog.FileName;
                  this.a(this.txtboxRadioListFilePath.Text);
                  num2 = (short) 0;
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
              }
            case 2:
              goto label_11;
            default:
              goto label_2;
          }
        }
label_10:
        break;
label_5:
        break;
label_12:
        break;
label_11:
        this.b.OTAP_BATCH_RADIO_LIST_LOCATION = this.txtboxRadioListFilePath.Text;
        this.b.Save();
        break;
    }
  }

  private void a(string A_0)
  {
    int A_1 = 2;
    short num;
    try
    {
      FileStream fileStream = new FileStream(A_0, FileMode.Open, FileAccess.Read, FileShare.Read);
      this.d = (POP25BatchProgrammerRadioList.RadioList) this.c.Deserialize((Stream) fileStream);
      this.FirePropertyChanged(RptMgrErrorHandler.b("솄\uE686ﶈ\uEA8A\uDE8C\uE08E\uE490\uE192\uF694\uF296", A_1));
      fileStream.Close();
    }
    catch (Exception ex)
    {
      if (File.Exists(this.a))
      {
        if (System.Windows.MessageBox.Show(ex.Message, AppResources.Invalid_XML_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
        {
label_3:
          switch (true ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_3;
            default:
              num = (short) 1;
              if (num == (short) 0)
                ;
              num = (short) 0;
              if (num == (short) 0)
                ;
              if (this.DataSource.Count > 0)
              {
                this.DataSource.Clear();
                break;
              }
              break;
          }
        }
      }
    }
    num = (short) 0;
  }

  private void DataSource_CollectionChanged(object A_0, NotifyCollectionChangedEventArgs A_1)
  {
    short num1 = -19630;
    int num2 = (int) num1;
    num1 = (short) -19630;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        this.e = true;
        break;
      default:
        goto case 1;
    }
  }

  private void dgRadioList_CurrentCellChanged(object A_0, EventArgs A_1)
  {
    short num1 = -19983;
    int num2 = (int) num1;
    num1 = (short) -19983;
    int num3 = (int) num1;
    switch (num2 == num3)
    {
      case true:
        short num4 = 0;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        this.e = true;
        break;
      default:
        goto case 1;
    }
  }

  private void This_Closing(object A_0, CancelEventArgs A_1)
  {
    int A_1_1 = 3;
    int num1 = 0;
    short num2;
    while (true)
    {
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
          A_1.Cancel = true;
          num2 = (short) 7;
          num1 = (int) (IntPtr) num2;
          continue;
        case 2:
          if (System.Windows.MessageBox.Show(AppResources.File_Must_Have_A_Xml_Extension, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
          {
            num2 = (short) 16 /*0x10*/;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 3:
          num2 = (short) 18;
          num1 = (int) (IntPtr) num2;
          continue;
        case 4:
          num2 = (short) 28;
          num1 = (int) (IntPtr) num2;
          continue;
        case 5:
          num2 = (short) 14;
          num1 = (int) (IntPtr) num2;
          continue;
        case 6:
          if (!this.a.EndsWith(RptMgrErrorHandler.b("ꢅ\uF087\uE789\uE08B", A_1_1)))
          {
            num2 = (short) 2;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 4;
          num1 = (int) (IntPtr) num2;
          continue;
        case 7:
        case 20:
        case 21:
        case 22:
          goto label_74;
        case 8:
          A_1.Cancel = true;
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Is_Read_Only);
          num2 = (short) 22;
          num1 = (int) (IntPtr) num2;
          continue;
        case 9:
          if (!(this.a == AppResources.Please_Select_Radio_List_Location))
          {
            num2 = (short) 10;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          num2 = (short) 3;
          num1 = (int) (IntPtr) num2;
          continue;
        case 10:
          if (this.a != null)
          {
            num2 = (short) 26;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 11:
          if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Hidden, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
          {
            num2 = (short) 24;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 12:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 19;
          num1 = (int) (IntPtr) num2;
          continue;
        case 13:
          if (System.Windows.MessageBox.Show(AppResources.File_You_Save_Is_Readonly, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
          {
            num2 = (short) 8;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 14:
          if (System.Windows.MessageBox.Show(AppResources.Do_You_Want_To_Save_The_Radio_List, AppResources.Confirm_Saving, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
          {
            num2 = (short) 0;
            num2 = (short) 25;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 15:
          goto label_10;
        case 16 /*0x10*/:
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Must_Have_Xml_Extension);
          num2 = (short) 21;
          num1 = (int) (IntPtr) num2;
          continue;
        case 17:
label_69:
          if ((File.GetAttributes(this.a) & FileAttributes.Hidden) == FileAttributes.Hidden)
          {
            num2 = (short) 30;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_67;
        case 18:
          if (System.Windows.MessageBox.Show(AppResources.Please_Select_A_Valid_Xml_File_Or_Click_Save_As, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
        case 19:
          if ((File.GetAttributes(this.a) & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
          {
            num2 = (short) 29;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 23:
          if (File.Exists(this.a))
          {
            num2 = (short) 27;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_67;
        case 24:
          A_1.Cancel = true;
          AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_saving_Radio_List_File_Is_Hidden);
          num2 = (short) 20;
          num1 = (int) (IntPtr) num2;
          continue;
        case 25:
          this.a = this.txtboxRadioListFilePath.Text;
          num2 = (short) 9;
          num1 = (int) (IntPtr) num2;
          continue;
        case 26:
          num2 = (short) 6;
          num1 = (int) (IntPtr) num2;
          continue;
        case 27:
          num2 = (short) 17;
          num1 = (int) (IntPtr) num2;
          continue;
        case 28:
          if (File.Exists(this.a))
          {
            num2 = (short) 12;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          break;
        case 29:
          num2 = (short) 13;
          num1 = (int) (IntPtr) num2;
          continue;
        case 30:
          num2 = (short) -16214;
          int num3 = (int) num2;
          num2 = (short) -16214;
          int num4 = (int) num2;
          switch (num3 == num4 ? 1 : 0)
          {
            case 0:
            case 2:
              goto label_69;
            default:
              num2 = (short) 0;
              if (num2 == (short) 0)
                ;
              num2 = (short) 11;
              num1 = (int) (IntPtr) num2;
              continue;
          }
        default:
label_3:
          if (this.e)
          {
            num2 = (short) 5;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_74;
      }
      num2 = (short) 23;
      num1 = (int) (IntPtr) num2;
      continue;
label_67:
      num2 = (short) 15;
      num1 = (int) (IntPtr) num2;
    }
label_10:
    try
    {
      int index;
      switch (0)
      {
        case 0:
label_12:
          index = 0;
          num2 = (short) 5;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          while (true)
          {
            switch (num1)
            {
              case 0:
                if (System.Windows.MessageBox.Show(AppResources.Fix_The_Invalid_Entries_Before_Saving_File, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
                {
                  num2 = (short) 15;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 11;
              case 1:
                if (this.d[index].Radio_ID_Valid)
                {
                  num2 = (short) 3;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 6;
              case 2:
                if (!this.f)
                {
                  num2 = (short) 14;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                continue;
              case 3:
                num2 = (short) 7;
                num1 = (int) (IntPtr) num2;
                continue;
              case 4:
                goto label_74;
              case 5:
              case 8:
                num2 = (short) 13;
                num1 = (int) (IntPtr) num2;
                continue;
              case 6:
                this.f = true;
                num2 = (short) 9;
                num1 = (int) (IntPtr) num2;
                continue;
              case 7:
                if (this.d[index].Radio_IP_Valid)
                {
                  this.f = false;
                  ++index;
                  num2 = (short) 8;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 6;
                num1 = (int) (IntPtr) num2;
                continue;
              case 9:
              case 10:
                num2 = (short) 2;
                num1 = (int) (IntPtr) num2;
                continue;
              case 11:
              case 12:
                this.txtboxRadioListFilePath.Text = this.a;
                num2 = (short) 4;
                num1 = (int) (IntPtr) num2;
                continue;
              case 13:
                if (index >= this.d.Count)
                {
                  num2 = (short) 10;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                num2 = (short) 1;
                num1 = (int) (IntPtr) num2;
                continue;
              case 14:
                TextWriter textWriter = (TextWriter) new StreamWriter(this.a);
                this.c.Serialize(textWriter, (object) this.d);
                textWriter.Close();
                num2 = (short) 12;
                num1 = (int) (IntPtr) num2;
                continue;
              case 15:
                A_1.Cancel = true;
                num2 = (short) 11;
                num1 = (int) (IntPtr) num2;
                continue;
              default:
                goto label_12;
            }
          }
      }
    }
    catch (Exception ex)
    {
      if (System.Windows.MessageBox.Show(ex.Message, AppResources.Error_Saving_Radio_List_File, MessageBoxButton.OK, MessageBoxImage.Exclamation) == MessageBoxResult.OK)
        AppInfoManager.StatusMsgReport.RegisterMessage((StatusMsgType) 0, AppResources.Error_Saving_Radio_List_File_Without_Excalmatory + RptMgrErrorHandler.b("ꚅ", A_1_1) + this.a);
    }
label_74:
    this.b.OTAP_BATCH_RADIO_LIST_LOCATION = this.txtboxRadioListFilePath.Text;
    this.b.Save();
  }

  public event PropertyChangedEventHandler PropertyChanged
  {
    add
    {
      int num1;
      PropertyChangedEventHandler changedEventHandler;
      short num2;
      switch (0)
      {
        case 0:
label_2:
          changedEventHandler = this.g;
          num2 = (short) 0;
          num1 = (int) (IntPtr) num2;
          goto default;
        default:
          PropertyChangedEventHandler comparand;
          while (true)
          {
            switch (num1)
            {
              case 0:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.g, comparand + value, comparand);
                num2 = (short) 12760;
                int num3 = (int) num2;
                num2 = (short) 12760;
                int num4 = (int) num2;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_2;
                  default:
                    num2 = (short) 0;
                    if (num2 == (short) 0)
                      ;
                    num2 = (short) 1;
                    num1 = (int) (IntPtr) num2;
                    continue;
                }
              case 1:
                if (changedEventHandler == comparand)
                {
                  num2 = (short) 2;
                  num1 = (int) (IntPtr) num2;
                  continue;
                }
                goto case 0;
              case 2:
                goto label_8;
              default:
                goto label_2;
            }
          }
label_8:
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          num2 = (short) 0;
          break;
      }
    }
    remove
    {
      short num1;
      int num2;
      PropertyChangedEventHandler changedEventHandler;
      switch (0)
      {
        case 0:
label_3:
          changedEventHandler = this.g;
          num1 = (short) 0;
          num2 = (int) (IntPtr) num1;
          goto default;
        default:
          while (true)
          {
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            PropertyChangedEventHandler comparand;
            switch (num2)
            {
              case 0:
                comparand = changedEventHandler;
                changedEventHandler = Interlocked.CompareExchange<PropertyChangedEventHandler>(ref this.g, comparand - value, comparand);
                num1 = (short) -26924;
                int num3 = (int) num1;
                num1 = (short) -26924;
                int num4 = (int) num1;
                switch (num3 == num4 ? 1 : 0)
                {
                  case 0:
                  case 2:
                    goto label_3;
                  default:
                    num1 = (short) 0;
                    if (num1 == (short) 0)
                      ;
                    num1 = (short) 1;
                    num2 = (int) (IntPtr) num1;
                    continue;
                }
              case 1:
                if (changedEventHandler == comparand)
                {
                  num1 = (short) 2;
                  num2 = (int) (IntPtr) num1;
                  continue;
                }
                goto case 0;
              case 2:
                goto label_9;
              default:
                goto label_3;
            }
          }
label_9:
          num1 = (short) 0;
          break;
      }
    }
  }

  public void FirePropertyChanged(string name)
  {
    int num1 = 0;
    while (true)
    {
      short num2 = 0;
      num2 = (short) 9886;
      int num3 = (int) num2;
      num2 = (short) 9886;
      int num4 = (int) num2;
      switch (num3 == num4 ? 1 : 0)
      {
        case 0:
          goto label_9;
        case 2:
          goto label_2;
        default:
          num2 = (short) 0;
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
              // ISSUE: reference to a compiler-generated field
              this.g((object) this, new PropertyChangedEventArgs(name));
              num2 = (short) 2;
              num1 = (int) (IntPtr) num2;
              continue;
            case 2:
              goto label_12;
          }
          num2 = (short) 1;
          if (num2 == (short) 0)
            ;
          // ISSUE: reference to a compiler-generated field
          if (this.g != null)
          {
            num2 = (short) 1;
            num1 = (int) (IntPtr) num2;
            continue;
          }
          goto label_11;
      }
    }
label_9:
    return;
label_2:
    return;
label_12:
    return;
label_11:;
  }

  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  public void InitializeComponent()
  {
    int A_1 = 9;
    short num1 = 31820;
    int num2 = (int) num1;
    num1 = (short) 31820;
    int num3 = (int) num1;
    short num4;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
        break;
      case 1:
        num4 = (short) 0;
        if (num4 == (short) 0)
          ;
        if (this.h)
          break;
        num4 = (short) 1;
        if (num4 == (short) 0)
          ;
        this.h = true;
        System.Windows.Application.LoadComponent((object) this, new Uri(RptMgrErrorHandler.b("ꎋ\uDD8D\uE08F\uF791\uF793ﾕ聯\uF699\uDA9Bﮝ솟횡톣풥춧\uD9A9鞫춭\uDFAF\uDFB1쒳\uD9B5횷\uDFB9튻쪽\uEFBF닁ꯃ뛅難\uFFC9껋꿍\uA4CF뇑볓ꛕ\uAAD7뗙믛곝臟迡解菥髧엩鳫臭胯샱쇳铵駷軹\u9FFB雽烿瀁欃愅稇欉愋挍甏怑易眕簗猙猛爝䤟儡倣ࠥ倧䬩䄫䈭", A_1), UriKind.Relative));
        break;
      case 2:
        break;
      default:
        num4 = (short) 0;
        goto case 1;
    }
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  [GeneratedCode("PresentationBuildTasks", "5.0.10.0")]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    short num1 = -26199;
    int num2 = (int) num1;
    num1 = (short) -26199;
    int num3 = (int) num1;
    switch (num2 == num3 ? 1 : 0)
    {
      case 0:
      case 2:
label_16:
        ((CommandBinding) target).Executed += new ExecutedRoutedEventHandler(this.btnRadioListHelp_click);
        ((CommandBinding) target).CanExecute += new CanExecuteRoutedEventHandler(this.F1HelpCommandCanExcute);
        break;
      default:
        short num4 = 0;
        if (num4 == (short) 0)
          ;
        num4 = (short) 0;
        int num5 = (int) (IntPtr) num4;
        while (true)
        {
          switch (num5)
          {
            case 0:
              num4 = (short) 1;
              if (num4 == (short) 0)
                ;
              switch (0)
              {
                case 0:
                  break;
                default:
                  continue;
              }
              break;
            case 1:
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            case 2:
              goto label_24;
          }
          switch (connectionId)
          {
            case 1:
              goto label_12;
            case 2:
              goto label_16;
            case 3:
              goto label_10;
            case 4:
              goto label_21;
            case 5:
              goto label_19;
            case 6:
              goto label_22;
            case 7:
              goto label_15;
            case 8:
              goto label_9;
            case 9:
              goto label_23;
            case 10:
              goto label_13;
            case 11:
              goto label_8;
            case 12:
              goto label_18;
            case 13:
              goto label_11;
            case 14:
              goto label_17;
            case 15:
              goto label_14;
            default:
              num4 = (short) 1;
              num5 = (int) (IntPtr) num4;
              continue;
          }
        }
label_8:
        this.btnSave = (System.Windows.Controls.Button) target;
        this.btnSave.Click += new RoutedEventHandler(this.btnSave_Click);
        break;
label_9:
        this.dgRadioList = (System.Windows.Controls.DataGrid) target;
        this.dgRadioList.CurrentCellChanged += new EventHandler<EventArgs>(this.dgRadioList_CurrentCellChanged);
        break;
label_10:
        this.lbSchedulerList = (System.Windows.Controls.Label) target;
        break;
label_11:
        this.btnDone = (System.Windows.Controls.Button) target;
        this.btnDone.Click += new RoutedEventHandler(this.btnDone_Click);
        break;
label_12:
        this.This = (POP25BatchProgrammerRadioList) target;
        this.This.Closing += new CancelEventHandler(this.This_Closing);
        break;
label_13:
        this.btnDeleteAll = (System.Windows.Controls.Button) target;
        this.btnDeleteAll.Click += new RoutedEventHandler(this.btnDeleteAll_Click);
        break;
label_14:
        this.btnHelp = (System.Windows.Controls.Button) target;
        this.btnHelp.Click += new RoutedEventHandler(this.btnRadioListHelp_click);
        break;
label_15:
        num4 = (short) 0;
        this.label1 = (System.Windows.Controls.Label) target;
        break;
label_17:
        this.btnCancel = (System.Windows.Controls.Button) target;
        this.btnCancel.Click += new RoutedEventHandler(this.btnCancel_Click);
        break;
label_18:
        this.btnSaveAs = (System.Windows.Controls.Button) target;
        this.btnSaveAs.Click += new RoutedEventHandler(this.btnSaveAs_Click);
        break;
label_19:
        this.btnRadioListFilePathBrowse = (System.Windows.Controls.Button) target;
        this.btnRadioListFilePathBrowse.Click += new RoutedEventHandler(this.btnRadioListFilePathBrowse_Click);
        break;
label_21:
        this.txtboxRadioListFilePath = (System.Windows.Controls.TextBox) target;
        break;
label_22:
        this.lbRadioList = (System.Windows.Controls.Label) target;
        break;
label_23:
        this.btnDelete = (System.Windows.Controls.Button) target;
        this.btnDelete.Click += new RoutedEventHandler(this.btndelete_Click);
        break;
label_24:
        this.h = true;
        break;
    }
  }

  [XmlType("Radio")]
  [Serializable]
  public class RadioInfo
  {
    private string radio_id;
    private string radio_ip;
    private bool radio_id_valid = true;
    private bool radio_ip_valid = true;

    public string Radio_ID
    {
      get
      {
        short num1 = 1;
        if (num1 == (short) 0)
          ;
        num1 = (short) 4316;
        int num2 = (int) num1;
        num1 = (short) 4316;
        int num3 = (int) num1;
        switch (num2 == num3)
        {
          case true:
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            return this.radio_id;
          default:
            num1 = (short) 0;
            goto case 1;
        }
      }
      set
      {
        short num1 = 26494;
        int num2 = (int) num1;
        num1 = (short) 26494;
        int num3 = (int) num1;
        short num4;
        int num5;
        switch (num2 == num3 ? 1 : 0)
        {
          case 0:
          case 2:
label_10:
            num4 = (short) 6;
            num5 = (int) (IntPtr) num4;
            break;
          default:
            num4 = (short) 0;
            if (num4 == (short) 0)
              ;
            num4 = (short) 1;
            if (num4 == (short) 0)
              ;
            switch (0)
            {
              case 0:
                goto label_5;
            }
            break;
        }
        int num6;
        int result;
        while (true)
        {
          switch (num5)
          {
            case 0:
              if (result >= num6)
              {
                num4 = (short) 8;
                num5 = (int) (IntPtr) num4;
                continue;
              }
              goto case 6;
            case 1:
              if (string.IsNullOrEmpty(this.radio_id))
              {
                num4 = (short) 5;
                num5 = (int) (IntPtr) num4;
                continue;
              }
              num4 = (short) 2;
              num5 = (int) (IntPtr) num4;
              continue;
            case 2:
              if (!int.TryParse(value, out result))
              {
                num4 = (short) 7;
                num5 = (int) (IntPtr) num4;
                continue;
              }
              num4 = (short) 0;
              num5 = (int) (IntPtr) num4;
              continue;
            case 3:
              goto label_17;
            case 4:
              goto label_9;
            case 5:
              goto label_12;
            case 6:
              this.Radio_ID_Valid = false;
              num4 = (short) 3;
              num5 = (int) (IntPtr) num4;
              continue;
            case 7:
              goto label_11;
            case 8:
              num4 = (short) 0;
              num4 = (short) 4;
              num5 = (int) (IntPtr) num4;
              continue;
            default:
              goto label_5;
          }
label_4:;
        }
label_17:
        return;
label_9:
        int num7;
        if (result <= num7)
          return;
        goto label_10;
label_11:
        this.Radio_ID_Valid = false;
        return;
label_12:
        this.Radio_ID_Valid = true;
        return;
label_5:
        this.radio_id = value;
        num6 = 1;
        num7 = 16777211;
        this.Radio_ID_Valid = true;
        num4 = (short) 1;
        num5 = (int) (IntPtr) num4;
        goto label_4;
      }
    }

    public string Radio_IP
    {
      get
      {
        short num1 = 19326;
        int num2 = (int) num1;
        num1 = (short) 19326;
        int num3 = (int) num1;
        switch (num2 == num3)
        {
          case true:
            short num4 = 0;
            num4 = (short) 0;
            if (num4 == (short) 0)
              ;
            num4 = (short) 1;
            if (num4 == (short) 0)
              ;
            return this.radio_ip;
          default:
            goto case 1;
        }
      }
      set
      {
        int num1 = 0;
        switch (num1)
        {
          default:
            short num2 = 1;
            if (num2 == (short) 0)
              ;
            string str;
            switch (0)
            {
              case 0:
label_4:
                this.radio_ip = value;
                str = value;
                this.Radio_IP_Valid = true;
                num2 = (short) 0;
                num1 = (int) (IntPtr) num2;
                goto default;
              default:
                int result;
                int index;
                string[] strArray1;
                string[] strArray2;
                while (true)
                {
                  switch (num1)
                  {
                    case 0:
                      if (string.IsNullOrEmpty(this.radio_ip))
                      {
                        num2 = (short) 8;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 0;
                      strArray1 = str.Split('.');
                      num2 = (short) 9;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 1:
                      if (result > (int) byte.MaxValue)
                      {
                        num2 = (short) 2;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      ++index;
                      num2 = (short) 15;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 2:
                      goto label_26;
                    case 3:
                      num2 = (short) 1;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 4:
                      goto label_13;
                    case 5:
                    case 15:
                      num2 = (short) 11;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 6:
                      goto label_12;
                    case 7:
                      strArray2 = strArray1;
                      index = 0;
                      num2 = (short) 5;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 8:
                      goto label_7;
                    case 9:
                      if (strArray1.Length != 4)
                      {
                        num2 = (short) 4;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 12;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 10:
                      if (int.TryParse(strArray2[index], out result))
                      {
                        num2 = (short) 14;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 6;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 11:
                      if (index >= strArray2.Length)
                      {
                        num2 = (short) 13;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      num2 = (short) 10;
                      num1 = (int) (IntPtr) num2;
                      continue;
                    case 12:
                      if (this.Radio_IP_Valid)
                      {
                        num2 = (short) 7;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_34;
                    case 13:
                      goto label_30;
                    case 14:
                      if (result >= 0)
                      {
                        num2 = (short) 3;
                        num1 = (int) (IntPtr) num2;
                        continue;
                      }
                      goto label_26;
                    default:
                      goto label_4;
                  }
                }
label_30:
                return;
label_7:
                num2 = (short) 2777;
                int num3 = (int) num2;
                num2 = (short) 2777;
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
                    this.Radio_IP_Valid = true;
                    return;
                }
label_12:
                this.Radio_IP_Valid = false;
                return;
label_13:
                this.Radio_IP_Valid = false;
                return;
label_26:
                this.Radio_IP_Valid = false;
                return;
label_34:
                return;
            }
        }
      }
    }

    [XmlIgnore]
    public bool Radio_ID_Valid
    {
      get
      {
        short num1 = 0;
        num1 = (short) -7187;
        int num2 = (int) num1;
        num1 = (short) -7187;
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
            return this.radio_id_valid;
          default:
            goto case 1;
        }
      }
      set
      {
        short num1 = 0;
        num1 = (short) -12673;
        int num2 = (int) num1;
        num1 = (short) -12673;
        int num3 = (int) num1;
        switch (num2 == num3)
        {
          case true:
            num1 = (short) 0;
            if (num1 == (short) 0)
              ;
            num1 = (short) 1;
            if (num1 == (short) 0)
              ;
            this.radio_id_valid = value;
            break;
          default:
            goto case 1;
        }
      }
    }

    [XmlIgnore]
    public bool Radio_IP_Valid
    {
      get
      {
        short num1 = -9157;
        int num2 = (int) num1;
        num1 = (short) -9157;
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
            return this.radio_ip_valid;
          default:
            goto case 1;
        }
      }
      set
      {
        short num1 = -22479;
        int num2 = (int) num1;
        num1 = (short) -22479;
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
            this.radio_ip_valid = value;
            break;
          default:
            goto case 1;
        }
      }
    }
  }

  [XmlType("RadioList_Table")]
  [Serializable]
  public class RadioList : ObservableCollection<POP25BatchProgrammerRadioList.RadioInfo>
  {
  }
}
