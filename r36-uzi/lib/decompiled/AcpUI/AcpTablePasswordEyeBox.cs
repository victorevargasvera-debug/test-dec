// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTablePasswordEyeBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTablePasswordEyeBox : AcpPasswordEyeBox
{
  public AcpTablePasswordEyeBox()
  {
    this.MyPasswordBox.BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0);
    this.MyOpenPasswordBox.BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0);
    this.btnShowPassword.BorderThickness = new Thickness(0.0, 0.0, 0.0, 0.0);
  }

  protected override void OnPreviewKeyDown(KeyEventArgs e)
  {
    this.AcpTablePasswordEyeBox_PreviewKeyDown((object) null, e);
  }

  protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this.AcpTablePasswordEyeBox_PreviewMouseLeftButtonDown((object) null, e);
  }

  public void AcpTablePasswordEyeBox_PreviewKeyDown(object sender, KeyEventArgs e)
  {
    if (e.Key == Key.Tab)
      return;
    this.MyPasswordBox.CaretBrush = (Brush) Brushes.Black;
    this.MyPasswordBox.Focus();
  }

  public void AcpTablePasswordEyeBox_PreviewMouseLeftButtonDown(
    object sender,
    MouseButtonEventArgs e)
  {
    if (!this.IsFocused)
      this.MyPasswordBox.CaretBrush = (Brush) Brushes.Transparent;
    else
      this.MyPasswordBox.CaretBrush = (Brush) Brushes.Black;
  }

  protected override void OnGotFocus(RoutedEventArgs e)
  {
    this.MyPasswordBox.CaretBrush = (Brush) Brushes.Transparent;
    base.OnGotFocus(e);
  }
}
