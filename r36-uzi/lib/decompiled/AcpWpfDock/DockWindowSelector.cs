// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfDock.DockWindowSelector
// Assembly: AcpWpfDock, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 89CC52D3-0487-4106-AFAE-BE4A13C8A50E
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfDock.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

#nullable disable
namespace DevComponents.WpfDock;

[DesignTimeVisible(false)]
public class DockWindowSelector : Selector
{
  public static readonly DependencyProperty ToolWindowsProperty;
  private static readonly DependencyPropertyKey ToolWindowsPropertyKey;
  public static readonly DependencyProperty SelectedImageProperty;
  private static readonly DependencyPropertyKey SelectedImagePropertyKey;
  public static readonly DependencyProperty SelectedDockWindowProperty;
  private static readonly DependencyPropertyKey SelectedDockWindowPropertyKey;
  public static readonly DependencyProperty SelectedHeaderProperty;
  private static readonly DependencyPropertyKey SelectedHeaderPropertyKey;
  public static readonly DependencyProperty SelectedDescriptionProperty;
  private static readonly DependencyPropertyKey SelectedDescriptionPropertyKey;
  public static readonly DependencyProperty ActiveToolWindowsLabelProperty;
  public static readonly DependencyProperty ActiveFilesLabelProperty;
  public static readonly DependencyProperty CycleAllWindowsProperty = DependencyProperty.Register(nameof (CycleAllWindows), typeof (bool), typeof (DockWindowSelector), (PropertyMetadata) new UIPropertyMetadata((object) false));
  private DockWindowInfo m_SelectedToolWindow;

  public bool CycleAllWindows
  {
    get => (bool) this.GetValue(DockWindowSelector.CycleAllWindowsProperty);
    set => this.SetValue(DockWindowSelector.CycleAllWindowsProperty, (object) value);
  }

  static DockWindowSelector()
  {
    FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((object) typeof (DockWindowSelector)));
    DockWindowSelector.ActiveToolWindowsLabelProperty = DependencyProperty.Register(nameof (ActiveToolWindowsLabel), typeof (string), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    DockWindowSelector.ActiveFilesLabelProperty = DependencyProperty.Register(nameof (ActiveFilesLabel), typeof (string), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    DockWindowSelector.ToolWindowsPropertyKey = DependencyProperty.RegisterReadOnly(nameof (ToolWindows), typeof (ObservableCollection<DockWindowInfo>), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowSelector.ToolWindowsProperty = DockWindowSelector.ToolWindowsPropertyKey.DependencyProperty;
    DockWindowSelector.SelectedDescriptionPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedDescription), typeof (string), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((object) ""));
    DockWindowSelector.SelectedDescriptionProperty = DockWindowSelector.SelectedDescriptionPropertyKey.DependencyProperty;
    DockWindowSelector.SelectedHeaderPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedHeader), typeof (object), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowSelector.SelectedHeaderProperty = DockWindowSelector.SelectedHeaderPropertyKey.DependencyProperty;
    DockWindowSelector.SelectedImagePropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedImage), typeof (object), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowSelector.SelectedImageProperty = DockWindowSelector.SelectedImagePropertyKey.DependencyProperty;
    DockWindowSelector.SelectedDockWindowPropertyKey = DependencyProperty.RegisterReadOnly(nameof (SelectedDockWindow), typeof (DockWindow), typeof (DockWindowSelector), (PropertyMetadata) new FrameworkPropertyMetadata((PropertyChangedCallback) null));
    DockWindowSelector.SelectedDockWindowProperty = DockWindowSelector.SelectedDockWindowPropertyKey.DependencyProperty;
  }

  public DockWindowSelector()
  {
    this.ToolWindows = new ObservableCollection<DockWindowInfo>();
    this.ToolWindows.CollectionChanged += new NotifyCollectionChangedEventHandler(this.ToolWindows_CollectionChanged);
  }

  private void ToolWindows_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
  {
    if (e.NewItems != null)
    {
      foreach (DockWindowInfo newItem in (IEnumerable) e.NewItems)
        this.AddLogicalChild((object) newItem);
    }
    if (e.OldItems == null)
      return;
    foreach (DockWindowInfo newItem in (IEnumerable) e.NewItems)
      this.RemoveLogicalChild((object) newItem);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue(null)]
  public ObservableCollection<DockWindowInfo> ToolWindows
  {
    get
    {
      return (ObservableCollection<DockWindowInfo>) this.GetValue(DockWindowSelector.ToolWindowsProperty);
    }
    internal set => this.SetValue(DockWindowSelector.ToolWindowsPropertyKey, (object) value);
  }

  protected override void OnSelectionChanged(SelectionChangedEventArgs e)
  {
    base.OnSelectionChanged(e);
    this.UpdateAllSelectedContent();
    CommandManager.InvalidateRequerySuggested();
  }

  protected override void OnInitialized(EventArgs e)
  {
    base.OnInitialized(e);
    PropertyInfo property = this.GetType().GetProperty("CanSelectMultiple", BindingFlags.Instance | BindingFlags.NonPublic);
    if (property != (PropertyInfo) null)
      property.SetValue((object) this, (object) false, (object[]) null);
    this.ItemContainerGenerator.StatusChanged += new EventHandler(this.OnGeneratorStatusChanged);
  }

  private void OnGeneratorStatusChanged(object sender, EventArgs e)
  {
    if (this.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
      return;
    if (this.HasItems && this.SelectedIndex < 0 && this.SelectedToolWindow == null)
      this.SelectedIndex = 0;
    this.UpdateAllSelectedContent();
  }

  private void UpdateAllSelectedContent()
  {
    if (this.SelectedIndex < 0)
    {
      this.SelectedDescription = "";
      this.SelectedDockWindow = (DockWindow) null;
      this.SelectedHeader = (object) null;
      this.SelectedImage = (object) null;
    }
    else
    {
      DockWindowInfo selectedItem = this.SelectedItem as DockWindowInfo;
      this.SelectedDescription = selectedItem.Description;
      this.SelectedDockWindow = selectedItem.DockWindow;
      this.SelectedHeader = selectedItem.Header;
      this.SelectedImage = selectedItem.Image;
      if (this.SelectedToolWindow == null)
        return;
      this.SelectedToolWindow = (DockWindowInfo) null;
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedImage
  {
    get => this.GetValue(DockWindowSelector.SelectedImageProperty);
    internal set => this.SetValue(DockWindowSelector.SelectedImagePropertyKey, value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public object SelectedHeader
  {
    get => this.GetValue(DockWindowSelector.SelectedHeaderProperty);
    internal set => this.SetValue(DockWindowSelector.SelectedHeaderPropertyKey, value);
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public string SelectedDescription
  {
    get => (string) this.GetValue(DockWindowSelector.SelectedDescriptionProperty);
    internal set
    {
      this.SetValue(DockWindowSelector.SelectedDescriptionPropertyKey, (object) value);
    }
  }

  [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
  public DockWindow SelectedDockWindow
  {
    get => (DockWindow) this.GetValue(DockWindowSelector.SelectedDockWindowProperty);
    internal set => this.SetValue(DockWindowSelector.SelectedDockWindowPropertyKey, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue("")]
  public string ActiveFilesLabel
  {
    get => (string) this.GetValue(DockWindowSelector.ActiveFilesLabelProperty);
    set => this.SetValue(DockWindowSelector.ActiveFilesLabelProperty, (object) value);
  }

  [Bindable(true)]
  [Category("Content")]
  [DefaultValue("")]
  public string ActiveToolWindowsLabel
  {
    get => (string) this.GetValue(DockWindowSelector.ActiveToolWindowsLabelProperty);
    set => this.SetValue(DockWindowSelector.ActiveToolWindowsLabelProperty, (object) value);
  }

  internal void NavigateBack()
  {
    if (this.GetCycleThroughAll())
    {
      List<DockWindowInfo> dockWindowInfoList = new List<DockWindowInfo>(this.Items.Count + this.ToolWindows.Count);
      DockWindowInfo[] collection = new DockWindowInfo[this.Items.Count];
      this.Items.CopyTo((Array) collection, 0);
      dockWindowInfoList.AddRange((IEnumerable<DockWindowInfo>) collection);
      dockWindowInfoList.AddRange((IEnumerable<DockWindowInfo>) this.ToolWindows);
      int num = this.SelectedIndex;
      if (this.SelectedToolWindow != null)
        num = dockWindowInfoList.IndexOf(this.SelectedToolWindow);
      int index = num - 1;
      if (index < 0)
        index = dockWindowInfoList.Count - 1;
      if (index < this.Items.Count)
      {
        this.SelectedToolWindow = (DockWindowInfo) null;
        this.SelectedItem = (object) dockWindowInfoList[index];
      }
      else
        this.SelectedToolWindow = dockWindowInfoList[index];
    }
    else if (this.Items.Count > 0)
    {
      if (this.SelectedIndex > 0)
        --this.SelectedIndex;
      else
        this.SelectedIndex = this.Items.Count - 1;
    }
    else
    {
      if (this.ToolWindows.Count <= 0)
        return;
      int index;
      if (this.SelectedToolWindow == null)
      {
        index = this.ToolWindows.Count - 1;
      }
      else
      {
        int num = this.ToolWindows.IndexOf(this.SelectedToolWindow);
        index = num != 0 ? num - 1 : this.ToolWindows.Count - 1;
      }
      this.SelectedToolWindow = this.ToolWindows[index];
    }
  }

  internal void NavigateForward()
  {
    if (this.GetCycleThroughAll())
    {
      List<DockWindowInfo> dockWindowInfoList = new List<DockWindowInfo>(this.Items.Count + this.ToolWindows.Count);
      DockWindowInfo[] collection = new DockWindowInfo[this.Items.Count];
      this.Items.CopyTo((Array) collection, 0);
      dockWindowInfoList.AddRange((IEnumerable<DockWindowInfo>) collection);
      dockWindowInfoList.AddRange((IEnumerable<DockWindowInfo>) this.ToolWindows);
      int num = this.SelectedIndex;
      if (this.SelectedToolWindow != null)
        num = dockWindowInfoList.IndexOf(this.SelectedToolWindow);
      int index = num + 1;
      if (index > dockWindowInfoList.Count - 1)
        index = 0;
      if (index < this.Items.Count)
      {
        this.SelectedToolWindow = (DockWindowInfo) null;
        this.SelectedItem = (object) dockWindowInfoList[index];
      }
      else
        this.SelectedToolWindow = dockWindowInfoList[index];
    }
    else if (this.Items.Count > 0)
    {
      if (this.SelectedIndex < this.Items.Count - 1)
        ++this.SelectedIndex;
      else
        this.SelectedIndex = 0;
    }
    else
    {
      if (this.ToolWindows.Count <= 0)
        return;
      int index;
      if (this.SelectedToolWindow == null)
      {
        index = 0;
      }
      else
      {
        int num = this.ToolWindows.IndexOf(this.SelectedToolWindow);
        index = num != this.ToolWindows.Count - 1 ? num + 1 : 0;
      }
      this.SelectedToolWindow = this.ToolWindows[index];
    }
  }

  private bool GetCycleThroughAll() => this.CycleAllWindows;

  internal DockWindowInfo SelectedToolWindow
  {
    get => this.m_SelectedToolWindow;
    set
    {
      if (this.m_SelectedToolWindow == value)
        return;
      if (this.m_SelectedToolWindow != null)
        this.m_SelectedToolWindow.IsSelected = false;
      this.m_SelectedToolWindow = value;
      if (this.m_SelectedToolWindow == null)
        return;
      this.m_SelectedToolWindow.IsSelected = true;
      this.SelectedIndex = -1;
    }
  }
}
