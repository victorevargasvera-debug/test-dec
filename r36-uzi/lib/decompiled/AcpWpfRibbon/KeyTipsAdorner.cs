// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.KeyTipsAdorner
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using DevComponents.WpfRibbon.KeyTips;
using System;
using System.Collections.Generic;
using System.Media;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

#nullable disable
namespace DevComponents.WpfRibbon;

internal class KeyTipsAdorner : Adorner
{
  private Control m_RootControl;
  private string m_KeyTipsStack = "";
  private object m_ContextObject;
  private List<UIElement> m_ActiveKeyTipElements = new List<UIElement>(50);

  public KeyTipsAdorner(UIElement elem)
    : base(elem)
  {
    this.m_RootControl = elem as Control;
  }

  protected override void OnRender(DrawingContext drawingContext)
  {
    KeyTipColors enabledColors = this.GetEnabledColors();
    KeyTipColors disabledColors = this.GetDisabledColors();
    this.m_ActiveKeyTipElements.Clear();
    KeyTipRenderInfo info = new KeyTipRenderInfo();
    info.EnabledColors = enabledColors;
    info.DisabledColors = disabledColors;
    if (this.m_RootControl != null)
    {
      info.Typeface = new Typeface(this.m_RootControl.FontFamily, this.m_RootControl.FontStyle, this.m_RootControl.FontWeight, this.m_RootControl.FontStretch);
      info.FontSize = this.m_RootControl.FontSize;
    }
    else if (this.m_ContextObject is Control)
    {
      Control contextObject = this.m_ContextObject as Control;
      info.Typeface = new Typeface(contextObject.FontFamily, contextObject.FontStyle, contextObject.FontWeight, contextObject.FontStretch);
      info.FontSize = contextObject.FontSize;
    }
    else
    {
      info.Typeface = new Typeface("Arial");
      info.FontSize = 8.25;
    }
    info.KeyTipsStack = this.KeyTipsStack;
    info.Adorner = this;
    if (this.m_RootControl is Ribbon)
    {
      info.UseSpecKeyTipPositioning = ((Ribbon) this.m_RootControl).UseSpecKeyTipPositioning;
      info.RibbonMenuMode = ((Ribbon) this.m_RootControl).IsRibbonMenuOpen && this.m_ContextObject is RibbonTab;
    }
    info.ActiveKeyTipsElements = this.m_ActiveKeyTipElements;
    object obj = (object) this.m_RootControl;
    if (this.m_ContextObject != null)
      obj = this.m_ContextObject;
    KeyTipRenderFactory.GetRenderer(obj)?.Render(drawingContext, obj, info);
  }

  protected override HitTestResult HitTestCore(PointHitTestParameters hitTestParameters)
  {
    return (HitTestResult) null;
  }

  private KeyTipColors GetDisabledColors()
  {
    KeyTipColors disabledColors = new KeyTipColors();
    disabledColors.Background = this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsDisabledBackground)) as Brush;
    if (this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsDisabledBorder)) is Brush resource)
    {
      disabledColors.Border = new Pen(resource, 1.0);
      disabledColors.Border.Freeze();
    }
    disabledColors.Foreground = this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsDisabledForeground)) as Brush;
    return disabledColors;
  }

  private KeyTipColors GetEnabledColors()
  {
    KeyTipColors enabledColors = new KeyTipColors();
    enabledColors.Background = this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsEnabledBackground)) as Brush;
    if (this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsEnabledBorder)) is Brush resource)
    {
      enabledColors.Border = new Pen(resource, 1.0);
      enabledColors.Border.Freeze();
    }
    enabledColors.Foreground = this.FindResource((object) new ComponentResourceKey(typeof (Ribbon), (object) RibbonColors.KeyTipsEnabledForeground)) as Brush;
    return enabledColors;
  }

  public string KeyTipsStack
  {
    get => this.m_KeyTipsStack;
    set
    {
      if (value == null)
        value = "";
      if (!(this.m_KeyTipsStack != value))
        return;
      this.m_KeyTipsStack = value;
      this.InvalidateVisual();
    }
  }

  public object ContextObject
  {
    get => this.m_ContextObject;
    set
    {
      this.m_ContextObject = value;
      this.InvalidateVisual();
    }
  }

  public Control RootControl
  {
    get => this.m_RootControl;
    set => this.m_RootControl = value;
  }

  internal bool ProcessTextInput(TextCompositionEventArgs e)
  {
    bool handled = e.Handled;
    int num = this.ProcessKeyInput(this.GetInputText(e), ref handled) ? 1 : 0;
    e.Handled = handled;
    return num != 0;
  }

  private string GetInputText(TextCompositionEventArgs e)
  {
    return e.SystemText != "" ? e.SystemText : e.Text;
  }

  private bool ProcessKeyInput(string textInput, ref bool markAsHandled)
  {
    string str = this.m_KeyTipsStack + textInput.ToUpper();
    bool flag = false;
    foreach (UIElement activeKeyTipElement in this.m_ActiveKeyTipElements)
    {
      string keyTip = Ribbon.GetKeyTip(activeKeyTipElement);
      if (keyTip == str)
      {
        markAsHandled = true;
        return this.ExecuteAction(activeKeyTipElement);
      }
      if (keyTip.StartsWith(str))
        flag = true;
    }
    if (flag)
    {
      this.KeyTipsStack = str;
      markAsHandled = true;
    }
    else
      SystemSounds.Beep.Play();
    return false;
  }

  public bool ExecuteAction(UIElement elem)
  {
    switch (elem)
    {
      case RibbonTab _:
        if (this.m_RootControl is Ribbon rootControl1)
        {
          rootControl1.ShowKeyTipsForContext(elem as RibbonTab);
        }
        else
        {
          RibbonTab ribbonTab = elem as RibbonTab;
          if (!ribbonTab.IsSelected)
            ribbonTab.IsSelected = true;
          this.ContextObject = (object) ribbonTab;
        }
        return false;
      case ButtonDropDown _:
        ButtonDropDown buttonDropDown = elem as ButtonDropDown;
        if ((buttonDropDown.Role == eButtonRole.DropDown || buttonDropDown.Role == eButtonRole.SplitButton) && buttonDropDown.HasItems)
        {
          buttonDropDown.ClickHeader();
          return false;
        }
        buttonDropDown.InternalOnClick(true);
        break;
      case RibbonBar _:
        (elem as RibbonBar).InvokeLaunchDialog();
        break;
      case RadioButton _:
        RadioButton radioButton1 = (RadioButton) elem;
        RadioButton radioButton2 = radioButton1;
        DependencyProperty isCheckedProperty1 = ToggleButton.IsCheckedProperty;
        bool? isChecked1 = radioButton1.IsChecked;
        // ISSUE: variable of a boxed type
        __Boxed<bool?> local1 = (ValueType) (isChecked1.HasValue ? new bool?(!isChecked1.GetValueOrDefault()) : new bool?());
        radioButton2.SetValue(isCheckedProperty1, (object) local1);
        break;
      case CheckBox _:
        CheckBox checkBox1 = (CheckBox) elem;
        CheckBox checkBox2 = checkBox1;
        DependencyProperty isCheckedProperty2 = ToggleButton.IsCheckedProperty;
        bool? isChecked2 = checkBox1.IsChecked;
        // ISSUE: variable of a boxed type
        __Boxed<bool?> local2 = (ValueType) (isChecked2.HasValue ? new bool?(!isChecked2.GetValueOrDefault()) : new bool?());
        checkBox2.SetValue(isCheckedProperty2, (object) local2);
        break;
      case TabItem _:
        (elem as TabItem).IsSelected = true;
        break;
      default:
        Ribbon rootControl2 = this.m_RootControl as Ribbon;
        AutomationPeer peerForElement = UIElementAutomationPeer.CreatePeerForElement(elem);
        if (rootControl2 != null && peerForElement != null && peerForElement.IsControlElement() && peerForElement.IsEnabled())
        {
          if (peerForElement.GetPattern(PatternInterface.ExpandCollapse) is IExpandCollapseProvider pattern1)
          {
            rootControl2.ShowKeyTips = false;
            elem.Focus();
            pattern1.Expand();
            return false;
          }
          if (peerForElement.GetPattern(PatternInterface.Toggle) is IToggleProvider pattern2)
          {
            pattern2.Toggle();
            return true;
          }
          if (peerForElement.GetPattern(PatternInterface.Invoke) is InvokePattern pattern3)
          {
            pattern3.Invoke();
            break;
          }
          break;
        }
        break;
    }
    return true;
  }
}
