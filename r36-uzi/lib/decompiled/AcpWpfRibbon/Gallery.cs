// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Gallery
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_GalleryBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class Gallery : ButtonDropDown
{
  public static readonly RoutedCommand DropDownGalleryCommand;
  public static readonly DependencyProperty IsCollapsibleProperty;
  public static readonly DependencyProperty IsResizeEnabledProperty;
  public static readonly DependencyProperty SuggestedContainerWidthProperty;
  public static readonly DependencyProperty IsCollapsedProperty;
  public static readonly DependencyProperty MenuItemsProperty;
  private static readonly DependencyPropertyKey MenuItemsPropertyKey;
  public static readonly DependencyProperty MenuItemsVisibilityProperty;
  private static readonly DependencyPropertyKey MenuItemsVisibilityPropertyKey;
  public static readonly DependencyProperty CategoryProperty;
  public static readonly DependencyProperty MaxPopupHeightProperty = DependencyProperty.Register(nameof (MaxPopupHeight), typeof (double), typeof (Gallery), (PropertyMetadata) new UIPropertyMetadata((object) 400.0));
  private const string PartGalleryViewPanelName = "GalleryView";
  private const string PartItemsPanelName = "PART_ItemsPanel";
  private const string PartMenuItemsPanelName = "PART_MenuItemsPanel";
  private const string PartPopupContainerPanel = "PopupContainerPanel";
  private const string PartResizeThumbName = "GalleryPopupResizeThumb";
  private const string PartPopupScrollViewer = "PopupScrollViewer";
  private GalleryScrollViewer m_Panel;
  private Panel m_ItemsPanel;
  private Panel m_MenuItemsPanel;
  private Panel m_PopupGalleryPanel;
  private Thumb m_ResizeThumb;
  private Size m_MinPopupPanelSize;
  private Size m_StartingPopupPanelSize;
  private ScrollViewer m_PopupScrollViewer;
  private double m_OldHeight = double.NaN;
  private bool _ImmediateLivePreview;

  public double MaxPopupHeight
  {
    get => (double) this.GetValue(Gallery.MaxPopupHeightProperty);
    set => this.SetValue(Gallery.MaxPopupHeightProperty, (object) value);
  }

  static Gallery()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Gallery)));
    FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Gallery.DropDownGalleryCommand = new RoutedCommand("DropDownGallery", typeof (GalleryScrollViewer));
    CommandManager.RegisterClassCommandBinding(typeof (Gallery), new CommandBinding((ICommand) Gallery.DropDownGalleryCommand, new ExecutedRoutedEventHandler(Gallery.OnDropDownGalleryCommand), new CanExecuteRoutedEventHandler(Gallery.OnQueryDropDownGalleryCommand)));
    Gallery.IsCollapsibleProperty = DependencyProperty.Register(nameof (IsCollapsible), typeof (bool), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Gallery.SuggestedContainerWidthProperty = DependencyProperty.Register(nameof (SuggestedContainerWidth), typeof (double), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) 200.0, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsParentMeasure));
    Gallery.IsCollapsedProperty = DependencyProperty.Register(nameof (IsCollapsed), typeof (bool), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(Gallery.OnIsCollapsedChanged)));
    Gallery.MenuItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (MenuItems), typeof (ObservableCollection<UIElement>), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    Gallery.MenuItemsProperty = Gallery.MenuItemsPropertyKey.DependencyProperty;
    Gallery.MenuItemsVisibilityPropertyKey = DependencyProperty.RegisterReadOnly(nameof (MenuItemsVisibility), typeof (Visibility), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Collapsed));
    Gallery.MenuItemsVisibilityProperty = Gallery.MenuItemsVisibilityPropertyKey.DependencyProperty;
    Gallery.CategoryProperty = DependencyProperty.RegisterAttached("Category", typeof (string), typeof (Gallery), new PropertyMetadata((object) "", new PropertyChangedCallback(Gallery.OnCategoryChanged)));
    Gallery.IsResizeEnabledProperty = DependencyProperty.Register(nameof (IsResizeEnabled), typeof (bool), typeof (Gallery), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
  }

  public Gallery()
  {
    this.SetValue(Gallery.MenuItemsPropertyKey, (object) new ObservableCollection<UIElement>());
    this.MenuItems.CollectionChanged += new NotifyCollectionChangedEventHandler(this.MenuItemsCollectionChanged);
  }

  public override void OnApplyTemplate()
  {
    if (this.m_MenuItemsPanel != null)
      this.m_MenuItemsPanel.Children.Clear();
    if (this.m_ResizeThumb != null)
    {
      this.m_ResizeThumb.DragDelta -= new DragDeltaEventHandler(this.ResizeThumbDragDelta);
      this.m_ResizeThumb.DragStarted -= new DragStartedEventHandler(this.ResizeThumbDragStarted);
    }
    if (this.m_ItemsPanel != null)
      this.m_ItemsPanel.IsItemsHost = false;
    this.m_Panel = this.GetTemplateChild("GalleryView") as GalleryScrollViewer;
    this.m_ItemsPanel = this.GetTemplateChild("PART_ItemsPanel") as Panel;
    this.m_MenuItemsPanel = this.GetTemplateChild("PART_MenuItemsPanel") as Panel;
    this.m_PopupGalleryPanel = this.GetTemplateChild("PopupContainerPanel") as Panel;
    this.m_ResizeThumb = this.GetTemplateChild("GalleryPopupResizeThumb") as Thumb;
    this.m_PopupScrollViewer = this.GetTemplateChild("PopupScrollViewer") as ScrollViewer;
    if (this.m_ResizeThumb != null)
    {
      this.m_ResizeThumb.DragDelta += new DragDeltaEventHandler(this.ResizeThumbDragDelta);
      this.m_ResizeThumb.DragStarted += new DragStartedEventHandler(this.ResizeThumbDragStarted);
    }
    this.UpdateMenuItems();
    base.OnApplyTemplate();
  }

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    if (e.NewFocus == this && !this.IsCollapsed)
      FocusHelpers.FocusFirstChild((ItemsControl) this);
    base.OnGotKeyboardFocus(e);
  }

  private void ResizeThumbDragStarted(object sender, DragStartedEventArgs e)
  {
    if (this.m_PopupGalleryPanel == null)
      return;
    this.m_StartingPopupPanelSize = new Size(Math.Ceiling(this.m_PopupScrollViewer.RenderSize.Width), Math.Ceiling(this.m_PopupScrollViewer.RenderSize.Height));
  }

  private void ResizeThumbDragDelta(object sender, DragDeltaEventArgs e)
  {
    if (this.m_PopupGalleryPanel == null)
      return;
    Panel popupGalleryPanel = this.m_PopupGalleryPanel;
    if (this.m_MinPopupPanelSize.Width == 0.0)
      this.m_MinPopupPanelSize.Width = this.m_PopupScrollViewer.ActualWidth;
    double num1 = Math.Ceiling(Math.Max(this.m_MinPopupPanelSize.Width, this.m_StartingPopupPanelSize.Width + e.HorizontalChange));
    double num2 = Math.Ceiling(Math.Max(this.m_MinPopupPanelSize.Height, this.m_PopupScrollViewer.ActualHeight + e.VerticalChange));
    if (this.m_PopupScrollViewer.Width == num1 && this.m_PopupScrollViewer.Height == num2)
      return;
    foreach (UIElement child in this.m_PopupGalleryPanel.Children)
    {
      if (child is GalleryWrapPanel galleryWrapPanel)
        galleryWrapPanel.Width = double.NaN;
    }
    this.m_PopupScrollViewer.Width = num1;
    this.m_PopupScrollViewer.Height = num2;
    this.Popup.UpdateLayout();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public ObservableCollection<UIElement> MenuItems
  {
    get => (ObservableCollection<UIElement>) this.GetValue(Gallery.MenuItemsProperty);
  }

  private void MenuItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    this.UpdateMenuItems();
  }

  private void UpdateMenuItems()
  {
    this.MenuItemsVisibility = this.MenuItems.Count != 0 ? Visibility.Visible : Visibility.Collapsed;
    if (this.m_MenuItemsPanel == null)
      return;
    this.m_MenuItemsPanel.Children.Clear();
    foreach (UIElement menuItem in (Collection<UIElement>) this.MenuItems)
      this.m_MenuItemsPanel.Children.Add(menuItem);
    this.m_MenuItemsPanel.InvalidateMeasure();
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool IsCollapsible
  {
    get => (bool) this.GetValue(Gallery.IsCollapsibleProperty);
    set => this.SetValue(Gallery.IsCollapsibleProperty, (object) value);
  }

  [Browsable(true)]
  [DefaultValue(true)]
  public bool IsResizeEnabled
  {
    get => (bool) this.GetValue(Gallery.IsResizeEnabledProperty);
    set => this.SetValue(Gallery.IsResizeEnabledProperty, (object) value);
  }

  public bool IsCollapsed
  {
    get => (bool) this.GetValue(Gallery.IsCollapsedProperty);
    set => this.SetValue(Gallery.IsCollapsedProperty, (object) value);
  }

  [Browsable(false)]
  public Visibility MenuItemsVisibility
  {
    get => (Visibility) this.GetValue(Gallery.MenuItemsVisibilityProperty);
    internal set => this.SetValue(Gallery.MenuItemsVisibilityPropertyKey, (object) value);
  }

  [Browsable(true)]
  [DefaultValue(200.0)]
  public double SuggestedContainerWidth
  {
    get => (double) this.GetValue(Gallery.SuggestedContainerWidthProperty);
    set => this.SetValue(Gallery.SuggestedContainerWidthProperty, (object) value);
  }

  private static void OnQueryDropDownGalleryCommand(object target, CanExecuteRoutedEventArgs args)
  {
    bool flag = false;
    Gallery gallery = (Gallery) target;
    if (gallery.Popup != null)
      flag = true;
    if (gallery.Items.Count == 0)
      flag = false;
    args.CanExecute = flag;
  }

  protected override void HandleMouseDown(MouseButtonEventArgs e)
  {
    if (!this.IsCollapsed)
      return;
    base.HandleMouseDown(e);
  }

  private static void OnDropDownGalleryCommand(object target, ExecutedRoutedEventArgs args)
  {
    if (args.Command != Gallery.DropDownGalleryCommand)
      return;
    ((ButtonDropDown) target).IsPopupOpen = true;
    args.Handled = true;
  }

  internal Panel InternalItemsPanel => this.m_ItemsPanel;

  protected override void OnPopupOpened(RoutedEventArgs e)
  {
    this.m_MinPopupPanelSize = new Size();
    this.m_StartingPopupPanelSize = new Size();
    if (this.m_ItemsPanel != null)
    {
      this.m_ItemsPanel.Width = this.m_ItemsPanel.ActualWidth;
      this.m_ItemsPanel.IsItemsHost = false;
    }
    if (this.m_PopupGalleryPanel != null)
      this.GeneratePopupGalleryItems(this.m_PopupGalleryPanel);
    if (this.m_ResizeThumb != null)
    {
      if (this.FlowDirection == FlowDirection.LeftToRight)
        this.m_ResizeThumb.Cursor = Cursors.SizeNWSE;
      else
        this.m_ResizeThumb.Cursor = Cursors.SizeNESW;
    }
    if (this.m_PopupScrollViewer != null)
      this.m_PopupScrollViewer.SizeChanged += new SizeChangedEventHandler(this.PopupScrollViewerSizeChanged);
    if (this.Popup != null && !this.IsCollapsed)
      this.Popup.VerticalOffset = -this.ActualHeight;
    base.OnPopupOpened(e);
  }

  private void PopupScrollViewerSizeChanged(object sender, SizeChangedEventArgs e)
  {
    this.m_PopupScrollViewer.SizeChanged -= new SizeChangedEventHandler(this.PopupScrollViewerSizeChanged);
    if (this.m_PopupScrollViewer.ActualHeight <= this.MaxPopupHeight)
      return;
    this.m_PopupScrollViewer.Height = this.MaxPopupHeight;
  }

  private void GeneratePopupGalleryItems(Panel p)
  {
    GalleryWrapPanel element1 = new GalleryWrapPanel();
    string str = "";
    bool flag = false;
    IEnumerable enumerable = (IEnumerable) this.Items;
    if (this.ItemsSource != null || this.ItemTemplate != null)
    {
      IItemContainerGenerator containerGenerator = (IItemContainerGenerator) this.ItemContainerGenerator;
      if (containerGenerator != null)
      {
        ArrayList arrayList = new ArrayList(this.Items.Count);
        containerGenerator.RemoveAll();
        using (containerGenerator.StartAt(new GeneratorPosition(-1, 0), GeneratorDirection.Forward))
        {
          while (containerGenerator.GenerateNext() is UIElement next)
          {
            arrayList.Add((object) next);
            containerGenerator.PrepareItemContainer((DependencyObject) next);
          }
        }
        enumerable = (IEnumerable) arrayList;
      }
    }
    foreach (object obj in enumerable)
    {
      if (obj is UIElement uiElement)
      {
        Size renderSize = uiElement.RenderSize;
        if (renderSize.Height > this.m_MinPopupPanelSize.Height)
        {
          ref Size local = ref this.m_MinPopupPanelSize;
          renderSize = uiElement.RenderSize;
          double num = renderSize.Height + 12.0;
          local.Height = num;
        }
        string category = Gallery.GetCategory(uiElement);
        if (uiElement is ContentPresenter)
        {
          ((FrameworkElement) uiElement).ApplyTemplate();
          UIElement child = VisualTreeHelper.GetChildrenCount((DependencyObject) uiElement) > 0 ? VisualTreeHelper.GetChild((DependencyObject) uiElement, 0) as UIElement : (UIElement) null;
          if (child is ButtonDropDown)
            category = Gallery.GetCategory(child);
        }
        if (category != null && category != str)
        {
          flag = true;
          if (element1.Children.Count > 0)
          {
            p.Children.Add((UIElement) element1);
            element1 = new GalleryWrapPanel();
          }
          Label categoryLabel = this.CreateCategoryLabel(category);
          p.Children.Add((UIElement) categoryLabel);
          p.Children.Add((UIElement) this.CreateSeparator());
          str = category;
        }
        element1.Children.Add(uiElement);
      }
    }
    if (element1.Parent == null)
      p.Children.Add((UIElement) element1);
    if (flag)
      return;
    Separator element2 = new Separator();
    element2.Visibility = Visibility.Collapsed;
    p.Children.Add((UIElement) element2);
  }

  protected virtual Label CreateCategoryLabel(string cat)
  {
    Label categoryLabel = new Label();
    if (cat == "" || cat == null)
      cat = "No Category";
    categoryLabel.Content = (object) cat;
    categoryLabel.SetResourceReference(Control.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.GalleryCategoryBackground));
    categoryLabel.SetResourceReference(Control.ForegroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.GalleryCategoryForeground));
    categoryLabel.FontWeight = FontWeights.Bold;
    categoryLabel.Margin = new Thickness();
    categoryLabel.Padding = new Thickness(6.0, 1.0, 1.0, 1.0);
    return categoryLabel;
  }

  protected virtual Separator CreateSeparator()
  {
    Separator separator = new Separator();
    separator.Padding = new Thickness();
    separator.Margin = new Thickness();
    return separator;
  }

  protected override void OnPopupClosed(RoutedEventArgs e)
  {
    if (this.m_PopupGalleryPanel != null)
    {
      foreach (UIElement child1 in this.m_PopupGalleryPanel.Children)
      {
        if (child1 is WrapPanel)
        {
          WrapPanel wrapPanel = child1 as WrapPanel;
          UIElement child2 = wrapPanel.Children[0];
          wrapPanel.Children.Clear();
        }
      }
      this.m_PopupGalleryPanel.Children.Clear();
      this.m_PopupScrollViewer.Width = double.NaN;
      this.m_PopupScrollViewer.Height = double.NaN;
    }
    base.OnPopupClosed(e);
    if (this.m_ItemsPanel == null)
      return;
    this.m_ItemsPanel.Width = double.NaN;
    this.m_ItemsPanel.IsItemsHost = true;
    int count = this.m_ItemsPanel.Children.Count;
  }

  internal double GetMinContainerWidth()
  {
    if (this.Items.Count > 0)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is UIElement uiElement && uiElement.Visibility == Visibility.Visible)
          return uiElement.DesiredSize.Width * 2.0;
      }
    }
    return 36.0;
  }

  internal double PanelWidth => this.m_Panel != null ? this.m_Panel.DesiredSize.Width : 0.0;

  [AttachedPropertyBrowsableForChildren]
  public static string GetCategory(UIElement element)
  {
    return element != null ? (string) element.GetValue(Gallery.CategoryProperty) : throw new ArgumentNullException("elem");
  }

  public static void SetCategory(UIElement element, string category)
  {
    if (element == null)
      throw new ArgumentNullException("elem");
    element.SetValue(Gallery.CategoryProperty, (object) category);
  }

  private static void OnIsCollapsedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    if (!(d is Gallery gallery))
      return;
    gallery.OnIsCollapsedChanged();
  }

  private void OnIsCollapsedChanged()
  {
    if (this.IsCollapsed)
    {
      this.m_OldHeight = this.Height;
      this.Height = double.NaN;
    }
    else
    {
      if (this.m_OldHeight == this.Height)
        return;
      this.Height = this.m_OldHeight;
    }
  }

  private static void OnCategoryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
  }

  internal bool ImmediateLivePreview
  {
    get => this._ImmediateLivePreview;
    set => this._ImmediateLivePreview = value;
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    this._ImmediateLivePreview = false;
    base.OnMouseLeave(e);
  }
}
