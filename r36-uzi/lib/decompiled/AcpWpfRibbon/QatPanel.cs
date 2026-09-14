// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.QatPanel
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class QatPanel : Panel
{
  private UIElementCollection m_Children;
  private ItemContainerGenerator m_ItemGenerator;
  private List<UIElement> m_GeneratedChildren;
  private bool m_ChildrenGenerated;
  private Thickness m_OldMargin;

  protected override Size MeasureOverride(Size availableSize)
  {
    if (!LayoutHelpers.IsEmpty(this.m_OldMargin))
    {
      this.Margin = this.m_OldMargin;
      this.m_OldMargin = new Thickness();
    }
    this.GenerateChildren();
    Size availableSize1 = new Size(double.PositiveInfinity, availableSize.Height);
    int num1 = this.IsItemsHost ? 1 : 0;
    QatOverflowPanel overflowPanel = this.OverflowPanel;
    if (num1 != 0)
    {
      overflowPanel?.Children.Clear();
      this.m_Children.Clear();
      foreach (UIElement generatedChild in this.m_GeneratedChildren)
      {
        this.m_Children.Add(generatedChild);
        Qat.SetIsOverflowItem((DependencyObject) generatedChild, (object) false);
      }
    }
    int num2 = this.m_GeneratedChildren.Count - 1;
    bool flag = false;
    Size size = new Size();
    for (int index = 0; index <= num2; ++index)
    {
      UIElement generatedChild = this.m_GeneratedChildren[index];
      generatedChild.Measure(availableSize1);
      Size desiredSize = generatedChild.DesiredSize;
      desiredSize.Width = Math.Round(desiredSize.Width);
      desiredSize.Height = Math.Round(desiredSize.Height);
      if (flag || LayoutHelpers.GreaterThan(desiredSize.Width + size.Width, availableSize.Width) && overflowPanel != null)
      {
        Qat.SetIsOverflowItem((DependencyObject) generatedChild, (object) true);
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
      for (int index = num2; index >= 0; --index)
      {
        UIElement generatedChild = this.m_GeneratedChildren[index];
        if (Qat.GetIsOverflowItem((DependencyObject) generatedChild))
        {
          this.m_Children.Remove(generatedChild);
          overflowPanel.Children.Insert(0, generatedChild);
        }
      }
    }
    Qat qat = this.Qat;
    if (qat != null)
      qat.HasOverflowItems = flag;
    if (this.IsCompleteOverflow && !LayoutHelpers.IsEmpty(this.Margin))
    {
      this.m_OldMargin = this.Margin;
      this.Margin = new Thickness();
    }
    return size;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    int num1 = this.m_Children.Count - 1;
    double num2 = 0.0;
    for (int index = 0; index <= num1; ++index)
    {
      UIElement child = this.m_Children[index];
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

  private new void GenerateChildren()
  {
    if (this.m_ChildrenGenerated)
      return;
    Qat qat = this.Qat;
    if (this.IsItemsHost && qat != null)
    {
      if (this.m_ItemGenerator == null)
      {
        this.m_ItemGenerator = ((IItemContainerGenerator) qat.ItemContainerGenerator).GetItemContainerGeneratorForPanel((Panel) this);
        this.m_ItemGenerator.ItemsChanged += new ItemsChangedEventHandler(this.OnItemsChanged);
      }
      IItemContainerGenerator itemGenerator = (IItemContainerGenerator) this.m_ItemGenerator;
      itemGenerator.RemoveAll();
      if (this.m_Children == null)
        this.m_Children = this.CreateUIElementCollection((FrameworkElement) null);
      else
        this.m_Children.Clear();
      this.GeneratedChildren.Clear();
      this.OverflowPanel?.Children.Clear();
      using (itemGenerator.StartAt(new GeneratorPosition(-1, 0), GeneratorDirection.Forward))
      {
        while (itemGenerator.GenerateNext() is UIElement next)
        {
          this.m_GeneratedChildren.Add(next);
          this.m_Children.Add(next);
          Qat.SetIsOverflowItem((DependencyObject) next, (object) false);
          itemGenerator.PrepareItemContainer((DependencyObject) next);
        }
      }
      this.m_ChildrenGenerated = true;
    }
    else
      this.m_Children = this.InternalChildren;
  }

  internal bool IsCompleteOverflow
  {
    get
    {
      return this.m_Children != null && this.m_Children.Count == 0 && this.OverflowPanel != null && this.OverflowPanel.Children.Count > 0;
    }
  }

  private Qat Qat => this.TemplatedParent as Qat;

  internal List<UIElement> GeneratedChildren
  {
    get
    {
      if (this.m_GeneratedChildren == null)
        this.m_GeneratedChildren = new List<UIElement>(10);
      return this.m_GeneratedChildren;
    }
  }

  private QatOverflowPanel OverflowPanel => this.Qat?.OverflowPanel;

  private void OnItemsChanged(object sender, ItemsChangedEventArgs e)
  {
    switch (e.Action)
    {
      case NotifyCollectionChangedAction.Add:
      case NotifyCollectionChangedAction.Remove:
      case NotifyCollectionChangedAction.Reset:
        this.m_ChildrenGenerated = false;
        this.GenerateChildren();
        break;
    }
    this.InvalidateMeasure();
  }

  protected override int VisualChildrenCount
  {
    get => this.m_Children == null ? base.VisualChildrenCount : this.m_Children.Count;
  }

  protected override Visual GetVisualChild(int index)
  {
    if (index < 0 || index >= this.VisualChildrenCount)
      throw new ArgumentOutOfRangeException(nameof (index), (object) index, "Argument for Visual child is out of range");
    return this.m_Children == null ? base.GetVisualChild(index) : (Visual) this.m_Children[index];
  }

  internal bool HasOnlyCustomizeItem
  {
    get
    {
      return this.m_ChildrenGenerated && this.Children.Count == 1 && this.Children[0] is QatCustomizeButton;
    }
  }

  [Browsable(false)]
  public new UIElementCollection Children
  {
    get => this.m_ChildrenGenerated ? this.m_Children : base.Children;
  }
}
