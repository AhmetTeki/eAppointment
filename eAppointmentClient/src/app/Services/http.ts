import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultModel } from '../Models/result.model';
import { api } from '../Constans';
import { Error } from './error';

@Injectable({
  providedIn: 'root',
})
export class Http {
  token: string = '';
  constructor(
    private http: HttpClient,
    private error: Error,
  ) {
    if (localStorage.getItem('token')) {
      this.token = localStorage.getItem('token') ?? '';
    }
  }

  post<T>(
    apiUrl: string,
    body: any,
    callback: (res: ResultModel<T>) => void,
    errorCallback?: (err: HttpErrorResponse) => void,
  ) {
    this.http
      .post<ResultModel<T>>(`${api}/${apiUrl}`, body, {
        headers: {
          Authorization: 'Bearer ' + this.token,
        },
      })
      .subscribe({
        next: (res) => {
          callback(res);
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
          if (errorCallback !== undefined) {
            errorCallback(err);
          }
        },
      });
  }
}
