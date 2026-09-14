// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonBarPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class RibbonBarPanel : Panel
{
  private CollapsedRibbonBarControl[] m_CollapsedControls;
  private RepeatButton m_ScrollLeft;
  private RepeatButton m_ScrollRight;
  private double m_AvailableWidth;
  private int m_HorizontalOffset;
  private double m_Spacing = 2.0;

  protected override void OnInitialized(EventArgs e)
  {
    KeyboardNavigation.SetTabNavigation((DependencyObject) this, KeyboardNavigationMode.Cycle);
    KeyboardNavigation.SetDirectionalNavigation((DependencyObject) this, KeyboardNavigationMode.Cycle);
    base.OnInitialized(e);
  }

  protected override Size MeasureOverride(Size availableSize)
  {
    this.RestoreAllCollapsed();
    UIElementCollection internalChildren = this.InternalChildren;
    Size size1 = new Size();
    List<RibbonBar> ribbonBarList = new List<RibbonBar>(internalChildren.Count);
    bool flag = false;
    Size availableSize1 = new Size(double.PositiveInfinity, availableSize.Height);
    foreach (UIElement uiElement in internalChildren)
    {
      if (uiElement.Visibility != Visibility.Collapsed)
      {
        if (uiElement is RibbonBar ribbonBar)
          ribbonBar.IsRibbonBarPanelMeasure = true;
        uiElement.Measure(availableSize1);
        if (ribbonBar != null)
          ribbonBar.IsRibbonBarPanelMeasure = false;
        Size desiredSize = uiElement.DesiredSize;
        if (desiredSize.Height > size1.Height)
          size1.Height = desiredSize.Height;
        size1.Width += desiredSize.Width + this.m_Spacing;
        if (ribbonBar != null)
        {
          ribbonBarList.Add(ribbonBar);
          if (ribbonBar.ResizeOrderIndex != 0)
            flag = true;
        }
      }
    }
    double width1 = size1.Width;
    if (width1 > availableSize.Width)
    {
      double val2 = Math.Ceiling(width1 - availableSize.Width);
      if (flag)
        ribbonBarList.Sort((IComparer<RibbonBar>) new RibbonBarPanel.ResizeOrderComparer());
      Size size2;
      for (int index = ribbonBarList.Count - 1; index >= 0; --index)
      {
        RibbonBar ribbonBar1 = ribbonBarList[index];
        if (ribbonBar1.IsAutoSizeEnabled)
        {
          ribbonBar1.IsSecondMeasurePass = true;
          ribbonBar1.IsRibbonBarPanelMeasure = true;
          Size desiredSize = ribbonBar1.DesiredSize;
          Size panelMeasureSize = ribbonBar1.LastPanelMeasureSize;
          Size availableSize2 = new Size(Math.Max(24.0, desiredSize.Width - val2), desiredSize.Height);
          ribbonBar1.Measure(availableSize2);
          if (ribbonBar1.MeasureNeedCollapse)
          {
            ribbonBar1.MeasureNeedCollapse = false;
            RibbonBar ribbonBar2 = ribbonBar1;
            size2 = ribbonBar1.LastPanelMeasureSize;
            Size availableSize3 = new Size(Math.Ceiling(size2.Width) + (desiredSize.Width - panelMeasureSize.Width), availableSize1.Height);
            ribbonBar2.Measure(availableSize3);
          }
          ribbonBar1.IsSecondMeasurePass = false;
          ribbonBar1.IsRibbonBarPanelMeasure = false;
          double width2 = desiredSize.Width;
          size2 = ribbonBar1.DesiredSize;
          double width3 = size2.Width;
          if (LayoutHelpers.GreaterThan(width2, width3))
          {
            double num1 = val2;
            double width4 = desiredSize.Width;
            size2 = ribbonBar1.DesiredSize;
            double width5 = size2.Width;
            double num2 = width4 - width5;
            val2 = num1 - num2;
          }
          ref Size local = ref size1;
          double width6 = local.Width;
          size2 = ribbonBar1.DesiredSize;
          double num = size2.Width - desiredSize.Width;
          local.Width = width6 + num;
          if (val2 < 0.0 || LayoutHelpers.IsClose(0.0, val2))
            break;
        }
      }
      if (LayoutHelpers.GreaterThan(val2, 0.0))
      {
        this.m_CollapsedControls = new CollapsedRibbonBarControl[internalChildren.Count];
        for (int index = ribbonBarList.Count - 1; index >= 0; --index)
        {
          RibbonBar bar = ribbonBarList[index];
          Size desiredSize = bar.DesiredSize;
          CollapsedRibbonBarControl ribbonBarControl = this.CollapseRibbonBar(bar);
          ribbonBarControl.Measure(availableSize);
          double num3 = val2;
          double width7 = desiredSize.Width;
          size2 = ribbonBarControl.DesiredSize;
          double width8 = size2.Width;
          double num4 = width7 - width8;
          val2 = num3 - num4;
          ref Size local = ref size1;
          double width9 = local.Width;
          size2 = ribbonBarControl.DesiredSize;
          double num5 = size2.Width - desiredSize.Width;
          local.Width = width9 + num5;
          if (LayoutHelpers.GreaterThan(0.0, val2))
            break;
        }
      }
    }
    if (!double.IsInfinity(availableSize.Height) && !LayoutHelpers.IsZero(availableSize.Height))
      size1.Height = availableSize.Height;
    if (size1.Width > availableSize.Width)
      this.CreateScrollButtons();
    else
      this.DestroyScrollButtons();
    this.MeasureScrollButtons(availableSize);
    this.m_AvailableWidth = availableSize.Width;
    return size1;
  }

  private CollapsedRibbonBarControl CollapseRibbonBar(RibbonBar bar)
  {
    bar.IsCollapsed = true;
    CollapsedRibbonBarControl element = new CollapsedRibbonBarControl();
    CollapsedRibbonBarButton button = element.CreateButton();
    button.Header = this.CreateCollapsedHeader(bar);
    button.Image = bar.CollapsedImage;
    int index = this.InternalChildren.IndexOf((UIElement) bar);
    this.m_CollapsedControls[index] = element;
    this.Children.Remove((UIElement) bar);
    this.Children.Insert(index, (UIElement) element);
    button.AttachedRibbonBar = bar;
    return element;
  }

  public void RestoreAllCollapsed()
  {
    if (this.m_CollapsedControls == null)
      return;
    CollapsedRibbonBarControl[] collapsedControls = this.m_CollapsedControls;
    int length = collapsedControls.Length;
    this.m_CollapsedControls = (CollapsedRibbonBarControl[]) null;
    for (int index = 0; index < length; ++index)
    {
      CollapsedRibbonBarControl element = collapsedControls[index];
      if (element != null)
      {
        CollapsedRibbonBarButton header = element.Header as CollapsedRibbonBarButton;
        RibbonBar attachedRibbonBar = header.AttachedRibbonBar;
        header.AttachedRibbonBar = (RibbonBar) null;
        if (header.IsPopupOpen)
          header.IsPopupOpen = false;
        header.CollapsedRibbonBarPanel?.Children.Clear();
        this.Children.Remove((UIElement) element);
        this.Children.Insert(index, (UIElement) attachedRibbonBar);
        header.Header = (object) null;
        header.Image = (object) null;
        element.Header = (object) null;
        attachedRibbonBar.IsCollapsed = false;
      }
    }
  }

  private object CreateCollapsedHeader(RibbonBar bar)
  {
    object collapsedHeader1 = bar.CollapsedHeader;
    if (collapsedHeader1 != null)
      return collapsedHeader1;
    object header = bar.Header;
    switch (header)
    {
      case null:
        return (object) null;
      case string _:
      case UIElement _:
      case Inline _:
        TextBlock collapsedHeader2 = new TextBlock();
        collapsedHeader2.TextWrapping = TextWrapping.Wrap;
        switch (header)
        {
          case string _:
            collapsedHeader2.Inlines.Add((string) header);
            break;
          case UIElement _:
            collapsedHeader2.Inlines.Add((UIElement) header);
            break;
          case Inline _:
            collapsedHeader2.Inlines.Add((Inline) header);
            break;
        }
        return (object) collapsedHeader2;
      default:
        return header;
    }
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    UIElementCollection internalChildren = this.InternalChildren;
    double horizontalOffset = (double) this.m_HorizontalOffset;
    int count = internalChildren.Count;
    for (int index = 0; index < count; ++index)
    {
      UIElement collapsedControl = internalChildren[index];
      if (this.m_CollapsedControls != null && this.m_CollapsedControls[index] != null)
        collapsedControl = (UIElement) this.m_CollapsedControls[index];
      if (collapsedControl.Visibility != Visibility.Collapsed)
      {
        Size desiredSize = collapsedControl.DesiredSize;
        collapsedControl.Arrange(new Rect(horizontalOffset, 0.0, desiredSize.Width, finalSize.Height));
        horizontalOffset += desiredSize.Width + this.m_Spacing;
      }
    }
    if (this.m_ScrollLeft != null)
      this.m_ScrollLeft.Arrange(new Rect(0.0, 0.0, this.m_ScrollLeft.DesiredSize.Width, finalSize.Height));
    if (this.m_ScrollRight != null)
      this.m_ScrollRight.Arrange(new Rect(this.m_AvailableWidth - this.m_ScrollRight.DesiredSize.Width, 0.0, this.m_ScrollRight.DesiredSize.Width, finalSize.Height));
    return finalSize;
  }

  protected override Visual GetVisualChild(int index)
  {
    return this.IsScrollUsed && index >= this.VisualChildrenCount - 2 ? (index == this.VisualChildrenCount - 1 ? (Visual) this.m_ScrollRight : (Visual) this.m_ScrollLeft) : (this.m_CollapsedControls == null || this.m_CollapsedControls[index] == null ? base.GetVisualChild(index) : (Visual) this.m_CollapsedControls[index]);
  }

  internal bool FocusFirstRibbonBar()
  {
    foreach (UIElement child in this.Children)
    {
      if (child.Visibility == Visibility.Visible && child.Focusable)
        return child is RibbonBar ? FocusHelpers.FocusFirstChild((ItemsControl) (child as RibbonBar)) : child.Focus();
    }
    return false;
  }

  protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
  {
    if (e.Property == RibbonTab.TabColorProperty)
    {
      foreach (UIElement child in this.Children)
        RibbonTab.SetTabColor(child, (eRibbonTabColor) e.NewValue);
    }
    base.OnPropertyChanged(e);
  }

  protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
  {
    base.OnRenderSizeChanged(sizeInfo);
    if (!this.IsScrollUsed)
      return;
    this.UpdateScrollButtonVisibility();
  }

  private void MeasureScrollButtons(Size availableSize)
  {
    if (this.m_ScrollLeft != null)
      this.m_ScrollLeft.Measure(availableSize);
    if (this.m_ScrollRight == null)
      return;
    this.m_ScrollRight.Measure(availableSize);
  }

  private void CreateScrollButtons()
  {
    if (this.m_ScrollLeft != null)
      return;
    this.m_ScrollLeft = new RepeatButton();
    this.m_ScrollLeft.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "RibbonScrollButton")) as Style;
    this.m_ScrollLeft.Tag = (object) "LeftScroll";
    this.m_ScrollLeft.Click += new RoutedEventHandler(this.ScrollLeft_Click);
    this.m_ScrollLeft.Visibility = Visibility.Collapsed;
    this.AddLogicalChild((object) this.m_ScrollLeft);
    this.AddVisualChild((Visual) this.m_ScrollLeft);
    this.m_ScrollRight = new RepeatButton();
    this.m_ScrollRight.Style = this.TryFindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) "RibbonScrollButton")) as Style;
    this.m_ScrollRight.Click += new RoutedEventHandler(this.ScrollRight_Click);
    this.AddLogicalChild((object) this.m_ScrollRight);
    this.AddVisualChild((Visual) this.m_ScrollRight);
  }

  private void ScrollRight_Click(object sender, RoutedEventArgs e)
  {
    Size size = this.DesiredSize;
    double width1 = size.Width;
    size = this.RenderSize;
    double width2 = size.Width;
    size = this.DesiredSize;
    double num = size.Width + (double) this.m_HorizontalOffset;
    double val2 = width2 - num;
    this.SetScrollOffset(-(int) Math.Ceiling(Math.Min(width1, val2)));
  }

  private void ScrollLeft_Click(object sender, RoutedEventArgs e)
  {
    this.SetScrollOffset((int) Math.Min((double) Math.Abs(this.m_HorizontalOffset), this.RenderSize.Width));
  }

  private void SetScrollOffset(int offset)
  {
    this.m_HorizontalOffset += offset;
    this.InvalidateArrange();
    this.UpdateScrollButtonVisibility();
  }

  private void UpdateScrollButtonVisibility()
  {
    if (this.m_ScrollLeft != null && this.m_HorizontalOffset != 0)
      this.m_ScrollLeft.Visibility = Visibility.Visible;
    else
      this.m_ScrollLeft.Visibility = Visibility.Collapsed;
    if (this.RenderSize.Width + (double) this.m_HorizontalOffset <= this.DesiredSize.Width)
      this.m_ScrollRight.Visibility = Visibility.Collapsed;
    else
      this.m_ScrollRight.Visibility = Visibility.Visible;
  }

  private bool IsScrollUsed => this.m_ScrollLeft != null;

  protected override int VisualChildrenCount
  {
    get
    {
      int visualChildrenCount = base.VisualChildrenCount;
      if (this.IsScrollUsed)
        visualChildrenCount += 2;
      return visualChildrenCount;
    }
  }

  private void DestroyScrollButtons()
  {
    this.m_HorizontalOffset = 0;
    this.RemoveButton(this.m_ScrollLeft);
    this.RemoveButton(this.m_ScrollRight);
    this.m_ScrollRight = (RepeatButton) null;
    this.m_ScrollLeft = (RepeatButton) null;
  }

  private void RemoveButton(RepeatButton b)
  {
    if (b == null)
      return;
    this.RemoveLogicalChild((object) b);
    this.RemoveVisualChild((Visual) b);
  }

  private class ResizeOrderComparer : IComparer<RibbonBar>
  {
    public int Compare(RibbonBar x, RibbonBar y) => x.ResizeOrderIndex - y.ResizeOrderIndex;
  }
}
