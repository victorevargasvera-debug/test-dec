// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpListBoxMruFiles
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;

#nullable disable
namespace AcpUI;

public partial class AcpListBoxMruFiles : UserControl, IComponentConnector, IStyleConnector
{
  public static readonly RoutedEvent FileClickEvent = EventManager.RegisterRoutedEvent("FileClick", RoutingStrategy.Bubble, typeof (RoutedEventHandler), typeof (AcpListBoxMruFiles));
  internal ListBox MruListBox;
  private bool _contentLoaded;

  public AcpListBoxMruFiles() => this.InitializeComponent();

  public event RoutedEventHandler FileClick
  {
    add => this.AddHandler(AcpListBoxMruFiles.FileClickEvent, (Delegate) value);
    remove => this.RemoveHandler(AcpListBoxMruFiles.FileClickEvent, (Delegate) value);
  }

  private void OnMruFileClick(object sender, RoutedEventArgs e)
  {
    if (!(sender is StackPanel))
      return;
    SelectedMruFileEventArgs e1 = new SelectedMruFileEventArgs(((XmlNode) ((FrameworkElement) sender).Tag).Value);
    e1.RoutedEvent = AcpListBoxMruFiles.FileClickEvent;
    e1.Source = sender;
    this.RaiseEvent((RoutedEventArgs) e1);
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpUI;component/acplistboxmrufiles.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    if (connectionId == 1)
      this.MruListBox = (ListBox) target;
    else
      this._contentLoaded = true;
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IStyleConnector.Connect(int connectionId, object target)
  {
    if (connectionId != 2)
      return;
    ((UIElement) target).MouseLeftButtonDown += new MouseButtonEventHandler(this.OnMruFileClick);
  }
}
