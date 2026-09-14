// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageDeviceInfoTableView
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI.Common;
using CommonResources;
using Infragistics.Windows.DataPresenter;
using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageDeviceInfoTableView : Page, IComponentConnector
{
  internal XamDataGrid DGContactTypes;
  private bool _contentLoaded;

  public PageDeviceInfoTableView()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    DataTable contactEntryDataTable = this.CreateContactEntryDataTable();
    this.DGContactTypes.DataSource = (IEnumerable) contactEntryDataTable.DefaultView;
    this.AddSomeRows(contactEntryDataTable, 4);
  }

  private DataTable CreateContactEntryDataTable()
  {
    DataTable contactEntryDataTable = new DataTable("SwatiTable");
    DataColumn column1 = new DataColumn("Host/DSP Version", typeof (string));
    DataColumn column2 = new DataColumn("MACE Version", typeof (string));
    DataColumn column3 = new DataColumn("Tuner Version", typeof (string));
    DataColumn column4 = new DataColumn("Model Number", typeof (string));
    contactEntryDataTable.Columns.Add(new DataColumn("Select Device/s")
    {
      DataType = Type.GetType("System.String")
    });
    contactEntryDataTable.Columns.Add(new DataColumn("DeviceName")
    {
      DataType = Type.GetType("System.String"),
      Unique = false,
      ReadOnly = false
    });
    contactEntryDataTable.Columns.Add(column1);
    contactEntryDataTable.Columns.Add(column2);
    contactEntryDataTable.Columns.Add(column3);
    contactEntryDataTable.Columns.Add(column4);
    return contactEntryDataTable;
  }

  private void AddSomeRows(DataTable dt, int numRows)
  {
    DataRow row1 = dt.NewRow();
    row1[1] = (object) AppResources.Radio_ID1;
    row1[2] = (object) AppResources.R01_00_00;
    row1[3] = (object) AppResources.R01_00_00;
    row1[4] = (object) AppResources.R01_00_00;
    row1[5] = (object) AppResources.XTL5000_ID;
    dt.Rows.Add(row1);
    DataRow row2 = dt.NewRow();
    row2[1] = (object) AppResources.Radio_ID2;
    row2[2] = (object) AppResources.R02_00_00;
    row2[3] = (object) AppResources.R02_00_00;
    row2[4] = (object) AppResources.R01_00_00;
    row2[5] = (object) AppResources.XTL5000_ID;
    dt.Rows.Add(row2);
    DataRow row3 = dt.NewRow();
    row3[1] = (object) AppResources.Radio_ID3;
    row3[2] = (object) AppResources.R01_00_00;
    row3[3] = (object) AppResources.R01_00_00;
    row3[4] = (object) AppResources.R01_00_00;
    row3[5] = (object) AppResources.XTL5000_ID;
    dt.Rows.Add(row3);
    DataRow row4 = dt.NewRow();
    row4[1] = (object) AppResources.Radio_ID4;
    row4[2] = (object) AppResources.R02_00_00;
    row4[3] = (object) AppResources.R02_00_00;
    row4[4] = (object) AppResources.R02_00_00;
    row4[5] = (object) AppResources.XTL2500_ID;
    dt.Rows.Add(row4);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagedeviceinfotableview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.DGContactTypes = (XamDataGrid) target;
    else
      this._contentLoaded = true;
  }
}
