// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonEx
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfRibbon;

public class ButtonEx : ButtonDropDown, IPopupParentControl
{
  public static readonly DependencyProperty IsCancelProperty;
  public static readonly DependencyProperty IsDefaultProperty;
  private ParentPopupControlImpl m_PopupHandler;

  static ButtonEx()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (ButtonEx), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (ButtonEx)));
    ButtonEx.IsDefaultProperty = DependencyProperty.Register(nameof (IsDefault), typeof (bool), typeof (ButtonEx), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(ButtonEx.OnIsDefaultChanged)));
    ButtonEx.IsCancelProperty = DependencyProperty.Register(nameof (IsCancel), typeof (bool), typeof (ButtonEx), (PropertyMetadata) new FrameworkPropertyMetadata((object) false, new PropertyChangedCallback(ButtonEx.OnIsCancelChanged)));
    EventManager.RegisterClassHandler(typeof (ButtonEx), ButtonDropDown.PreviewClickEvent, (Delegate) new RoutedEventHandler(ButtonEx.OnButtonDropDownPreviewClick));
    EventManager.RegisterClassHandler(typeof (ButtonEx), Mouse.MouseDownEvent, (Delegate) new MouseButtonEventHandler(ButtonEx.OnMouseButtonDown));
    EventManager.RegisterClassHandler(typeof (ButtonEx), Mouse.MouseUpEvent, (Delegate) new MouseButtonEventHandler(ButtonEx.OnMouseButtonUp));
    EventManager.RegisterClassHandler(typeof (ButtonEx), Mouse.LostMouseCaptureEvent, (Delegate) new MouseEventHandler(ButtonEx.OnLostMouseCapture));
    EventManager.RegisterClassHandler(typeof (ButtonEx), BasePopupControl.IsSelectedChangedEvent, (Delegate) new RoutedPropertyChangedEventHandler<bool>(ButtonEx.OnIsSelectedChanged));
    InputMethod.IsInputMethodSuspendedProperty.OverrideMetadata(typeof (ButtonEx), (PropertyMetadata) new FrameworkPropertyMetadata((object) true, FrameworkPropertyMetadataOptions.Inherits));
  }

  public ButtonEx()
  {
    this.m_PopupHandler = new ParentPopupControlImpl((FrameworkElement) this);
    this.m_PopupHandler.InternalMenuModeChanged += new EventHandler(this.PopupHandlerMenuModeChanged);
  }

  public bool IsCancel
  {
    get => (bool) this.GetValue(ButtonEx.IsCancelProperty);
    set => this.SetValue(ButtonEx.IsCancelProperty, (object) value);
  }

  public bool IsDefault
  {
    get => (bool) this.GetValue(ButtonEx.IsDefaultProperty);
    set => this.SetValue(ButtonEx.IsDefaultProperty, (object) value);
  }

  private static void OnIsDefaultChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonEx element = d as ButtonEx;
    if ((bool) e.NewValue)
      AccessKeyManager.Register("\r", (IInputElement) element);
    else
      AccessKeyManager.Unregister("\r", (IInputElement) element);
  }

  private static void OnIsCancelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
  {
    ButtonEx element = d as ButtonEx;
    if ((bool) e.NewValue)
      AccessKeyManager.Register("\u001B", (IInputElement) element);
    else
      AccessKeyManager.Unregister("\u001B", (IInputElement) element);
  }

  protected override void SetPopupMode(bool popupMode)
  {
    IPopupParentControl popupParentControl = (IPopupParentControl) this;
    if (popupParentControl.IsPopupMode == popupMode)
      return;
    popupParentControl.IsPopupMode = popupMode;
  }

  private void PopupHandlerMenuModeChanged(object sender, EventArgs e)
  {
    this.OnInternalMenuModeChanged(e);
  }

  protected override bool IsItemItsOwnContainerOverride(object item)
  {
    switch (item)
    {
      case ButtonDropDown _:
      case Separator _:
        return true;
      default:
        return false;
    }
  }

  protected override DependencyObject GetContainerForItemOverride()
  {
    return (DependencyObject) new ButtonDropDown();
  }

  private static void OnIsSelectedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
  {
    ((ButtonEx) sender)?.OnSelectedChanged(sender, e);
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
    ((ButtonEx) sender).InternalMouseButtonDown(e);
  }

  protected virtual void InternalMouseButtonDown(MouseButtonEventArgs e)
  {
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnMouseButtonUp(object sender, MouseButtonEventArgs e)
  {
    ((ButtonEx) sender).InternalMouseButtonUp(e);
  }

  protected virtual void InternalMouseButtonUp(MouseButtonEventArgs e)
  {
    if (e.OriginalSource is FrameworkElement originalSource && (originalSource == this || originalSource.TemplatedParent == this))
      return;
    this.m_PopupHandler.ClosePopupOnMouseEvent(e);
  }

  private static void OnLostMouseCapture(object sender, MouseEventArgs e)
  {
    ParentPopupControlImpl.OnLostMouseCapture(sender, e);
  }

  protected internal virtual void OnInternalMenuModeChanged(EventArgs e)
  {
    if (this.m_PopupHandler.IsPopupMode || !this.IsPopupOpen)
      return;
    this.IsPopupOpen = false;
  }

  bool IPopupParentControl.IsPopupMode
  {
    get => this.m_PopupHandler.IsPopupMode;
    set => this.m_PopupHandler.IsPopupMode = value;
  }

  internal ButtonDropDown CurrentSelection => this.m_PopupHandler.CurrentSelection;

  bool IPopupParentControl.QueryMouseCapturePopupClose(DependencyObject sourceObject) => true;

  protected override eButtonRenderingState GetBorderRenderState()
  {
    eButtonRenderingState borderRenderState = base.GetBorderRenderState();
    if (this.IsKeyboardFocusWithin && (borderRenderState == eButtonRenderingState.CheckedHover || borderRenderState == eButtonRenderingState.Hover))
    {
      Rect rect = new Rect(new System.Windows.Point(), this.RenderSize);
      if ((!this.IsMouseOver || !rect.Contains(Mouse.GetPosition((IInputElement) this))) && !this.IsHighlighted)
        borderRenderState = eButtonRenderingState.Normal;
    }
    return borderRenderState;
  }
}
