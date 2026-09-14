// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CommandHelpers
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

internal static class CommandHelpers
{
  internal static void ExecuteCommand(ICommand command, object parameter, IInputElement target)
  {
    if (command is RoutedCommand routedCommand)
    {
      if (!routedCommand.CanExecute(parameter, target))
        return;
      routedCommand.Execute(parameter, target);
    }
    else
    {
      if (!command.CanExecute(parameter))
        return;
      command.Execute(parameter);
    }
  }
}
