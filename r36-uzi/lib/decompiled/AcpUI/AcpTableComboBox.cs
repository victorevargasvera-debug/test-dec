// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpTableComboBox
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpTableComboBox : AcpComboBox
{
  protected override void OnDropDownOpened(EventArgs e)
  {
    if (this.IsFocused)
      this.IsDropDownOpen = true;
    else
      this.IsDropDownOpen = false;
    base.OnDropDownOpened(e);
  }

  protected override void OnGotFocus(RoutedEventArgs e)
  {
    Keyboard.Focus((IInputElement) this);
    base.OnGotFocus(e);
  }

  protected override void OnPreviewKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Space || e.Key == Key.Return)
    {
      if (this.IsDropDownOpen)
        this.IsDropDownOpen = false;
      else
        this.IsDropDownOpen = true;
    }
    new AcpTableTextBoxBase().AcpTableTextBox_PreviewKeyDown((object) null, e);
  }

  private void AcpTableComboBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
  {
  }

  private void AcpTableComboBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
  {
  }
}
