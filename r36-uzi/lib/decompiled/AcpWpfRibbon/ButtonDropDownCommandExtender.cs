// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonDropDownCommandExtender
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfRibbon;

public class ButtonDropDownCommandExtender : IButtonDropDownCommandExtender
{
  private string m_Header = string.Empty;
  private ImageSource m_ImageSource;
  private ImageSource m_ImageSmallSource;
  private bool m_IsChecked;
  private bool m_SyncIsChecked = true;
  private bool m_SyncHeader = true;
  private bool m_SyncImageSource = true;
  private bool m_SyncImageSmallSource = true;

  public ButtonDropDownCommandExtender()
  {
  }

  public ButtonDropDownCommandExtender(string header)
    : this(header, (string) null, (string) null)
  {
  }

  public ButtonDropDownCommandExtender(string header, string image)
    : this(header, image, (string) null)
  {
  }

  public ButtonDropDownCommandExtender(string header, string image, string imageSmall)
  {
    this.m_Header = header;
    if (image != null && image.Length > 0)
      this.m_ImageSource = (ImageSource) new BitmapImage(new Uri(image, UriKind.RelativeOrAbsolute));
    if (imageSmall == null || imageSmall.Length <= 0)
      return;
    this.m_ImageSmallSource = (ImageSource) new BitmapImage(new Uri(imageSmall, UriKind.RelativeOrAbsolute));
  }

  public string Header
  {
    get => this.m_Header;
    set
    {
      if (!(this.m_Header != value))
        return;
      this.m_Header = value;
      CommandManager.InvalidateRequerySuggested();
    }
  }

  public ImageSource ImageSource
  {
    get => this.m_ImageSource;
    set
    {
      if (this.m_ImageSource == value)
        return;
      this.m_ImageSource = value;
      CommandManager.InvalidateRequerySuggested();
    }
  }

  public ImageSource ImageSmallSource
  {
    get => this.m_ImageSmallSource;
    set
    {
      if (this.m_ImageSmallSource == value)
        return;
      this.m_ImageSmallSource = value;
      CommandManager.InvalidateRequerySuggested();
    }
  }

  public bool IsChecked
  {
    get => this.m_IsChecked;
    set
    {
      if (this.m_IsChecked == value)
        return;
      this.m_IsChecked = value;
      CommandManager.InvalidateRequerySuggested();
    }
  }

  public bool SyncIsChecked
  {
    get => this.m_SyncIsChecked;
    set => this.m_SyncIsChecked = value;
  }

  public bool SyncHeader
  {
    get => this.m_SyncHeader;
    set => this.m_SyncHeader = value;
  }

  public bool SyncImageSource
  {
    get => this.m_SyncImageSource;
    set => this.m_SyncImageSource = value;
  }

  public bool SyncImageSmallSource
  {
    get => this.m_SyncImageSmallSource;
    set => this.m_SyncImageSmallSource = value;
  }
}
