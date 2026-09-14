// Decompiled with JetBrains decompiler
// Type: AcpUI.CustomView.CustomViewCreationInfo
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

#nullable disable
namespace AcpUI.CustomView;

public class CustomViewCreationInfo
{
  public CustomViewCreationInfo(string customViewFileName, string customViewFileBaseline)
  {
    this.CustomViewFileName = customViewFileName;
    this.CustomViewFileBaseline = customViewFileBaseline;
  }

  public string CustomViewFileName { get; set; }

  public string CustomViewFileBaseline { get; set; }
}
