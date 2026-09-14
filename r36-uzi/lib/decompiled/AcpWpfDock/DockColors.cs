// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockColors
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

#nullable disable
namespace DevComponents.WpfDock;

public static class DockColors
{
  public static string DockSplitterClass = "DockSplitter";
  public static string DockTabClass = "DockTab";
  public static string DocumentTabClass = "DocumentTab";
  public static string DockTabPanelClass = "DockTabPanel";
  public static string DockGroupClass = "DockGroup";
  public static string DockCaptionClass = "DockCaption";
  public static string AutoHidePanelClass = "AutoHidePanel";
  public static string DockButtonClass = "DockButton";
  public static string DockSelectorClass = "DockSelector";
  public static string DockWindowInfoClass = "DockWindowInfo";
  public static string DockTabCloseButtonClass = "DocktabCloseButton";
  public static string DockSplitterNormalBackground = DockColors.DockSplitterClass + DockSplitterStateKeys.Normal + DockSplitterPartKeys.Background;
  public static string DockSplitterPreviewBrush = DockColors.DockSplitterClass + DockSplitterPartKeys.Preview;
  public static string DockTabPanelBackground = DockColors.DockTabPanelClass + DockTabPanelPartKeys.Background;
  public static string DockTabPanelInnerBackground = DockColors.DockTabPanelClass + DockTabPanelPartKeys.BackgroundInner;
  public static string DockTabNormalForeground = DockColors.DockTabClass + DockTabStateKeys.Normal + DockTabPartKeys.Foreground;
  public static string DockTabSelectedBackground = DockColors.DockTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Background;
  public static string DockTabSelectedBorder = DockColors.DockTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Border;
  public static string DockTabSelectedBorderInner = DockColors.DockTabClass + DockTabStateKeys.Selected + DockTabPartKeys.BorderInner;
  public static string DockTabSelectedForeground = DockColors.DockTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Foreground;
  public static string DockTabAutoHideBackground = DockColors.DockTabClass + DockTabStateKeys.AutoHide + DockTabPartKeys.Background;
  public static string DockTabAutoHideBorder = DockColors.DockTabClass + DockTabStateKeys.AutoHide + DockTabPartKeys.Border;
  public static string DockTabAutoHideBorderInner = DockColors.DockTabClass + DockTabStateKeys.AutoHide + DockTabPartKeys.BorderInner;
  public static string DockTabAutoHideForeground = DockColors.DockTabClass + DockTabStateKeys.AutoHide + DockTabPartKeys.Foreground;
  public static string DocumentTabPanelBackground = DockColors.DocumentTabClass + DockTabPanelPartKeys.Background;
  public static string DocumentTabPanelInnerBackground = DockColors.DocumentTabClass + DockTabPanelPartKeys.BackgroundInner;
  public static string DocumentTabNormalForeground = DockColors.DocumentTabClass + DockTabStateKeys.Normal + DockTabPartKeys.Foreground;
  public static string DocumentTabNormalBackground = DockColors.DocumentTabClass + DockTabStateKeys.Normal + DockTabPartKeys.Background;
  public static string DocumentTabNormalBorder = DockColors.DocumentTabClass + DockTabStateKeys.Normal + DockTabPartKeys.Border;
  public static string DocumentTabNormalBorderInner = DockColors.DocumentTabClass + DockTabStateKeys.Normal + DockTabPartKeys.BorderInner;
  public static string DocumentTabSelectedBackground = DockColors.DocumentTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Background;
  public static string DocumentTabSelectedBorder = DockColors.DocumentTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Border;
  public static string DocumentTabSelectedBorderInner = DockColors.DocumentTabClass + DockTabStateKeys.Selected + DockTabPartKeys.BorderInner;
  public static string DocumentTabSelectedForeground = DockColors.DocumentTabClass + DockTabStateKeys.Selected + DockTabPartKeys.Foreground;
  public static string DockGroupBackground = DockColors.DockGroupClass + DockGroupPartKeys.Background;
  public static string DockGroupBorder = DockColors.DockGroupClass + DockGroupPartKeys.Border;
  public static string DockGroupForeground = DockColors.DockGroupClass + DockGroupPartKeys.Foreground;
  public static string DockCaptionInactiveBackground = DockColors.DockGroupClass + DockCaptionStateKeys.Inactive + DockCaptionPartKeys.Background;
  public static string DockCaptionInactiveForeground = DockColors.DockGroupClass + DockCaptionStateKeys.Inactive + DockCaptionPartKeys.Foreground;
  public static string DockCaptionActiveBackground = DockColors.DockGroupClass + DockCaptionStateKeys.Active + DockCaptionPartKeys.Background;
  public static string DockCaptionActiveForeground = DockColors.DockGroupClass + DockCaptionStateKeys.Active + DockCaptionPartKeys.Foreground;
  public static string DockPreviewWindowBackground = nameof (DockPreviewWindowBackground);
  public static string DockHintBorder = nameof (DockHintBorder);
  public static string AutoHidePanelBackground = DockColors.AutoHidePanelClass + AutoHidePanelPartKeys.Background;
  public static string DockButtonNormalBackground = DockColors.DockButtonClass + DockButtonStateKeys.Normal + DockButtonPartKeys.Background;
  public static string DockButtonNormalBorder = DockColors.DockButtonClass + DockButtonStateKeys.Normal + DockButtonPartKeys.Border;
  public static string DockButtonNormalForeground = DockColors.DockButtonClass + DockButtonStateKeys.Normal + DockButtonPartKeys.Foreground;
  public static string DockButtonHoverBackground = DockColors.DockButtonClass + DockButtonStateKeys.Hover + DockButtonPartKeys.Background;
  public static string DockButtonHoverBorder = DockColors.DockButtonClass + DockButtonStateKeys.Hover + DockButtonPartKeys.Border;
  public static string DockButtonHoverForeground = DockColors.DockButtonClass + DockButtonStateKeys.Hover + DockButtonPartKeys.Foreground;
  public static string DockButtonPressedBackground = DockColors.DockButtonClass + DockButtonStateKeys.Pressed + DockButtonPartKeys.Background;
  public static string DockButtonPressedBorder = DockColors.DockButtonClass + DockButtonStateKeys.Pressed + DockButtonPartKeys.Border;
  public static string DockButtonPressedForeground = DockColors.DockButtonClass + DockButtonStateKeys.Pressed + DockButtonPartKeys.Foreground;
  public static string DockButtonDisabledBackground = DockColors.DockButtonClass + DockButtonStateKeys.Disabled + DockButtonPartKeys.Background;
  public static string DockButtonDisabledBorder = DockColors.DockButtonClass + DockButtonStateKeys.Disabled + DockButtonPartKeys.Border;
  public static string DockButtonDisabledForeground = DockColors.DockButtonClass + DockButtonStateKeys.Disabled + DockButtonPartKeys.Foreground;
  public static string DockSelectorBackground = DockColors.DockSelectorClass + DockSelectorPartKeys.Background;
  public static string DockSelectorBorder = DockColors.DockSelectorClass + DockSelectorPartKeys.Border;
  public static string DockWindowInfoBackground = DockColors.DockWindowInfoClass + DockSelectorPartKeys.Background;
  public static string DockWindowInfoBorder = DockColors.DockWindowInfoClass + DockSelectorPartKeys.Border;
  public static string DockTabCloseButtonActiveBackground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Active + DockTabCloseButtonPartKeys.Background;
  public static string DockTabCloseButtonActiveBorder = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Active + DockTabCloseButtonPartKeys.Border;
  public static string DockTabCloseButtonActiveBorderInner = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Active + DockTabCloseButtonPartKeys.BorderInner;
  public static string DockTabCloseButtonActiveForeground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Active + DockTabCloseButtonPartKeys.Foreground;
  public static string DockTabCloseButtonInactiveBackground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Inactive + DockTabCloseButtonPartKeys.Background;
  public static string DockTabCloseButtonInactiveBorder = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Inactive + DockTabCloseButtonPartKeys.Border;
  public static string DockTabCloseButtonInactiveBorderInner = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Inactive + DockTabCloseButtonPartKeys.BorderInner;
  public static string DockTabCloseButtonInactiveForeground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Inactive + DockTabCloseButtonPartKeys.Foreground;
  public static string DockTabCloseButtonHoverBackground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Hover + DockTabCloseButtonPartKeys.Background;
  public static string DockTabCloseButtonHoverBorder = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Hover + DockTabCloseButtonPartKeys.Border;
  public static string DockTabCloseButtonHoverBorderInner = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Hover + DockTabCloseButtonPartKeys.BorderInner;
  public static string DockTabCloseButtonHoverForeground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Hover + DockTabCloseButtonPartKeys.Foreground;
  public static string DockTabCloseButtonPressedBackground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Pressed + DockTabCloseButtonPartKeys.Background;
  public static string DockTabCloseButtonPressedBorder = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Pressed + DockTabCloseButtonPartKeys.Border;
  public static string DockTabCloseButtonPressedBorderInner = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Pressed + DockTabCloseButtonPartKeys.BorderInner;
  public static string DockTabCloseButtonPressedForeground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Pressed + DockTabCloseButtonPartKeys.Foreground;
  public static string DockTabCloseButtonDisabledBackground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Disabled + DockTabCloseButtonPartKeys.Background;
  public static string DockTabCloseButtonDisabledBorder = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Disabled + DockTabCloseButtonPartKeys.Border;
  public static string DockTabCloseButtonDisabledBorderInner = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Disabled + DockTabCloseButtonPartKeys.BorderInner;
  public static string DockTabCloseButtonDisabledForeground = DockColors.DockTabCloseButtonClass + DockTabCloseButtonStateKeys.Disabled + DockTabCloseButtonPartKeys.Foreground;
}
