import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { LoginModel } from '../../Models/login.model';
import { FormValidateDirective } from 'form-validate-angular';
import { Http } from '../../Services/http';
import { LoginResponseModel } from '../../Models/login-response.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  imports: [FormsModule, FormValidateDirective],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  login: LoginModel = new LoginModel();
  constructor(
    private http: Http,
    private router: Router,
  ) {}

  signIn(form: NgForm) {
    if (form.valid) {
      this.http.post<LoginResponseModel>('Auth/Login', this.login, (res) => {
        if (res.data !== undefined) {
          localStorage.setItem('token', res.data.token);
          this.router.navigateByUrl('/');
        }
      });
    }
  }
}
