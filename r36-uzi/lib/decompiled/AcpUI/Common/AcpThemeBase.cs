// Decompiled with JetBrains decompiler
// Type: AcpUI.Common.AcpThemeBase
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.ComponentModel;
using System.Windows;

#nullable disable
namespace AcpUI.Common;

public class AcpThemeBase : FrameworkElement, INotifyPropertyChanged
{
  private string _themeName;

  public string ThemeName
  {
    get => this._themeName;
    set => this._themeName = value;
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public void FirePropertyChanged(string name)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(name));
  }

  public AcpThemeBase()
  {
    this.Loaded += new RoutedEventHandler(this.AcpThemeBase_Loaded);
    this.Unloaded += new RoutedEventHandler(this.AcpThemeBase_Unloaded);
  }

  private void AcpThemeBase_Unloaded(object sender, RoutedEventArgs e)
  {
    Utility.ThemeChangedEvent -= new ThemeChangedEventHandler(this.ThemeChangedEvent);
  }

  private void AcpThemeBase_Loaded(object sender, RoutedEventArgs e)
  {
    Utility.ThemeChangedEvent += new ThemeChangedEventHandler(this.ThemeChangedEvent);
  }

  private void ThemeChangedEvent(object sender, ThemeChangedEventArgs e)
  {
    this._themeName = e.ThemeName;
    this.FirePropertyChanged("ThemeName");
  }
}
