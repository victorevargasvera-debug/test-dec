// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarColors
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

#nullable disable
namespace DevComponents.WpfRibbon;

public static class CrumbBarColors
{
  public static string MenuItemClass = "CrumbBarMenuItem";
  public static string ButtonClass = "CrumbBarButton";
  public static string MenuItemNormalBorder = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Normal + ButtonPartColorKeys.Border;
  public static string MenuItemNormalBorderLight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Normal + ButtonPartColorKeys.BorderLight;
  public static string MenuItemNormalBackground = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Normal + ButtonPartColorKeys.Background;
  public static string MenuItemNormalTopHighlight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Normal + ButtonPartColorKeys.TopHighlight;
  public static string MenuItemNormalBottomHighlight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Normal + ButtonPartColorKeys.BottomHighlight;
  public static string MenuItemHoverBorder = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.Border;
  public static string MenuItemHoverBorderLight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.BorderLight;
  public static string MenuItemHoverBackground = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.Background;
  public static string MenuItemHoverTopHighlight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.TopHighlight;
  public static string MenuItemHoverBottomHighlight = CrumbBarColors.MenuItemClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.BottomHighlight;
  public static string ButtonHoverBackground = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.Background;
  public static string ButtonHoverBorderLight = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.BorderLight;
  public static string ButtonHoverBorder = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Hover + ButtonPartColorKeys.Border;
  public static string ButtonHoverInactiveBackground = CrumbBarColors.ButtonClass + ButtonStateColorKeys.HoverInactive + ButtonPartColorKeys.Background;
  public static string ButtonHoverInactiveBorder = CrumbBarColors.ButtonClass + ButtonStateColorKeys.HoverInactive + ButtonPartColorKeys.Border;
  public static string ButtonPressedBackground = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Pressed + ButtonPartColorKeys.Background;
  public static string ButtonPressedBorderLight = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Pressed + ButtonPartColorKeys.BorderLight;
  public static string ButtonPressedBorder = CrumbBarColors.ButtonClass + ButtonStateColorKeys.Pressed + ButtonPartColorKeys.Border;
  public static string ControlBorder = nameof (ControlBorder);
  public static string ControlBackground = nameof (ControlBackground);
  public static string ControlBorderOuter = nameof (ControlBorderOuter);
  public static string ActionItemsSeparator = nameof (ActionItemsSeparator);
}
