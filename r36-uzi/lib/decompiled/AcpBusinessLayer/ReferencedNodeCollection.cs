// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.ReferencedNodeCollection
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace AcpBusinessLayer;

public class ReferencedNodeCollection : KeyedCollection<string, FeatureNode>, IDisposable
{
  private bool disposedValue;
  private bool isDisposeInProgress;

  private ReferencedNodeCollection()
  {
  }

  internal ReferencedNodeCollection(Recordset container)
    : this()
  {
    this.Container = container;
  }

  internal Recordset Container { get; private set; }

  protected override string GetKeyForItem(FeatureNode item)
  {
    if (this.Dictionary != null && this.Dictionary.Values.Contains(item))
    {
      foreach (string key in (IEnumerable<string>) this.Dictionary.Keys)
      {
        if (this.Dictionary[key] == item)
          return key;
      }
    }
    return item.ReferenceKey;
  }

  internal void ChangeKey(FeatureNode item, string newKey)
  {
    try
    {
      if (this.Contains(newKey))
      {
        if (this[newKey] == item)
          return;
        this.Remove(newKey);
        this.Container.ValidateReferenceKey(newKey);
        this.ChangeItemKey(item, newKey);
      }
      else if (!this.Contains(item))
      {
        this.Container.ValidateReferenceKey(newKey);
        this.ChangeItemKey(item, newKey);
      }
      else
        this.ChangeItemKey(item, newKey);
    }
    catch (Exception ex)
    {
    }
  }

  internal void UpdateKey(FeatureNode item) => this.ChangeKey(item, item.ReferenceKey);

  internal FeatureNode LookupHelper(string key)
  {
    return key != null && this.Contains(key) ? this[key] : (FeatureNode) null;
  }

  internal void DeleteItem(FeatureNode item)
  {
    if (!this.Contains(item))
      return;
    this.UpdateKey(item);
    this.Remove(item.ReferenceKey);
  }

  protected virtual void Dispose(bool disposing)
  {
    if (this.isDisposeInProgress)
      return;
    if (!this.disposedValue)
    {
      if (disposing)
      {
        this.isDisposeInProgress = true;
        this.Container?.Dispose();
        if (this.Items != null)
        {
          foreach (FeatureNode featureNode in (IEnumerable<FeatureNode>) this.Items)
            featureNode?.Dispose();
        }
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
