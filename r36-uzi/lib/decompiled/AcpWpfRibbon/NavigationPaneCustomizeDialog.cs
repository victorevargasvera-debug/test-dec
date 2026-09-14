// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.NavigationPaneCustomizeDialog
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Interop;
using System.Windows.Markup;

#nullable disable
namespace DevComponents.WpfRibbon;

public class NavigationPaneCustomizeDialog : Window, IComponentConnector
{
  private bool _DataChanged;
  private bool _Reordered;
  public static readonly DependencyProperty NavigationPaneProperty = DependencyProperty.Register(nameof (NavigationPane), typeof (NavigationPane), typeof (NavigationPaneCustomizeDialog), (PropertyMetadata) new UIPropertyMetadata((PropertyChangedCallback) null));
  internal Button ButtonMoveUp;
  internal Button ButtonMoveDown;
  internal ListBox PaneItems;
  private bool _contentLoaded;

  public NavigationPaneCustomizeDialog() => this.InitializeComponent();

  protected override void OnSourceInitialized(EventArgs e)
  {
    base.OnSourceInitialized(e);
    IntPtr handle = new WindowInteropHelper((Window) this).Handle;
    WinApi.SetWindowLong(handle, -20, WinApi.GetWindowLong(handle, -20) | 1);
    WinApi.SetWindowPos(handle, IntPtr.Zero, 0, 0, 0, 0, 39);
    this._DataChanged = false;
    this._Reordered = false;
  }

  public NavigationPane NavigationPane
  {
    get => (NavigationPane) this.GetValue(NavigationPaneCustomizeDialog.NavigationPaneProperty);
    set => this.SetValue(NavigationPaneCustomizeDialog.NavigationPaneProperty, (object) value);
  }

  public void Initialize(NavigationPane np)
  {
    this.NavigationPane = np;
    this.PaneItems.ItemsSource = (IEnumerable) new PaneItemDescriptionList(np);
    if (np.Items.CanSort)
      return;
    this.ButtonMoveDown.IsEnabled = false;
    this.ButtonMoveUp.IsEnabled = false;
  }

  private void OkButtonClick(object sender, RoutedEventArgs e)
  {
    this.DialogResult = new bool?(true);
    if (this._DataChanged)
    {
      PaneItemDescriptionList itemDescriptionList = this.GetPaneItemDescriptionList();
      NavigationPane navigationPane = this.NavigationPane;
      if (this._Reordered)
      {
        for (int index = 0; index < itemDescriptionList.Count; ++index)
        {
          PaneItemDescription paneItemDescription = itemDescriptionList[index];
          if (index != navigationPane.Items.IndexOf((object) paneItemDescription.PaneItem))
          {
            navigationPane.Items.Remove((object) paneItemDescription.PaneItem);
            navigationPane.Items.Insert(index, (object) paneItemDescription.PaneItem);
          }
        }
      }
      foreach (PaneItemDescription paneItemDescription in (Collection<PaneItemDescription>) itemDescriptionList)
        paneItemDescription.PaneItem.Visibility = paneItemDescription.IsVisible ? Visibility.Visible : Visibility.Collapsed;
    }
    this.Close();
  }

  private void CheckedChanged(object sender, RoutedEventArgs e) => this._DataChanged = true;

  private void MoveItemUp(object sender, RoutedEventArgs e)
  {
    if (this.PaneItems.SelectedIndex <= 0)
      return;
    PaneItemDescriptionList itemDescriptionList = this.GetPaneItemDescriptionList();
    PaneItemDescription paneItemDescription = itemDescriptionList[this.PaneItems.SelectedIndex];
    int selectedIndex = this.PaneItems.SelectedIndex;
    itemDescriptionList.RemoveAt(selectedIndex);
    int index = selectedIndex - 1;
    itemDescriptionList.Insert(index, paneItemDescription);
    this.PaneItems.SelectedIndex = index;
    this._Reordered = true;
    this._DataChanged = true;
  }

  private void MoveItemDown(object sender, RoutedEventArgs e)
  {
    if (this.PaneItems.SelectedIndex < 0 || this.PaneItems.SelectedIndex >= this.PaneItems.Items.Count - 1)
      return;
    PaneItemDescriptionList itemDescriptionList = this.GetPaneItemDescriptionList();
    PaneItemDescription paneItemDescription = itemDescriptionList[this.PaneItems.SelectedIndex];
    int selectedIndex = this.PaneItems.SelectedIndex;
    itemDescriptionList.RemoveAt(selectedIndex);
    int index = selectedIndex + 1;
    itemDescriptionList.Insert(index, paneItemDescription);
    this.PaneItems.SelectedIndex = index;
    this._Reordered = true;
    this._DataChanged = true;
  }

  private void ResetItems(object sender, RoutedEventArgs e)
  {
    this.Initialize(this.NavigationPane);
    this._Reordered = false;
    this._DataChanged = false;
  }

  private PaneItemDescriptionList GetPaneItemDescriptionList()
  {
    return this.PaneItems.ItemsSource as PaneItemDescriptionList;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpWpfRibbon;component/navigationpane/navigationpanecustomizedialog.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.OkButtonClick);
        break;
      case 2:
        this.ButtonMoveUp = (Button) target;
        this.ButtonMoveUp.Click += new RoutedEventHandler(this.MoveItemUp);
        break;
      case 3:
        this.ButtonMoveDown = (Button) target;
        this.ButtonMoveDown.Click += new RoutedEventHandler(this.MoveItemDown);
        break;
      case 4:
        ((ButtonBase) target).Click += new RoutedEventHandler(this.ResetItems);
        break;
      case 5:
        this.PaneItems = (ListBox) target;
        this.PaneItems.AddHandler(ToggleButton.CheckedEvent, (Delegate) new RoutedEventHandler(this.CheckedChanged));
        this.PaneItems.AddHandler(ToggleButton.UncheckedEvent, (Delegate) new RoutedEventHandler(this.CheckedChanged));
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
