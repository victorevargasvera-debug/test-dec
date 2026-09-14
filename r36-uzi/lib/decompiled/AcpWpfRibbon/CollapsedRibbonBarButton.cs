// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CollapsedRibbonBarButton
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CollapsedRibbonBarButton : ButtonDropDown
{
  private RibbonBar m_AttachedRibbonBar;

  static CollapsedRibbonBarButton()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CollapsedRibbonBarButton), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CollapsedRibbonBarButton)));
  }

  internal RibbonBar AttachedRibbonBar
  {
    get => this.m_AttachedRibbonBar;
    set
    {
      if (this.m_AttachedRibbonBar != null)
        this.RemoveLogicalChild((object) this.m_AttachedRibbonBar);
      this.m_AttachedRibbonBar = value;
      if (this.m_AttachedRibbonBar == null)
        return;
      this.AddLogicalChild((object) this.m_AttachedRibbonBar);
    }
  }

  protected override void HandleMouseDown(MouseButtonEventArgs e)
  {
    if (new Rect(new Point(), this.RenderSize).Contains(e.GetPosition((IInputElement) this)) && e.ChangedButton == MouseButton.Left && this.AttachedRibbonBar != null)
      this.ClickHeader();
    e.Handled = true;
  }

  protected override bool HasVisibleItems => this.AttachedRibbonBar != null;

  internal CollapsedRibbonBarPanel CollapsedRibbonBarPanel
  {
    get => this.GetTemplateChild("PART_CollapsedRibbonBarPanel") as CollapsedRibbonBarPanel;
  }
}
