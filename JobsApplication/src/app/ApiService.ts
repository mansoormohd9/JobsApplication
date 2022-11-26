import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IApiService } from './ApiService.interface';
import { Observable } from 'rxjs';

@Injectable()
export class MyService implements IApiService {

  constructor(private httpClient: HttpClient) { }

  get(): void {
    this.httpClient.get('url');
  }

  delete(url: string): Observable<Object> {
    return this.httpClient.delete(url);
  }
}