// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockWindowInfo
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfDock;

[DesignTimeVisible(false)]
public class DockWindowInfo : Control
{
  public static readonly DependencyProperty ImageProperty;
  public static readonly DependencyProperty HeaderProperty;
  public static readonly DependencyProperty DescriptionProperty;
  public static readonly DependencyProperty DockWindowProperty;
  public static readonly DependencyProperty IsSelectedProperty;

  static DockWindowInfo()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockWindowInfo)));
    DockWindowInfo.IsSelectedProperty = Selector.IsSelectedProperty.AddOwner(typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, FrameworkPropertyMetadataOptions.AffectsParentMeasure | FrameworkPropertyMetadataOptions.AffectsRender | FrameworkPropertyMetadataOptions.BindsTwoWayByDefault | FrameworkPropertyMetadataOptions.Journal));
    DockWindowInfo.ImageProperty = DependencyProperty.Register(nameof (Image), typeof (object), typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    DockWindowInfo.HeaderProperty = DependencyProperty.Register(nameof (Header), typeof (object), typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((object) null, FrameworkPropertyMetadataOptions.AffectsMeasure));
    DockWindowInfo.DescriptionProperty = DependencyProperty.Register(nameof (Description), typeof (string), typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    DockWindowInfo.DockWindowProperty = DependencyProperty.Register(nameof (DockWindow), typeof (DockWindow), typeof (DockWindowInfo), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public object Image
  {
    get => this.GetValue(DockWindowInfo.ImageProperty);
    set => this.SetValue(DockWindowInfo.ImageProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue("")]
  public string Description
  {
    get => (string) this.GetValue(DockWindowInfo.DescriptionProperty);
    set => this.SetValue(DockWindowInfo.DescriptionProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public object Header
  {
    get => this.GetValue(DockWindowInfo.HeaderProperty);
    set => this.SetValue(DockWindowInfo.HeaderProperty, value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public DockWindow DockWindow
  {
    get => (DockWindow) this.GetValue(DockWindowInfo.DockWindowProperty);
    set => this.SetValue(DockWindowInfo.DockWindowProperty, (object) value);
  }

  [Category("Appearance")]
  [Bindable(true)]
  public bool IsSelected
  {
    get => (bool) this.GetValue(DockWindowInfo.IsSelectedProperty);
    set => this.SetValue(DockWindowInfo.IsSelectedProperty, (object) value);
  }

  protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
  {
    if (this.Parent is DockWindowSelector parent1)
    {
      if (DockSite.GetIsDocument((UIElement) this.DockWindow))
        this.IsSelected = true;
      else
        parent1.SelectedToolWindow = this;
      if (parent1.Parent is DockSelectorAdorner parent && parent.RealAdornedElement is DockSite realAdornedElement)
        realAdornedElement.ReleaseDockSelectorAdorner(true);
    }
    base.OnMouseLeftButtonUp(e);
  }

  public static DockWindowInfo FromDockWindow(DockWindow dw)
  {
    DockWindowInfo dockWindowInfo = new DockWindowInfo();
    if (dw.Image == null)
    {
      string str = "images/ToolWindowImage16.png";
      if (DockSite.GetIsDocument((UIElement) dw))
        str = "images/DocumentImage16.png";
      BitmapImage bitmapImage = new BitmapImage(new Uri("pack://application:,,,/AcpWpfDock;component/" + str, UriKind.RelativeOrAbsolute));
      dockWindowInfo.Image = (object) new System.Windows.Controls.Image()
      {
        Source = (ImageSource) bitmapImage,
        Stretch = Stretch.None
      };
    }
    else
      dockWindowInfo.Image = DockWindowGroup.XamlClone(dw.Image);
    dockWindowInfo.Header = DockWindowGroup.XamlClone(dw.Header);
    dockWindowInfo.Description = dw.Description;
    dockWindowInfo.DockWindow = dw;
    return dockWindowInfo;
  }
}
