// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.TitlePanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class TitlePanel : Panel
{
  private double m_TabXPosition;
  private double m_QatRightPosition;
  private double m_TitleChromeHeight;

  protected override Size MeasureOverride(Size availableSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    Size size = new Size();
    foreach (UIElement uiElement in internalChildren)
    {
      if (uiElement is ContextGroup contextGroup)
      {
        if (!contextGroup.IsOneTabVisible)
        {
          if (contextGroup.Visibility != Visibility.Collapsed)
            contextGroup.Visibility = Visibility.Collapsed;
        }
        else
        {
          if (contextGroup.Visibility != Visibility.Visible)
            contextGroup.Visibility = Visibility.Visible;
          Size availableSize1 = new Size(0.0, Math.Min(this.GetContextGroupHeight(), availableSize.Height));
          foreach (RibbonTab linkedTab in (Collection<RibbonTab>) contextGroup.LinkedTabs)
            availableSize1.Width += linkedTab.DesiredSize.Width;
          contextGroup.Measure(availableSize1);
          Size desiredSize = contextGroup.DesiredSize;
          size.Width += desiredSize.Width;
          if (desiredSize.Height > size.Height)
            size.Height = desiredSize.Height;
        }
      }
      else
      {
        uiElement.Measure(new Size(double.PositiveInfinity, availableSize.Height));
        size.Width += uiElement.DesiredSize.Width;
        size.Height = Math.Max(uiElement.DesiredSize.Height, size.Height);
      }
    }
    if (availableSize.Width < double.PositiveInfinity)
      size.Width = availableSize.Width;
    return size;
  }

  private double GetContextGroupHeight() => this.m_TitleChromeHeight + 20.0;

  private bool IsTabVisible(RibbonTab tab)
  {
    return tab.Visibility == Visibility.Visible && (!(VisualTreeHelper.GetParent((DependencyObject) tab) is UIElement parent) || parent.Visibility == Visibility.Visible);
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    Rect rect1 = new Rect(finalSize);
    List<Rect> availableArea = new List<Rect>(internalChildren.Count * 2);
    availableArea.Add(rect1);
    List<UIElement> uiElementList = new List<UIElement>(internalChildren.Count);
    foreach (UIElement uiElement in internalChildren)
    {
      ContextGroup contextGroup = uiElement as ContextGroup;
      if (uiElement.Visibility == Visibility.Visible)
      {
        if (contextGroup == null)
        {
          uiElementList.Add(uiElement);
        }
        else
        {
          Rect rect2 = new Rect();
          foreach (RibbonTab linkedTab in (Collection<RibbonTab>) contextGroup.LinkedTabs)
          {
            if (this.IsTabVisible(linkedTab))
            {
              Rect layoutSlot = LayoutInformation.GetLayoutSlot((FrameworkElement) linkedTab);
              layoutSlot.X -= this.m_QatRightPosition - this.m_TabXPosition;
              if (layoutSlot.X >= 0.0 && layoutSlot.Right <= rect1.Right)
              {
                Rect rect3 = new Rect(layoutSlot.X, 0.0, layoutSlot.Width, this.GetContextGroupHeight());
                if (rect2.Width == 0.0)
                  rect2 = rect3;
                else
                  rect2.Union(rect3);
              }
            }
          }
          if (!LayoutHelpers.IsEmpty(rect2))
          {
            contextGroup.Arrange(rect2);
            this.ExcludeArea(availableArea, rect2);
          }
          else if (contextGroup.Visibility != Visibility.Hidden)
            contextGroup.Visibility = Visibility.Hidden;
        }
      }
    }
    availableArea.Sort((IComparer<Rect>) new TitlePanel.RectWidthComparer());
    foreach (UIElement uiElement in uiElementList)
    {
      if (availableArea.Count != 0)
      {
        if (uiElement.Visibility == Visibility.Visible)
        {
          uiElement.Arrange(availableArea[availableArea.Count - 1]);
          availableArea.RemoveAt(availableArea.Count - 1);
        }
      }
      else
        break;
    }
    return finalSize;
  }

  private void ExcludeArea(List<Rect> availableArea, Rect tabsArea)
  {
    int index1 = 0;
    for (int index2 = availableArea.Count - 1; index1 <= index2; ++index1)
    {
      Rect rect1 = availableArea[index1];
      if (rect1.IntersectsWith(tabsArea))
      {
        Rect rect2 = new Rect(rect1.X, rect1.Y, Math.Max(0.0, tabsArea.X - rect1.X), rect1.Height);
        Rect rect3 = new Rect(tabsArea.Right, rect1.Y, Math.Max(0.0, rect1.Right - tabsArea.Right), rect1.Height);
        bool flag = false;
        if (LayoutHelpers.GreaterThan(rect2.Width, 0.0) && !LayoutHelpers.IsZero(rect2.Width))
        {
          availableArea[index1] = rect2;
          flag = true;
        }
        if (LayoutHelpers.GreaterThan(rect3.Width, 0.0) && !LayoutHelpers.IsZero(rect3.Width))
        {
          if (flag)
            availableArea.Add(rect3);
          else
            availableArea[index1] = rect3;
        }
      }
    }
  }

  internal double TabXPosition
  {
    get => this.m_TabXPosition;
    set => this.m_TabXPosition = value;
  }

  internal double QatRightPosition
  {
    get => this.m_QatRightPosition;
    set => this.m_QatRightPosition = value;
  }

  internal double TitleChromeHeight
  {
    get => this.m_TitleChromeHeight;
    set => this.m_TitleChromeHeight = value;
  }

  private class RectWidthComparer : IComparer<Rect>
  {
    public int Compare(Rect x, Rect y) => (int) (x.Width - y.Width);
  }
}
