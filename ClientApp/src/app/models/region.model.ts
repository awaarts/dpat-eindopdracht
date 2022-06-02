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

    console.log(maxX, minX, minY, maxY)

    for(let row = minY; row <= maxY; row++ ) {

      let cells = this.cells.filter(cell => cell.y == row)

      let minRowX = Math.min(...cells.map(cell => cell.x));
      let maxRowX = Math.max(...cells.map(cell => cell.x));

      cells.filter(cell => cell.x == minRowX)[0].leftBorder = true;
      cells.filter(cell => cell.x == maxRowX)[0].rightBorder = true;
    }

    for(let col = minX; col <= maxX; col++ ) {

      let cells = this.cells.filter(cell => cell.x == col)

      let minColY = Math.min(...cells.map(cell => cell.y));
      let maxColY = Math.max(...cells.map(cell => cell.y));

      cells.filter(cell => cell.y == minColY)[0].topBorder = true;
      cells.filter(cell => cell.y == maxColY)[0].bottomBorder = true;
    }
  }

  public getCell(x: number, y:number) {
    return this.cells.filter(cell => (cell.x == x && cell.y == y))[0];
  }
}

export { Region }
