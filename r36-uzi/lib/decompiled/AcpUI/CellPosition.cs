// Decompiled with JetBrains decompiler
// Type: AcpUI.CellPosition
// Assembly: AcpUI, Version=23.1.0.32, Culture=neutral, PublicKeyToken=d124d6ba4931c72b
// MVID: DC7F6A15-37A6-4183-BF9F-09213F636FB6
// Assembly location: F:\DECOMP\36-UZI\APXFamilyCPS1\lib_org\AcpUI.dll

using Infragistics.Windows.DataPresenter;
using System.Collections.Generic;
using System.Windows;

#nullable disable
namespace AcpUI;

internal struct CellPosition
{
  private int columnIndex;
  private int rowIndex;

  internal CellPosition(Cell cell)
  {
    this.columnIndex = CellPosition.GetColumnIndex(cell);
    this.rowIndex = CellPosition.GetRowIndex(cell);
  }

  internal CellPosition(int column, int row)
  {
    this.columnIndex = column;
    this.rowIndex = row;
  }

  internal int ColumnIndex => this.columnIndex;

  internal int RowIndex => this.rowIndex;

  internal static int GetColumnIndex(Cell cell)
  {
    CellCollection cells = cell.Record.Cells;
    int columnIndex = 0;
    foreach (Cell cell1 in (IEnumerable<Cell>) cells)
    {
      if (cell1.Field.Visibility == Visibility.Visible)
      {
        if (cell1 != cell)
          ++columnIndex;
        else
          break;
      }
    }
    return columnIndex;
  }

  internal static int GetRowIndex(Cell cell) => cell.Record.DataItemIndex;

  internal static CellPosition FromCell(Cell cell)
  {
    return new CellPosition(CellPosition.GetColumnIndex(cell), CellPosition.GetRowIndex(cell));
  }
}
