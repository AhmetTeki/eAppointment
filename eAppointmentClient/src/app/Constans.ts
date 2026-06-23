import { DepartmentModel } from './Models/doctor.model';

export const api: string = 'https://localhost:7246/api';

export const departments: DepartmentModel[] = [
  { name: 'Acil', value: 1 },
  { name: 'Radyoloji', value: 2 },
  { name: 'Kardiyoloji', value: 3 },
  { name: 'Dermotoloji', value: 4 },
  { name: 'Psikiyatri', value: 5 },
];
