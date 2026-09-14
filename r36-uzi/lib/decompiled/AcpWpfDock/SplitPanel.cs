// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.SplitPanel
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock;

[Localizability(LocalizationCategory.Ignore)]
[ContentProperty("Children")]
[DesignTimeVisible(false)]
public class SplitPanel : FrameworkElement
{
  public static readonly DependencyProperty RelativeSizeProperty = DependencyProperty.RegisterAttached("RelativeSize", typeof (Size), typeof (SplitPanel), new PropertyMetadata((object) new Size(100.0, 100.0), new PropertyChangedCallback(SplitPanel.RelativeSizeChanged)));
  public static readonly DependencyProperty OrientationProperty = DependencyProperty.Register(nameof (Orientation), typeof (Orientation), typeof (SplitPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) Orientation.Vertical, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty BackgroundProperty = DependencyProperty.Register(nameof (Background), typeof (Brush), typeof (SplitPanel), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
  internal const double MinDockWindowSize = 20.0;
  private Dictionary<UIElement, DockSplitter> m_Splitters = new Dictionary<UIElement, DockSplitter>();
  private List<DockSplitter> m_SplittersIndexed = new List<DockSplitter>();
  private SplitPanelChildrenCollection m_Children;
  private string m_Id = "";

  static SplitPanel()
  {
    EventManager.RegisterClassHandler(typeof (SplitPanel), DockSite.DockChangedEvent, (Delegate) new RoutedEventHandler(SplitPanel.OnDockChanged));
  }

  public SplitPanel() => this.m_Id = Guid.NewGuid().ToString();

  protected override Size MeasureOverride(Size availableSize)
  {
    return this.MeasureArrange(availableSize, false);
  }

  protected virtual bool IsDocument => DockSite.GetIsDocument((UIElement) this);

  private double GetTotalRelativeSize()
  {
    SplitPanelChildrenCollection internalChildren = this.InternalChildren;
    Size size = new Size();
    foreach (UIElement element in (Collection<UIElement>) internalChildren)
    {
      if (element.Visibility == Visibility.Visible)
      {
        Size relativeSize = SplitPanel.GetRelativeSize(element);
        size.Width += relativeSize.Width;
        size.Height += relativeSize.Height;
      }
    }
    return this.Orientation == Orientation.Horizontal ? size.Width : size.Height;
  }

  private int GetSplitterHeight() => 4;

  private double GetSplitterWidth() => 4.0;

  protected override Size ArrangeOverride(Size finalSize) => this.MeasureArrange(finalSize, true);

  private Size MeasureArrange(Size finalSize, bool isArrange)
  {
    if (finalSize.Width < this.GetSplitterWidth() * (double) (this.m_Splitters.Count + 1) || finalSize.Height < (double) (this.GetSplitterHeight() * (this.m_Splitters.Count + 1)))
      return finalSize;
    SplitPanelChildrenCollection internalChildren = this.InternalChildren;
    Orientation orientation = this.Orientation;
    Size size1 = new Size(this.GetSplitterWidth(), (double) this.GetSplitterHeight());
    double num1 = 0.0;
    Dock dock = DockSite.GetDock((UIElement) this);
    DockSplitter dockSplitter = (DockSplitter) null;
    bool isDocument = this.IsDocument;
    double totalRelativeSize = this.GetTotalRelativeSize();
    Size size2 = finalSize;
    if (!isDocument && this.CanResizeSplitPanel && this.m_Splitters.Count > 0)
    {
      if (orientation == Orientation.Horizontal)
        size2.Height -= (double) this.GetSplitterHeight();
      else
        size2.Width -= this.GetSplitterWidth();
      dockSplitter = this.m_SplittersIndexed[0];
      Rect finalRect = new Rect(finalSize.Width - size1.Width, 0.0, size1.Width, finalSize.Height);
      switch (dock)
      {
        case Dock.Top:
          finalRect = new Rect(0.0, finalSize.Height - size1.Height, finalSize.Width, size1.Height);
          break;
        case Dock.Right:
          finalRect = new Rect(0.0, 0.0, size1.Width, finalSize.Height);
          break;
        case Dock.Bottom:
          finalRect = new Rect(0.0, 0.0, finalSize.Width, size1.Height);
          break;
      }
      if (isArrange)
        dockSplitter.Arrange(finalRect);
      else
        dockSplitter.Measure(finalRect.Size);
    }
    if (orientation == Orientation.Horizontal)
      size2.Width = Math.Max(20.0, size2.Width - Math.Ceiling((double) Math.Max(0, this.m_Splitters.Count - (!isDocument ? 1 : 0)) * size1.Width));
    else
      size2.Height = Math.Max(20.0, size2.Height - Math.Ceiling((double) Math.Max(0, this.m_Splitters.Count - (!isDocument ? 1 : 0)) * size1.Height));
    double num2 = orientation == Orientation.Horizontal ? size1.Width : size1.Height;
    double val1 = orientation == Orientation.Horizontal ? size2.Width : size2.Height;
    foreach (UIElement uiElement in (Collection<UIElement>) internalChildren)
    {
      if (uiElement.Visibility != Visibility.Collapsed)
      {
        Size relativeSize = SplitPanel.GetRelativeSize(uiElement);
        Size size3 = size2;
        if (orientation == Orientation.Horizontal)
          size3.Width = Math.Min(val1, Math.Max(20.0, Math.Ceiling(size2.Width * (relativeSize.Width / totalRelativeSize))));
        else
          size3.Height = Math.Min(val1, Math.Max(20.0, Math.Ceiling(size2.Height * (relativeSize.Height / totalRelativeSize))));
        Rect finalRect1 = orientation != Orientation.Horizontal ? new Rect(dock == Dock.Right ? size1.Width : 0.0, num1, size3.Width, size3.Height) : new Rect(num1, dock == Dock.Bottom ? size1.Height : 0.0, size3.Width, size3.Height);
        if (isArrange)
          uiElement.Arrange(finalRect1);
        else
          uiElement.Measure(finalRect1.Size);
        this.m_Splitters.TryGetValue(uiElement, out dockSplitter);
        if (dockSplitter != null)
        {
          Rect finalRect2 = new Rect(finalRect1.X, finalRect1.Bottom, finalRect1.Width, num2);
          if (orientation == Orientation.Horizontal)
            finalRect2 = new Rect(finalRect1.Right, finalRect1.Y, num2, finalRect1.Height);
          if (isArrange)
            dockSplitter.Arrange(finalRect2);
          else
            dockSplitter.Measure(finalRect2.Size);
        }
        dockSplitter = (DockSplitter) null;
        if (orientation == Orientation.Horizontal)
        {
          num1 += size3.Width + num2;
          val1 -= size3.Width;
        }
        else
        {
          num1 += size3.Height + num2;
          val1 -= size3.Height;
        }
        if (val1 < 20.0)
          val1 = 20.0;
      }
    }
    if (isArrange)
      return finalSize;
    Size arrangeBounds = new Size();
    if (this.Orientation == Orientation.Horizontal)
    {
      arrangeBounds.Width = finalSize.Width;
      arrangeBounds.Height = !(this.Parent is AutoHidePopup) ? DockSite.GetDockSize((UIElement) this) : finalSize.Height;
    }
    else
    {
      arrangeBounds.Height = finalSize.Height;
      arrangeBounds.Width = !(this.Parent is AutoHidePopup) ? DockSite.GetDockSize((UIElement) this) : finalSize.Width;
    }
    LayoutHelpers.NormalizeMeasureBounds(ref arrangeBounds);
    return arrangeBounds;
  }

  [AttachedPropertyBrowsableForChildren]
  public static Size GetRelativeSize(UIElement element)
  {
    return element != null ? (Size) element.GetValue(SplitPanel.RelativeSizeProperty) : throw new ArgumentNullException(nameof (element));
  }

  public static void SetRelativeSize(UIElement element, Size d)
  {
    if (element == null)
      throw new ArgumentNullException(nameof (element));
    element.SetValue(SplitPanel.RelativeSizeProperty, (object) d);
  }

  private static void RelativeSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (!(d is UIElement reference))
      return;
    reference.InvalidateMeasure();
    if (!(VisualTreeHelper.GetParent((DependencyObject) reference) is FrameworkElement parent))
      return;
    parent.InvalidateMeasure();
  }

  private static void OnDockChanged(object sender, RoutedEventArgs e)
  {
    if (!(e.Source is SplitPanel source))
      return;
    source.RecreateSplitters();
  }

  public Orientation Orientation
  {
    get => (Orientation) this.GetValue(SplitPanel.OrientationProperty);
    set => this.SetValue(SplitPanel.OrientationProperty, (object) value);
  }

  protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
  {
    if (e.Property == DockSite.IsDocumentProperty)
      this.RecreateSplitters();
    base.OnPropertyChanged(e);
  }

  private void RecreateSplitters()
  {
    foreach (DockSplitter child in this.m_SplittersIndexed)
    {
      this.RemoveVisualChild((Visual) child);
      this.RemoveLogicalChild((object) child);
      child.LeftControl = (UIElement) null;
      child.RightControl = (UIElement) null;
    }
    this.m_Splitters.Clear();
    this.m_SplittersIndexed.Clear();
    if (this.Children.Count == 0 || this.Children.Count == 1 && this.IsDocument)
      return;
    Dock dock = DockSite.GetDock((UIElement) this);
    DockSplitter dockSplitter1 = (DockSplitter) null;
    if (this.CanResizeSplitPanel)
    {
      DockSplitter dockSplitter2 = new DockSplitter();
      dockSplitter2.Focusable = false;
      dockSplitter2.LeftControl = (UIElement) this;
      dockSplitter2.Orientation = dock == Dock.Left || dock == Dock.Right ? Orientation.Vertical : Orientation.Horizontal;
      this.m_Splitters.Add((UIElement) this, dockSplitter2);
      this.m_SplittersIndexed.Add(dockSplitter2);
      dockSplitter1 = (DockSplitter) null;
    }
    Orientation orientation = this.Orientation == Orientation.Horizontal ? Orientation.Vertical : Orientation.Horizontal;
    UIElement key = (UIElement) null;
    foreach (UIElement child in (Collection<UIElement>) this.Children)
    {
      if (child.Visibility == Visibility.Visible)
      {
        if (key == null)
        {
          key = child;
        }
        else
        {
          DockSplitter dockSplitter3 = new DockSplitter();
          dockSplitter3.Focusable = false;
          dockSplitter3.LeftControl = key;
          dockSplitter3.RightControl = child;
          dockSplitter3.Orientation = orientation;
          this.m_Splitters.Add(key, dockSplitter3);
          this.m_SplittersIndexed.Add(dockSplitter3);
          key = child;
        }
      }
    }
    foreach (DockSplitter child in this.m_SplittersIndexed)
    {
      this.AddVisualChild((Visual) child);
      this.AddLogicalChild((object) child);
    }
    this.OnSplittersRecreated(new EventArgs());
  }

  public event EventHandler SplittersUpdating;

  protected virtual void OnSplittersUpdating(EventArgs e)
  {
    EventHandler splittersUpdating = this.SplittersUpdating;
    if (splittersUpdating == null)
      return;
    splittersUpdating((object) this, e);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public List<DockSplitter> Splitters => this.m_SplittersIndexed;

  public event EventHandler SplittersRecreated;

  protected virtual void OnSplittersRecreated(EventArgs e)
  {
    EventHandler splittersRecreated = this.SplittersRecreated;
    if (splittersRecreated == null)
      return;
    splittersRecreated((object) this, e);
  }

  protected override int VisualChildrenCount => this.Children.Count + this.m_Splitters.Count;

  protected override Visual GetVisualChild(int index)
  {
    return index >= this.Children.Count ? (Visual) this.m_SplittersIndexed[index - this.Children.Count] : (Visual) this.Children[index];
  }

  protected virtual SplitPanelChildrenCollection CreateUIElementCollection()
  {
    return new SplitPanelChildrenCollection(this);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public SplitPanelChildrenCollection Children => this.InternalChildren;

  protected internal SplitPanelChildrenCollection InternalChildren
  {
    get
    {
      if (this.m_Children == null)
      {
        this.m_Children = this.CreateUIElementCollection();
        this.m_Children.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ChildrenChanged);
      }
      return this.m_Children;
    }
  }

  internal void OnChildrenClear()
  {
    foreach (UIElement child in (Collection<UIElement>) this.Children)
    {
      this.RemoveLogicalChild((object) child);
      this.RemoveVisualChild((Visual) child);
    }
  }

  private void ChildrenChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    bool isDocument = DockSite.GetIsDocument((UIElement) this);
    if (e.Action != NotifyCollectionChangedAction.Move)
    {
      if (e.OldItems != null)
      {
        foreach (UIElement oldItem in (IEnumerable) e.OldItems)
        {
          this.RemoveLogicalChild((object) oldItem);
          this.RemoveVisualChild((Visual) oldItem);
          if (isDocument)
            DockSite.SetIsDocument(oldItem, false);
        }
      }
      if (e.NewItems != null)
      {
        foreach (UIElement newItem in (IEnumerable) e.NewItems)
        {
          this.AddLogicalChild((object) newItem);
          this.AddVisualChild((Visual) newItem);
          DockSite.SetIsDocument(newItem, isDocument);
        }
      }
    }
    this.RecreateSplitters();
    this.UpdateIsDocument();
    this.InvalidateMeasure();
  }

  private void UpdateIsDocument()
  {
    DockSite dockSite = this.GetDockSite();
    if (dockSite == null)
      return;
    bool isDocument = DockSite.GetIsDocument((UIElement) this);
    foreach (UIElement child in (Collection<UIElement>) this.Children)
    {
      DockSite.SetIsDocument(child, isDocument);
      if (child is DockWindowGroup group)
        dockSite.UpdateIsDocument(group);
    }
  }

  public DockSite GetDockSite() => DockSite.GetDockSite((DependencyObject) this);

  [DefaultValue(null)]
  public Brush Background
  {
    get => (Brush) this.GetValue(SplitPanel.BackgroundProperty);
    set => this.SetValue(SplitPanel.BackgroundProperty, (object) value);
  }

  protected override void OnRender(DrawingContext dc)
  {
    Brush background = this.Background;
    if (background == null)
      return;
    DrawingContext drawingContext = dc;
    Brush brush = background;
    Size renderSize = this.RenderSize;
    double width = renderSize.Width;
    renderSize = this.RenderSize;
    double height = renderSize.Height;
    Rect rectangle = new Rect(0.0, 0.0, width, height);
    drawingContext.DrawRectangle(brush, (Pen) null, rectangle);
  }

  public UIElement GetDockedElementAt(System.Windows.Point p)
  {
    foreach (UIElement internalChild in (Collection<UIElement>) this.InternalChildren)
    {
      if (internalChild.Visibility == Visibility.Visible && LayoutInformation.GetLayoutSlot(internalChild as FrameworkElement).Contains(p))
      {
        if (!(internalChild is SplitPanel))
          return internalChild;
        System.Windows.Point p1 = internalChild.PointFromScreen(this.PointToScreen(p));
        UIElement dockedElementAt = ((SplitPanel) internalChild).GetDockedElementAt(p1);
        if (dockedElementAt != null)
          return dockedElementAt;
      }
    }
    return (UIElement) null;
  }

  private bool CanResizeSplitPanel
  {
    get => !(this.Parent is SplitPanel) && !this.IsDocument && !(this.Parent is FloatingWindow);
  }

  [EditorBrowsable(EditorBrowsableState.Never)]
  public void UpdateAutoVisibility()
  {
    if (this.VisibleItemsCount == 0)
    {
      if (this.Visibility == Visibility.Visible)
        this.Visibility = Visibility.Collapsed;
      if (this.Parent is SplitPanel)
        ((SplitPanel) this.Parent).UpdateAutoVisibility();
    }
    else if (this.Visibility == Visibility.Collapsed)
    {
      this.Visibility = Visibility.Visible;
      if (this.Parent is SplitPanel)
        ((SplitPanel) this.Parent).UpdateAutoVisibility();
    }
    this.RecreateSplitters();
  }

  [Bindable(false)]
  [Browsable(false)]
  [EditorBrowsable(EditorBrowsableState.Never)]
  public int VisibleItemsCount
  {
    get
    {
      int visibleItemsCount = 0;
      foreach (UIElement child in (Collection<UIElement>) this.Children)
      {
        if (child.Visibility == Visibility.Visible && !(child is DockSplitter))
          ++visibleItemsCount;
      }
      return visibleItemsCount;
    }
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      if (this.m_SplittersIndexed.Count <= 0)
        return (IEnumerator) this.m_Children.GetEnumerator();
      List<UIElement> uiElementList = new List<UIElement>((IEnumerable<UIElement>) this.m_Children);
      foreach (UIElement uiElement in this.m_SplittersIndexed)
        uiElementList.Add(uiElement);
      return (IEnumerator) uiElementList.GetEnumerator();
    }
  }

  [Browsable(false)]
  public string Id => this.m_Id;
}
