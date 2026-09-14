// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.HeaderedPopupControl
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class HeaderedPopupControl : BasePopupControl
{
  public static readonly DependencyProperty HeaderProperty = HeaderedContentControl.HeaderProperty.AddOwner(typeof (HeaderedPopupControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, new PropertyChangedCallback(HeaderedPopupControl.OnHeaderChanged)));
  public static readonly DependencyProperty HeaderTemplateProperty = HeaderedContentControl.HeaderTemplateProperty.AddOwner(typeof (HeaderedPopupControl));
  internal static readonly DependencyPropertyKey HasHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof (HasHeader), typeof (bool), typeof (HeaderedPopupControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
  public static readonly DependencyProperty HasHeaderProperty = HeaderedPopupControl.HasHeaderPropertyKey.DependencyProperty;
  public static readonly DependencyProperty HeaderTemplateSelectorProperty = HeaderedContentControl.HeaderTemplateSelectorProperty.AddOwner(typeof (HeaderedPopupControl), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));

  [Category("Content")]
  [Bindable(true)]
  public object Header
  {
    get => this.GetValue(HeaderedPopupControl.HeaderProperty);
    set => this.SetValue(HeaderedPopupControl.HeaderProperty, value);
  }

  private static void OnHeaderChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    HeaderedPopupControl headeredPopupControl = (HeaderedPopupControl) d;
    headeredPopupControl.SetValue(HeaderedPopupControl.HasHeaderPropertyKey, (object) (e.NewValue != null));
    headeredPopupControl.OnHeaderChanged(e.OldValue, e.NewValue);
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
  [DefaultValue(null)]
  public DataTemplate HeaderTemplate
  {
    get => (DataTemplate) this.GetValue(HeaderedPopupControl.HeaderTemplateProperty);
    set => this.SetValue(HeaderedPopupControl.HeaderTemplateProperty, (object) value);
  }

  [Bindable(true)]
  [DefaultValue(null)]
  public DataTemplateSelector HeaderTemplateSelector
  {
    get
    {
      return (DataTemplateSelector) this.GetValue(HeaderedPopupControl.HeaderTemplateSelectorProperty);
    }
    set => this.SetValue(HeaderedPopupControl.HeaderTemplateSelectorProperty, (object) value);
  }

  [Bindable(false)]
  [Browsable(false)]
  public bool HasHeader => (bool) this.GetValue(HeaderedPopupControl.HasHeaderProperty);
}
