export class DoctorModel {
  id: string = '';
  firstName: string = '';
  lastName: string = '';
  fullName: string = '';
  department: DepartmentModel = new DepartmentModel();
  departmentValue: Number = 0;
}

export class DepartmentModel {
  name: string = '';
  value: number = 0;
}
