import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { LoginModel } from '../../Models/login.model';
import { FormValidateDirective } from 'form-validate-angular';

@Component({
  selector: 'app-login',
  imports: [FormsModule, FormValidateDirective],
  templateUrl: './login.html',
  styleUrl: './login.css',
})
export class Login {
  login: LoginModel = new LoginModel();
}
