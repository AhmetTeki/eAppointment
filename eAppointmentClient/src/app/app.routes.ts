import { Routes } from '@angular/router';
import { Layouts } from './Components/layouts/layouts';
import { Home } from './Components/home/home';
import { Login } from './Components/login/login';
import { NotFound } from './Components/not-found/not-found';

export const routes: Routes = [
  {
    path: 'login',
    component: Login,
  },
  {
    path: '',
    component: Layouts,
    children: [
      {
        path: '',
        component: Home,
      },
    ],
  },
  {
    path: '**',
    component: NotFound,
  },
];
