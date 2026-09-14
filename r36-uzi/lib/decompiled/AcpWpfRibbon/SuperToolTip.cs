// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.SuperToolTip
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[TemplatePart(Name = "PART_TooltipBorder", Type = typeof (Decorator))]
[DesignTimeVisible(false)]
public class SuperToolTip : System.Windows.Controls.ToolTip
{
  public static readonly DependencyProperty HeaderProperty;
  public static readonly DependencyProperty HeaderTemplateProperty;
  internal static readonly DependencyPropertyKey HasHeaderPropertyKey;
  public static readonly DependencyProperty HasHeaderProperty;
  public static readonly DependencyProperty HeaderTemplateSelectorProperty;
  public static readonly DependencyProperty FooterProperty;
  public static readonly DependencyProperty FooterTemplateProperty;
  internal static readonly DependencyPropertyKey HasFooterPropertyKey;
  public static readonly DependencyProperty FooterImageProperty;
  public static readonly DependencyProperty HasFooterProperty;
  public static readonly DependencyProperty FooterTemplateSelectorProperty;

  static SuperToolTip()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (SuperToolTip)));
    SuperToolTip.HeaderProperty = HeaderedContentControl.HeaderProperty.AddOwner(typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(SuperToolTip.OnHeaderChanged)));
    SuperToolTip.HeaderTemplateProperty = HeaderedContentControl.HeaderTemplateProperty.AddOwner(typeof (SuperToolTip));
    SuperToolTip.HasHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasHeader), typeof (bool), typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    SuperToolTip.HasHeaderProperty = SuperToolTip.HasHeaderPropertyKey.DependencyProperty;
    SuperToolTip.HeaderTemplateSelectorProperty = HeaderedContentControl.HeaderTemplateSelectorProperty.AddOwner(typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    SuperToolTip.FooterProperty = DependencyProperty.Register(nameof (Footer), typeof (object), typeof (SuperToolTip), new PropertyMetadata((object) null, new PropertyChangedCallback(SuperToolTip.OnFooterChanged)));
    SuperToolTip.FooterTemplateProperty = DependencyProperty.Register(nameof (FooterTemplate), typeof (DataTemplate), typeof (SuperToolTip), new PropertyMetadata((PropertyChangedCallback) null));
    SuperToolTip.HasFooterPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasFooter), typeof (bool), typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    SuperToolTip.HasFooterProperty = SuperToolTip.HasFooterPropertyKey.DependencyProperty;
    SuperToolTip.FooterTemplateSelectorProperty = DependencyProperty.Register(nameof (FooterTemplateSelector), typeof (DataTemplateSelector), typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    SuperToolTip.FooterImageProperty = DependencyProperty.Register(nameof (FooterImage), typeof (object), typeof (SuperToolTip), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure | FrameworkPropertyMetadataOptions.AffectsArrange | FrameworkPropertyMetadataOptions.AffectsRender));
  }

  [Category("Content")]
  [Bindable(true)]
  public object Header
  {
    get => this.GetValue(SuperToolTip.HeaderProperty);
    set => this.SetValue(SuperToolTip.HeaderProperty, value);
  }

  private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    SuperToolTip superToolTip = (SuperToolTip) d;
    superToolTip.SetValue(SuperToolTip.HasHeaderPropertyKey, (object) (e.NewValue != null));
    superToolTip.OnHeaderChanged(e.OldValue, e.NewValue);
  }

  protected virtual void OnHeaderChanged(object oldHeader, object newHeader)
  {
    if (oldHeader != null)
      this.RemoveLogicalChild(oldHeader);
    if (newHeader == null)
      return;
    this.AddLogicalChild(newHeader);
  }

  [Bindable(true)]
  public DataTemplate HeaderTemplate
  {
    get => (DataTemplate) this.GetValue(SuperToolTip.HeaderTemplateProperty);
    set => this.SetValue(SuperToolTip.HeaderTemplateProperty, (object) value);
  }

  [Bindable(true)]
  public DataTemplateSelector HeaderTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(SuperToolTip.HeaderTemplateSelectorProperty);
    set => this.SetValue(SuperToolTip.HeaderTemplateSelectorProperty, (object) value);
  }

  [Bindable(false)]
  [Browsable(false)]
  public bool HasHeader => (bool) this.GetValue(SuperToolTip.HasHeaderProperty);

  [Category("Content")]
  [Bindable(true)]
  [DefaultValue(null)]
  public object FooterImage
  {
    get => this.GetValue(SuperToolTip.FooterImageProperty);
    set => this.SetValue(SuperToolTip.FooterImageProperty, value);
  }

  [Category("Content")]
  [Bindable(true)]
  public object Footer
  {
    get => this.GetValue(SuperToolTip.FooterProperty);
    set => this.SetValue(SuperToolTip.FooterProperty, value);
  }

  private static void OnFooterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    SuperToolTip superToolTip = (SuperToolTip) d;
    superToolTip.SetValue(SuperToolTip.HasFooterPropertyKey, (object) (e.NewValue != null));
    superToolTip.OnFooterChanged(e.OldValue, e.NewValue);
  }

  protected virtual void OnFooterChanged(object oldFooter, object newFooter)
  {
    if (oldFooter != null)
      this.RemoveLogicalChild(oldFooter);
    if (newFooter == null)
      return;
    this.AddLogicalChild(newFooter);
  }

  [Bindable(true)]
  public DataTemplate FooterTemplate
  {
    get => (DataTemplate) this.GetValue(SuperToolTip.FooterTemplateProperty);
    set => this.SetValue(SuperToolTip.FooterTemplateProperty, (object) value);
  }

  [Bindable(true)]
  public DataTemplateSelector FooterTemplateSelector
  {
    get => (DataTemplateSelector) this.GetValue(SuperToolTip.HeaderTemplateSelectorProperty);
    set => this.SetValue(SuperToolTip.HeaderTemplateSelectorProperty, (object) value);
  }

  [Bindable(false)]
  [Browsable(false)]
  public bool HasFooter => (bool) this.GetValue(SuperToolTip.HasFooterProperty);
}
