import { Cell } from "./cell.model";
import { RegionCell } from "./region.cell.model";
import { Region } from "./region.model";

class Board {
  cells : Cell[][] = [];
  regions : Region[] = [];

  public getRegionCell(x: number, y: number) {
    for(let i = 0; i < this.regions.length; i++) {
      let region = this.regions[i]
      let cell = region.getCell(x,y)
      if(cell != null) {
        return cell;
      }
    }
    return new RegionCell(-1,-1);
  }
}

export { Board }
