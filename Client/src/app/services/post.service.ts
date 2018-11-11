import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, mergeMap, tap, switchMap, flatMap, filter } from 'rxjs/operators';

@Injectable()
export class PostService {

  private cachePosts: any[];
  private cachePostsSize: number;

  constructor(private http: HttpClient) {}
}
