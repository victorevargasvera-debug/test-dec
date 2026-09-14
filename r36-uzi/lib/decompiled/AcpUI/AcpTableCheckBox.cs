// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableCheckBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpTableCheckBox : AcpCheckBox
{
  public AcpTableCheckBox() => this.HorizontalAlignment = HorizontalAlignment.Center;

  protected override void OnPreviewKeyDown(KeyEventArgs e)
  {
    new AcpTableTextBoxBase().AcpTableTextBox_PreviewKeyDown((object) null, e);
  }
}
