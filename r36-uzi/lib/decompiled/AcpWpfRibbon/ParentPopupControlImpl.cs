// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ParentPopupControlImpl
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class ParentPopupControlImpl
{
  private FrameworkElement m_Parent;
  private ButtonDropDown m_CurrentSelection;
  private bool m_IsPopupMode;

  internal event EventHandler InternalMenuModeChanged;

  public ParentPopupControlImpl(FrameworkElement parent) => this.m_Parent = parent;

  public static void OnButtonDropDownPreviewClick(object sender, RoutedEventArgs e)
  {
    IPopupParentControl pc = (IPopupParentControl) sender;
    if (!(e.OriginalSource is ButtonDropDown originalSource) || originalSource.StaysOpenOnClick || pc == null || !pc.IsPopupMode)
      return;
    pc.IsPopupMode = false;
    if (ParentPopupControlImpl.IsOnPopup(pc as UIElement))
      return;
    e.Handled = true;
  }

  public void ClosePopupOnMouseEvent(MouseButtonEventArgs e)
  {
    if (e.Handled || e.ChangedButton != MouseButton.Left && e.ChangedButton != MouseButton.Right || !this.IsPopupMode)
      return;
    FrameworkElement originalSource = e.OriginalSource as FrameworkElement;
    FrameworkElement captureElement = this.CaptureElement;
    if (originalSource == null || originalSource != captureElement && originalSource.TemplatedParent != captureElement && !(originalSource.TemplatedParent is BasePopupControl))
      return;
    this.IsPopupMode = false;
    e.Handled = true;
  }

  public static void OnLostMouseCapture(object sender, MouseEventArgs e)
  {
    IPopupParentControl popupParentControl = sender as IPopupParentControl;
    if (Mouse.Captured == popupParentControl || Mouse.Captured is FrameworkElement && ((FrameworkElement) Mouse.Captured).TemplatedParent is ButtonDropDown && ((ButtonDropDown) ((FrameworkElement) Mouse.Captured).TemplatedParent).IsPopupOpen)
      return;
    if (!ParentPopupControlImpl.IsIgnoredCaptureType(Mouse.Captured) && Mouse.Captured is FrameworkElement)
    {
      ButtonDropDown buttonDropDown = ParentPopupControlImpl.FindButtonDropDown(Mouse.Captured as FrameworkElement);
      if (buttonDropDown != null && buttonDropDown.IsPopupOpen)
        return;
    }
    if (!popupParentControl.QueryMouseCapturePopupClose(Mouse.Captured as DependencyObject))
      return;
    if (e.OriginalSource == popupParentControl && (!(popupParentControl is Ribbon) || !((Ribbon) popupParentControl).IsRibbonMenuOpen))
    {
      if (Mouse.Captured != null && ParentPopupControlImpl.IsVisualDescendant(popupParentControl as DependencyObject, Mouse.Captured as DependencyObject) || Mouse.Captured is ContextMenu && ((FrameworkElement) Mouse.Captured).Name == Ribbon.SysQatCustomizeContextMenu)
        return;
      popupParentControl.IsPopupMode = false;
    }
    else if (ParentPopupControlImpl.IsVisualDescendant(popupParentControl as DependencyObject, e.OriginalSource as DependencyObject) || ParentPopupControlImpl.IsLogicalDescendant(popupParentControl as DependencyObject, e.OriginalSource as DependencyObject))
    {
      if (!popupParentControl.IsPopupMode || Mouse.Captured != null)
        return;
      Mouse.Capture(popupParentControl as IInputElement, CaptureMode.SubTree);
      e.Handled = true;
    }
    else if (Mouse.Captured == null && e.OriginalSource is FrameworkElement && ((FrameworkElement) e.OriginalSource).TemplatedParent is ButtonDropDown && ((ButtonDropDown) ((FrameworkElement) e.OriginalSource).TemplatedParent).IsPopupOpen)
    {
      BasePopupControl basePopupControl = ParentPopupControlImpl.GetBasePopupControl(((FrameworkElement) e.OriginalSource).TemplatedParent as FrameworkElement);
      if (basePopupControl != null)
        Mouse.Capture((IInputElement) basePopupControl, CaptureMode.SubTree);
      else
        popupParentControl.IsPopupMode = false;
    }
    else
    {
      ButtonDropDown buttonDropDown;
      if (Mouse.Captured == null && e.OriginalSource is FrameworkElement && (buttonDropDown = ParentPopupControlImpl.FindButtonDropDown(e.OriginalSource as FrameworkElement)) != null && buttonDropDown.IsPopupOpen)
      {
        BasePopupControl basePopupControl = ParentPopupControlImpl.GetBasePopupControl((FrameworkElement) buttonDropDown);
        if (basePopupControl != null)
          Mouse.Capture((IInputElement) basePopupControl, CaptureMode.SubTree);
        else
          popupParentControl.IsPopupMode = false;
      }
      else
      {
        if (popupParentControl is Ribbon && ((Ribbon) popupParentControl).IsRibbonMenuOpen && ParentPopupControlImpl.IsChildOf(((Selector) popupParentControl).SelectedItem as UIElement, Mouse.Captured as UIElement))
          return;
        popupParentControl.IsPopupMode = false;
      }
    }
  }

  private static bool IsIgnoredCaptureType(IInputElement o)
  {
    switch (o)
    {
      case BasePopupControl _:
      case ButtonDropDown _:
        return true;
      default:
        return false;
    }
  }

  private static BasePopupControl GetBasePopupControl(FrameworkElement elem)
  {
    for (; elem.Parent is FrameworkElement; elem = elem.Parent as FrameworkElement)
    {
      if (elem is BasePopupControl)
        return elem as BasePopupControl;
    }
    return (BasePopupControl) null;
  }

  private static ButtonDropDown FindButtonDropDown(FrameworkElement elem)
  {
    for (; elem.Parent is FrameworkElement; elem = elem.Parent as FrameworkElement)
    {
      if (elem.TemplatedParent is ButtonDropDown)
        return elem.TemplatedParent as ButtonDropDown;
    }
    while (elem != null)
    {
      elem = VisualTreeHelper.GetParent((DependencyObject) elem) as FrameworkElement;
      if (elem != null && elem.TemplatedParent is ButtonDropDown)
        return elem.TemplatedParent as ButtonDropDown;
      if (elem == null)
        break;
    }
    return (ButtonDropDown) null;
  }

  public void OnIsSelectedChanged(object sender, RoutedPropertyChangedEventArgs<bool> e)
  {
    if (!(e.OriginalSource is ButtonDropDown originalSource))
      return;
    if (e.NewValue)
    {
      if (this.CurrentSelection != originalSource && originalSource.GetPopupParent() == this.Parent)
      {
        bool flag = false;
        if (this.CurrentSelection != null)
        {
          flag = this.CurrentSelection.IsPopupOpen;
          this.CurrentSelection.IsPopupOpen = false;
        }
        this.CurrentSelection = originalSource;
        if (this.CurrentSelection != null & flag && this.CurrentSelection.IsPopupOpen != flag)
          this.CurrentSelection.IsPopupOpen = flag;
      }
    }
    else if (this.CurrentSelection == originalSource)
      this.CurrentSelection = (ButtonDropDown) null;
    e.Handled = true;
  }

  public UIElement Parent => (UIElement) this.m_Parent;

  public ButtonDropDown CurrentSelection
  {
    get => this.m_CurrentSelection;
    set
    {
      bool flag = false;
      if (this.m_CurrentSelection != null)
      {
        flag = this.m_CurrentSelection.IsKeyboardFocused;
        this.m_CurrentSelection.IsSelected = false;
      }
      this.m_CurrentSelection = value;
      if (this.m_CurrentSelection == null)
        return;
      this.m_CurrentSelection.IsSelected = true;
      if (!flag)
        return;
      this.m_CurrentSelection.Focus();
    }
  }

  private FrameworkElement CaptureElement => this.m_Parent;

  public bool IsPopupMode
  {
    get => this.m_IsPopupMode;
    set
    {
      if (this.m_IsPopupMode == value)
        return;
      this.m_IsPopupMode = value;
      if (this.m_IsPopupMode)
      {
        if (!ParentPopupControlImpl.IsVisualDescendant((DependencyObject) this.m_Parent, (DependencyObject) (Mouse.Captured as Visual)) && !ParentPopupControlImpl.IsOnPopup((UIElement) this.m_Parent) && !Mouse.Capture((IInputElement) this.CaptureElement, CaptureMode.SubTree))
          this.m_IsPopupMode = false;
        else
          this.OnInternalMenuModeChanged(EventArgs.Empty);
      }
      else
      {
        if (this.CurrentSelection != null)
        {
          this.CurrentSelection.IsPopupOpen = false;
          this.CurrentSelection = (ButtonDropDown) null;
        }
        this.OnInternalMenuModeChanged(EventArgs.Empty);
        ParentPopupControlImpl.SetSuspendPopupAnimation(this.m_Parent as ItemsControl, (ButtonDropDown) null, false);
        if (this.HasCapture)
          Mouse.Capture((IInputElement) null);
        this.RestorePreviousFocus();
      }
    }
  }

  private bool IsKeyboardFocusWithin
  {
    get
    {
      UIElement parent = (UIElement) this.m_Parent;
      return parent != null && parent.IsKeyboardFocusWithin;
    }
  }

  private void RestorePreviousFocus()
  {
    if (this.IsKeyboardFocusWithin)
      Keyboard.Focus((IInputElement) null);
    DependencyObject parent = this.m_Parent.Parent;
    if (parent == null)
      return;
    DependencyObject focusScope = FocusManager.GetFocusScope(parent);
    if (focusScope == null || !this.ContainsElement(FocusManager.GetFocusedElement(focusScope)))
      return;
    FocusManager.SetFocusedElement(focusScope, (IInputElement) null);
  }

  private bool ContainsElement(IInputElement element)
  {
    if (element == this.m_Parent)
      return true;
    DependencyObject container = element as DependencyObject;
    ButtonDropDown buttonDropDown = element as ButtonDropDown;
    while (container != null)
    {
      if (buttonDropDown != null)
        container = buttonDropDown.Parent;
      if (container == this.m_Parent)
        return true;
      if (container != null)
      {
        buttonDropDown = container as ButtonDropDown;
        if (ItemsControl.ItemsControlFromItemContainer(container) == this.m_Parent)
          return true;
        if (buttonDropDown == null)
          break;
      }
      else
        break;
    }
    return false;
  }

  internal static void SetSuspendPopupAnimation(
    ItemsControl itemsCont,
    ButtonDropDown ignore,
    bool suspend)
  {
    if (itemsCont == null)
      return;
    int count = itemsCont.Items.Count;
    for (int index = 0; index < count; ++index)
    {
      if (itemsCont.ItemContainerGenerator.ContainerFromIndex(index) is ButtonDropDown itemsCont1 && itemsCont1 != ignore && itemsCont1.IsPopupAnimationSuspended != suspend)
      {
        itemsCont1.IsPopupAnimationSuspended = suspend;
        if (!suspend)
          ParentPopupControlImpl.SetSuspendPopupAnimation((ItemsControl) itemsCont1, (ButtonDropDown) null, suspend);
      }
    }
  }

  public bool HasCapture => Mouse.Captured == this.CaptureElement;

  internal static bool IsLogicalDescendant(DependencyObject reference, DependencyObject node)
  {
    if (node == null || reference == null)
      return false;
    if (node == reference)
      return true;
    while (node != null)
    {
      node = LogicalTreeHelper.GetParent(node);
      if (node == reference)
        return true;
    }
    return false;
  }

  internal static bool IsVisualDescendant(DependencyObject reference, DependencyObject node)
  {
    if (node == reference)
      return true;
    do
    {
      switch (node)
      {
        case null:
          goto label_9;
        case Popup popup when popup.Parent != null:
          node = popup.Parent;
          break;
        case ContentControl _ when ((FrameworkElement) node).Name == "PART_PopupContent":
          node = LogicalTreeHelper.GetParent(node);
          switch (node)
          {
            case null:
            case Popup _:
              break;
            default:
              node = LogicalTreeHelper.GetParent(node);
              break;
          }
          break;
        default:
          node = ParentPopupControlImpl.FindParent(node);
          break;
      }
    }
    while (node != reference);
    return true;
label_9:
    return false;
  }

  private static DependencyObject FindParent(DependencyObject dpo)
  {
    ContentElement contentElement;
    switch (dpo)
    {
      case RibbonBar ribbonBar when ribbonBar.Parent != null:
        return ribbonBar.Parent;
      case RibbonTab ribbonTab when ribbonTab.Parent != null:
        return ribbonTab.Parent;
      case Visual reference1:
        contentElement = (ContentElement) null;
        break;
      default:
        contentElement = dpo as ContentElement;
        break;
    }
    ContentElement reference2 = contentElement;
    if (reference2 != null)
    {
      dpo = ContentOperations.GetParent(reference2);
      if (dpo != null)
        return dpo;
      if (reference2 is FrameworkContentElement frameworkContentElement)
        return frameworkContentElement.Parent;
    }
    else if (reference1 != null)
      return VisualTreeHelper.GetParent((DependencyObject) reference1);
    return (DependencyObject) null;
  }

  internal static bool IsChildOf(UIElement parent, UIElement pc)
  {
    if (pc == null)
      return false;
    for (FrameworkElement parent1 = VisualTreeHelper.GetParent((DependencyObject) pc) as FrameworkElement; parent1 != null && parent1 != null; parent1 = VisualTreeHelper.GetParent((DependencyObject) parent1) as FrameworkElement)
    {
      if (parent1 == parent)
        return true;
    }
    for (FrameworkElement parent2 = VisualTreeHelper.GetParent((DependencyObject) pc) as FrameworkElement; parent2 != null && parent2 != null; parent2 = LogicalTreeHelper.GetParent((DependencyObject) parent2) as FrameworkElement)
    {
      if (parent2 == parent)
        return true;
    }
    return false;
  }

  internal static bool IsOnPopup(UIElement pc)
  {
    if (pc == null)
      return false;
    for (FrameworkElement parent = VisualTreeHelper.GetParent((DependencyObject) pc) as FrameworkElement; parent != null; parent = parent.Parent as FrameworkElement)
    {
      if (parent is Popup || parent.Parent is Popup)
        return true;
    }
    return false;
  }

  private void OnInternalMenuModeChanged(EventArgs e)
  {
    if (this.InternalMenuModeChanged == null)
      return;
    this.InternalMenuModeChanged((object) this, e);
  }

  internal void OnTooltipOpening(ToolTipEventArgs e)
  {
    if (this.CurrentSelection == null || ParentPopupControlImpl.IsVisualDescendant(e.OriginalSource as DependencyObject, (DependencyObject) this.CurrentSelection) && (e.OriginalSource != this.CurrentSelection || !this.CurrentSelection.IsPopupOpen))
      return;
    e.Handled = true;
  }
}
