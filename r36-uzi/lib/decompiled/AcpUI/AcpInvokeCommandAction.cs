// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpInvokeCommandAction
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

#nullable disable
namespace AcpUI;

public class AcpInvokeCommandAction : TriggerAction<DependencyObject>
{
  private string commandName;
  public static readonly DependencyProperty CommandProperty = DependencyProperty.Register(nameof (Command), typeof (ICommand), typeof (AcpInvokeCommandAction), (PropertyMetadata) null);
  public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register(nameof (CommandParameter), typeof (object), typeof (AcpInvokeCommandAction), (PropertyMetadata) null);

  public string CommandName
  {
    get
    {
      ((Freezable) this).ReadPreamble();
      return this.commandName;
    }
    set
    {
      if (!(this.CommandName != value))
        return;
      ((Freezable) this).WritePreamble();
      this.commandName = value;
      ((Freezable) this).WritePostscript();
    }
  }

  public ICommand Command
  {
    get => (ICommand) ((DependencyObject) this).GetValue(AcpInvokeCommandAction.CommandProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpInvokeCommandAction.CommandProperty, (object) value);
    }
  }

  public object CommandParameter
  {
    get => ((DependencyObject) this).GetValue(AcpInvokeCommandAction.CommandParameterProperty);
    set
    {
      ((DependencyObject) this).SetValue(AcpInvokeCommandAction.CommandParameterProperty, value);
    }
  }

  protected virtual void Invoke(object parameter)
  {
    if (this.AssociatedObject == null)
      return;
    ICommand command = this.ResolveCommand();
    AcpCommandParameter parameter1 = new AcpCommandParameter()
    {
      Sender = this.AssociatedObject,
      Parameter = ((DependencyObject) this).GetValue(AcpInvokeCommandAction.CommandParameterProperty),
      EventArgs = parameter as EventArgs
    };
    if (command == null || !command.CanExecute((object) parameter1))
      return;
    command.Execute((object) parameter1);
  }

  private ICommand ResolveCommand()
  {
    ICommand command = (ICommand) null;
    if (this.Command != null)
      command = this.Command;
    else if (this.AssociatedObject != null)
    {
      foreach (PropertyInfo property in this.AssociatedObject.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
      {
        if (typeof (ICommand).IsAssignableFrom(property.PropertyType) && string.Equals(property.Name, this.CommandName, StringComparison.Ordinal))
          command = (ICommand) property.GetValue((object) this.AssociatedObject, (object[]) null);
      }
    }
    return command;
  }
}
