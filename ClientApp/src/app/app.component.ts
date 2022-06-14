import { Component } from '@angular/core';
import {Board} from "./models/board.model";
import {Cell} from "./models/cell.model";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'app';
  board = new Board();

  newBoardLoaded(board: any) {
    this.board.cells = board.cells.map(
        (row: Array<any>) => row.map(
        (cell: {
          fixedValue: number;
          helperValue: number;
          cellState: { state: string; };
        }) => {
          return new Cell(
            cell.fixedValue,
            [cell.helperValue],
            cell.cellState?.state
          );
        })
      );
  }
}
