// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarViewPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CrumbBarViewPanel : Panel
{
  private List<UIElement> m_GeneratedChildren;

  protected override Size MeasureOverride(Size availableSize)
  {
    Size availableSize1 = new Size(double.PositiveInfinity, availableSize.Height);
    int num1 = this.IsItemsHost ? 1 : 0;
    CrumbBarViewOverflowPanel overflowPanel = this.OverflowPanel;
    overflowPanel?.Children.Clear();
    this.Children.Clear();
    foreach (UIElement generatedChild in this.GeneratedChildren)
    {
      this.Children.Add(generatedChild);
      if (generatedChild is CrumbBarItemView crumbBarItemView)
        crumbBarItemView.IsOverflowItem = false;
    }
    int num2 = this.m_GeneratedChildren.Count - 1;
    bool flag = false;
    Size size = new Size();
    for (int index = num2; index >= 0; --index)
    {
      UIElement generatedChild = this.m_GeneratedChildren[index];
      generatedChild.Measure(availableSize1);
      Size desiredSize = generatedChild.DesiredSize;
      desiredSize.Width = Math.Round(desiredSize.Width);
      desiredSize.Height = Math.Round(desiredSize.Height);
      if (flag || LayoutHelpers.GreaterThan(desiredSize.Width + size.Width, availableSize.Width) && overflowPanel != null && index < num2)
      {
        if (generatedChild is CrumbBarItemView crumbBarItemView)
          crumbBarItemView.IsOverflowItem = true;
        flag = true;
      }
      else
      {
        size.Width += desiredSize.Width;
        size.Height = Math.Max(desiredSize.Height, size.Height);
      }
    }
    if (flag)
    {
      for (int index = 0; index <= num2; ++index)
      {
        UIElement generatedChild = this.m_GeneratedChildren[index];
        if (generatedChild is CrumbBarItemView crumbBarItemView && crumbBarItemView.IsOverflowItem)
        {
          this.Children.Remove(generatedChild);
          overflowPanel.Children.Insert(0, generatedChild);
        }
      }
    }
    CrumbBar crumbBar = this.CrumbBar;
    if (crumbBar != null)
      crumbBar.HasOverflowItems = flag;
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    int num1 = this.Children.Count - 1;
    double num2 = 0.0;
    for (int index = 0; index <= num1; ++index)
    {
      UIElement child = this.Children[index];
      UIElement uiElement = child;
      double x = num2;
      Size desiredSize = child.DesiredSize;
      double width = desiredSize.Width;
      desiredSize = child.DesiredSize;
      double height = Math.Max(desiredSize.Height, finalSize.Height);
      Rect finalRect = new Rect(x, 0.0, width, height);
      uiElement.Arrange(finalRect);
      double num3 = num2;
      desiredSize = child.DesiredSize;
      double num4 = Math.Round(desiredSize.Width);
      num2 = num3 + num4;
    }
    return finalSize;
  }

  private CrumbBar CrumbBar => this.TemplatedParent as CrumbBar;

  internal List<UIElement> GeneratedChildren
  {
    get
    {
      if (this.m_GeneratedChildren == null)
        this.m_GeneratedChildren = new List<UIElement>(10);
      return this.m_GeneratedChildren;
    }
  }

  private CrumbBarViewOverflowPanel OverflowPanel => this.CrumbBar?.OverflowPanel;
}
