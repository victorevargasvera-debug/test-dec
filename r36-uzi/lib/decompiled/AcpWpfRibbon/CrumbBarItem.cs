// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CrumbBarItem
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class CrumbBarItem : HeaderedItemsControl
{
  public static readonly DependencyProperty ImageProperty = DependencyProperty.Register(nameof (Image), typeof (object), typeof (CrumbBarItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
  public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof (ImageSource), typeof (string), typeof (CrumbBarItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(CrumbBarItem.OnImageSourceChanged)));
  public static readonly DependencyProperty IsPopupOpenProperty = DependencyProperty.Register(nameof (IsPopupOpen), typeof (bool), typeof (CrumbBarItem), (PropertyMetadata) new UIPropertyMetadata((object) false, new PropertyChangedCallback(CrumbBarItem.OnIsPopupOpenChanged), new CoerceValueCallback(CrumbBarItem.OnCoerceIsPopupOpen)));
  public static readonly DependencyProperty IsPressedProperty = DependencyProperty.Register(nameof (IsPressed), typeof (bool), typeof (CrumbBarItem), (PropertyMetadata) new UIPropertyMetadata((object) false));
  public static readonly DependencyProperty IsMouseOverStateProperty = DependencyProperty.Register(nameof (IsMouseOverState), typeof (bool), typeof (CrumbBarItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty IsSelectedProperty;
  private static readonly DependencyPropertyKey IsSelectedPropertyKey;
  private bool _IsLeftMouseButtonDown;
  private bool _MouseOverInternal;

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public object Image
  {
    get => this.GetValue(CrumbBarItem.ImageProperty);
    set => this.SetValue(CrumbBarItem.ImageProperty, value);
  }

  private static void OnImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is CrumbBarItem crumbBarItem))
      return;
    crumbBarItem.OnImageSourceChanged((string) e.OldValue, (string) e.NewValue);
  }

  protected virtual void OnImageSourceChanged(string oldValue, string newValue)
  {
    string imageSource = this.ImageSource;
    if (imageSource == null || imageSource.Length == 0)
    {
      this.Image = (object) null;
    }
    else
    {
      System.Windows.Controls.Image image;
      try
      {
        BitmapImage bitmapImage = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
        image = new System.Windows.Controls.Image();
        image.Source = (System.Windows.Media.ImageSource) bitmapImage;
        image.Stretch = Stretch.None;
        image.SnapsToDevicePixels = true;
      }
      catch
      {
        this.Image = (object) null;
        return;
      }
      this.Image = (object) image;
    }
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public string ImageSource
  {
    get => (string) this.GetValue(CrumbBarItem.ImageSourceProperty);
    set => this.SetValue(CrumbBarItem.ImageSourceProperty, (object) value);
  }

  private static object OnCoerceIsPopupOpen(DependencyObject o, object value)
  {
    return o is CrumbBarItem crumbBarItem ? (object) crumbBarItem.OnCoerceIsPopupOpen((bool) value) : value;
  }

  private static void OnIsPopupOpenChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is CrumbBarItem crumbBarItem))
      return;
    crumbBarItem.OnIsPopupOpenChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual bool OnCoerceIsPopupOpen(bool value) => value;

  protected virtual void OnIsPopupOpenChanged(bool oldValue, bool newValue)
  {
    this.UpdatePressed();
    this.UpdateIsMouseOverState();
  }

  public bool IsPopupOpen
  {
    get => (bool) this.GetValue(CrumbBarItem.IsPopupOpenProperty);
    set => this.SetValue(CrumbBarItem.IsPopupOpenProperty, (object) value);
  }

  public bool IsPressed
  {
    get => (bool) this.GetValue(CrumbBarItem.IsPressedProperty);
    set => this.SetValue(CrumbBarItem.IsPressedProperty, (object) value);
  }

  public bool IsMouseOverState
  {
    get => (bool) this.GetValue(CrumbBarItem.IsMouseOverStateProperty);
    set => this.SetValue(CrumbBarItem.IsMouseOverStateProperty, (object) value);
  }

  static CrumbBarItem()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (CrumbBarItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (CrumbBarItem)));
    CrumbBarItem.IsSelectedPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsSelected), typeof (bool), typeof (CrumbBarItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    CrumbBarItem.IsSelectedProperty = CrumbBarItem.IsSelectedPropertyKey.DependencyProperty;
  }

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new CrumbBarItem();
  }

  protected override bool IsItemItsOwnContainerOverride(object item) => item is CrumbBarItem;

  internal ItemsControl ParentItemsControl
  {
    get => ItemsControl.ItemsControlFromItemContainer((DependencyObject) this);
  }

  internal CrumbBar ParentCrumbBar
  {
    get
    {
      for (ItemsControl container = this.ParentItemsControl; container != null; container = ItemsControl.ItemsControlFromItemContainer((DependencyObject) container))
      {
        if (container is CrumbBar parentCrumbBar)
          return parentCrumbBar;
      }
      return (CrumbBar) null;
    }
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
    if (new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      this.IsLeftMouseButtonDown = true;
    base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    this.IsLeftMouseButtonDown = false;
    if (new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
    {
      this.Select();
      e.Handled = true;
    }
    base.OnMouseLeftButtonUp(e);
  }

  public void Select()
  {
    CrumbBar tree = this.GetTree();
    if (tree == null)
      return;
    object selectedItem = (object) null;
    ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer((DependencyObject) this);
    if (itemsControl != null)
      selectedItem = itemsControl.ItemContainerGenerator.ItemFromContainer((DependencyObject) this);
    bool flag = false;
    if (selectedItem != null && selectedItem != DependencyProperty.UnsetValue)
    {
      if (tree.SelectedItem != selectedItem)
      {
        tree.SelectedItem = selectedItem;
        tree.SetSelectedItem(selectedItem, this);
        flag = true;
      }
    }
    else if (tree.SelectedItem != this)
    {
      tree.SelectedItem = (object) this;
      flag = true;
    }
    if (!flag)
      return;
    tree.SetOpenedViewItem((CrumbBarItemView) null);
  }

  private CrumbBar GetTree()
  {
    if (this.Parent == null)
    {
      ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer((DependencyObject) this);
      if (itemsControl != null)
      {
        if (itemsControl.TemplatedParent is CrumbBarItemView)
          return ((CrumbBarItemView) itemsControl.TemplatedParent).ParentTree;
        if (itemsControl is CrumbBarItemsControl)
          return ((CrumbBarItemsControl) itemsControl).ParentViewItem.ParentTree;
      }
    }
    if (this.Parent is CrumbBar parent1)
      return parent1;
    for (FrameworkElement parent2 = this.Parent as FrameworkElement; parent2 != null; parent2 = parent2.Parent as FrameworkElement)
    {
      if (parent2 is CrumbBar)
        return (CrumbBar) parent2;
    }
    return (CrumbBar) null;
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

  [Browsable(false)]
  public bool IsSelected
  {
    get => (bool) this.GetValue(CrumbBarItem.IsSelectedProperty);
    internal set => this.SetValue(CrumbBarItem.IsSelectedPropertyKey, (object) value);
  }
}
