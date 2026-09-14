// Decompiled with JetBrains decompiler
// Type: AcpUI.ImportExport.ImportExportItem
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

#nullable disable
namespace AcpUI.ImportExport;

public class ImportExportItem
{
  public string recsetName;
  public int recsetDataTransferOrder;

  internal ImportExportItem(string recsetName, int recsetDataTransferOrder)
  {
    this.recsetName = recsetName;
    this.recsetDataTransferOrder = recsetDataTransferOrder;
  }

  public string RecsetName
  {
    get => this.recsetName;
    set => this.recsetName = value;
  }

  internal int RecsetDataTransferOrder
  {
    get => this.recsetDataTransferOrder;
    set => this.recsetDataTransferOrder = value;
  }
}
