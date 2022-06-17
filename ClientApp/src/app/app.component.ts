import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import {Board} from "./models/board.model";
import {Cell} from "./models/cell.model";
import {RegionCell} from "./models/region.cell.model"
import {Region} from "./models/region.model"

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  board = new Board();
  selectedFixedValue = true;

  private http: HttpClient;
  private baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') url: string) {
    this.http = httpClient;
    this.baseUrl = url;

    this.http.get<string>(
      this.baseUrl + 'api/game'
    ).subscribe(result => {
      if(result !== null) {
        this.newBoardLoaded(result);
      }
    }, error => {
      console.log(error)
    });
  }

  newBoardLoaded(board: any) {
    this.board.cells = board.cells.map(
        (row: Array<any>) => row.map(
        (cell) => { return cell ?
          new Cell(
            cell.fixedValue,
            [cell.helperValue],
            cell.cellState?.state,
            cell.x,
            cell.y,
          )
         : null})
      );

    let regions = board.groups.filter((group: any) => group.type == "region");
    this.board.regions = regions.map((region: any) => {
      return new Region(
        region.cells.map((cell: any) => {
          return new RegionCell(cell.x, cell.y)
        })
      )
    })
    this.board.setCellBorders();
  }
}
