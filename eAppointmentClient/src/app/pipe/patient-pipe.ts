import { Pipe, PipeTransform } from '@angular/core';
import { PatientModel } from '../Models/patient.model';

@Pipe({
  name: 'patient',
})
export class PatientPipe implements PipeTransform {
  transform(value: PatientModel[], search: string): PatientModel[] {
    if (!search) {
      return value;
    }
    return (
      value.filter((p) => p.fullName.toLocaleLowerCase().includes(search.toLocaleLowerCase())) ||
      value.filter((p) => p.fullAddress.toLocaleLowerCase().includes(search.toLocaleLowerCase()))
    );
  }
}
