// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.BackstageTab
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfRibbon;

public class BackstageTab : TabItem
{
  public static readonly DependencyProperty PanelBackgroundProperty = DependencyProperty.Register(nameof (PanelBackground), typeof (eBackstagePanelBackgroundImage), typeof (BackstageTab), (PropertyMetadata) new UIPropertyMetadata((object) eBackstagePanelBackgroundImage.Blue, new PropertyChangedCallback(BackstageTab.OnPanelBackgroundChanged)));
  public static readonly DependencyProperty PanelBackgroundImageProperty = DependencyProperty.Register(nameof (PanelBackgroundImage), typeof (object), typeof (BackstageTab), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(BackstageTab.OnPanelBackgroundImageChanged)));
  private static readonly DependencyPropertyKey EffectiveBackgroundImagePropertyKey = DependencyProperty.RegisterReadOnly(nameof (EffectiveBackgroundImage), typeof (object), typeof (BackstageTab), (PropertyMetadata) new UIPropertyMetadata((object) null, new PropertyChangedCallback(BackstageTab.OnEffectiveBackgroundImageChanged), new CoerceValueCallback(BackstageTab.OnCoerceEffectiveBackgroundImage)));
  public static readonly DependencyProperty EffectiveBackgroundImageProperty = BackstageTab.EffectiveBackgroundImagePropertyKey.DependencyProperty;
  public static readonly DependencyProperty TabToolTipProperty = DependencyProperty.Register(nameof (TabToolTip), typeof (object), typeof (BackstageTab), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty TabContextMenuProperty = DependencyProperty.Register(nameof (TabContextMenu), typeof (ContextMenu), typeof (BackstageTab), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty InnerBorderBrushProperty = DependencyProperty.Register(nameof (InnerBorderBrush), typeof (Brush), typeof (BackstageTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsRender));
  public static readonly DependencyProperty InnerBorderThicknessProperty = DependencyProperty.Register(nameof (InnerBorderThickness), typeof (Thickness), typeof (BackstageTab), new PropertyMetadata((object) new Thickness()));

  private static void OnPanelBackgroundChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is BackstageTab backstageTab))
      return;
    backstageTab.OnPanelBackgroundChanged((eBackstagePanelBackgroundImage) e.OldValue, (eBackstagePanelBackgroundImage) e.NewValue);
  }

  protected virtual void OnPanelBackgroundChanged(
    eBackstagePanelBackgroundImage oldValue,
    eBackstagePanelBackgroundImage newValue)
  {
    this.CoerceValue(BackstageTab.EffectiveBackgroundImageProperty);
  }

  public eBackstagePanelBackgroundImage PanelBackground
  {
    get => (eBackstagePanelBackgroundImage) this.GetValue(BackstageTab.PanelBackgroundProperty);
    set => this.SetValue(BackstageTab.PanelBackgroundProperty, (object) value);
  }

  private static void OnPanelBackgroundImageChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is BackstageTab backstageTab))
      return;
    backstageTab.OnPanelBackgroundImageChanged(e.OldValue, e.NewValue);
  }

  protected virtual void OnPanelBackgroundImageChanged(object oldValue, object newValue)
  {
    this.CoerceValue(BackstageTab.EffectiveBackgroundImageProperty);
  }

  public object PanelBackgroundImage
  {
    get => this.GetValue(BackstageTab.PanelBackgroundImageProperty);
    set => this.SetValue(BackstageTab.PanelBackgroundImageProperty, value);
  }

  public object EffectiveBackgroundImage
  {
    get => this.GetValue(BackstageTab.EffectiveBackgroundImageProperty);
    internal set => this.SetValue(BackstageTab.EffectiveBackgroundImagePropertyKey, value);
  }

  private static void OnEffectiveBackgroundImageChanged(
    DependencyObject o,
    DependencyPropertyChangedEventArgs e)
  {
    if (!(o is BackstageTab backstageTab))
      return;
    backstageTab.OnEffectiveBackgroundImageChanged(e.OldValue, e.NewValue);
  }

  protected virtual void OnEffectiveBackgroundImageChanged(object oldValue, object newValue)
  {
  }

  private static object OnCoerceEffectiveBackgroundImage(DependencyObject o, object value)
  {
    return o is BackstageTab backstageTab ? backstageTab.OnCoerceEffectiveBackgroundImage(value) : value;
  }

  protected virtual object OnCoerceEffectiveBackgroundImage(object value)
  {
    if (this.PanelBackgroundImage != null)
      return this.PanelBackgroundImage;
    if (this.PanelBackground == eBackstagePanelBackgroundImage.Blue)
      return (object) this.CreateImageFromImageSource("themes/images/BlueBackstage.png");
    if (this.PanelBackground == eBackstagePanelBackgroundImage.Green)
      return (object) this.CreateImageFromImageSource("themes/images/GreenBackstage.png");
    if (this.PanelBackground == eBackstagePanelBackgroundImage.Magenta)
      return (object) this.CreateImageFromImageSource("themes/images/MagentaBackstage.png");
    return this.PanelBackground == eBackstagePanelBackgroundImage.Orange ? (object) this.CreateImageFromImageSource("themes/images/OrangeBackstage.png") : (object) null;
  }

  protected virtual Image CreateImageFromImageSource(string imageSource)
  {
    return new Image()
    {
      Source = (ImageSource) new BitmapImage(new Uri("pack://application:,,,/AcpWpfRibbon;component/" + imageSource, UriKind.RelativeOrAbsolute)),
      Stretch = Stretch.None
    };
  }

  public object TabToolTip
  {
    get => this.GetValue(BackstageTab.TabToolTipProperty);
    set => this.SetValue(BackstageTab.TabToolTipProperty, value);
  }

  public ContextMenu TabContextMenu
  {
    get => (ContextMenu) this.GetValue(BackstageTab.TabContextMenuProperty);
    set => this.SetValue(BackstageTab.TabContextMenuProperty, (object) value);
  }

  public Brush InnerBorderBrush
  {
    get => (Brush) this.GetValue(BackstageTab.InnerBorderBrushProperty);
    set => this.SetValue(BackstageTab.InnerBorderBrushProperty, (object) value);
  }

  public Thickness InnerBorderThickness
  {
    get => (Thickness) this.GetValue(BackstageTab.InnerBorderThicknessProperty);
    set => this.SetValue(BackstageTab.InnerBorderThicknessProperty, (object) value);
  }

  static BackstageTab()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (BackstageTab), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (BackstageTab)));
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.CoerceValue(BackstageTab.EffectiveBackgroundImageProperty);
    base.OnInitialized(e);
  }
}
