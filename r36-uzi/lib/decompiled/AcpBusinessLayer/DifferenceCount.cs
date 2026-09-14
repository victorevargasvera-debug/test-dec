// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.DifferenceCount
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;

#nullable disable
namespace AcpBusinessLayer;

public class DifferenceCount : IDisposable
{
  private int count;
  private bool disposedValue;

  internal DifferenceCount()
  {
  }

  internal DifferenceCount(int count)
  {
    this.count = count >= 0 ? count : throw new ArgumentOutOfRangeException(nameof (count));
  }

  public event DifferenceCountChangedEventHandler CountChanged;

  internal int Value => this.count;

  internal void Increment(string name)
  {
    ++this.count;
    if (this.CountChanged == null)
      return;
    this.CountChanged((object) this, new DifferenceCountChangedEventArgs(name, DifferenceCountChangedAction.Increment));
  }

  internal void Decrement(string name)
  {
    --this.count;
    if (this.CountChanged == null)
      return;
    this.CountChanged((object) this, new DifferenceCountChangedEventArgs(name, DifferenceCountChangedAction.Decrement));
  }

  internal void Reset(string name)
  {
    this.count = 0;
    if (this.CountChanged == null)
      return;
    this.CountChanged((object) this, new DifferenceCountChangedEventArgs(name, DifferenceCountChangedAction.Reset));
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.disposedValue)
      return;
    if (disposing)
      MemoryUtility.RemoveEventHandler("CountChanged", typeof (DifferenceCount), (object) this);
    this.disposedValue = true;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
