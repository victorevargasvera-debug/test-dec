// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageStatusBar
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyDepot R28\APXdepotR28.exe

using AcpUI.Common;
using CommonResources;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media.Animation;

#nullable disable
namespace MackinawCPS;

public partial class PageStatusBar : Page, INotifyPropertyChanged, IComponentConnector
{
  private string status;
  private string model;
  private string sn;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal TextBlock StatusText;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal TextBlock SerialNumText;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal TextBlock ModelText;
  [SuppressMessage("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
  internal ProgressBar ProgBar;
  private bool _contentLoaded;

  public PageStatusBar()
  {
    this.InitializeComponent();
    Utility.SetDirection((FrameworkElement) this);
    this.Status = AppResources.READY_ID;
    this.DataContext = (object) this;
  }

  internal void UpdateProgress(double progress)
  {
    DoubleAnimation animation = new DoubleAnimation(100.0, new Duration(TimeSpan.FromSeconds(5.0)));
    this.ProgBar.BeginAnimation(RangeBase.ValueProperty, (AnimationTimeline) animation);
  }

  public string Status
  {
    get => this.status;
    set
    {
      this.status = value;
      this.OnPropertyChanged(nameof (Status));
    }
  }

  public string RadioModel
  {
    get => this.model;
    set
    {
      this.model = value;
      this.OnPropertyChanged(nameof (RadioModel));
    }
  }

  public string SerialNum
  {
    get => this.sn;
    set
    {
      this.sn = value;
      this.OnPropertyChanged(nameof (SerialNum));
    }
  }

  public void OnPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }

  public event PropertyChangedEventHandler PropertyChanged;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/pagestatusbar.xaml", UriKind.Relative));
  }

  [SuppressMessage("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
  [GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
  [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
  [SuppressMessage("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  [DebuggerNonUserCode]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.StatusText = (TextBlock) target;
        break;
      case 2:
        this.SerialNumText = (TextBlock) target;
        break;
      case 3:
        this.ModelText = (TextBlock) target;
        break;
      case 4:
        this.ProgBar = (ProgressBar) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
