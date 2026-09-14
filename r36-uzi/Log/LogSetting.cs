// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Log.LogSetting
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System.ComponentModel;

#nullable disable
namespace MackinawCPS.Log;

public class LogSetting : INotifyPropertyChanged
{
  private bool uploadToServer;
  private RestartOptions restartOption;
  private bool hideDialogChecked;

  public bool UploadToServer
  {
    get => this.uploadToServer;
    set
    {
      if (value == this.uploadToServer)
        return;
      this.uploadToServer = value;
      this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (UploadToServer)));
    }
  }

  public RestartOptions RestartOption
  {
    get => this.restartOption;
    set
    {
      if (value == this.restartOption)
        return;
      this.restartOption = value;
      this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (RestartOption)));
    }
  }

  public bool HideDialogChecked
  {
    get => this.hideDialogChecked;
    set
    {
      if (value == this.hideDialogChecked)
        return;
      this.hideDialogChecked = value;
      this.OnPropertyChanged(new PropertyChangedEventArgs(nameof (HideDialogChecked)));
    }
  }

  public event PropertyChangedEventHandler PropertyChanged;

  public void OnPropertyChanged(PropertyChangedEventArgs e)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, e);
  }
}
