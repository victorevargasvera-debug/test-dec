// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageDeviceMenagerTableView
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpUI.Common;
using CommonResources;
using Infragistics.Windows.DataPresenter;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageDeviceMenagerTableView : Page, IComponentConnector
{
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal XamDataGrid DGContactTypes;
  private bool _contentLoaded;

  public PageDeviceMenagerTableView()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    DataTable contactEntryDataTable = this.CreateContactEntryDataTable();
    this.DGContactTypes.DataSource = (IEnumerable) contactEntryDataTable.DefaultView;
    this.AddSomeRows(contactEntryDataTable, 4);
  }

  private DataTable CreateContactEntryDataTable()
  {
    DataTable contactEntryDataTable = new DataTable(AppResources.SwatiTable_Id);
    DataColumn column1 = new DataColumn(AppResources.Asset_ID, typeof (string));
    DataColumn column2 = new DataColumn(AppResources.Organization_Id, typeof (string));
    DataColumn column3 = new DataColumn(AppResources.Host_DSP_Version, typeof (string));
    DataColumn column4 = new DataColumn(AppResources.MACE_Version, typeof (string));
    DataColumn column5 = new DataColumn(AppResources.Tuner_Version, typeof (string));
    DataColumn column6 = new DataColumn(AppResources.Model_Number, typeof (string));
    DataColumn column7 = new DataColumn(AppResources.Serial_Number, typeof (string));
    DataColumn column8 = new DataColumn(AppResources.FLASHcode_Id, typeof (string));
    contactEntryDataTable.Columns.Add(new DataColumn(AppResources.Select_Device_S)
    {
      DataType = Type.GetType("System.Boolean")
    });
    contactEntryDataTable.Columns.Add(new DataColumn(AppResources.DeviceName_Id)
    {
      DataType = Type.GetType("System.String"),
      Unique = false,
      ReadOnly = false
    });
    contactEntryDataTable.Columns.Add(column1);
    contactEntryDataTable.Columns.Add(column2);
    contactEntryDataTable.Columns.Add(column6);
    contactEntryDataTable.Columns.Add(column7);
    contactEntryDataTable.Columns.Add(column8);
    contactEntryDataTable.Columns.Add(column3);
    contactEntryDataTable.Columns.Add(column4);
    contactEntryDataTable.Columns.Add(column5);
    return contactEntryDataTable;
  }

  private void AddSomeRows(DataTable dt, int numRows)
  {
    DataRow row1 = dt.NewRow();
    row1[1] = (object) AppResources.Radio_ID1;
    row1[2] = (object) "PO1234LI";
    row1[3] = (object) AppResources.Police_Id;
    row1[4] = (object) "XTL5000";
    row1[5] = (object) "123ABC1234";
    row1[6] = (object) "588008-000480";
    row1[7] = (object) "R01.00.00";
    row1[8] = (object) "R01.00.00";
    row1[9] = (object) "R01.00.00";
    dt.Rows.Add(row1);
    DataRow row2 = dt.NewRow();
    row2[1] = (object) AppResources.Radio_ID2;
    row2[2] = (object) "PO4567LI";
    row2[3] = (object) AppResources.Police_Id;
    row2[4] = (object) "XTL5000";
    row2[5] = (object) "460MIA4500";
    row2[6] = (object) "588008-000480";
    row2[7] = (object) "R02.00.00";
    row2[8] = (object) "R02.00.00";
    row2[9] = (object) "R01.00.00";
    dt.Rows.Add(row2);
    DataRow row3 = dt.NewRow();
    row3[1] = (object) AppResources.Radio_ID3;
    row3[2] = (object) "PO8901LI";
    row3[3] = (object) AppResources.Police_Id;
    row3[4] = (object) "XTL5000";
    row3[5] = (object) "460PLA4500";
    row3[6] = (object) "588008-000488";
    row3[7] = (object) "R01.00.00";
    row3[8] = (object) "R01.00.00";
    row3[9] = (object) "R01.00.00";
    dt.Rows.Add(row3);
    DataRow row4 = dt.NewRow();
    row4[1] = (object) AppResources.Radio_ID4;
    row4[2] = (object) "FI1234RE";
    row4[3] = (object) AppResources.Fire_Id;
    row4[4] = (object) "XTL5000";
    row4[5] = (object) "460SUN4500";
    row4[6] = (object) "588008-000488";
    row4[7] = (object) "R02.00.00";
    row4[8] = (object) "R02.00.00";
    row4[9] = (object) "R02.00.00";
    dt.Rows.Add(row4);
    DataRow row5 = dt.NewRow();
    row5[1] = (object) AppResources.Radio_ID5;
    row5[2] = (object) "FI5678RE";
    row5[3] = (object) AppResources.Fire_Id;
    row5[4] = (object) "XTL2500";
    row5[5] = (object) "460WES4500";
    row5[6] = (object) "588008-000488";
    row5[7] = (object) "R02.00.00";
    row5[8] = (object) "R02.00.00";
    row5[9] = (object) "R02.00.00";
    dt.Rows.Add(row5);
    DataRow row6 = dt.NewRow();
    row6[1] = (object) AppResources.Radio_ID6;
    row6[2] = (object) "FI9012RE";
    row6[3] = (object) AppResources.Fire_Id;
    row6[4] = (object) "XTL2500";
    row6[5] = (object) "460JAX4500";
    row6[6] = (object) "588008-000408";
    row6[7] = (object) "R03.00.00";
    row6[8] = (object) "R02.00.00";
    row6[9] = (object) "R02.00.00";
    dt.Rows.Add(row6);
    DataRow row7 = dt.NewRow();
    row7[1] = (object) AppResources.Radio_ID7;
    row7[2] = (object) "EM1234TA";
    row7[3] = (object) AppResources.EMT_Id;
    row7[4] = (object) "XTL2500";
    row7[5] = (object) "460HIA4500";
    row7[6] = (object) "588008-000408";
    row7[7] = (object) "R03.00.00";
    row7[8] = (object) "R02.00.00";
    row7[9] = (object) "R02.00.00";
    dt.Rows.Add(row7);
    DataRow row8 = dt.NewRow();
    row8[1] = (object) AppResources.Radio_ID8;
    row8[2] = (object) "EM5678TB";
    row8[3] = (object) AppResources.EMT_Id;
    row8[4] = (object) "XTL2500";
    row8[5] = (object) "460LAD4500";
    row8[6] = (object) "588008-000488";
    row8[7] = (object) "R02.00.01";
    row8[8] = (object) "R02.00.01";
    row8[9] = (object) "R02.00.01";
    dt.Rows.Add(row8);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagedevicemenagertableview.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.DGContactTypes = (XamDataGrid) target;
    else
      this._contentLoaded = true;
  }
}
