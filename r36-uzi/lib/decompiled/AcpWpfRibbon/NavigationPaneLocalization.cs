// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPaneLocalization
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Windows;

#nullable disable
namespace DevComponents.WpfRibbon;

public class NavigationPaneLocalization : DependencyObject
{
  public static readonly DependencyProperty ShowMoreButtonsProperty = DependencyProperty.Register(nameof (ShowMoreButtons), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Show _More Buttons"));
  public static readonly DependencyProperty ShowFewerButtonsProperty = DependencyProperty.Register(nameof (ShowFewerButtons), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Show Fe_wer Buttons"));
  public static readonly DependencyProperty NavigationPaneOptionsProperty = DependencyProperty.Register(nameof (NavigationPaneOptions), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Na_vigation Pane Options"));
  public static readonly DependencyProperty AddRemoveButtonsProperty = DependencyProperty.Register(nameof (AddRemoveButtons), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "_Add or Remove Buttons..."));
  public static readonly DependencyProperty CollapsedPaneTextProperty = DependencyProperty.Register(nameof (CollapsedPaneText), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Navigation Pane"));
  public static readonly DependencyProperty CustomizeDialogTitleProperty = DependencyProperty.Register(nameof (CustomizeDialogTitle), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Navigation Pane Options"));
  public static readonly DependencyProperty CustomizeDialogLabelProperty = DependencyProperty.Register(nameof (CustomizeDialogLabel), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Display buttons in this order:"));
  public static readonly DependencyProperty CustomizeDialogButtonMoveUpProperty = DependencyProperty.Register(nameof (CustomizeDialogButtonMoveUp), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Move Up"));
  public static readonly DependencyProperty CustomizeDialogButtonMoveDownProperty = DependencyProperty.Register(nameof (CustomizeDialogButtonMoveDown), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Move Down"));
  public static readonly DependencyProperty CustomizeDialogButtonResetProperty = DependencyProperty.Register(nameof (CustomizeDialogButtonReset), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Reset"));
  public static readonly DependencyProperty CustomizeDialogButtonOkProperty = DependencyProperty.Register(nameof (CustomizeDialogButtonOk), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "OK"));
  public static readonly DependencyProperty CustomizeDialogButtonCancelProperty = DependencyProperty.Register(nameof (CustomizeDialogButtonCancel), typeof (string), typeof (NavigationPaneLocalization), (PropertyMetadata) new UIPropertyMetadata((object) "Cancel"));

  public string ShowMoreButtons
  {
    get => (string) this.GetValue(NavigationPaneLocalization.ShowMoreButtonsProperty);
    set => this.SetValue(NavigationPaneLocalization.ShowMoreButtonsProperty, (object) value);
  }

  public string ShowFewerButtons
  {
    get => (string) this.GetValue(NavigationPaneLocalization.ShowFewerButtonsProperty);
    set => this.SetValue(NavigationPaneLocalization.ShowFewerButtonsProperty, (object) value);
  }

  public string NavigationPaneOptions
  {
    get => (string) this.GetValue(NavigationPaneLocalization.NavigationPaneOptionsProperty);
    set => this.SetValue(NavigationPaneLocalization.NavigationPaneOptionsProperty, (object) value);
  }

  public string AddRemoveButtons
  {
    get => (string) this.GetValue(NavigationPaneLocalization.AddRemoveButtonsProperty);
    set => this.SetValue(NavigationPaneLocalization.AddRemoveButtonsProperty, (object) value);
  }

  public string CollapsedPaneText
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CollapsedPaneTextProperty);
    set => this.SetValue(NavigationPaneLocalization.CollapsedPaneTextProperty, (object) value);
  }

  public string CustomizeDialogTitle
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogTitleProperty);
    set => this.SetValue(NavigationPaneLocalization.CustomizeDialogTitleProperty, (object) value);
  }

  public string CustomizeDialogLabel
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogLabelProperty);
    set => this.SetValue(NavigationPaneLocalization.CustomizeDialogLabelProperty, (object) value);
  }

  public string CustomizeDialogButtonMoveUp
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogButtonMoveUpProperty);
    set
    {
      this.SetValue(NavigationPaneLocalization.CustomizeDialogButtonMoveUpProperty, (object) value);
    }
  }

  public string CustomizeDialogButtonMoveDown
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogButtonMoveDownProperty);
    set
    {
      this.SetValue(NavigationPaneLocalization.CustomizeDialogButtonMoveDownProperty, (object) value);
    }
  }

  public string CustomizeDialogButtonReset
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogButtonResetProperty);
    set
    {
      this.SetValue(NavigationPaneLocalization.CustomizeDialogButtonResetProperty, (object) value);
    }
  }

  public string CustomizeDialogButtonOk
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogButtonOkProperty);
    set
    {
      this.SetValue(NavigationPaneLocalization.CustomizeDialogButtonOkProperty, (object) value);
    }
  }

  public string CustomizeDialogButtonCancel
  {
    get => (string) this.GetValue(NavigationPaneLocalization.CustomizeDialogButtonCancelProperty);
    set
    {
      this.SetValue(NavigationPaneLocalization.CustomizeDialogButtonCancelProperty, (object) value);
    }
  }
}
