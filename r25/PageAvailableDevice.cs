// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageAvailableDevice
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpUI;
using AcpUI.Common;
using CommonResources;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageAvailableDevice : Page, IComponentConnector
{
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal Button button;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal TreeView MyTreeView;
  private bool _contentLoaded;

  public PageAvailableDevice()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    AcpTreeViewItem newItem1 = new AcpTreeViewItem();
    newItem1.Name = "TreeViewItemAvailableDevice";
    newItem1.Header = (object) AppResources.Available_Device;
    newItem1.IsExpanded = true;
    this.MyTreeView.Items.Add((object) newItem1);
    AcpTreeViewItem newItem2 = new AcpTreeViewItem();
    CheckBox checkBox1 = new CheckBox();
    checkBox1.Content = (object) AppResources.XTL5000_588008_000480;
    checkBox1.Name = "TreeViewItemXTL5000";
    newItem2.Header = (object) checkBox1;
    newItem1.Items.Add((object) newItem2);
    AcpTreeViewItem newItem3 = new AcpTreeViewItem();
    CheckBox checkBox2 = new CheckBox();
    checkBox2.Content = (object) AppResources.Radio_ID1;
    checkBox2.Name = "TreeViewItemXTL50001";
    newItem3.Header = (object) checkBox2;
    newItem2.Items.Add((object) newItem3);
    AcpTreeViewItem newItem4 = new AcpTreeViewItem();
    CheckBox checkBox3 = new CheckBox();
    checkBox3.Content = (object) AppResources.Radio_ID2;
    checkBox3.Name = "TreeViewItemXTL50001";
    newItem4.Header = (object) checkBox3;
    newItem2.Items.Add((object) newItem4);
    AcpTreeViewItem newItem5 = new AcpTreeViewItem();
    CheckBox checkBox4 = new CheckBox();
    checkBox4.Content = (object) AppResources.XTL2500_588008_000480;
    checkBox4.Name = "TreeViewItemXTL2500";
    newItem5.Header = (object) checkBox4;
    newItem1.Items.Add((object) newItem5);
    AcpTreeViewItem newItem6 = new AcpTreeViewItem();
    CheckBox checkBox5 = new CheckBox();
    checkBox5.Content = (object) AppResources.Radio_ID3;
    checkBox5.Name = "TreeViewItemXTL25001";
    newItem6.Header = (object) checkBox5;
    newItem5.Items.Add((object) newItem6);
    AcpTreeViewItem newItem7 = new AcpTreeViewItem();
    CheckBox checkBox6 = new CheckBox();
    checkBox6.Content = (object) AppResources.XTL1500_588008_000480;
    checkBox6.Name = "TreeViewItemXTL1500";
    newItem7.Header = (object) checkBox6;
    newItem1.Items.Add((object) newItem7);
    AcpTreeViewItem newItem8 = new AcpTreeViewItem();
    CheckBox checkBox7 = new CheckBox();
    checkBox7.Content = (object) AppResources.Radio_ID4;
    checkBox7.Name = "TreeViewItemXTL15001";
    newItem8.Header = (object) checkBox7;
    newItem7.Items.Add((object) newItem8);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pageavailabledevice.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.button = (Button) target;
        break;
      case 2:
        this.MyTreeView = (TreeView) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
