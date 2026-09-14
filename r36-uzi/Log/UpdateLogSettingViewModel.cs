// Decompiled with JetBrains decompiler
// Type: MackinawCPS.Log.UpdateLogSettingViewModel
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using CommonResources;
using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Windows;

#nullable disable
namespace MackinawCPS.Log;

internal class UpdateLogSettingViewModel
{
  private UpdateLogSettingView _view;

  internal UpdateLogSettingViewModel(UpdateLogSettingView view, LogSetting logSetting)
  {
    this._view = view;
    this.LogSetting = logSetting;
    this.UpdateLogSettingCommand = new CpsCommand(new Action<object>(this.UpdateLogSetting), new Func<object, bool>(this.CanUpdateLogSetting));
  }

  public LogSetting LogSetting { get; }

  public CpsCommand UpdateLogSettingCommand { get; }

  private void UpdateLogSetting(object logSetting)
  {
    try
    {
      WindowMain mainWindow = (WindowMain) Application.Current.MainWindow;
      if (this.LogSetting.HideDialogChecked != mainWindow.settingsSavedOnAppExit.HideLogUploadDialog)
      {
        mainWindow.settingsSavedOnAppExit.HideLogUploadDialog = this.LogSetting.HideDialogChecked;
        mainWindow.settingsSavedOnAppExit.Save();
      }
      bool flag = bool.Parse((string) logSetting);
      bool uploadToServer = mainWindow.settingsSavedOnAppExit.UploadToServer;
      if (flag != uploadToServer)
      {
        this.LogSetting.UploadToServer = flag;
        mainWindow.settingsSavedOnAppExit.UploadToServer = flag;
        mainWindow.settingsSavedOnAppExit.Save();
        if (this.LogSetting.RestartOption == RestartOptions.Now)
        {
          string fileName = Process.GetCurrentProcess().MainModule.FileName;
          Process.Start(new ProcessStartInfo(Path.Combine(Assembly.GetEntryAssembly().Location, fileName)));
          Environment.Exit(0);
        }
        else
        {
          int num = (int) MessageBox.Show(AppResources.APXCPS_Logging_Change_Notification, AppResources.APXCPS_Log);
        }
      }
    }
    catch (Exception ex)
    {
      int num = (int) MessageBox.Show("Error Updating LogUpload Settings - " + ex.Message);
    }
    ((Window) this._view.Parent).Close();
  }

  private bool CanUpdateLogSetting(object parameter) => true;
}
