import { HttpClient } from '@angular/common/http';
import { ValueConverter } from '@angular/compiler/src/render3/view/template';
import {Component, EventEmitter, Inject, Input, OnInit, Output} from '@angular/core';
import { Cell } from 'src/app/models/cell.model';
import { RegionCell } from 'src/app/models/region.cell.model';

@Component({
  selector: 'app-cell',
  templateUrl: './cell.component.html',
  styleUrls: ['./cell.component.css']
})
export class CellComponent implements OnInit {

  @Input() selectedFixedValue = true;
  @Input() cell: Cell;

  @Output() cellUpdated = new EventEmitter<string>();

  private http: HttpClient;
  private baseUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') url: string) {
    this.http = httpClient;
    this.baseUrl = url;
  }

  ngOnInit(): void {
  }

  updateCell(): void {
    this.http.post<string>(
      this.baseUrl + `api/game/${
        this.selectedFixedValue ? 'cell' : 'helpervalue'}?x=${this.cell.x}&y=${this.cell.y}&newValue=${this.cell.value ?? -1}`,
      {}
    ).subscribe((result) => {
      this.cellUpdated.emit(result)
    }, error => {
      console.log(error)
    });
  }

}
