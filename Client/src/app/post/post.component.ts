import { Component, Input } from '@angular/core';

/**
 * @title Card with multiple sections
 */
@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
})
export class PostComponent {
  @Input() title: string;
  @Input() description: string;
}
