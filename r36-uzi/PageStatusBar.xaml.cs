// Decompiled with JetBrains decompiler
// Type: MackinawCPS.PageStatusBar
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using AcpCommonLib;
using CommonResources;
using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
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
  private string codeplugIdentifier;
  internal TextBlock StatusText;
  internal TextBlock CPSVersionText;
  internal TextBlock SerialNumText;
  internal TextBlock ModelText;
  internal TextBlock CodeplugIdentifierText;
  internal ProgressBar ProgBar;
  private bool _contentLoaded;

  public PageStatusBar()
  {
    this.InitializeComponent();
    AcpUI.Common.Utility.SetDirection((FrameworkElement) this);
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

  public string CodeplugIdentifier
  {
    get => this.codeplugIdentifier;
    set
    {
      this.codeplugIdentifier = value;
      this.OnPropertyChanged(nameof (CodeplugIdentifier));
    }
  }

  public string CPSVersion => AppInfoManager.AppVersion;

  public void OnPropertyChanged(string propertyName)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(propertyName));
  }

  public event PropertyChangedEventHandler PropertyChanged;

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/APXFamilyCPS;component/pagestatusbar.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.8.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.StatusText = (TextBlock) target;
        break;
      case 2:
        this.CPSVersionText = (TextBlock) target;
        break;
      case 3:
        this.SerialNumText = (TextBlock) target;
        break;
      case 4:
        this.ModelText = (TextBlock) target;
        break;
      case 5:
        this.CodeplugIdentifierText = (TextBlock) target;
        break;
      case 6:
        this.ProgBar = (ProgressBar) target;
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
