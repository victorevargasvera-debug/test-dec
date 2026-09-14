// Decompiled with JetBrains decompiler
// Type: AcpFileHandlerLib.HeaderDataControl
// Assembly: AcpFileHandlerLib, Version=23.1.0.19, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: F211B494-0F50-48D2-88BA-E4CADB408707
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpFileHandlerLib.dll

using AcpCommonLib;
using AcpExceptionLib;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows.Forms;

#nullable disable
namespace AcpFileHandlerLib;

internal class HeaderDataControl : UserControl
{
  private IAcpFileHandler fileHandler;
  private IContainer components;
  private Label serialNumberLabel;
  private Label flashCodeLabel;
  private Label versionNumberLabel;
  private Label fileInformationLabel;
  private TextBox modelNumberTxtBox;
  private TextBox serialNumberTxtBox;
  private TextBox flashCodeTxtBox;
  private TextBox versionNumberTxtBox;
  private Label modelNumberLabel;
  private Panel panel1;
  private TextBox fileInfoTxtBox;
  private TableLayoutPanel tableLayoutPanel2;
  private TableLayoutPanel tableLayoutPanel1;

  public HeaderDataControl(DialogType dlgType)
  {
    this.InitializeComponent();
    this.fileHandler = (IAcpFileHandler) new AcpFileHandler();
    switch (dlgType)
    {
      case DialogType.SaveAs:
        this.fileInfoTxtBox.Enabled = true;
        break;
      case DialogType.Open:
        this.fileInfoTxtBox.ReadOnly = true;
        break;
    }
    if (!Thread.CurrentThread.CurrentUICulture.TextInfo.IsRightToLeft)
      return;
    this.RightToLeft = RightToLeft.Yes;
    if (!(Thread.CurrentThread.CurrentUICulture.TwoLetterISOLanguageName == "ar"))
      return;
    Thread.CurrentThread.CurrentUICulture.NumberFormat.DigitSubstitution = DigitShapes.None;
  }

  public string FileInfoField
  {
    get => this.fileInfoTxtBox.Text;
    set => this.fileInfoTxtBox.Text = value;
  }

  public string ModelNumberField
  {
    set => this.modelNumberTxtBox.Text = value;
  }

  public string SerialNumberField
  {
    set => this.serialNumberTxtBox.Text = value;
  }

  public string FlashCodeField
  {
    set
    {
      string lower = Thread.CurrentThread.CurrentCulture.Name.ToLower();
      if (!lower.StartsWith("ar") && !lower.StartsWith("he"))
        this.flashCodeTxtBox.Text = value;
      else
        this.flashCodeTxtBox.Text = Utility.reverseConverter(value);
    }
  }

  public string VersionNumberField
  {
    set => this.versionNumberTxtBox.Text = value;
  }

  public string SerialNumberLabel
  {
    set => this.serialNumberLabel.Text = value;
  }

  public string FlashCodeLabel
  {
    set => this.flashCodeLabel.Text = value;
  }

  public string VersionNumberLabel
  {
    set => this.versionNumberLabel.Text = value;
  }

  public string FileInformationLabel
  {
    set => this.fileInformationLabel.Text = value;
  }

  public string ModelNumberLabel
  {
    set => this.modelNumberLabel.Text = value;
  }

  public void OnFileChangedSafely(ref AcpFileHeader fileHeader, string filePath)
  {
    if (File.Exists(filePath))
    {
      try
      {
        fileHeader = this.fileHandler.ReadHeaderSafely(filePath);
        this.DisplayHeaderData(fileHeader);
      }
      catch (AcpException ex)
      {
        this.ClearHeaderData();
      }
    }
    else
      this.ClearHeaderData();
  }

  internal void DisplayHeaderData(AcpFileHeader fileHeader)
  {
    this.ModelNumberField = fileHeader.ModelNumber;
    this.SerialNumberField = fileHeader.SerialNumber;
    this.FlashCodeField = fileHeader.FlashCode;
    this.VersionNumberField = fileHeader.VersionNumber;
    this.FileInfoField = fileHeader.FileInfo;
  }

  internal void ClearHeaderData()
  {
    this.ModelNumberField = string.Empty;
    this.SerialNumberField = string.Empty;
    this.FlashCodeField = string.Empty;
    this.VersionNumberField = string.Empty;
    this.FileInfoField = string.Empty;
  }

  protected override void Dispose(bool disposing)
  {
    if (disposing && this.components != null)
      this.components.Dispose();
    base.Dispose(disposing);
  }

  private void InitializeComponent()
  {
    this.serialNumberLabel = new Label();
    this.flashCodeLabel = new Label();
    this.versionNumberLabel = new Label();
    this.fileInformationLabel = new Label();
    this.modelNumberTxtBox = new TextBox();
    this.serialNumberTxtBox = new TextBox();
    this.flashCodeTxtBox = new TextBox();
    this.versionNumberTxtBox = new TextBox();
    this.modelNumberLabel = new Label();
    this.panel1 = new Panel();
    this.tableLayoutPanel2 = new TableLayoutPanel();
    this.fileInfoTxtBox = new TextBox();
    this.tableLayoutPanel1 = new TableLayoutPanel();
    this.panel1.SuspendLayout();
    this.tableLayoutPanel2.SuspendLayout();
    this.tableLayoutPanel1.SuspendLayout();
    this.SuspendLayout();
    this.serialNumberLabel.AutoSize = true;
    this.serialNumberLabel.Location = new Point(256 /*0x0100*/, 0);
    this.serialNumberLabel.Name = "serialNumberLabel";
    this.serialNumberLabel.Size = new Size(79, 13);
    this.serialNumberLabel.TabIndex = 1;
    this.serialNumberLabel.Text = "Serial_Number:";
    this.flashCodeLabel.AutoSize = true;
    this.flashCodeLabel.Location = new Point(3, 29);
    this.flashCodeLabel.Name = "flashCodeLabel";
    this.flashCodeLabel.Size = new Size(66, 13);
    this.flashCodeLabel.TabIndex = 2;
    this.flashCodeLabel.Text = "Flash_Code:";
    this.versionNumberLabel.AutoSize = true;
    this.versionNumberLabel.Location = new Point(256 /*0x0100*/, 29);
    this.versionNumberLabel.Name = "versionNumberLabel";
    this.versionNumberLabel.Size = new Size(88, 13);
    this.versionNumberLabel.TabIndex = 3;
    this.versionNumberLabel.Text = "Version_Number:";
    this.fileInformationLabel.AutoSize = true;
    this.fileInformationLabel.Location = new Point(3, 0);
    this.fileInformationLabel.Name = "fileInformationLabel";
    this.fileInformationLabel.Size = new Size(84, 13);
    this.fileInformationLabel.TabIndex = 4;
    this.fileInformationLabel.Text = "File_Information:";
    this.modelNumberTxtBox.Enabled = false;
    this.modelNumberTxtBox.Location = new Point(106, 3);
    this.modelNumberTxtBox.Name = "modelNumberTxtBox";
    this.modelNumberTxtBox.Size = new Size(142, 20);
    this.modelNumberTxtBox.TabIndex = 5;
    this.serialNumberTxtBox.Enabled = false;
    this.serialNumberTxtBox.Location = new Point(356, 3);
    this.serialNumberTxtBox.Name = "serialNumberTxtBox";
    this.serialNumberTxtBox.Size = new Size(142, 20);
    this.serialNumberTxtBox.TabIndex = 6;
    this.flashCodeTxtBox.Enabled = false;
    this.flashCodeTxtBox.Location = new Point(106, 32 /*0x20*/);
    this.flashCodeTxtBox.Name = "flashCodeTxtBox";
    this.flashCodeTxtBox.Size = new Size(142, 20);
    this.flashCodeTxtBox.TabIndex = 7;
    this.versionNumberTxtBox.Enabled = false;
    this.versionNumberTxtBox.Location = new Point(356, 32 /*0x20*/);
    this.versionNumberTxtBox.Name = "versionNumberTxtBox";
    this.versionNumberTxtBox.Size = new Size(142, 20);
    this.versionNumberTxtBox.TabIndex = 8;
    this.modelNumberLabel.AutoSize = true;
    this.modelNumberLabel.Location = new Point(3, 0);
    this.modelNumberLabel.Name = "modelNumberLabel";
    this.modelNumberLabel.Size = new Size(82, 13);
    this.modelNumberLabel.TabIndex = 0;
    this.modelNumberLabel.Text = "Model_Number:";
    this.panel1.Controls.Add((Control) this.tableLayoutPanel2);
    this.panel1.Controls.Add((Control) this.tableLayoutPanel1);
    this.panel1.Location = new Point(0, 0);
    this.panel1.Name = "panel1";
    this.panel1.Size = new Size(512 /*0x0200*/, 142);
    this.panel1.TabIndex = 10;
    this.tableLayoutPanel2.ColumnCount = 2;
    this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.23576f));
    this.tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 79.76424f));
    this.tableLayoutPanel2.Controls.Add((Control) this.fileInformationLabel, 0, 0);
    this.tableLayoutPanel2.Controls.Add((Control) this.fileInfoTxtBox, 1, 0);
    this.tableLayoutPanel2.Location = new Point(1, 67);
    this.tableLayoutPanel2.Name = "tableLayoutPanel2";
    this.tableLayoutPanel2.RowCount = 1;
    this.tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50f));
    this.tableLayoutPanel2.Size = new Size(509, 72);
    this.tableLayoutPanel2.TabIndex = 11;
    this.fileInfoTxtBox.Location = new Point(105, 3);
    this.fileInfoTxtBox.Multiline = true;
    this.fileInfoTxtBox.Name = "fileInfoTxtBox";
    this.fileInfoTxtBox.ScrollBars = ScrollBars.Vertical;
    this.fileInfoTxtBox.Size = new Size(392, 64 /*0x40*/);
    this.fileInfoTxtBox.TabIndex = 9;
    this.tableLayoutPanel1.ColumnCount = 4;
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.76923f));
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 59.23077f));
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100f));
    this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 156f));
    this.tableLayoutPanel1.Controls.Add((Control) this.modelNumberLabel, 0, 0);
    this.tableLayoutPanel1.Controls.Add((Control) this.modelNumberTxtBox, 1, 0);
    this.tableLayoutPanel1.Controls.Add((Control) this.serialNumberLabel, 2, 0);
    this.tableLayoutPanel1.Controls.Add((Control) this.serialNumberTxtBox, 3, 0);
    this.tableLayoutPanel1.Controls.Add((Control) this.versionNumberLabel, 2, 1);
    this.tableLayoutPanel1.Controls.Add((Control) this.flashCodeLabel, 0, 1);
    this.tableLayoutPanel1.Controls.Add((Control) this.flashCodeTxtBox, 1, 1);
    this.tableLayoutPanel1.Controls.Add((Control) this.versionNumberTxtBox, 3, 1);
    this.tableLayoutPanel1.Location = new Point(0, 4);
    this.tableLayoutPanel1.Name = "tableLayoutPanel1";
    this.tableLayoutPanel1.RowCount = 2;
    this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50.74627f));
    this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 49.25373f));
    this.tableLayoutPanel1.Size = new Size(510, 58);
    this.tableLayoutPanel1.TabIndex = 10;
    this.AutoScaleDimensions = new SizeF(6f, 13f);
    this.AutoScaleMode = AutoScaleMode.Font;
    this.Controls.Add((Control) this.panel1);
    this.Name = nameof (HeaderDataControl);
    this.Size = new Size(516, 138);
    this.panel1.ResumeLayout(false);
    this.tableLayoutPanel2.ResumeLayout(false);
    this.tableLayoutPanel2.PerformLayout();
    this.tableLayoutPanel1.ResumeLayout(false);
    this.tableLayoutPanel1.PerformLayout();
    this.ResumeLayout(false);
  }
}
