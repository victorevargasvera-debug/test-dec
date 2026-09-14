// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.CloningMachine
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Xml;

#nullable disable
namespace DevComponents.WpfRibbon;

internal static class CloningMachine
{
  internal static ButtonDropDown Clone(ButtonDropDown source, bool deepCopy)
  {
    ButtonDropDown target = new ButtonDropDown();
    target.Name = source.Name;
    target.Role = source.Role;
    target.ColorClass = source.ColorClass;
    target.ExpandPosition = source.ExpandPosition;
    target.ExpandVisibility = source.ExpandVisibility;
    target.ImagePosition = source.ImagePosition;
    target.InputGestureText = source.InputGestureText;
    target.IsCheckable = source.IsCheckable;
    target.IsChecked = source.IsChecked;
    if (source.Command == null)
      target.IsEnabled = source.IsEnabled;
    target.PartVisibility = source.PartVisibility;
    target.PopupPlacement = source.PopupPlacement;
    target.PopupType = source.PopupType;
    target.Role = source.Role;
    target.ContentExpands = source.ContentExpands;
    target.InlineExpand = source.InlineExpand;
    target.ToolTip = source.ToolTip;
    target.Command = source.Command;
    target.CommandTarget = source.CommandTarget;
    target.CommandParameter = source.CommandParameter;
    target.Tag = source.Tag;
    if (!(target.Command is ButtonDropDownCommand))
    {
      target.Header = CloningMachine.XamlClone(source.Header);
      target.Image = CloningMachine.XamlClone(source.Image);
      target.ImageSmall = CloningMachine.XamlClone(source.ImageSmall);
      target.ImageSource = source.ImageSource;
      target.ImageSmallSource = source.ImageSmallSource;
    }
    target.WrapLabel = source.WrapLabel;
    if (deepCopy)
      CloningMachine.CloneCollection(source.Items, target.Items);
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, ButtonDropDown.ClickEvent);
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, ButtonDropDown.CheckedEvent);
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, ButtonDropDown.UncheckedEvent);
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, ButtonDropDown.PopupOpenedEvent);
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, ButtonDropDown.PopupClosedEvent);
    return target;
  }

  internal static ButtonPanel Clone(ButtonPanel source, bool deepCopy)
  {
    ButtonPanel buttonPanel = new ButtonPanel();
    buttonPanel.Name = source.Name;
    buttonPanel.Orientation = source.Orientation;
    buttonPanel.FixedWidth = source.FixedWidth;
    buttonPanel.FixedHeight = source.FixedHeight;
    CloningMachine.CloneCollection(source.Children, buttonPanel.Children);
    return buttonPanel;
  }

  internal static GroupPanel Clone(GroupPanel source, bool deepCopy)
  {
    GroupPanel groupPanel = new GroupPanel();
    groupPanel.Name = source.Name;
    groupPanel.Orientation = source.Orientation;
    groupPanel.FixedWidth = source.FixedWidth;
    groupPanel.FixedHeight = source.FixedHeight;
    groupPanel.BorderBrush = source.BorderBrush;
    groupPanel.LightBorderBrush = source.LightBorderBrush;
    groupPanel.CornerRadius = source.CornerRadius;
    CloningMachine.CloneCollection(source.Children, groupPanel.Children);
    return groupPanel;
  }

  internal static object GetObjectCopy(object o, bool deepCopy)
  {
    switch (o)
    {
      case null:
        return (object) null;
      case ButtonDropDown _:
        return (object) CloningMachine.Clone((ButtonDropDown) o, deepCopy);
      case GroupPanel _:
        return (object) CloningMachine.Clone((GroupPanel) o, deepCopy);
      case ButtonPanel _:
        return (object) CloningMachine.Clone((ButtonPanel) o, deepCopy);
      case RibbonBar _:
        return (object) CloningMachine.Clone((RibbonBar) o, deepCopy);
      case string _:
        return (object) o.ToString();
      case Image _:
        return CloningMachine.Clone((Image) o);
      default:
        return XamlReader.Load(XmlReader.Create((TextReader) new StringReader(XamlWriter.Save(o))));
    }
  }

  internal static object Clone(Image image)
  {
    try
    {
      return (object) (XamlReader.Load(XmlReader.Create((TextReader) new StringReader(XamlWriter.Save((object) image)))) as Image);
    }
    catch
    {
      if (image.Source == null)
        throw;
    }
    Image image1 = new Image();
    image1.Source = image.Source.CloneCurrentValue();
    image1.Margin = image.Margin;
    image1.Stretch = image.Stretch;
    image1.StretchDirection = image.StretchDirection;
    image1.Width = image.Width;
    image1.Height = image.Height;
    image1.MinHeight = image.MinHeight;
    image1.MinWidth = image.MinWidth;
    return (object) image1;
  }

  internal static void CloneCollection(UIElementCollection source, UIElementCollection target)
  {
    foreach (UIElement o in source)
    {
      if (CloningMachine.GetObjectCopy((object) o, true) is UIElement objectCopy)
        target.Add(objectCopy);
    }
  }

  internal static void CloneCollection(ItemCollection source, ItemCollection target)
  {
    foreach (object o in (IEnumerable) source)
    {
      object objectCopy = CloningMachine.GetObjectCopy(o, true);
      if (objectCopy != null)
        target.Add(objectCopy);
    }
  }

  internal static object XamlClone(object source)
  {
    if (source == null)
      return (object) null;
    if (source is string)
      return (object) source.ToString();
    return source.GetType().IsValueType ? source : XamlReader.Load(XmlReader.Create((TextReader) new StringReader(XamlWriter.Save(source))));
  }

  internal static RibbonBar Clone(RibbonBar source, bool deepCopy)
  {
    RibbonBar target = new RibbonBar();
    target.Name = source.Name;
    target.Header = CloningMachine.XamlClone(source.Header);
    target.DialogLauncherVisible = source.DialogLauncherVisible;
    target.IsAutoSizeEnabled = source.IsAutoSizeEnabled;
    target.ResizeOrderIndex = source.ResizeOrderIndex;
    target.CollapsedHeader = CloningMachine.XamlClone(source.CollapsedHeader);
    target.CollapsedImage = CloningMachine.XamlClone(source.CollapsedImage);
    target.VerticalAlignment = source.VerticalAlignment;
    target.HorizontalAlignment = source.HorizontalAlignment;
    target.HorizontalContentAlignment = source.HorizontalContentAlignment;
    target.VerticalContentAlignment = source.VerticalContentAlignment;
    RoutedEventHandlerCloner.CopyHandlers((UIElement) source, (UIElement) target, RibbonBar.LaunchDialogEvent);
    if (deepCopy)
      CloningMachine.CloneCollection(source.Items, target.Items);
    return target;
  }
}
