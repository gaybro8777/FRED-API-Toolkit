import { Injectable, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { ISourceResponse } from './source.interfaces'

@Injectable()
export class SourceService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  public get(): Observable<ISourceResponse> {
    return this.http.get<ISourceResponse>(this.baseUrl + 'api/sources');
  }

}

