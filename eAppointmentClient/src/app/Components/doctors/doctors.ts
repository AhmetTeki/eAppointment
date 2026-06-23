import { Component, ElementRef, OnInit, ViewChild, viewChild } from '@angular/core';
import { RouterLink } from '@angular/router';
import { Http } from '../../Services/http';
import { DoctorModel } from '../../Models/doctor.model';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { departments } from '../../Constans';
import { FormValidateDirective } from 'form-validate-angular';

@Component({
  selector: 'app-doctors',
  imports: [RouterLink, CommonModule, FormsModule, FormValidateDirective],
  templateUrl: './doctors.html',
  styleUrl: './doctors.css',
})
export class Doctors implements OnInit {
  doctors: DoctorModel[] = [];
  departmens = departments;
  @ViewChild('addDoctorModalCloseBtn') addDoctorModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  constructor(private http: Http) {}

  createModel: DoctorModel = new DoctorModel();

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<DoctorModel[]>('Doctors/GetAll', {}, (res) => {
      this.doctors = res.data;
    });
  }
  add(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Doctors/Create', this.createModel, (res) => {
        console.log(res);
        this.getAll();
        this.addDoctorModalCloseBtn?.nativeElement.click();
        this.createModel = new DoctorModel();
      });
    }
  }
}
