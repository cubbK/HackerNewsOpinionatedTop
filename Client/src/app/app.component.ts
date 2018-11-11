import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { PostService } from './services/post.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private http: HttpClient) {}

  title = 'Client';
  private subscription: any;
  public feed: Array<any>;

  ngOnInit() {
      this.http.get('/articles').subscribe(data => console.log(data));
      // this._api.getPosts().subscribe(data => console.log(data));
  }
}
