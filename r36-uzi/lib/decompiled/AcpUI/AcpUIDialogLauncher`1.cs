// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpUIDialogLauncher`1
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Windows.Navigation;

#nullable disable
namespace AcpUI;

internal class AcpUIDialogLauncher<T> : PageFunction<T>
{
  private PageFunction<T> page;

  public event AcpUIDialogLauncherReturnEventHandler AcpUIDialogLauncherReturnEvent;

  internal AcpUIDialogLauncher(PageFunction<T> page) => this.page = page;

  protected override void Start()
  {
    base.Start();
    this.KeepAlive = true;
    this.page.Return += new ReturnEventHandler<T>(this.PageReturn);
    this.NavigationService.Navigate((object) this.page);
  }

  private void OnLoaded(object sender, EventArgs e)
  {
  }

  internal void PageReturn(object sender, ReturnEventArgs<T> e)
  {
    if (this.AcpUIDialogLauncherReturnEvent != null && e != null)
      this.AcpUIDialogLauncherReturnEvent((object) this, new PageReturnEventArgs(true, (object) e.Result));
    this.OnReturn((ReturnEventArgs<T>) null);
  }
}
