// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBoxCustomDecHex
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;

#nullable disable
namespace AcpUI;

public class AcpTableTextBoxCustomDecHex : AcpTableTextBoxDecHex
{
  private string customValueMaskType;

  public AcpTableTextBoxCustomDecHex()
  {
    this.Loaded += new RoutedEventHandler(this.AcpTextBoxCustomDecHex_Loaded);
  }

  public string CustomValueMaskType
  {
    get => this.customValueMaskType;
    set => this.customValueMaskType = value;
  }

  private void AcpTextBoxCustomDecHex_Loaded(object sender, RoutedEventArgs e)
  {
    if (AcpTextBox.DisableMask)
    {
      this.AcpTextBoxMemberDec.MaskType = (string) null;
      this.AcpTextBoxMemberHex.MaskType = (string) null;
    }
    else
    {
      this.AcpTextBoxMemberDec.MaskType = $"{{char:10:0-9{this.CustomValueMaskType}}}";
      this.AcpTextBoxMemberHex.MaskType = $"{{char:8:0-9a-fA-F{this.CustomValueMaskType}}}";
    }
  }
}
