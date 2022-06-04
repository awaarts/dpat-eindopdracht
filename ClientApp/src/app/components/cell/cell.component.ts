import { Component, Input, OnInit } from '@angular/core';
import { Cell } from 'src/app/models/cell.model';
import { RegionCell } from 'src/app/models/region.cell.model';

@Component({
  selector: 'app-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.css']
})
export class CellComponent implements OnInit {

  @Input()
  cell: Cell;

  constructor() {
    console.log(this.cell);
  }

  ngOnInit(): void {
  }

}
