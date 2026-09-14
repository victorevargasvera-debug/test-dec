// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ApplicationMenu
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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ApplicationMenu : ButtonDropDown
{
  private const string ApplicationButtonResourceName = "RibbonStartButton";
  public static readonly DependencyProperty ColorProperty = DependencyProperty.Register(nameof (Color), typeof (eApplicationMenuColor), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) eApplicationMenuColor.Blue, new PropertyChangedCallback(ApplicationMenu.OnColorChanged)));
  public static readonly DependencyProperty BackstageUsesPopupProperty = DependencyProperty.Register(nameof (BackstageUsesPopup), typeof (bool), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) false, new PropertyChangedCallback(ApplicationMenu.OnBackstageUsesPopupChanged)));
  public static readonly DependencyProperty BackstageTabProperty = DependencyProperty.Register(nameof (BackstageTab), typeof (UIElement), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(ApplicationMenu.OnBackstageTabChanged), new CoerceValueCallback(ApplicationMenu.OnCoerceBackstageTab)));
  public static readonly DependencyProperty BackstageEnabledProperty = DependencyProperty.Register(nameof (BackstageEnabled), typeof (bool), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) true, new PropertyChangedCallback(ApplicationMenu.OnBackstageEnabledChanged), new CoerceValueCallback(ApplicationMenu.OnCoerceBackstageEnabled)));
  private static readonly DependencyPropertyKey IsBackstageActivePropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsBackstageActive), typeof (bool), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) false, new PropertyChangedCallback(ApplicationMenu.OnIsBackstageActiveChanged), new CoerceValueCallback(ApplicationMenu.OnCoerceIsBackstageActive)));
  public static readonly DependencyProperty IsBackstageActiveProperty = ApplicationMenu.IsBackstageActivePropertyKey.DependencyProperty;
  public static readonly DependencyProperty VisualStyleProperty = Ribbon.VisualStyleProperty.AddOwner(typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((object) eRibbonVisualStyle.Office2007Blue, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(ApplicationMenu.OnVisualStyleChanged)));
  private static readonly DependencyPropertyKey EffectiveStylePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveStyle), typeof (eEffectiveStyle), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) eEffectiveStyle.Office2007, new PropertyChangedCallback(ApplicationMenu.OnEffectiveStyleChanged)));
  public static readonly DependencyProperty EffectiveStyleProperty = ApplicationMenu.EffectiveStylePropertyKey.DependencyProperty;
  public static readonly DependencyProperty MruItemsProperty = DependencyProperty.Register(nameof (MruItems), typeof (ObservableCollection<object>), typeof (ApplicationMenu), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(ApplicationMenu.OnMruItemsChanged)));
  private static readonly DependencyPropertyKey AppItemsPropertyKey;
  public static readonly DependencyProperty AppItemsProperty;
  private static readonly DependencyPropertyKey HasMruItemsPropertyKey;
  public static readonly DependencyProperty HasMruItemsProperty;
  private static readonly DependencyPropertyKey HasAppItemsPropertyKey;
  public static readonly DependencyProperty HasAppItemsProperty;
  public static readonly DependencyProperty MruItemTemplateProperty;
  public static readonly DependencyProperty AppItemTemplateProperty;
  public static readonly DependencyProperty MruItemTemplateSelectorProperty;
  public static readonly DependencyProperty AppItemTemplateSelectorProperty;
  public static readonly DependencyProperty DoubleClickCloseProperty;
  private Border _OutterBorder;
  private Border _InnerBorder;
  private ApplicationMenu.OverlayAdorner _OverlayAdorner;
  private BackstageContentAdorner _BackstageAdorner;
  private IInputElement _PreviousFocusedElement;

  private static void OnColorChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnColorChanged((eApplicationMenuColor) e.OldValue, (eApplicationMenuColor) e.NewValue);
  }

  protected virtual void OnColorChanged(
    eApplicationMenuColor oldValue,
    eApplicationMenuColor newValue)
  {
    this.UpdateColors();
  }

  private void UpdateColors()
  {
    if (this._InnerBorder == null && this._OutterBorder == null || this.EffectiveStyle != eEffectiveStyle.Office2010)
      return;
    string str1 = "";
    if (this.IsPopupOpen)
      str1 = "Expanded";
    else if (this.IsKeyboardFocused || this.IsMouseOver)
      str1 = "Hover";
    string str2 = "";
    if (this.Color != eApplicationMenuColor.Blue)
      str2 = Enum.GetName(typeof (eApplicationMenuColor), (object) this.Color);
    if (this._OutterBorder != null)
    {
      this._OutterBorder.SetResourceReference(Border.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) $"RibbonStartButton{str2}{str1}OutterBorderFill"));
      this._OutterBorder.SetResourceReference(Border.BorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) $"RibbonStartButton{str2}{str1}OutterBorder"));
    }
    if (this._InnerBorder == null)
      return;
    this._InnerBorder.SetResourceReference(Border.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) $"RibbonStartButton{str2}{str1}BottomHighlight"));
    this._InnerBorder.SetResourceReference(Border.BorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) $"RibbonStartButton{str2}{str1}InnerBorder"));
  }

  public eApplicationMenuColor Color
  {
    get => (eApplicationMenuColor) this.GetValue(ApplicationMenu.ColorProperty);
    set => this.SetValue(ApplicationMenu.ColorProperty, (object) value);
  }

  private static void OnBackstageUsesPopupChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnBackstageUsesPopupChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual void OnBackstageUsesPopupChanged(bool oldValue, bool newValue)
  {
  }

  public bool BackstageUsesPopup
  {
    get => (bool) this.GetValue(ApplicationMenu.BackstageUsesPopupProperty);
    set => this.SetValue(ApplicationMenu.BackstageUsesPopupProperty, (object) value);
  }

  private static object OnCoerceBackstageTab(DependencyObject o, object value)
  {
    return o is ApplicationMenu applicationMenu ? (object) applicationMenu.OnCoerceBackstageTab((UIElement) value) : value;
  }

  private static void OnBackstageTabChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnBackstageTabChanged((UIElement) e.OldValue, (UIElement) e.NewValue);
  }

  protected virtual UIElement OnCoerceBackstageTab(UIElement value) => value;

  protected virtual void OnBackstageTabChanged(UIElement oldValue, UIElement newValue)
  {
    this.CoerceValue(ApplicationMenu.IsBackstageActiveProperty);
    if (oldValue is Backstage && ((Backstage) oldValue).ApplicationMenu == this)
      ((Backstage) oldValue).ApplicationMenu = (ApplicationMenu) null;
    if (!(newValue is Backstage))
      return;
    ((Backstage) newValue).ApplicationMenu = this;
  }

  public UIElement BackstageTab
  {
    get => (UIElement) this.GetValue(ApplicationMenu.BackstageTabProperty);
    set => this.SetValue(ApplicationMenu.BackstageTabProperty, (object) value);
  }

  private static object OnCoerceBackstageEnabled(DependencyObject o, object value)
  {
    return o is ApplicationMenu applicationMenu ? (object) applicationMenu.OnCoerceBackstageEnabled((bool) value) : value;
  }

  private static void OnBackstageEnabledChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnBackstageEnabledChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual bool OnCoerceBackstageEnabled(bool value) => value;

  protected virtual void OnBackstageEnabledChanged(bool oldValue, bool newValue)
  {
    this.CoerceValue(ApplicationMenu.IsBackstageActiveProperty);
  }

  public bool BackstageEnabled
  {
    get => (bool) this.GetValue(ApplicationMenu.BackstageEnabledProperty);
    set => this.SetValue(ApplicationMenu.BackstageEnabledProperty, (object) value);
  }

  public bool IsBackstageActive
  {
    get => (bool) this.GetValue(ApplicationMenu.IsBackstageActiveProperty);
    internal set => this.SetValue(ApplicationMenu.IsBackstageActivePropertyKey, (object) value);
  }

  private static void OnIsBackstageActiveChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnIsBackstageActiveChanged((bool) e.OldValue, (bool) e.NewValue);
  }

  protected virtual void OnIsBackstageActiveChanged(bool oldValue, bool newValue)
  {
  }

  private static object OnCoerceIsBackstageActive(DependencyObject d, object baseValue)
  {
    return d is ApplicationMenu applicationMenu ? applicationMenu.CoerceIsBackstageActive((bool) baseValue) : baseValue;
  }

  private object CoerceIsBackstageActive(bool value)
  {
    return this.BackstageTab != null && this.BackstageEnabled ? (object) true : (object) false;
  }

  public eRibbonVisualStyle VisualStyle
  {
    get => (eRibbonVisualStyle) this.GetValue(ApplicationMenu.VisualStyleProperty);
    set => this.SetValue(ApplicationMenu.VisualStyleProperty, (object) value);
  }

  private static void OnVisualStyleChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    ((ApplicationMenu) o).OnVisualStyleChanged((eRibbonVisualStyle) e.OldValue, (eRibbonVisualStyle) e.NewValue);
  }

  private void OnVisualStyleChanged(eRibbonVisualStyle oldValue, eRibbonVisualStyle newValue)
  {
    if (newValue == eRibbonVisualStyle.Office2010Silver || newValue == eRibbonVisualStyle.Office2010Blue || newValue == eRibbonVisualStyle.Office2010Black)
      this.EffectiveStyle = eEffectiveStyle.Office2010;
    else
      this.EffectiveStyle = eEffectiveStyle.Office2007;
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);

  public eEffectiveStyle EffectiveStyle
  {
    get => (eEffectiveStyle) this.GetValue(ApplicationMenu.EffectiveStyleProperty);
    internal set => this.SetValue(ApplicationMenu.EffectiveStylePropertyKey, (object) value);
  }

  private static void OnEffectiveStyleChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnEffectiveStyleChanged((eEffectiveStyle) e.OldValue, (eEffectiveStyle) e.NewValue);
  }

  protected virtual void OnEffectiveStyleChanged(eEffectiveStyle oldValue, eEffectiveStyle newValue)
  {
    this.UpdateColors();
  }

  private static void OnMruItemsChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ApplicationMenu applicationMenu))
      return;
    applicationMenu.OnMruItemsChanged((ObservableCollection<object>) e.OldValue, (ObservableCollection<object>) e.NewValue);
  }

  protected virtual void OnMruItemsChanged(
    ObservableCollection<object> oldValue,
    ObservableCollection<object> newValue)
  {
    if (oldValue != null)
      oldValue.CollectionChanged -= new NotifyCollectionChangedEventHandler(this.MruItemsCollectionChanged);
    if (newValue == null)
    {
      this.ClearValue(ApplicationMenu.HasMruItemsPropertyKey);
    }
    else
    {
      newValue.CollectionChanged += new NotifyCollectionChangedEventHandler(this.MruItemsCollectionChanged);
      this.HasMruItems = newValue.Count > 0;
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  [Bindable(true)]
  public ObservableCollection<object> MruItems
  {
    get => (ObservableCollection<object>) this.GetValue(ApplicationMenu.MruItemsProperty);
    set => this.SetValue(ApplicationMenu.MruItemsProperty, (object) value);
  }

  static ApplicationMenu()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ApplicationMenu)));
    FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ApplicationMenu.HasMruItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasMruItems), typeof (bool), typeof (ApplicationMenu), new PropertyMetadata((object) false));
    ApplicationMenu.HasMruItemsProperty = ApplicationMenu.HasMruItemsPropertyKey.DependencyProperty;
    ApplicationMenu.AppItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (AppItems), typeof (ObservableCollection<object>), typeof (ApplicationMenu), new PropertyMetadata((object) new ObservableCollection<object>()));
    ApplicationMenu.AppItemsProperty = ApplicationMenu.AppItemsPropertyKey.DependencyProperty;
    ApplicationMenu.HasAppItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasAppItems), typeof (bool), typeof (ApplicationMenu), new PropertyMetadata((object) false));
    ApplicationMenu.HasAppItemsProperty = ApplicationMenu.HasAppItemsPropertyKey.DependencyProperty;
    ApplicationMenu.MruItemTemplateProperty = DependencyProperty.Register(nameof (MruItemTemplate), typeof (DataTemplate), typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ApplicationMenu.MruItemTemplateSelectorProperty = DependencyProperty.Register(nameof (MruItemTemplateSelector), typeof (DataTemplateSelector), typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ApplicationMenu.AppItemTemplateProperty = DependencyProperty.Register(nameof (AppItemTemplate), typeof (DataTemplate), typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ApplicationMenu.AppItemTemplateSelectorProperty = DependencyProperty.Register(nameof (AppItemTemplateSelector), typeof (DataTemplateSelector), typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ApplicationMenu.DoubleClickCloseProperty = DependencyProperty.Register(nameof (DoubleClickClose), typeof (bool), typeof (ApplicationMenu), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
  }

  public ApplicationMenu()
  {
    ObservableCollection<object> observableCollection1 = new ObservableCollection<object>();
    this.SetValue(ApplicationMenu.MruItemsProperty, (object) observableCollection1);
    ObservableCollection<object> observableCollection2 = new ObservableCollection<object>();
    observableCollection2.CollectionChanged += new NotifyCollectionChangedEventHandler(this.AppItemsCollectionChanged);
    this.SetValue(ApplicationMenu.AppItemsPropertyKey, (object) observableCollection2);
  }

  public override void OnApplyTemplate()
  {
    this._OutterBorder = this.GetTemplateChild("OB") as Border;
    this._InnerBorder = this.GetTemplateChild("IB") as Border;
    base.OnApplyTemplate();
    this.UpdateColors();
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  public ObservableCollection<object> AppItems
  {
    get => (ObservableCollection<object>) this.GetValue(ApplicationMenu.AppItemsProperty);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
  [Browsable(false)]
  public bool HasAppItems => (bool) this.GetValue(ApplicationMenu.HasAppItemsProperty);

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Browsable(false)]
  public bool HasMruItems
  {
    get => (bool) this.GetValue(ApplicationMenu.HasMruItemsProperty);
    private set => this.SetValue(ApplicationMenu.HasMruItemsPropertyKey, (object) value);
  }

  private void AppItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
    {
      if (this.AppItems.Count == 0 && this.HasAppItems)
        this.SetValue(ApplicationMenu.HasAppItemsPropertyKey, (object) false);
      else if (this.AppItems.Count > 0 && !this.HasAppItems)
        this.SetValue(ApplicationMenu.HasAppItemsPropertyKey, (object) true);
    }
    if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      this.SetRole((IList) this.AppItems, eElementRole.AppMenuApplicationCommand);
      foreach (object appItem in (Collection<object>) this.AppItems)
        this.AddLogicalChild(appItem);
    }
    else
    {
      if (e.OldItems != null)
      {
        this.SetRole(e.OldItems, eElementRole.Default);
        foreach (object oldItem in (IEnumerable) e.OldItems)
          this.RemoveLogicalChild(oldItem);
      }
      if (e.NewItems == null)
        return;
      this.SetRole(e.NewItems, eElementRole.AppMenuApplicationCommand);
      foreach (object newItem in (IEnumerable) e.NewItems)
        this.AddLogicalChild(newItem);
    }
  }

  private void MruItemsCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Add || e.Action == NotifyCollectionChangedAction.Remove || e.Action == NotifyCollectionChangedAction.Reset)
    {
      if (this.MruItems != null && this.MruItems.Count == 0 && this.HasMruItems)
        this.SetValue(ApplicationMenu.HasMruItemsPropertyKey, (object) false);
      else if (this.MruItems != null && this.MruItems.Count > 0 && !this.HasMruItems)
        this.SetValue(ApplicationMenu.HasMruItemsPropertyKey, (object) true);
    }
    if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      this.SetRole((IList) this.MruItems, eElementRole.AppMenuMruItem);
      foreach (object mruItem in (Collection<object>) this.MruItems)
        this.AddLogicalChild(mruItem);
    }
    else
    {
      if (e.OldItems != null)
      {
        this.SetRole(e.OldItems, eElementRole.Default);
        foreach (object oldItem in (IEnumerable) e.OldItems)
          this.RemoveLogicalChild(oldItem);
      }
      if (e.NewItems == null)
        return;
      this.SetRole(e.NewItems, eElementRole.AppMenuMruItem);
      foreach (object newItem in (IEnumerable) e.NewItems)
        this.AddLogicalChild(newItem);
    }
  }

  private void SetRole(IList col, eElementRole role)
  {
    foreach (object obj in (IEnumerable) col)
    {
      if (obj is FrameworkElement element)
        Ribbon.SetElementRole(element, role);
    }
  }

  [Bindable(true)]
  public DataTemplate MruItemTemplate
  {
    get => (DataTemplate) this.GetValue(ApplicationMenu.MruItemTemplateProperty);
    set => this.SetValue(ApplicationMenu.MruItemTemplateProperty, (object) value);
  }

  [Bindable(true)]
  public DataTemplate AppItemTemplate
  {
    get => (DataTemplate) this.GetValue(ApplicationMenu.AppItemTemplateProperty);
    set => this.SetValue(ApplicationMenu.AppItemTemplateProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Bindable(true)]
  [Browsable(false)]
  public DataTemplateSelector MruItemTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(ApplicationMenu.MruItemTemplateSelectorProperty);
    set => this.SetValue(ApplicationMenu.MruItemTemplateSelectorProperty, (object) value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  [Bindable(true)]
  [Browsable(false)]
  public DataTemplateSelector AppItemTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(ApplicationMenu.AppItemTemplateSelectorProperty);
    set => this.SetValue(ApplicationMenu.AppItemTemplateSelectorProperty, (object) value);
  }

  protected override void OnPopupOpened(RoutedEventArgs e)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Loaded, (Delegate) new DispatcherOperationCallback(this.ShowCuesAfterRender), (object) null);
    base.OnPopupOpened(e);
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    if (this.IsPopupOpen && this._OverlayAdorner == null && !this.IsBackstageActive && this.Parent is Ribbon parent)
    {
      AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) parent);
      if (adornerLayer != null)
      {
        this._OverlayAdorner = new ApplicationMenu.OverlayAdorner((UIElement) parent);
        adornerLayer.Add((Adorner) this._OverlayAdorner);
      }
    }
    this.UpdateColors();
    base.OnMouseLeave(e);
  }

  protected override void OnPopupClosed(RoutedEventArgs e)
  {
    if (this._OverlayAdorner != null)
    {
      (this._OverlayAdorner.Parent as AdornerLayer).Remove((Adorner) this._OverlayAdorner);
      this._OverlayAdorner = (ApplicationMenu.OverlayAdorner) null;
    }
    base.OnPopupClosed(e);
  }

  private object ShowCuesAfterRender(object arg)
  {
    Popup popup = this.Popup;
    if (popup != null && popup.IsOpen)
    {
      Ribbon.ShowKeyboardCues((DependencyObject) popup, true);
      if (this.GetTemplateChild("AppButtonPopupPart") is Rectangle templateChild && templateChild.RenderTransform is TranslateTransform)
      {
        TranslateTransform renderTransform = (TranslateTransform) templateChild.RenderTransform;
        System.Windows.Point screen1 = popup.PointToScreen(new System.Windows.Point(0.0, 0.0));
        System.Windows.Point screen2 = templateChild.PointToScreen(new System.Windows.Point(0.0, 0.0));
        if (renderTransform.X != 5.0)
          screen2.X -= renderTransform.X - 5.0;
        --screen2.X;
        if (renderTransform.X != 5.0 + screen1.X - screen2.X)
        {
          TranslateTransform translateTransform = new TranslateTransform(5.0 + screen1.X - screen2.X, -26.0);
          templateChild.RenderTransform = (Transform) translateTransform;
        }
      }
    }
    return (object) null;
  }

  protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
  {
    this.CloseOnDoubleClick(e);
    base.OnMouseDoubleClick(e);
  }

  internal void CloseOnDoubleClick(MouseButtonEventArgs e)
  {
    if (!this.DoubleClickClose || e.ChangedButton != MouseButton.Left || this.IsPopupOpen && this.IsBackstageActive || !new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)))
      return;
    Window.GetWindow((DependencyObject) this)?.Close();
  }

  [Bindable(true)]
  [DefaultValue(true)]
  [Browsable(true)]
  public bool DoubleClickClose
  {
    get => (bool) this.GetValue(ApplicationMenu.DoubleClickCloseProperty);
    set => this.SetValue(ApplicationMenu.DoubleClickCloseProperty, (object) value);
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    base.OnMouseLeftButtonDown(e);
    ButtonDropDown openButton = this.GetOpenButton();
    if (openButton == null || new Rect(openButton.Popup.RenderSize).Contains(e.GetPosition((IInputElement) openButton.Popup)))
      return;
    openButton.IsPopupOpen = false;
  }

  private ButtonDropDown GetOpenButton()
  {
    foreach (object obj in (IEnumerable) this.Items)
    {
      if (obj is ButtonDropDown openButton && openButton.IsPopupOpen)
        return openButton;
    }
    return (ButtonDropDown) null;
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      this.SetRole((IList) this.Items, eElementRole.AppMenuDocumentCommand);
    }
    else
    {
      if (e.NewItems != null)
        this.SetRole(e.NewItems, eElementRole.AppMenuDocumentCommand);
      if (e.OldItems != null)
        this.SetRole(e.OldItems, eElementRole.Default);
    }
    base.OnItemsChanged(e);
  }

  protected override void ClearChildMouseHighlight()
  {
    base.ClearChildMouseHighlight();
    if (this.AppItems != null)
      this.ClearChildMouseHighlight((IEnumerable) this.AppItems);
    if (this.MruItems == null)
      return;
    this.ClearChildMouseHighlight((IEnumerable) this.MruItems);
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    Key key = e.Key;
    UIElement highlightedChild1 = (UIElement) this.HighlightedChild;
    if ((key == Key.Down || key == Key.Tab) && highlightedChild1 != null)
    {
      if (this.IsLastVisible((IList) this.Items, highlightedChild1) && this.MruItems.Count > 0)
      {
        this.FocusFirstItem((IEnumerable) this.MruItems);
        e.Handled = true;
      }
      if (!e.Handled && this.IsLastVisible((IList) this.MruItems, highlightedChild1) && this.AppItems.Count > 0)
      {
        this.FocusFirstItem((IEnumerable) this.AppItems);
        e.Handled = true;
      }
      if (!e.Handled && this.IsLastVisible((IList) this.AppItems, highlightedChild1) && this.Items.Count > 0)
      {
        this.FocusFirstItem((IEnumerable) this.Items);
        e.Handled = true;
      }
    }
    base.OnKeyDown(e);
    if (e.Handled)
      return;
    bool flag = false;
    if (this.FlowDirection == FlowDirection.RightToLeft)
    {
      switch (key)
      {
        case Key.Left:
          key = Key.Right;
          break;
        case Key.Right:
          key = Key.Left;
          break;
      }
    }
    if (key == Key.Left || key == Key.Right)
    {
      if (this.IsPopupOpen && this.HighlightedChild == null)
      {
        ((UIElement) this.Items[0]).Focus();
        flag = true;
      }
      if (!flag && this.HighlightedChild != null)
      {
        ButtonDropDown highlightedChild2 = this.HighlightedChild;
        if (this.Items.Contains((object) highlightedChild2))
        {
          if (this.MruItems.Count > 0)
          {
            this.FocusFirstItem((IEnumerable) this.MruItems);
            flag = true;
          }
        }
        else if (this.MruItems.Contains((object) highlightedChild2) && this.Items.Count > 0)
        {
          this.FocusFirstItem((IEnumerable) this.Items);
          flag = true;
        }
      }
    }
    if (!flag)
      return;
    e.Handled = true;
  }

  private void FocusFirstItem(IEnumerable en)
  {
    foreach (object obj in en)
    {
      if (obj is ButtonDropDown buttonDropDown && buttonDropDown.Visibility == Visibility.Visible)
      {
        buttonDropDown.Focus();
        break;
      }
    }
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      IEnumerator logicalChildren = base.LogicalChildren;
      ArrayList arrayList = new ArrayList();
      logicalChildren.Reset();
      while (logicalChildren.MoveNext())
        arrayList.Add(logicalChildren.Current);
      if (this.AppItems != null)
        arrayList.AddRange((ICollection) this.AppItems);
      if (this.MruItems != null)
        arrayList.AddRange((ICollection) this.MruItems);
      return arrayList.GetEnumerator();
    }
  }

  protected override void HandleMouseDown(MouseButtonEventArgs e)
  {
    if (this.IsBackstageActive)
    {
      Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
      if (this.IsEnabled && rect.Contains(e.GetPosition((IInputElement) this)) && (e.ChangedButton == MouseButton.Left || e.ChangedButton == MouseButton.Right) && this.HasVisibleItems)
      {
        e.Handled = true;
        this.ClickHeader();
        return;
      }
    }
    base.HandleMouseDown(e);
  }

  public override void ClickHeader()
  {
    if (this.IsBackstageActive)
      this.IsPopupOpen = !this.IsPopupOpen;
    else
      base.ClickHeader();
  }

  protected override void OnIsPopupOpenChanged(bool oldValue, bool newValue)
  {
    this.UpdateColors();
    if (this.IsBackstageActive && !this.BackstageUsesPopup)
    {
      if (newValue)
      {
        AdornerLayer backstageAdornerLayer = this.GetBackstageAdornerLayer();
        this._BackstageAdorner = new BackstageContentAdorner(this);
        BackstageContentAdorner backstageAdorner = this._BackstageAdorner;
        backstageAdornerLayer.Add((Adorner) backstageAdorner);
        CommandManager.InvalidateRequerySuggested();
        this.IsSelected = true;
        this.OnPopupOpened(new RoutedEventArgs(ButtonDropDown.PopupOpenedEvent, (object) this));
        this.UpdateKeyTipsState();
        this._PreviousFocusedElement = Keyboard.FocusedElement;
        if (this._PreviousFocusedElement == null)
        {
          Window window = Window.GetWindow((DependencyObject) this);
          if (window != null)
            this._PreviousFocusedElement = FocusManager.GetFocusedElement((DependencyObject) window);
        }
        this._BackstageAdorner.Focus();
      }
      else
      {
        if (this._BackstageAdorner == null)
          return;
        if (this._BackstageAdorner.Parent is AdornerLayer parent)
          parent.Remove((Adorner) this._BackstageAdorner);
        this._BackstageAdorner.RemoveBackstageContent();
        CommandManager.InvalidateRequerySuggested();
        this.OnPopupClosed(new RoutedEventArgs(ButtonDropDown.PopupClosedEvent, (object) this));
        this.UpdateKeyTipsState();
        if (this._PreviousFocusedElement != null)
        {
          Keyboard.Focus(this._PreviousFocusedElement);
          this._PreviousFocusedElement = (IInputElement) null;
        }
        else
        {
          UIElement element = (UIElement) null;
          Window window = Window.GetWindow((DependencyObject) this);
          if (window != null)
            element = window.PredictFocus(FocusNavigationDirection.Down) as UIElement;
          if (element == null)
          {
            Ribbon ribbon = this.GetRibbon();
            if (ribbon != null)
              element = ribbon.PredictFocus(FocusNavigationDirection.Down) as UIElement;
          }
          if (element == null)
            element = (UIElement) this.GetRibbon();
          if (element == null)
            return;
          Keyboard.Focus((IInputElement) element);
        }
      }
    }
    else
    {
      if (this.IsBackstageActive)
      {
        if (newValue)
        {
          AdornerLayer backstageAdornerLayer = this.GetBackstageAdornerLayer();
          this.Popup.Width = backstageAdornerLayer.RenderSize.Width - 1.0;
          Ribbon ribbon = this.GetRibbon();
          if (ribbon != null)
            this.Popup.Height = backstageAdornerLayer.RenderSize.Height - ribbon.GetTitleChromeHeight() + 2.0;
          else
            this.Popup.Height = this.RenderSize.Height;
        }
        else
        {
          this.Popup.ClearValue(FrameworkElement.WidthProperty);
          this.Popup.ClearValue(FrameworkElement.HeightProperty);
        }
      }
      base.OnIsPopupOpenChanged(oldValue, newValue);
    }
  }

  internal Ribbon GetRibbon() => this.Parent as Ribbon;

  private AdornerLayer GetBackstageAdornerLayer()
  {
    AdornerLayer backstageAdornerLayer = AdornerLayer.GetAdornerLayer((Visual) this);
    Ribbon ribbon = this.GetRibbon();
    if (ribbon != null)
      backstageAdornerLayer = AdornerLayer.GetAdornerLayer((Visual) ribbon) ?? backstageAdornerLayer;
    Window window = Window.GetWindow((DependencyObject) this);
    if (window != null)
      backstageAdornerLayer = AdornerLayer.GetAdornerLayer((Visual) ribbon) ?? AdornerLayer.GetAdornerLayer((Visual) window);
    return backstageAdornerLayer;
  }

  protected override void OnShowKeyTipsChanged()
  {
    if (!this.IsBackstageActive)
      base.OnShowKeyTipsChanged();
    else if (this.ShowKeyTips)
    {
      UIElement backstageTab = this.BackstageTab;
      this.m_KeyTipsAdorner = new KeyTipsAdorner(backstageTab);
      AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) backstageTab);
      if (adornerLayer == null)
        return;
      adornerLayer.Add((Adorner) this.m_KeyTipsAdorner);
      this.m_KeyTipsAdorner.ContextObject = (object) this;
      if (!this.BackstageUsesPopup)
        return;
      backstageTab.Focus();
    }
    else
    {
      if (this.m_KeyTipsAdorner == null)
        return;
      UIElement backstageTab = this.BackstageTab;
      if (backstageTab != null)
        AdornerLayer.GetAdornerLayer((Visual) backstageTab)?.Remove((Adorner) this.m_KeyTipsAdorner);
      this.m_KeyTipsAdorner.ContextObject = (object) null;
      this.m_KeyTipsAdorner = (KeyTipsAdorner) null;
    }
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    this.UpdateColors();
    base.OnIsKeyboardFocusWithinChanged(e);
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    this.UpdateColors();
    base.OnMouseEnter(e);
  }

  private class OverlayAdorner(UIElement elem) : Adorner(elem)
  {
    protected override void OnRender(DrawingContext drawingContext)
    {
      Rect rectangle = new Rect(this.RenderSize);
      if (rectangle.Width > 0.0 && rectangle.Height > 0.0)
        drawingContext.DrawRectangle((Brush) Brushes.Transparent, (Pen) null, rectangle);
      base.OnRender(drawingContext);
    }
  }
}
