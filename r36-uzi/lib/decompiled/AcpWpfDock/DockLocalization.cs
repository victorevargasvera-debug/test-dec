// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockLocalization
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using AcpCommonResources;
using System.ComponentModel;

#nullable disable
namespace DevComponents.WpfDock;

[ToolboxItem(false)]
[TypeConverter(typeof (ExpandableObjectConverter))]
public class DockLocalization
{
  private string m_OptionsMenuAutoHideText = AcpResources.Auto_Hide;
  private string m_OptionsMenuHideText = AcpResources.Hide_Id;
  private string m_OptionsMenuFloatingText = AcpResources.Floating_Id;
  private string m_OptionsMenuTabbedDocumentText = AcpResources.Tabbed_Document;
  private string m_OptionsMenuDockableText = AcpResources.Dockable_Id;
  private string m_DockSelectorActiveToolWindowsText = "Active Tool Windows";
  private string m_DockSelectorActiveFilesText = "Active Files";

  [DefaultValue("Auto Hide")]
  [Localizable(true)]
  [Description("Indicates text used on options menu to place dock window into auto-hide mode.")]
  [Category("Options Menu")]
  public string OptionsMenuAutoHideText
  {
    get => this.m_OptionsMenuAutoHideText;
    set => this.m_OptionsMenuAutoHideText = value;
  }

  [DefaultValue("Hide")]
  [Localizable(true)]
  [Description("Indicates text used on options menu to hide dock window.")]
  [Category("Options Menu")]
  public string OptionsMenuHideText
  {
    get => this.m_OptionsMenuHideText;
    set => this.m_OptionsMenuHideText = value;
  }

  [DefaultValue("Floating")]
  [Localizable(true)]
  [Description("Indicates text used on options menu to place dock window into floating mode.")]
  [Category("Options Menu")]
  public string OptionsMenuFloatingText
  {
    get => this.m_OptionsMenuFloatingText;
    set => this.m_OptionsMenuFloatingText = value;
  }

  [DefaultValue("Tabbed Document")]
  [Localizable(true)]
  [Description("Indicates text used on options menu to dock dock window as tabbed document")]
  [Category("Options Menu")]
  public string OptionsMenuTabbedDocumentText
  {
    get => this.m_OptionsMenuTabbedDocumentText;
    set => this.m_OptionsMenuTabbedDocumentText = value;
  }

  [DefaultValue("Dockable")]
  [Localizable(true)]
  [Description("Indicates text used on options menu to dock dock window")]
  [Category("Options Menu")]
  public string OptionsMenuDockableText
  {
    get => this.m_OptionsMenuDockableText;
    set => this.m_OptionsMenuDockableText = value;
  }

  [DefaultValue("Active Tool Windows")]
  [Localizable(true)]
  [Description("Indicates text used on dock selector label to indicates Active Tool Windows.")]
  [Category("Dock Selector")]
  public string DockSelectorActiveToolWindowsText
  {
    get => this.m_DockSelectorActiveToolWindowsText;
    set => this.m_DockSelectorActiveToolWindowsText = value;
  }

  [DefaultValue("Active Files")]
  [Localizable(true)]
  [Description("Indicates text used on dock selector label to indicates Active Files.")]
  [Category("Dock Selector")]
  public string DockSelectorActiveFilesText
  {
    get => this.m_DockSelectorActiveFilesText;
    set => this.m_DockSelectorActiveFilesText = value;
  }
}
