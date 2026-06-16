import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { tokenModel } from '../Models/token.model';
import { jwtDecode, JwtPayload } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})
export class Auth {
  tokenDecode: tokenModel = new tokenModel();
  constructor(private router: Router) {}

  isAuth() {
    const token: string | null = localStorage.getItem('token');
    if (token) {
      const decode: JwtPayload | any = jwtDecode(token);

      const exp = decode.exp;
      const now = new Date().getTime() / 1000;

      if (now > exp) {
        localStorage.removeItem('token');
        this.router.navigateByUrl('/login');
        return false;
      } else {
        this.tokenDecode.id =
          decode['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
        this.tokenDecode.name =
          decode['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name'];
        this.tokenDecode.email =
          decode['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress'];
        this.tokenDecode.userName = decode['UserName'];
        return true;
      }
    } else {
      this.router.navigateByUrl('/login');
      return false;
    }
  }
}
