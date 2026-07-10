import { Component } from '@angular/core';
import { departments } from '../../Constans';
import { DoctorModel } from '../../Models/doctor.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';
import { Http } from '../../Services/http';
import { AppointmentModel } from '../../Models/appointment.model';

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule, DxSchedulerModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  constructor(private http: Http) {}
  departments = departments;
  doctors: DoctorModel[] = [];
  appointments: AppointmentModel[] = [];

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
}
