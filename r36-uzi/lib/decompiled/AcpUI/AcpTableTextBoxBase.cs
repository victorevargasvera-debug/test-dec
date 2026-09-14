// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBoxBase
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpUI.Common;
using Infragistics.Windows.Editors;
using System.Globalization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTableTextBoxBase : AcpTextBox
{
  private FocusNavigationDirection tabDirection = FocusNavigationDirection.Right;

  public AcpTableTextBoxBase()
  {
    if (!CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
      return;
    this.tabDirection = FocusNavigationDirection.Left;
  }

  protected override void OnPreviewKeyDown(KeyEventArgs e)
  {
    this.AcpTableTextBox_PreviewKeyDown((object) null, e);
  }

  protected override void OnPreviewMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this.AcpTableTextBox_PreviewMouseLeftButtonDown((object) null, e);
  }

  public void AcpTableTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
  {
    if (e.Key == Key.Tab)
      return;
    this.CaretBrush = (Brush) Brushes.Black;
    if (!this.IsMasked)
      return;
    if (e.Key == Key.Return)
      Utility.SaveFieldWithFocus();
    XamMaskedEditor visualChild = this.FindVisualChild<XamMaskedEditor>((DependencyObject) this);
    if (visualChild != null)
      ((UIElement) visualChild).Focus();
    else
      this.MoveFocus(new TraversalRequest(FocusNavigationDirection.Down));
  }

  public void AcpTableTextBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
    if (!this.IsFocused)
      this.CaretBrush = (Brush) Brushes.Transparent;
    else
      this.CaretBrush = (Brush) Brushes.Black;
  }
}
