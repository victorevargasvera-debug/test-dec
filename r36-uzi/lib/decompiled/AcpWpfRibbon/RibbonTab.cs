// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.RibbonTab
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_RibbonTabBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class RibbonTab : HeaderedContentControl
{
  public static readonly DependencyProperty IsSelectedProperty;
  public static readonly DependencyProperty ContextGroupProperty;
  public static readonly DependencyProperty ColorProperty;
  public static readonly DependencyProperty TabColorProperty;
  private RibbonTabBorder m_TabBorder;
  private const string RibbonTabBorderName = "PART_RibbonTabBorder";
  internal static int MinimumTabWidth = 24;
  private bool m_IsMinimizedState;
  private bool m_IsRibbonMenuOpen;

  static RibbonTab()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (RibbonTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (RibbonTab)));
    RibbonTab.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (RibbonTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(RibbonTab.OnIsSelectedChanged)));
    RibbonTab.ContextGroupProperty = DependencyProperty.Register(nameof (ContextGroup), typeof (ContextGroup), typeof (RibbonTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(RibbonTab.OnContextGroupChanged)));
    RibbonTab.ColorProperty = DependencyProperty.Register(nameof (Color), typeof (eRibbonTabColor), typeof (RibbonTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonTabColor.Default, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(RibbonTab.OnColorChanged)));
    RibbonTab.TabColorProperty = DependencyProperty.RegisterAttached("TabColor", typeof (eRibbonTabColor), typeof (RibbonTab), new PropertyMetadata((object) eRibbonTabColor.Default));
  }

  [DefaultValue(null)]
  public ContextGroup ContextGroup
  {
    get => (ContextGroup) this.GetValue(RibbonTab.ContextGroupProperty);
    set => this.SetValue(RibbonTab.ContextGroupProperty, (object) value);
  }

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    this.m_TabBorder = this.GetTemplateChild("PART_RibbonTabBorder") as RibbonTabBorder;
    this.UpdateBorderRenderState();
    this.UpdateTabBorderColorClass();
  }

  protected override void OnContentChanged(object oldContent, object newContent)
  {
    base.OnContentChanged(oldContent, newContent);
    if (this.IsSelected)
    {
      Ribbon parentRibbon = this.ParentRibbon;
      if (parentRibbon != null)
        parentRibbon.SelectedContent = newContent;
    }
    if (oldContent is UIElement)
      RibbonTab.SetTabColor((UIElement) oldContent, eRibbonTabColor.Default);
    if (!(newContent is UIElement))
      return;
    RibbonTab.SetTabColor((UIElement) newContent, this.Color);
  }

  internal Ribbon ParentRibbon
  {
    get => ItemsControl.ItemsControlFromItemContainer((DependencyObject) this) as Ribbon;
  }

  protected override void OnAccessKey(AccessKeyEventArgs e)
  {
    Ribbon parentRibbon = this.ParentRibbon;
    if (!this.IsSelected)
    {
      if (parentRibbon != null && parentRibbon.IsMinimized && !parentRibbon.IsRibbonMenuOpen)
        parentRibbon.IsRibbonMenuOpen = true;
      this.IsSelected = true;
    }
    parentRibbon?.EnterKeyTipsMode();
    base.OnAccessKey(e);
  }

  [DefaultValue(eRibbonTabColor.Default)]
  public eRibbonTabColor Color
  {
    get => (eRibbonTabColor) this.GetValue(RibbonTab.ColorProperty);
    set => this.SetValue(RibbonTab.ColorProperty, (object) value);
  }

  private static void OnColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    (d as RibbonTab).OnColorChanged((eRibbonTabColor) e.NewValue);
  }

  private void OnColorChanged(eRibbonTabColor newValue) => this.UpdateTabBorderColorClass();

  private void UpdateTabBorderColorClass()
  {
    if (this.m_TabBorder == null)
      return;
    eRibbonTabColor color = this.Color;
    if (color == eRibbonTabColor.Default)
      this.m_TabBorder.ColorClass = RibbonColors.RibbonTabClass;
    else
      this.m_TabBorder.ColorClass = RibbonColors.RibbonTabClass + color.ToString();
  }

  private static void OnContextGroupChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    (d as RibbonTab).OnContextGroupChanged(e.OldValue as ContextGroup, e.NewValue as ContextGroup);
  }

  private void OnContextGroupChanged(ContextGroup oldGroup, ContextGroup newGroup)
  {
    oldGroup?.LinkedTabs.Remove(this);
    newGroup?.LinkedTabs.Add(this);
  }

  private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    RibbonTab source = d as RibbonTab;
    if ((bool) e.NewValue)
      source.OnSelected(new RoutedEventArgs(Selector.SelectedEvent, (object) source));
    else
      source.OnUnselected(new RoutedEventArgs(Selector.UnselectedEvent, (object) source));
    source.UpdateBorderRenderState();
  }

  protected virtual void OnSelected(RoutedEventArgs e)
  {
    if (this.Content is UIElement)
    {
      UIElement content = (UIElement) this.Content;
      content.ClearValue(RibbonTab.TabColorProperty);
      RibbonTab.SetTabColor(content, this.Color);
    }
    this.RaiseSelectedEvents(true, e);
  }

  protected virtual void OnUnselected(RoutedEventArgs e) => this.RaiseSelectedEvents(false, e);

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    base.OnGotKeyboardFocus(e);
    if (e.Handled || e.NewFocus != this || this.IsSelected)
      return;
    this.IsSelected = true;
  }

  private void RaiseSelectedEvents(bool newValue, RoutedEventArgs e) => this.RaiseEvent(e);

  [Category("Appearance")]
  [Bindable(true)]
  public bool IsSelected
  {
    get => (bool) this.GetValue(RibbonTab.IsSelectedProperty);
    set => this.SetValue(RibbonTab.IsSelectedProperty, (object) value);
  }

  protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
  {
    if (e.LeftButton == MouseButtonState.Pressed && e.Source == this)
    {
      Ribbon ribbon = this.GetRibbon();
      if (ribbon != null && ribbon.AutoExpand)
      {
        ribbon.IsMinimized = !ribbon.IsMinimized;
        e.Handled = true;
      }
    }
    base.OnMouseDoubleClick(e);
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    base.OnMouseLeftButtonDown(e);
    if (!WinApi.KeyValidated || e.Source != this || this.IsSelected && (!this.m_IsMinimizedState || this.m_IsRibbonMenuOpen))
      return;
    if (!this.IsSelected)
      this.IsSelected = true;
    e.Handled = true;
    if (!this.m_IsMinimizedState || this.m_IsRibbonMenuOpen)
      return;
    Ribbon ribbon = this.GetRibbon();
    if (ribbon == null)
      return;
    Window window = Window.GetWindow((DependencyObject) ribbon);
    if (window != null && !window.IsActive)
      return;
    ribbon.IsRibbonMenuOpen = true;
  }

  private Ribbon GetRibbon()
  {
    if (this.TemplatedParent is Ribbon)
      return this.TemplatedParent as Ribbon;
    if (this.Parent is Ribbon)
      return this.Parent as Ribbon;
    DependencyObject reference = (DependencyObject) this;
    while (reference != null)
    {
      reference = VisualTreeHelper.GetParent(reference);
      if (reference is Ribbon)
        return reference as Ribbon;
    }
    return (Ribbon) null;
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    base.OnMouseEnter(e);
    this.UpdateBorderRenderState();
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    base.OnMouseLeave(e);
    this.UpdateBorderRenderState();
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    base.OnMouseMove(e);
    if (!this.IsSelected)
      return;
    this.UpdateBorderRenderState();
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    base.OnIsKeyboardFocusWithinChanged(e);
    this.UpdateBorderRenderState();
  }

  private bool RibbonKeyTipsEnabled
  {
    get
    {
      Ribbon ribbon = this.GetRibbon();
      return ribbon != null && ribbon.ShowKeyTips;
    }
  }

  internal void UpdateBorderRenderState()
  {
    if (this.m_TabBorder == null)
      return;
    eRibbonTabRenderingState tabRenderingState = eRibbonTabRenderingState.Normal;
    if (this.IsKeyboardFocusWithin && this.RibbonKeyTipsEnabled)
      tabRenderingState = eRibbonTabRenderingState.Focused;
    else if (this.IsMouseOver)
    {
      if (this.IsSelected)
      {
        Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
        if (this.m_IsMinimizedState)
        {
          if (this.m_IsRibbonMenuOpen)
            tabRenderingState = eRibbonTabRenderingState.Selected;
          else if (rect.Contains(Mouse.GetPosition((IInputElement) this)))
            tabRenderingState = eRibbonTabRenderingState.Hover;
        }
        else
          tabRenderingState = !rect.Contains(Mouse.GetPosition((IInputElement) this)) ? eRibbonTabRenderingState.Selected : eRibbonTabRenderingState.HoverSelected;
      }
      else
        tabRenderingState = eRibbonTabRenderingState.Hover;
    }
    else if (this.IsSelected && (!this.m_IsMinimizedState || this.m_IsRibbonMenuOpen))
      tabRenderingState = eRibbonTabRenderingState.Selected;
    if (this.m_TabBorder.TabState == tabRenderingState)
      return;
    this.m_TabBorder.TabState = tabRenderingState;
  }

  internal bool IsMinimizedState
  {
    get => this.m_IsMinimizedState;
    set
    {
      if (this.m_IsMinimizedState == value)
        return;
      this.m_IsMinimizedState = value;
      this.UpdateBorderRenderState();
    }
  }

  internal bool IsRibbonMenuOpen
  {
    get => this.m_IsRibbonMenuOpen;
    set
    {
      if (this.m_IsRibbonMenuOpen == value)
        return;
      this.m_IsRibbonMenuOpen = value;
      this.UpdateBorderRenderState();
    }
  }

  protected override Size MeasureOverride(Size constraint)
  {
    Size size = base.MeasureOverride(constraint);
    if (Math.Ceiling(size.Width) < Math.Ceiling(constraint.Width) && this.ContextGroup != null && this.ContextGroup.Visibility == Visibility.Visible && this.ContextGroup.LinkedTabs.Count == 1)
    {
      this.ContextGroup.Measure(constraint);
      if (this.ContextGroup.DesiredSize.Width > size.Width)
        size.Width = Math.Ceiling(this.ContextGroup.DesiredSize.Width);
    }
    return size;
  }

  [AttachedPropertyBrowsableForChildren]
  public static eRibbonTabColor GetTabColor(UIElement element)
  {
    return element != null ? (eRibbonTabColor) element.GetValue(RibbonTab.TabColorProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetTabColor(UIElement element, eRibbonTabColor tabColor)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(RibbonTab.TabColorProperty, (object) tabColor);
  }
}
