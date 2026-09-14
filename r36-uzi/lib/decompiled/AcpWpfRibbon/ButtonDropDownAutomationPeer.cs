// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonDropDownAutomationPeer
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;

#nullable disable
namespace DevComponents.WpfRibbon;

public class ButtonDropDownAutomationPeer(ButtonDropDown owner) : 
  FrameworkElementAutomationPeer((FrameworkElement) owner),
  IExpandCollapseProvider,
  IInvokeProvider,
  IToggleProvider
{
  void IExpandCollapseProvider.Collapse()
  {
    if (!this.IsEnabled())
      throw new ElementNotEnabledException();
    ButtonDropDown owner = (ButtonDropDown) this.Owner;
    if (!owner.HasItems)
      throw new InvalidOperationException("Operation cannot be performed");
    owner.IsPopupOpen = false;
  }

  protected override AutomationControlType GetAutomationControlTypeCore()
  {
    return AutomationControlType.Button;
  }

  void IExpandCollapseProvider.Expand()
  {
    if (!this.IsEnabled())
      throw new ElementNotEnabledException();
    ButtonDropDown owner = (ButtonDropDown) this.Owner;
    if (!owner.HasItems)
      throw new InvalidOperationException("Operation cannot be performed");
    owner.OpenPopup();
  }

  ExpandCollapseState IExpandCollapseProvider.ExpandCollapseState
  {
    get
    {
      ExpandCollapseState expandCollapseState = ExpandCollapseState.Collapsed;
      ButtonDropDown owner = (ButtonDropDown) this.Owner;
      if (!owner.HasItems)
        return ExpandCollapseState.LeafNode;
      if (owner.IsPopupOpen)
        expandCollapseState = ExpandCollapseState.Expanded;
      return expandCollapseState;
    }
  }

  void IInvokeProvider.Invoke()
  {
    if (!this.IsEnabled())
      throw new ElementNotEnabledException();
    ButtonDropDown owner = (ButtonDropDown) this.Owner;
    if (owner.Role == eButtonRole.SplitButton || owner.Role == eButtonRole.MenuItem && !owner.HasItems)
      owner.InternalOnClick(false);
    else
      owner.ClickHeader();
  }

  void IToggleProvider.Toggle()
  {
    if (!this.IsEnabled())
      throw new ElementNotEnabledException();
    ButtonDropDown owner = (ButtonDropDown) this.Owner;
    if (!owner.IsCheckable)
      throw new InvalidOperationException("Operation cannot be performed.");
    owner.IsChecked = !owner.IsChecked;
  }

  ToggleState IToggleProvider.ToggleState
  {
    get => !((ButtonDropDown) this.Owner).IsChecked ? ToggleState.Off : ToggleState.On;
  }

  internal void RaiseExpandCollapseAutomationEvent(bool oldValue, bool newValue)
  {
    this.RaisePropertyChangedEvent(ExpandCollapsePatternIdentifiers.ExpandCollapseStateProperty, (object) (ExpandCollapseState) (oldValue ? 1 : 0), (object) (ExpandCollapseState) (newValue ? 1 : 0));
  }
}
