// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockSplitter
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

#nullable disable
namespace DevComponents.WpfDock;

[TemplatePart(Name = "PART_SplitterBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class DockSplitter : Control
{
  public static readonly DependencyProperty OrientationProperty;
  private UIElement m_LeftControl;
  private UIElement m_RightControl;
  private DockSplitterAdorner m_PreviewAdorner;
  private bool m_SplitterPreview;
  private int m_MinResizeOffset;
  private int m_MaxResizeOffset;

  static DockSplitter()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockSplitter), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockSplitter)));
    DockSplitter.OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (DockSplitter), (PropertyMetadata) new FrameworkPropertyMetadata((object) Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  }

  public Orientation Orientation
  {
    get => (Orientation) this.GetValue(DockSplitter.OrientationProperty);
    set => this.SetValue(DockSplitter.OrientationProperty, (object) value);
  }

  protected override void OnMouseDown(MouseButtonEventArgs e)
  {
    if (e.ChangedButton == MouseButton.Left && e.ButtonState == MouseButtonState.Pressed)
    {
      this.StartSplitResize();
      e.Handled = true;
    }
    base.OnMouseDown(e);
  }

  private void StartSplitResize()
  {
    if (!Mouse.Capture((IInputElement) this))
      return;
    double num1 = 21.0;
    if (this.RightControl == null)
    {
      UIElement leftControl = this.LeftControl;
      UIElement parent = VisualTreeHelper.GetParent((DependencyObject) leftControl) as UIElement;
      int num2 = parent is AutoHidePopup ? 1 : 0;
      DockSite dockSite = parent as DockSite;
      if (num2 != 0)
        dockSite = ((AutoHidePopup) parent).DockWindow.GetDockSite();
      Dock dock = DockSite.GetDock(leftControl);
      Size size = new Size(32.0, 32.0);
      if (dockSite != null)
        size = dockSite.GetMinimumDocumentAreaSize();
      if (this.Orientation == Orientation.Horizontal)
      {
        this.m_MinResizeOffset = -(int) (leftControl.RenderSize.Height - num1);
        if (dockSite != null)
        {
          if (dock == Dock.Bottom)
          {
            Size renderSize = dockSite.RenderSize;
            double height1 = renderSize.Height;
            renderSize = leftControl.RenderSize;
            double height2 = renderSize.Height;
            this.m_MaxResizeOffset = Math.Max(0, (int) (height1 - height2 - size.Height));
          }
          else
            this.m_MaxResizeOffset = (int) (dockSite.RenderSize.Height - num1 - size.Height);
        }
        else if (parent != null)
          this.m_MaxResizeOffset = (int) (parent.RenderSize.Height - num1);
        if (dock == Dock.Bottom)
        {
          int num3 = -this.m_MaxResizeOffset;
          this.m_MaxResizeOffset = -this.m_MinResizeOffset;
          this.m_MinResizeOffset = num3;
        }
      }
      else
      {
        this.m_MinResizeOffset = -(int) (leftControl.RenderSize.Width - num1);
        if (dockSite != null)
          this.m_MaxResizeOffset = (int) (dockSite.RenderSize.Width - num1 - size.Width);
        else if (parent != null)
          this.m_MaxResizeOffset = (int) (parent.RenderSize.Width - num1);
        if (dock == Dock.Right)
        {
          int num4 = -this.m_MaxResizeOffset;
          this.m_MaxResizeOffset = -this.m_MinResizeOffset;
          this.m_MinResizeOffset = num4;
        }
      }
    }
    else
    {
      UIElement leftControl = this.LeftControl;
      UIElement rightControl = this.RightControl;
      if (this.Orientation == Orientation.Vertical)
      {
        this.m_MinResizeOffset = -(int) (leftControl.RenderSize.Width - num1);
        this.m_MaxResizeOffset = (int) (rightControl.RenderSize.Width - num1);
      }
      else
      {
        this.m_MinResizeOffset = -(int) (leftControl.RenderSize.Height - num1);
        this.m_MaxResizeOffset = (int) (rightControl.RenderSize.Height - num1);
      }
    }
    this.m_PreviewAdorner = new DockSplitterAdorner(this);
    this.m_PreviewAdorner.PreviewBrush = this.TryFindResource((object) new ComponentResourceKey(typeof (DockSite), (object) DockColors.DockSplitterPreviewBrush)) as Brush;
    AdornerLayer.GetAdornerLayer((Visual) this).Add((Adorner) this.m_PreviewAdorner);
    this.m_SplitterPreview = true;
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    if (this.m_SplitterPreview)
    {
      System.Windows.Point position = e.GetPosition((IInputElement) this);
      double num = this.Orientation == Orientation.Horizontal ? position.Y : position.X;
      if (num < (double) this.m_MinResizeOffset)
        num = (double) this.m_MinResizeOffset;
      else if (num > (double) this.m_MaxResizeOffset)
        num = (double) this.m_MaxResizeOffset;
      this.m_PreviewAdorner.Offset = num;
    }
    base.OnMouseMove(e);
  }

  protected override void OnKeyUp(KeyEventArgs e)
  {
    if (this.m_SplitterPreview && e.Key == Key.Escape)
      this.ReleaseMouseCapture();
    base.OnKeyUp(e);
  }

  protected override void OnMouseUp(MouseButtonEventArgs e)
  {
    if (this.m_SplitterPreview && e.LeftButton == MouseButtonState.Released)
    {
      this.ApplyResize();
      this.ReleaseMouseCapture();
    }
    base.OnMouseUp(e);
  }

  private void ApplyResize()
  {
    double num1 = this.m_PreviewAdorner != null ? this.m_PreviewAdorner.Offset : throw new InvalidOperationException("Splitter Preview Adorner null. Cannot apply resize");
    if (this.RightControl == null)
    {
      UIElement leftControl = this.LeftControl;
      Dock dock = DockSite.GetDock(leftControl);
      if (leftControl is SplitPanel && ((FrameworkElement) leftControl).Parent is AutoHidePopup)
      {
        SplitPanel splitPanel = leftControl as SplitPanel;
        double num2 = dock == Dock.Bottom || dock == Dock.Top ? splitPanel.Height : splitPanel.Width;
        double num3 = dock == Dock.Bottom || dock == Dock.Right ? num2 - num1 : num2 + num1;
        AutoHidePopup parent1 = splitPanel.Parent as AutoHidePopup;
        Popup parent2 = parent1.Parent as Popup;
        switch (dock)
        {
          case Dock.Left:
            splitPanel.Width = num3;
            if (parent1.HasAnimatedProperties)
              parent1.BeginAnimation(AutoHideAdorner.RightProperty, (AnimationTimeline) null);
            if (parent2 != null)
            {
              parent1.Width = splitPanel.Width;
              break;
            }
            AutoHideAdorner.SetRight((UIElement) parent1, AutoHideAdorner.GetLeft((UIElement) parent1) + num3);
            break;
          case Dock.Top:
            splitPanel.Height = num3;
            if (parent1.HasAnimatedProperties)
              parent1.BeginAnimation(AutoHideAdorner.BottomProperty, (AnimationTimeline) null);
            if (parent2 != null)
            {
              parent1.Height = splitPanel.Height;
              break;
            }
            AutoHideAdorner.SetBottom((UIElement) parent1, AutoHideAdorner.GetTop((UIElement) parent1) + num3);
            break;
          case Dock.Right:
            splitPanel.Width = num3;
            if (parent1.HasAnimatedProperties)
              parent1.BeginAnimation(AutoHideAdorner.LeftProperty, (AnimationTimeline) null);
            if (parent2 != null)
            {
              parent2.HorizontalOffset += num1;
              parent1.Width = splitPanel.Width;
              break;
            }
            AutoHideAdorner.SetLeft((UIElement) parent1, AutoHideAdorner.GetRight((UIElement) parent1) - num3);
            break;
          case Dock.Bottom:
            splitPanel.Height = num3;
            if (parent1.HasAnimatedProperties)
              parent1.BeginAnimation(AutoHideAdorner.TopProperty, (AnimationTimeline) null);
            if (parent2 != null)
            {
              parent2.VerticalOffset += num1;
              parent1.Height = splitPanel.Height;
              break;
            }
            AutoHideAdorner.SetTop((UIElement) parent1, AutoHideAdorner.GetBottom((UIElement) parent1) - num3);
            break;
        }
      }
      else
      {
        double dockSize = DockSite.GetDockSize(leftControl);
        if (dock == Dock.Bottom || dock == Dock.Right)
          DockSite.SetDockSize(leftControl, dockSize - num1);
        else
          DockSite.SetDockSize(leftControl, dockSize + num1);
      }
    }
    else
    {
      UIElement leftControl = this.LeftControl;
      UIElement rightControl = this.RightControl;
      Size d1 = new Size();
      Size d2 = new Size();
      Size relativeSize1 = SplitPanel.GetRelativeSize(leftControl);
      Size relativeSize2 = SplitPanel.GetRelativeSize(rightControl);
      if (this.Orientation == Orientation.Vertical)
      {
        double num4 = (leftControl.RenderSize.Width + num1) / leftControl.RenderSize.Width;
        d1 = new Size(Math.Round(relativeSize1.Width * num4), relativeSize1.Height);
        Size renderSize = rightControl.RenderSize;
        double num5 = renderSize.Width - num1;
        renderSize = rightControl.RenderSize;
        double width = renderSize.Width;
        double num6 = num5 / width;
        d2 = new Size(Math.Round(relativeSize2.Width * num6), relativeSize2.Height);
      }
      else
      {
        double num7 = (leftControl.RenderSize.Height + num1) / leftControl.RenderSize.Height;
        d1 = new Size(relativeSize1.Width, Math.Round(relativeSize1.Height * num7));
        Size renderSize = rightControl.RenderSize;
        double num8 = renderSize.Height - num1;
        renderSize = rightControl.RenderSize;
        double height = renderSize.Height;
        double num9 = num8 / height;
        d2 = new Size(relativeSize2.Width, Math.Round(relativeSize2.Height * num9));
      }
      SplitPanel.SetRelativeSize(leftControl, d1);
      SplitPanel.SetRelativeSize(rightControl, d2);
    }
  }

  protected override void OnLostMouseCapture(MouseEventArgs e)
  {
    if (this.m_SplitterPreview)
    {
      this.m_SplitterPreview = false;
      AdornerLayer.GetAdornerLayer((Visual) this).Remove((Adorner) this.m_PreviewAdorner);
      this.m_PreviewAdorner.PreviewBrush = (Brush) null;
      this.m_PreviewAdorner = (DockSplitterAdorner) null;
    }
    base.OnLostMouseCapture(e);
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public UIElement LeftControl
  {
    get => this.m_LeftControl;
    internal set => this.m_LeftControl = value;
  }

  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public UIElement RightControl
  {
    get => this.m_RightControl;
    internal set => this.m_RightControl = value;
  }
}
