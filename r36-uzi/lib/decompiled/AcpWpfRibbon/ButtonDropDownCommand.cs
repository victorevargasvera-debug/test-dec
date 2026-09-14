// Decompiled with JetBrains decompiler
// Type: DevComponents.WpfRibbon.ButtonDropDownCommand
// Assembly: AcpWpfRibbon, Version=23.0.0.26, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 45A745B5-88C3-40EE-B1E5-8DBA2EACD529
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpWpfRibbon.dll

using System;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

#nullable disable
namespace DevComponents.WpfRibbon;

public class ButtonDropDownCommand : RoutedCommand, IButtonDropDownCommandExtender
{
  private string m_Header = string.Empty;
  private ImageSource m_ImageSource;
  private ImageSource m_ImageSmallSource;
  private string m_ImageSourceString = "";
  private string m_ImageSmallSourceString = "";
  private bool m_SyncHeader = true;
  private bool m_SyncImageSource = true;
  private bool m_SyncImageSmallSource = true;

  public ButtonDropDownCommand()
  {
  }

  public ButtonDropDownCommand(string header, string name, Type ownerType)
    : this(header, name, string.Empty, string.Empty, ownerType, (InputGestureCollection) null)
  {
  }

  public ButtonDropDownCommand(
    string header,
    string name,
    Type ownerType,
    InputGestureCollection inputGestures)
    : this(header, name, string.Empty, string.Empty, ownerType, inputGestures)
  {
  }

  public ButtonDropDownCommand(string header, string name, string image, Type ownerType)
    : this(header, name, image, string.Empty, ownerType, (InputGestureCollection) null)
  {
  }

  public ButtonDropDownCommand(
    string header,
    string name,
    string image,
    Type ownerType,
    InputGestureCollection inputGestures)
    : this(header, name, image, string.Empty, ownerType, inputGestures)
  {
  }

  public ButtonDropDownCommand(
    string header,
    string name,
    string image,
    string imageSmall,
    Type ownerType)
    : this(header, name, image, imageSmall, ownerType, (InputGestureCollection) null)
  {
  }

  public ButtonDropDownCommand(
    string header,
    string name,
    string image,
    string imageSmall,
    Type ownerType,
    InputGestureCollection inputGestures)
    : base(name, ownerType, inputGestures)
  {
    if (header != null)
      this.m_Header = header;
    if (image != null && image.Length > 0)
      this.m_ImageSourceString = image;
    if (imageSmall == null || imageSmall.Length <= 0)
      return;
    this.m_ImageSmallSourceString = imageSmall;
  }

  public ButtonDropDownCommand(
    string header,
    string name,
    ImageSource image,
    ImageSource imageSmall,
    Type ownerType,
    InputGestureCollection inputGestures)
    : base(name, ownerType, inputGestures)
  {
    if (header != null)
      this.m_Header = header;
    this.m_ImageSource = image;
    this.m_ImageSmallSource = imageSmall;
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
    get
    {
      if (this.m_ImageSource == null && this.m_ImageSourceString.Length > 0)
        this.m_ImageSource = this.LoadImage(this.m_ImageSourceString);
      return this.m_ImageSource;
    }
    set
    {
      if (this.m_ImageSource == value)
        return;
      this.m_ImageSource = value;
      CommandManager.InvalidateRequerySuggested();
    }
  }

  private ImageSource LoadImage(string source)
  {
    ImageSource imageSource = (ImageSource) null;
    try
    {
      imageSource = (ImageSource) new BitmapImage(new Uri(source, UriKind.RelativeOrAbsolute));
    }
    catch
    {
    }
    return imageSource;
  }

  public ImageSource ImageSmallSource
  {
    get
    {
      if (this.m_ImageSmallSource == null && this.m_ImageSmallSourceString.Length > 0)
        this.m_ImageSmallSource = this.LoadImage(this.m_ImageSmallSourceString);
      return this.m_ImageSmallSource;
    }
    set
    {
      if (this.m_ImageSmallSource == value)
        return;
      this.m_ImageSmallSource = value;
      CommandManager.InvalidateRequerySuggested();
    }
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
