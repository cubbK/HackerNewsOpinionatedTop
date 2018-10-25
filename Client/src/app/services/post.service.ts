import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Http, Headers, RequestOptions } from '@angular/http';
import { map, mergeMap, tap, switchMap, flatMap, filter } from 'rxjs/operators';

@Injectable()
export class PostService {

  private cachePosts: any[];
  private cachePostsSize: number;

  constructor(private _api: Http) {}

  getPosts(): Observable<any> {
    return this._api
      .get(`https://localhost:5001/api/articles`)
      .pipe(map(data => data.json()))
      .pipe(tap(data => ((this.cachePosts = data), (this.cachePostsSize = data.length))));
  }
}
