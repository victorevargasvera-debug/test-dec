// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpViewModel
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

#nullable disable
namespace AcpUI;

public class AcpViewModel
{
  public AcpUpDownCommand UpDownCommand { get; set; }

  public AcpKeyCommand KeyCommand { get; set; }

  public AcpMouseLeftButtonDownCommand MouseLeftButtonDownCommand { get; set; }

  public AcpViewModel()
  {
    this.UpDownCommand = new AcpUpDownCommand();
    this.KeyCommand = new AcpKeyCommand();
    this.MouseLeftButtonDownCommand = new AcpMouseLeftButtonDownCommand();
  }
}
