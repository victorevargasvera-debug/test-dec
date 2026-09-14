// Decompiled with JetBrains decompiler
// Type: MackinawCPS.CpsCommand
// Assembly: APXFamilyCPS, Version=36.0.1.0, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 9359335E-041C-4B12-9409-F4E6E7D93299
// Assembly location: C:\Program Files (x86)\Motorola\ApxFamilyCPS R36.00\APXFamilyCPS1.exe

using System;
using System.Windows.Input;

#nullable disable
namespace MackinawCPS;

public class CpsCommand : ICommand
{
  private Action<object> _execute;
  private Func<object, bool> _canExecute;

  public CpsCommand(Action<object> execute, Func<object, bool> canExecute)
  {
    this._execute = execute;
    this._canExecute = canExecute;
  }

  public bool CanExecute(object parameter) => this._canExecute(parameter);

  public void Execute(object parameter) => this._execute(parameter);

  public event EventHandler CanExecuteChanged
  {
    add => CommandManager.RequerySuggested += value;
    remove => CommandManager.RequerySuggested -= value;
  }
}
