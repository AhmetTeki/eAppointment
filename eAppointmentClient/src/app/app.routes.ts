import { Routes } from '@angular/router';
import { Layouts } from './Components/layouts/layouts';
import { Home } from './Components/home/home';
import { Login } from './Components/login/login';
import { NotFound } from './Components/not-found/not-found';
import { inject } from '@angular/core';
import { Auth } from './Services/auth';
import { Doctors } from './Components/doctors/doctors';

export const routes: Routes = [
  {
    path: 'login',
    component: Login,
  },
  {
    path: '',
    component: Layouts,
    canActivateChild: [() => inject(Auth).isAuth()],
    children: [
      {
        path: '',
        component: Home,
      },
      {
        path: 'doctors',
        component: Doctors,
      },
    ],
  },
  {
    path: '**',
    component: NotFound,
  },
];
