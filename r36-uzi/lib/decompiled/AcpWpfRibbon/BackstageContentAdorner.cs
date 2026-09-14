// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.BackstageContentAdorner
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class BackstageContentAdorner : Adorner
{
  private bool _BackstageContentActive;

  public BackstageContentAdorner(ApplicationMenu adornedElement)
    : base((UIElement) adornedElement)
  {
    this._BackstageContentActive = true;
    this.AddLogicalChild((object) adornedElement.BackstageTab);
    this.AddVisualChild((Visual) adornedElement.BackstageTab);
    this.Focusable = true;
    this.FocusVisualStyle = (Style) null;
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      if (!this._BackstageContentActive || this.ApplicationMenu.BackstageTab == null)
        return (IEnumerator) new List<UIElement>().GetEnumerator();
      return (IEnumerator) new List<UIElement>((IEnumerable<UIElement>) new UIElement[1]
      {
        this.ApplicationMenu.BackstageTab
      }).GetEnumerator();
    }
  }

  protected override int VisualChildrenCount
  {
    get => this._BackstageContentActive && this.ApplicationMenu.BackstageTab != null ? 1 : 0;
  }

  protected override Visual GetVisualChild(int index)
  {
    return this._BackstageContentActive && index == 0 ? (Visual) this.ApplicationMenu.BackstageTab : base.GetVisualChild(index);
  }

  private ApplicationMenu ApplicationMenu => (ApplicationMenu) this.AdornedElement;

  protected override Size MeasureOverride(Size constraint)
  {
    if (!this._BackstageContentActive)
      return base.MeasureOverride(constraint);
    ApplicationMenu applicationMenu = this.ApplicationMenu;
    UIElement backstageTab = applicationMenu.BackstageTab;
    constraint.Height -= applicationMenu.RenderSize.Height;
    Ribbon ribbon = applicationMenu.GetRibbon();
    if (ribbon != null && !ribbon.IsUsingGlass)
    {
      --constraint.Width;
      constraint.Height -= 8.0;
    }
    Size availableSize = constraint;
    backstageTab.Measure(availableSize);
    return constraint;
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    if (!this._BackstageContentActive)
      return base.ArrangeOverride(finalSize);
    UIElement backstageTab = this.ApplicationMenu.BackstageTab;
    Rect rect = new Rect(finalSize);
    rect.Y += this.ApplicationMenu.RenderSize.Height;
    rect.Height -= this.ApplicationMenu.RenderSize.Height;
    Rect finalRect = rect;
    backstageTab.Arrange(finalRect);
    return base.ArrangeOverride(finalSize);
  }

  protected override void OnRender(DrawingContext drawingContext)
  {
    if (this._BackstageContentActive)
    {
      Rect rectangle = new Rect(this.RenderSize);
      if (rectangle.Width > 0.0 && rectangle.Height > 0.0)
      {
        rectangle.Y += this.ApplicationMenu.RenderSize.Height;
        rectangle.Height -= this.ApplicationMenu.RenderSize.Height;
        drawingContext.DrawRectangle((Brush) Brushes.Transparent, (Pen) null, rectangle);
      }
    }
    base.OnRender(drawingContext);
  }

  public void RemoveBackstageContent()
  {
    this.RemoveLogicalChild((object) this.ApplicationMenu.BackstageTab);
    this.RemoveVisualChild((Visual) this.ApplicationMenu.BackstageTab);
    this._BackstageContentActive = false;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    if (e.Key == Key.Escape)
    {
      this.ApplicationMenu.IsPopupOpen = false;
      e.Handled = true;
    }
    base.OnKeyDown(e);
  }

  protected override void OnTextInput(TextCompositionEventArgs e)
  {
    base.OnTextInput(e);
    KeyTipsAdorner keyTipsAdorner = this.ApplicationMenu.m_KeyTipsAdorner;
    if (e.Handled || keyTipsAdorner == null || !keyTipsAdorner.ProcessTextInput(e))
      return;
    this.ApplicationMenu.ShowKeyTips = false;
  }
}
