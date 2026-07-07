import { Component } from '@angular/core';
import { departments } from '../../Constans';
import { DoctorModel } from '../../Models/doctor.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DxSchedulerModule } from 'devextreme-angular';

@Component({
  selector: 'app-home',
  imports: [FormsModule, CommonModule, DxSchedulerModule],
  templateUrl: './home.html',
  styleUrl: './home.css',
})
export class Home {
  departments = departments;
  doctors: DoctorModel[] = [];

  selectedDepartmentValue: number = 0;
  selectedDoctorId: string = '';
}
