// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageFilterView
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpUI;
using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS;

public class PageFilterView : Page, IComponentConnector
{
  internal AcpCheckBox ChBoxDev2;
  internal CheckBox ChBoxDev7;
  internal CheckBox ChBoxDev8;
  internal CheckBox ChBoxDev9;
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
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/devicemanager/pagefilterview.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
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
