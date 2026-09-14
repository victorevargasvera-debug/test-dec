// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ListItem
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.ComponentModel;
using System.Windows.Media.Imaging;

#nullable disable
namespace AcpBusinessLayer;

public class ListItem : INotifyPropertyChanged, IDisposable
{
  private string name;
  private bool valid;
  private bool visible;
  private BitmapImage image;
  private bool disposedValue;

  internal AcpListField parent { get; set; }

  public ListItem(AcpListField parent, string name)
    : this(parent, name, true, true, false)
  {
  }

  public ListItem(AcpListField parent, string name, bool valid, bool visible)
    : this(parent, name, valid, visible, false)
  {
  }

  public ListItem(AcpListField parent, string name, bool valid, bool visible, bool temp)
  {
    this.name = name;
    this.valid = valid;
    this.visible = visible;
    this.parent = parent;
    this.Temporary = temp;
  }

  public virtual string ItemName
  {
    get => this.name;
    set
    {
      this.name = value;
      this.OnPropertyChanged(nameof (ItemName));
    }
  }

  public virtual bool ItemValidity
  {
    get => this.valid;
    set
    {
      this.valid = value;
      this.OnPropertyChanged(nameof (ItemValidity));
    }
  }

  public bool ItemVisibility
  {
    get => this.parent.SerializeItems ? this.visible : this.parent.GetItemVisibility(this);
    set
    {
      if (this.parent.SerializeItems)
        this.visible = value;
      else
        this.parent.SetItemVisibility(this, value);
    }
  }

  internal bool Temporary { get; private set; }

  public BitmapImage ItemImage
  {
    get => this.image;
    set
    {
      this.image = value;
      this.OnPropertyChanged(nameof (ItemImage));
    }
  }

  public override string ToString() => this.ItemName;

  public event PropertyChangedEventHandler PropertyChanged;

  protected void OnPropertyChanged(string info)
  {
    if (this.PropertyChanged == null)
      return;
    this.PropertyChanged((object) this, new PropertyChangedEventArgs(info));
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.disposedValue)
      return;
    if (disposing)
      MemoryUtility.RemoveEventHandler("PropertyChanged", typeof (ListItem), (object) this);
    this.disposedValue = true;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
