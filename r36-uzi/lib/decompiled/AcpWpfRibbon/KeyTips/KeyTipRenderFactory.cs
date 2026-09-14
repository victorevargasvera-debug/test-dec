// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTips.KeyTipRenderFactory
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

#nullable disable
namespace DevComponents.WpfRibbon.KeyTips;

internal static class KeyTipRenderFactory
{
  private static KeyTipRenderer m_RibbonKeyTipRenderer = (KeyTipRenderer) new RibbonKeyTipRenderer();
  private static KeyTipRenderer m_RibbonTabKeyTipRenderer = (KeyTipRenderer) new RibbonTabKeyTipRenderer();
  private static KeyTipRenderer m_RibbonBarKeyTipRenderer = (KeyTipRenderer) new RibbonBarKeyTipRenderer();
  private static KeyTipRenderer m_ButtonPopupKeyTipRenderer = (KeyTipRenderer) new ButtonPopupKeyRenderer();
  private static KeyTipRenderer m_AppMenuKeyTipRenderer = (KeyTipRenderer) new AppMenuKeyTipRenderer();

  public static KeyTipRenderer GetRenderer(object o)
  {
    switch (o)
    {
      case Ribbon _:
        return KeyTipRenderFactory.m_RibbonKeyTipRenderer;
      case ApplicationMenu _:
        return KeyTipRenderFactory.m_AppMenuKeyTipRenderer;
      case RibbonTab _:
        return KeyTipRenderFactory.m_RibbonTabKeyTipRenderer;
      case RibbonBar _:
        return KeyTipRenderFactory.m_RibbonBarKeyTipRenderer;
      case ButtonDropDown _:
        return KeyTipRenderFactory.m_ButtonPopupKeyTipRenderer;
      default:
        return (KeyTipRenderer) null;
    }
  }
}
