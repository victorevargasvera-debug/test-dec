// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.BasePopupControl
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

[DesignTimeVisible(false)]
public class BasePopupControl : ItemsControl, IPopupParentControl
{
  private ParentPopupControlImpl m_PopupHandler;
  internal static readonly RoutedEvent IsSelectedChangedEvent = EventManager.RegisterRoutedEvent("IsSelectedChanged", RoutingStrategy.Bubble, typeof (RoutedPropertyChangedEventHandler<bool>), typeof (BasePopupControl));

  static BasePopupControl()
  {
    EventManager.RegisterClassHandler(typeof (BasePopupControl), ButtonDropDown.PreviewClickEvent, (Delegate) new RoutedEventHandler(BasePopupControl.OnButtonDropDownPreviewClick));
    EventManager.RegisterClassHandler(typeof (BasePopupControl), Mouse.MouseDownEvent, (Delegate) new MouseButtonEventHandler(BasePopupControl.OnMouseButtonDown));
    EventManager.RegisterClassHandler(typeof (BasePopupControl), Mouse.MouseUpEvent, (Delegate) new MouseButtonEventHandler(BasePopupControl.OnMouseButtonUp));
    EventManager.RegisterClassHandler(typeof (BasePopupControl), Mouse.LostMouseCaptureEvent, (Delegate) new MouseEventHandler(BasePopupControl.OnLostMouseCapture));
    EventManager.RegisterClassHandler(typeof (BasePopupControl), BasePopupControl.IsSelectedChangedEvent, (Delegate) new RoutedPropertyChangedEventHandler<bool>(BasePopupControl.OnIsSelectedChanged));
    InputMethod.IsInputMethodSuspendedProperty.OverrideMetadata(typeof (BasePopupControl), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.Inherits));
  }

  public BasePopupControl()
  {
    this.m_PopupHandler = new ParentPopupControlImpl((FrameworkElement) this);
    this.m_PopupHandler.InternalMenuModeChanged += new EventHandler(this.PopupHandlerMenuModeChanged);
  }

  private void PopupHandlerMenuModeChanged(object sender, EventArgs e)
  {
    this.OnInternalMenuModeChanged(e);
  }

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new ButtonDropDown();
  }

  private static void OnIsSelectedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
  {
    ((BasePopupControl) sender)?.OnSelectedChanged(sender, e);
  }

  private void OnSelectedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
  {
    this.m_PopupHandler.OnIsSelectedChanged(sender, e);
  }

  private static void OnButtonDropDownPreviewClick(object sender, RoutedEventArgs e)
  {
    ParentPopupControlImpl.OnButtonDropDownPreviewClick(sender, e);
  }

  private static void OnMouseButtonDown(object sender, MouseButtonEventArgs e)
  {
    ((BasePopupControl) sender).InternalMouseButtonDown(e);
  }

  protected virtual void InternalMouseButtonDown(MouseButtonEventArgs e)
  {
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnMouseButtonUp(object sender, MouseButtonEventArgs e)
  {
    ((BasePopupControl) sender).InternalMouseButtonUp(e);
  }

  protected virtual void InternalMouseButtonUp(MouseButtonEventArgs e)
  {
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnLostMouseCapture(object sender, MouseEventArgs e)
  {
    ParentPopupControlImpl.OnLostMouseCapture(sender, e);
  }

  protected internal virtual void OnInternalMenuModeChanged(EventArgs e)
  {
  }

  bool IPopupParentControl.IsPopupMode
  {
    get => this.m_PopupHandler.IsPopupMode;
    set => this.m_PopupHandler.IsPopupMode = value;
  }

  internal ButtonDropDown CurrentSelection => this.m_PopupHandler.CurrentSelection;

  bool IPopupParentControl.QueryMouseCapturePopupClose(DependencyObject sourceObject) => true;
}
