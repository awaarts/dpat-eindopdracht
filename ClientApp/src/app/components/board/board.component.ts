import { Component, OnInit } from '@angular/core';
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

  board: Board = new Board();

  constructor() {
    this.board.cells = [
      [
        new Cell(1, [1,3,4]),
        new Cell(),
        new Cell(),
        new Cell(3, [5,3,2]),
        new Cell(3, [5,3,2]),
      ],
      [
        new Cell(),
        new Cell(),
        new Cell(8, [9, ], 'correct'),
        new Cell(),
      ],
      [
        new Cell(),
        new Cell(2, [3, 4]),
        new Cell(3, [3,2,1]),
        new Cell(),
        new Cell(3, [3,2,1]),
        new Cell(3, [3,2,1]),
      ],
      [
        new Cell(),
        new Cell(2, [3, 4]),
        new Cell(3, [3,2,1]),
        new Cell(),
        new Cell(),
      ],
      [
        new Cell(),
        new Cell(2, [3, 4]),
        new Cell(3, [3,2,1]),
        new Cell(),
        new Cell(3, [3,2,1]),
        new Cell(7, [3,2,1]),
      ],
      [
        new Cell(7, [3,2,1]),
      ]
    ]
    this.board.regions = [
      new Region([
        new RegionCell(0,0),
        new RegionCell(0,1),
        new RegionCell(0,2),
      ])
       ,new Region([
        new RegionCell(0,3),
        new RegionCell(1,3),
        new RegionCell(2,3),
        new RegionCell(3,3),
      ])
       ,new Region([
        new RegionCell(1,1),
        new RegionCell(2,1),
        new RegionCell(3,1),
      ])

    ]
    console.log(this.board.regions[0])
    console.log(this.board.getRegionCell(0,1))
  }

  ngOnInit(): void {
  }

}
