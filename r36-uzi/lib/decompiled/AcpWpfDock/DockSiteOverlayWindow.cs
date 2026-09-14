// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockSiteOverlayWindow
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using DevComponents.WpfDock.Primitives;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfDock;

internal class DockSiteOverlayWindow : EmptyWindow
{
  static DockSiteOverlayWindow()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockSiteOverlayWindow), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockSiteOverlayWindow)));
  }

  internal AdornerLayer GetAdornerLayer()
  {
    return this.GetTemplateChild("PART_ContentPresenter") is Visual templateChild ? AdornerLayer.GetAdornerLayer(templateChild) : (AdornerLayer) null;
  }

  internal UIElement GetElementToAdorn()
  {
    return this.GetTemplateChild("PART_ContentPresenter") as UIElement;
  }
}
