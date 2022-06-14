import {Component, EventEmitter, Inject, OnInit, Output} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  private http: HttpClient;
  private baseUrl: string;

  @Output() newBoardLoaded = new EventEmitter<string>();

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') url: string) {
    this.http = httpClient;
    this.baseUrl = url;
  }

  loadFile(event: any) {
    const formData = new FormData();
    formData.append("file", event.target.files[0]);
    this.http.post<string>(
      this.baseUrl + 'api/game',
      formData
    ).subscribe(result => {
      this.newBoardLoaded.emit(result)
    }, error => {
      console.log(error)
    });
  }

  ngOnInit(): void {
  }

}
