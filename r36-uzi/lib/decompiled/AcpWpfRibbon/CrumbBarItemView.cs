// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarItemView
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CrumbBarItemView : Control
{
  public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(nameof (Header), typeof (object), typeof (CrumbBarItemView), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
  public static readonly DependencyProperty CrumbBarItemProperty = DependencyProperty.Register(nameof (CrumbBarItem), typeof (CrumbBarItem), typeof (CrumbBarItemView), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(CrumbBarItemView.OnCrumbBarItemChanged)));
  public static readonly DependencyProperty IsOverflowItemProperty = DependencyProperty.Register(nameof (IsOverflowItem), typeof (bool), typeof (CrumbBarItemView), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsPopupOpenProperty = DependencyProperty.Register(nameof (IsPopupOpen), typeof (bool), typeof (CrumbBarItemView), (PropertyMetadata) new UIPropertyMetadata((object) false, new PropertyChangedCallback(CrumbBarItemView.OnIsPopupOpenChanged), new CoerceValueCallback(CrumbBarItemView.OnCoerceIsPopupOpen)));
  public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(nameof (IsPressed), typeof (bool), typeof (CrumbBarItemView), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsMouseOverStateProperty = DependencyProperty.Register(nameof (IsMouseOverState), typeof (bool), typeof (CrumbBarItemView), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  private Popup _Popup;
  private ScrollViewer _ScrollViewer;
  private CrumbBar _ParentTree;
  private bool _IsLeftMouseButtonDown;
  private bool _MouseOverInternal;
  private CrumbBarItemsControl _ItemsControl;

  public object Header
  {
    get => this.GetValue(CrumbBarItemView.HeaderProperty);
    set => this.SetValue(CrumbBarItemView.HeaderProperty, value);
  }

  private static void OnCrumbBarItemChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is CrumbBarItemView crumbBarItemView))
      return;
    crumbBarItemView.OnCrumbBarItemChanged((CrumbBarItem) e.OldValue, (CrumbBarItem) e.NewValue);
  }

  protected virtual void OnCrumbBarItemChanged(CrumbBarItem oldValue, CrumbBarItem newValue)
  {
    BindingOperations.ClearBinding((DependencyObject) this, CrumbBarItemView.HeaderProperty);
    if (newValue == null)
      return;
    this.SetBinding(CrumbBarItemView.HeaderProperty, (BindingBase) new Binding("Header")
    {
      Source = (object) newValue,
      Mode = BindingMode.OneWay
    });
  }

  public CrumbBarItem CrumbBarItem
  {
    get => (CrumbBarItem) this.GetValue(CrumbBarItemView.CrumbBarItemProperty);
    set => this.SetValue(CrumbBarItemView.CrumbBarItemProperty, (object) value);
  }

  public bool IsOverflowItem
  {
    get => (bool) this.GetValue(CrumbBarItemView.IsOverflowItemProperty);
    set => this.SetValue(CrumbBarItemView.IsOverflowItemProperty, (object) value);
  }

  private static object OnCoerceIsPopupOpen(DependencyObject o, object value)
  {
    return o is CrumbBarItemView crumbBarItemView ? (object) crumbBarItemView.OnCoerceIsPopupOpen((bool) value) : value;
  }

  private static void OnIsPopupOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is CrumbBarItemView crumbBarItemView))
      return;
    crumbBarItemView.OnIsPopupOpenChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual bool OnCoerceIsPopupOpen(bool value) => value;

  protected virtual void OnIsPopupOpenChanged(bool oldValue, bool newValue)
  {
    this.UpdatePressed();
    this.UpdateIsMouseOverState();
  }

  [Browsable(false)]
  public bool IsPopupOpen
  {
    get => (bool) this.GetValue(CrumbBarItemView.IsPopupOpenProperty);
    set => this.SetValue(CrumbBarItemView.IsPopupOpenProperty, (object) value);
  }

  public bool IsPressed
  {
    get => (bool) this.GetValue(CrumbBarItemView.IsPressedProperty);
    set => this.SetValue(CrumbBarItemView.IsPressedProperty, (object) value);
  }

  public bool IsMouseOverState
  {
    get => (bool) this.GetValue(CrumbBarItemView.IsMouseOverStateProperty);
    set => this.SetValue(CrumbBarItemView.IsMouseOverStateProperty, (object) value);
  }

  static CrumbBarItemView()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CrumbBarItemView), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CrumbBarItemView)));
  }

  public override void OnApplyTemplate()
  {
    if (this._ScrollViewer != null)
      this._ScrollViewer.Content = (object) null;
    if (this._Popup != null)
    {
      this._Popup.Opened -= new EventHandler(this.PopupOpened);
      this._Popup.Closed -= new EventHandler(this.PopupClosed);
    }
    this._Popup = this.GetTemplateChild("PART_Popup") as Popup;
    if (this._Popup != null)
    {
      this._Popup.Opened += new EventHandler(this.PopupOpened);
      this._Popup.Closed += new EventHandler(this.PopupClosed);
    }
    this._ScrollViewer = this.GetTemplateChild("PART_ItemsScrollViewer") as ScrollViewer;
    if (this._ScrollViewer != null)
      this._ScrollViewer.Content = (object) this.GetItemsControl();
    base.OnApplyTemplate();
  }

  private void PopupClosed(object sender, EventArgs e) => this.GetTree()?.ViewItemClosed(this);

  private void PopupOpened(object sender, EventArgs e) => this.GetTree()?.SetOpenedViewItem(this);

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    this.CrumbBarItem.Select();
    base.OnMouseLeftButtonUp(e);
  }

  private CrumbBar GetTree() => this._ParentTree;

  internal CrumbBar ParentTree
  {
    get => this._ParentTree;
    set => this._ParentTree = value;
  }

  private void UpdatePressed() => this.IsPressed = this.IsPopupOpen || this._IsLeftMouseButtonDown;

  private bool IsLeftMouseButtonDown
  {
    get => this._IsLeftMouseButtonDown;
    set
    {
      if (this._IsLeftMouseButtonDown == value)
        return;
      this._IsLeftMouseButtonDown = value;
      this.UpdatePressed();
    }
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this.IsLeftMouseButtonDown = true;
    base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseUp(MouseButtonEventArgs e)
  {
    if (e.ChangedButton == MouseButton.Left)
      this.IsLeftMouseButtonDown = false;
    base.OnMouseUp(e);
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    if (new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      this.MouseOverInternal = true;
    base.OnMouseEnter(e);
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    this.MouseOverInternal = new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this));
    base.OnMouseMove(e);
  }

  private bool MouseOverInternal
  {
    get => this._MouseOverInternal;
    set
    {
      if (this._MouseOverInternal == value)
        return;
      this._MouseOverInternal = value;
      this.UpdateIsMouseOverState();
      if (!this.GetTree().IsMenuMode || !this.CrumbBarItem.HasItems || this.IsPopupOpen || this.IsOverflowItem)
        return;
      this.IsPopupOpen = true;
    }
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    this.MouseOverInternal = false;
    base.OnMouseLeave(e);
  }

  private void UpdateIsMouseOverState()
  {
    this.IsMouseOverState = this._MouseOverInternal | this.IsPopupOpen;
  }

  internal void ClosePopup() => this.IsPopupOpen = false;

  private CrumbBarItemsControl GetItemsControl()
  {
    if (this._ItemsControl == null)
    {
      this._ItemsControl = new CrumbBarItemsControl();
      this._ItemsControl.SetBinding(ItemsControl.ItemsSourceProperty, (BindingBase) new Binding("CrumbBarItem.Items")
      {
        Source = (object) this
      });
      this._ItemsControl.SetBinding(ItemsControl.ItemTemplateProperty, (BindingBase) new Binding("CrumbBarItem.ItemTemplate")
      {
        Source = (object) this
      });
      this._ItemsControl.SetBinding(ItemsControl.ItemTemplateSelectorProperty, (BindingBase) new Binding("CrumbBarItem.ItemTemplateSelector")
      {
        Source = (object) this
      });
      this._ItemsControl.Margin = new Thickness(2.0);
      Grid.SetIsSharedSizeScope((UIElement) this._ItemsControl, true);
      this._ItemsControl.SnapsToDevicePixels = true;
      this._ItemsControl.ParentViewItem = this;
    }
    return this._ItemsControl;
  }
}
