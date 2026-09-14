// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CodeplugConfiguration.PageCodeplugNotOpened
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using AcpUI.Common;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace MackinawCPS.CodeplugConfiguration;

public partial class PageCodeplugNotOpened : Page, IComponentConnector
{
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ContentControl HowTo;
  private bool _contentLoaded;

  public PageCodeplugNotOpened()
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
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/codeplugconfiguration/pagecodeplugnotopened.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.HowTo = (ContentControl) target;
    else
      this._contentLoaded = true;
  }
}
