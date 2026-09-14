// Decompiled with JetBrains decompiler
// Type: MackinawCPS.InitializationScreen.SplashScreen
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using Common;
using CommonResources;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Resources;
using System.Windows.Forms;
using System.Windows.Forms.Layout;

#nullable disable
namespace MackinawCPS.InitializationScreen;

public class SplashScreen : Form
{
  private SplashWindowStates state;
  private TimeSpan _Min;
  private TimeSpan _Max;
  private bool closeRequested;
  private IContainer components;
  private Label label2;
  private TableLayoutPanel tableLayoutPanel2;
  private Label label3;
  private Timer timer1;
  private Label versionLabel;
  private Panel panel1;
  private Label timingLabel;

  public SplashScreen()
    : this(new TimeSpan(0, 0, 5), new TimeSpan(0, 0, 10), 10, "")
  {
  }

  public SplashScreen(TimeSpan min, TimeSpan max, int radius, string productVersionText)
  {
    int num1 = radius;
    int num2 = num1 * 2;
    this._Min = min;
    this._Max = max;
    this.closeRequested = false;
    this.InitializeComponent();
    this.Opacity = 0.99;
    this.timer1.Tick += new EventHandler(this.timer1_Tick);
    if (this._Min.Equals(TimeSpan.Zero))
    {
      if (!this._Max.Equals(TimeSpan.Zero))
      {
        this._Min = this._Max;
        this.timer1.Interval = (int) this._Min.TotalMilliseconds;
      }
    }
    else
      this.timer1.Interval = (int) min.TotalMilliseconds;
    this.Load += new EventHandler(this.SplashScreen_Load);
    this.panel1.MouseClick += new MouseEventHandler(this.SplashScreen_MouseClick);
    foreach (Control control in (ArrangedElementCollection) this.panel1.Controls)
      control.MouseClick += new MouseEventHandler(this.SplashScreen_MouseClick);
    this.SuspendLayout();
    if (num1 > 0)
    {
      int x1 = num1;
      int x2 = this.Size.Width - num1;
      int y1 = num1;
      int y2 = this.Size.Height - num1;
      Point location1 = new Point(0, 0);
      Point location2 = new Point(this.Width - 2 * num1, 0);
      Point location3 = new Point(0, this.Height - 2 * num1);
      Point location4 = new Point(this.Width - 2 * num1, this.Height - 2 * num1);
      GraphicsPath path = (GraphicsPath) null;
      try
      {
        path = new GraphicsPath();
        path.StartFigure();
        path.AddArc(new Rectangle(location1, new Size(num2, num2)), 180f, 90f);
        path.AddLine(new Point(x1, 0), new Point(x2, 0));
        path.AddArc(new Rectangle(location2, new Size(num2, num2)), 270f, 90f);
        path.AddLine(new Point(this.Width, y1), new Point(this.Width, y2));
        path.AddArc(new Rectangle(location4, new Size(num2, num2)), 0.0f, 90f);
        path.AddLine(new Point(x1, this.Height), new Point(x2, this.Height));
        path.AddArc(new Rectangle(location3, new Size(num2, num2)), 90f, 90f);
        path.CloseFigure();
        this.Region = new Region(path);
      }
      finally
      {
        path?.Dispose();
      }
    }
    this.versionLabel.Text = "";
    if (!string.IsNullOrEmpty(productVersionText))
      this.versionLabel.Text = productVersionText;
    this.ResumeLayout(true);
  }

  public SplashScreen(
    TimeSpan min,
    TimeSpan max,
    int radius,
    string productVersionText,
    string Year)
    : this(min, max, radius, productVersionText)
  {
    this.label2.Text = $"© {Year} MOTOROLA SOLUTIONS, INC.  PROTECTED BY U.S. AND INTERNATIONAL COPYRIGHT LAWS";
  }

  private bool CheckCloseWindowRequest()
  {
    bool flag = false;
    if (this.closeRequested && this.state == SplashWindowStates.SHOWN_MINIMUM_TIME_HIT)
      flag = true;
    return flag;
  }

  internal void CloseWindow(bool forceClose)
  {
    if (!this.InvokeRequired)
      return;
    this.Invoke((Delegate) new SplashScreen.BoolDelegate(this.HandleAppCloseWindowRequest), (object) forceClose);
  }

  private void HandleAppCloseWindowRequest(bool forceClose)
  {
    this.closeRequested = true;
    if (this.state == SplashWindowStates.SHOWN)
    {
      if (!forceClose)
        return;
      this.timer1.Stop();
      this.setupFadeOut();
    }
    else if (this.state == SplashWindowStates.SHOWN_MINIMUM_TIME_HIT)
    {
      this.timer1.Stop();
      this.setupFadeOut();
    }
    else
    {
      if (this.state != SplashWindowStates.WAIT_FOR_ACTIVATE)
        return;
      this.state = SplashWindowStates.CLOSED;
    }
  }

  private void CloseAndCleanupWindow()
  {
    this.timer1.Stop();
    this.timer1.Dispose();
    this.state = SplashWindowStates.CLOSED;
    this.Close();
  }

  protected override void OnClosing(CancelEventArgs e) => base.OnClosing(e);

  private void timer1_Tick(object sender, EventArgs e)
  {
    this.timer1.Stop();
    if (this.state == SplashWindowStates.SHOWN)
    {
      this.state = SplashWindowStates.SHOWN_MINIMUM_TIME_HIT;
      if (!this.CheckCloseWindowRequest())
      {
        TimeSpan timeSpan = TimeSpan.Zero;
        try
        {
          if (this._Min > TimeSpan.Zero)
          {
            if (this._Max > this._Min)
              timeSpan = this._Max.Subtract(this._Min);
          }
        }
        catch (Exception ex)
        {
        }
        if (!timeSpan.Equals(TimeSpan.Zero))
        {
          this.timer1.Interval = (int) timeSpan.TotalMilliseconds;
          this.timer1.Start();
        }
        else
          this.setupFadeOut();
      }
      else
        this.setupFadeOut();
    }
    else if (this.state == SplashWindowStates.SHOWN_MINIMUM_TIME_HIT)
      this.setupFadeOut();
    else if (this.state == SplashWindowStates.CLOSING_FADE_DELAY)
    {
      this.timer1.Interval = 30;
      this.state = SplashWindowStates.CLOSING_WITH_FADE;
      this.timer1.Start();
    }
    else
    {
      if (this.state != SplashWindowStates.CLOSING_WITH_FADE || !this.HandleFadeOutTick())
        return;
      this.timer1.Start();
    }
  }

  private void setupFadeOut()
  {
    if (this.state != SplashWindowStates.CLOSING_FADE_DELAY && this.state != SplashWindowStates.CLOSING_WITH_FADE)
      this.state = SplashWindowStates.CLOSING_FADE_DELAY;
    this.timer1.Interval = 30;
    this.timer1.Start();
  }

  private bool HandleFadeOutTick()
  {
    bool flag = false;
    if (this.Opacity >= 0.1)
    {
      this.Opacity -= 0.05;
      flag = true;
    }
    else
      this.CloseAndCleanupWindow();
    return flag;
  }

  protected override void OnShown(EventArgs e) => base.OnShown(e);

  private void SplashScreen_Load(object sender, EventArgs e)
  {
    if (!Product.IsVertex())
      return;
    this.label2.Text = AppResources.Vertex_Standard_LMR_Inc_Protected_By_US_And_International_Copyright_Law;
    this.label2.ForeColor = Color.White;
    this.label2.BackColor = Color.Transparent;
    this.versionLabel.ForeColor = Color.WhiteSmoke;
    this.BackgroundImage = (Image) new ResourceManager(typeof (SplashScreen)).GetObject("SplashScreenBackground_Vertex");
  }

  private void SplashScreen_MouseClick(object sender, MouseEventArgs e)
  {
    if (this.state != SplashWindowStates.SHOWN && this.state != SplashWindowStates.SHOWN_MINIMUM_TIME_HIT && this.state != SplashWindowStates.SHOWN_MAXIMUM_TIME_HIT)
      return;
    this.CloseAndCleanupWindow();
  }

  protected override void OnActivated(EventArgs e)
  {
    base.OnActivated(e);
    if (this.state == SplashWindowStates.WAIT_FOR_ACTIVATE)
    {
      this.state = SplashWindowStates.SHOWN;
      this.timer1.Start();
    }
    else
    {
      int state = (int) this.state;
    }
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.components = (IContainer) new System.ComponentModel.Container();
    ComponentResourceManager componentResourceManager = new ComponentResourceManager(typeof (SplashScreen));
    this.timer1 = new Timer(this.components);
    this.tableLayoutPanel2 = new TableLayoutPanel();
    this.label3 = new Label();
    this.label2 = new Label();
    this.versionLabel = new Label();
    this.panel1 = new Panel();
    this.timingLabel = new Label();
    this.tableLayoutPanel2.SuspendLayout();
    this.panel1.SuspendLayout();
    this.SuspendLayout();
    this.tableLayoutPanel2.BackColor = Color.Transparent;
    this.tableLayoutPanel2.ColumnCount = 1;
    this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f));
    this.tableLayoutPanel2.Controls.Add((Control) this.label3, 0, 0);
    this.tableLayoutPanel2.Dock = DockStyle.Fill;
    this.tableLayoutPanel2.Location = new Point(0, 0);
    this.tableLayoutPanel2.Name = "tableLayoutPanel2";
    this.tableLayoutPanel2.RowCount = 2;
    this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel2.RowStyles.Add(new RowStyle());
    this.tableLayoutPanel2.Size = new Size(676, 68);
    this.tableLayoutPanel2.TabIndex = 1;
    this.label3.AutoSize = true;
    this.label3.Dock = DockStyle.Bottom;
    this.label3.Font = new Font("Impact", 42f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.label3.ForeColor = SystemColors.ControlLight;
    this.label3.Location = new Point(3, 0);
    this.label3.Name = "label3";
    this.label3.Size = new Size(670, 68);
    this.label3.TabIndex = 0;
    this.label3.Text = "APX CPS";
    this.label3.TextAlign = ContentAlignment.MiddleCenter;
    this.label2.BackColor = Color.Black;
    this.label2.Font = new Font("Microsoft Sans Serif", 6.5f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.label2.ForeColor = SystemColors.InactiveCaption;
    this.label2.Location = new Point(25, 397);
    this.label2.Name = "label2";
    this.label2.Size = new Size(525, 10);
    this.label2.TabIndex = 0;
    this.label2.Text = "© 2019 MOTOROLA SOLUTIONS, INC.  PROTECTED BY U.S. AND INTERNATIONAL COPYRIGHT LAWS";
    this.label2.TextAlign = ContentAlignment.MiddleCenter;
    this.versionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.versionLabel.AutoSize = true;
    this.versionLabel.Font = new Font("Microsoft Sans Serif", 9.75f, FontStyle.Regular, GraphicsUnit.Point, (byte) 0);
    this.versionLabel.ForeColor = Color.FromArgb(0, 175, 209);
    this.versionLabel.Location = new Point(415, 298);
    this.versionLabel.Name = "versionLabel";
    this.versionLabel.Size = new Size(135, 16 /*0x10*/);
    this.versionLabel.TabIndex = 0;
    this.versionLabel.Text = "Version: XX.XX.XX.YY";
    this.panel1.BackColor = Color.Transparent;
    this.panel1.Controls.Add((Control) this.timingLabel);
    this.panel1.Controls.Add((Control) this.versionLabel);
    this.panel1.Controls.Add((Control) this.label2);
    this.panel1.Dock = DockStyle.Fill;
    this.panel1.Location = new Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(578, 439);
    this.panel1.TabIndex = 1;
    this.timingLabel.AutoSize = true;
    this.timingLabel.ForeColor = SystemColors.Window;
    this.timingLabel.Location = new Point(22, 357);
    this.timingLabel.Name = "timingLabel";
    this.timingLabel.Size = new Size(104, 13);
    this.timingLabel.TabIndex = 1;
    this.timingLabel.Text = "Timing Label Hidden";
    this.timingLabel.Visible = false;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.BackgroundImage = (Image) componentResourceManager.GetObject("$this.BackgroundImage");
    this.BackgroundImageLayout = ImageLayout.Stretch;
    this.ClientSize = new Size(578, 439);
    this.Controls.Add((Control) this.panel1);
    this.DoubleBuffered = true;
    this.FormBorderStyle = FormBorderStyle.None;
    this.Name = nameof (SplashScreen);
    this.Opacity = 0.99;
    this.ShowInTaskbar = false;
    this.StartPosition = FormStartPosition.CenterScreen;
    this.Text = "SplashScreen2";
    this.TopMost = true;
    this.tableLayoutPanel2.ResumeLayout(false);
    this.tableLayoutPanel2.PerformLayout();
    this.panel1.ResumeLayout(false);
    this.panel1.PerformLayout();
    this.ResumeLayout(false);
  }

  private delegate void NoArgsDelegate();

  private delegate void BoolDelegate(bool b);

  private delegate void UpdateTextDelegate(string s);

  private delegate void UpdateProgressDelegate(int start_value, int stop_value, int current_value);
}
