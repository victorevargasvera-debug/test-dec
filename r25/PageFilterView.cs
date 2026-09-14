// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageFilterView
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpUI;
using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageFilterView : Page, IComponentConnector
{
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal AcpCheckBox ChBoxDev2;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal CheckBox ChBoxDev7;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal CheckBox ChBoxDev8;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal CheckBox ChBoxDev9;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal CheckBox ChBoxDev10;
  private bool _contentLoaded;

  internal void OnMouseLeftButtonDown(object sender, RoutedEventArgs e)
  {
  }

  internal void OnMouseRightButtonDown(object sender, RoutedEventArgs e)
  {
    if (sender != this.ChBoxDev7)
      return;
    this.ChBoxDev8.IsChecked = new bool?(false);
    this.ChBoxDev9.IsChecked = new bool?(false);
    this.ChBoxDev10.IsChecked = new bool?(false);
  }

  public PageFilterView()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagefilterview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.ChBoxDev2 = (AcpCheckBox) target;
        this.ChBoxDev2.MouseRightButtonDown += new MouseButtonEventHandler(this.OnMouseRightButtonDown);
        break;
      case 2:
        this.ChBoxDev7 = (CheckBox) target;
        this.ChBoxDev7.Click += new RoutedEventHandler(this.OnMouseRightButtonDown);
        break;
      case 3:
        this.ChBoxDev8 = (CheckBox) target;
        this.ChBoxDev8.MouseRightButtonDown += new MouseButtonEventHandler(this.OnMouseRightButtonDown);
        break;
      case 4:
        this.ChBoxDev9 = (CheckBox) target;
        this.ChBoxDev9.MouseRightButtonDown += new MouseButtonEventHandler(this.OnMouseRightButtonDown);
        break;
      case 5:
        this.ChBoxDev10 = (CheckBox) target;
        this.ChBoxDev10.MouseRightButtonDown += new MouseButtonEventHandler(this.OnMouseRightButtonDown);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
