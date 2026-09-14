// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpUIDialogWindow`1
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUI.Common;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;

#nullable disable
namespace AcpUI;

public class AcpUIDialogWindow<T> : NavigationWindow
{
  private T dialogData;

  public AcpUIDialogWindow(PageFunction<T> page, T dialogData)
  {
    Utility.SetDirection((FrameworkElement) this);
    this.dialogData = dialogData;
    this.Title = page.Title;
    this.ShowsNavigationUI = false;
    this.SizeToContent = SizeToContent.WidthAndHeight;
    Brush resource = (Brush) this.TryFindResource((object) new ComponentResourceKey(typeof (System.Windows.Controls.Frame), (object) AcpColorKeys.FrameContentAreaBackground));
    if (resource != null)
      this.Background = resource;
    AcpUIDialogLauncher<T> content = new AcpUIDialogLauncher<T>(page);
    content.AcpUIDialogLauncherReturnEvent += new AcpUIDialogLauncherReturnEventHandler(this.LauncherReturn);
    this.Navigate((object) content);
  }

  public object DialogData => (object) this.dialogData;

  private void LauncherReturn(object sender, PageReturnEventArgs e) => this.dialogData = (T) e.Data;
}
