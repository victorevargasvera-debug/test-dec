// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpFlyInButton
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;

#nullable disable
namespace AcpUI;

public class AcpFlyInButton : AcpButton
{
  public static readonly DependencyProperty ShowDiffIconProperty = DependencyProperty.RegisterAttached(nameof (ShowDiffIcon), typeof (bool), typeof (AcpFlyInButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty ShowInvalidRecIconProperty = DependencyProperty.RegisterAttached(nameof (ShowInvalidRecIcon), typeof (bool), typeof (AcpFlyInButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));

  public bool ShowDiffIcon
  {
    get => (bool) this.GetValue(AcpFlyInButton.ShowDiffIconProperty);
    set => this.SetValue(AcpFlyInButton.ShowDiffIconProperty, (object) value);
  }

  public bool ShowInvalidRecIcon
  {
    get => (bool) this.GetValue(AcpFlyInButton.ShowInvalidRecIconProperty);
    set => this.SetValue(AcpFlyInButton.ShowInvalidRecIconProperty, (object) value);
  }
}
