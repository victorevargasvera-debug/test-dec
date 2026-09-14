// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ContextGroup
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class ContextGroup : ContentControl
{
  private ObservableCollection<RibbonTab> m_LinkedTabs;
  public static readonly DependencyProperty StockColorProperty;
  public static readonly DependencyProperty IsSimpleContentProperty;
  private static readonly DependencyPropertyKey IsSimpleContentPropertyKey;
  private const string LabelContentName = "PART_LabelContent";
  private Label m_ContentLabel;
  private bool m_IsGlassEnabled;

  static ContextGroup()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ContextGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ContextGroup)));
    ContextGroup.StockColorProperty = DependencyProperty.Register(nameof (StockColor), typeof (eContextGroupColor), typeof (ContextGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) eContextGroupColor.Orange, FrameworkPropertyMetadataOptions.AffectsRender, new PropertyChangedCallback(ContextGroup.OnStockColorChanged)));
    ContextGroup.IsSimpleContentPropertyKey = DependencyProperty.RegisterReadOnly(nameof (IsSimpleContent), typeof (bool), typeof (ContextGroup), (PropertyMetadata) new FrameworkPropertyMetadata((object) false));
    ContextGroup.IsSimpleContentProperty = ContextGroup.IsSimpleContentPropertyKey.DependencyProperty;
  }

  public ContextGroup() => this.m_LinkedTabs = new ObservableCollection<RibbonTab>();

  public override void OnApplyTemplate()
  {
    this.m_ContentLabel = this.GetTemplateChild("PART_LabelContent") as Label;
    this.UpdateLabelGlassEffect();
    base.OnApplyTemplate();
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public Visibility TabsVisibility
  {
    get
    {
      foreach (UIElement linkedTab in (Collection<RibbonTab>) this.m_LinkedTabs)
      {
        if (linkedTab.Visibility == Visibility.Visible)
          return Visibility.Visible;
      }
      return Visibility.Collapsed;
    }
    set
    {
      foreach (UIElement linkedTab in (Collection<RibbonTab>) this.m_LinkedTabs)
        linkedTab.Visibility = value;
    }
  }

  [Browsable(false)]
  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public ObservableCollection<RibbonTab> LinkedTabs => this.m_LinkedTabs;

  internal bool IsOneTabVisible
  {
    get
    {
      foreach (UIElement linkedTab in (Collection<RibbonTab>) this.m_LinkedTabs)
      {
        if (linkedTab.Visibility == Visibility.Visible)
          return true;
      }
      return false;
    }
  }

  private static void OnStockColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ((ContextGroup) d).OnStockColorChanged((eContextGroupColor) e.NewValue);
  }

  private void OnStockColorChanged(eContextGroupColor c) => this.ApplyNewStockColor(c);

  private void ApplyNewStockColor(eContextGroupColor c)
  {
    string str = RibbonColors.ContextGroupClass + c.ToString();
    this.SetResourceReference(Control.BackgroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + ContextGroupPartColorKeys.Background)));
    this.SetResourceReference(Control.BorderBrushProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + ContextGroupPartColorKeys.Border)));
    this.UpdateStockForegroundColor();
  }

  private void UpdateStockForegroundColor()
  {
    string str = RibbonColors.ContextGroupClass + this.StockColor.ToString();
    this.SetResourceReference(Control.ForegroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) (str + ContextGroupPartColorKeys.Foreground)));
  }

  [DefaultValue(eContextGroupColor.Orange)]
  public eContextGroupColor StockColor
  {
    get => (eContextGroupColor) this.GetValue(ContextGroup.StockColorProperty);
    set => this.SetValue(ContextGroup.StockColorProperty, (object) value);
  }

  protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
  {
    for (int index = this.LinkedTabs.Count - 1; index >= 0; --index)
    {
      RibbonTab linkedTab = this.LinkedTabs[index];
      if (linkedTab.Visibility == Visibility.Visible && !linkedTab.IsSelected)
        linkedTab.IsSelected = true;
    }
    base.OnMouseLeftButtonDown(e);
  }

  public bool IsSimpleContent
  {
    get => (bool) this.GetValue(ContextGroup.IsSimpleContentProperty);
    internal set => this.SetValue(ContextGroup.IsSimpleContentPropertyKey, (object) value);
  }

  protected override void OnContentChanged(object oldContent, object newContent)
  {
    if (newContent is string)
    {
      if (!this.IsSimpleContent)
        this.IsSimpleContent = true;
    }
    else if (this.IsSimpleContent)
      this.IsSimpleContent = false;
    base.OnContentChanged(oldContent, newContent);
  }

  internal Label ContentLabel => this.m_ContentLabel;

  internal bool IsGlassEnabled
  {
    get => this.m_IsGlassEnabled;
    set
    {
      if (this.m_IsGlassEnabled == value)
        return;
      this.m_IsGlassEnabled = value;
      this.UpdateLabelGlassEffect();
    }
  }

  private void UpdateLabelGlassEffect()
  {
    if (this.m_ContentLabel == null)
      return;
    if (this.IsGlassEnabled)
    {
      this.m_ContentLabel.Effect = (Effect) new DropShadowEffect()
      {
        ShadowDepth = 0.0,
        Color = Colors.White,
        BlurRadius = 9.0,
        Opacity = 1.0
      };
      this.m_ContentLabel.SetResourceReference(Control.ForegroundProperty, (object) new ComponentResourceKey(typeof (Ribbon), (object) SystemColors.ActiveCaptionBrushKey));
    }
    else
    {
      this.m_ContentLabel.Effect = (Effect) null;
      this.UpdateStockForegroundColor();
    }
  }
}
