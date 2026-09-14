// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableTextBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using Infragistics.Windows.Editors;
using System.Windows;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpTableTextBox : AcpTableTextBoxBase
{
  protected override void OnGotFocus(RoutedEventArgs e)
  {
    XamMaskedEditor visualChild = this.FindVisualChild<XamMaskedEditor>((DependencyObject) this);
    if (visualChild != null)
      ((ValueEditor) visualChild).IsInEditMode = false;
    else
      this.CaretBrush = (Brush) Brushes.Transparent;
    base.OnGotFocus(e);
  }
}
