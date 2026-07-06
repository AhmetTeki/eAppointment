import { ChangeDetectorRef, Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PatientModel } from '../../Models/patient.model';
import { Http } from '../../Services/http';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterLink } from '@angular/router';
import { FormValidateDirective } from 'form-validate-angular';
import { PatientPipe } from '../../pipe/patient-pipe';

@Component({
  selector: 'app-patient',
  imports: [RouterLink, CommonModule, FormsModule, FormValidateDirective, PatientPipe],
  templateUrl: './patients.html',
  styleUrl: './patients.css',
})
export class Patients implements OnInit {
  patients: PatientModel[] = [];

  @ViewChild('addPatientModalCloseBtn') addPatientModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  @ViewChild('updatePatientModalCloseBtn') updatePatientModalCloseBtn:
    | ElementRef<HTMLButtonElement>
    | undefined;

  constructor(
    private http: Http,
    private cdr: ChangeDetectorRef,
  ) {}

  search: string = '';
  createModel: PatientModel = new PatientModel();
  updateModel: PatientModel = new PatientModel();

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.http.post<PatientModel[]>('Patients/GetAll', {}, (res) => {
      this.patients = res.data;
      this.cdr.detectChanges();
    });
  }
  add(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Patients/Create', this.createModel, (res) => {
        this.getAll();
        this.addPatientModalCloseBtn?.nativeElement.click();
        this.createModel = new PatientModel();
      });
    }
  }
  delete(id: string) {
    this.http.post<string>('Patients/DeleteById', { id }, (res) => {
      this.getAll();
      alert('Kayıt başarıyla silindi.');
    });
  }

  get(data: PatientModel) {
    this.updateModel = { ...data };
  }

  update(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Patients/Update', this.updateModel, (res) => {
        this.getAll();
        this.updatePatientModalCloseBtn?.nativeElement.click();
      });
    }
  }
}
