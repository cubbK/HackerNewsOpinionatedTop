import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { PostService } from './services/post.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _api: PostService) {}

  title = 'Client';
  private subscription: any;
  public feed: Array<any>;

  ngOnInit() {
      this._api.getPosts().subscribe(data => console.log(data));
  }
}
