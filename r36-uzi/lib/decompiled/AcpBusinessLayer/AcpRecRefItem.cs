// Decompiled with JetBrains decompiler
// Type: AcpBusinessLayer.AcpRecRefItem
// Assembly: AcpBusinessLayer, Version=23.1.0.23, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: 44CF2A76-4418-422B-9DDD-B27A71BAF20C
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpBusinessLayer.dll

#nullable disable
namespace AcpBusinessLayer;

public class AcpRecRefItem : ListItem
{
  private bool disposedValue;
  private bool isDisposeInProgress;

  public AcpRecRefItem(AcpRecRefField parent, FeatureNode node)
    : this(parent, node, true, true, false)
  {
  }

  public AcpRecRefItem(AcpRecRefField parent, FeatureNode node, bool valid, bool visible)
    : this(parent, node, valid, visible, false)
  {
  }

  public AcpRecRefItem(
    AcpRecRefField parent,
    FeatureNode node,
    bool valid,
    bool visible,
    bool temp)
    : base((AcpListField) parent, node.ReferenceKey, valid, visible, temp)
  {
    this.Node = node;
  }

  internal FeatureNode Node { get; set; }

  internal bool ForceValid
  {
    get => this.Node == null || this.Node.KeyField == null || this.Node.KeyField.ForceValid;
  }

  public override string ItemName
  {
    get => this.Node.ReferenceKey;
    set => this.OnPropertyChanged(nameof (ItemName));
  }

  protected override void Dispose(bool disposing)
  {
    if (!this.disposedValue && !this.isDisposeInProgress)
    {
      this.isDisposeInProgress = true;
      if (disposing)
        this.Node?.Dispose();
      this.disposedValue = true;
    }
    this.isDisposeInProgress = false;
    base.Dispose(disposing);
  }
}
