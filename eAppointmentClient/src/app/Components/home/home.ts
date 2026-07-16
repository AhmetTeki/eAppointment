import { Component, ElementRef, ViewChild, viewChild } from '@angular/core';
import { departments } from '../../Constans';
import { DoctorModel } from '../../Models/doctor.model';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule, DatePipe } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';
import { Http } from '../../Services/http';
import { AppointmentModel } from '../../Models/appointment.model';
import { CreateAppointmentModel } from '../../Models/create-appoinment.model';
import { FormValidateDirective } from 'form-validate-angular';
import { PatientModel } from '../../Models/patient.model';

declare const $: any;

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule, DxSchedulerModule, FormValidateDirective],
  templateUrl: './home.html',
  styleUrl: './home.css',
  providers: [DatePipe],
})
export class Home {
  constructor(
    private http: Http,
    private date: DatePipe,
  ) {}
  departments = departments;
  doctors: DoctorModel[] = [];
  appointments: AppointmentModel[] = [];
  createModel: CreateAppointmentModel = new CreateAppointmentModel();
  @ViewChild('addModalCloseBtn') addModalCloseBtn: ElementRef<HTMLButtonElement> | undefined;
  selectedDepartmentValue: number = 0;
  selectedDoctorId: string = '';

  getAllDoctor() {
    this.selectedDoctorId = '';
    if (this.selectedDepartmentValue > 0) {
      this.http.post<DoctorModel[]>(
        'Appointments/GetDoctorsByDepartment',
        {
          departmentValue: +this.selectedDepartmentValue,
        },
        (res) => {
          this.doctors = res.data;
        },
      );
    }
  }

  GetAllAppointments() {
    if (this.selectedDoctorId) {
      this.http.post<AppointmentModel[]>(
        'Appointments/GetAllByDoctorId',
        {
          doctorId: this.selectedDoctorId,
        },
        (res) => {
          this.appointments = res.data;
        },
      );
    }
  }

  onAppointmentFormOpening(event: any) {
    event.cancel = true;
    this.createModel.startDate =
      this.date.transform(event.appointmentData.startDate, 'dd.MM.yyyy HH:mm') ?? '';
    this.createModel.endDate =
      this.date.transform(event.appointmentData.endDate, 'dd.MM.yyyy HH:mm') ?? '';
    this.createModel.doctorId = this.selectedDoctorId;
    $('#addModal').modal('show');
  }

  getPatient() {
    this.http.post<PatientModel>(
      'Appointments/GetPatientByIdentityNumber',
      {
        identityNumber: this.createModel.identityNumber,
      },
      (res) => {
        if (res.data === null) {
          this.createModel.patientId = null;
          this.createModel.city = '';
          this.createModel.firstName = '';
          this.createModel.lastName = '';
          this.createModel.town = '';
          this.createModel.fullAddress = '';
        }

        this.createModel.patientId = res.data.id;
        this.createModel.city = res.data.city;
        this.createModel.firstName = res.data.firstName;
        this.createModel.lastName = res.data.lastName;
        this.createModel.town = res.data.town;
        this.createModel.fullAddress = res.data.fullAddress;
      },
    );
  }

  create(form: NgForm) {
    if (form.valid) {
      this.http.post<string>('Appointments/Create', this.createModel, (res) => {
        alert('Success');
        this.addModalCloseBtn?.nativeElement.click();
        this.createModel = new CreateAppointmentModel();
        this.GetAllAppointments;
      });
    }
  }

  onAppointmentDeleted(event: any) {
    event.cancel = true;
  }
  onAppointmentDeleting(event: any) {
    event.cancel = true;
    this.http.post('Appointments/Delete', { id: event.appointmentData.id }, (res) => {
      alert('Succes');
      this.GetAllAppointments();
    });
  }

  onAppointmentUpdating(event: any) {
    event.cancel = true;
    const data = {
      id: event.oldData.id,
      startDate: this.date.transform(event.newData.startDate),
      endDate: this.date.transform(event.newData.endDate),
    };
    this.http.post('Appointments/Update', data, (res) => {
      alert('Succes');
      this.GetAllAppointments();
    });
  }
}
