// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPaneSplitter
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_SplitterBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class NavigationPaneSplitter : Control
{
  public static readonly DependencyProperty PanePanelProperty = DependencyProperty.Register(nameof (PanePanel), typeof (NavigationPanePanel), typeof (NavigationPaneSplitter), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  private int _VisibleItemsCount = -1;
  private Size _FirstElementSize;
  private double _MinContentHeight;

  static NavigationPaneSplitter()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (NavigationPaneSplitter), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (NavigationPaneSplitter)));
  }

  public NavigationPanePanel PanePanel
  {
    get => (NavigationPanePanel) this.GetValue(NavigationPaneSplitter.PanePanelProperty);
    set => this.SetValue(NavigationPaneSplitter.PanePanelProperty, (object) value);
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    if (this.PanePanel != null && this.PanePanel.FirstVisible != null && this.TemplatedParent is NavigationPane)
    {
      NavigationPane templatedParent = this.TemplatedParent as NavigationPane;
      this._VisibleItemsCount = this.PanePanel.VisiblePaneItemCount;
      this._FirstElementSize = this.PanePanel.FirstVisible.RenderSize;
      this._MinContentHeight = templatedParent.MinimumContentHeight;
      this.CaptureMouse();
      e.Handled = true;
    }
    base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (e.LeftButton == MouseButtonState.Pressed)
    {
      System.Windows.Point position = e.GetPosition((IInputElement) this);
      double num = double.PositiveInfinity;
      NavigationPane templatedParent = this.TemplatedParent as NavigationPane;
      if (templatedParent.SelectedContent is UIElement)
        num = ((UIElement) templatedParent.SelectedContent).RenderSize.Height;
      if (position.Y < 0.0)
      {
        if (this.PanePanel.LargeItemsCount < this._VisibleItemsCount && num - this._FirstElementSize.Height > this._MinContentHeight && Math.Abs(position.Y) > this._FirstElementSize.Height * 0.8)
          ++templatedParent.LargeItemsCount;
      }
      else if (this.PanePanel.LargeItemsCount > 0 && position.Y + this.RenderSize.Height > this._FirstElementSize.Height * 0.75)
        --templatedParent.LargeItemsCount;
    }
    base.OnMouseMove(e);
  }

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    if (this.IsMouseCaptured)
    {
      this.ReleaseMouseCapture();
      e.Handled = true;
    }
    base.OnMouseLeftButtonUp(e);
  }
}
