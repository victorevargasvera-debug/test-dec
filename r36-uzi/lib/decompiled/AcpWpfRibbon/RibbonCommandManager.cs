// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonCommandManager
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections.Generic;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

public static class RibbonCommandManager
{
  private static Dictionary<ICommand, IButtonDropDownCommandExtender> m_Commands = new Dictionary<ICommand, IButtonDropDownCommandExtender>();

  public static void Connect(ICommand command, IButtonDropDownCommandExtender extender)
  {
    RibbonCommandManager.m_Commands[command] = extender;
  }

  public static void Disconnect(ICommand command, IButtonDropDownCommandExtender extender)
  {
    RibbonCommandManager.m_Commands.Remove(command);
  }

  public static IButtonDropDownCommandExtender GetExender(ICommand command)
  {
    IButtonDropDownCommandExtender exender = (IButtonDropDownCommandExtender) null;
    RibbonCommandManager.m_Commands.TryGetValue(command, out exender);
    return exender;
  }

  public static void ClearCommands() => RibbonCommandManager.m_Commands.Clear();
}
