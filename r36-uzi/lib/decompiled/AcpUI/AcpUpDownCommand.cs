// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpUpDownCommand
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpBusinessLayer;
using AcpUI.Common;
using System;
using System.Windows.Input;

#nullable disable
namespace AcpUI;

public class AcpUpDownCommand : ICommand
{
  public bool CanExecute(object parameter) => true;

  public event EventHandler CanExecuteChanged;

  public void Execute(object parameter)
  {
    AcpCommandParameter commandParameter = parameter as AcpCommandParameter;
    StepUpDownUtility.OnClick((object) commandParameter.Sender, commandParameter.Parameter as AcpFieldBase);
  }
}
