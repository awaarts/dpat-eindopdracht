import { RegionCell } from "./region.cell.model";

class Region {
  cells: RegionCell[] = []

  constructor(cells: RegionCell[]) {
    this.cells = cells;
    this.setCellBorders();
  }

  setCellBorders() {
    let maxX = Math.max(...this.cells.map(cell => cell.x));
    let minX = Math.min(...this.cells.map(cell => cell.x));
    let minY = Math.min(...this.cells.map(cell => cell.y));
    let maxY = Math.max(...this.cells.map(cell => cell.y));

      let bottomCells = this.cells.filter(cell => cell.x == maxX);
      bottomCells.forEach(cell => cell.bottomBorder = true);

      let topCells = this.cells.filter(cell => cell.x == minX);
      topCells.forEach(cell => cell.topBorder = true);


    let rightCells = this.cells.filter(cell => cell.y == maxY);
    rightCells.forEach(cell => cell.rightBorder = true);

    let leftCells = this.cells.filter(cell => cell.y == minY);
    leftCells.forEach(cell => cell.leftBorder = true);

  }

  public getCell(x: number, y:number) {
    return this.cells.filter(cell => (cell.x == x && cell.y == y))[0];
  }
}

export { Region }
