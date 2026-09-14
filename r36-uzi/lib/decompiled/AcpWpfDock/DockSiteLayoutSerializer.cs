// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockSiteLayoutSerializer
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Xml;

#nullable disable
namespace DevComponents.WpfDock;

internal class DockSiteLayoutSerializer : IDockSiteLayoutSerializer
{
  private const int LayoutVersion = 1;
  private List<DockWindow> m_DockWindows;
  private bool m_IgnoreLoadLayoutElementNotFoundErrors;

  public string SaveLayout(DockSite ds)
  {
    XmlDocument xmlDocument = new XmlDocument();
    XmlElement element1 = xmlDocument.CreateElement(DockXmlElements.DockSite);
    element1.SetAttribute(DockXmlElements.Version, XmlConvert.ToString(1));
    xmlDocument.AppendChild((XmlNode) element1);
    foreach (SplitPanel splitPanel in (Collection<SplitPanel>) ds.SplitPanels)
    {
      if (DockSite.GetSaveLayout((UIElement) splitPanel))
        this.SaveSplitPanelLayout(splitPanel, element1);
    }
    if (ds.Content is SplitPanel content && DockSite.GetSaveLayout((UIElement) content))
      this.SaveSplitPanelLayout(content, element1).SetAttribute(DockXmlElements.IsDocument, XmlConvert.ToString(true));
    foreach (FloatingWindow floatingWindow in ds.GetFloatingWindows())
    {
      if (DockSite.GetSaveLayout((UIElement) floatingWindow))
        this.SaveFloatingWindowLayout(floatingWindow, element1);
    }
    List<DockWindow> dockWindows = ds.GetDockWindows(eDockList.AutoHide);
    XmlElement element2 = xmlDocument.CreateElement(DockXmlElements.AutoHideWindows);
    element1.AppendChild((XmlNode) element2);
    foreach (DockWindow dockWindow in dockWindows)
      this.SaveDockWindowLayout(dockWindow, element2);
    return xmlDocument.InnerXml;
  }

  private void SaveFloatingWindowLayout(FloatingWindow fw, XmlElement xmlParent)
  {
    if (!(fw.Content is DockWindowGroup content) || !DockSite.GetSaveLayout((UIElement) content))
      return;
    XmlElement element = xmlParent.OwnerDocument.CreateElement(DockXmlElements.FloatingWindow);
    xmlParent.AppendChild((XmlNode) element);
    this.SaveDockWindowGroupLayout(content, element);
    element.SetAttribute(DockXmlElements.FloatRect, DockSiteLayoutSerializer.ConvertRect(new Rect(fw.Left, fw.Top, fw.Width, fw.Height)));
  }

  private XmlElement SaveSplitPanelLayout(SplitPanel sp, XmlElement xmlParent)
  {
    XmlElement element = xmlParent.OwnerDocument.CreateElement(DockXmlElements.SplitPanel);
    xmlParent.AppendChild((XmlNode) element);
    if (sp.Parent is DockSite)
    {
      element.SetAttribute(DockXmlElements.Dock, DockSite.GetDock((UIElement) sp).ToString());
      element.SetAttribute(DockXmlElements.DockSize, XmlConvert.ToString(DockSite.GetDockSize((UIElement) sp)));
    }
    else if (sp.Parent is SplitPanel)
    {
      Size relativeSize = SplitPanel.GetRelativeSize((UIElement) sp);
      element.SetAttribute(DockXmlElements.RelativeSize, DockSiteLayoutSerializer.ConvertSize(relativeSize));
    }
    element.SetAttribute(DockXmlElements.Orientation, sp.Orientation.ToString());
    foreach (UIElement child in (Collection<UIElement>) sp.Children)
    {
      if (DockSite.GetSaveLayout(child))
      {
        switch (child)
        {
          case DockWindowGroup _:
            this.SaveDockWindowGroupLayout(child as DockWindowGroup, element);
            continue;
          case DockWindow _:
            this.SaveDockWindowLayout(child as DockWindow, element);
            continue;
          case SplitPanel _:
            this.SaveSplitPanelLayout(child as SplitPanel, element);
            continue;
          case FrameworkElement _:
            this.SaveDockedControlLayout(child as FrameworkElement, element);
            continue;
          default:
            continue;
        }
      }
    }
    return element;
  }

  private void SaveDockedControlLayout(FrameworkElement elem, XmlElement xmlSplitPanel)
  {
    if (elem.Name == "" || elem.Name == null)
      throw new InvalidOperationException("The FrameworkElement child of SplitPanel does not have name assigned and its layout cannot be serialized.");
    XmlElement element = xmlSplitPanel.OwnerDocument.CreateElement(DockXmlElements.DockedControl);
    if (elem.Parent is SplitPanel)
      element.SetAttribute(DockXmlElements.RelativeSize, DockSiteLayoutSerializer.ConvertSize(SplitPanel.GetRelativeSize((UIElement) elem)));
    element.SetAttribute(DockXmlElements.ControlName, elem.Name);
    xmlSplitPanel.AppendChild((XmlNode) element);
  }

  private void SaveDockWindowLayout(DockWindow dockWindow, XmlElement xmlParent)
  {
    if (dockWindow.Name == "" || dockWindow.Name == null)
      throw new InvalidOperationException("The DockWindow child of SplitPanel or DockWindowGroup does not have name assigned and its layout cannot be serialized.");
    XmlElement element = xmlParent.OwnerDocument.CreateElement(DockXmlElements.DockWindow);
    if (dockWindow.Parent is SplitPanel)
      element.SetAttribute(DockXmlElements.RelativeSize, DockSiteLayoutSerializer.ConvertSize(SplitPanel.GetRelativeSize((UIElement) dockWindow)));
    element.SetAttribute(DockXmlElements.ControlName, dockWindow.Name);
    if (dockWindow.Visibility != Visibility.Visible && !dockWindow.IsAutoHide)
      element.SetAttribute(DockXmlElements.Visibility, dockWindow.Visibility.ToString());
    if (dockWindow.IsFloating)
    {
      FloatingWindow floatingWindow = dockWindow.GetDockSite().GetFloatingWindow((UIElement) dockWindow);
      Rect rect = new Rect(floatingWindow.Left, floatingWindow.Top, floatingWindow.Width, floatingWindow.Height);
      dockWindow.FloatingRect = rect;
    }
    else if (dockWindow.IsAutoHide)
      element.SetAttribute(DockXmlElements.Dock, DockSite.GetDock((UIElement) dockWindow).ToString());
    Size sz;
    ref Size local = ref sz;
    Size size = dockWindow.LastAutoHideSize;
    double width;
    if (size.Width <= 0.0)
    {
      size = dockWindow.LastDockedSize;
      width = size.Width;
    }
    else
    {
      size = dockWindow.LastAutoHideSize;
      width = size.Width;
    }
    size = dockWindow.LastAutoHideSize;
    double height;
    if (size.Height <= 0.0)
    {
      size = dockWindow.LastDockedSize;
      height = size.Height;
    }
    else
    {
      size = dockWindow.LastAutoHideSize;
      height = size.Height;
    }
    local = new Size(width, height);
    if (!sz.IsEmpty)
      element.SetAttribute(DockXmlElements.AutoHideSize, DockSiteLayoutSerializer.ConvertSize(sz));
    if (dockWindow.FloatingRect != DockWindow.DefaultFloatingRect)
      element.SetAttribute(DockXmlElements.FloatRect, DockSiteLayoutSerializer.ConvertRect(dockWindow.FloatingRect));
    xmlParent.AppendChild((XmlNode) element);
  }

  private void SaveDockWindowGroupLayout(DockWindowGroup dockGroup, XmlElement xmlParent)
  {
    XmlElement element = xmlParent.OwnerDocument.CreateElement(DockXmlElements.DockWindowGroup);
    xmlParent.AppendChild((XmlNode) element);
    element.SetAttribute(DockXmlElements.RelativeSize, DockSiteLayoutSerializer.ConvertSize(SplitPanel.GetRelativeSize((UIElement) dockGroup)));
    if (dockGroup.Visibility != Visibility.Visible)
      element.SetAttribute(DockXmlElements.Visibility, dockGroup.Visibility.ToString());
    foreach (object elem in (IEnumerable) dockGroup.Items)
    {
      if (elem is DockWindow)
        this.SaveDockWindowLayout(elem as DockWindow, element);
      else if (elem is FrameworkElement)
        this.SaveDockedControlLayout(elem as FrameworkElement, element);
    }
  }

  public void LoadLayout(DockSite ds, string layout)
  {
    XmlDocument xmlDocument = new XmlDocument();
    xmlDocument.LoadXml(layout);
    if (xmlDocument.FirstChild.Name != DockXmlElements.DockSite)
      throw new InvalidOperationException("Layout XML not in valid format. DockSite element missing.");
    XmlElement firstChild = xmlDocument.FirstChild as XmlElement;
    if (XmlConvert.ToInt32(firstChild.GetAttribute(DockXmlElements.Version)) > 1)
      throw new InvalidOperationException("Layout XML not in supported version.");
    this.m_IgnoreLoadLayoutElementNotFoundErrors = ds.IgnoreLoadLayoutElementNotFoundErrors;
    this.m_DockWindows = ds.GetDockWindows();
    try
    {
      foreach (XmlNode childNode in firstChild.ChildNodes)
      {
        XmlElement xmlElement = childNode as XmlElement;
        if (xmlElement.Name == DockXmlElements.SplitPanel)
          this.LoadSplitPanelLayout(ds, xmlElement);
        else if (xmlElement.Name == DockXmlElements.FloatingWindow)
          this.LoadFloatingWindowLayout(ds, xmlElement);
        else if (xmlElement.Name == DockXmlElements.AutoHideWindows)
          this.LoadAutoHideWindowsLayout(ds, xmlElement);
      }
    }
    finally
    {
      this.m_DockWindows = (List<DockWindow>) null;
    }
    Window.GetWindow((DependencyObject) ds)?.Activate();
  }

  private void LoadAutoHideWindowsLayout(DockSite ds, XmlElement xmlParent)
  {
    foreach (XmlNode childNode in xmlParent.ChildNodes)
    {
      XmlElement elem = childNode as XmlElement;
      if (elem.Name == DockXmlElements.DockWindow)
      {
        DockWindow dockWindow1 = this.FindDockWindow(elem.GetAttribute(DockXmlElements.ControlName));
        if (dockWindow1 != null && dockWindow1.IsAutoHide)
          dockWindow1.IsAutoHide = false;
        DockWindow dockWindow2 = this.LoadDockWindowLayout(elem);
        if (dockWindow2 != null)
        {
          Dock dock = DockSite.GetDock((UIElement) dockWindow2);
          if (dockWindow2.ParentGroup != null && dockWindow2.ParentGroup.Items.Count == 1 && ds.GetDockFromDockWindowGroup(dockWindow2.ParentGroup) != dock)
            ds.DockWindow(dockWindow2.ParentGroup, DockSite.GetDockSideFromDock(dock));
          ds.SetAutoHide(dockWindow2, true, eEventActionSource.Code, false, DockSite.GetDock((UIElement) dockWindow2));
          dockWindow2.LastDock = DockSite.GetDock((UIElement) dockWindow2);
          dockWindow2.IgnoreAutoHideChange = true;
          dockWindow2.IsAutoHide = true;
          dockWindow2.IgnoreAutoHideChange = false;
        }
      }
    }
  }

  private void LoadFloatingWindowLayout(DockSite ds, XmlElement xmlParent)
  {
    foreach (XmlNode childNode in xmlParent.ChildNodes)
    {
      XmlElement elem = childNode as XmlElement;
      if (elem.Name == DockXmlElements.DockWindowGroup)
      {
        DockWindowGroup dg = this.LoadDockWindowGroupLayout(elem);
        if (dg == null)
          break;
        ds.FloatWindow(dg);
        break;
      }
    }
  }

  private DockWindowGroup LoadDockWindowGroupLayout(XmlElement elem)
  {
    return this.LoadDockWindowGroupLayout((SplitPanel) null, elem);
  }

  private void LoadSplitPanelLayout(DockSite ds, XmlElement elem)
  {
    SplitPanel splitPanel = new SplitPanel();
    Dock d1 = (Dock) Enum.Parse(typeof (Dock), elem.GetAttribute(DockXmlElements.Dock));
    double d2 = XmlConvert.ToDouble(elem.GetAttribute(DockXmlElements.DockSize));
    Orientation orientation = (Orientation) Enum.Parse(typeof (Orientation), elem.GetAttribute(DockXmlElements.Orientation));
    bool flag = false;
    if (elem.HasAttribute(DockXmlElements.IsDocument) && XmlConvert.ToBoolean(elem.GetAttribute(DockXmlElements.IsDocument)))
      flag = true;
    DockSite.SetDock((UIElement) splitPanel, d1);
    DockSite.SetDockSize((UIElement) splitPanel, d2);
    splitPanel.Orientation = orientation;
    object obj = (object) null;
    if (flag)
    {
      obj = ds.Content;
      ds.Content = (object) splitPanel;
    }
    else
      ds.SplitPanels.Add(splitPanel);
    this.LoadChildren(splitPanel, elem);
    if (splitPanel.Children.Count == 0)
    {
      if (flag)
        ds.Content = obj;
      else
        ds.SplitPanels.Remove(splitPanel);
    }
    else
      splitPanel.UpdateAutoVisibility();
  }

  private void LoadSplitPanelLayout(SplitPanel parent, XmlElement elem)
  {
    SplitPanel splitPanel = new SplitPanel();
    Size d = DockSiteLayoutSerializer.ConvertSize(elem.GetAttribute(DockXmlElements.RelativeSize));
    SplitPanel.SetRelativeSize((UIElement) splitPanel, d);
    Orientation orientation = (Orientation) Enum.Parse(typeof (Orientation), elem.GetAttribute(DockXmlElements.Orientation));
    splitPanel.Orientation = orientation;
    parent.Children.Add((UIElement) splitPanel);
    this.LoadChildren(splitPanel, elem);
    if (splitPanel.Children.Count == 0)
      parent.Children.Remove((UIElement) splitPanel);
    else
      splitPanel.UpdateAutoVisibility();
  }

  private void LoadChildren(SplitPanel parent, XmlElement xmlParent)
  {
    foreach (XmlNode childNode in xmlParent.ChildNodes)
    {
      XmlElement elem = childNode as XmlElement;
      if (elem.Name == DockXmlElements.SplitPanel)
        this.LoadSplitPanelLayout(parent, elem);
      else if (elem.Name == DockXmlElements.DockWindowGroup)
        this.LoadDockWindowGroupLayout(parent, elem);
      else if (elem.Name == DockXmlElements.DockWindow)
      {
        DockWindow dw = this.LoadDockWindowLayout(elem);
        if (dw != null)
        {
          this.Detach(dw);
          parent.Children.Add((UIElement) dw);
        }
      }
      else if (elem.Name == DockXmlElements.DockedControl)
      {
        FrameworkElement frameworkElement = this.LoadDockControlLayout(elem);
        if (frameworkElement != null)
          parent.Children.Add((UIElement) frameworkElement);
      }
    }
  }

  private void Detach(DockWindow dw)
  {
    if (dw.IsAutoHide)
      dw.IsAutoHide = false;
    if (dw.Parent is DockWindowGroup)
    {
      DockWindowGroup parent = dw.Parent as DockWindowGroup;
      parent.Items.Remove((object) dw);
      if (parent.Items.Count != 0)
        return;
      this.Detach(parent);
    }
    else
    {
      if (!(dw.Parent is SplitPanel))
        return;
      SplitPanel parent = dw.Parent as SplitPanel;
      parent.Children.Remove((UIElement) dw);
      if (parent.Children.Count != 0)
        return;
      this.Detach(parent);
    }
  }

  private void Detach(DockWindowGroup dg)
  {
    if (dg.Parent is SplitPanel)
    {
      SplitPanel parent = dg.Parent as SplitPanel;
      parent.Children.Remove((UIElement) dg);
      if (parent.Children.Count != 0)
        return;
      this.Detach(parent);
    }
    else
    {
      if (!(dg.Parent is FloatingWindow))
        return;
      dg.GetDockSite().Detach(dg);
    }
  }

  private void Detach(SplitPanel panel)
  {
    if (panel.Parent is SplitPanel)
    {
      SplitPanel parent = panel.Parent as SplitPanel;
      parent.Children.Remove((UIElement) panel);
      if (parent.Children.Count != 0)
        return;
      this.Detach(parent);
    }
    else
    {
      if (!(panel.Parent is DockSite))
        return;
      DockSite parent = panel.Parent as DockSite;
      if (parent.Content == panel)
      {
        parent.Content = (object) null;
      }
      else
      {
        if (!parent.SplitPanels.Contains(panel))
          return;
        parent.SplitPanels.Remove(panel);
      }
    }
  }

  private FrameworkElement LoadDockControlLayout(XmlElement elem)
  {
    string attribute = elem.GetAttribute(DockXmlElements.ControlName);
    Size size = new Size();
    if (elem.HasAttribute(DockXmlElements.RelativeSize))
      size = DockSiteLayoutSerializer.ConvertSize(elem.GetAttribute(DockXmlElements.RelativeSize));
    FrameworkElement dockControl = this.FindDockControl(attribute);
    if (dockControl != null && !LayoutHelpers.IsEmpty(size))
      SplitPanel.SetRelativeSize((UIElement) dockControl, size);
    return dockControl;
  }

  private FrameworkElement FindDockControl(string name)
  {
    throw new Exception("The method or operation is not implemented.");
  }

  private DockWindow LoadDockWindowLayout(XmlElement elem)
  {
    string attribute = elem.GetAttribute(DockXmlElements.ControlName);
    Size size = new Size();
    if (elem.HasAttribute(DockXmlElements.RelativeSize))
      size = DockSiteLayoutSerializer.ConvertSize(elem.GetAttribute(DockXmlElements.RelativeSize));
    DockWindow dockWindow = this.FindDockWindow(attribute);
    if (dockWindow == null && this.m_IgnoreLoadLayoutElementNotFoundErrors)
      return (DockWindow) null;
    if (dockWindow != null && !LayoutHelpers.IsEmpty(size))
      SplitPanel.SetRelativeSize((UIElement) dockWindow, size);
    if (elem.HasAttribute(DockXmlElements.Visibility))
      dockWindow.Visibility = (Visibility) Enum.Parse(typeof (Visibility), elem.GetAttribute(DockXmlElements.Visibility));
    else
      dockWindow.Visibility = Visibility.Visible;
    if (elem.HasAttribute(DockXmlElements.FloatRect))
      dockWindow.FloatingRect = DockSiteLayoutSerializer.ConvertRect(elem.GetAttribute(DockXmlElements.FloatRect));
    if (elem.HasAttribute(DockXmlElements.Dock))
      DockSite.SetDock((UIElement) dockWindow, (Dock) Enum.Parse(typeof (Dock), elem.GetAttribute(DockXmlElements.Dock)));
    if (elem.HasAttribute(DockXmlElements.AutoHideSize))
      dockWindow.LastAutoHideSize = DockSiteLayoutSerializer.ConvertSize(elem.GetAttribute(DockXmlElements.AutoHideSize));
    return dockWindow;
  }

  private DockWindow FindDockWindow(string name)
  {
    foreach (DockWindow dockWindow in this.m_DockWindows)
    {
      if (dockWindow.Name == name)
        return dockWindow;
    }
    Trace.WriteLine($"DockWindow named '{name}' could not be found while loading layout");
    return (DockWindow) null;
  }

  private DockWindowGroup LoadDockWindowGroupLayout(SplitPanel sp, XmlElement elem)
  {
    DockWindowGroup element = new DockWindowGroup();
    Size d = DockSiteLayoutSerializer.ConvertSize(elem.GetAttribute(DockXmlElements.RelativeSize));
    if (sp != null)
    {
      SplitPanel.SetRelativeSize((UIElement) element, d);
      sp.Children.Add((UIElement) element);
    }
    if (elem.HasAttribute(DockXmlElements.Visibility))
      element.Visibility = (Visibility) Enum.Parse(typeof (Visibility), elem.GetAttribute(DockXmlElements.Visibility));
    else
      element.Visibility = Visibility.Visible;
    bool flag = false;
    foreach (XmlNode childNode in elem.ChildNodes)
    {
      XmlElement elem1 = childNode as XmlElement;
      if (elem1.Name == DockXmlElements.DockWindow)
      {
        DockWindow dockWindow = this.LoadDockWindowLayout(elem1);
        if (dockWindow != null)
        {
          this.Detach(dockWindow);
          element.Items.Add((object) dockWindow);
        }
        else
          flag = true;
      }
      else if (elem1.Name == DockXmlElements.DockedControl)
      {
        FrameworkElement newItem = this.LoadDockControlLayout(elem1);
        if (newItem != null)
          element.Items.Add((object) newItem);
      }
    }
    if (element.Items.Count == 0 & flag)
    {
      sp?.Children.Remove((UIElement) element);
      element = (DockWindowGroup) null;
    }
    else if (element.SelectedItem == null)
      element.SelectFirstTab();
    return element;
  }

  private static Size ConvertSize(string size)
  {
    string[] strArray = size.Split(',');
    return new Size(XmlConvert.ToDouble(strArray[0]), XmlConvert.ToDouble(strArray[1]));
  }

  private static string ConvertSize(Size sz)
  {
    return $"{XmlConvert.ToString(sz.Width)},{XmlConvert.ToString(sz.Height)}";
  }

  private static Rect ConvertRect(string rect)
  {
    string[] strArray = rect.Split(',');
    return new Rect(XmlConvert.ToDouble(strArray[0]), XmlConvert.ToDouble(strArray[1]), XmlConvert.ToDouble(strArray[2]), XmlConvert.ToDouble(strArray[3]));
  }

  private static string ConvertRect(Rect r)
  {
    return $"{XmlConvert.ToString(r.X)},{XmlConvert.ToString(r.Y)},{XmlConvert.ToString(r.Width)},{XmlConvert.ToString(r.Height)}";
  }
}
