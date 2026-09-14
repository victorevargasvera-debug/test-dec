// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpMouseLeftButtonDownCommand
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using Infragistics.Windows.Editors;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace AcpUI;

public class AcpMouseLeftButtonDownCommand : ICommand
{
  public bool CanExecute(object parameter) => true;

  public event EventHandler CanExecuteChanged;

  public void Execute(object parameter)
  {
    try
    {
      AcpCommandParameter commandParameter = parameter as AcpCommandParameter;
      if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxSpinnerDecHex))
      {
        AcpTableTextBoxSpinnerDecHex parameter1 = commandParameter.Parameter as AcpTableTextBoxSpinnerDecHex;
        AcpTableTextBoxBase textBoxMemberDec = parameter1.AcpTextBoxMemberDec;
        AcpTableTextBoxBase textBoxMemberHex = parameter1.AcpTextBoxMemberHex;
        XamMaskedEditor visualChild1 = textBoxMemberDec.FindVisualChild<XamMaskedEditor>((DependencyObject) textBoxMemberDec);
        XamMaskedEditor visualChild2 = textBoxMemberHex.FindVisualChild<XamMaskedEditor>((DependencyObject) textBoxMemberHex);
        XamMaskedEditor elementUnderMouse = AcpTextBox.GetElementUnderMouse<XamMaskedEditor>();
        if (visualChild1 == null || visualChild2 == null || !((UIElement) visualChild1).IsFocused && !((UIElement) visualChild2).IsFocused && !((ValueEditor) visualChild1).IsInEditMode && !((ValueEditor) visualChild2).IsInEditMode)
          return;
        ((ValueEditor) elementUnderMouse).IsInEditMode = true;
      }
      else if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxSpinner))
      {
        AcpTableTextBoxBase acpTextBoxMember = (commandParameter.Parameter as AcpTableTextBoxSpinner).AcpTextBoxMember;
        XamMaskedEditor visualChild = acpTextBoxMember.FindVisualChild<XamMaskedEditor>((DependencyObject) acpTextBoxMember);
        if (visualChild != null)
        {
          if (!((UIElement) visualChild).IsFocused && !((ValueEditor) visualChild).IsInEditMode)
            return;
          ((ValueEditor) visualChild).IsInEditMode = true;
        }
        else
          acpTextBoxMember.CaretBrush = (Brush) Brushes.Black;
      }
      else if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxDecHex))
      {
        AcpTableTextBoxDecHex parameter2 = commandParameter.Parameter as AcpTableTextBoxDecHex;
        AcpTableTextBoxBase textBoxMemberDec = parameter2.AcpTextBoxMemberDec;
        AcpTableTextBoxBase textBoxMemberHex = parameter2.AcpTextBoxMemberHex;
        XamMaskedEditor visualChild3 = textBoxMemberDec.FindVisualChild<XamMaskedEditor>((DependencyObject) textBoxMemberDec);
        XamMaskedEditor visualChild4 = textBoxMemberHex.FindVisualChild<XamMaskedEditor>((DependencyObject) textBoxMemberHex);
        XamMaskedEditor elementUnderMouse = AcpTextBox.GetElementUnderMouse<XamMaskedEditor>();
        if (visualChild3 == null || visualChild4 == null || !((UIElement) visualChild3).IsFocused && !((UIElement) visualChild4).IsFocused && !((ValueEditor) visualChild3).IsInEditMode && !((ValueEditor) visualChild4).IsInEditMode)
          return;
        ((ValueEditor) elementUnderMouse).IsInEditMode = true;
      }
      else if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxBase))
      {
        object parameter3 = commandParameter.Parameter;
        if (!(commandParameter.Sender is XamMaskedEditor sender) || !((UIElement) sender).IsFocused && !((ValueEditor) sender).IsInEditMode)
          return;
        ((ValueEditor) sender).IsInEditMode = true;
      }
      else
      {
        if (!(commandParameter.Parameter.GetType() == typeof (AcpTableTextBox)))
          return;
        object parameter4 = commandParameter.Parameter;
        if (!(commandParameter.Sender is XamMaskedEditor sender) || !((UIElement) sender).IsFocused && !((ValueEditor) sender).IsInEditMode)
          return;
        ((ValueEditor) sender).IsInEditMode = true;
      }
    }
    catch
    {
    }
  }
}
