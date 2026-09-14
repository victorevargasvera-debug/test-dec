// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.PaneItem
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
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class PaneItem : HeaderedContentControl
{
  public static readonly DependencyProperty IsSelectedProperty;
  public static readonly DependencyProperty ImageProperty;
  public static readonly DependencyProperty ImageSourceProperty;
  public static readonly DependencyProperty ImageSmallProperty;
  public static readonly DependencyProperty ImageSmallSourceProperty;
  public static readonly DependencyProperty TitleProperty;
  public static readonly DependencyProperty SmallStateProperty;
  public static readonly DependencyProperty PaneExpandedProperty;
  private bool _MouseLeftButtonDown;
  private bool _ToolTipSet;

  static PaneItem()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (PaneItem)));
    UIElement.VisibilityProperty.OverrideMetadata(typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata(new PropertyChangedCallback(PaneItem.VisibilityChanged)));
    PaneItem.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(PaneItem.OnIsSelectedChanged)));
    PaneItem.ImageProperty = DependencyProperty.Register(nameof (Image), typeof (object), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    PaneItem.ImageSourceProperty = DependencyProperty.Register(nameof (ImageSource), typeof (string), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(PaneItem.ImageSourceChanged)));
    PaneItem.ImageSmallProperty = DependencyProperty.Register(nameof (ImageSmall), typeof (object), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    PaneItem.ImageSmallSourceProperty = DependencyProperty.Register(nameof (ImageSmallSource), typeof (string), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(PaneItem.ImageSmallSourceChanged)));
    PaneItem.TitleProperty = DependencyProperty.Register(nameof (Title), typeof (string), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    PaneItem.SmallStateProperty = DependencyProperty.Register(nameof (SmallState), typeof (bool), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange, new PropertyChangedCallback(PaneItem.SmallStateChanged)));
    PaneItem.PaneExpandedProperty = DependencyProperty.Register(nameof (PaneExpanded), typeof (bool), typeof (PaneItem), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, new PropertyChangedCallback(PaneItem.PaneExpandedChanged)));
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    this._MouseLeftButtonDown = true;
    this.CaptureMouse();
    base.OnMouseLeftButtonDown(e);
  }

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    if (this.IsMouseCaptured)
      this.ReleaseMouseCapture();
    if (!WinApi.KeyValidated)
      return;
    if (this._MouseLeftButtonDown && new Rect(new System.Windows.Point(), this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      this.IsSelected = true;
    this._MouseLeftButtonDown = false;
    base.OnMouseLeftButtonUp(e);
  }

  [Category("Appearance")]
  [Bindable(true)]
  public bool IsSelected
  {
    get => (bool) this.GetValue(PaneItem.IsSelectedProperty);
    set => this.SetValue(PaneItem.IsSelectedProperty, (object) value);
  }

  private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    PaneItem source = d as PaneItem;
    if ((bool) e.NewValue)
      source.OnSelected(new RoutedEventArgs(Selector.SelectedEvent, (object) source));
    else
      source.OnUnselected(new RoutedEventArgs(Selector.UnselectedEvent, (object) source));
  }

  protected virtual void OnSelected(RoutedEventArgs e) => this.RaiseSelectedEvents(true, e);

  protected virtual void OnUnselected(RoutedEventArgs e) => this.RaiseSelectedEvents(false, e);

  private void RaiseSelectedEvents(bool newValue, RoutedEventArgs e) => this.RaiseEvent(e);

  private static void VisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((PaneItem) d).VisibilityChanged();
  }

  private void VisibilityChanged()
  {
    if (this.Parent is NavigationPane parent)
      parent.UpdateItemsState();
    parent.ItemVisibilityChanged(this);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public object Image
  {
    get => this.GetValue(PaneItem.ImageProperty);
    set => this.SetValue(PaneItem.ImageProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public string ImageSource
  {
    get => (string) this.GetValue(PaneItem.ImageSourceProperty);
    set => this.SetValue(PaneItem.ImageSourceProperty, (object) value);
  }

  private static void ImageSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((PaneItem) d).ImageSourceChanged();
  }

  private void ImageSourceChanged()
  {
    this.Image = (object) this.LoadImage(this.ImageSource);
    if (this.ImageSmall != null || this.Image == null)
      return;
    this.ImageSmall = (object) this.LoadImage(this.ImageSource);
    if (!(this.ImageSmall is System.Windows.Controls.Image))
      return;
    System.Windows.Controls.Image imageSmall = (System.Windows.Controls.Image) this.ImageSmall;
    imageSmall.Stretch = Stretch.Fill;
    imageSmall.Width = 16.0;
    imageSmall.Height = 16.0;
  }

  [Bindable(true)]
  [Category("Content")]
  public object ImageSmall
  {
    get => this.GetValue(PaneItem.ImageSmallProperty);
    set => this.SetValue(PaneItem.ImageSmallProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public string ImageSmallSource
  {
    get => (string) this.GetValue(PaneItem.ImageSmallSourceProperty);
    set => this.SetValue(PaneItem.ImageSmallSourceProperty, (object) value);
  }

  private static void ImageSmallSourceChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((PaneItem) d).ImageSmallSourceChanged();
  }

  private void ImageSmallSourceChanged()
  {
    this.ImageSmall = (object) this.LoadImage(this.ImageSmallSource);
  }

  private System.Windows.Controls.Image LoadImage(string imageSource)
  {
    if (imageSource == null || imageSource.Length == 0)
      return (System.Windows.Controls.Image) null;
    System.Windows.Controls.Image image;
    try
    {
      BitmapImage bitmapImage = new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute));
      image = new System.Windows.Controls.Image();
      image.Source = (System.Windows.Media.ImageSource) bitmapImage;
      image.Stretch = Stretch.None;
    }
    catch
    {
      return (System.Windows.Controls.Image) null;
    }
    return image;
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public string Title
  {
    get => (string) this.GetValue(PaneItem.TitleProperty);
    set => this.SetValue(PaneItem.TitleProperty, (object) value);
  }

  protected override void OnContentChanged(object oldContent, object newContent)
  {
    if (this.IsInitialized && this.Parent is NavigationPane)
      ((NavigationPane) this.Parent).UpdateSelectedContent();
    base.OnContentChanged(oldContent, newContent);
  }

  protected override void OnHeaderChanged(object oldHeader, object newHeader)
  {
    if (this.IsInitialized && this.Parent is NavigationPane)
      ((NavigationPane) this.Parent).UpdateSelectedHeader();
    base.OnHeaderChanged(oldHeader, newHeader);
  }

  public bool FocusContent()
  {
    if (!this.IsKeyboardFocusWithin && this.Content is UIElement)
    {
      this.UpdateLayout();
      ((UIElement) this.Content).MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
    }
    return true;
  }

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    base.OnGotKeyboardFocus(e);
    if (e.Handled || e.NewFocus != this || this.IsSelected)
      return;
    this.IsSelected = true;
  }

  [Bindable(true)]
  [Category("Content")]
  public bool SmallState
  {
    get => (bool) this.GetValue(PaneItem.SmallStateProperty);
    set => this.SetValue(PaneItem.SmallStateProperty, (object) value);
  }

  private static void SmallStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((PaneItem) d).SmallStateChanged();
  }

  private void SmallStateChanged() => this.UpdateToolTip();

  private void UpdateToolTip()
  {
    if ((this.SmallState || !this.PaneExpanded) && this.ToolTip == null && this.Header is string)
    {
      this.ToolTip = (object) this.Header.ToString();
      this._ToolTipSet = true;
    }
    else
    {
      if (!this._ToolTipSet)
        return;
      this.ToolTip = (object) null;
    }
  }

  public bool PaneExpanded
  {
    get => (bool) this.GetValue(PaneItem.PaneExpandedProperty);
    set => this.SetValue(PaneItem.PaneExpandedProperty, (object) value);
  }

  private static void PaneExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((PaneItem) d).PaneExpandedChanged();
  }

  private void PaneExpandedChanged() => this.UpdateToolTip();
}
