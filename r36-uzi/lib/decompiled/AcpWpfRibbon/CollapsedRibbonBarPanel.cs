// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CollapsedRibbonBarPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CollapsedRibbonBarPanel : Panel
{
  protected override Size MeasureOverride(Size availableSize)
  {
    this.Children.Clear();
    if (!(this.TemplatedParent is CollapsedRibbonBarButton templatedParent) || templatedParent.AttachedRibbonBar == null)
      return base.MeasureOverride(availableSize);
    RibbonBar attachedRibbonBar = templatedParent.AttachedRibbonBar;
    this.Children.Add((UIElement) attachedRibbonBar);
    attachedRibbonBar.Measure(new Size(double.PositiveInfinity, attachedRibbonBar.DesiredSize.Height));
    return attachedRibbonBar.DesiredSize;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    if (this.Children.Count != 1)
      return finalSize;
    (this.Children[0] as RibbonBar).Arrange(new Rect(finalSize));
    return finalSize;
  }

  protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
  {
    return new UIElementCollection((UIElement) this, this.TemplatedParent == null ? logicalParent : (FrameworkElement) null);
  }
}
