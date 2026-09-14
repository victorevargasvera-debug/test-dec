// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.MenuItemColors
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

#nullable disable
namespace DevComponents.WpfRibbon;

public static class MenuItemColors
{
  public static string MenuItemClass = "FlatMenuItem";
  public static string MenuPopupClass = "FlatMenuPopup";
  public static string SeparatorClass = "FlatSeparator";
  public static string MenuPopupBorder = MenuItemColors.MenuPopupClass + "Border";
  public static string MenuPopupBackground = MenuItemColors.MenuPopupClass + "Background";
  public static string MenuPopupIconBackground = MenuItemColors.MenuPopupClass + "IconBackground";
  public static string MenuPopupForeground = MenuItemColors.MenuPopupClass + "Foreground";
  public static string MenuItemMouseOverBorder = $"{MenuItemColors.MenuItemClass}{MenuItemStates.MouseOver}Border";
  public static string MenuItemMouseOverBackground = $"{MenuItemColors.MenuItemClass}{MenuItemStates.MouseOver}Background";
  public static string MenuItemCheckedBorder = $"{MenuItemColors.MenuItemClass}{MenuItemStates.Checked}Border";
  public static string MenuItemCheckedBackground = $"{MenuItemColors.MenuItemClass}{MenuItemStates.Checked}Background";
  public static string MenuItemDisabledForeground = $"{MenuItemColors.MenuItemClass}{MenuItemStates.Disabled}Foreground";
  public static string SeparatorBorder = MenuItemColors.SeparatorClass + "Border";
}
