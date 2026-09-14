// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonDropDown
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Security;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_ButtonDropDownBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class ButtonDropDown : HeaderedItemsControl, ICommandSource
{
  private static readonly DependencyProperty ContentExpandsProperty;
  public static readonly DependencyProperty IsPressedProperty;
  private static readonly DependencyPropertyKey IsPressedPropertyKey;
  public static readonly DependencyProperty IsPopupOpenProperty;
  public static readonly DependencyProperty RoleProperty;
  public static readonly DependencyProperty PartVisibilityProperty;
  public static readonly DependencyProperty FocusChangeKeepsPopupOpenProperty;
  public static readonly DependencyProperty ColorClassProperty;
  public static readonly DependencyProperty IsHighlightedProperty;
  private static readonly DependencyPropertyKey IsHighlightedPropertyKey;
  public static readonly DependencyProperty IsCheckableProperty;
  public static readonly DependencyProperty IsCheckedProperty;
  public static readonly DependencyProperty ImageProperty;
  public static readonly DependencyProperty ImageSmallProperty;
  public static readonly DependencyProperty UseSmallImageProperty;
  public static readonly DependencyProperty RenderImageProperty;
  private static readonly DependencyPropertyKey RenderImagePropertyKey;
  public static readonly DependencyProperty WrapLabelProperty;
  public static readonly DependencyProperty InlineExpandProperty;
  public static readonly DependencyProperty ImagePositionProperty;
  public static readonly DependencyProperty ExpandPositionProperty;
  public static readonly DependencyProperty StaysOpenOnClickProperty;
  internal static readonly DependencyProperty IsSelectedProperty;
  public static readonly DependencyProperty PopupPlacementProperty;
  public static readonly DependencyProperty PopupPlacementTargetProperty;
  public static readonly DependencyProperty IsPopupAnimationSuspendedProperty;
  public static readonly DependencyProperty InputGestureTextProperty;
  public static readonly DependencyProperty IsExpandVisibleProperty;
  private static readonly DependencyPropertyKey IsExpandVisiblePropertyKey;
  public static readonly DependencyProperty IsSimpleHeaderProperty;
  private static readonly DependencyPropertyKey IsSimpleHeaderPropertyKey;
  public static readonly DependencyProperty ExpandVisibilityProperty;
  public static readonly DependencyProperty PopupTypeProperty;
  public static readonly RoutedEvent ClickEvent;
  public static readonly RoutedEvent PopupOpenedEvent;
  public static readonly RoutedEvent PopupClosedEvent;
  public static readonly RoutedEvent CheckedEvent;
  public static readonly RoutedEvent UncheckedEvent;
  public static readonly DependencyProperty CommandProperty;
  public static readonly DependencyProperty CommandParameterProperty;
  public static readonly DependencyProperty CommandTargetProperty;
  internal static readonly RoutedEvent PreviewClickEvent;
  public static readonly DependencyProperty CornerRadiusProperty;
  public static readonly DependencyProperty OptionGroupProperty;
  public static readonly DependencyProperty IsNestedMenuProperty;
  private const string PopupTemplateName = "PART_Popup";
  private const string ButtonBorderName = "PART_ButtonDropDownBorder";
  private const string ButtonImageName = "PART_ButtonImage";
  private const string ButtonContentName = "PART_ButtonContent";
  private const string ButtonExpandName = "PART_ButtonExpand";
  private const string MenuItemStyleKey = "ButtonDropDownMenuItem";
  private const string ButtonDropDownStyleKey = "ButtonDropDown";
  private const string PartPopupContent = "PART_PopupContent";
  private const string PartExpandInlineName = "PART_ButtonExpandInline";
  private Popup m_Popup;
  private ButtonBorder m_ButtonBorder;
  private FrameworkElement m_ButtonImage;
  private FrameworkElement m_ButtonContent;
  private FrameworkElement m_ButtonExpand;
  private FrameworkElement m_ButtonExpandInline;
  private Control m_PopupContentControl;
  private Rect m_ExpandBounds = Rect.Empty;
  private Rect m_CommandBounds = Rect.Empty;
  private System.Windows.Point m_MouseDownPosition = new System.Windows.Point(double.MaxValue, double.MaxValue);
  private DispatcherTimer m_DelayPopupOpenTimer;
  private DispatcherTimer m_DelayPopupCloseTimer;
  private DispatcherTimer m_LivePreviewOpenTimer;
  private ElementAutoSizeBag m_AutoSizeBag;
  private bool m_RenderBorder = true;
  private static Size _FixedSmallImageSize = new Size(16.0, 16.0);
  private AccessText m_AccessText;
  private bool _RaiseUndoPreview;
  private ButtonDropDown m_HighlightedChild;
  private bool m_ShowKeyTips;
  internal KeyTipsAdorner m_KeyTipsAdorner;
  public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register(nameof (ImageSource), typeof (string), typeof (ButtonDropDown), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(ButtonDropDown.OnImageSourceChanged)));
  public static readonly DependencyProperty ImageSmallSourceProperty = DependencyProperty.Register(nameof (ImageSmallSource), typeof (string), typeof (ButtonDropDown), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(ButtonDropDown.OnImageSmallSourceChanged)));
  private Size m_ImageFixedSize;
  private EventHandler m_CanExecuteEventHandler;
  private bool m_CanExecute = true;

  static ButtonDropDown()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ButtonDropDown)));
    FrameworkElement.FocusVisualStyleProperty.OverrideMetadata(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ButtonDropDown.ClickEvent = EventManager.RegisterRoutedEvent("Click", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    ButtonDropDown.PreviewClickEvent = EventManager.RegisterRoutedEvent("PreviewClick", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    ButtonDropDown.CheckedEvent = EventManager.RegisterRoutedEvent("Checked", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    ButtonDropDown.UncheckedEvent = EventManager.RegisterRoutedEvent("Unchecked", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    ButtonDropDown.PopupOpenedEvent = EventManager.RegisterRoutedEvent("PopupOpened", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    ButtonDropDown.PopupClosedEvent = EventManager.RegisterRoutedEvent("PopupClosed", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (ButtonDropDown));
    EventManager.RegisterClassHandler(typeof (ButtonDropDown), BasePopupControl.IsSelectedChangedEvent, (Delegate) new RoutedPropertyChangedEventHandler<bool>(ButtonDropDown.OnParentControlIsSelectedChanged));
    EventManager.RegisterClassHandler(typeof (ButtonDropDown), AccessKeyManager.AccessKeyPressedEvent, (Delegate) new AccessKeyPressedEventHandler(ButtonDropDown.OnAccessKeyPressed));
    ButtonDropDown.IsPopupOpenProperty = DependencyProperty.Register(nameof (IsPopupOpen), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ButtonDropDown.OnIsPopupOpenChanged), new CoerceValueCallback(ButtonDropDown.CoerceIsPopupOpen)));
    ButtonDropDown.RoleProperty = DependencyProperty.Register(nameof (Role), typeof (eButtonRole), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eButtonRole.SplitButton, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ButtonDropDown.OnRoleChanged)));
    ButtonDropDown.PartVisibilityProperty = DependencyProperty.Register(nameof (PartVisibility), typeof (eButtonPartVisibility), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eButtonPartVisibility.ImageAndHeader, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsParentArrange));
    ButtonDropDown.IsCheckableProperty = DependencyProperty.Register(nameof (IsCheckable), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.IsPressedPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsPressed), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.IsPressedProperty = ButtonDropDown.IsPressedPropertyKey.DependencyProperty;
    ButtonDropDown.PopupPlacementProperty = DependencyProperty.Register(nameof (PopupPlacement), typeof (ePopupPlacement), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) ePopupPlacement.Right, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ButtonDropDown.OnPopupPlacementChanged)));
    ButtonDropDown.PopupPlacementTargetProperty = DependencyProperty.Register(nameof (PopupPlacementTarget), typeof (UIElement), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ButtonDropDown.IsHighlightedPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsHighlighted), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(ButtonDropDown.OnIsHighlightedChanged)));
    ButtonDropDown.IsHighlightedProperty = ButtonDropDown.IsHighlightedPropertyKey.DependencyProperty;
    ButtonDropDown.IsCheckedProperty = DependencyProperty.Register(nameof (IsChecked), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal, new PropertyChangedCallback(ButtonDropDown.OnIsCheckedChanged)));
    ButtonDropDown.StaysOpenOnClickProperty = DependencyProperty.Register(nameof (StaysOpenOnClick), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.ImageProperty = DependencyProperty.Register(nameof (Image), typeof (object), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ButtonDropDown.OnImageChanged)));
    ButtonDropDown.ImageSmallProperty = DependencyProperty.Register(nameof (ImageSmall), typeof (object), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ButtonDropDown.OnImageChanged)));
    ButtonDropDown.UseSmallImageProperty = DependencyProperty.Register(nameof (UseSmallImage), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(ButtonDropDown.OnUseSmallImageChanged)));
    ButtonDropDown.RenderImagePropertyKey = DependencyProperty.RegisterReadOnly(nameof (RenderImage), typeof (object), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ButtonDropDown.RenderImageProperty = ButtonDropDown.RenderImagePropertyKey.DependencyProperty;
    ButtonDropDown.CornerRadiusProperty = DependencyProperty.Register(nameof (CornerRadius), typeof (CornerRadius), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) new CornerRadius(2.0), FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.SubPropertiesDoNotAffectRender));
    ButtonDropDown.ImagePositionProperty = DependencyProperty.Register(nameof (ImagePosition), typeof (eButtonImagePosition), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eButtonImagePosition.Left, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    ButtonDropDown.ExpandPositionProperty = DependencyProperty.Register(nameof (ExpandPosition), typeof (eExpandPosition), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eExpandPosition.Right, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ButtonDropDown.OnExpandPositionChanged)));
    ButtonDropDown.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ButtonDropDown.OnIsSelectedChanged)));
    ButtonDropDown.IsPopupAnimationSuspendedProperty = DependencyProperty.Register(nameof (IsPopupAnimationSuspended), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.ContentExpandsProperty = DependencyProperty.Register(nameof (ContentExpands), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
    ButtonDropDown.IsExpandVisiblePropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsExpandVisible), typeof (Visibility), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) Visibility.Collapsed));
    ButtonDropDown.IsExpandVisibleProperty = ButtonDropDown.IsExpandVisiblePropertyKey.DependencyProperty;
    ButtonDropDown.ExpandVisibilityProperty = DependencyProperty.Register(nameof (ExpandVisibility), typeof (eExpandVisibility), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eExpandVisibility.Auto, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(ButtonDropDown.OnExpandVisibilityChanged)));
    ButtonDropDown.CommandProperty = DependencyProperty.Register(nameof (Command), typeof (ICommand), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(ButtonDropDown.OnCommandChanged)));
    ButtonDropDown.CommandParameterProperty = DependencyProperty.Register(nameof (CommandParameter), typeof (object), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ButtonDropDown.CommandTargetProperty = DependencyProperty.Register(nameof (CommandTarget), typeof (IInputElement), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    ButtonDropDown.PopupTypeProperty = DependencyProperty.Register(nameof (PopupType), typeof (eDropDownType), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) eDropDownType.Popup, new PropertyChangedCallback(ButtonDropDown.OnPopupTypeChanged)));
    ButtonDropDown.InputGestureTextProperty = DependencyProperty.Register(nameof (InputGestureText), typeof (string), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) string.Empty, new PropertyChangedCallback(ButtonDropDown.OnInputGestureTextChanged), new CoerceValueCallback(ButtonDropDown.CoerceInputGestureText)));
    ButtonDropDown.ColorClassProperty = DependencyProperty.Register(nameof (ColorClass), typeof (string), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) RibbonColors.ButtonClass, FrameworkPropertyMetadataOptions.AffectsRender));
    ButtonDropDown.OptionGroupProperty = DependencyProperty.Register(nameof (OptionGroup), typeof (string), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    ButtonDropDown.WrapLabelProperty = DependencyProperty.Register(nameof (WrapLabel), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender));
    ButtonDropDown.InlineExpandProperty = DependencyProperty.Register(nameof (InlineExpand), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ButtonDropDown.OnInlineExpandChanged)));
    ButtonDropDown.FocusChangeKeepsPopupOpenProperty = DependencyProperty.Register(nameof (FocusChangeKeepsPopupOpen), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.IsSimpleHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsSimpleHeader), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ButtonDropDown.IsSimpleHeaderProperty = ButtonDropDown.IsSimpleHeaderPropertyKey.DependencyProperty;
    KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
    KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) KeyboardNavigationMode.Local));
    ToolTipService.IsEnabledProperty.OverrideMetadata(typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null, new CoerceValueCallback(ButtonDropDown.CoerceToolTipIsEnabled)));
    ButtonDropDown.IsNestedMenuProperty = DependencyProperty.Register(nameof (IsNestedMenu), typeof (bool), typeof (ButtonDropDown), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
  }

  public ButtonDropDown()
  {
    this.IsEnabledChanged += new DependencyPropertyChangedEventHandler(this.OnIsEnabledChanged);
  }

  [Category("Behavior")]
  public event RoutedEventHandler Click
  {
    add => this.AddHandler(ButtonDropDown.ClickEvent, (Delegate) value);
    remove => this.RemoveHandler(ButtonDropDown.ClickEvent, (Delegate) value);
  }

  [Category("Behavior")]
  public event RoutedEventHandler PopupOpened
  {
    add => this.AddHandler(ButtonDropDown.PopupOpenedEvent, (Delegate) value);
    remove => this.RemoveHandler(ButtonDropDown.PopupOpenedEvent, (Delegate) value);
  }

  [Category("Behavior")]
  public event RoutedEventHandler PopupClosed
  {
    add => this.AddHandler(ButtonDropDown.PopupClosedEvent, (Delegate) value);
    remove => this.RemoveHandler(ButtonDropDown.PopupClosedEvent, (Delegate) value);
  }

  [Category("Behavior")]
  public event RoutedEventHandler Checked
  {
    add => this.AddHandler(ButtonDropDown.CheckedEvent, (Delegate) value);
    remove => this.RemoveHandler(ButtonDropDown.CheckedEvent, (Delegate) value);
  }

  [Category("Behavior")]
  public event RoutedEventHandler Unchecked
  {
    add => this.AddHandler(ButtonDropDown.UncheckedEvent, (Delegate) value);
    remove => this.RemoveHandler(ButtonDropDown.UncheckedEvent, (Delegate) value);
  }

  private static void OnImageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonDropDown buttonDropDown = d as ButtonDropDown;
    if (d == null)
      return;
    buttonDropDown.OnImageChanged(e.OldValue, e.NewValue);
  }

  private void OnImageChanged(object oldValue, object newValue)
  {
    if (oldValue is System.Windows.Controls.Image && !LayoutHelpers.IsEmpty(this.ImageFixedSize))
    {
      System.Windows.Controls.Image image = oldValue as System.Windows.Controls.Image;
      image.MaxHeight = double.PositiveInfinity;
      image.MaxWidth = double.PositiveInfinity;
    }
    this.OnImageChanged();
  }

  private void OnImageChanged()
  {
    if (this.UseSmallImage)
    {
      if (this.ImageSmall == null)
        this.ImageFixedSize = ButtonDropDown._FixedSmallImageSize;
    }
    else if (!LayoutHelpers.IsEmpty(this.ImageFixedSize))
      this.ImageFixedSize = new Size();
    this.UpdateRenderImage();
    this.UpdateImageEnabledState();
  }

  private void UpdateRenderImage()
  {
    if ((this.UseSmallImage || this.Role == eButtonRole.MenuItem) && (this.ImageSmall != null || !string.IsNullOrEmpty(this.ImageSmallSource)))
    {
      if (!string.IsNullOrEmpty(this.ImageSmallSource))
        this.RenderImage = (object) this.CreateImageFromImageSource(this.ImageSmallSource);
      else
        this.RenderImage = this.ImageSmall;
    }
    else if (!string.IsNullOrEmpty(this.ImageSource))
      this.RenderImage = (object) this.CreateImageFromImageSource(this.ImageSource);
    else
      this.RenderImage = this.Image;
  }

  protected virtual System.Windows.Controls.Image CreateImageFromImageSource(string imageSource)
  {
    return new System.Windows.Controls.Image()
    {
      Source = (System.Windows.Media.ImageSource) new BitmapImage(new Uri(imageSource, UriKind.RelativeOrAbsolute)),
      Stretch = Stretch.None
    };
  }

  private static void OnUseSmallImageChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(d is ButtonDropDown buttonDropDown))
      return;
    buttonDropDown.OnImageChanged();
  }

  private void UpdateImageEnabledState()
  {
    if (!(this.Image is FrameworkElement))
      return;
    FrameworkElement image = this.Image as FrameworkElement;
    if (this.IsEnabled)
    {
      if (image.Opacity != 1.0)
        image.Opacity = 1.0;
    }
    else
      image.Opacity = 0.3;
    if (!(this.ImageSmall is FrameworkElement imageSmall))
      return;
    if (this.IsEnabled)
    {
      if (imageSmall.Opacity == 1.0)
        return;
      imageSmall.Opacity = 1.0;
    }
    else
      imageSmall.Opacity = 0.3;
  }

  private void OnIsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
  {
    this.UpdateEnabledState();
  }

  private void UpdateEnabledState()
  {
    this.UpdateImageEnabledState();
    this.UpdateBorderRenderState();
  }

  public override void OnApplyTemplate()
  {
    base.OnApplyTemplate();
    if (this.m_Popup != null)
    {
      this.m_Popup.Closed -= new EventHandler(this.InternalPopupClosed);
      this.m_Popup.Opened -= new EventHandler(this.Popup_Opened);
    }
    this.m_Popup = this.GetTemplateChild("PART_Popup") as Popup;
    this.m_ButtonBorder = this.GetTemplateChild("PART_ButtonDropDownBorder") as ButtonBorder;
    this.m_ButtonContent = this.GetTemplateChild("PART_ButtonContent") as FrameworkElement;
    this.m_ButtonImage = this.GetTemplateChild("PART_ButtonImage") as FrameworkElement;
    this.m_ButtonExpand = this.GetTemplateChild("PART_ButtonExpand") as FrameworkElement;
    this.m_ButtonExpandInline = this.GetTemplateChild("PART_ButtonExpandInline") as FrameworkElement;
    this.m_PopupContentControl = this.GetTemplateChild("PART_PopupContent") as Control;
    this.m_AccessText = this.GetTemplateChild("HeaderAccessText") as AccessText;
    if (this.m_Popup != null)
    {
      this.m_Popup.Closed += new EventHandler(this.InternalPopupClosed);
      this.m_Popup.Opened += new EventHandler(this.Popup_Opened);
      this.m_Popup.PlacementTarget = (UIElement) this;
    }
    if (this.m_ButtonImage != null && !LayoutHelpers.IsEmpty(this.m_ImageFixedSize))
      this.ImageFixedSize = this.m_ImageFixedSize;
    this.UpdatePopupTypeTemplate();
    this.UpdateBorderBehavior();
    this.UpdateHeaderContentVisibility();
    this.UpdateBorderRenderState();
    this.UpdateExpandVisibility();
  }

  private void Popup_Opened(object sender, EventArgs e) => this.UpdateKeyTipsState();

  protected override void OnHeaderChanged(object oldHeader, object newHeader)
  {
    base.OnHeaderChanged(oldHeader, newHeader);
    if (newHeader is string)
    {
      if (!this.IsSimpleHeader)
        this.IsSimpleHeader = true;
    }
    else if (this.IsSimpleHeader)
      this.IsSimpleHeader = false;
    this.UpdateHeaderContentVisibility();
  }

  private void UpdateHeaderContentVisibility()
  {
    Visibility visibility = Visibility.Collapsed;
    if (this.Header != null && this.PartVisibility != eButtonPartVisibility.ImageOnly)
      visibility = Visibility.Visible;
    if (this.m_ButtonContent == null || this.m_ButtonContent.Visibility == visibility)
      return;
    this.m_ButtonContent.Visibility = visibility;
  }

  protected override Size MeasureOverride(Size constraint)
  {
    if (this.m_ButtonContent is TextBlock && this.IsSimpleHeader)
    {
      string header = (string) this.Header;
      if (this.WrapLabel && this.m_ButtonContent.Visibility == Visibility.Visible && (this.ImagePosition == eButtonImagePosition.Top || this.ImagePosition == eButtonImagePosition.Bottom) && header != null && header.IndexOf(' ') > 0)
      {
        TextBlock buttonContent = this.m_ButtonContent as TextBlock;
        FormattedText formattedText = new FormattedText((string) this.Header, CultureInfo.CurrentCulture, buttonContent.FlowDirection, new Typeface(buttonContent.FontFamily, buttonContent.FontStyle, buttonContent.FontWeight, buttonContent.FontStretch), buttonContent.FontSize, buttonContent.Foreground);
        formattedText.BuildGeometry(new System.Windows.Point(0.0, 0.0));
        double num1 = Math.Ceiling(formattedText.Height) * 2.0 + 2.0;
        double num2 = Math.Ceiling(formattedText.MinWidth);
        double num3 = Math.Max(2.0, Math.Ceiling(formattedText.Width * 0.1));
        int num4 = 0;
        do
        {
          formattedText.MaxTextWidth = num2;
          if (formattedText.Height > num1)
            num2 += num3;
          ++num4;
        }
        while (formattedText.Height > num1 && num4 < 11);
        double val1 = Math.Ceiling(formattedText.Width);
        double num5 = 0.0;
        if (this.m_ImageFixedSize.Width > 0.0)
          num5 = this.m_ImageFixedSize.Width;
        else if (this.Image is System.Windows.Controls.Image)
        {
          System.Windows.Controls.Image image = (System.Windows.Controls.Image) this.Image;
          num5 = !image.IsArrangeValid ? 32.0 : image.ActualWidth;
        }
        double num6 = Math.Max(val1, num5 + 6.0);
        if (this.m_ButtonExpandInline != null && this.m_ButtonExpandInline.Visibility == Visibility.Visible)
        {
          if (this.m_ButtonExpandInline.DesiredSize.Width == 0.0)
            this.m_ButtonExpandInline.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
          num6 += this.m_ButtonExpandInline.DesiredSize.Width + 2.0;
        }
        if (num6 % 2.0 != 0.0)
          ++num6;
        buttonContent.Width = num6;
      }
      else if (!double.IsNaN(this.m_ButtonContent.Width))
        this.m_ButtonContent.Width = double.NaN;
    }
    return base.MeasureOverride(constraint);
  }

  protected override Size ArrangeOverride(Size finalSize)
  {
    Size size = base.ArrangeOverride(finalSize);
    this.m_CommandBounds = Rect.Empty;
    this.m_ExpandBounds = Rect.Empty;
    Rect empty = Rect.Empty;
    if (this.Role != eButtonRole.SplitButton || this.m_ButtonExpand == null || this.m_ButtonContent == null && this.m_ButtonImage == null || !this.HasVisibleItems && this.ExpandVisibility != eExpandVisibility.Visible)
      return size;
    Rect r1 = Rect.Empty;
    Rect layoutSlot;
    if (this.m_ButtonImage != null)
    {
      layoutSlot = LayoutInformation.GetLayoutSlot(this.m_ButtonImage);
      if (this.m_ButtonImage.Parent is FrameworkElement parent && !LayoutHelpers.IsZero(layoutSlot.Width) && !LayoutHelpers.IsZero(layoutSlot.Height))
      {
        layoutSlot.Location = parent.TranslatePoint(layoutSlot.Location, (UIElement) this.m_ButtonBorder);
        r1 = layoutSlot;
      }
    }
    Rect rect1 = Rect.Empty;
    if (this.m_ButtonContent != null)
    {
      layoutSlot = LayoutInformation.GetLayoutSlot(this.m_ButtonContent);
      if (this.m_ButtonContent.Parent is FrameworkElement parent && !LayoutHelpers.IsZero(layoutSlot.Width) && !LayoutHelpers.IsZero(layoutSlot.Height))
      {
        layoutSlot.Location = parent.TranslatePoint(layoutSlot.Location, (UIElement) this.m_ButtonBorder);
        rect1 = layoutSlot;
      }
    }
    Rect rect2 = Rect.Empty;
    layoutSlot = LayoutInformation.GetLayoutSlot(this.m_ButtonExpand);
    if (this.m_ButtonExpand.Parent is FrameworkElement parent1)
    {
      layoutSlot.Location = parent1.TranslatePoint(layoutSlot.Location, (UIElement) this.m_ButtonBorder);
      rect2 = layoutSlot;
    }
    Rect innerContent = r1;
    innerContent.Union(rect1);
    innerContent.Union(rect2);
    Size renderSize = this.m_ButtonBorder.RenderSize;
    if (this.ContentExpands && !r1.IsEmpty && !rect1.IsEmpty)
    {
      Rect r2 = rect1;
      if (this.ImagePosition == eButtonImagePosition.Top)
      {
        r2.Y += 2.0;
        r2.Height -= 2.0;
      }
      r2.Union(rect2);
      this.m_ExpandBounds = this.GetFullRectangle(r2, innerContent, renderSize);
      this.m_CommandBounds = this.GetFullRectangle(r1, innerContent, renderSize);
    }
    else
    {
      Rect r3 = r1;
      r3.Union(rect1);
      this.m_ExpandBounds = this.GetFullRectangle(rect2, innerContent, renderSize);
      this.m_CommandBounds = this.GetFullRectangle(r3, innerContent, renderSize);
    }
    if (this.m_CommandBounds.Height > 0.0)
      this.m_CommandBounds.Height += 3.0;
    this.m_ButtonBorder.ExpandBounds = this.m_ExpandBounds;
    return size;
  }

  private Rect GetFullRectangle(Rect r, Rect innerContent, Size totalSize)
  {
    if (LayoutHelpers.IsClose(innerContent.Right, r.Right))
      r.Width += totalSize.Width - innerContent.Width - (LayoutHelpers.IsClose(innerContent.X, r.X) ? 0.0 : innerContent.X);
    if (LayoutHelpers.IsClose(innerContent.Bottom, r.Bottom))
      r.Height += totalSize.Height - innerContent.Height - (LayoutHelpers.IsClose(innerContent.Y, r.Y) ? 0.0 : innerContent.Y);
    if (LayoutHelpers.IsClose(innerContent.X, r.X))
    {
      r.X -= innerContent.X;
      r.Width += innerContent.X;
    }
    if (LayoutHelpers.IsClose(innerContent.Y, r.Y))
      r.Y -= innerContent.Y;
    return r;
  }

  protected override void OnVisualParentChanged(DependencyObject oldParent)
  {
    this.PopupPlacement = !(this.GetParent() is ButtonDropDown) ? ePopupPlacement.Bottom : ePopupPlacement.Right;
    base.OnVisualParentChanged(oldParent);
  }

  private void InternalPopupClosed(object source, EventArgs e)
  {
    this.UpdateKeyTipsState();
    this.OnPopupClosed(new RoutedEventArgs(ButtonDropDown.PopupClosedEvent, (object) this));
  }

  protected virtual void OnPopupClosed(RoutedEventArgs e) => this.RaiseEvent(e);

  protected virtual void OnPopupOpened(RoutedEventArgs e) => this.RaiseEvent(e);

  protected override DependencyObject GetContainerForItemOverride()
  {
    return this.ItemsSource != null ? base.GetContainerForItemOverride() : (DependencyObject) new ButtonDropDown();
  }

  private static object CoerceToolTipIsEnabled(DependencyObject d, object value)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) d;
    if (buttonDropDown.IsPopupOpen)
      return (object) false;
    return buttonDropDown.Parent is BasePopupControl parent && parent.CurrentSelection != null ? (object) false : value;
  }

  protected override void OnMouseMove(MouseEventArgs e)
  {
    base.OnMouseMove(e);
    this.UpdateInactiveButtonPart();
  }

  private void UpdateInactiveButtonPart()
  {
    if (this.IsEnabled && !this.IsPopupOpen && this.Role == eButtonRole.SplitButton && this.m_ButtonBorder != null && this.m_ButtonContent != null && this.m_ButtonImage != null && this.IsHighlighted)
    {
      if (this.IsPopupOpen)
      {
        this.m_ButtonBorder.MouseOverInactiveRect = this.m_CommandBounds;
      }
      else
      {
        Rect rect = new Rect(this.RenderSize);
        System.Windows.Point position = Mouse.GetPosition((IInputElement) this);
        if (rect.Contains(position))
        {
          if (!this.m_ExpandBounds.Contains(position))
            this.m_ButtonBorder.MouseOverInactiveRect = this.m_ExpandBounds;
          else if (!this.m_CommandBounds.Contains(position))
            this.m_ButtonBorder.MouseOverInactiveRect = this.m_CommandBounds;
          else
            this.m_ButtonBorder.MouseOverInactiveRect = Rect.Empty;
        }
        else
          this.m_ButtonBorder.MouseOverInactiveRect = Rect.Empty;
      }
    }
    else
    {
      if (this.m_ButtonBorder == null)
        return;
      this.m_ButtonBorder.MouseOverInactiveRect = Rect.Empty;
    }
  }

  protected override void OnMouseEnter(MouseEventArgs e)
  {
    base.OnMouseEnter(e);
    this.StopTimer(ref this.m_DelayPopupCloseTimer);
    this.UpdateIsPressed();
    if (!RibbonWindow.SiziningWindowInProgress)
    {
      if (this.Parent is ButtonDropDown)
        ((ButtonDropDown) this.Parent).ClearChildMouseHighlight();
      this.SetValue(ButtonDropDown.IsHighlightedPropertyKey, (object) true);
    }
    if ((this.Role == eButtonRole.MenuItem || this.IsOnApplicationMenu) && new Rect(this.RenderSize).Contains(e.GetPosition((IInputElement) this)) && !this.IsPopupOpen)
      this.OpenOnHoverTimer();
    if (!this.IsPopupOpen && this.Parent is BasePopupControl)
      this.CoerceValue(ToolTipService.IsEnabledProperty);
    if (RibbonWindow.SiziningWindowInProgress || !this.RaiseLivePreview || !this.IsEnabled)
      return;
    this.SetupLivePreview();
  }

  protected virtual bool RaiseLivePreview => Ribbon.GetLivePreviewEnabled((FrameworkElement) this);

  private bool IsOnApplicationMenu
  {
    get
    {
      for (DependencyObject parent = this.Parent; parent != null; parent = LogicalTreeHelper.GetParent(parent))
      {
        if (parent is ApplicationMenu)
          return true;
      }
      return false;
    }
  }

  private bool ShowLivePreviewImmediately
  {
    get => !(this.Parent is Gallery) || ((Gallery) this.Parent).ImmediateLivePreview;
  }

  private void SetupLivePreview()
  {
    if (this.ShowLivePreviewImmediately)
    {
      this.InvokeLivePreview();
    }
    else
    {
      if (this.m_LivePreviewOpenTimer == null)
      {
        this.m_LivePreviewOpenTimer = new DispatcherTimer(DispatcherPriority.Normal);
        this.m_LivePreviewOpenTimer.Tick += new EventHandler(this.TimerInvokeLivePreview);
      }
      else
        this.m_LivePreviewOpenTimer.Stop();
      this.StartTimer(this.m_LivePreviewOpenTimer);
    }
  }

  private void InvokeLivePreview()
  {
    this._RaiseUndoPreview = true;
    if (this.Parent is Gallery)
      ((Gallery) this.Parent).ImmediateLivePreview = true;
    if (!Ribbon.IsLivePreviewActive && this.Parent is FrameworkElement)
    {
      Ribbon.SetIsLivePreviewActive((FrameworkElement) this, true);
      ((UIElement) this.Parent).MouseLeave += new MouseEventHandler(this.ParentMouseLeave);
    }
    this.RaiseEvent(new RoutedEventArgs(Ribbon.LivePreviewEvent, (object) this));
  }

  private void ParentMouseLeave(object sender, MouseEventArgs e)
  {
    if (!Ribbon.IsLivePreviewActive)
      return;
    ((UIElement) sender).MouseLeave -= new MouseEventHandler(this.ParentMouseLeave);
    Ribbon.SetIsLivePreviewActive((FrameworkElement) this, false);
  }

  private void TimerInvokeLivePreview(object sender, EventArgs e)
  {
    this.InvokeLivePreview();
    this.StopTimer(ref this.m_LivePreviewOpenTimer);
  }

  private void OpenOnHoverTimer()
  {
    if (this.m_DelayPopupOpenTimer == null)
    {
      this.m_DelayPopupOpenTimer = new DispatcherTimer(DispatcherPriority.Normal);
      this.m_DelayPopupOpenTimer.Tick += new EventHandler(this.OnDelayPopupOpen);
    }
    else
      this.m_DelayPopupOpenTimer.Stop();
    this.StartTimer(this.m_DelayPopupOpenTimer);
  }

  private void CloseOnHoverTimer()
  {
    if (this.m_DelayPopupCloseTimer == null)
    {
      this.m_DelayPopupCloseTimer = new DispatcherTimer(DispatcherPriority.Normal);
      this.m_DelayPopupCloseTimer.Tick += new EventHandler(this.OnDelayPopupClose);
    }
    else
      this.m_DelayPopupCloseTimer.Stop();
    this.StartTimer(this.m_DelayPopupCloseTimer);
  }

  private void OnDelayPopupOpen(object sender, EventArgs e)
  {
    if (this.HasVisibleItems)
      this.OpenPopup();
    else
      this.IsSelected = true;
    this.StopTimer(ref this.m_DelayPopupOpenTimer);
  }

  private void OnDelayPopupClose(object sender, EventArgs e)
  {
    this.IsPopupOpen = false;
    this.StopTimer(ref this.m_DelayPopupCloseTimer);
  }

  protected override void OnMouseLeave(MouseEventArgs e)
  {
    base.OnMouseLeave(e);
    this.RemoveButtonHighlight();
  }

  private void RemoveButtonHighlight()
  {
    this.StopTimer(ref this.m_LivePreviewOpenTimer);
    this.StopTimer(ref this.m_DelayPopupOpenTimer);
    if (this.Role == eButtonRole.MenuItem && this.IsHighlighted && this.IsPopupOpen)
      this.CloseOnHoverTimer();
    this.SetValue(ButtonDropDown.IsHighlightedPropertyKey, (object) false);
    this.UpdateInactiveButtonPart();
    this.UpdateIsPressed();
    this.UpdateBorderRenderState();
    if (!this._RaiseUndoPreview)
      return;
    this.RaiseEvent(new RoutedEventArgs(Ribbon.UndoLivePreviewEvent, (object) this));
    this._RaiseUndoPreview = false;
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    if (!e.Handled)
    {
      this.m_MouseDownPosition = e.GetPosition((IInputElement) this);
      this.HandleMouseDown(e);
      this.UpdateIsPressed();
    }
    base.OnMouseLeftButtonDown(e);
    this.UpdateBorderRenderState();
  }

  private void StopTimer(ref DispatcherTimer timer)
  {
    if (timer == null)
      return;
    timer.Stop();
    timer = (DispatcherTimer) null;
  }

  private void StartTimer(DispatcherTimer timer)
  {
    timer.Interval = TimeSpan.FromMilliseconds((double) SystemParameters.MenuShowDelay);
    timer.Start();
  }

  private static void OnAccessKeyPressed(object sender, AccessKeyPressedEventArgs e)
  {
    ButtonDropDown buttonDropDown = sender as ButtonDropDown;
    bool flag = false;
    if (e.Target == null)
    {
      switch (Mouse.Captured)
      {
        case null:
        case BasePopupControl _:
        case Ribbon _:
          e.Target = (UIElement) buttonDropDown;
          if (e.OriginalSource == buttonDropDown && buttonDropDown.IsPopupOpen)
          {
            flag = true;
            break;
          }
          break;
        default:
          e.Handled = true;
          break;
      }
    }
    else if (e.Scope == null)
    {
      if (e.Target != buttonDropDown && e.Target is ButtonDropDown)
      {
        flag = true;
      }
      else
      {
        for (DependencyObject current = e.Source as DependencyObject; current != null && current != buttonDropDown; current = LogicalTreeHelper.GetParent(current))
        {
          if (current is UIElement container && ItemsControl.ItemsControlFromItemContainer((DependencyObject) container) == buttonDropDown)
          {
            flag = true;
            break;
          }
        }
      }
    }
    if (!flag)
      return;
    e.Scope = (object) buttonDropDown;
    e.Handled = true;
  }

  protected override void OnAccessKey(AccessKeyEventArgs e)
  {
    base.OnAccessKey(e);
    if (e.IsMultiple)
      return;
    if (this.Role == eButtonRole.DropDown)
      this.ClickHeader();
    else
      this.InternalOnClick(true);
  }

  [SecurityCritical]
  internal void InternalOnClick(bool userInitiated)
  {
    this.StopTimer(ref this.m_LivePreviewOpenTimer);
    this._RaiseUndoPreview = false;
    Ribbon.SetIsLivePreviewActive((FrameworkElement) null, false);
    if (this.IsCheckable || this.IsInOptionGroup)
      this.IsChecked = !this.IsChecked;
    this.RaiseEvent(new RoutedEventArgs(ButtonDropDown.PreviewClickEvent, (object) this));
    if (AutomationPeer.ListenerExists(AutomationEvents.InvokePatternOnInvoked))
      UIElementAutomationPeer.CreatePeerForElement((UIElement) this)?.RaiseAutomationEvent(AutomationEvents.InvokePatternOnInvoked);
    this.Dispatcher.BeginInvoke(DispatcherPriority.Render, (Delegate) new DispatcherOperationCallback(this.InvokeClickAfterRender), (object) userInitiated);
    if (this.Parent is ButtonDropDown && ((ButtonDropDown) this.Parent).ShowKeyTips)
      ((ButtonDropDown) this.Parent).ShowKeyTips = false;
    if (!(this.Parent is Backstage))
      return;
    ApplicationMenu applicationMenu = ((Backstage) this.Parent).ApplicationMenu;
    if (applicationMenu != null && applicationMenu.ShowKeyTips)
      applicationMenu.ShowKeyTips = false;
    if (applicationMenu == null || !applicationMenu.IsPopupOpen || this.StaysOpenOnClick)
      return;
    applicationMenu.IsPopupOpen = false;
  }

  private void FocusOrSelect()
  {
    if (!this.IsKeyboardFocusWithin)
      this.Focus();
    if (!this.IsSelected)
      this.IsSelected = true;
    if (!this.IsSelected || this.IsHighlighted)
      return;
    this.SetValue(ButtonDropDown.IsHighlightedPropertyKey, (object) true);
  }

  [SecurityCritical]
  private object InvokeClickAfterRender(object arg)
  {
    int num = (bool) arg ? 1 : 0;
    this.OnClick();
    ButtonDropDown.ExecuteCommand((ICommandSource) this);
    return (object) null;
  }

  protected virtual void OnClick()
  {
    this.RaiseEvent(new RoutedEventArgs(ButtonDropDown.ClickEvent, (object) this));
  }

  internal static void ExecuteCommand(ICommandSource commandSource)
  {
    ICommand command = commandSource.Command;
    if (command == null)
      return;
    object commandParameter = commandSource.CommandParameter;
    IInputElement target = commandSource.CommandTarget;
    if (target == null && Keyboard.FocusedElement == null)
      target = commandSource as IInputElement;
    if (command is RoutedCommand routedCommand && target != null)
    {
      if (!routedCommand.CanExecute(commandParameter, target))
        return;
      routedCommand.Execute(commandParameter, target);
    }
    else
    {
      if (!command.CanExecute(commandParameter))
        return;
      command.Execute(commandParameter);
    }
  }

  protected virtual void HandleMouseDown(MouseButtonEventArgs e)
  {
    Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
    if (this.IsEnabled && rect.Contains(e.GetPosition((IInputElement) this)) && (e.ChangedButton == MouseButton.Left || e.ChangedButton == MouseButton.Right && this.IsOnContextMenu) && (this.Role == eButtonRole.SplitButton && !this.m_ExpandBounds.IsEmpty && this.m_ExpandBounds.Contains(e.GetPosition((IInputElement) this)) || this.Role == eButtonRole.DropDown || this.Role == eButtonRole.MenuItem && this.HasVisibleItems))
    {
      if (this.Parent is ApplicationMenu && this.IsPopupOpen)
      {
        e.Handled = true;
        return;
      }
      this.ClickHeader();
    }
    e.Handled = true;
  }

  private bool IsOnContextMenu => false;

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    if (!e.Handled)
      this.UpdateIsPressed();
    if (this.IsEnabled)
    {
      Rect rect = new Rect(this.RenderSize);
      System.Windows.Point position = e.GetPosition((IInputElement) this);
      if (this.Role == eButtonRole.SplitButton && this.m_CommandBounds.Contains(this.m_MouseDownPosition) && this.m_CommandBounds.Contains(position) || this.Role == eButtonRole.SplitButton && this.m_CommandBounds.IsEmpty && rect.Contains(this.m_MouseDownPosition) && rect.Contains(position) || this.Role == eButtonRole.MenuItem && !this.HasVisibleItems)
        this.InternalOnClick(true);
      e.Handled = true;
    }
    base.OnMouseLeftButtonUp(e);
    this.UpdateBorderRenderState();
    this.m_MouseDownPosition = new System.Windows.Point(double.MaxValue, double.MaxValue);
  }

  private void UpdateIsPressed()
  {
    Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
    if (Mouse.LeftButton == MouseButtonState.Pressed && this.IsMouseOver && rect.Contains(Mouse.GetPosition((IInputElement) this)))
      this.SetValue(ButtonDropDown.IsPressedPropertyKey, (object) true);
    else
      this.ClearValue(ButtonDropDown.IsPressedPropertyKey);
  }

  protected virtual eButtonRenderingState GetBorderRenderState()
  {
    eButtonRenderingState borderRenderState = eButtonRenderingState.Normal;
    if (!this.IsEnabled)
      borderRenderState = eButtonRenderingState.Disabled;
    else if (this.Role == eButtonRole.MenuItem || this.IsOnApplicationMenu)
    {
      Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
      if (this.IsHighlighted || this.IsPopupOpen)
        borderRenderState = eButtonRenderingState.Hover;
    }
    else
    {
      Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
      if (this.IsPopupOpen)
        borderRenderState = eButtonRenderingState.Expanded;
      else if (Mouse.LeftButton == MouseButtonState.Pressed && this.IsMouseOver && rect.Contains(Mouse.GetPosition((IInputElement) this)))
        borderRenderState = eButtonRenderingState.Pressed;
      else if (this.IsMouseOver && rect.Contains(Mouse.GetPosition((IInputElement) this)) || this.IsHighlighted || this.IsKeyboardFocusWithin)
        borderRenderState = !this.IsChecked ? eButtonRenderingState.Hover : eButtonRenderingState.CheckedHover;
      else if (this.IsChecked)
        borderRenderState = eButtonRenderingState.Checked;
    }
    return borderRenderState;
  }

  private void UpdateBorderRenderState()
  {
    if (this.m_ButtonBorder == null)
      return;
    this.SetButtonBorderState(this.GetBorderRenderState());
  }

  protected void SetButtonBorderState(eButtonRenderingState state)
  {
    if (this.m_ButtonBorder.ButtonState == state)
      return;
    this.m_ButtonBorder.ButtonState = state;
  }

  public virtual void ClickHeader()
  {
    if (this.IsPopupOpen)
    {
      if (this.IsNestedMenu)
        return;
      this.SetPopupMode(false);
      if (this.GetParent() is IPopupParentControl)
        return;
      this.IsPopupOpen = false;
    }
    else
      this.OpenPopup();
  }

  protected virtual void SetPopupMode(bool popupMode)
  {
    IPopupParentControl popupParent = this.GetPopupParent();
    if (popupParent == null || popupParent.IsPopupMode == popupMode)
      return;
    popupParent.IsPopupMode = popupMode;
  }

  internal IPopupParentControl GetPopupParent()
  {
    if (this.Parent is IPopupParentControl)
      return this.Parent as IPopupParentControl;
    if (this.TemplatedParent is IPopupParentControl)
      return this.TemplatedParent as IPopupParentControl;
    ItemsControl popupParent = ItemsControl.ItemsControlFromItemContainer((DependencyObject) this);
    if (popupParent is IPopupParentControl)
      return popupParent as IPopupParentControl;
    DependencyObject parent = this.Parent;
    if (parent != null)
    {
      while (!(parent is IPopupParentControl))
      {
        parent = LogicalTreeHelper.GetParent(parent);
        if (parent == null)
          goto label_10;
      }
      return parent as IPopupParentControl;
    }
label_10:
    return (IPopupParentControl) null;
  }

  internal object GetParent()
  {
    if (this.Parent is ButtonDropDown || this.Parent is IPopupParentControl)
      return (object) this.Parent;
    if (this.TemplatedParent is IPopupParentControl)
      return (object) this.TemplatedParent;
    return this.Parent != null ? (object) this.Parent : (object) ItemsControl.ItemsControlFromItemContainer((DependencyObject) this);
  }

  internal bool OpenPopup()
  {
    if (this.IsPopupOpen || this.Role != eButtonRole.DropDown && !this.HasVisibleItems)
      return false;
    this.IsPopupOpen = true;
    if (!this.IsKeyboardFocusWithin)
      this.FocusOrSelect();
    return true;
  }

  protected virtual bool HasVisibleItems
  {
    get
    {
      if (this.Items.Count > 0 && this.ItemsSource != null)
        return true;
      if (this.Items.Count > 0)
      {
        foreach (object obj in (IEnumerable) this.Items)
        {
          if (obj is UIElement && ((UIElement) obj).Visibility != Visibility.Collapsed)
            return true;
        }
      }
      return false;
    }
  }

  [Browsable(false)]
  [Category("Appearance")]
  public bool IsPressed => (bool) this.GetValue(ButtonDropDown.IsPressedProperty);

  public eButtonRole Role
  {
    get => (eButtonRole) this.GetValue(ButtonDropDown.RoleProperty);
    set => this.SetValue(ButtonDropDown.RoleProperty, (object) value);
  }

  [DefaultValue(eButtonPartVisibility.ImageAndHeader)]
  public eButtonPartVisibility PartVisibility
  {
    get => (eButtonPartVisibility) this.GetValue(ButtonDropDown.PartVisibilityProperty);
    set => this.SetValue(ButtonDropDown.PartVisibilityProperty, (object) value);
  }

  public eDropDownType PopupType
  {
    get => (eDropDownType) this.GetValue(ButtonDropDown.PopupTypeProperty);
    set => this.SetValue(ButtonDropDown.PopupTypeProperty, (object) value);
  }

  private static void OnPopupTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).UpdatePopupTypeTemplate();
  }

  private void UpdatePopupTypeTemplate()
  {
    if (this.m_PopupContentControl == null)
      return;
    if (this.PopupType == eDropDownType.Popup)
      this.m_PopupContentControl.Template = this.FindResource((object) new ComponentResourceKey(typeof (ButtonDropDown), (object) "PopupTypePopupContent")) as ControlTemplate;
    else
      this.m_PopupContentControl.Template = this.FindResource((object) new ComponentResourceKey(typeof (ButtonDropDown), (object) "PopupTypeMenuContent")) as ControlTemplate;
  }

  [Browsable(false)]
  public ePopupPlacement PopupPlacement
  {
    get => (ePopupPlacement) this.GetValue(ButtonDropDown.PopupPlacementProperty);
    set => this.SetValue(ButtonDropDown.PopupPlacementProperty, (object) value);
  }

  [Browsable(false)]
  public UIElement PopupPlacementTarget
  {
    get => (UIElement) this.GetValue(ButtonDropDown.PopupPlacementTargetProperty);
    set => this.SetValue(ButtonDropDown.PopupPlacementTargetProperty, (object) value);
  }

  public bool IsSimpleHeader
  {
    get => (bool) this.GetValue(ButtonDropDown.IsSimpleHeaderProperty);
    internal set => this.SetValue(ButtonDropDown.IsSimpleHeaderPropertyKey, (object) value);
  }

  public bool IsNestedMenu
  {
    get => (bool) this.GetValue(ButtonDropDown.IsNestedMenuProperty);
    set => this.SetValue(ButtonDropDown.IsNestedMenuProperty, (object) value);
  }

  public Visibility IsExpandVisible
  {
    get => (Visibility) this.GetValue(ButtonDropDown.IsExpandVisibleProperty);
  }

  [Browsable(true)]
  [DefaultValue(eExpandVisibility.Auto)]
  public eExpandVisibility ExpandVisibility
  {
    get => (eExpandVisibility) this.GetValue(ButtonDropDown.ExpandVisibilityProperty);
    set => this.SetValue(ButtonDropDown.ExpandVisibilityProperty, (object) value);
  }

  private static void OnExpandPositionChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) d;
    if (!buttonDropDown.IsSimpleHeader)
      return;
    buttonDropDown.UpdateExpandVisibility();
  }

  private static void OnExpandVisibilityChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).UpdateExpandVisibility();
  }

  private static void OnInlineExpandChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).UpdateExpandVisibility();
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    this.UpdateExpandVisibility();
    base.OnItemsChanged(e);
  }

  private bool IsUsingInlineExpand
  {
    get
    {
      return this.IsSimpleHeader && this.InlineExpand && this.m_ButtonExpandInline != null && this.ExpandPosition == eExpandPosition.Bottom;
    }
  }

  private void UpdateInlineExpandParent()
  {
    TextBlock buttonContent = this.m_ButtonContent as TextBlock;
    if (this.m_AccessText == null || !this.IsSimpleHeader || buttonContent == null)
      return;
    PropertyInfo property = this.m_AccessText.GetType().GetProperty("TextBlock", BindingFlags.Instance | BindingFlags.NonPublic);
    if (!(property != (PropertyInfo) null) || !(property.GetValue((object) this.m_AccessText, (object[]) null) is TextBlock textBlock))
      return;
    if (this.m_ButtonExpandInline.Parent is InlineUIContainer)
    {
      if (buttonContent.Inlines.Contains((Inline) (this.m_ButtonExpandInline.Parent as InlineUIContainer)))
      {
        buttonContent.Inlines.Remove((Inline) (this.m_ButtonExpandInline.Parent as InlineUIContainer));
      }
      else
      {
        (this.m_ButtonExpandInline.Parent as InlineUIContainer).Child = (UIElement) null;
        new InlineUIContainer().Child = (UIElement) this.m_ButtonExpandInline;
      }
    }
    if (this.m_ButtonExpandInline.Parent == null)
      return;
    textBlock.Inlines.Add((Inline) (this.m_ButtonExpandInline.Parent as InlineUIContainer));
  }

  private void AccessTextSizeChanged(object sender, SizeChangedEventArgs e)
  {
    this.UpdateInlineExpandParent();
  }

  private void SetInlineExpandVisibility(Visibility v)
  {
    if (this.m_ButtonExpandInline == null)
      return;
    this.m_ButtonExpandInline.Visibility = v;
    TextBlock buttonContent = this.m_ButtonContent as TextBlock;
    if (v == Visibility.Visible)
    {
      if (this.m_AccessText == null || !this.IsSimpleHeader)
        return;
      PropertyInfo property = this.m_AccessText.GetType().GetProperty("TextBlock", BindingFlags.Instance | BindingFlags.NonPublic);
      if (!(property != (PropertyInfo) null) || !(property.GetValue((object) this.m_AccessText, (object[]) null) is TextBlock textBlock))
        return;
      InlineUIContainer inlineUiContainer = this.m_ButtonExpandInline.Parent as InlineUIContainer;
      if (buttonContent.Inlines.Contains((Inline) inlineUiContainer))
        buttonContent.Inlines.Remove((Inline) inlineUiContainer);
      if (inlineUiContainer == null)
      {
        inlineUiContainer = new InlineUIContainer();
        inlineUiContainer.Child = (UIElement) this.m_ButtonExpandInline;
      }
      if (!textBlock.Inlines.Contains((Inline) inlineUiContainer))
        textBlock.Inlines.Add((Inline) (this.m_ButtonExpandInline.Parent as InlineUIContainer));
      this.m_AccessText.SizeChanged += new SizeChangedEventHandler(this.AccessTextSizeChanged);
    }
    else
    {
      if (!(this.m_ButtonExpandInline.Parent is InlineUIContainer) || buttonContent == null)
        return;
      buttonContent.Inlines.Remove((Inline) (this.m_ButtonExpandInline.Parent as InlineUIContainer));
      (this.m_ButtonExpandInline.Parent as InlineUIContainer).Child = (UIElement) null;
    }
  }

  private void UpdateExpandVisibility()
  {
    if (this.ExpandVisibility == eExpandVisibility.Auto)
    {
      if (this.IsUsingInlineExpand)
      {
        this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Collapsed);
        if (this.HasVisibleItems)
          this.SetInlineExpandVisibility(Visibility.Visible);
        else
          this.SetInlineExpandVisibility(Visibility.Collapsed);
      }
      else
      {
        this.SetInlineExpandVisibility(Visibility.Collapsed);
        if (this.HasVisibleItems)
        {
          if (this.IsExpandVisible == Visibility.Visible)
            return;
          this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Visible);
        }
        else
        {
          if (this.IsExpandVisible != Visibility.Visible)
            return;
          this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Collapsed);
        }
      }
    }
    else if (this.IsUsingInlineExpand)
    {
      this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Collapsed);
      if (this.ExpandVisibility == eExpandVisibility.Hidden)
      {
        this.m_ButtonExpandInline.Visibility = Visibility.Collapsed;
      }
      else
      {
        if (this.ExpandVisibility != eExpandVisibility.Visible)
          return;
        this.m_ButtonExpandInline.Visibility = Visibility.Visible;
      }
    }
    else
    {
      if (this.m_ButtonExpandInline != null)
        this.m_ButtonExpandInline.Visibility = Visibility.Collapsed;
      if (this.ExpandVisibility == eExpandVisibility.Visible && this.IsExpandVisible != Visibility.Visible)
      {
        this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Visible);
      }
      else
      {
        if (this.ExpandVisibility != eExpandVisibility.Hidden || this.IsExpandVisible != Visibility.Visible)
          return;
        this.SetValue(ButtonDropDown.IsExpandVisiblePropertyKey, (object) Visibility.Collapsed);
      }
    }
  }

  internal bool IsSelected
  {
    get => (bool) this.GetValue(ButtonDropDown.IsSelectedProperty);
    set => this.SetValue(ButtonDropDown.IsSelectedProperty, (object) value);
  }

  public bool ContentExpands
  {
    get => (bool) this.GetValue(ButtonDropDown.ContentExpandsProperty);
    set => this.SetValue(ButtonDropDown.ContentExpandsProperty, (object) value);
  }

  [Browsable(false)]
  public Popup Popup => this.m_Popup;

  protected ButtonDropDown HighlightedChild
  {
    get => this.m_HighlightedChild;
    set
    {
      if (this.m_HighlightedChild != null)
        this.m_HighlightedChild.IsSelected = false;
      this.m_HighlightedChild = value;
      if (this.m_HighlightedChild == null)
        return;
      this.m_HighlightedChild.IsSelected = true;
    }
  }

  private static void OnIsHighlightedChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).OnIsHighlightedChanged();
  }

  private void OnIsHighlightedChanged() => this.UpdateBorderRenderState();

  protected override void OnGotKeyboardFocus(KeyboardFocusChangedEventArgs e)
  {
    base.OnGotKeyboardFocus(e);
    this.UpdateBorderRenderState();
  }

  protected override void OnIsKeyboardFocusWithinChanged(DependencyPropertyChangedEventArgs e)
  {
    base.OnIsKeyboardFocusWithinChanged(e);
    if (this.GetParent() is ButtonDropDown)
      this.IsSelected = (bool) e.NewValue;
    else if (this.GetParent() is IPopupParentControl && !(bool) e.NewValue && this.IsPopupOpen && !this.FocusChangeKeepsPopupOpen && FocusManager.GetFocusedElement((DependencyObject) this) == null && (!(Keyboard.FocusedElement is ContextMenu) || !(((FrameworkElement) Keyboard.FocusedElement).Name == Ribbon.SysQatCustomizeContextMenu)))
      this.IsPopupOpen = false;
    this.UpdateBorderRenderState();
  }

  protected virtual void UpdateKeyTipsState()
  {
    if (this.IsPopupOpen)
    {
      UIElement keyTipsParent = this.GetKeyTipsParent();
      if (keyTipsParent == null)
        return;
      bool flag = false;
      if (keyTipsParent is RibbonTab)
      {
        RibbonTab ribbonTab = keyTipsParent as RibbonTab;
        if (ribbonTab.ParentRibbon != null && ribbonTab.ParentRibbon.KeyTipsVisible)
        {
          flag = true;
          ribbonTab.ParentRibbon.ShowKeyTips = false;
        }
      }
      else if (keyTipsParent is Ribbon)
      {
        Ribbon ribbon = keyTipsParent as Ribbon;
        if (ribbon.KeyTipsVisible)
        {
          ribbon.ShowKeyTips = false;
          flag = true;
        }
      }
      else if (keyTipsParent is ButtonDropDown)
      {
        ButtonDropDown buttonDropDown = keyTipsParent as ButtonDropDown;
        if (buttonDropDown.ShowKeyTips)
        {
          buttonDropDown.ShowKeyTips = false;
          flag = true;
        }
      }
      this.ShowKeyTips = flag;
    }
    else
    {
      if (!this.ShowKeyTips)
        return;
      UIElement keyTipsParent = this.GetKeyTipsParent();
      switch (keyTipsParent)
      {
        case RibbonTab _:
          RibbonTab contextObject = keyTipsParent as RibbonTab;
          Ribbon parentRibbon = contextObject.ParentRibbon;
          if (parentRibbon != null)
          {
            parentRibbon.ShowKeyTipsForContext(contextObject);
            break;
          }
          break;
        case Ribbon _:
          (keyTipsParent as Ribbon).ShowKeyTips = true;
          break;
        case ButtonDropDown _:
          (keyTipsParent as ButtonDropDown).ShowKeyTips = true;
          break;
      }
      this.ShowKeyTips = false;
    }
  }

  protected virtual void OnShowKeyTipsChanged()
  {
    if (this.m_ShowKeyTips)
    {
      this.m_ShowKeyTips = false;
      if (this.m_Popup == null)
        return;
      UIElement elementForAdorning = this.GetElementForAdorning();
      if (elementForAdorning == null)
        return;
      this.m_KeyTipsAdorner = new KeyTipsAdorner(elementForAdorning);
      AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer((Visual) elementForAdorning);
      if (adornerLayer == null)
        return;
      adornerLayer.Add((Adorner) this.m_KeyTipsAdorner);
      this.m_KeyTipsAdorner.ContextObject = (object) this;
      this.m_ShowKeyTips = true;
    }
    else
    {
      if (this.m_KeyTipsAdorner == null || this.m_Popup == null)
        return;
      UIElement elementForAdorning = this.GetElementForAdorning();
      if (elementForAdorning != null)
        AdornerLayer.GetAdornerLayer((Visual) elementForAdorning)?.Remove((Adorner) this.m_KeyTipsAdorner);
      this.m_KeyTipsAdorner.ContextObject = (object) null;
      this.m_KeyTipsAdorner = (KeyTipsAdorner) null;
    }
  }

  internal bool ShowKeyTips
  {
    get => this.m_ShowKeyTips;
    set
    {
      if (this.m_ShowKeyTips == value)
        return;
      this.m_ShowKeyTips = value;
      this.OnShowKeyTipsChanged();
    }
  }

  protected virtual UIElement GetElementForAdorning()
  {
    foreach (object elementForAdorning in (IEnumerable) this.Items)
    {
      if (elementForAdorning is UIElement && ((UIElement) elementForAdorning).Visibility == Visibility.Visible)
        return elementForAdorning as UIElement;
    }
    return (UIElement) null;
  }

  private UIElement GetKeyTipsParent()
  {
    DependencyObject parent = this.Parent;
    while (!(parent is RibbonTab))
    {
      if (parent is Ribbon)
        return parent as UIElement;
      if (parent is ButtonDropDown)
        return parent as UIElement;
      if (parent != null)
        parent = LogicalTreeHelper.GetParent(parent);
      if (parent == null)
        return (UIElement) null;
    }
    return parent as UIElement;
  }

  protected override void OnLostFocus(RoutedEventArgs e)
  {
    base.OnLostFocus(e);
    this.UpdateBorderRenderState();
  }

  private static void OnIsPopupOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) d;
    bool oldValue = (bool) e.OldValue;
    bool newValue = (bool) e.NewValue;
    int num1 = oldValue ? 1 : 0;
    int num2 = newValue ? 1 : 0;
    buttonDropDown.OnIsPopupOpenChanged(num1 != 0, num2 != 0);
  }

  protected virtual void OnIsPopupOpenChanged(bool oldValue, bool newValue)
  {
    this.StopTimer(ref this.m_DelayPopupOpenTimer);
    this.StopTimer(ref this.m_DelayPopupCloseTimer);
    if (UIElementAutomationPeer.FromElement((UIElement) this) is ButtonDropDownAutomationPeer downAutomationPeer)
    {
      downAutomationPeer.ResetChildrenCache();
      downAutomationPeer.RaiseExpandCollapseAutomationEvent(oldValue, newValue);
    }
    if (newValue)
    {
      CommandManager.InvalidateRequerySuggested();
      this.IsSelected = true;
      this.HighlightedChild = (ButtonDropDown) null;
      this.SetPopupMode(true);
      this.UpdatePopupPlacement();
      this.OnPopupOpened(new RoutedEventArgs(ButtonDropDown.PopupOpenedEvent, (object) this));
    }
    else
    {
      if (this.HighlightedChild != null)
      {
        if (this.HighlightedChild.IsKeyboardFocusWithin)
          this.Focus();
        if (this.HighlightedChild != null && this.HighlightedChild.IsPopupOpen)
          this.HighlightedChild.IsPopupOpen = false;
      }
      else if (this.IsKeyboardFocusWithin && this.GetParent() is ButtonDropDown)
        ((UIElement) this.GetParent()).Focus();
      this.HighlightedChild = (ButtonDropDown) null;
      if (this.m_Popup == null)
        this.OnPopupClosed(new RoutedEventArgs(ButtonDropDown.PopupClosedEvent, (object) this));
      if (this.GetParent() is IPopupParentControl && !(this.Parent is ButtonEx))
        this.SetPopupMode(false);
    }
    this.CoerceValue(ToolTipService.IsEnabledProperty);
    this.UpdateBorderRenderState();
    this.UpdateInactiveButtonPart();
  }

  protected virtual void UpdatePopupPlacement()
  {
    if (!(this.Parent is ApplicationMenu) || !((ItemsControl) this.Parent).Items.Contains((object) this))
      return;
    ApplicationMenu parent = this.Parent as ApplicationMenu;
    if (!(parent.GetTemplateChild("MruBorder") is UIElement templateChild) || !parent.HasMruItems)
      return;
    this.m_Popup.PlacementTarget = templateChild;
    this.m_Popup.Placement = PlacementMode.Relative;
    this.m_Popup.Width = templateChild.RenderSize.Width + 2.0;
    this.m_Popup.Height = templateChild.RenderSize.Height + 3.0;
    this.m_Popup.HorizontalOffset = 1.0;
  }

  private static void OnParentControlIsSelectedChanged(
    object sender,
    RoutedPropertyChangedEventArgs<bool> e)
  {
    if (sender == e.OriginalSource)
      return;
    ButtonDropDown buttonDropDown = (ButtonDropDown) sender;
    if (!(e.OriginalSource is ButtonDropDown originalSource))
      return;
    if (e.NewValue)
    {
      if (buttonDropDown.HighlightedChild == originalSource)
        buttonDropDown.StopTimer(ref buttonDropDown.m_DelayPopupCloseTimer);
      if (buttonDropDown.HighlightedChild != originalSource && originalSource.GetParent() == buttonDropDown)
      {
        if (buttonDropDown.HighlightedChild != null && buttonDropDown.HighlightedChild.IsPopupOpen)
          buttonDropDown.HighlightedChild.IsPopupOpen = false;
        buttonDropDown.HighlightedChild = originalSource;
      }
    }
    else if (buttonDropDown.HighlightedChild == originalSource)
      buttonDropDown.HighlightedChild = (ButtonDropDown) null;
    e.Handled = true;
  }

  private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) d;
    buttonDropDown.SetValue(ButtonDropDown.IsHighlightedPropertyKey, e.NewValue);
    if ((bool) e.OldValue)
    {
      if (buttonDropDown.IsPopupOpen)
        buttonDropDown.IsPopupOpen = false;
      buttonDropDown.StopTimer(ref buttonDropDown.m_DelayPopupOpenTimer);
      buttonDropDown.StopTimer(ref buttonDropDown.m_DelayPopupCloseTimer);
    }
    buttonDropDown.RaiseEvent((RoutedEventArgs) new RoutedPropertyChangedEventArgs<bool>((bool) e.OldValue, (bool) e.NewValue, BasePopupControl.IsSelectedChangedEvent));
  }

  [Browsable(false)]
  [Bindable(true)]
  [Category("Appearance")]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsPopupOpen
  {
    get => (bool) this.GetValue(ButtonDropDown.IsPopupOpenProperty);
    set => this.SetValue(ButtonDropDown.IsPopupOpenProperty, (object) value);
  }

  private static object CoerceIsPopupOpen(DependencyObject d, object value)
  {
    if ((bool) value)
    {
      ButtonDropDown buttonDropDown = (ButtonDropDown) d;
      if (!buttonDropDown.IsLoaded)
      {
        buttonDropDown.RegisterToOpenOnLoad();
        return (object) false;
      }
    }
    return value;
  }

  private void RegisterToOpenOnLoad() => this.Loaded += new RoutedEventHandler(this.OpenOnLoad);

  private void OpenOnLoad(object sender, RoutedEventArgs e)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Delegate) (param =>
    {
      this.CoerceValue(ButtonDropDown.IsPopupOpenProperty);
      return (object) null;
    }));
  }

  private static void OnPopupPlacementChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
  }

  private static void OnIsCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).OnIsCheckedChanged(e);
  }

  private void OnIsCheckedChanged(DependencyPropertyChangedEventArgs e)
  {
    if ((bool) e.NewValue)
    {
      this.OnChecked(new RoutedEventArgs(ButtonDropDown.CheckedEvent));
      this.UpdateOptionGroupState();
    }
    else
      this.OnUnchecked(new RoutedEventArgs(ButtonDropDown.UncheckedEvent));
    this.UpdateBorderRenderState();
  }

  private bool IsInOptionGroup
  {
    get
    {
      string optionGroup = this.OptionGroup;
      return optionGroup != null && !(optionGroup == "");
    }
  }

  private void UpdateOptionGroupState()
  {
    if (!this.IsInOptionGroup)
      return;
    string optionGroup = this.OptionGroup;
    IEnumerable enumerable = (IEnumerable) null;
    if (this.Parent is ItemsControl)
      enumerable = (IEnumerable) ((ItemsControl) this.Parent).Items;
    else if (this.Parent is Panel)
      enumerable = (IEnumerable) ((Panel) this.Parent).Children;
    if (enumerable == null)
      return;
    foreach (object obj in enumerable)
    {
      if (obj is ButtonDropDown buttonDropDown && buttonDropDown != this && buttonDropDown.OptionGroup == optionGroup && buttonDropDown.IsChecked)
        buttonDropDown.IsChecked = false;
    }
  }

  private static void OnRoleChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).OnRoleChanged((eButtonRole) e.OldValue, (eButtonRole) e.NewValue);
  }

  private void OnRoleChanged(eButtonRole oldRole, eButtonRole newRole)
  {
    if (newRole == eButtonRole.MenuItem)
      this.Style = (Style) this.FindResource((object) new ComponentResourceKey(typeof (ButtonDropDown), (object) "ButtonDropDownMenuItem"));
    else if (oldRole == eButtonRole.MenuItem)
      this.Style = (Style) this.FindResource((object) typeof (ButtonDropDown));
    this.UpdateBorderBehavior();
  }

  private void UpdateBorderBehavior()
  {
    if (this.Role == eButtonRole.MenuItem)
    {
      if (this.m_ButtonBorder != null)
        this.m_ButtonBorder.Animation = false;
    }
    else if (this.m_ButtonBorder != null)
      this.m_ButtonBorder.Animation = true;
    if (this.m_ButtonBorder == null)
      return;
    this.m_ButtonBorder.RenderBorder = this.m_RenderBorder;
  }

  internal bool RenderBorder
  {
    get => this.m_RenderBorder;
    set
    {
      this.m_RenderBorder = value;
      this.UpdateBorderBehavior();
    }
  }

  protected virtual void OnChecked(RoutedEventArgs e) => this.RaiseEvent(e);

  protected virtual void OnUnchecked(RoutedEventArgs e) => this.RaiseEvent(e);

  [Bindable(true)]
  [Category("Behavior")]
  public bool IsCheckable
  {
    get => (bool) this.GetValue(ButtonDropDown.IsCheckableProperty);
    set => this.SetValue(ButtonDropDown.IsCheckableProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Appearance")]
  public bool IsChecked
  {
    get => (bool) this.GetValue(ButtonDropDown.IsCheckedProperty);
    set => this.SetValue(ButtonDropDown.IsCheckedProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Appearance")]
  public eExpandPosition ExpandPosition
  {
    get => (eExpandPosition) this.GetValue(ButtonDropDown.ExpandPositionProperty);
    set => this.SetValue(ButtonDropDown.ExpandPositionProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(true)]
  public bool WrapLabel
  {
    get => (bool) this.GetValue(ButtonDropDown.WrapLabelProperty);
    set => this.SetValue(ButtonDropDown.WrapLabelProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(true)]
  public bool InlineExpand
  {
    get => (bool) this.GetValue(ButtonDropDown.InlineExpandProperty);
    set => this.SetValue(ButtonDropDown.InlineExpandProperty, (object) value);
  }

  [Bindable(true)]
  [DefaultValue(false)]
  [Description("Indicates whether popup is left open when input focus changes.")]
  public bool FocusChangeKeepsPopupOpen
  {
    get => (bool) this.GetValue(ButtonDropDown.FocusChangeKeepsPopupOpenProperty);
    set => this.SetValue(ButtonDropDown.FocusChangeKeepsPopupOpenProperty, (object) value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object RenderImage
  {
    get => this.GetValue(ButtonDropDown.RenderImageProperty);
    internal set => this.SetValue(ButtonDropDown.RenderImagePropertyKey, value);
  }

  [Bindable(true)]
  [Category("Content")]
  public object Image
  {
    get => this.GetValue(ButtonDropDown.ImageProperty);
    set => this.SetValue(ButtonDropDown.ImageProperty, value);
  }

  private static void OnImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ButtonDropDown buttonDropDown))
      return;
    buttonDropDown.OnImageSourceChanged((string) e.OldValue, (string) e.NewValue);
  }

  protected virtual void OnImageSourceChanged(string oldValue, string newValue)
  {
    this.UpdateRenderImage();
  }

  public string ImageSource
  {
    get => (string) this.GetValue(ButtonDropDown.ImageSourceProperty);
    set => this.SetValue(ButtonDropDown.ImageSourceProperty, (object) value);
  }

  private static void OnImageSmallSourceChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is ButtonDropDown buttonDropDown))
      return;
    buttonDropDown.OnImageSmallSourceChanged((string) e.OldValue, (string) e.NewValue);
  }

  protected virtual void OnImageSmallSourceChanged(string oldValue, string newValue)
  {
    this.UpdateRenderImage();
  }

  public string ImageSmallSource
  {
    get => (string) this.GetValue(ButtonDropDown.ImageSmallSourceProperty);
    set => this.SetValue(ButtonDropDown.ImageSmallSourceProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  public object ImageSmall
  {
    get => this.GetValue(ButtonDropDown.ImageSmallProperty);
    set => this.SetValue(ButtonDropDown.ImageSmallProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  public bool UseSmallImage
  {
    get => (bool) this.GetValue(ButtonDropDown.UseSmallImageProperty);
    set => this.SetValue(ButtonDropDown.UseSmallImageProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  public eButtonImagePosition ImagePosition
  {
    get => (eButtonImagePosition) this.GetValue(ButtonDropDown.ImagePositionProperty);
    set => this.SetValue(ButtonDropDown.ImagePositionProperty, (object) value);
  }

  [Category("Appearance")]
  [Browsable(false)]
  public bool IsHighlighted => (bool) this.GetValue(ButtonDropDown.IsHighlightedProperty);

  [Bindable(true)]
  [Category("Behavior")]
  public bool StaysOpenOnClick
  {
    get => (bool) this.GetValue(ButtonDropDown.StaysOpenOnClickProperty);
    set => this.SetValue(ButtonDropDown.StaysOpenOnClickProperty, (object) value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsPopupAnimationSuspended
  {
    get => (bool) this.GetValue(ButtonDropDown.IsPopupAnimationSuspendedProperty);
    set => this.SetValue(ButtonDropDown.IsPopupAnimationSuspendedProperty, (object) value);
  }

  [Category("Content")]
  [Bindable(true)]
  public string InputGestureText
  {
    get => (string) this.GetValue(ButtonDropDown.InputGestureTextProperty);
    set => this.SetValue(ButtonDropDown.InputGestureTextProperty, (object) value);
  }

  private static void OnInputGestureTextChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
  }

  private static object CoerceInputGestureText(DependencyObject d, object value)
  {
    ButtonDropDown buttonDropDown = (ButtonDropDown) d;
    RoutedCommand command = buttonDropDown.Command as RoutedCommand;
    if (string.IsNullOrEmpty((string) value) && buttonDropDown.InputGestureText == "" && command != null)
    {
      InputGestureCollection inputGestures = command.InputGestures;
      if (inputGestures == null || inputGestures.Count < 1)
        return value;
      for (int index = 0; index < inputGestures.Count; ++index)
      {
        if (((IList) inputGestures)[index] is KeyGesture keyGesture)
          return (object) keyGesture.GetDisplayStringForCulture(CultureInfo.CurrentCulture);
      }
    }
    return value;
  }

  protected override AutomationPeer OnCreateAutomationPeer()
  {
    return (AutomationPeer) new ButtonDropDownAutomationPeer(this);
  }

  internal ElementAutoSizeBag AutoSizeBag
  {
    get => this.m_AutoSizeBag;
    set => this.m_AutoSizeBag = value;
  }

  private Size ImageFixedSize
  {
    get => this.m_ImageFixedSize;
    set
    {
      this.m_ImageFixedSize = value;
      if (this.m_ButtonImage == null)
        return;
      if (LayoutHelpers.IsEmpty(this.m_ImageFixedSize))
      {
        this.m_ButtonImage.MaxWidth = double.PositiveInfinity;
        this.m_ButtonImage.MaxHeight = double.PositiveInfinity;
      }
      else
      {
        this.m_ButtonImage.MaxWidth = this.m_ImageFixedSize.Width;
        this.m_ButtonImage.MaxHeight = this.m_ImageFixedSize.Height;
      }
    }
  }

  internal bool HasImage => this.m_ButtonImage != null;

  internal void OpenPopupWithKeyboard()
  {
    if (!this.OpenPopup())
      return;
    this.GetFirstVisible()?.Focus();
  }

  private UIElement GetFirstVisible()
  {
    foreach (object firstVisible in (IEnumerable) this.Items)
    {
      if (firstVisible is UIElement && ((UIElement) firstVisible).Visibility == Visibility.Visible)
        return firstVisible as UIElement;
    }
    return (UIElement) null;
  }

  private UIElement GetFocusedElement(IList items)
  {
    foreach (object obj in (IEnumerable) items)
    {
      if (obj is UIElement focusedElement && focusedElement.IsFocused)
        return focusedElement;
    }
    return (UIElement) null;
  }

  protected override void OnKeyDown(KeyEventArgs e)
  {
    base.OnKeyDown(e);
    Key key = e.Key;
    bool flag = false;
    if (key == Key.System && (Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt && this.IsPopupOpen)
    {
      this.IsPopupOpen = false;
    }
    else
    {
      if (e.Handled)
        return;
      if (this.FlowDirection == FlowDirection.RightToLeft)
      {
        if (key == Key.Right)
          key = Key.Left;
        else if (key == Key.Left)
          key = Key.Right;
      }
      if (key <= Key.Return)
      {
        if (key != Key.Tab)
        {
          if (key == Key.Return)
          {
            if (this.Role == eButtonRole.DropDown || this.Role == eButtonRole.SplitButton && this.HasItems)
              this.OpenPopupWithKeyboard();
            else if (this.GetParent() is ItemsControl)
            {
              if (this.HasVisibleItems)
                this.OpenPopupWithKeyboard();
              else
                this.InternalOnClick(true);
            }
            else
              this.InternalOnClick(true);
            flag = true;
            goto label_45;
          }
          goto label_45;
        }
      }
      else if (key != Key.Escape)
      {
        if (key != Key.Up && key != Key.Down)
          goto label_45;
      }
      else
      {
        if (this.IsPopupOpen)
        {
          this.IsPopupOpen = false;
        }
        else
        {
          object parent = this.GetParent();
          switch (parent)
          {
            case ButtonDropDown _:
              ((ButtonDropDown) parent).IsPopupOpen = false;
              break;
            case IPopupParentControl _:
              this.SetPopupMode(false);
              break;
          }
        }
        flag = true;
        goto label_45;
      }
      UIElement uiElement1 = (UIElement) null;
      if (this.IsPopupOpen)
      {
        IList generatedItems = this.GetGeneratedItems();
        uiElement1 = this.GetFocusedElement(generatedItems);
        if (uiElement1 == null && !(uiElement1 is ButtonDropDown))
        {
          if (this.HighlightedChild == null && !((UIElement) generatedItems[0]).IsFocused && ((UIElement) generatedItems[0]).Focusable)
          {
            ((UIElement) generatedItems[0]).Focus();
            flag = true;
          }
          else if (this.HighlightedChild != null && !this.HighlightedChild.IsFocused || this.HighlightedChild == null)
          {
            UIElement nextItem = this.FindNextItem(this.HighlightedChild == null ? 0 : generatedItems.IndexOf((object) this.HighlightedChild), key == Key.Up ? -1 : 1);
            if (nextItem != null)
              nextItem.Focus();
            else
              this.HighlightedChild.Focus();
            flag = true;
          }
        }
      }
      if (!flag && this.GetParent() is ButtonDropDown)
      {
        UIElement uiElement2 = uiElement1 == null ? this.PredictFocus(key == Key.Down || key == Key.Tab ? FocusNavigationDirection.Down : FocusNavigationDirection.Up) as UIElement : uiElement1.PredictFocus(key == Key.Down || key == Key.Tab ? FocusNavigationDirection.Down : FocusNavigationDirection.Up) as UIElement;
        if (uiElement2 != null)
        {
          if (this.Parent is ButtonDropDown)
            ((ButtonDropDown) this.Parent).ClearChildMouseHighlight();
          if (this.Parent is ApplicationMenu && (this.IsLastVisible((IList) ((ItemsControl) this.Parent).Items, (UIElement) this) || this.IsLastVisible((IList) ((ApplicationMenu) this.Parent).MruItems, (UIElement) this) || this.IsLastVisible((IList) ((ApplicationMenu) this.Parent).AppItems, (UIElement) this)))
          {
            flag = false;
          }
          else
          {
            uiElement2.Focus();
            flag = true;
          }
        }
      }
label_45:
      if (!flag)
        return;
      e.Handled = true;
    }
  }

  internal bool IsLastVisible(IList collection, UIElement element)
  {
    for (int index = collection.Count - 1; index >= 0; --index)
    {
      UIElement uiElement = collection[index] as UIElement;
      if (uiElement.Visibility == Visibility.Visible)
      {
        if (uiElement == element)
          return true;
        break;
      }
    }
    return false;
  }

  private UIElement FindNextItem(int startIndex, int direction)
  {
    if (direction != 0)
    {
      int index1 = startIndex;
      IList generatedItems = this.GetGeneratedItems();
      for (int index2 = 0; index2 < generatedItems.Count; ++index2)
      {
        index1 += direction;
        if (index1 >= generatedItems.Count)
          index1 = 0;
        else if (index1 < 0)
          index1 = generatedItems.Count - 1;
        if (generatedItems[index1] is UIElement nextItem && nextItem.IsEnabled && nextItem.Visibility == Visibility.Visible)
          return nextItem;
      }
    }
    return (UIElement) null;
  }

  private IList GetGeneratedItems()
  {
    if (this.ItemsSource == null || !this.HasItems)
      return (IList) this.Items;
    List<object> generatedItems = new List<object>();
    for (int index = 0; index < this.Items.Count; ++index)
      generatedItems.Add((object) this.ItemContainerGenerator.ContainerFromIndex(index));
    return (IList) generatedItems;
  }

  protected virtual void ClearChildMouseHighlight()
  {
    this.ClearChildMouseHighlight((IEnumerable) this.Items);
  }

  protected virtual void ClearChildMouseHighlight(IEnumerable col)
  {
    foreach (object obj in col)
    {
      if (obj is ButtonDropDown buttonDropDown && buttonDropDown.IsHighlighted)
        buttonDropDown.RemoveButtonHighlight();
    }
  }

  protected override void OnTextInput(TextCompositionEventArgs e)
  {
    base.OnTextInput(e);
    if (e.Handled || this.m_KeyTipsAdorner == null || !this.m_KeyTipsAdorner.ProcessTextInput(e))
      return;
    this.ShowKeyTips = false;
  }

  [DefaultValue("Button")]
  public string ColorClass
  {
    get => (string) this.GetValue(ButtonDropDown.ColorClassProperty);
    set => this.SetValue(ButtonDropDown.ColorClassProperty, (object) value);
  }

  [DefaultValue("")]
  public string OptionGroup
  {
    get => (string) this.GetValue(ButtonDropDown.OptionGroupProperty);
    set => this.SetValue(ButtonDropDown.OptionGroupProperty, (object) value);
  }

  public virtual ButtonDropDown Copy(bool deepCopy) => CloningMachine.Clone(this, deepCopy);

  [TypeConverter(typeof (CornerRadiusConverter))]
  [DefaultValue(2)]
  public CornerRadius CornerRadius
  {
    get => (CornerRadius) this.GetValue(ButtonDropDown.CornerRadiusProperty);
    set => this.SetValue(ButtonDropDown.CornerRadiusProperty, (object) value);
  }

  [Category("Action")]
  [Bindable(true)]
  [Localizability(LocalizationCategory.NeverLocalize)]
  public ICommand Command
  {
    get => (ICommand) this.GetValue(ButtonDropDown.CommandProperty);
    set => this.SetValue(ButtonDropDown.CommandProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Action")]
  [Localizability(LocalizationCategory.NeverLocalize)]
  public object CommandParameter
  {
    get => this.GetValue(ButtonDropDown.CommandParameterProperty);
    set => this.SetValue(ButtonDropDown.CommandParameterProperty, value);
  }

  [Bindable(true)]
  [Category("Action")]
  public IInputElement CommandTarget
  {
    get => (IInputElement) this.GetValue(ButtonDropDown.CommandTargetProperty);
    set => this.SetValue(ButtonDropDown.CommandTargetProperty, (object) value);
  }

  private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ButtonDropDown) d).OnCommandChanged((ICommand) e.OldValue, (ICommand) e.NewValue);
  }

  private void OnCommandChanged(ICommand oldCommand, ICommand newCommand)
  {
    if (oldCommand != null)
      this.RemoveCommand(oldCommand);
    if (newCommand == null)
      return;
    this.AddCommand(newCommand);
  }

  private void RemoveCommand(ICommand oldCommand)
  {
    if (oldCommand != null)
    {
      oldCommand.CanExecuteChanged -= this.m_CanExecuteEventHandler;
      this.m_CanExecuteEventHandler = (EventHandler) null;
    }
    this.UpdateCanExecute();
  }

  private void AddCommand(ICommand newCommand)
  {
    if (newCommand != null)
    {
      this.m_CanExecuteEventHandler = new EventHandler(this.CanExecuteChanged);
      newCommand.CanExecuteChanged += this.m_CanExecuteEventHandler;
    }
    this.UpdateCanExecute();
  }

  private void CanExecuteChanged(object sender, EventArgs e) => this.UpdateCanExecute();

  protected override bool IsEnabledCore => base.IsEnabledCore && this.CanExecute;

  private bool CanExecute
  {
    get => this.m_CanExecute;
    set
    {
      if (this.m_CanExecute == value)
        return;
      this.m_CanExecute = value;
      this.CoerceValue(UIElement.IsEnabledProperty);
    }
  }

  protected virtual void UpdateCanExecute()
  {
    if (this.Command != null)
    {
      ButtonDropDown buttonDropDown = ItemsControl.ItemsControlFromItemContainer((DependencyObject) this) as ButtonDropDown;
      if (!this.IsDesignMode && (buttonDropDown == null || buttonDropDown.IsPopupOpen))
      {
        object commandParameter = this.CommandParameter;
        IInputElement target = this.CommandTarget;
        if (!(this.Command is RoutedCommand command))
        {
          this.CanExecute = this.Command.CanExecute(commandParameter);
        }
        else
        {
          if (target == null)
            target = (IInputElement) this;
          this.CanExecute = command.CanExecute(commandParameter, target);
        }
      }
      else
        this.CanExecute = true;
      if (!(this.Command is IButtonDropDownCommandExtender downCommandExtender) && this.Command != null)
        downCommandExtender = RibbonCommandManager.GetExender(this.Command);
      if (downCommandExtender != null)
      {
        if (downCommandExtender.SyncHeader && downCommandExtender.Header != (string) this.Header)
          this.Header = (object) downCommandExtender.Header;
        if (downCommandExtender.SyncImageSource && downCommandExtender.ImageSource != null && (this.Image == null || !(this.Image is System.Windows.Controls.Image) || this.Image is System.Windows.Controls.Image && ((System.Windows.Controls.Image) this.Image).Source != downCommandExtender.ImageSource))
        {
          if (this.IsDesignMode)
          {
            if (this.Image == null && (this.Header == null || this.ImagePosition != eButtonImagePosition.Left))
              this.Image = this.GetDesignTimeImageRepresentation();
          }
          else
          {
            if (!(this.Image is System.Windows.Controls.Image image))
            {
              image = new System.Windows.Controls.Image();
              image.Stretch = Stretch.None;
            }
            image.Source = downCommandExtender.ImageSource;
            this.Image = (object) image;
          }
        }
        if (!this.IsDesignMode && downCommandExtender.SyncImageSmallSource && downCommandExtender.ImageSmallSource != null && (this.ImageSmall == null || !(this.ImageSmall is System.Windows.Controls.Image) || this.ImageSmall is System.Windows.Controls.Image && ((System.Windows.Controls.Image) this.ImageSmall).Source != downCommandExtender.ImageSmallSource))
        {
          if (!(this.ImageSmall is System.Windows.Controls.Image image))
          {
            image = new System.Windows.Controls.Image();
            image.Width = ButtonDropDown._FixedSmallImageSize.Width;
            image.Height = ButtonDropDown._FixedSmallImageSize.Height;
          }
          image.Source = downCommandExtender.ImageSmallSource;
          this.ImageSmall = (object) image;
        }
      }
      else if (this.IsDesignMode && this.Image == null && (this.Header == null || this.ImagePosition != eButtonImagePosition.Left))
        this.Image = this.GetDesignTimeImageRepresentation();
      if (!(this.CommandParameter is IButtonCommandParameter))
        return;
      IButtonCommandParameter cp = this.CommandParameter as IButtonCommandParameter;
      bool commandValueChanged = false;
      bool commandIsChedked = false;
      if (cp is DispatcherObject && !((DispatcherObject) cp).Dispatcher.CheckAccess())
      {
        ((DispatcherObject) cp).Dispatcher.BeginInvoke(DispatcherPriority.Normal, (Delegate) (o =>
        {
          commandValueChanged = cp.ValueChanged;
          commandIsChedked = cp.IsChecked;
        }), (object) null);
      }
      else
      {
        commandValueChanged = cp.ValueChanged;
        commandIsChedked = cp.IsChecked;
      }
      if (!commandValueChanged)
        return;
      this.IsChecked = commandIsChedked;
      cp.ValueChanged = false;
    }
    else
      this.CanExecute = true;
  }

  private object GetDesignTimeImageRepresentation()
  {
    Rectangle imageRepresentation = new Rectangle();
    imageRepresentation.Fill = (Brush) Brushes.CornflowerBlue;
    imageRepresentation.StrokeThickness = 1.0;
    imageRepresentation.Stroke = (Brush) Brushes.RoyalBlue;
    imageRepresentation.Width = 16.0;
    imageRepresentation.Height = 16.0;
    return (object) imageRepresentation;
  }

  private bool IsDesignMode => DesignerProperties.GetIsInDesignMode((DependencyObject) this);
}
