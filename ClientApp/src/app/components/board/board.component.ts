import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import { Board } from 'src/app/models/board.model';
import { Cell } from 'src/app/models/cell.model';
import { RegionCell } from 'src/app/models/region.cell.model';
import { Region } from 'src/app/models/region.model';

@Component({
  selector: 'app-board',
  templateUrl: './board.component.html',
  styleUrls: ['./board.component.css']
})
export class BoardComponent implements OnInit {

  @Input() board: Board = new Board();
  @Input() selectedFixedValue = true;

  @Output() boardUpdated = new EventEmitter<string>();

  constructor() {
  }

  ngOnInit(): void {
  }

  updateBoard(board: string): void {
    this.boardUpdated.emit(board);
  }

}
