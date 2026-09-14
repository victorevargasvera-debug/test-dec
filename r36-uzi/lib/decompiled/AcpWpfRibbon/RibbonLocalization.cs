// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonLocalization
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using AcpCommonResources;
using System.ComponentModel;

#nullable disable
namespace DevComponents.WpfRibbon;

[ToolboxItem(false)]
[TypeConverter(typeof (ExpandableObjectConverter))]
public class RibbonLocalization
{
  private string m_QatRemoveItemText = "_Remove from Quick Access Toolbar";
  private string m_QatAddItemText = AcpResources.Add_to_Quick_Access_Toolbar;
  private string m_QatCustomizeText = AcpResources.Customize_Quick_Access_Toolbar;
  private string m_QatPlaceBelowRibbonText = AcpResources.Show_Quick_Access_Toolbar_Below;
  private string m_QatPlaceAboveRibbonText = AcpResources.Show_Quick_Access_Toolbar_Above;
  private string m_QatMoreCommandsText = "_More Commands...";
  private string m_QatDialogOkButton = AcpResources.OK_Id;
  private string m_QatDialogCancelButton = AcpResources.Cancel_Id;
  private string m_QatDialogAddButton = "_Add >>";
  private string m_QatDialogRemoveButton = "_Remove";
  private string m_QatDialogCategoriesLabel = "_Choose commands from:";
  private string m_QatDialogPlacementCheckbox = "_Place Quick Access Toolbar below the Ribbon";
  private string m_QatDialogCaption = AcpResources.Customize_Quick_Access_Toolbar;
  private string m_MinimizeRibbonText = AcpResources.Minimize_the_Ribbon;
  private string m_MaximizeRibbonText = AcpResources.Maximize_the_Ribbon;
  private string m_QatCustomizeMenuLabel = AcpResources.Customize_Quick_Access_Toolbar;

  [DefaultValue("Customize Quick Access Toolbar")]
  [Localizable(true)]
  [Description("Indicates the the title text of the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogCaption
  {
    get => this.m_QatDialogCaption;
    set => this.m_QatDialogCaption = value;
  }

  [DefaultValue("_Place Quick Access Toolbar below the Ribbon")]
  [Localizable(true)]
  [Description("Indicates the text of the 'Place Quick Access Toolbar below the Ribbon' check-box on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogPlacementCheckbox
  {
    get => this.m_QatDialogPlacementCheckbox;
    set => this.m_QatDialogPlacementCheckbox = value;
  }

  [DefaultValue("_Choose commands from:")]
  [Localizable(true)]
  [Description("Indicates the text of the Choose commands from label on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogCategoriesLabel
  {
    get => this.m_QatDialogCategoriesLabel;
    set => this.m_QatDialogCategoriesLabel = value;
  }

  [DefaultValue("_Remove")]
  [Localizable(true)]
  [Description("Indicates the text of the Remove button on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogRemoveButton
  {
    get => this.m_QatDialogRemoveButton;
    set => this.m_QatDialogRemoveButton = value;
  }

  [DefaultValue("_Add >>")]
  [Localizable(true)]
  [Description("Indicates the text of the Add button on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogAddButton
  {
    get => this.m_QatDialogAddButton;
    set => this.m_QatDialogAddButton = value;
  }

  [DefaultValue("OK")]
  [Localizable(true)]
  [Description("Indicates the text of the OK button on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogOkButton
  {
    get => this.m_QatDialogOkButton;
    set => this.m_QatDialogOkButton = value;
  }

  [DefaultValue("Cancel")]
  [Localizable(true)]
  [Description("Indicates the text of the OK button on the Quick Access Toolbar Customize dialog form.")]
  [Category("QAT Customize Dialog")]
  public string QatDialogCancelButton
  {
    get => this.m_QatDialogCancelButton;
    set => this.m_QatDialogCancelButton = value;
  }

  [DefaultValue("_Remove from Quick Access Toolbar")]
  [Localizable(true)]
  [Description("Indicates the text that is used on context menu used to customize Quick Access Toolbar.")]
  [Category("Quick Access Toolbar")]
  public string QatRemoveItemText
  {
    get => this.m_QatRemoveItemText;
    set => this.m_QatRemoveItemText = value;
  }

  [DefaultValue("_Add to Quick Access Toolbar")]
  [Localizable(true)]
  [Description("Indicates the text that is used on context menu used to customize Quick Access Toolbar.")]
  [Category("Quick Access Toolbar")]
  public string QatAddItemText
  {
    get => this.m_QatAddItemText;
    set => this.m_QatAddItemText = value;
  }

  [DefaultValue("_Customize Quick Access Toolbar...")]
  [Localizable(true)]
  [Description("Indicates the text that is used on context menu used to customize Quick Access Toolbar.")]
  [Category("Quick Access Toolbar")]
  public string QatCustomizeText
  {
    get => this.m_QatCustomizeText;
    set => this.m_QatCustomizeText = value;
  }

  [DefaultValue("Customize Quick Access Toolbar")]
  [Localizable(true)]
  [Description("Indicates text that is used on Quick Access Toolbar customize menu label.")]
  [Category("Quick Access Toolbar")]
  public string QatCustomizeMenuLabel
  {
    get => this.m_QatCustomizeMenuLabel;
    set => this.m_QatCustomizeMenuLabel = value;
  }

  [DefaultValue("_Show Below the Ribbon")]
  [Localizable(true)]
  [Description("Indicates the text that is used on context menu used to change placement of the Quick Access Toolbar.")]
  [Category("Quick Access Toolbar")]
  public string QatPlaceBelowRibbonText
  {
    get => this.m_QatPlaceBelowRibbonText;
    set => this.m_QatPlaceBelowRibbonText = value;
  }

  [DefaultValue("_Show Above the Ribbon")]
  [Localizable(true)]
  [Description("Indicates the text that is used on context menu used to change placement of the Quick Access Toolbar.")]
  [Category("Quick Access Toolbar")]
  public string QatPlaceAboveRibbonText
  {
    get => this.m_QatPlaceAboveRibbonText;
    set => this.m_QatPlaceAboveRibbonText = value;
  }

  [DefaultValue("Mi_nimize the Ribbon")]
  [Localizable(true)]
  [Description("Indicates text that is used on context menu item used to minimize the Ribbon.")]
  [Category("Quick Access Toolbar")]
  public string MinimizeRibbonText
  {
    get => this.m_MinimizeRibbonText;
    set => this.m_MinimizeRibbonText = value;
  }

  [DefaultValue("_Maximize the Ribbon")]
  [Localizable(true)]
  [Description("Indicates text that is used on context menu item used to maximize the Ribbon.")]
  [Category("Quick Access Toolbar")]
  public string MaximizeRibbonText
  {
    get => this.m_MaximizeRibbonText;
    set => this.m_MaximizeRibbonText = value;
  }

  [DefaultValue("_More Commands...")]
  [Localizable(true)]
  [Description("Indicates text that is used on QAT Customize menu item used to open the Qat Customize Dialog.")]
  [Category("Quick Access Toolbar")]
  public string QatMoreCommandsText
  {
    get => this.m_QatMoreCommandsText;
    set => this.m_QatMoreCommandsText = value;
  }
}
