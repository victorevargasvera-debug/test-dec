// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Qat
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class Qat : BasePopupControl
{
  public static readonly DependencyProperty IsOverflowItemProperty;
  internal static readonly DependencyPropertyKey IsOverflowItemPropertyKey;
  public static readonly DependencyProperty HasOverflowItemsProperty;
  internal static readonly DependencyPropertyKey HasOverflowItemsPropertyKey;
  public static readonly DependencyProperty IsOverflowOpenProperty;
  public static readonly DependencyProperty IsAboveRibbonProperty;
  internal static readonly DependencyPropertyKey IsAboveRibbonPropertyKey;
  public static readonly DependencyProperty IsActiveProperty;
  public static readonly DependencyProperty IsGlassEnabledProperty;
  private const string OverflowButtonName = "PART_OverflowButton";
  private const string OverflowPanelName = "PART_OverflowPanel";
  private QatOverflowPanel m_OverflowPanel;

  static Qat()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Qat)));
    Qat.IsOverflowItemPropertyKey = DependencyProperty.RegisterAttachedReadOnly("IsOverflowItem", typeof (bool), typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    Qat.IsOverflowItemProperty = Qat.IsOverflowItemPropertyKey.DependencyProperty;
    Qat.HasOverflowItemsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasOverflowItems), typeof (bool), typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    Qat.HasOverflowItemsProperty = Qat.HasOverflowItemsPropertyKey.DependencyProperty;
    Qat.IsOverflowOpenProperty = DependencyProperty.Register(nameof (IsOverflowOpen), typeof (bool), typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(Qat.OnIsOverflowOpenChanged), new CoerceValueCallback(Qat.CoerceIsOverflowOpen)));
    Qat.IsAboveRibbonPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsAboveRibbon), typeof (bool), typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Qat.IsAboveRibbonProperty = Qat.IsAboveRibbonPropertyKey.DependencyProperty;
    Qat.IsActiveProperty = Ribbon.IsActiveProperty.AddOwner(typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.AffectsRender));
    Qat.IsGlassEnabledProperty = DependencyProperty.Register(nameof (IsGlassEnabled), typeof (bool), typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsRender));
    UIElement.FocusableProperty.OverrideMetadata(typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) true));
    Control.IsTabStopProperty.OverrideMetadata(typeof (Qat), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
  }

  public override void OnApplyTemplate()
  {
    this.m_OverflowPanel = this.GetTemplateChild("PART_OverflowPanel") as QatOverflowPanel;
    base.OnApplyTemplate();
  }

  internal static void SetIsOverflowItem(DependencyObject element, object value)
  {
    element.SetValue(Qat.IsOverflowItemPropertyKey, value);
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    if (e.NewItems != null)
    {
      foreach (object newItem in (IEnumerable) e.NewItems)
      {
        if (newItem is ButtonDropDown buttonDropDown)
          buttonDropDown.UseSmallImage = true;
      }
    }
    else if (e.Action == NotifyCollectionChangedAction.Reset)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is ButtonDropDown buttonDropDown)
          buttonDropDown.UseSmallImage = true;
      }
    }
    base.OnItemsChanged(e);
  }

  public static bool GetIsOverflowItem(DependencyObject element)
  {
    return element != null ? (bool) element.GetValue(Qat.IsOverflowItemProperty) : throw new ArgumentNullException("elem");
  }

  internal QatOverflowPanel OverflowPanel => this.m_OverflowPanel;

  [Browsable(false)]
  [DefaultValue(true)]
  public bool IsAboveRibbon
  {
    get => (bool) this.GetValue(Qat.IsAboveRibbonProperty);
    internal set => this.SetValue(Qat.IsAboveRibbonPropertyKey, (object) value);
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool HasOverflowItems
  {
    get => (bool) this.GetValue(Qat.HasOverflowItemsProperty);
    internal set => this.SetValue(Qat.HasOverflowItemsPropertyKey, (object) value);
  }

  [Bindable(true)]
  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsOverflowOpen
  {
    get => (bool) this.GetValue(Qat.IsOverflowOpenProperty);
    set => this.SetValue(Qat.IsOverflowOpenProperty, (object) value);
  }

  private void RegisterToOpenOnLoad() => this.Loaded += new RoutedEventHandler(this.OpenOnLoad);

  private void OpenOnLoad(object sender, RoutedEventArgs e)
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Delegate) new DispatcherOperationCallback(this.OpenPopupOnLoad), (object) null);
  }

  private object OpenPopupOnLoad(object arg)
  {
    this.CoerceValue(Qat.IsOverflowOpenProperty);
    return (object) null;
  }

  private static void OnIsOverflowOpenChanged(
    DependencyObject d,
    DependencyPropertyChangedEventArgs e)
  {
    Qat qat = (Qat) d;
    if ((bool) e.NewValue)
    {
      ((IPopupParentControl) qat).IsPopupMode = true;
      qat.FocusOverflowPanel();
    }
    else
      ((IPopupParentControl) qat).IsPopupMode = false;
  }

  private void FocusOverflowPanel()
  {
    this.Dispatcher.BeginInvoke(DispatcherPriority.Input, (Delegate) new DispatcherOperationCallback(this.FocusOverflowPanel), (object) null);
  }

  private object FocusOverflowPanel(object arg)
  {
    if (this.OverflowPanel != null)
      this.OverflowPanel.Focus();
    return (object) null;
  }

  private static object CoerceIsOverflowOpen(DependencyObject d, object value)
  {
    if ((bool) value)
    {
      Qat qat = (Qat) d;
      if (!qat.IsLoaded)
      {
        qat.RegisterToOpenOnLoad();
        return (object) false;
      }
    }
    return value;
  }

  protected internal override void OnInternalMenuModeChanged(EventArgs e)
  {
    if (((IPopupParentControl) this).IsPopupMode || !this.IsOverflowOpen)
      return;
    this.IsOverflowOpen = false;
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public bool IsActive
  {
    get => (bool) this.GetValue(Qat.IsActiveProperty);
    set => this.SetValue(Qat.IsActiveProperty, (object) value);
  }

  public bool IsGlassEnabled
  {
    get => (bool) this.GetValue(Qat.IsGlassEnabledProperty);
    set => this.SetValue(Qat.IsGlassEnabledProperty, (object) value);
  }
}
