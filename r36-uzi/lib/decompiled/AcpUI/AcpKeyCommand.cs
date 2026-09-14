// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpKeyCommand
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.Common;
using System;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpKeyCommand : ICommand
{
  public bool CanExecute(object parameter) => true;

  public event EventHandler CanExecuteChanged;

  public void Execute(object parameter)
  {
    AcpCommandParameter commandParameter = parameter as AcpCommandParameter;
    if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxSpinnerDecHex))
    {
      AcpFieldBase myBlObject = (commandParameter.Parameter as AcpTableTextBoxSpinnerDecHex).MyBLObject;
      StepUpDownUtility.OnKeyPress(commandParameter.EventArgs as KeyEventArgs, myBlObject);
    }
    else if (commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxSpinner))
    {
      AcpFieldBase myBlObject = (commandParameter.Parameter as AcpTableTextBoxSpinner).MyBLObject;
      StepUpDownUtility.OnKeyPress(commandParameter.EventArgs as KeyEventArgs, myBlObject);
    }
    else
    {
      if (!(commandParameter.Parameter.GetType() == typeof (AcpTableTextBoxDecHex)))
        return;
      KeyEventArgs eventArgs = commandParameter.EventArgs as KeyEventArgs;
      switch (eventArgs.Key)
      {
        case Key.Up:
        case Key.Down:
          eventArgs.Handled = true;
          break;
      }
    }
    (commandParameter.Sender as AcpTableTextBoxBase).AcpTableTextBox_PreviewKeyDown((object) commandParameter.Sender, commandParameter.EventArgs as KeyEventArgs);
  }
}
