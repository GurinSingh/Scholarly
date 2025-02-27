import { Injectable } from '@angular/core';
import { article } from '../../../models/article/article';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDbServiceWithSelector } from '../IDbServiceWithSelector';
import { IDbService } from '../IDbService';

@Injectable({
  providedIn: 'root'
})
export class ArticleService implements IDbService<article>, IDbServiceWithSelector<article> {
  private _url: string = 'article';

  constructor(private http: HttpClient) { }
  
  updateBySelector(selector: string): Observable<void> {
    throw new Error('Method not implemented.');
  }
  deleteBySelector(selector: string): Observable<void> {
    throw new Error('Method not implemented.');
  }
  getAll(): Observable<article[]> {
    return this.http.get<article[]>('/article/get/');
  }
  getById(id: number): Observable<article> {
    return this.http.get<article>('/article/getById/' + id);
  }
  getBySelector(selector: string): Observable<article> {
    return this.http.get<article>('/article/get/' + selector);
  }
 
  insert(entity: article): Observable<void> {
    return this.http.post<void>('/article/save', entity);
  }
  update(entity: article): Observable<void> {
    throw new Error('Method not implemented.');
  }
  delete(id: number): Observable<void> {
    throw new Error('Method not implemented.');
  }
}
