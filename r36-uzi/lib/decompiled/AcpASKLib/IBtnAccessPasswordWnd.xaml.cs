// Decompiled with JetBrains decompiler
// Type: AcpASKLib.IBtnAccessPasswordWnd
// Assembly: AcpASKLib, Version=23.1.0.5, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: D65BC533-E9D0-49A5-8218-5CB2B5C70E2D
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpASKLib.dll

using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

#nullable disable
namespace AcpASKLib;

public partial class IBtnAccessPasswordWnd : Window, IComponentConnector
{
  internal Label lblTitle;
  internal PasswordBox Passwd;
  internal Button OkButton;
  internal Button cancelButton;
  private bool _contentLoaded;

  public IBtnAccessPasswordWnd()
  {
    this.InitializeComponent();
    if (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft)
      this.FlowDirection = FlowDirection.RightToLeft;
    else
      this.FlowDirection = FlowDirection.LeftToRight;
    this.Passwd.Focus();
  }

  private void OnClickOK(object sender, RoutedEventArgs e)
  {
    this.DialogResult = new bool?(true);
    this.Close();
  }

  private void OnClickCancel(object sender, RoutedEventArgs e)
  {
    this.DialogResult = new bool?(false);
    this.Close();
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  public void InitializeComponent()
  {
    if (this._contentLoaded)
      return;
    this._contentLoaded = true;
    Application.LoadComponent((object) this, new Uri("/AcpASKLib;component/ibtnaccesspasswordwnd.xaml", UriKind.Relative));
  }

  [DebuggerNonUserCode]
  [GeneratedCode("PresentationBuildTasks", "8.0.3.0")]
  [EditorBrowsable(EditorBrowsableState.Never)]
  void IComponentConnector.Connect(int connectionId, object target)
  {
    switch (connectionId)
    {
      case 1:
        this.lblTitle = (Label) target;
        break;
      case 2:
        this.Passwd = (PasswordBox) target;
        break;
      case 3:
        this.OkButton = (Button) target;
        this.OkButton.Click += new RoutedEventHandler(this.OnClickOK);
        break;
      case 4:
        this.cancelButton = (Button) target;
        this.cancelButton.Click += new RoutedEventHandler(this.OnClickCancel);
        break;
      default:
        this._contentLoaded = true;
        break;
    }
  }
}
