// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.Backstage
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

public class Backstage : TabControl
{
  public static readonly DependencyProperty ContentBackgroundProperty = DependencyProperty.Register(nameof (ContentBackground), typeof (Brush), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty ContentBorderBrushProperty = DependencyProperty.Register(nameof (ContentBorderBrush), typeof (Brush), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty ContentInnerBorderBrushProperty = DependencyProperty.Register(nameof (ContentInnerBorderBrush), typeof (Brush), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  public static readonly DependencyProperty ContentBorderThicknessProperty = DependencyProperty.Register(nameof (ContentBorderThickness), typeof (Thickness), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((object) new Thickness()));
  public static readonly DependencyProperty TabStripMinWidthProperty = DependencyProperty.Register(nameof (TabStripMinWidth), typeof (double), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((object) 120.0));
  public static readonly DependencyProperty SelectedPanelEffectiveBackgroundImageProperty = DependencyProperty.Register(nameof (SelectedPanelEffectiveBackgroundImage), typeof (object), typeof (Backstage), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  private static ComponentResourceKey _BackstageButtonStyleKey = new ComponentResourceKey(typeof (Backstage), (object) "Button");
  private static ComponentResourceKey _BackstageButtonDropDownStyleKey = new ComponentResourceKey(typeof (Backstage), (object) "ButtonDropDown");
  private ApplicationMenu _ApplicationMenu;

  public Brush ContentBackground
  {
    get => (Brush) this.GetValue(Backstage.ContentBackgroundProperty);
    set => this.SetValue(Backstage.ContentBackgroundProperty, (object) value);
  }

  public Brush ContentBorderBrush
  {
    get => (Brush) this.GetValue(Backstage.ContentBorderBrushProperty);
    set => this.SetValue(Backstage.ContentBorderBrushProperty, (object) value);
  }

  public Brush ContentInnerBorderBrush
  {
    get => (Brush) this.GetValue(Backstage.ContentInnerBorderBrushProperty);
    set => this.SetValue(Backstage.ContentInnerBorderBrushProperty, (object) value);
  }

  public Thickness ContentBorderThickness
  {
    get => (Thickness) this.GetValue(Backstage.ContentBorderThicknessProperty);
    set => this.SetValue(Backstage.ContentBorderThicknessProperty, (object) value);
  }

  public double TabStripMinWidth
  {
    get => (double) this.GetValue(Backstage.TabStripMinWidthProperty);
    set => this.SetValue(Backstage.TabStripMinWidthProperty, (object) value);
  }

  public object SelectedPanelEffectiveBackgroundImage
  {
    get => this.GetValue(Backstage.SelectedPanelEffectiveBackgroundImageProperty);
    set => this.SetValue(Backstage.SelectedPanelEffectiveBackgroundImageProperty, value);
  }

  static Backstage()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (Backstage), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (Backstage)));
  }

  protected override bool IsItemItsOwnContainerOverride(object item) => true;

  protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
  {
    base.PrepareContainerForItemOverride(element, item);
    if (!(element is FrameworkElement targetObject))
      return;
    Type type = targetObject.GetType();
    ResourceKey name = (ResourceKey) null;
    if (type == typeof (Button))
      name = Backstage.ButtonStyleKey;
    else if (type == typeof (ButtonDropDown))
      name = Backstage.ButtonDropDownStyleKey;
    if (name == null || !this.IsDefaultStyle((DependencyObject) targetObject, FrameworkElement.StyleProperty))
      return;
    targetObject.SetResourceReference(FrameworkElement.StyleProperty, (object) name);
  }

  private bool IsDefaultStyle(DependencyObject targetObject, DependencyProperty dp)
  {
    return DependencyPropertyHelper.GetValueSource(targetObject, dp).BaseValueSource <= BaseValueSource.ImplicitStyleReference;
  }

  public static ResourceKey ButtonStyleKey => (ResourceKey) Backstage._BackstageButtonStyleKey;

  public static ResourceKey ButtonDropDownStyleKey
  {
    get => (ResourceKey) Backstage._BackstageButtonDropDownStyleKey;
  }

  private int FindNextTabItemIndex(int startIndex, int direction)
  {
    if (direction != 0)
    {
      int index1 = startIndex;
      for (int index2 = 0; index2 < this.Items.Count; ++index2)
      {
        index1 += direction;
        if (index1 >= this.Items.Count)
          index1 = 0;
        else if (index1 < 0)
          index1 = this.Items.Count - 1;
        if (this.ItemContainerGenerator.ContainerFromIndex(index1) is TabItem tabItem && tabItem.IsEnabled && tabItem.Visibility == Visibility.Visible)
          return index1;
      }
    }
    return -1;
  }

  protected override void OnInitialized(EventArgs e)
  {
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
    base.OnInitialized(e);
  }

  protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
  {
    if (this.Items.Count > 0 && this.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
      this.EnsureSelectedTab();
    bool flag = this.ItemsSource != null;
    if (e.Action == NotifyCollectionChangedAction.Reset && flag)
    {
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is FrameworkElement child)
          this.AddLogicalChild((object) child);
      }
    }
    if (e.NewItems != null && flag)
    {
      foreach (object newItem in (IEnumerable) e.NewItems)
      {
        if (newItem is FrameworkElement child)
          this.AddLogicalChild((object) child);
      }
    }
    if (e.OldItems != null && flag)
    {
      foreach (object oldItem in (IEnumerable) e.OldItems)
      {
        if (oldItem is FrameworkElement child)
          this.RemoveLogicalChild((object) child);
      }
    }
    base.OnItemsChanged(e);
  }

  protected override IEnumerator LogicalChildren
  {
    get
    {
      if (this.ItemsSource == null)
        return base.LogicalChildren;
      List<object> objectList = new List<object>();
      foreach (object obj in (IEnumerable) this.Items)
      {
        if (obj is FrameworkElement)
          objectList.Add(obj);
      }
      return (IEnumerator) objectList.GetEnumerator();
    }
  }

  private void EnsureSelectedTab()
  {
    int num = -1;
    if (this.SelectedIndex == -1)
      num = this.FindNextTabItemIndex(-1, 1);
    else if (!(this.ItemContainerGenerator.ContainerFromIndex(this.SelectedIndex) is TabItem))
      num = this.FindNextTabItemIndex(this.SelectedIndex, 1);
    if (num < 0)
      return;
    this.SelectedIndex = num;
  }

  private void OnGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    this.EnsureSelectedTab();
  }

  protected override void OnSelectionChanged(SelectionChangedEventArgs e)
  {
    if (this.SelectedIndex == -1)
      this.ClearValue(Backstage.SelectedPanelEffectiveBackgroundImageProperty);
    else if (!(this.ItemContainerGenerator.ContainerFromIndex(this.SelectedIndex) is BackstageTab backstageTab))
      this.ClearValue(Backstage.SelectedPanelEffectiveBackgroundImageProperty);
    else
      this.SetBinding(Backstage.SelectedPanelEffectiveBackgroundImageProperty, (BindingBase) new Binding("EffectiveBackgroundImage")
      {
        Source = (object) backstageTab,
        Mode = BindingMode.OneWay
      });
    base.OnSelectionChanged(e);
  }

  internal ApplicationMenu ApplicationMenu
  {
    get => this._ApplicationMenu;
    set => this._ApplicationMenu = value;
  }
}
