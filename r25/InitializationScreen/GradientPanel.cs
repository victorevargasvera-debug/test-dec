// Decompiled with JetBrains decompiler
// Type: MackinawCPS.InitializationScreen.GradientPanel
// Assembly: APXFamilyCPS, Version=15.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 7983BD42-76AB-479D-8966-B7B635E0E28A
// Assembly location: C:\Program Files (x86)\Motorola\APX Dpt 25\APXFamilyCPS.exe

using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#nullable disable
namespace MackinawCPS.InitializationScreen;

public class GradientPanel : Panel
{
  private IContainer components = (IContainer) null;

  public GradientPanel() => this.InitializeComponent();

  protected override void OnPaint(PaintEventArgs pe) => base.OnPaint(pe);

  protected override void OnPaintBackground(PaintEventArgs e)
  {
    base.OnPaintBackground(e);
    LinearGradientBrush linearGradientBrush = (LinearGradientBrush) null;
    try
    {
      linearGradientBrush = new LinearGradientBrush(new Rectangle(new Point(0, 0), this.Size), Color.FromArgb(0, (int) byte.MaxValue, (int) byte.MaxValue, (int) byte.MaxValue), Color.FromArgb((int) byte.MaxValue, 0, 0, 0), LinearGradientMode.Vertical);
      e.Graphics.FillRectangle((Brush) linearGradientBrush, new Rectangle(new Point(0, 0), this.Size));
    }
    finally
    {
      linearGradientBrush?.Dispose();
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent() => this.components = (IContainer) new System.ComponentModel.Container();
}
