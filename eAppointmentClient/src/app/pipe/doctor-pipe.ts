import { Pipe, PipeTransform } from '@angular/core';
import { DoctorModel } from '../Models/doctor.model';

@Pipe({
  name: 'doctor',
})
export class DoctorPipe implements PipeTransform {
  transform(value: DoctorModel[], search: string): DoctorModel[] {
    if (!search) {
      return value;
    }
    return (
      value.filter((p) => p.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase())) ||
      value.filter((p) =>
        p.department.name.toLocaleLowerCase().includes(search.toLocaleLowerCase()),
      )
    );
  }
}
