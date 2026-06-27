import {
  ChangeDetectorRef,
  Component,
  ElementRef,
  OnInit,
  ViewChild,
  viewChild,
} from '@angular/core';
import { RouterLink } from '@angular/router';
import { Http } from '../../Services/http';
import { DoctorModel } from '../../Models/doctor.model';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { departments } from '../../Constans';
import { FormValidateDirective } from 'form-validate-angular';
import { DoctorPipe } from '../../pipe/doctor-pipe';

@Component({
  selector: 'app-doctors',
  imports: [RouterLink, CommonModule, FormsModule, FormValidateDirective, DoctorPipe],
  templateUrl: './doctors.html',
  styleUrl: './doctors.css',
})
export class Doctors implements OnInit {
  doctors: DoctorModel[] = [];
  departmens = departments;
  @ViewChild('addDoctorModalCloseBtn') addDoctorModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  @ViewChild('updateDoctorModalCloseBtn') updateDoctorModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  constructor(
    private http: Http,
    private cdr: ChangeDetectorRef,
  ) {}

  search: string = '';
  createModel: DoctorModel = new DoctorModel();
  updateModel: DoctorModel = new DoctorModel();

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<DoctorModel[]>('Doctors/GetAll', {}, (res) => {
      this.doctors = res.data;
      this.cdr.detectChanges();
    });
  }
  add(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Doctors/Create', this.createModel, (res) => {
        this.getAll();
        this.addDoctorModalCloseBtn?.nativeElement.click();
        this.createModel = new DoctorModel();
      });
    }
  }
  delete(id: string) {
    this.http.post<string>('Doctors/DeleteById', { id }, (res) => {
      this.getAll();
      alert('Kayıt başarıyla silindi.');
    });
  }

  get(data: DoctorModel) {
    this.updateModel = { ...data };
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Doctors/Update', this.updateModel, (res) => {
        this.getAll();
        this.updateDoctorModalCloseBtn?.nativeElement.click();
      });
    }
  }
}
