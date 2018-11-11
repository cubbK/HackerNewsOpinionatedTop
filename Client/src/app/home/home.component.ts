import { Component, OnInit } from '@angular/core';
import { PostService } from '../services/post.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  articles;
  constructor(private postService: PostService) {
    this.articles = this.postService.getAll();
    this.postService.getAll().subscribe(data => console.log(data))
  }

  ngOnInit() {
  }

}
