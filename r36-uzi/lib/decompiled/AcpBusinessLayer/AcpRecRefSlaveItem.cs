// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpRecRefSlaveItem
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Diagnostics;

#nullable disable
namespace AcpBusinessLayer;

[DebuggerDisplay("Name={SlaveField.UIName}, ChildSection={ChildSectionId}")]
public class AcpRecRefSlaveItem : IDisposable
{
  private bool disposedValue;
  private bool isDisposeInProgress;

  private AcpRecRefSlaveItem()
  {
  }

  public AcpRecRefSlaveItem(AcpRecRefField slave, int childSectionId)
  {
    this.SlaveField = slave;
    this.ChildSectionId = childSectionId;
  }

  internal AcpRecRefField SlaveField { get; private set; }

  internal int ChildSectionId { get; private set; }

  protected virtual void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
      {
        this.isDisposeInProgress = true;
        this.SlaveField?.Dispose();
      }
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
  }

  public void Dispose()
  {
    this.Dispose(true);
    GC.SuppressFinalize((object) this);
  }
}
