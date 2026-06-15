import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResultModel } from '../Models/result.model';
import { api } from '../Constans';

@Injectable({
  providedIn: 'root',
})
export class Http {
  constructor(private http: HttpClient) {}

  post<T>(
    apiUrl: string,
    body: any,
    callback: (res: ResultModel<T>) => void,
    errorCallback?: (err: HttpErrorResponse) => void,
  ) {
    this.http.post<ResultModel<T>>(`${api}/${apiUrl}`, body).subscribe({
      next: (res) => {
        callback(res);
      },
      error: (err: HttpErrorResponse) => {
        if (errorCallback !== undefined) errorCallback(err);
      },
    });
  }
}
