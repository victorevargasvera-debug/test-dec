// Decompiled with JetBrains decompiler
// Type: AcpUI.AcpFieldToTableCellPairingInfo
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using AcpCommonLib;
using Infragistics.Windows.DataPresenter;

#nullable disable
namespace AcpUI;

internal class AcpFieldToTableCellPairingInfo
{
  private AcpFieldInfo acpFieldInfo;
  private TableCellInfo tableCellInfo;

  private AcpFieldToTableCellPairingInfo(AcpFieldInfo fieldInfo, TableCellInfo cellInfo)
  {
    this.acpFieldInfo = fieldInfo;
    this.tableCellInfo = cellInfo;
  }

  internal static AcpFieldToTableCellPairingInfo CreateFrom(IAcpField field, Cell cell)
  {
    AcpFieldInfo fieldInfo = field == null ? (AcpFieldInfo) null : new AcpFieldInfo(field.Parent.ParentRecset.RecsetId, field.Parent.FeatureSectionId, field.UIName);
    string cellMask = MaskedTableCellInfo.GetCellMask(cell);
    TableCellInfo cellInfo = cellMask == null ? new TableCellInfo(cell.Field.Label as string, CellPosition.GetColumnIndex(cell)) : (TableCellInfo) new MaskedTableCellInfo(cell.Field.Label as string, CellPosition.GetColumnIndex(cell), cellMask);
    return new AcpFieldToTableCellPairingInfo(fieldInfo, cellInfo);
  }

  internal AcpFieldInfo FieldInfo => this.acpFieldInfo;

  internal TableCellInfo CellInfo => this.tableCellInfo;
}
