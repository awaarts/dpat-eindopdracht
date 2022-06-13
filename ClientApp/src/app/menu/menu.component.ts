import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {
  private http: HttpClient;
  private baseUrl: string;
  test: any;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') url: string) {
    this.http = httpClient;
    this.baseUrl = url;
  }

  ngOnInit(): void {
    this.http.get<string>(this.baseUrl + 'api/game').subscribe(result => {
      console.log('hello', result)
      this.test = result;
    });
  }

}
