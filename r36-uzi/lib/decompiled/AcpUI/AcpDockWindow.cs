// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpDockWindow
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using DevComponents.WpfDock;
using System;
using System.Windows.Input;
using System.Windows.Threading;

#nullable disable
namespace AcpUI;

public class AcpDockWindow : DockWindow
{
  private DispatcherTimer timer;
  private bool bAutoRiseEnabled = true;

  internal bool IsAutoRiseEnabled
  {
    get => this.bAutoRiseEnabled;
    set => this.bAutoRiseEnabled = value;
  }

  public void StartTimer(int durationInMillSec)
  {
    if (this.timer == null)
    {
      this.timer = new DispatcherTimer(DispatcherPriority.Normal);
      this.timer.Tick += new EventHandler(this.OnPopupTimeOut);
    }
    else
      this.timer.Stop();
    this.timer.Interval = TimeSpan.FromMilliseconds((double) durationInMillSec);
    this.timer.Start();
  }

  internal void StopTimer()
  {
    if (this.timer == null)
      return;
    this.timer.Stop();
    this.timer.Tick -= new EventHandler(this.OnPopupTimeOut);
    this.timer = (DispatcherTimer) null;
  }

  private void OnPopupTimeOut(object sender, EventArgs e)
  {
    DockSite dockSite = this.GetDockSite();
    if (dockSite == null || this.AutoHidePopupWnd == null || dockSite.ActiveDockWindow != null && (dockSite.ActiveDockWindow == null || !(dockSite.ActiveDockWindow.Name != this.Name)) || this.IsMouseOver || !this.AutoHideOpen || this.IsMouseWithinAutoHidePopup())
      return;
    this.StopTimer();
    this.AutoHideOpen = false;
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    DockSite dockSite = this.GetDockSite();
    if ((dockSite.ActiveDockWindow == null || dockSite.ActiveDockWindow != null && dockSite.ActiveDockWindow.Name != this.Name) && this.IsAutoHide && !this.AutoHideOpen)
      this.StartTimer(5000);
    base.OnMouseEnter(e);
  }
}
