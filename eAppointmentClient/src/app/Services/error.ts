import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class Error {
  constructor() {}

  errorHandler(err: HttpErrorResponse) {
    console.log(err);
    alert('Bir hata oluştu: ' + err.message);
  }
}
