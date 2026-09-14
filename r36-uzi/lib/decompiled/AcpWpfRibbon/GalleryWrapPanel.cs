// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.GalleryWrapPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class GalleryWrapPanel : WrapPanel
{
  protected override UIElementCollection CreateUIElementCollection(FrameworkElement logicalParent)
  {
    return new UIElementCollection((UIElement) this, (FrameworkElement) null);
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (double.IsPositiveInfinity(constraint.Width))
    {
      Gallery gallery = (Gallery) null;
      if (this.TemplatedParent is Gallery)
        gallery = this.TemplatedParent as Gallery;
      else if (this.Parent is Panel && ((FrameworkElement) this.Parent).TemplatedParent is Gallery)
        gallery = ((FrameworkElement) this.Parent).TemplatedParent as Gallery;
      else if (this.TemplatedParent is ItemsPresenter templatedParent && templatedParent.TemplatedParent is Gallery)
        gallery = templatedParent.TemplatedParent as Gallery;
      if (gallery != null)
        constraint.Width = !gallery.IsCollapsed ? gallery.InternalItemsPanel.ActualWidth + 20.0 : 200.0;
    }
    return base.MeasureOverride(constraint);
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Size size = base.ArrangeOverride(finalSize);
    if (!double.IsNaN(this.Width) || this.Parent is Panel && !double.IsNaN(((FrameworkElement) this.Parent).Width))
      return size;
    this.Width = finalSize.Width + 2.0;
    return size;
  }
}
